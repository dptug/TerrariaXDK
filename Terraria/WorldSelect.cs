// Type: Terraria.WorldSelect
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Terraria
{
  public static class WorldSelect
  {
    private static string[] worldNames = new string[8];
    private static int cursorX = 0;
    private const int MAX_WORLDS = 8;
    private static byte selectedWorld;
    private static byte selectedSession;
    private static byte sessionListTop;
    public static string worldPathName;
    private static JoinableSession session;

    static WorldSelect()
    {
    }

    public static void Update()
    {
      if (UI.main.IsBackButtonTriggered())
        UI.main.PrevMenu(-1);
      else if (UI.main.IsButtonTriggered(Buttons.Y))
        UI.main.ShowParty();
      else if (WorldSelect.cursorX == 0)
      {
        if (UI.main.IsButtonTriggered(Buttons.A))
        {
          WorldSelect.SelectWorld();
        }
        else
        {
          if (!UI.main.IsButtonTriggered(Buttons.X))
            return;
          WorldSelect.DeleteWorld();
        }
      }
      else if (UI.main.IsButtonTriggered(Buttons.A))
      {
        WorldSelect.JoinSession();
      }
      else
      {
        if (!UI.main.IsButtonTriggered(Buttons.X) || !UI.main.CanViewGamerCard())
          return;
        UI.main.ShowGamerCard(Gamer.GetFromGamertag(Netplay.availableSessions[(int) WorldSelect.selectedSession].host));
      }
    }

    public static void UpdateCursor(int dx, int dy)
    {
      if (dx != 0 || dy != 0)
        Main.PlaySound(12);
      if (dx > 0)
        WorldSelect.cursorX = 1;
      else if (dx < 0)
        WorldSelect.cursorX = 0;
      int count = Netplay.availableSessions.Count;
      if (count == 0)
      {
        WorldSelect.selectedSession = (byte) 0;
        WorldSelect.sessionListTop = (byte) 0;
        WorldSelect.cursorX = 0;
      }
      if (dy == 0)
        return;
      if (WorldSelect.cursorX == 0)
      {
        dy += (int) WorldSelect.selectedWorld;
        if (dy < 0)
          dy += 8;
        else if (dy >= 8)
          dy -= 8;
        WorldSelect.selectedWorld = (byte) dy;
      }
      else
      {
        dy += (int) WorldSelect.selectedSession;
        if (dy < 0)
          dy += count;
        else if (dy >= count)
          dy -= count;
        WorldSelect.selectedSession = (byte) dy;
        if (dy < (int) WorldSelect.sessionListTop)
        {
          WorldSelect.sessionListTop = (byte) dy;
        }
        else
        {
          if (dy <= (int) WorldSelect.sessionListTop + 7)
            return;
          WorldSelect.sessionListTop += (byte) (dy - ((int) WorldSelect.sessionListTop + 7));
        }
      }
    }

    public static void Draw(WorldView view)
    {
      Rectangle rect = new Rectangle();
      Color white = Color.White;
      rect.X = view.SAFE_AREA_OFFSET_L;
      rect.Y = view.SAFE_AREA_OFFSET_T;
      rect.Width = 416;
      rect.Height = 446;
      Main.DrawRect(451, rect, 64, 0);
      rect.X += 448;
      Main.DrawRect(451, rect, 64, 0);
      UI.DrawStringCC(UI.fontBig, Lang.menu[83], view.SAFE_AREA_OFFSET_L + (rect.Width >> 1), rect.Y + 32, white);
      UI.DrawStringCC(UI.fontBig, Lang.menu[84], rect.Center.X, rect.Y + 32, white);
      int count = Netplay.availableSessions.Count;
      if (count == 0)
      {
        string s = !Netplay.IsFindingSessions() ? Lang.menu[77] : Lang.menu[76];
        UI.DrawStringCC(UI.fontSmall, s, rect.Center.X, rect.Center.Y, UI.mouseTextColor);
      }
      else
      {
        rect.X += 8;
        rect.Y += 80;
        rect.Width = 400;
        rect.Height = 24;
        int num = Math.Min(count, (int) WorldSelect.sessionListTop + 8);
        lock (Netplay.availableSessions)
        {
          for (int local_5 = (int) WorldSelect.sessionListTop; local_5 < num; ++local_5)
          {
            int local_6 = 450;
            int local_7 = (int) byte.MaxValue;
            if (local_5 == (int) WorldSelect.selectedSession && WorldSelect.cursorX == 1)
            {
              local_7 = (int) UI.mouseTextBrightness;
              local_6 = 448;
            }
            Main.DrawRect(local_6, rect, local_7, 0);
            rect.Y += 48;
          }
          rect.Y -= 48 * Math.Min(count, 8);
          Color local_1_1 = Color.White;
          for (int local_8 = (int) WorldSelect.sessionListTop; local_8 < num; ++local_8)
          {
            JoinableSession local_9 = Netplay.availableSessions[local_8];
            string local_10 = ToStringExtensions.ToStringLookup(local_8 + 1) + ".";
            UI.DrawStringLC(UI.fontSmallOutline, local_10, rect.X, rect.Center.Y, local_1_1);
            UI.DrawStringLC(UI.fontSmallOutline, local_9.host, rect.X + 32, rect.Center.Y, local_1_1);
            string local_10_1 = Lang.menu[78] + ToStringExtensions.ToStringLookup(local_9.players) + "/8";
            UI.DrawStringRC(UI.fontSmallOutline, local_10_1, rect.Right, rect.Center.Y, local_1_1);
            rect.Y += 48;
          }
        }
      }
      rect.X = view.SAFE_AREA_OFFSET_L + 8;
      rect.Y = view.SAFE_AREA_OFFSET_T + 80;
      rect.Width = 400;
      rect.Height = 24;
      for (int index = 0; index < 8; ++index)
      {
        int texId = 450;
        int alpha = (int) byte.MaxValue;
        if (index == (int) WorldSelect.selectedWorld && WorldSelect.cursorX == 0)
        {
          alpha = (int) UI.mouseTextBrightness;
          texId = 448;
        }
        else if (WorldSelect.worldNames[index] == null)
        {
          alpha = 212;
          texId = 451;
        }
        Main.DrawRect(texId, rect, alpha, 0);
        rect.Y += 48;
      }
      rect.Y -= 384;
      for (int index = 0; index < 8; ++index)
      {
        string s = WorldSelect.worldNames[index] == null ? Lang.menu[79] : WorldSelect.worldNames[index];
        Color c = WorldSelect.worldNames[index] == null ? new Color(200, 200, 220, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        UI.DrawStringCC(UI.fontSmallOutline, s, rect.Center.X, rect.Center.Y, c);
        rect.Y += 48;
      }
    }

    public static void ControlDescription(StringBuilder strBuilder)
    {
      if (WorldSelect.cursorX == 0)
      {
        if (WorldSelect.worldNames[(int) WorldSelect.selectedWorld] == null)
          strBuilder.Append(Lang.controls(Lang.CONTROLS.CREATE_WORLD));
        else
          strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
      }
      else
        strBuilder.Append(Lang.controls(Lang.CONTROLS.JOIN));
      strBuilder.Append(' ');
      strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
      strBuilder.Append(' ');
      if (WorldSelect.cursorX == 0)
      {
        if (WorldSelect.worldNames[(int) WorldSelect.selectedWorld] != null)
        {
          strBuilder.Append(Lang.menu[17]);
          strBuilder.Append(' ');
        }
      }
      else if (UI.main.CanViewGamerCard())
      {
        strBuilder.Append(Lang.controls(Lang.CONTROLS.X_SHOW_GAMERCARD));
        strBuilder.Append(' ');
      }
      if (!UI.main.CanPlayOnline())
        return;
      strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_PARTY));
    }

    public static string WorldName()
    {
      return WorldSelect.worldNames[(int) WorldSelect.selectedWorld];
    }

    private static void SelectWorld()
    {
      Main.PlaySound(10);
      WorldSelect.worldPathName = "world" + (object) WorldSelect.selectedWorld + ".wld";
      UI.main.SetMenu(MenuMode.GAME_MODE, true, false);
    }

    public static void CreateWorld(string name)
    {
      if (UI.main.HasPlayerStorage())
        WorldSelect.worldNames[(int) WorldSelect.selectedWorld] = name;
      Main.worldName = name;
      WorldGen.CreateNewWorld();
    }

    public static bool LoadWorlds()
    {
      if (!UI.main.HasPlayerStorage())
      {
        WorldSelect.worldPathName = (string) null;
        for (int index = 0; index < 8; ++index)
          WorldSelect.worldNames[index] = (string) null;
        return true;
      }
      else
      {
        bool flag = true;
        try
        {
          using (StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds"))
          {
            for (int index = 0; index < 8; ++index)
            {
              string file = "world" + ToStringExtensions.ToStringLookup(index) + ".wld";
              if (storageContainer.FileExists(file))
              {
                try
                {
                  using (Stream input = storageContainer.OpenFile(file, FileMode.Open))
                  {
                    using (BinaryReader binaryReader = new BinaryReader(input))
                    {
                      if (binaryReader.ReadInt32() > 46)
                      {
                        int num = (int) binaryReader.ReadUInt32();
                      }
                      WorldSelect.worldNames[index] = binaryReader.ReadString();
                      binaryReader.Close();
                    }
                  }
                }
                catch
                {
                  Main.ShowSaveIcon();
                  storageContainer.DeleteFile(file);
                  Main.HideSaveIcon();
                  WorldSelect.worldNames[index] = (string) null;
                  flag = false;
                }
              }
              else
                WorldSelect.worldNames[index] = (string) null;
            }
          }
        }
        catch (IOException ex)
        {
          UI.main.ReadError();
          for (int index = 0; index < 8; ++index)
            WorldSelect.worldNames[index] = (string) null;
          flag = true;
        }
        catch (Exception ex)
        {
          flag = true;
        }
        return flag;
      }
    }

    private static void DeleteWorld()
    {
      if (WorldSelect.worldNames[(int) WorldSelect.selectedWorld] == null)
        return;
      Main.PlaySound(10);
      UI.main.SetMenu(MenuMode.CONFIRM_DELETE_WORLD, true, false);
    }

    public static void EraseWorld()
    {
      if (!UI.main.HasPlayerStorage())
        return;
      Main.ShowSaveIcon();
      try
      {
        using (StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds"))
        {
          WorldSelect.worldPathName = "world" + (object) WorldSelect.selectedWorld + ".wld";
          storageContainer.DeleteFile(WorldSelect.worldPathName);
        }
      }
      catch (IOException ex)
      {
        UI.main.WriteError();
      }
      catch (Exception ex)
      {
      }
      Main.HideSaveIcon();
      WorldSelect.worldNames[(int) WorldSelect.selectedWorld] = (string) null;
    }

    public static AvailableNetworkSession Session()
    {
      AvailableNetworkSessionCollection sessionCollection = NetworkSession.Find(NetworkSessionType.PlayerMatch, (IEnumerable<SignedInGamer>) new List<SignedInGamer>(1)
      {
        UI.main.signedInGamer
      }, WorldSelect.session.joinableSession.SessionProperties);
      WorldSelect.session = (JoinableSession) null;
      if (((ReadOnlyCollection<AvailableNetworkSession>) sessionCollection).Count <= 0)
        return (AvailableNetworkSession) null;
      else
        return ((ReadOnlyCollection<AvailableNetworkSession>) sessionCollection)[0];
    }

    private static void JoinSession()
    {
      WorldSelect.session = Netplay.availableSessions[(int) WorldSelect.selectedSession];
      Netplay.StopFindingSessions();
      UI.main.SetMenu(MenuMode.NETPLAY, true, false);
      UI.main.statusText = Lang.menu[80];
      Netplay.StartClient();
    }
  }
}
