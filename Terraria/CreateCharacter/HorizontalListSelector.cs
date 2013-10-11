// Type: Terraria.CreateCharacter.HorizontalListSelector
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class HorizontalListSelector : ISelector
  {
    private const int ITEM_SPACING = 4;
    private Texture2D[] options;
    private Texture2D background;
    private Vector2 backgroundOrigin;
    private Texture2D picker;
    private Vector2 pickerOrigin;
    private int flashTimer;
    public int Selected;
    private int revertValue;
    private int resetValue;

    public HorizontalListSelector(Texture2D[] options, Texture2D background, Texture2D picker, int resetValue)
    {
      this.background = background;
      this.backgroundOrigin = new Vector2((float) (background.Width >> 1), (float) (background.Height >> 1));
      this.options = options;
      this.picker = picker;
      this.pickerOrigin = new Vector2((float) (picker.Bounds.Width >> 1), (float) (picker.Bounds.Height >> 1));
      this.Selected = resetValue;
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
      float num1 = this.flashTimer > 0 ? (float) (2.0 + 0.100000001490116 * (double) this.flashTimer) : 2f;
      Color color = Color.White * alpha;
      float num2 = (float) ((double) this.background.Width * 2.0 + 4.0);
      int num3 = (this.options.Length - 1) * (int) num2 - 4;
      position.X -= (float) (num3 >> 1);
      Vector2 vector2_1 = Vector2.Zero;
      Vector2 vector2_2 = Vector2.Zero;
      Texture2D texture2D1 = (Texture2D) null;
      for (int index = 0; index < this.options.Length; ++index)
      {
        Texture2D texture2D2 = this.options[index];
        Vector2 vector2_3 = new Vector2((float) (texture2D2.Width >> 1), (float) (texture2D2.Height >> 1));
        if (index == this.Selected)
        {
          texture2D1 = texture2D2;
          vector2_2 = vector2_3;
          vector2_1 = position;
        }
        else
        {
          Main.spriteBatch.Draw(this.background, position, new Rectangle?(), color, 0.0f, this.backgroundOrigin, 2f, SpriteEffects.None, 0.0f);
          Main.spriteBatch.Draw(texture2D2, position, new Rectangle?(), color, 0.0f, vector2_3, 2f, SpriteEffects.None, 0.0f);
        }
        position.X += num2;
      }
      if (texture2D1 == null)
        return;
      Main.spriteBatch.Draw(this.picker, vector2_1, new Rectangle?(), color, 0.0f, this.pickerOrigin, num1, SpriteEffects.None, 0.0f);
      Main.spriteBatch.Draw(texture2D1, vector2_1, new Rectangle?(), color, 0.0f, vector2_2, num1, SpriteEffects.None, 0.0f);
    }

    public bool SelectLeft()
    {
      if (this.Selected > 0)
        --this.Selected;
      else
        this.Selected = this.options.Length - 1;
      return true;
    }

    public bool SelectRight()
    {
      if (this.Selected < this.options.Length - 1)
        ++this.Selected;
      else
        this.Selected = 0;
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

    public void Reset()
    {
      this.Selected = this.resetValue;
    }

    public void Show()
    {
      this.revertValue = this.Selected;
      this.flashTimer = 0;
    }

    public void FlashSelection(int duration)
    {
      this.flashTimer = duration;
    }

    public void CancelSelection()
    {
      this.Selected = this.revertValue;
    }

    public void SetCursor(Vector2i cursor)
    {
      int num = cursor.X;
      if (num < 0)
        num = 0;
      else if (num > this.options.Length - 1)
        num = this.options.Length - 1;
      this.Selected = num;
    }
  }
}
