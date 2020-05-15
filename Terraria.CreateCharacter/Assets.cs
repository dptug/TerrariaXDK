using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.CreateCharacter
{
	internal class Assets
	{
		public const int HAIR_COUNT = 36;

		public static Texture2D CATEGORY_BACKGROUND;

		public static Texture2D CATEGORY_BACKGROUND_SELECTED;

		public static Texture2D[] CATEGORY_ICONS;

		public static Rectangle[] HAIR_SOURCES;

		public static Texture2D HAIR_PICKER;

		public static Texture2D HAIR_BACKGROUND;

		public static Texture2D COLOR_PALETTE;

		public static Texture2D COLOR_PICKER;

		public static Texture2D OPTION_MALE;

		public static Texture2D OPTION_FEMALE;

		public static Texture2D DIFFICULTY_SOFTCORE;

		public static Texture2D DIFFICULTY_MEDIUMCORE;

		public static Texture2D DIFFICULTY_HARDCORE;

		public static Texture2D HORIZONTAL_PICKER;

		public static Texture2D HORIZONTAL_BACKGROUND;

		public static Texture2D FRAME;

		public static void LoadContent(ContentManager Content)
		{
			CATEGORY_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Tile01");
			CATEGORY_BACKGROUND_SELECTED = Content.Load<Texture2D>("UI/CharacterCreation/Tile01_Bigger");
			CATEGORY_ICONS = new Texture2D[10]
			{
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Gender"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Hair"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_HairColor"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Eyes"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Skin"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Shirt"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Undershirt"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Pants"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Shoes"),
				Content.Load<Texture2D>("UI/CharacterCreation/Category_Difficulty")
			};
			HAIR_SOURCES = new Rectangle[36];
			for (int i = 0; i < 36; i++)
			{
				HAIR_SOURCES[i] = new Rectangle(0, 4, 40, 30);
			}
			HAIR_SOURCES[2] = new Rectangle(0, 6, 40, 40);
			HAIR_SOURCES[8] = new Rectangle(4, 4, 40, 30);
			HAIR_SOURCES[9] = new Rectangle(0, 4, 35, 30);
			HAIR_SOURCES[10] = new Rectangle(2, 4, 40, 28);
			HAIR_SOURCES[16] = new Rectangle(2, 0, 30, 28);
			HAIR_SOURCES[17] = new Rectangle(0, 6, 40, 32);
			HAIR_SOURCES[23] = new Rectangle(0, 0, 40, 28);
			HAIR_SOURCES[26] = new Rectangle(0, 4, 35, 30);
			HAIR_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Selector");
			HAIR_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Background");
			COLOR_PALETTE = Content.Load<Texture2D>("UI/CharacterCreation/Palette");
			COLOR_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Color_Selector");
			OPTION_MALE = Content.Load<Texture2D>("UI/CharacterCreation/Gender_Male");
			OPTION_FEMALE = Content.Load<Texture2D>("UI/CharacterCreation/Gender_Female");
			DIFFICULTY_SOFTCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Soft");
			DIFFICULTY_MEDIUMCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Med");
			DIFFICULTY_HARDCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Hard");
			HORIZONTAL_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Selector");
			HORIZONTAL_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Background");
			FRAME = Content.Load<Texture2D>("UI/CharacterCreation/Frame01");
		}
	}
}
