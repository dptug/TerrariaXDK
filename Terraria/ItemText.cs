using Microsoft.Xna.Framework;

namespace Terraria
{
	public struct ItemText
	{
		public const int ACTIVE_TIME = 56;

		public byte active;

		public short lifeTime;

		public short netID;

		public Vector2 position;

		public float velocityY;

		public float alpha;

		public float alphaDir;

		public float scale;

		public Color color;

		public int stack;

		public string text;

		public Vector2 textSize;

		public void Init()
		{
			active = 0;
		}

		public void Update(int whoAmI, ItemTextPool pool)
		{
			alpha += alphaDir;
			if (alpha <= 0.7f)
			{
				alpha = 0.7f;
				alphaDir = 0f - alphaDir;
			}
			else if (alpha >= 1f)
			{
				alpha = 1f;
				alphaDir = 0f - alphaDir;
			}
			bool flag = false;
			Vector2 vector = textSize;
			vector *= scale;
			vector.Y *= 0.8f;
			Rectangle rectangle = default(Rectangle);
			Rectangle value = default(Rectangle);
			rectangle.X = (int)(position.X - vector.X * 0.5f);
			rectangle.Y = (int)(position.Y - vector.Y * 0.5f);
			rectangle.Width = (int)vector.X;
			rectangle.Height = (int)vector.Y;
			for (int i = 0; i < 4; i++)
			{
				if (pool.itemText[i].active == 0 || i == whoAmI)
				{
					continue;
				}
				Vector2 vector2 = pool.itemText[i].textSize;
				vector2 *= pool.itemText[i].scale;
				vector2.Y *= 0.8f;
				value.X = (int)(pool.itemText[i].position.X - vector2.X * 0.5f);
				value.Y = (int)(pool.itemText[i].position.Y - vector2.Y * 0.5f);
				value.Width = (int)vector2.X;
				value.Height = (int)vector2.Y;
				if (rectangle.Intersects(value) && (position.Y < pool.itemText[i].position.Y || (position.Y == pool.itemText[i].position.Y && whoAmI < i)))
				{
					flag = true;
					int num = pool.numActive;
					if (num > 3)
					{
						num = 3;
					}
					pool.itemText[i].lifeTime = (lifeTime = (short)(56 + num * 14));
				}
			}
			if (!flag)
			{
				velocityY *= 0.86f;
				if (scale == 1f)
				{
					velocityY *= 0.4f;
				}
			}
			else if (velocityY > -6f)
			{
				velocityY -= 0.2f;
			}
			else
			{
				velocityY *= 0.86f;
			}
			position.Y += velocityY;
			if (--lifeTime <= 0)
			{
				scale -= 0.03f;
				if (scale < 0.1f)
				{
					active = 0;
				}
				lifeTime = 0;
				return;
			}
			if (scale < 1f)
			{
				scale += 0.1f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
		}
	}
}
