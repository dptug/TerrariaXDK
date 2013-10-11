// Type: Terraria.CreateCharacter.HairSelector
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class HairSelector : ISelector
  {
    private const int ITEM_SPACING = 2;
    private Texture2D background;
    private Texture2D picker;
    private Vector2 pickerOrigin;
    private int columns;
    private int rows;
    private Rectangle[] sources;
    private int flashTimer;
    private Vector2i selected;
    private Vector2i revertValue;
    private Vector2i resetValue;

    public int Selected
    {
      get
      {
        return this.selected.X + this.selected.Y * this.columns;
      }
    }

    public HairSelector(int columns, Rectangle[] sources, Texture2D background, Texture2D picker, Vector2i resetValue)
    {
      this.background = background;
      this.picker = picker;
      this.pickerOrigin = new Vector2((float) (picker.Bounds.Width >> 1), (float) (picker.Bounds.Height >> 1));
      this.columns = columns;
      this.rows = sources.Length / columns;
      this.sources = sources;
      this.selected = resetValue;
      this.revertValue = resetValue;
      this.resetValue = resetValue;
    }

    public void Update()
    {
      if (this.flashTimer <= 0)
        return;
      --this.flashTimer;
    }

    public void Draw(Vector2 position, float alpha)
    {
      Rectangle bounds = this.background.Bounds;
      int num1 = bounds.Width + 2;
      int num2 = bounds.Height + 2;
      int num3 = bounds.Width >> 1;
      int num4 = bounds.Height >> 1;
      int num5 = num1 * this.columns - 2;
      int num6 = num2 * this.rows - 2;
      position.X -= (float) (num5 >> 1);
      position.Y -= (float) (num6 >> 1);
      position.X += (float) num3;
      position.Y += (float) num4;
      Color color = Color.White * alpha;
      Vector2 position1 = new Vector2();
      for (int index1 = this.rows - 1; index1 > -1; --index1)
      {
        int y = (int) position.Y + index1 * num2;
        for (int index2 = this.columns - 1; index2 > -1; --index2)
        {
          if (index1 != this.selected.Y || index2 != this.selected.X)
          {
            int x = (int) position.X + index2 * num1;
            int index3 = index1 * this.columns + index2;
            position1.X = (float) (x - num3);
            position1.Y = (float) (y - num4);
            Main.spriteBatch.Draw(this.background, position1, color);
            SpriteSheet<_sheetSprites>.DrawCentered(1269 + index3, x, y, this.sources[index3], color);
          }
        }
      }
      Vector2 vector2 = new Vector2();
      float scale = this.flashTimer > 0 ? (float) (1.0 + 0.100000001490116 * (double) this.flashTimer) : 1f;
      vector2.X = position.X + (float) (this.selected.X * num1);
      vector2.Y = position.Y + (float) (this.selected.Y * num2);
      Main.spriteBatch.Draw(this.picker, vector2, new Rectangle?(), color, 0.0f, this.pickerOrigin, scale, SpriteEffects.None, 0.0f);
      SpriteSheet<_sheetSprites>.DrawCentered(1269 + this.Selected, (int) vector2.X, (int) vector2.Y, this.sources[this.Selected], color, scale);
    }

    public bool SelectLeft()
    {
      if (this.selected.X > 0)
        --this.selected.X;
      else
        this.selected.X = this.columns - 1;
      return true;
    }

    public bool SelectRight()
    {
      if (this.selected.X < this.columns - 1)
        ++this.selected.X;
      else
        this.selected.X = 0;
      return true;
    }

    public bool SelectUp()
    {
      if (this.selected.Y > 0)
        --this.selected.Y;
      else
        this.selected.Y = this.rows - 1;
      return true;
    }

    public bool SelectDown()
    {
      if (this.selected.Y < this.rows - 1)
        ++this.selected.Y;
      else
        this.selected.Y = 0;
      return true;
    }

    public void SetCursor(Vector2i cursor)
    {
      this.selected = cursor;
    }

    public void Reset()
    {
      this.selected = this.resetValue;
    }

    public void Show()
    {
      this.revertValue = this.selected;
      this.flashTimer = 0;
    }

    public void FlashSelection(int duration)
    {
      this.flashTimer = duration;
    }

    public void CancelSelection()
    {
      this.selected = this.revertValue;
    }
  }
}
