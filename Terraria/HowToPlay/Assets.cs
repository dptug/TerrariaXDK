// Type: Terraria.HowToPlay.Assets
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.HowToPlay
{
  public class Assets
  {
    public static Texture2D TEXT_BACKGROUND;
    public static int TEXT_BACKGROUND_BORDER_WIDTH;
    public static Texture2D HOWTO_LOGO;
    public static Texture2D HOWTO_MOVEMENT;
    public static Texture2D HOWTO_HOTBAR2;
    public static Texture2D HOWTO_DEBUFF;
    public static Texture2D HOWTO_INVENTORY;

    public static void LoadContent(ContentManager Content)
    {
      Assets.TEXT_BACKGROUND = Content.Load<Texture2D>("UI/HowToPlay/Text_Back");
      Assets.TEXT_BACKGROUND_BORDER_WIDTH = 20;
      Assets.HOWTO_MOVEMENT = Content.Load<Texture2D>("UI/HowToPlay/Howto_Movement");
      Assets.HOWTO_HOTBAR2 = Content.Load<Texture2D>("UI/HowToPlay/Howto_Hotbar2");
      Assets.HOWTO_DEBUFF = Content.Load<Texture2D>("UI/HowToPlay/Howto_Debuff");
      Assets.HOWTO_INVENTORY = Content.Load<Texture2D>("UI/HowToPlay/Howto_Inventory");
      Assets.HOWTO_LOGO = Content.Load<Texture2D>("UI/HowToPlay/Howto_Logo");
    }
  }
}
