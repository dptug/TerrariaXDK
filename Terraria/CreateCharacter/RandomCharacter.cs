// Type: Terraria.CreateCharacter.RandomCharacter
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Terraria;

namespace Terraria.CreateCharacter
{
  internal class RandomCharacter
  {
    private static Vector2i getRandomColor(FastRandom rnd)
    {
      int width = Assets.COLOR_PALETTE.Width;
      int upperBound = Assets.COLOR_PALETTE.Height >> 1;
      int num = Assets.COLOR_PALETTE.Height >> 2;
      return new Vector2i(rnd.Next(width), rnd.Next(upperBound) + num);
    }

    public static Vector2i[] create(FastRandom rnd)
    {
      RandomCharacter.HairGender[] hairGenderArray = new RandomCharacter.HairGender[36]
      {
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Male,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Unisex,
        RandomCharacter.HairGender.Female,
        RandomCharacter.HairGender.Male
      };
      Vector2i[] vector2iArray1 = new Vector2i[6]
      {
        new Vector2i(3, 3),
        new Vector2i(3, 3),
        new Vector2i(3, 5),
        new Vector2i(3, 7),
        new Vector2i(0, 8),
        new Vector2i(3, 0)
      };
      Vector2i[] vector2iArray2 = new Vector2i[6]
      {
        new Vector2i(9, 4),
        new Vector2i(3, 8),
        new Vector2i(9, 7),
        new Vector2i(3, 8),
        new Vector2i(3, 8),
        new Vector2i(2, 4)
      };
      Vector2i[] vector2iArray3 = new Vector2i[10];
      int index1 = rnd.Next(36);
      vector2iArray3[1] = new Vector2i(index1 % 9, index1 / 9);
      RandomCharacter.HairGender hairGender = hairGenderArray[index1];
      int x = hairGender != RandomCharacter.HairGender.Male ? (hairGender != RandomCharacter.HairGender.Female ? rnd.Next(2) : 1) : 0;
      vector2iArray3[0] = new Vector2i(x, 0);
      int index2 = rnd.Next(vector2iArray1.Length);
      vector2iArray3[4] = vector2iArray1[index2];
      vector2iArray3[3] = vector2iArray2[index2];
      vector2iArray3[2] = RandomCharacter.getRandomColor(rnd);
      vector2iArray3[5] = RandomCharacter.getRandomColor(rnd);
      vector2iArray3[6] = RandomCharacter.getRandomColor(rnd);
      vector2iArray3[7] = RandomCharacter.getRandomColor(rnd);
      vector2iArray3[8] = RandomCharacter.getRandomColor(rnd);
      return vector2iArray3;
    }

    private enum HairGender
    {
      Male,
      Female,
      Unisex,
    }
  }
}
