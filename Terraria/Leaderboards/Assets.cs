// Type: Terraria.Leaderboards.Assets
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Leaderboards
{
  internal class Assets
  {
    public static Texture2D[] COLUMN_ICONS;

    public static void LoadContent(ContentManager Content)
    {
      Assets.COLUMN_ICONS = new Texture2D[32];
      string str1 = "UI/Leaderboards/";
      for (int index = 31; index >= 0; --index)
      {
        string str2 = ((object) (Column) index).ToString().ToLower();
        string assetName = str1 + str2;
        Assets.COLUMN_ICONS[index] = Content.Load<Texture2D>(assetName);
      }
    }
  }
}
