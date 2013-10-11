// Type: Terraria.SoundUI.Assets
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.SoundUI
{
  public class Assets
  {
    public static Texture2D SLIDER;
    public static Rectangle SLIDER_EMPTY_RECT;
    public static Rectangle SLIDER_EMPTY_INACTIVE_RECT;
    public static Rectangle SLIDER_FULL_RECT;
    public static Rectangle SLIDER_FULL_INACTIVE_RECT;
    public static Texture2D SOUND_ICONS;
    public static Rectangle SOUND_ICON_RECT;
    public static Rectangle MUSIC_ICON_RECT;

    public static void LoadContent(ContentManager Content)
    {
      Assets.SLIDER = Content.Load<Texture2D>("UI/SoundBar");
      Assets.SLIDER_EMPTY_RECT = new Rectangle(0, 0, 244, 58);
      Assets.SLIDER_EMPTY_INACTIVE_RECT = new Rectangle(0, 58, 244, 58);
      Assets.SLIDER_FULL_RECT = new Rectangle(0, 116, 244, 58);
      Assets.SLIDER_FULL_INACTIVE_RECT = new Rectangle(0, 174, 244, 58);
      Assets.SOUND_ICONS = Content.Load<Texture2D>("UI/SoundIcons");
      Assets.SOUND_ICON_RECT = new Rectangle(0, 36, 40, 36);
      Assets.MUSIC_ICON_RECT = new Rectangle(0, 0, 40, 36);
    }
  }
}
