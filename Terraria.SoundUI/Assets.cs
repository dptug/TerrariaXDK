using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.SoundUI;

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
		SLIDER = Content.Load<Texture2D>("UI/SoundBar");
		SLIDER_EMPTY_RECT = new Rectangle(0, 0, 244, 58);
		SLIDER_EMPTY_INACTIVE_RECT = new Rectangle(0, 58, 244, 58);
		SLIDER_FULL_RECT = new Rectangle(0, 116, 244, 58);
		SLIDER_FULL_INACTIVE_RECT = new Rectangle(0, 174, 244, 58);
		SOUND_ICONS = Content.Load<Texture2D>("UI/SoundIcons");
		SOUND_ICON_RECT = new Rectangle(0, 36, 40, 36);
		MUSIC_ICON_RECT = new Rectangle(0, 0, 40, 36);
	}
}
