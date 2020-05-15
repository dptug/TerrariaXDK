namespace Terraria.CreateCharacter
{
	internal class RandomCharacter
	{
		private enum HairGender
		{
			Male,
			Female,
			Unisex
		}

		private static Vector2i getRandomColor(FastRandom rnd)
		{
			int width = Assets.COLOR_PALETTE.Width;
			int upperBound = Assets.COLOR_PALETTE.Height >> 1;
			int num = Assets.COLOR_PALETTE.Height >> 2;
			return new Vector2i(rnd.Next(width), rnd.Next(upperBound) + num);
		}

		public static Vector2i[] create(FastRandom rnd)
		{
			HairGender[] array = new HairGender[36]
			{
				HairGender.Unisex,
				HairGender.Male,
				HairGender.Male,
				HairGender.Male,
				HairGender.Male,
				HairGender.Female,
				HairGender.Female,
				HairGender.Male,
				HairGender.Male,
				HairGender.Female,
				HairGender.Unisex,
				HairGender.Female,
				HairGender.Unisex,
				HairGender.Unisex,
				HairGender.Male,
				HairGender.Male,
				HairGender.Unisex,
				HairGender.Male,
				HairGender.Unisex,
				HairGender.Male,
				HairGender.Male,
				HairGender.Female,
				HairGender.Female,
				HairGender.Male,
				HairGender.Male,
				HairGender.Female,
				HairGender.Female,
				HairGender.Unisex,
				HairGender.Male,
				HairGender.Female,
				HairGender.Male,
				HairGender.Male,
				HairGender.Female,
				HairGender.Unisex,
				HairGender.Female,
				HairGender.Male
			};
			Vector2i[] array2 = new Vector2i[6]
			{
				new Vector2i(3, 3),
				new Vector2i(3, 3),
				new Vector2i(3, 5),
				new Vector2i(3, 7),
				new Vector2i(0, 8),
				new Vector2i(3, 0)
			};
			Vector2i[] array3 = new Vector2i[6]
			{
				new Vector2i(9, 4),
				new Vector2i(3, 8),
				new Vector2i(9, 7),
				new Vector2i(3, 8),
				new Vector2i(3, 8),
				new Vector2i(2, 4)
			};
			Vector2i[] array4 = new Vector2i[10];
			int num = rnd.Next(36);
			array4[1] = new Vector2i(num % 9, num / 9);
			HairGender hairGender = array[num];
			int num2 = -1;
			switch (hairGender)
			{
			case HairGender.Male:
				num2 = 0;
				break;
			case HairGender.Female:
				num2 = 1;
				break;
			default:
				num2 = rnd.Next(2);
				break;
			}
			array4[0] = new Vector2i(num2, 0);
			int num3 = rnd.Next(array2.Length);
			array4[4] = array2[num3];
			array4[3] = array3[num3];
			array4[2] = getRandomColor(rnd);
			array4[5] = getRandomColor(rnd);
			array4[6] = getRandomColor(rnd);
			array4[7] = getRandomColor(rnd);
			array4[8] = getRandomColor(rnd);
			return array4;
		}
	}
}
