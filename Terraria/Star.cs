using Microsoft.Xna.Framework;

namespace Terraria;

public struct Star
{
	public const int maxStars = 96;

	public const int maxStarTypes = 5;

	public static Star[] star = new Star[96];

	public Vector2 position;

	public float scale;

	public float rotation;

	public int type;

	public float twinkle;

	public float twinkleSpeed;

	public float rotationSpeed;

	public unsafe static void SpawnStars()
	{
		fixed (Star* ptr = &star[0])
		{
			Star* ptr2 = ptr;
			int num = 95;
			while (num >= 0)
			{
				ptr2->type = Main.rand.Next(5);
				int num2 = ptr2->type + 19;
				int width = SpriteSheet<_sheetTiles>.src[num2].Width;
				int height = SpriteSheet<_sheetTiles>.src[num2].Height;
				int num3;
				do
				{
					num3 = Main.rand.Next(960 - width);
				}
				while ((num3 < 48 || num3 > 912) && Main.rand.Next(4) != 0);
				ptr2->position.X = num3 + (width >> 1);
				do
				{
					num3 = Main.rand.Next(540 - height);
				}
				while ((num3 < 27 || num3 > 513) && Main.rand.Next(4) != 0);
				ptr2->position.Y = num3 + (height >> 1);
				ptr2->scale = (float)Main.rand.Next(50, 120) * 0.01f;
				ptr2->rotation = (float)Main.rand.Next(628) * 0.01f;
				ptr2->twinkle = (float)Main.rand.Next(101) * 0.01f;
				ptr2->twinkleSpeed = (float)Main.rand.Next(40, 100) * 0.0001f;
				if (Main.rand.Next(2) == 0)
				{
					ptr2->twinkleSpeed *= -1f;
				}
				ptr2->rotationSpeed = (float)Main.rand.Next(10, 40) * 0.0001f;
				if (Main.rand.Next(2) == 0)
				{
					ptr2->rotationSpeed *= -1f;
				}
				num--;
				ptr2++;
			}
		}
	}

	public unsafe static void UpdateStars()
	{
		fixed (Star* ptr = &star[0])
		{
			Star* ptr2 = ptr;
			int num = 95;
			while (num >= 0)
			{
				ptr2->twinkle += ptr2->twinkleSpeed;
				if (ptr2->twinkle > 1f)
				{
					ptr2->twinkle = 1f;
					ptr2->twinkleSpeed *= -1f;
				}
				else if (ptr2->twinkle < 0.5f)
				{
					ptr2->twinkle = 0.5f;
					ptr2->twinkleSpeed *= -1f;
				}
				ptr2->rotation += ptr2->rotationSpeed;
				if (ptr2->rotation > 6.28f)
				{
					ptr2->rotation -= 6.28f;
				}
				else if (ptr2->rotation < 0f)
				{
					ptr2->rotation += 6.28f;
				}
				num--;
				ptr2++;
			}
		}
	}
}
