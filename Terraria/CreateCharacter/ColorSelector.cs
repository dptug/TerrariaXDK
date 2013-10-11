// Type: Terraria.CreateCharacter.ColorSelector
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class ColorSelector : ISelector
  {
    private const int ITEM_WIDTH = 16;
    private const int ITEM_HEIGHT = 16;
    private const int ITEM_SELECTED_WIDTH = 20;
    private const int ITEM_SELECTED_HEIGHT = 20;
    private const int ITEM_SPACING = 6;
    private Texture2D palette;
    private Rectangle paletteBounds;
    private Texture2D picker;
    private Rectangle pickerBounds;
    private Vector2i selected;
    private Vector2i revertValue;
    private Vector2i resetValue;
    private int flashTimer;
    public Color Selected;

    public ColorSelector(Texture2D palette, Texture2D picker, Vector2i resetValue)
    {
      this.palette = palette;
      this.paletteBounds = palette.Bounds;
      this.picker = picker;
      this.pickerBounds = picker.Bounds;
      this.selected = resetValue;
      this.resetValue = resetValue;
      this.resetValue = resetValue;
      this.UpdateColor();
    }

    public void Update()
    {
      if (this.flashTimer <= 0)
        return;
      --this.flashTimer;
    }

    public void Draw(Vector2 position, float alpha)
    {
      Rectangle rectangle1 = this.paletteBounds;
      Rectangle rectangle2 = new Rectangle(0, 0, 1, 1);
      Rectangle rectangle3 = new Rectangle(0, 0, 16, 16);
      Vector2 position1 = new Vector2();
      Vector2i vector2i = new Vector2i(8, 8);
      int num1 = rectangle1.Width * 22 - 6;
      int num2 = rectangle1.Height * 22 - 6;
      position.X -= (float) (num1 >> 1);
      position.Y -= (float) (num2 >> 1);
      position.X += 8f;
      position.Y += 8f;
      Color color1 = Color.White * alpha;
      Color color2 = Color.Black * alpha;
      for (int index1 = rectangle1.Height - 1; index1 > -1; --index1)
      {
        for (int index2 = rectangle1.Width - 1; index2 > -1; --index2)
        {
          if (this.selected.X != index2 || this.selected.Y != index1)
          {
            rectangle2.X = index2;
            rectangle2.Y = index1;
            rectangle3.X = (int) position.X + index2 * 22 - vector2i.X;
            rectangle3.Y = (int) position.Y + index1 * 22 - vector2i.Y;
            Main.spriteBatch.Draw(this.palette, rectangle3, new Rectangle?(rectangle2), color1);
            position1.X = (float) (rectangle3.X - (this.pickerBounds.Width - 16 >> 1));
            position1.Y = (float) (rectangle3.Y - (this.pickerBounds.Height - 16 >> 1));
            Main.spriteBatch.Draw(this.picker, position1, color2);
          }
        }
      }
      Vector2 vector2 = new Vector2();
      vector2.X = position.X + (float) (this.selected.X * 22);
      vector2.Y = position.Y + (float) (this.selected.Y * 22);
      rectangle2.X = this.selected.X;
      rectangle2.Y = this.selected.Y;
      float num3 = this.flashTimer > 0 ? (float) (1.0 + 0.100000001490116 * (double) this.flashTimer) : 1f;
      rectangle3.X = (int) position.X + this.selected.X * 22 - (int) ((double) vector2i.X * (double) num3);
      rectangle3.Y = (int) position.Y + this.selected.Y * 22 - (int) ((double) vector2i.Y * (double) num3);
      rectangle3.Width = (int) ((double) rectangle3.Width * (double) num3);
      rectangle3.Height = (int) ((double) rectangle3.Height * (double) num3);
      Main.spriteBatch.Draw(this.palette, rectangle3, new Rectangle?(rectangle2), color1);
      Main.spriteBatch.Draw(this.picker, vector2, new Rectangle?(), color1, 0.0f, new Vector2((float) (this.pickerBounds.Width >> 1), (float) (this.pickerBounds.Height >> 1)), num3, SpriteEffects.None, 0.0f);
    }

    private void UpdateColor()
    {
      Rectangle rectangle = new Rectangle(this.selected.X, this.selected.Y, 1, 1);
      Color[] colorArray = new Color[1];
      this.palette.GetData<Color>(0, new Rectangle?(rectangle), (M0[]) colorArray, 0, 1);
      this.Selected = colorArray[0];
    }

    public bool SelectLeft()
    {
      if (this.selected.X > 0)
        --this.selected.X;
      else
        this.selected.X = this.paletteBounds.Width - 1;
      this.UpdateColor();
      return true;
    }

    public bool SelectRight()
    {
      if (this.selected.X < this.paletteBounds.Width - 1)
        ++this.selected.X;
      else
        this.selected.X = 0;
      this.UpdateColor();
      return true;
    }

    public bool SelectUp()
    {
      if (this.selected.Y > 0)
        --this.selected.Y;
      else
        this.selected.Y = this.paletteBounds.Height - 1;
      this.UpdateColor();
      return true;
    }

    public bool SelectDown()
    {
      if (this.selected.Y < this.paletteBounds.Height - 1)
        ++this.selected.Y;
      else
        this.selected.Y = 0;
      this.UpdateColor();
      return true;
    }

    public void SetCursor(Vector2i cursor)
    {
      this.selected = cursor;
      this.UpdateColor();
    }

    public void Reset()
    {
      this.selected = this.resetValue;
      this.UpdateColor();
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
      this.UpdateColor();
    }
  }
}
