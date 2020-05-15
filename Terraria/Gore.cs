using Microsoft.Xna.Framework;

namespace Terraria
{
	public struct Gore
	{
		public const int MAX_GORE_TYPES = 175;

		public const int MAX_GORE = 128;

		public const int goreTime = 360;

		private static int lastGoreIndex;

		public Vector2 position;

		public Vector2 velocity;

		public float rotation;

		public float scale;

		public float light;

		public byte active;

		public byte type;

		public bool sticky;

		public short alpha;

		public short timeLeft;

		public void Init()
		{
			active = 0;
		}

		public void Update()
		{
			if (type == 11 || type == 12 || type == 13 || type == 61 || type == 62 || type == 63 || type == 99)
			{
				velocity.Y *= 0.98f;
				velocity.X *= 0.98f;
				scale -= 0.007f;
				if (scale < 0.1f)
				{
					active = 0;
					return;
				}
			}
			else if (type == 16 || type == 17)
			{
				velocity.Y *= 0.98f;
				velocity.X *= 0.98f;
				scale -= 0.01f;
				if (scale < 0.1f)
				{
					active = 0;
					return;
				}
			}
			else
			{
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
			if (sticky)
			{
				int num = SpriteSheet<_sheetSprites>.src[256 + type].Width;
				if (SpriteSheet<_sheetSprites>.src[256 + type].Height < num)
				{
					num = SpriteSheet<_sheetSprites>.src[256 + type].Height;
				}
				num = (int)((float)num * scale * 0.9f);
				Collision.TileCollision(ref position, ref velocity, num, num);
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.97f;
					if (velocity.X > -0.01f && velocity.X < 0.01f)
					{
						velocity.X = 0f;
					}
				}
				if (timeLeft > 0)
				{
					timeLeft--;
				}
				else
				{
					alpha++;
				}
			}
			else
			{
				alpha += 2;
			}
			if (alpha >= 255)
			{
				active = 0;
				return;
			}
			position.X += velocity.X;
			position.Y += velocity.Y;
			if (light > 0f)
			{
				float num2 = light * scale;
				Vector3 rgb = new Vector3(num2, num2, num2);
				if (type == 16)
				{
					rgb.Y *= 0.8f;
					rgb.Z *= 0.3f;
				}
				else if (type == 17)
				{
					rgb.X *= 0.3f;
					rgb.Y *= 0.6f;
				}
				Lighting.addLight((int)(position.X + (float)SpriteSheet<_sheetSprites>.src[256 + type].Width * scale * 0.5f) >> 4, (int)(position.Y + (float)SpriteSheet<_sheetSprites>.src[256 + type].Height * scale * 0.5f) >> 4, rgb);
			}
		}

		public unsafe static int NewGore(Vector2 Position, Vector2 Velocity, int Type, double Scale = 1.0)
		{
			int num = lastGoreIndex++ & 0x7F;
			fixed (Gore* ptr = &Main.gore[num])
			{
				ptr->position = Position;
				ptr->velocity = Velocity;
				ptr->velocity.Y -= (float)Main.rand.Next(10, 31) * 0.1f;
				ptr->velocity.X += (float)Main.rand.Next(-20, 21) * 0.1f;
				ptr->type = (byte)Type;
				ptr->active = 1;
				ptr->rotation = 0f;
				if (Type == 16 || Type == 17)
				{
					ptr->sticky = false;
					ptr->alpha = 100;
					ptr->scale = 0.7f;
					ptr->light = 1f;
					return num;
				}
				if ((Type >= 11 && Type <= 13) || (Type >= 61 && Type <= 63) || Type == 99)
				{
					ptr->sticky = false;
				}
				else
				{
					ptr->sticky = true;
					ptr->timeLeft = 360;
				}
				ptr->scale = (float)Scale;
				ptr->alpha = 0;
				ptr->light = 0f;
			}
			return num;
		}

		public unsafe static int NewGore(int X, int Y, Vector2 Velocity, int Type)
		{
			int num = lastGoreIndex++ & 0x7F;
			fixed (Gore* ptr = &Main.gore[num])
			{
				ptr->position.X = X;
				ptr->position.Y = Y;
				ptr->velocity = Velocity;
				ptr->velocity.Y -= (float)Main.rand.Next(10, 31) * 0.1f;
				ptr->velocity.X += (float)Main.rand.Next(-20, 21) * 0.1f;
				ptr->type = (byte)Type;
				ptr->active = 1;
				ptr->rotation = 0f;
				if (Type == 16 || Type == 17)
				{
					ptr->sticky = false;
					ptr->alpha = 100;
					ptr->scale = 0.7f;
					ptr->light = 1f;
					return num;
				}
				if ((Type >= 11 && Type <= 13) || (Type >= 61 && Type <= 63) || Type == 99)
				{
					ptr->sticky = false;
				}
				else
				{
					ptr->sticky = true;
					ptr->timeLeft = 360;
				}
				ptr->scale = 1f;
				ptr->alpha = 0;
				ptr->light = 0f;
			}
			return num;
		}

		public Color GetAlpha(Color newColor)
		{
			int r;
			int g;
			int b;
			if (type == 16 || type == 17)
			{
				r = newColor.R;
				g = newColor.G;
				b = newColor.B;
			}
			else
			{
				double num = (255.0 - (double)alpha) * 0.00392156862745098;
				r = (int)((double)(int)newColor.R * num);
				g = (int)((double)(int)newColor.G * num);
				b = (int)((double)(int)newColor.B * num);
			}
			int a = newColor.A - alpha;
			return new Color(r, g, b, a);
		}
	}
}
