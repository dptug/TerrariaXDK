using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria.HowToPlay;

namespace Terraria.Leaderboards;

internal class LeaderboardsUI
{
	private enum LeaderboardMode
	{
		Overall,
		MyScore,
		Friends
	}

	public const uint MAX_NUMBER = 99999999u;

	public const string MAX_NUMBER_STRING = "99999999";

	private const int ROW_HEIGHT = 50;

	private const int ROW_WIDTH = 900;

	private const int ROW_SPACING = 5;

	private const int BACKGROUND_X = 20;

	private const int RANK_X = 80;

	private const int GAMERTAG_X = 250;

	private const int STATISTICS_X = 375;

	private const int STATISTICS_WIDTH = 550;

	private const int MAX_ROWS_PER_SCREEN = 7;

	private const Leaderboard DEFAULT_LEADERBOARD = Leaderboard.DISTANCE;

	private static Color ROW_COLOR_SELECTED = Color.White;

	private static Color ROW_COLOR = UI.DEFAULT_DIALOG_COLOR;

	private LeaderboardData Data;

	private BoxGraphic Box;

	private UI parentUI;

	private int uiDelay;

	private LeaderboardMode mode;

	private Leaderboard SelectedLeaderboard;

	private int[] StatisticsPositions;

	private int[] IconPositions;

	private Texture2D[] IconIndices;

	public LeaderboardsUI(UI parentUI)
	{
		Data = new LeaderboardData(7);
		Box = BoxGraphic.Create(900, 50, Terraria.HowToPlay.Assets.TEXT_BACKGROUND, 8, ROW_COLOR);
		uiDelay = 0;
		this.parentUI = parentUI;
		SelectedLeaderboard = Leaderboard.DISTANCE;
	}

	public void InitializeData()
	{
		mode = LeaderboardMode.Overall;
		SelectedLeaderboard = Leaderboard.DISTANCE;
		LoadLeaderboard();
	}

	private void CalculateStatisticPositions()
	{
		SpriteFont fontSmallOutline = UI.fontSmallOutline;
		float x = UI.MeasureString(fontSmallOutline, "99999999").X;
		Column[] columns = Data.Columns;
		int num = columns.Length;
		float num2 = ((float)(550 / num) - x) * 0.5f;
		StatisticsPositions = new int[num];
		IconIndices = new Texture2D[num];
		IconPositions = new int[num];
		float num3 = 375f;
		for (int i = 0; i < num; i++)
		{
			StatisticsPositions[i] = (int)(num3 + num2 + x * 0.5f);
			num3 += x + num2 * 2f;
			Column column = columns[i];
			IconIndices[i] = Assets.COLUMN_ICONS[(int)column];
			IconPositions[i] = StatisticsPositions[i] - (IconIndices[i].Width >> 1);
		}
	}

	public void Update()
	{
		if (!parentUI.HasOnline() || !Data.Update())
		{
			MessageBox.Show(parentUI.controller, Lang.menu[5], Lang.inter[36], new string[1] { Lang.menu[90] });
			parentUI.PrevMenu();
		}
		else if (uiDelay > 0)
		{
			uiDelay--;
		}
		else if (Data.Ready)
		{
			bool flag = false;
			if (parentUI.IsDownButtonDown())
			{
				flag = Data.MoveDown();
			}
			else if (parentUI.IsUpButtonDown())
			{
				flag = Data.MoveUp();
			}
			else if (parentUI.IsButtonTriggered(Buttons.X) && !parentUI.signedInGamer.IsGuest)
			{
				SwitchLeaderboardFilter();
			}
			else if (parentUI.IsButtonTriggered(Buttons.LeftShoulder))
			{
				PreviousLeaderboard();
			}
			else if (parentUI.IsButtonTriggered(Buttons.RightShoulder))
			{
				NextLeaderboard();
			}
			else if (parentUI.IsButtonTriggered(Buttons.A) && parentUI.CanViewGamerCard() && Data.NumEntries > 0)
			{
				parentUI.ShowGamerCard(Data.GetSelectedGamer());
			}
			if (flag)
			{
				uiDelay = 12;
				Main.PlaySound(12);
			}
		}
	}

	private void NextLeaderboard()
	{
		int selectedLeaderboard = (int)SelectedLeaderboard;
		selectedLeaderboard++;
		if (selectedLeaderboard == 5)
		{
			selectedLeaderboard = 0;
		}
		SelectedLeaderboard = (Leaderboard)selectedLeaderboard;
		LoadLeaderboard();
	}

	private void PreviousLeaderboard()
	{
		int selectedLeaderboard = (int)SelectedLeaderboard;
		selectedLeaderboard--;
		if (selectedLeaderboard < 0)
		{
			selectedLeaderboard = 4;
		}
		SelectedLeaderboard = (Leaderboard)selectedLeaderboard;
		LoadLeaderboard();
	}

