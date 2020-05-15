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
			TEXT_BACKGROUND = Content.Load<Texture2D>("UI/HowToPlay/Text_Back");
			TEXT_BACKGROUND_BORDER_WIDTH = 20;
			HOWTO_MOVEMENT = Content.Load<Texture2D>("UI/HowToPlay/Howto_Movement");
			HOWTO_HOTBAR2 = Content.Load<Texture2D>("UI/HowToPlay/Howto_Hotbar2");
			HOWTO_DEBUFF = Content.Load<Texture2D>("UI/HowToPlay/Howto_Debuff");
			HOWTO_INVENTORY = Content.Load<Texture2D>("UI/HowToPlay/Howto_Inventory");
			HOWTO_LOGO = Content.Load<Texture2D>("UI/HowToPlay/Howto_Logo");
		}
	}
}
