using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria
{
	public sealed class Netplay
	{
		public enum ClientState
		{
			JOINING,
			WAITING_FOR_PLAYER_ID,
			WAITING_FOR_PLAYER_DATA_REQ,
			RECEIVED_PLAYER_DATA_REQ,
			WAITING_FOR_WORLD_INFO,
			ANNOUNCING_SPAWN_LOCATION,
			WAITING_FOR_TILE_DATA,
			PLAYING
		}

		public static bool disconnect;

		public static bool stopSession;

		public static bool hookEvents;

		public static bool isJoiningRemoteInvite;

		public static LocalNetworkGamer gamer;

		public static List<SignedInGamer> gamersWhoReceivedInvite = new List<SignedInGamer>(4);

		public static List<SignedInGamer> gamersWaitingToJoinInvite = new List<SignedInGamer>(4);

		public static List<UI> gamersWaitingForPlayerId = new List<UI>(4);

		public static List<UI> gamersWaitingToSendSpawn = new List<UI>(4);

		public static List<UI> gamersWaitingToSpawn = new List<UI>(4);

		public static List<NetClient> clients = new List<NetClient>(7);

		public static bool[] playerSlots = new bool[8];

		public static List<JoinableSession> availableSessions = new List<JoinableSession>(32);

		private static Thread sessionFinderThread = null;

		private static volatile bool stopSessionFinderThread = false;

		public static NetworkSession session;

		public static InviteAcceptedEventArgs invite;

		public static Thread sessionThread;

		public static AutoResetEvent sessionReadyEvent = new AutoResetEvent(initialState: false);

		public static ClientState clientState;

		public static int clientStatusCount;

		public static int clientStatusMax;

		public static void Init()
		{
			disconnect = false;
			hookEvents = false;
			stopSession = false;
			clientState = ClientState.JOINING;
			clientStatusCount = 0;
			clientStatusMax = 0;
		}

		public static void ResetSections()
		{
			for (int num = clients.Count - 1; num >= 0; num--)
			{
				clients[num].ResetSections();
			}
		}

		public static void ResetSections(ref Vector2i min, ref Vector2i max)
		{
			for (int num = clients.Count - 1; num >= 0; num--)
			{
				clients[num].ResetSections(ref min, ref max);
			}
		}

		public static void CreateSession()
		{
			NetworkSessionType sessionType = (Main.netMode != 0) ? NetworkSessionType.PlayerMatch : NetworkSessionType.Local;
			try
			{
				List<SignedInGamer> list = new List<SignedInGamer>(1);
				list.Add(UI.main.signedInGamer);
				NetworkSessionProperties networkSessionProperties = new NetworkSessionProperties();
				ulong xuid = UI.main.signedInGamer.GetXuid();
				if (UI.main.isInviteOnly)
				{
					networkSessionProperties[2] = -559038737;
				}
				else
				{
					networkSessionProperties[0] = (int)xuid;
					networkSessionProperties[1] = (int)(xuid >> 32);
				}
				int maxGamers = 8;
				int privateGamerSlots = 0;
				if (!Main.IsTutorial() && UI.main.isInviteOnly)
				{
					privateGamerSlots = 7;
				}
				session = NetworkSession.Create(sessionType, list, maxGamers, privateGamerSlots, networkSessionProperties);
				session.AllowJoinInProgress = true;
				session.AllowHostMigration = false;
				hookEvents = true;
				session.StartGame();
			}
			catch (Exception)
			{
				UI.Error(Lang.menu[5], Lang.inter[20]);
				UI.main.menuType = MenuType.MAIN;
				Main.netMode = 0;
				disconnect = true;
			}
		}

		public static void HookSessionEvents()
		{
			session.GamerJoined += GamerJoinedEventHandler;
			session.GamerLeft += GamerLeftEventHandler;
			session.GameEnded += GameEndedEventHandler;
			session.SessionEnded += SessionEndedEventHandler;
			hookEvents = false;
		}

		public static void DisposeSession()
		{
			session.GamerJoined -= GamerJoinedEventHandler;
			session.GamerLeft -= GamerLeftEventHandler;
			session.GameEnded -= GameEndedEventHandler;
			session.SessionEnded -= SessionEndedEventHandler;
			session.Dispose();
			session = null;
		}

		public static void Disconnect()
		{
			if (session != null)
			{
				if (Main.netMode != 1)
				{
					if (session.SessionState == NetworkSessionState.Playing)
					{
						session.EndGame();
						session.Update();
					}
					clients.Clear();
					for (int num = 7; num >= 0; num--)
					{
						playerSlots[num] = false;
					}
				}
				DisposeSession();
				gamer = null;
				gamersWaitingForPlayerId.Clear();
				gamersWaitingToSendSpawn.Clear();
				gamersWaitingToSpawn.Clear();
				for (int i = 0; i < 4; i++)
				{
					Main.ui[i].LeaveSession();
				}
			}
			disconnect = false;
			hookEvents = false;
			stopSession = false;
			Main.netMode = 0;
		}

		public static void SetAsRemotePlayerSlot(int i)
		{
			Player player = Main.player[i];
			UI ui = player.ui;
			if (ui != null)
			{
				if (player.view != null)
				{
					ui.setPlayer(-1);
				}
				else
				{
					ui.setPlayer(null);
				}
			}
		}

		private static void GamerJoinedEventHandler(object sender, GamerJoinedEventArgs e)
		{
			NetworkGamer networkGamer = e.Gamer;
			if (Main.netMode == 0)
			{
				for (int i = 0; i < 4; i++)
				{
					UI uI = Main.ui[i];
					if (uI.wasRemovedFromSessionWithoutOurConsent)
					{
						SignedInGamer signedInGamer = uI.signedInGamer;
						if (signedInGamer != null && signedInGamer.Gamertag == networkGamer.Gamertag)
						{
							networkGamer.Tag = uI.player;
							return;
						}
					}
				}
			}
			else if (!networkGamer.IsLocal)
			{
				Main.checkUserGeneratedContent = true;
			}
			int j = 0;
			Player player = null;
			if (Main.netMode != 1)
			{
				for (; playerSlots[j]; j++)
				{
				}
				playerSlots[j] = true;
			}
			if (networkGamer.IsLocal)
			{
				LocalNetworkGamer localNetworkGamer = (LocalNetworkGamer)networkGamer;
				SignedInGamer signedInGamer2 = localNetworkGamer.SignedInGamer;
				UI uI2 = Main.ui[(int)signedInGamer2.PlayerIndex];
				uI2.localGamer = localNetworkGamer;
				if (Main.netMode != 1)
				{
					uI2.JoinSession(j);
					player = (Player)(networkGamer.Tag = Main.player[j]);
					player.client = null;
					if (networkGamer.IsHost)
					{
						sessionReadyEvent.Set();
					}
					else
					{
						Main.JoinGame(uI2);
					}
				}
				else
				{
					gamersWaitingForPlayerId.Add(uI2);
				}
				if (gamer == null)
				{
					gamer = localNetworkGamer;
				}
			}
			else if (Main.netMode == 2)
			{
				SetAsRemotePlayerSlot(j);
				NetClient netClient = null;
				for (int num = clients.Count - 1; num >= 0; num--)
				{
					if (clients[num].machine == networkGamer.Machine)
					{
						netClient = clients[num];
						break;
					}
				}
				if (netClient == null)
				{
					netClient = new NetClient(networkGamer);
					clients.Add(netClient);
					NetMessage.syncPlayers();
				}
				player = Main.player[j];
				netClient.GamerJoined(player);
				networkGamer.Tag = player;
				NetMessage.SendPlayerId(networkGamer, j);
			}
			else if (Main.netMode == 1 && gamer != null)
			{
				NetMessage.CreateMessage0(11);
				NetMessage.SendMessage();
			}
		}

		private static void GamerLeftEventHandler(object sender, GamerLeftEventArgs e)
		{
			NetworkGamer networkGamer = e.Gamer;
			Player player = networkGamer.Tag as Player;
			if (networkGamer.IsLocal)
			{
				UI uI = Main.ui[(int)((LocalNetworkGamer)networkGamer).SignedInGamer.PlayerIndex];
				if (Main.netMode == 0 && uI.wasRemovedFromSessionWithoutOurConsent)
				{
					return;
				}
				uI.LeaveSession();
			}
			if (Main.netMode == 1)
			{
				return;
			}
			int whoAmI = player.whoAmI;
			player.active = 0;
			playerSlots[whoAmI] = false;
			if (Main.netMode != 2)
			{
				return;
			}
			if (networkGamer.IsLocal)
			{
				if (UI.main.isInviteOnly)
				{
					session.PrivateGamerSlots++;
				}
			}
			else
			{
				NetClient client = player.client;
				if (client.GamerLeft(player))
				{
					clients.Remove(client);
				}
				else if (networkGamer == client.gamer)
				{
					client.gamer = client.machine.Gamers[0];
				}
			}
			NetMessage.CreateMessage2(14, whoAmI, 0);
			NetMessage.SendMessage();
			if (player.announced)
			{
				player.announced = false;
				NetMessage.SendText(player.oldName, 33, 255, 240, 20, -1);
			}
		}

		private static void GameEndedEventHandler(object sender, GameEndedEventArgs e)
		{
			if (Main.netMode == 1)
			{
				UI.Error(Lang.inter[66], Lang.inter[67]);
				Main.saveOnExit = UI.main.autoSave;
				UI.main.ExitGame();
			}
		}

		private static void SessionEndedEventHandler(object sender, NetworkSessionEndedEventArgs e)
		{
			if (UI.main.menuMode != MenuMode.ERROR)
			{
				string desc;
				switch (e.EndReason)
				{
				case NetworkSessionEndReason.ClientSignedOut:
					GameEndedEventHandler(sender, new GameEndedEventArgs());
					return;
				case NetworkSessionEndReason.HostEndedSession:
				case NetworkSessionEndReason.RemovedByHost:
					desc = Lang.gen[46];
					break;
				default:
					desc = ((Main.netMode != 1) ? Lang.inter[36] : Lang.gen[46]);
					break;
				}
				UI.Error(Lang.menu[5], desc);
				Main.saveOnExit = UI.main.autoSave;
				UI.main.ExitGame();
			}
		}

		public static void StartServer()
		{
			sessionReadyEvent.Reset();
			Thread thread = new Thread(ServerLoop);
			thread.IsBackground = true;
			thread.Start();
			sessionThread = thread;
		}

		public static void ServerLoop()
		{
			Thread.CurrentThread.SetProcessorAffinity(5);
			Init();
			CreateSession();
			while (!disconnect && session != null)
			{
				Thread.Sleep(16);
			}
			stopSession = true;
			sessionThread = null;
		}

		public static void StartClient()
		{
			Thread thread = new Thread(ClientLoop);
			thread.IsBackground = true;
			thread.Start();
			sessionThread = thread;
		}

		public static void ClientLoop()
		{
			Thread.CurrentThread.SetProcessorAffinity(5);
			Init();
			UI.main.player.hostile = false;
			UI.main.player.NetClone(UI.main.netPlayer);
			for (int i = 0; i < 8; i++)
			{
				if (i != UI.main.myPlayer)
				{
					Main.player[i].active = 0;
				}
			}
			WorldGen.clearWorld();
			if (UI.main.menuMode == MenuMode.NETPLAY)
			{
				Main.netMode = 1;
				try
				{
					if (isJoiningRemoteInvite)
					{
						isJoiningRemoteInvite = false;
						session = NetworkSession.JoinInvited(gamersWaitingToJoinInvite);
						gamersWaitingToJoinInvite.Clear();
						gamersWhoReceivedInvite.Clear();
					}
					else
					{
						session = NetworkSession.Join(WorldSelect.Session());
					}
				}
				catch (Exception)
				{
					UI.Error(Lang.menu[5], Lang.inter[21], rememberPreviousMenu: true);
					UI.main.menuType = MenuType.MAIN;
					Main.netMode = 0;
					disconnect = true;
					stopSession = true;
					goto IL_028d;
				}
				hookEvents = true;
				while (!disconnect && session != null)
				{
					switch (clientState)
					{
					case ClientState.JOINING:
						UI.main.FirstProgressStep(3, Lang.menu[8]);
						clientState = ClientState.WAITING_FOR_PLAYER_ID;
						break;
					case ClientState.WAITING_FOR_PLAYER_ID:
						if (UI.main.progress <= 0.999f)
						{
							UI.main.progress = UI.main.progress + 0.001f;
						}
						break;
					case ClientState.WAITING_FOR_PLAYER_DATA_REQ:
						if (UI.main.progress <= 0.999f)
						{
							UI.main.progress = UI.main.progress + 0.001f;
						}
						break;
					case ClientState.RECEIVED_PLAYER_DATA_REQ:
						UI.main.NextProgressStep(Lang.menu[73]);
						clientState = ClientState.WAITING_FOR_WORLD_INFO;
						break;
					case ClientState.WAITING_FOR_WORLD_INFO:
						if (UI.main.progress <= 0.999f)
						{
							UI.main.progress = UI.main.progress + 0.001f;
						}
						break;
					case ClientState.WAITING_FOR_TILE_DATA:
						if (clientStatusMax > 0)
						{
							if (clientStatusCount >= clientStatusMax)
							{
								clientStatusMax = 0;
								clientStatusCount = 0;
								UI.main.progress = 1f;
							}
							else
							{
								UI.main.statusText = Lang.inter[44];
								UI.main.progress = (float)clientStatusCount / (float)clientStatusMax;
							}
						}
						break;
					}
					Thread.Sleep(0);
				}
				clientStatusCount = 0;
				clientStatusMax = 0;
				stopSession = true;
			}
			goto IL_028d;
			IL_028d:
			sessionThread = null;
		}

		public static void InviteAccepted()
		{
			PlayerIndex playerIndex = invite.Gamer.PlayerIndex;
			if (Main.isTrial)
			{
				MessageBox.Show(playerIndex, Lang.menu[5], Lang.inter[69], new string[1]
				{
					Lang.menu[90]
				});
			}
			else if (!UI.AllPlayersCanPlayOnline())
			{
				MessageBox.Show(playerIndex, Lang.menu[5], Lang.inter[68], new string[1]
				{
					Lang.menu[90]
				});
			}
			else
			{
				UI uI = Main.ui[(int)playerIndex];
				uI.InviteAccepted(invite);
			}
			invite = null;
		}

		public static void NetworkSession_InviteAccepted(object sender, InviteAcceptedEventArgs e)
		{
			if (invite == null)
			{
				invite = e;
			}
		}

		public static bool IsFindingSessions()
		{
			return sessionFinderThread != null;
		}

		public static void StopFindingSessions()
		{
			availableSessions.Clear();
			if (sessionFinderThread != null)
			{
				stopSessionFinderThread = true;
			}
		}

		public static void FindSessions()
		{
			StopFindingSessions();
			if (UI.main.CanPlayOnline())
			{
				if (sessionFinderThread != null)
				{
					sessionFinderThread.Join();
				}
				sessionFinderThread = new Thread(FindSessionsThread);
				sessionFinderThread.IsBackground = true;
				sessionFinderThread.Start();
			}
		}

		public static void FindSessionsThread()
		{
			NetworkSessionProperties networkSessionProperties = new NetworkSessionProperties();
			UI main = UI.main;
			if (main.HasOnline())
			{
				SignedInGamer signedInGamer = main.signedInGamer;
				if (signedInGamer != null)
				{
					try
					{
						List<SignedInGamer> list = new List<SignedInGamer>(1);
						list.Add(signedInGamer);
						FriendCollection friends = signedInGamer.GetFriends();
						int num = friends.Count - 1;
						while (num >= 0 && !stopSessionFinderThread)
						{
							FriendGamer friendGamer = friends[num];
							if (friendGamer.IsJoinable)
							{
								ulong xuid = friendGamer.GetXuid();
								networkSessionProperties[0] = (int)xuid;
								networkSessionProperties[1] = (int)(xuid >> 32);
								AvailableNetworkSessionCollection availableNetworkSessionCollection = NetworkSession.Find(NetworkSessionType.PlayerMatch, list, networkSessionProperties);
								if (availableNetworkSessionCollection.Count > 0)
								{
									lock (availableSessions)
									{
										availableSessions.Add(new JoinableSession(availableNetworkSessionCollection[0]));
									}
								}
								if (stopSessionFinderThread)
								{
									break;
								}
								Thread.Sleep(5000);
							}
							num--;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			stopSessionFinderThread = false;
			sessionFinderThread = null;
		}

		public static void CheckOfflineSession()
		{
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.wasRemovedFromSessionWithoutOurConsent)
				{
					if (session.SessionState == NetworkSessionState.Playing)
					{
						session.AddLocalGamer(uI.signedInGamer);
						session.Update();
						uI.wasRemovedFromSessionWithoutOurConsent = false;
					}
					else if (uI == UI.main)
					{
						DisposeSession();
						CreateSession();
						HookSessionEvents();
						uI.wasRemovedFromSessionWithoutOurConsent = false;
					}
				}
			}
		}
	}
}
