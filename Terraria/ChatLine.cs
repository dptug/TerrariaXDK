// Type: Terraria.ChatLine
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct ChatLine
  {
    public Color color;
    public int showTime;
    public string text;

    public void Init()
    {
      this.color = Color.White;
      this.showTime = 0;
      this.text = (string) null;
    }
  }
}
