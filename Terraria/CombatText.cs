// Type: Terraria.CombatText
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct CombatText
  {
    public byte active;
    public bool crit;
    public short lifeTime;
    public float alpha;
    public float alphaDir;
    public string text;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 textSize;
    public float scale;
    public float rotation;

    public void Init()
    {
      this.active = (byte) 0;
    }

    public static void NewText(Vector2 pos, int w, int h, int amount, bool Crit = false)
    {
      for (int index1 = 0; index1 < 32; ++index1)
      {
        if ((int) Main.combatText[index1].active == 0)
        {
          w >>= 1;
          h >>= 1;
          int index2 = Crit ? 1 : 0;
          Main.combatText[index1].text = ToStringExtensions.ToStringLookup(amount);
          Vector2 vector2 = UI.MeasureString(UI.fontCombatText[index2], Main.combatText[index1].text);
          Main.combatText[index1].textSize = vector2;
          Main.combatText[index1].alpha = 1f;
          Main.combatText[index1].alphaDir = -0.05f;
          Main.combatText[index1].active = (byte) 1;
          Main.combatText[index1].scale = 0.0f;
          Main.combatText[index1].position.X = (float) ((double) pos.X + (double) w - (double) vector2.X * 0.5);
          Main.combatText[index1].position.Y = (float) ((double) pos.Y + (double) (h >> 1) - (double) vector2.Y * 0.5);
          Main.combatText[index1].position.X += (float) Main.rand.Next(-w, w + 1);
          Main.combatText[index1].position.Y += (float) Main.rand.Next(-h, h + 1);
          Main.combatText[index1].crit = Crit;
          if (Crit)
          {
            Main.combatText[index1].lifeTime = (short) 120;
            Main.combatText[index1].velocity.Y = -14f;
            Main.combatText[index1].velocity.X = (float) Main.rand.Next(-25, 26) * 0.05f;
            Main.combatText[index1].rotation = (double) Main.combatText[index1].velocity.X < 0.0 ? -0.12f : 0.12f;
            break;
          }
          else
          {
            Main.combatText[index1].rotation = 0.0f;
            Main.combatText[index1].velocity.Y = -7f;
            Main.combatText[index1].lifeTime = (short) 60;
            break;
          }
        }
      }
    }

    public void Update()
    {
      this.alpha += this.alphaDir;
      if ((double) this.alpha <= 0.600000023841858)
        this.alphaDir = -this.alphaDir;
      else if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -this.alphaDir;
      }
      this.velocity.Y *= 0.92f;
      if (this.crit)
        this.velocity.Y *= 0.92f;
      this.velocity.X *= 0.93f;
      this.position.X += this.velocity.X;
      this.position.Y += this.velocity.Y;
      if ((int) --this.lifeTime <= 0)
      {
        this.scale -= 0.1f;
        if ((double) this.scale < 0.100000001490116)
          this.active = (byte) 0;
        this.lifeTime = (short) 0;
        if (!this.crit)
          return;
        this.alphaDir = -1f;
        this.scale += 0.07f;
      }
      else
      {
        if (this.crit)
        {
          if ((double) this.velocity.X < 0.0)
            this.rotation += 1.0 / 1000.0;
          else
            this.rotation -= 1.0 / 1000.0;
        }
        if ((double) this.scale < 1.0)
          this.scale += 0.1f;
        if ((double) this.scale <= 1.0)
          return;
        this.scale = 1f;
      }
    }

    public static void UpdateCombatText()
    {
      for (int index = 31; index >= 0; --index)
      {
        if ((int) Main.combatText[index].active != 0)
          Main.combatText[index].Update();
      }
    }
  }
}
