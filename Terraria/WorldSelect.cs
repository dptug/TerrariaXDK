using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Terraria;

public static class WorldSelect
{
	private const int MAX_WORLDS = 8;

	private static byte selectedWorld;

	private static byte selectedSession;

	private static byte sessionListTop;

	public static string worldPathName;

	private static string[] worldNames = new string[8];

	private static int cursorX = 0;

	private static JoinableSession session;

	public static void Update()
	{
		if (UI.main.IsBackButtonTriggered())
		{
			UI.main.PrevMenu();
		}
		else if (UI.main.IsButtonTriggered(Buttons.Y))
		{
			UI.main.ShowParty();
		}
		else if (cursorX == 0)
		{
			if (UI.main.IsButtonTriggered(Buttons.A))
			{
				SelectWorld();
			}
			else if (UI.main.IsButtonTriggered(Buttons.X))
			{
				DeleteWorld();
			}
		}
		else if (UI.main.IsButtonTriggered(Buttons.A))
		{
			JoinSession();
		}
		else if (UI.main.IsButtonTriggered(Buttons.X) && UI.main.CanViewGamerCard())
		{
			UI.main.ShowGamerCard(Gamer.GetFromGamertag(Netplay.availableSessions[selectedSession].host));
		}
	}

	public static void UpdateCursor(int dx, int dy)
	{
		if (dx != 0 || dy != 0)
		{
			Main.PlaySound(12);
		}
		if (dx > 0)
		{
			cursorX = 1;
		}
		else if (dx < 0)
		{
			cursorX = 0;
		}
		int count = Netplay.availableSessions.Count;
		if (count == 0)
		{
			selectedSession = 0;
			sessionListTop = 0;
			cursorX = 0;
		}
		if (dy == 0)
		{
			return;
		}
		if (cursorX == 0)
		{
			dy += selectedWorld;
			if (dy < 0)
			{
				dy += 8;
			}
			else if (dy >= 8)
			{
				dy -= 8;
			}
			selectedWorld = (byte)dy;
			return;
		}
		dy += selectedSession;
		if (dy < 0)
		{
			dy += count;
		}
		else if (dy >= count)
		{
			dy -= count;
		}
		selectedSession = (byte)dy;
		if (dy < sessionListTop)
		{
			sessionListTop = (byte)dy;
		}
		else if (dy > sessionListTop + 7)
		{
			sessionListTop = (byte)(sessionListTop + (dy - (sessionListTop + 7)));
		}
	}

	public static void Draw(WorldView view)
	{
		Rectangle rect = default(Rectangle);
		Color white = Color.White;
		rect.X = view.SAFE_AREA_OFFSET_L;
		rect.Y = view.SAFE_AREA_OFFSET_T;
		rect.Width = 416;
		rect.Height = 446;
		Main.DrawRect(451, rect, 64);
		rect.X += 448;
		Main.DrawRect(451, rect, 64);
		UI.DrawStringCC(UI.fontBig, Lang.menu[83], view.SAFE_AREA_OFFSET_L + (rect.Width >> 1), rect.Y + 32, white);
		UI.DrawStringCC(UI.fontBig, Lang.menu[84], rect.Center.X, rect.Y + 32, white);
		int count = Netplay.availableSessions.Count;
		if (count == 0)
		{
			UI.DrawStringCC(s: (!Netplay.IsFindingSessions()) ? Lang.menu[77] : Lang.menu[76], font: UI.fontSmall, x: rect.Center.X, y: rect.Center.Y, c: UI.mouseTextColor);
		}
		else
		{
			rect.X += 8;
			rect.Y += 80;
			rect.Width = 400;
			rect.Height = 24;
			int num = Math.Min(count, sessionListTop + 8);
			lock (Netplay.availableSessions)
			{
				for (int i = sessionListTop; i < num; i++)
				{
					int texId = 450;
					int alpha = 255;
					if (i == selectedSession && cursorX == 1)
					{
						alpha = UI.mouseTextBrightness;
						texId = 448;
					}
					Main.DrawRect(texId, rect, alpha);
					rect.Y += 48;
				}
				rect.Y -= 48 * Math.Min(count, 8);
				white = Color.White;
				for (int j = sessionListTop; j < num; j++)
				{
					JoinableSession joinableSession = Netplay.availableSessions[j];
					string s2 = (j + 1).ToStringLookup() + ".";
					UI.DrawStringLC(UI.fontSmallOutline, s2, rect.X, rect.Center.Y, white);
					UI.DrawStringLC(UI.fontSmallOutline, joinableSession.host, rect.X + 32, rect.Center.Y, white);
					s2 = Lang.menu[78] + joinableSession.players.ToStringLookup() + "/8";
					UI.DrawStringRC(UI.fontSmallOutline, s2, rect.Right, rect.Center.Y, white);
					rect.Y += 48;
				}
			}
		}
		rect.X = view.SAFE_AREA_OFFSET_L + 8;
		rect.Y = view.SAFE_AREA_OFFSET_T + 80;
		rect.Width = 400;
		rect.Height = 24;
		for (int k = 0; k < 8; k++)
		{
			int texId2 = 450;
			int alpha2 = 255;
			if (k == selectedWorld && cursorX == 0)
			{
				alpha2 = UI.mouseTextBrightness;
				texId2 = 448;
			}
			else if (worldNames[k] == null)
			{
				alpha2 = 212;
				texId2 = 451;
			}
			Main.DrawRect(texId2, rect, alpha2);
			rect.Y += 48;
		}
		rect.Y -= 384;
		for (int l = 0; l < 8; l++)
		{
			string s3 = ((worldNames[l] == null) ? Lang.menu[79] : worldNames[l]);
			white = ((worldNames[l] == null) ? new Color(200, 200, 220, 255) : new Color(255, 255, 255, 255));
			UI.DrawStringCC(UI.fontSmallOutline, s3, rect.Center.X, rect.Center.Y, white);
			rect.Y += 48;
		}
	}

