// Type: Terraria.ItemText
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct ItemText
  {
    public const int ACTIVE_TIME = 56;
    public byte active;
    public short lifeTime;
    public short netID;
    public Vector2 position;
    public float velocityY;
    public float alpha;
    public float alphaDir;
    public float scale;
    public Color color;
    public int stack;
    public string text;
    public Vector2 textSize;

    public void Init()
    {
      this.active = (byte) 0;
    }

    public void Update(int whoAmI, ItemTextPool pool)
    {
      this.alpha += this.alphaDir;
      if ((double) this.alpha <= 0.699999988079071)
      {
        this.alpha = 0.7f;
        this.alphaDir = -this.alphaDir;
      }
      else if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -this.alphaDir;
      }
      bool flag = false;
      Vector2 vector2_1 = this.textSize * this.scale;
      vector2_1.Y *= 0.8f;
      Rectangle rectangle1 = new Rectangle();
      Rectangle rectangle2 = new Rectangle();
      rectangle1.X = (int) ((double) this.position.X - (double) vector2_1.X * 0.5);
      rectangle1.Y = (int) ((double) this.position.Y - (double) vector2_1.Y * 0.5);
      rectangle1.Width = (int) vector2_1.X;
      rectangle1.Height = (int) vector2_1.Y;
      for (int index = 0; index < 4; ++index)
      {
        if ((int) pool.itemText[index].active != 0 && index != whoAmI)
        {
          Vector2 vector2_2 = pool.itemText[index].textSize;
          vector2_2 *= pool.itemText[index].scale;
          vector2_2.Y *= 0.8f;
          rectangle2.X = (int) ((double) pool.itemText[index].position.X - (double) vector2_2.X * 0.5);
          rectangle2.Y = (int) ((double) pool.itemText[index].position.Y - (double) vector2_2.Y * 0.5);
          rectangle2.Width = (int) vector2_2.X;
          rectangle2.Height = (int) vector2_2.Y;
          if (rectangle1.Intersects(rectangle2) && ((double) this.position.Y < (double) pool.itemText[index].position.Y || (double) this.position.Y == (double) pool.itemText[index].position.Y && whoAmI < index))
          {
            flag = true;
            int num = pool.numActive;
            if (num > 3)
              num = 3;
            pool.itemText[index].lifeTime = this.lifeTime = (short) (56 + num * 14);
          }
        }
      }
      if (!flag)
      {
        this.velocityY *= 0.86f;
        if ((double) this.scale == 1.0)
          this.velocityY *= 0.4f;
      }
      else if ((double) this.velocityY > -6.0)
        this.velocityY -= 0.2f;
      else
        this.velocityY *= 0.86f;
      this.position.Y += this.velocityY;
      if ((int) --this.lifeTime <= 0)
      {
        this.scale -= 0.03f;
        if ((double) this.scale < 0.100000001490116)
          this.active = (byte) 0;
        this.lifeTime = (short) 0;
      }
      else
      {
        if ((double) this.scale < 1.0)
          this.scale += 0.1f;
        if ((double) this.scale <= 1.0)
          return;
        this.scale = 1f;
      }
    }
  }
}
