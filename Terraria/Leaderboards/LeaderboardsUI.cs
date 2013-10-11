// Type: Terraria.Leaderboards.LeaderboardsUI
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using Terraria;

namespace Terraria.Leaderboards
{
  internal class LeaderboardsUI
  {
    private static Color ROW_COLOR_SELECTED = Color.White;
    private static Color ROW_COLOR = Terraria.UI.DEFAULT_DIALOG_COLOR;
    public const uint MAX_NUMBER = 99999999U;
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
    private LeaderboardData Data;
    private BoxGraphic Box;
    private Terraria.UI parentUI;
    private int uiDelay;
    private LeaderboardsUI.LeaderboardMode mode;
    private Leaderboard SelectedLeaderboard;
    private int[] StatisticsPositions;
    private int[] IconPositions;
    private Texture2D[] IconIndices;

    static LeaderboardsUI()
    {
    }

    public LeaderboardsUI(Terraria.UI parentUI)
    {
      this.Data = new LeaderboardData(7);
      this.Box = BoxGraphic.Create(900, 50, Terraria.HowToPlay.Assets.TEXT_BACKGROUND, 8, LeaderboardsUI.ROW_COLOR);
      this.uiDelay = 0;
      this.parentUI = parentUI;
      this.SelectedLeaderboard = Leaderboard.DISTANCE;
    }

    public void InitializeData()
    {
      this.mode = LeaderboardsUI.LeaderboardMode.Overall;
      this.SelectedLeaderboard = Leaderboard.DISTANCE;
      this.LoadLeaderboard();
    }

    private void CalculateStatisticPositions()
    {
      float num1 = Terraria.UI.MeasureString(Terraria.UI.fontSmallOutline, "99999999").X;
      Column[] columnArray = this.Data.Columns;
      int length = columnArray.Length;
      float num2 = (float) (((double) (550 / length) - (double) num1) * 0.5);
      this.StatisticsPositions = new int[length];
      this.IconIndices = new Texture2D[length];
      this.IconPositions = new int[length];
      float num3 = 375f;
      for (int index = 0; index < length; ++index)
      {
        this.StatisticsPositions[index] = (int) ((double) num3 + (double) num2 + (double) num1 * 0.5);
        num3 += num1 + num2 * 2f;
        Column column = columnArray[index];
        this.IconIndices[index] = Assets.COLUMN_ICONS[(int) column];
        this.IconPositions[index] = this.StatisticsPositions[index] - (this.IconIndices[index].Width >> 1);
      }
    }

    public void Update()
    {
      if (!this.parentUI.HasOnline() || !this.Data.Update())
      {
        MessageBox.Show(this.parentUI.controller, Lang.menu[5], Lang.inter[36], new string[1]
        {
          Lang.menu[90]
        }, 1 != 0);
        this.parentUI.PrevMenu(-1);
      }
      else if (this.uiDelay > 0)
      {
        --this.uiDelay;
      }
      else
      {
        if (!this.Data.Ready)
          return;
        bool flag = false;
        if (this.parentUI.IsDownButtonDown())
          flag = this.Data.MoveDown();
        else if (this.parentUI.IsUpButtonDown())
          flag = this.Data.MoveUp();
        else if (this.parentUI.IsButtonTriggered(Buttons.X) && !this.parentUI.signedInGamer.IsGuest)
          this.SwitchLeaderboardFilter();
        else if (this.parentUI.IsButtonTriggered(Buttons.LeftShoulder))
          this.PreviousLeaderboard();
        else if (this.parentUI.IsButtonTriggered(Buttons.RightShoulder))
          this.NextLeaderboard();
        else if (this.parentUI.IsButtonTriggered(Buttons.A) && this.parentUI.CanViewGamerCard() && this.Data.NumEntries > 0)
          this.parentUI.ShowGamerCard(this.Data.GetSelectedGamer());
        if (!flag)
          return;
        this.uiDelay = 12;
        Main.PlaySound(12);
      }
    }

    private void NextLeaderboard()
    {
      int num = (int) (this.SelectedLeaderboard + 1);
      if (num == 5)
        num = 0;
      this.SelectedLeaderboard = (Leaderboard) num;
      this.LoadLeaderboard();
    }

    private void PreviousLeaderboard()
    {
      int num = (int) (this.SelectedLeaderboard - 1);
      if (num < 0)
        num = 4;
      this.SelectedLeaderboard = (Leaderboard) num;
      this.LoadLeaderboard();
    }

    private void LoadLeaderboard()
    {
      switch (this.mode)
      {
        case LeaderboardsUI.LeaderboardMode.MyScore:
          this.Data.LoadLeaderboard(this.SelectedLeaderboard, (Gamer) this.parentUI.signedInGamer);
          break;
        case LeaderboardsUI.LeaderboardMode.Friends:
          SignedInGamer signedInGamer = this.parentUI.signedInGamer;
          this.Data.LoadLeaderboard(this.SelectedLeaderboard, signedInGamer.GetFriends(), (Gamer) signedInGamer);
          break;
        default:
          this.Data.LoadLeaderboard(this.SelectedLeaderboard);
          break;
      }
      this.CalculateStatisticPositions();
    }