	public static void ControlDescription(StringBuilder strBuilder)
	{
		if (cursorX == 0)
		{
			if (worldNames[selectedWorld] == null)
			{
				strBuilder.Append(Lang.controls(Lang.CONTROLS.CREATE_WORLD));
			}
			else
			{
				strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
			}
		}
		else
		{
			strBuilder.Append(Lang.controls(Lang.CONTROLS.JOIN));
		}
		strBuilder.Append(' ');
		strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
		strBuilder.Append(' ');
		if (cursorX == 0)
		{
			if (worldNames[selectedWorld] != null)
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
		if (UI.main.CanPlayOnline())
		{
			strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_PARTY));
		}
	}

	public static string WorldName()
	{
		return worldNames[selectedWorld];
	}

	private static void SelectWorld()
	{
		Main.PlaySound(10);
		worldPathName = "world" + selectedWorld + ".wld";
		UI.main.SetMenu(MenuMode.GAME_MODE);
	}

	public static void CreateWorld(string name)
	{
		if (UI.main.HasPlayerStorage())
		{
			worldNames[selectedWorld] = name;
		}
		Main.worldName = name;
		WorldGen.CreateNewWorld();
	}

	public static bool LoadWorlds()
	{
		if (!UI.main.HasPlayerStorage())
		{
			worldPathName = null;
			for (int i = 0; i < 8; i++)
			{
				worldNames[i] = null;
			}
			return true;
		}
		bool result = true;
		try
		{
			using StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds");
			for (int j = 0; j < 8; j++)
			{
				string text = "world" + j.ToStringLookup() + ".wld";
				if (storageContainer.FileExists(text))
				{
					try
					{
						using Stream input = storageContainer.OpenFile(text, FileMode.Open);
						using BinaryReader binaryReader = new BinaryReader(input);
						int num = binaryReader.ReadInt32();
						_ = 46;
						if (num > 46)
						{
							binaryReader.ReadUInt32();
						}
						worldNames[j] = binaryReader.ReadString();
						binaryReader.Close();
					}
					catch
					{
						Main.ShowSaveIcon();
						storageContainer.DeleteFile(text);
						Main.HideSaveIcon();
						worldNames[j] = null;
						result = false;
					}
				}
				else
				{
					worldNames[j] = null;
				}
			}
		}
		catch (IOException)
		{
			UI.main.ReadError();
			for (int k = 0; k < 8; k++)
			{
				worldNames[k] = null;
			}
			result = true;
		}
		catch (Exception)
		{
			result = true;
		}
		return result;
	}

	private static void DeleteWorld()
	{
		if (worldNames[selectedWorld] != null)
		{
			Main.PlaySound(10);
			UI.main.SetMenu(MenuMode.CONFIRM_DELETE_WORLD);
		}
	}

	public static void EraseWorld()
	{
		if (!UI.main.HasPlayerStorage())
		{
			return;
		}
		Main.ShowSaveIcon();
		try
		{
			using StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds");
			worldPathName = "world" + selectedWorld + ".wld";
			storageContainer.DeleteFile(worldPathName);
		}
		catch (IOException)
		{
			UI.main.WriteError();
		}
		catch (Exception)
		{
		}
		Main.HideSaveIcon();
		worldNames[selectedWorld] = null;
	}

	public static AvailableNetworkSession Session()
	{
		List<SignedInGamer> list = new List<SignedInGamer>(1);
		list.Add(UI.main.signedInGamer);
		AvailableNetworkSessionCollection availableNetworkSessionCollection = NetworkSession.Find(NetworkSessionType.PlayerMatch, (IEnumerable<SignedInGamer>)list, session.joinableSession.SessionProperties);
		session = null;
		if (((ReadOnlyCollection<AvailableNetworkSession>)(object)availableNetworkSessionCollection).Count <= 0)
		{
			return null;
		}
		return ((ReadOnlyCollection<AvailableNetworkSession>)(object)availableNetworkSessionCollection)[0];
	}

	private static void JoinSession()
	{
		session = Netplay.availableSessions[selectedSession];
		Netplay.StopFindingSessions();
		UI.main.SetMenu(MenuMode.NETPLAY);
		UI.main.statusText = Lang.menu[80];
		Netplay.StartClient();
	}
}
