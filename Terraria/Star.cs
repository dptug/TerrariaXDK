// Type: Terraria.Star
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct Star
  {
    public static Star[] star = new Star[96];
    public const int maxStars = 96;
    public const int maxStarTypes = 5;
    public Vector2 position;
    public float scale;
    public float rotation;
    public int type;
    public float twinkle;
    public float twinkleSpeed;
    public float rotationSpeed;

    static Star()
    {
    }

    public static unsafe void SpawnStars()
    {
      fixed (Star* starPtr1 = &Star.star[0])
      {
        Star* starPtr2 = starPtr1;
        int num1 = 95;
        while (num1 >= 0)
        {
          starPtr2->type = Main.rand.Next(5);
          int index = starPtr2->type + 19;
          int num2 = SpriteSheet<_sheetTiles>.src[index].Width;
          int num3 = SpriteSheet<_sheetTiles>.src[index].Height;
          int num4;
          do
          {
            num4 = Main.rand.Next(960 - num2);
          }
          while ((num4 < 48 || num4 > 912) && Main.rand.Next(4) != 0);
          starPtr2->position.X = (float) (num4 + (num2 >> 1));
          int num5;
          do
          {
            num5 = Main.rand.Next(540 - num3);
          }
          while ((num5 < 27 || num5 > 513) && Main.rand.Next(4) != 0);
          starPtr2->position.Y = (float) (num5 + (num3 >> 1));
          starPtr2->scale = (float) Main.rand.Next(50, 120) * 0.01f;
          starPtr2->rotation = (float) Main.rand.Next(628) * 0.01f;
          starPtr2->twinkle = (float) Main.rand.Next(101) * 0.01f;
          starPtr2->twinkleSpeed = (float) Main.rand.Next(40, 100) * 0.0001f;
          if (Main.rand.Next(2) == 0)
            starPtr2->twinkleSpeed *= -1f;
          starPtr2->rotationSpeed = (float) Main.rand.Next(10, 40) * 0.0001f;
          if (Main.rand.Next(2) == 0)
            starPtr2->rotationSpeed *= -1f;
          --num1;
          ++starPtr2;
        }
      }
    }

    public static unsafe void UpdateStars()
    {
      fixed (Star* starPtr1 = &Star.star[0])
      {
        Star* starPtr2 = starPtr1;
        int num = 95;
        while (num >= 0)
        {
          starPtr2->twinkle += starPtr2->twinkleSpeed;
          if ((double) starPtr2->twinkle > 1.0)
          {
            starPtr2->twinkle = 1f;
            starPtr2->twinkleSpeed *= -1f;
          }
          else if ((double) starPtr2->twinkle < 0.5)
          {
            starPtr2->twinkle = 0.5f;
            starPtr2->twinkleSpeed *= -1f;
          }
          starPtr2->rotation += starPtr2->rotationSpeed;
          if ((double) starPtr2->rotation > 6.28000020980835)
            starPtr2->rotation -= 6.28f;
          else if ((double) starPtr2->rotation < 0.0)
            starPtr2->rotation += 6.28f;
          --num;
          ++starPtr2;
        }
      }
    }
  }
}
