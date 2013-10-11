// Type: Terraria.CreateCharacter.Assets
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

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
      Assets.CATEGORY_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Tile01");
      Assets.CATEGORY_BACKGROUND_SELECTED = Content.Load<Texture2D>("UI/CharacterCreation/Tile01_Bigger");
      Assets.CATEGORY_ICONS = new Texture2D[10]
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
      Assets.HAIR_SOURCES = new Rectangle[36];
      for (int index = 0; index < 36; ++index)
        Assets.HAIR_SOURCES[index] = new Rectangle(0, 4, 40, 30);
      Assets.HAIR_SOURCES[2] = new Rectangle(0, 6, 40, 40);
      Assets.HAIR_SOURCES[8] = new Rectangle(4, 4, 40, 30);
      Assets.HAIR_SOURCES[9] = new Rectangle(0, 4, 35, 30);
      Assets.HAIR_SOURCES[10] = new Rectangle(2, 4, 40, 28);
      Assets.HAIR_SOURCES[16] = new Rectangle(2, 0, 30, 28);
      Assets.HAIR_SOURCES[17] = new Rectangle(0, 6, 40, 32);
      Assets.HAIR_SOURCES[23] = new Rectangle(0, 0, 40, 28);
      Assets.HAIR_SOURCES[26] = new Rectangle(0, 4, 35, 30);
      Assets.HAIR_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Selector");
      Assets.HAIR_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Background");
      Assets.COLOR_PALETTE = Content.Load<Texture2D>("UI/CharacterCreation/Palette");
      Assets.COLOR_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Color_Selector");
      Assets.OPTION_MALE = Content.Load<Texture2D>("UI/CharacterCreation/Gender_Male");
      Assets.OPTION_FEMALE = Content.Load<Texture2D>("UI/CharacterCreation/Gender_Female");
      Assets.DIFFICULTY_SOFTCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Soft");
      Assets.DIFFICULTY_MEDIUMCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Med");
      Assets.DIFFICULTY_HARDCORE = Content.Load<Texture2D>("UI/CharacterCreation/Button_Difficulty_Hard");
      Assets.HORIZONTAL_PICKER = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Selector");
      Assets.HORIZONTAL_BACKGROUND = Content.Load<Texture2D>("UI/CharacterCreation/Hair_Background");
      Assets.FRAME = Content.Load<Texture2D>("UI/CharacterCreation/Frame01");
    }
  }
}
