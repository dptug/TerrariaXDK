// Type: Terraria.CreateCharacter.DifficultySelector
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class DifficultySelector : ISelector
  {
    private static Vector2 TITLE_OFFSET = new Vector2(0.0f, -50f);
    private static Vector2 DESCRIPTION_OFFSET = new Vector2(0.0f, 50f);
    private static Vector2 SLIDE_OFFSET = new Vector2(120f, 0.0f);
    private const float TRANSITION_SPEED = 0.1f;
    private const int DESCRIPTION_ID_START = 29;
    private const int TITLE_ID_START = 24;
    private const int MAX_DIFFICULTY = 2;
    private const int ARROW_OFFSET = 10;
    public Difficulty Selected;
    private Difficulty ResetValue;
    private Texture2D[] DifficultyIcons;
    private int FlashTimer;
    private float TransitionTween;
    private DifficultySelector.Direction TransitionDirection;
    private Difficulty PreviousSelected;

    static DifficultySelector()
    {
    }

    public DifficultySelector(Texture2D[] difficultyIcons, Difficulty resetValue)
    {
      this.DifficultyIcons = difficultyIcons;
      this.ResetValue = resetValue;
      this.Selected = resetValue;
      this.TransitionTween = 0.0f;
    }

    public void Draw(Vector2 position, float alpha)
    {
      SpriteFont font = Terraria.UI.fontSmallOutline;
      if ((double) this.TransitionTween > 0.0)
      {
        float num1 = (float) (1.0 - (double) Math.Min(this.TransitionTween, 0.5f) / 0.5);
        float num2 = (float) (((double) Math.Max(0.5f, this.TransitionTween) - 0.5) / 0.5);
        this.DrawDescription(this.PreviousSelected, position, alpha * num2);
        this.DrawDescription(this.Selected, position, alpha * num1);
        int num3 = (int) this.TransitionDirection;
        this.DrawTitle(this.PreviousSelected, position + DifficultySelector.TITLE_OFFSET - DifficultySelector.SLIDE_OFFSET * (1f - this.TransitionTween) * (float) num3, 1f, this.TransitionTween);
        this.DrawTitle(this.Selected, position + DifficultySelector.TITLE_OFFSET + DifficultySelector.SLIDE_OFFSET * this.TransitionTween * (float) num3, 1f, 1f - this.TransitionTween);
      }
      else
      {
        this.DrawTitle(this.Selected, position + DifficultySelector.TITLE_OFFSET, (float) (1.0 + 0.100000001490116 * (double) this.FlashTimer), alpha);
        string text = Lang.menu[(int) (26 - this.Selected)];
        Vector2 vector2 = Terraria.UI.MeasureString(font, text);
        if ((double) alpha > 0.899999976158142)
          this.DrawArrows(position + DifficultySelector.TITLE_OFFSET, new Vector2((float) ((double) vector2.X * 0.5 + 10.0), 0.0f));
        this.DrawDescription(this.Selected, position, alpha);
      }
    }

    private void DrawTitle(Difficulty setting, Vector2 position, float scale, float alpha)
    {
      SpriteFont font = Terraria.UI.fontSmallOutline;
      string str = Lang.menu[(int) (26 - setting)];
      Vector2 pivot = Terraria.UI.MeasureString(font, str);
      pivot.X = (float) Math.Round((double) pivot.X * 0.5);
      pivot.Y = (float) Math.Round((double) pivot.Y * 0.5);
      Color color = setting != Difficulty.HARDCORE ? Color.White : Color.Red;
      Terraria.UI.DrawString(font, str, position, color * alpha, 0.0f, pivot, scale);
    }

    private void DrawArrows(Vector2 position, Vector2 spacing)
    {
      Vector2 vector2_1 = position - spacing - new Vector2(8f, 8f);
      Rectangle rect = new Rectangle((int) vector2_1.X, (int) vector2_1.Y, 16, 16);
      SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
      Vector2 vector2_2 = position + spacing - new Vector2(8f, 8f);
      rect.X = (int) vector2_2.X;
      rect.Y = (int) vector2_2.Y;
      SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
    }

    private void DrawDescription(Difficulty difficulty, Vector2 position, float alpha)
    {
      int index = (int) difficulty;
      Texture2D texture2D = this.DifficultyIcons[index];
      Vector2 vector2 = new Vector2((float) (texture2D.Width >> 1), (float) (texture2D.Height >> 1));
      Main.spriteBatch.Draw(texture2D, position, new Rectangle?(), Color.White * alpha, 0.0f, vector2, (float) (1.0 + 0.100000001490116 * (double) this.FlashTimer), SpriteEffects.None, 0.0f);
      string str = Lang.menu[31 - index];
      SpriteFont font = Terraria.UI.fontSmallOutline;
      Vector2 pivot = Terraria.UI.MeasureString(font, str);
      pivot.X = (float) Math.Round((double) pivot.X * 0.5);
      pivot.Y = (float) Math.Round((double) pivot.Y * 0.5);
      Terraria.UI.DrawString(font, str, position + DifficultySelector.DESCRIPTION_OFFSET, Color.White * alpha, 0.0f, pivot, 1f);
    }

    public void Update()
    {
      if ((double) this.TransitionTween > 0.0)
        this.TransitionTween -= 0.1f;
      else
        this.TransitionTween = 0.0f;
      if (this.FlashTimer <= 0)
        return;
      --this.FlashTimer;
    }

    public bool SelectLeft()
    {
      this.PreviousSelected = this.Selected;
      int num = (int) (this.Selected - 1);
      if (num < 0)
        num = 2;
      this.Selected = (Difficulty) num;
      this.TransitionTween = 1f;
      this.TransitionDirection = DifficultySelector.Direction.PREVIOUS;
      return true;
    }

    public bool SelectRight()
    {
      this.PreviousSelected = this.Selected;
      int num = (int) (this.Selected + 1);
      if (num > 2)
        num = 0;
      this.Selected = (Difficulty) num;
      this.TransitionTween = 1f;
      this.TransitionDirection = DifficultySelector.Direction.NEXT;
      return true;
    }

    public bool SelectUp()
    {
      return false;
    }

    public bool SelectDown()
    {
      return false;
    }

    public void SetCursor(Vector2i cursor)
    {
      this.Selected = (Difficulty) Math.Min(Math.Max(cursor.X, 0), 2);
    }

    public void Reset()
    {
      this.Selected = this.ResetValue;
    }

    public void Show()
    {
      this.ResetValue = this.Selected;
      this.FlashTimer = 0;
    }

    public void FlashSelection(int duration)
    {
      this.FlashTimer = duration;
    }

    public void CancelSelection()
    {
      this.Selected = this.ResetValue;
    }

    private enum Direction
    {
      PREVIOUS = -1,
      NEXT = 1,
    }
  }
}