    private void SwitchLeaderboardFilter()
    {
      if (this.mode == LeaderboardsUI.LeaderboardMode.Overall)
        this.mode = LeaderboardsUI.LeaderboardMode.MyScore;
      else if (this.mode == LeaderboardsUI.LeaderboardMode.MyScore)
        this.mode = LeaderboardsUI.LeaderboardMode.Friends;
      else if (this.mode == LeaderboardsUI.LeaderboardMode.Friends)
        this.mode = LeaderboardsUI.LeaderboardMode.Overall;
      this.LoadLeaderboard();
    }

    public void Draw(WorldView view)
    {
      SpriteFont font = Terraria.UI.fontSmallOutline;
      int x = view.SAFE_AREA_OFFSET_L;
      int y = view.SAFE_AREA_OFFSET_T;
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(Lang.inter[37]);
      Main.strBuilder.Append(this.Data.NumEntries);
      Main.strBuilder.Append('\n');
      Main.strBuilder.Append(this.Data.LeaderboardName);
      Terraria.UI.DrawStringLT(font, x, y, Color.White);
      Vector2 vector2 = new Vector2((float) x, (float) (y + 10));
      for (int index = 0; index < this.IconIndices.Length; ++index)
      {
        vector2.X = (float) this.IconPositions[index];
        Main.spriteBatch.Draw(this.IconIndices[index], vector2, Color.White);
      }
      vector2.Y = (float) (view.SAFE_AREA_OFFSET_T + 95);
      LeaderboardData.Row[] rows = this.Data.GetRows();
      for (int index1 = 0; index1 < rows.Length; ++index1)
      {
        this.Box.Color = index1 + this.Data.BatchStart == this.Data.Selected ? LeaderboardsUI.ROW_COLOR_SELECTED : LeaderboardsUI.ROW_COLOR;
        this.Box.Draw(new Vector2i(20, (int) vector2.Y - 25), 1f);
        LeaderboardData.Row row = rows[index1];
        if (row != null && row.Available)
        {
          vector2.X = 80f;
          string str1 = ToStringExtensions.ToStringLookup(row.Rank);
          Vector2 pivot = Terraria.UI.MeasureString(font, str1);
          pivot.X = (float) ((int) pivot.X >> 1);
          pivot.Y = (float) ((int) pivot.Y >> 1);
          Terraria.UI.DrawStringScaled(font, str1, vector2, Color.White, pivot, 1f);
          vector2.X = 250f;
          string gamertag = row.Gamertag;
          pivot = Terraria.UI.MeasureString(font, gamertag);
          pivot.X = (float) ((int) pivot.X >> 1);
          pivot.Y = (float) ((int) pivot.Y >> 1);
          Terraria.UI.DrawStringScaled(font, gamertag, vector2, Color.White, pivot, 1f);
          for (int index2 = Math.Min(this.StatisticsPositions.Length, row.Statistics.Length) - 1; index2 >= 0; --index2)
          {
            vector2.X = (float) this.StatisticsPositions[index2];
            uint num = row.Statistics[index2];
            string str2 = num < 99999999U ? ToStringExtensions.ToStringLookup((int) num) : "99999999";
            pivot = Terraria.UI.MeasureString(font, str2);
            pivot.X = (float) ((int) pivot.X >> 1);
            pivot.Y = (float) ((int) pivot.Y >> 1);
            Terraria.UI.DrawStringScaled(font, str2, vector2, Color.White, pivot, 1f);
          }
        }
        vector2.Y += 55f;
      }
    }

    public void ControlDescription(StringBuilder strBuilder)
    {
      strBuilder.Append(Lang.controls(Lang.CONTROLS.SWITCH_LEADERBOARD));
      strBuilder.Append(' ');
      if (this.parentUI.CanViewGamerCard() && this.Data.NumEntries > 0)
      {
        strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_GAMERCARD));
        strBuilder.Append(' ');
      }
      strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
      if (this.parentUI.signedInGamer.IsGuest)
        return;
      strBuilder.Append(' ');
      if (this.mode == LeaderboardsUI.LeaderboardMode.Friends)
        strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_TOP));
      else if (this.mode == LeaderboardsUI.LeaderboardMode.Overall)
      {
        strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_MYSELF));
      }
      else
      {
        if (this.mode != LeaderboardsUI.LeaderboardMode.MyScore)
          return;
        strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_FRIENDS));
      }
    }

    private enum LeaderboardMode
    {
      Overall,
      MyScore,
      Friends,
    }
  }
}
