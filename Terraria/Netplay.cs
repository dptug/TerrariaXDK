// Type: Terraria.Netplay
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Terraria
{
  public sealed class Netplay
  {
    public static List<SignedInGamer> gamersWhoReceivedInvite = new List<SignedInGamer>(4);
    public static List<SignedInGamer> gamersWaitingToJoinInvite = new List<SignedInGamer>(4);
    public static List<UI> gamersWaitingForPlayerId = new List<UI>(4);
    public static List<UI> gamersWaitingToSendSpawn = new List<UI>(4);
    public static List<UI> gamersWaitingToSpawn = new List<UI>(4);
    public static List<NetClient> clients = new List<NetClient>(7);
    public static bool[] playerSlots = new bool[8];
    public static List<JoinableSession> availableSessions = new List<JoinableSession>(32);
    private static Thread sessionFinderThread = (Thread) null;
    private static volatile bool stopSessionFinderThread = false;
    public static AutoResetEvent sessionReadyEvent = new AutoResetEvent(false);
    public static bool disconnect;
    public static bool stopSession;
    public static bool hookEvents;
    public static bool isJoiningRemoteInvite;
    public static LocalNetworkGamer gamer;
    public static NetworkSession session;
    public static InviteAcceptedEventArgs invite;
    public static Thread sessionThread;
    public static Netplay.ClientState clientState;
    public static int clientStatusCount;
    public static int clientStatusMax;

    static Netplay()
    {
    }

    public static void Init()
    {
      Netplay.disconnect = false;
      Netplay.hookEvents = false;
      Netplay.stopSession = false;
      Netplay.clientState = Netplay.ClientState.JOINING;
      Netplay.clientStatusCount = 0;
      Netplay.clientStatusMax = 0;
    }

    public static void ResetSections()
    {
      for (int index = Netplay.clients.Count - 1; index >= 0; --index)
        Netplay.clients[index].ResetSections();
    }

    public static void ResetSections(ref Vector2i min, ref Vector2i max)
    {
      for (int index = Netplay.clients.Count - 1; index >= 0; --index)
        Netplay.clients[index].ResetSections(ref min, ref max);
    }

    public static void CreateSession()
    {
      NetworkSessionType networkSessionType = Main.netMode != 0 ? NetworkSessionType.PlayerMatch : NetworkSessionType.Local;
      try
      {
        List<SignedInGamer> list = new List<SignedInGamer>(1);
        list.Add(UI.main.signedInGamer);
        NetworkSessionProperties sessionProperties = new NetworkSessionProperties();
        ulong xuid = GamerExtensions.GetXuid((Gamer) UI.main.signedInGamer);
        if (UI.main.isInviteOnly)
        {
          sessionProperties.set_Item(2, new int?(-559038737));
        }
        else
        {
          sessionProperties.set_Item(0, new int?((int) xuid));
          sessionProperties.set_Item(1, new int?((int) (xuid >> 32)));
        }
        int num1 = 8;
        int num2 = 0;
        if (!Main.IsTutorial() && UI.main.isInviteOnly)
          num2 = 7;
        Netplay.session = NetworkSession.Create(networkSessionType, (IEnumerable<SignedInGamer>) list, num1, num2, sessionProperties);
        Netplay.session.AllowJoinInProgress = true;
        Netplay.session.AllowHostMigration = false;
        Netplay.hookEvents = true;
        Netplay.session.StartGame();
      }
      catch (Exception ex)
      {
        UI.Error(Lang.menu[5], Lang.inter[20], false);
        UI.main.menuType = MenuType.MAIN;
        Main.netMode = 0;
        Netplay.disconnect = true;
      }
    }

    public static void HookSessionEvents()
    {
      Netplay.session.add_GamerJoined(new EventHandler<GamerJoinedEventArgs>(Netplay.GamerJoinedEventHandler));
      Netplay.session.add_GamerLeft(new EventHandler<GamerLeftEventArgs>(Netplay.GamerLeftEventHandler));
      Netplay.session.add_GameEnded(new EventHandler<GameEndedEventArgs>(Netplay.GameEndedEventHandler));
      Netplay.session.add_SessionEnded(new EventHandler<NetworkSessionEndedEventArgs>(Netplay.SessionEndedEventHandler));
      Netplay.hookEvents = false;
    }

    public static void DisposeSession()
    {
      Netplay.session.remove_GamerJoined(new EventHandler<GamerJoinedEventArgs>(Netplay.GamerJoinedEventHandler));
      Netplay.session.remove_GamerLeft(new EventHandler<GamerLeftEventArgs>(Netplay.GamerLeftEventHandler));
      Netplay.session.remove_GameEnded(new EventHandler<GameEndedEventArgs>(Netplay.GameEndedEventHandler));
      Netplay.session.remove_SessionEnded(new EventHandler<NetworkSessionEndedEventArgs>(Netplay.SessionEndedEventHandler));
      Netplay.session.Dispose();
      Netplay.session = (NetworkSession) null;
    }

    public static void Disconnect()
    {
      if (Netplay.session != null)
      {
        if (Main.netMode != 1)
        {
          if (Netplay.session.SessionState == NetworkSessionState.Playing)
          {
            Netplay.session.EndGame();
            Netplay.session.Update();
          }
          Netplay.clients.Clear();
          for (int index = 7; index >= 0; --index)
            Netplay.playerSlots[index] = false;
        }
        Netplay.DisposeSession();
        Netplay.gamer = (LocalNetworkGamer) null;
        Netplay.gamersWaitingForPlayerId.Clear();
        Netplay.gamersWaitingToSendSpawn.Clear();
        Netplay.gamersWaitingToSpawn.Clear();
        for (int index = 0; index < 4; ++index)
          Main.ui[index].LeaveSession();
      }
      Netplay.disconnect = false;
      Netplay.hookEvents = false;
      Netplay.stopSession = false;
      Main.netMode = 0;
    }

    public static void SetAsRemotePlayerSlot(int i)
    {
      Player player = Main.player[i];
      UI ui = player.ui;
      if (ui == null)
        return;
      if (player.view != null)
        ui.setPlayer(-1, true);
      else
        ui.setPlayer((Player) null);
    }

    private static void GamerJoinedEventHandler(object sender, GamerJoinedEventArgs e)
    {
      NetworkGamer gamer = e.Gamer;
      if (Main.netMode == 0)
      {
        for (int index = 0; index < 4; ++index)
        {
          UI ui = Main.ui[index];
          if (ui.wasRemovedFromSessionWithoutOurConsent)
          {
            SignedInGamer signedInGamer = ui.signedInGamer;
            if (signedInGamer != null && signedInGamer.Gamertag == gamer.Gamertag)
            {
              gamer.Tag = (object) ui.player;
              return;
            }
          }
        }
      }
      else if (!gamer.IsLocal)
        Main.checkUserGeneratedContent = true;
      int index1 = 0;
      if (Main.netMode != 1)
      {
        while (Netplay.playerSlots[index1])
          ++index1;
        Netplay.playerSlots[index1] = true;
      }
      if (gamer.IsLocal)
      {
        LocalNetworkGamer localNetworkGamer = (LocalNetworkGamer) gamer;
        SignedInGamer signedInGamer = localNetworkGamer.SignedInGamer;
        UI startUI = Main.ui[(int) signedInGamer.PlayerIndex];
        startUI.localGamer = localNetworkGamer;
        if (Main.netMode != 1)
        {
          startUI.JoinSession(index1);
          Player player = Main.player[index1];
          gamer.Tag = (object) player;
          player.client = (NetClient) null;
          if (gamer.IsHost)
            Netplay.sessionReadyEvent.Set();
          else
            Main.JoinGame(startUI);
        }
        else
          Netplay.gamersWaitingForPlayerId.Add(startUI);
        if (Netplay.gamer != null)
          return;
        Netplay.gamer = localNetworkGamer;
      }
      else if (Main.netMode == 2)
      {
        Netplay.SetAsRemotePlayerSlot(index1);
        NetClient netClient = (NetClient) null;
        for (int index2 = Netplay.clients.Count - 1; index2 >= 0; --index2)
        {
          if (Netplay.clients[index2].machine == gamer.Machine)
          {
            netClient = Netplay.clients[index2];
            break;
          }
        }
        if (netClient == null)
        {
          netClient = new NetClient(gamer);
          Netplay.clients.Add(netClient);
          NetMessage.syncPlayers();
        }
        Player player = Main.player[index1];
        netClient.GamerJoined(player);
        gamer.Tag = (object) player;
        NetMessage.SendPlayerId(gamer, index1);
      }
      else
      {
        if (Main.netMode != 1 || Netplay.gamer == null)
          return;
        NetMessage.CreateMessage0(11);
        NetMessage.SendMessage();
      }
    }

    private static void GamerLeftEventHandler(object sender, GamerLeftEventArgs e)
    {
      NetworkGamer gamer = e.Gamer;
      Player player = gamer.Tag as Player;
      if (gamer.IsLocal)
      {
        UI ui = Main.ui[(int) ((LocalNetworkGamer) gamer).SignedInGamer.PlayerIndex];
        if (Main.netMode == 0 && ui.wasRemovedFromSessionWithoutOurConsent)
          return;
        ui.LeaveSession();
      }
      if (Main.netMode == 1)
        return;
      int number = (int) player.whoAmI;
      player.active = (byte) 0;
      Netplay.playerSlots[number] = false;
      if (Main.netMode != 2)
        return;
      if (gamer.IsLocal)
      {
        if (UI.main.isInviteOnly)
          ++Netplay.session.PrivateGamerSlots;
      }
      else
      {
        NetClient netClient = player.client;
        if (netClient.GamerLeft(player))
          Netplay.clients.Remove(netClient);
        else if (gamer == netClient.gamer)
          netClient.gamer = ((ReadOnlyCollection<NetworkGamer>) netClient.machine.Gamers)[0];
      }
      NetMessage.CreateMessage2(14, number, 0);
      NetMessage.SendMessage();
      if (!player.announced)
        return;
      player.announced = false;
      NetMessage.SendText(player.oldName, 33, (int) byte.MaxValue, 240, 20, -1);
    }

    private static void GameEndedEventHandler(object sender, GameEndedEventArgs e)
    {
      if (Main.netMode != 1)
        return;
      UI.Error(Lang.inter[66], Lang.inter[67], false);
      Main.saveOnExit = UI.main.autoSave;
      UI.main.ExitGame();
    }

    private static void SessionEndedEventHandler(object sender, NetworkSessionEndedEventArgs e)
    {
      if (UI.main.menuMode == MenuMode.ERROR)
        return;
      string desc;
      switch (e.EndReason)
      {
        case NetworkSessionEndReason.ClientSignedOut:
          Netplay.GameEndedEventHandler(sender, new GameEndedEventArgs());
          return;
        case NetworkSessionEndReason.HostEndedSession:
        case NetworkSessionEndReason.RemovedByHost:
          desc = Lang.gen[46];
          break;
        default:
          desc = Main.netMode != 1 ? Lang.inter[36] : Lang.gen[46];
          break;
      }
      UI.Error(Lang.menu[5], desc, false);
      Main.saveOnExit = UI.main.autoSave;
      UI.main.ExitGame();
    }

    public static void StartServer()
    {
      Netplay.sessionReadyEvent.Reset();
      Thread thread = new Thread(new ThreadStart(Netplay.ServerLoop));
      thread.IsBackground = true;
      thread.Start();
      Netplay.sessionThread = thread;
    }

    public static void ServerLoop()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        5
      });
      Netplay.Init();
      Netplay.CreateSession();
      while (!Netplay.disconnect && Netplay.session != null)
        Thread.Sleep(16);
      Netplay.stopSession = true;
      Netplay.sessionThread = (Thread) null;
    }

    public static void StartClient()
    {
      Thread thread = new Thread(new ThreadStart(Netplay.ClientLoop));
      thread.IsBackground = true;
      thread.Start();
      Netplay.sessionThread = thread;
    }

    public static void ClientLoop()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        5
      });
      Netplay.Init();
      UI.main.player.hostile = false;
      UI.main.player.NetClone(UI.main.netPlayer);
      for (int index = 0; index < 8; ++index)
      {
        if (index != (int) UI.main.myPlayer)
          Main.player[index].active = (byte) 0;
      }
      WorldGen.clearWorld();
      if (UI.main.menuMode == MenuMode.NETPLAY)
      {
        Main.netMode = 1;
        try
        {
          if (Netplay.isJoiningRemoteInvite)
          {
            Netplay.isJoiningRemoteInvite = false;
            Netplay.session = NetworkSession.JoinInvited((IEnumerable<SignedInGamer>) Netplay.gamersWaitingToJoinInvite);
            Netplay.gamersWaitingToJoinInvite.Clear();
            Netplay.gamersWhoReceivedInvite.Clear();
          }
          else
            Netplay.session = NetworkSession.Join(WorldSelect.Session());
        }
        catch (Exception ex)
        {
          UI.Error(Lang.menu[5], Lang.inter[21], true);
          UI.main.menuType = MenuType.MAIN;
          Main.netMode = 0;
          Netplay.disconnect = true;
          Netplay.stopSession = true;
          goto label_28;
        }
        Netplay.hookEvents = true;
        while (!Netplay.disconnect && Netplay.session != null)
        {
          switch (Netplay.clientState)
          {
            case Netplay.ClientState.JOINING:
              UI.main.FirstProgressStep(3, Lang.menu[8]);
              Netplay.clientState = Netplay.ClientState.WAITING_FOR_PLAYER_ID;
              break;
            case Netplay.ClientState.WAITING_FOR_PLAYER_ID:
              if ((double) UI.main.progress <= 0.999000012874603)
              {
                UI.main.progress = UI.main.progress + 1.0 / 1000.0;
                break;
              }
              else
                break;
            case Netplay.ClientState.WAITING_FOR_PLAYER_DATA_REQ:
              if ((double) UI.main.progress <= 0.999000012874603)
              {
                UI.main.progress = UI.main.progress + 1.0 / 1000.0;
                break;
              }
              else
                break;
            case Netplay.ClientState.RECEIVED_PLAYER_DATA_REQ:
              UI.main.NextProgressStep(Lang.menu[73]);
              Netplay.clientState = Netplay.ClientState.WAITING_FOR_WORLD_INFO;
              break;
            case Netplay.ClientState.WAITING_FOR_WORLD_INFO:
              if ((double) UI.main.progress <= 0.999000012874603)
              {
                UI.main.progress = UI.main.progress + 1.0 / 1000.0;
                break;
              }
              else
                break;
            case Netplay.ClientState.WAITING_FOR_TILE_DATA:
              if (Netplay.clientStatusMax > 0)
              {
                if (Netplay.clientStatusCount >= Netplay.clientStatusMax)
                {
                  Netplay.clientStatusMax = 0;
                  Netplay.clientStatusCount = 0;
                  UI.main.progress = 1f;
                  break;
                }
                else
                {
                  UI.main.statusText = Lang.inter[44];
                  UI.main.progress = (float) Netplay.clientStatusCount / (float) Netplay.clientStatusMax;
                  break;
                }
              }
              else
                break;
          }
          Thread.Sleep(0);
        }
        Netplay.clientStatusCount = 0;
        Netplay.clientStatusMax = 0;
        Netplay.stopSession = true;
      }
