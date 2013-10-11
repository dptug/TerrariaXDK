// Type: Terraria.CreateCharacter.CategorySelector
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  internal class CategorySelector
  {
    private const float SCROLL_SPEED = 0.075f;
    private const float UNSELECTED_SIZE = 0.75f;
    private Texture2D[] options;
    private Texture2D background;
    private Texture2D backgroundSelected;
    private Vector2 spacing;
    public float ScrollTween;
    public bool Scrolling;
    private CategorySelector.ScrollDirection scrollDirection;
    private int previouslySelected;
    private int selected;

    public int SelectedIndex
    {
      get
      {
        return this.selected;
      }
      set
      {
        this.selected = Math.Min(this.options.Length - 1, Math.Max(0, value));
      }
    }

    public CategorySelector(Texture2D[] options, Texture2D background, Texture2D backgroundSelected, Vector2 spacing)
    {
      this.options = options;
      this.background = background;
      this.backgroundSelected = backgroundSelected;
      this.spacing = spacing;
      this.selected = 0;
      this.Scrolling = false;
      this.ScrollTween = 0.0f;
      this.scrollDirection = CategorySelector.ScrollDirection.PREVIOUS;
      this.previouslySelected = 0;
    }

    public void Update()
    {
      if (!this.Scrolling)
        return;
      this.ScrollTween -= 0.075f;
      if ((double) this.ScrollTween >= 0.0)
        return;
      this.Scrolling = false;
      this.ScrollTween = 0.0f;
    }

    public void Draw(Vector2 position)
    {
      Vector2 vector2_1 = new Vector2((float) (this.background.Width >> 1), (float) (this.background.Height >> 1));
      Vector2 vector2_2 = new Vector2((float) (this.backgroundSelected.Width >> 1), (float) (this.backgroundSelected.Height >> 1));
      int num1 = 4;
      int num2 = num1 * 2 + 1;
      int num3 = num1 + 1;
      for (int index1 = num2; index1 > 0; --index1)
      {
        int index2 = this.selected - num3 + index1;
        if (index2 < 0)
          index2 += this.options.Length;
        else if (index2 >= this.options.Length)
          index2 -= this.options.Length;
        float num4 = (float) num1 - Math.Abs((float) (index1 - num3) + this.ScrollTween * (float) this.scrollDirection);
        float num5 = Math.Max(0.75f, (float) (1.0 - 0.25 * (double) Math.Abs((float) (index1 - num3) + this.ScrollTween * (float) this.scrollDirection)));
        if ((double) num4 >= 0.0 && (double) num5 >= 0.0)
        {
          Texture2D texture2D = this.options[index2];
          Vector2 vector2_3 = new Vector2((float) (texture2D.Width >> 1), (float) (texture2D.Height >> 1));
          Vector2 vector2_4 = this.spacing * this.ScrollTween * (float) this.scrollDirection;
          Vector2 vector2_5 = position + this.spacing * (float) (index1 - num3) + vector2_4;
          if (index2 == this.selected)
            Main.spriteBatch.Draw(this.backgroundSelected, vector2_5, new Rectangle?(), Color.White * num4, 0.0f, vector2_2, num5, SpriteEffects.None, 0.0f);
          else
            Main.spriteBatch.Draw(this.background, vector2_5, new Rectangle?(), Color.White * num4, 0.0f, vector2_1, 1f, SpriteEffects.None, 0.0f);
          Main.spriteBatch.Draw(texture2D, vector2_5, new Rectangle?(), Color.White * num4, 0.0f, vector2_3, 1f, SpriteEffects.None, 0.0f);
        }
      }
      if (this.Scrolling)
        return;
      Vector2 vector2_6 = this.spacing * ((float) num1 - 0.25f);
      Vector2 vector2_7 = position - vector2_6 - new Vector2(8f, 8f);
      Rectangle rect = new Rectangle((int) vector2_7.X, (int) vector2_7.Y, 16, 16);
      SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
      Vector2 vector2_8 = position + vector2_6 - new Vector2(8f, 8f);
      rect.X = (int) vector2_8.X;
      rect.Y = (int) vector2_8.Y;
      SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
    }

    private void StartScrolling(CategorySelector.ScrollDirection direction)
    {
      this.Scrolling = true;
      this.ScrollTween = 1f;
      this.scrollDirection = direction;
    }

    public bool SelectNext()
    {
      bool flag = false;
      if (!this.Scrolling)
      {
        this.previouslySelected = this.selected;
        ++this.selected;
        if (this.selected >= this.options.Length)
          this.selected -= this.options.Length;
        flag = true;
        this.StartScrolling(CategorySelector.ScrollDirection.NEXT);
      }
      return flag;
    }

    public bool SelectPrevious()
    {
      bool flag = false;
      if (!this.Scrolling)
      {
        this.previouslySelected = this.selected;
        --this.selected;
        if (this.selected < 0)
          this.selected += this.options.Length;
        flag = true;
        this.StartScrolling(CategorySelector.ScrollDirection.PREVIOUS);
      }
      return flag;
    }

    private enum ScrollDirection
    {
      PREVIOUS = -1,
      NEXT = 1,
    }
  }
}