	private void LoadLeaderboard()
	{
		switch (mode)
		{
		case LeaderboardMode.MyScore:
			Data.LoadLeaderboard(SelectedLeaderboard, parentUI.signedInGamer);
			break;
		case LeaderboardMode.Friends:
		{
			SignedInGamer signedInGamer = parentUI.signedInGamer;
			FriendCollection friends = signedInGamer.GetFriends();
			Data.LoadLeaderboard(SelectedLeaderboard, friends, signedInGamer);
			break;
		}
		default:
			Data.LoadLeaderboard(SelectedLeaderboard);
			break;
		}
		CalculateStatisticPositions();
	}

	private void SwitchLeaderboardFilter()
	{
		if (mode == LeaderboardMode.Overall)
		{
			mode = LeaderboardMode.MyScore;
		}
		else if (mode == LeaderboardMode.MyScore)
		{
			mode = LeaderboardMode.Friends;
		}
		else if (mode == LeaderboardMode.Friends)
		{
			mode = LeaderboardMode.Overall;
		}
		LoadLeaderboard();
	}

	public void Draw(WorldView view)
	{
		SpriteFont fontSmallOutline = UI.fontSmallOutline;
		int sAFE_AREA_OFFSET_L = view.SAFE_AREA_OFFSET_L;
		int sAFE_AREA_OFFSET_T = view.SAFE_AREA_OFFSET_T;
		Main.strBuilder.Length = 0;
		Main.strBuilder.Append(Lang.inter[37]);
		Main.strBuilder.Append(Data.NumEntries);
		Main.strBuilder.Append('\n');
		Main.strBuilder.Append(Data.LeaderboardName);
		UI.DrawStringLT(fontSmallOutline, sAFE_AREA_OFFSET_L, sAFE_AREA_OFFSET_T, Color.White);
		Vector2 vector = new Vector2(sAFE_AREA_OFFSET_L, sAFE_AREA_OFFSET_T + 10);
		for (int i = 0; i < IconIndices.Length; i++)
		{
			vector.X = IconPositions[i];
			Main.spriteBatch.Draw(IconIndices[i], vector, Color.White);
		}
		vector.Y = view.SAFE_AREA_OFFSET_T + 95;
		LeaderboardData.Row[] rows = Data.GetRows();
		for (int j = 0; j < rows.Length; j++)
		{
			int num = j + Data.BatchStart;
			Color color = ((num == Data.Selected) ? ROW_COLOR_SELECTED : ROW_COLOR);
			Box.Color = color;
			Box.Draw(new Vector2i(20, (int)vector.Y - 25), 1f);
			LeaderboardData.Row row = rows[j];
			if (row != null && row.Available)
			{
				vector.X = 80f;
				string text = row.Rank.ToStringLookup();
				Vector2 pivot = UI.MeasureString(fontSmallOutline, text);
				pivot.X = (int)pivot.X >> 1;
				pivot.Y = (int)pivot.Y >> 1;
				UI.DrawStringScaled(fontSmallOutline, text, vector, Color.White, pivot, 1f);
				vector.X = 250f;
				string gamertag = row.Gamertag;
				pivot = UI.MeasureString(fontSmallOutline, gamertag);
				pivot.X = (int)pivot.X >> 1;
				pivot.Y = (int)pivot.Y >> 1;
				UI.DrawStringScaled(fontSmallOutline, gamertag, vector, Color.White, pivot, 1f);
				for (int num2 = Math.Min(StatisticsPositions.Length, row.Statistics.Length) - 1; num2 >= 0; num2--)
				{
					vector.X = StatisticsPositions[num2];
					uint num3 = row.Statistics[num2];
					string text2 = ((num3 < 99999999) ? ((int)num3).ToStringLookup() : "99999999");
					pivot = UI.MeasureString(fontSmallOutline, text2);
					pivot.X = (int)pivot.X >> 1;
					pivot.Y = (int)pivot.Y >> 1;
					UI.DrawStringScaled(fontSmallOutline, text2, vector, Color.White, pivot, 1f);
				}
			}
			vector.Y += 55f;
		}
	}

	public void ControlDescription(StringBuilder strBuilder)
	{
		strBuilder.Append(Lang.controls(Lang.CONTROLS.SWITCH_LEADERBOARD));
		strBuilder.Append(' ');
		if (parentUI.CanViewGamerCard() && Data.NumEntries > 0)
		{
			strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_GAMERCARD));
			strBuilder.Append(' ');
		}
		strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
		if (!parentUI.signedInGamer.IsGuest)
		{
			strBuilder.Append(' ');
			if (mode == LeaderboardMode.Friends)
			{
				strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_TOP));
			}
			else if (mode == LeaderboardMode.Overall)
			{
				strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_MYSELF));
			}
			else if (mode == LeaderboardMode.MyScore)
			{
				strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_FRIENDS));
			}
		}
	}
}