label_28:
      Netplay.sessionThread = (Thread) null;
    }

    public static void InviteAccepted()
    {
      PlayerIndex playerIndex = Netplay.invite.Gamer.PlayerIndex;
      if (Main.isTrial)
        MessageBox.Show(playerIndex, Lang.menu[5], Lang.inter[69], new string[1]
        {
          Lang.menu[90]
        }, 1 != 0);
      else if (!UI.AllPlayersCanPlayOnline())
        MessageBox.Show(playerIndex, Lang.menu[5], Lang.inter[68], new string[1]
        {
          Lang.menu[90]
        }, 1 != 0);
      else
        Main.ui[(int) playerIndex].InviteAccepted(Netplay.invite);
      Netplay.invite = (InviteAcceptedEventArgs) null;
    }

    public static void NetworkSession_InviteAccepted(object sender, InviteAcceptedEventArgs e)
    {
      if (Netplay.invite != null)
        return;
      Netplay.invite = e;
    }

    public static bool IsFindingSessions()
    {
      return Netplay.sessionFinderThread != null;
    }

    public static void StopFindingSessions()
    {
      Netplay.availableSessions.Clear();
      if (Netplay.sessionFinderThread == null)
        return;
      Netplay.stopSessionFinderThread = true;
    }

    public static void FindSessions()
    {
      Netplay.StopFindingSessions();
      if (!UI.main.CanPlayOnline())
        return;
      if (Netplay.sessionFinderThread != null)
        Netplay.sessionFinderThread.Join();
      Netplay.sessionFinderThread = new Thread(new ThreadStart(Netplay.FindSessionsThread));
      Netplay.sessionFinderThread.IsBackground = true;
      Netplay.sessionFinderThread.Start();
    }

    public static void FindSessionsThread()
    {
      NetworkSessionProperties sessionProperties = new NetworkSessionProperties();
      UI ui = UI.main;
      if (ui.HasOnline())
      {
        SignedInGamer signedInGamer = ui.signedInGamer;
        if (signedInGamer != null)
        {
          try
          {
            List<SignedInGamer> list = new List<SignedInGamer>(1);
            list.Add(signedInGamer);
            FriendCollection friends = signedInGamer.GetFriends();
            for (int index = ((ReadOnlyCollection<FriendGamer>) friends).Count - 1; index >= 0; --index)
            {
              if (!Netplay.stopSessionFinderThread)
              {
                FriendGamer friendGamer = ((ReadOnlyCollection<FriendGamer>) friends)[index];
                if (friendGamer.IsJoinable)
                {
                  ulong xuid = GamerExtensions.GetXuid((Gamer) friendGamer);
                  sessionProperties.set_Item(0, new int?((int) xuid));
                  sessionProperties.set_Item(1, new int?((int) (xuid >> 32)));
                  AvailableNetworkSessionCollection sessionCollection = NetworkSession.Find(NetworkSessionType.PlayerMatch, (IEnumerable<SignedInGamer>) list, sessionProperties);
                  if (((ReadOnlyCollection<AvailableNetworkSession>) sessionCollection).Count > 0)
                  {
                    lock (Netplay.availableSessions)
                      Netplay.availableSessions.Add(new JoinableSession(((ReadOnlyCollection<AvailableNetworkSession>) sessionCollection)[0]));
                  }
                  if (!Netplay.stopSessionFinderThread)
                    Thread.Sleep(5000);
                  else
                    break;
                }
              }
              else
                break;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      Netplay.stopSessionFinderThread = false;
      Netplay.sessionFinderThread = (Thread) null;
    }

    public static void CheckOfflineSession()
    {
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.wasRemovedFromSessionWithoutOurConsent)
        {
          if (Netplay.session.SessionState == NetworkSessionState.Playing)
          {
            Netplay.session.AddLocalGamer(ui.signedInGamer);
            Netplay.session.Update();
            ui.wasRemovedFromSessionWithoutOurConsent = false;
          }
          else if (ui == UI.main)
          {
            Netplay.DisposeSession();
            Netplay.CreateSession();
            Netplay.HookSessionEvents();
            ui.wasRemovedFromSessionWithoutOurConsent = false;
          }
        }
      }
    }

    public enum ClientState
    {
      JOINING,
      WAITING_FOR_PLAYER_ID,
      WAITING_FOR_PLAYER_DATA_REQ,
      RECEIVED_PLAYER_DATA_REQ,
      WAITING_FOR_WORLD_INFO,
      ANNOUNCING_SPAWN_LOCATION,
      WAITING_FOR_TILE_DATA,
      PLAYING,
    }
  }
}
