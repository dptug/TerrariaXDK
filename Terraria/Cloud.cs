using Microsoft.Xna.Framework;

namespace Terraria
{
	public struct Cloud
	{
		public const int MAX_CLOUDS = 20;

		public const int MAX_CLOUD_TYPES = 4;

		public static Cloud[] cloud = new Cloud[20];

		public static int numClouds = 20;

		public static float windSpeed = 0f;

		public static float windSpeedSpeed = 0f;

		public static bool resetClouds = true;

		public Vector2 position;

		public float scale;

		public bool active;

		public byte type;

		public ushort width;

		public ushort height;

		public static void Initialize()
		{
			for (int i = 0; i < 20; i++)
			{
				cloud[i].Init();
			}
		}

		public void Init()
		{
			active = false;
			type = 0;
			width = 0;
			height = 0;
		}

		public unsafe static void addCloud()
		{
			fixed (Cloud* ptr = cloud)
			{
				Cloud* ptr2 = ptr;
				for (int num = 19; num >= 0; num--)
				{
					if (!ptr2->active)
					{
						ptr2->type = (byte)Main.rand.Next(4);
						int num2 = ptr2->type + 8;
						ptr2->scale = (float)Main.rand.Next(50, 131) * 0.01f;
						ptr2->width = (ushort)((float)SpriteSheet<_sheetTiles>.src[num2].Width * ptr2->scale);
						ptr2->height = (ushort)((float)SpriteSheet<_sheetTiles>.src[num2].Height * ptr2->scale);
						float num3 = windSpeed;
						if (num3 > 0f)
						{
							ptr2->position.X = -ptr2->width;
						}
						else
						{
							ptr2->position.X = 960f;
						}
						ptr2->position.Y = Main.rand.Next(-135, 135) - Main.rand.Next(180);
						ptr2->active = true;
						break;
					}
					ptr2++;
				}
			}
		}

		public Color cloudColor(Color bgColor)
		{
			float num = (scale - 0.4f) * 0.9f;
			float num2 = 255f - (float)(255 - bgColor.R) * 1.1f;
			float num3 = 255f - (float)(255 - bgColor.G) * 1.1f;
			float num4 = 255f - (float)(255 - bgColor.B) * 1.1f;
			float num5 = 255f;
			num2 *= num;
			num3 *= num;
			num4 *= num;
			num5 *= num;
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			if (num4 < 0f)
			{
				num4 = 0f;
			}
			if (num5 < 0f)
			{
				num5 = 0f;
			}
			return new Color((byte)num2, (byte)num3, (byte)num4, (byte)num5);
		}

		public unsafe static void UpdateClouds()
		{
			if (resetClouds)
			{
				resetClouds = false;
				numClouds = Main.rand.Next(10, 20);
				do
				{
					windSpeed = (float)Main.rand.Next(-100, 101) * 0.01f;
				}
				while (windSpeed == 0f);
				for (int i = 0; i < 20; i++)
				{
					cloud[i].active = false;
				}
				for (int j = 0; j < numClouds; j++)
				{
					addCloud();
				}
				for (int k = 0; k < numClouds; k++)
				{
					int num = Main.rand.Next(960);
					if (cloud[k].position.X < 0f)
					{
						cloud[k].position.X += num;
					}
					else
					{
						cloud[k].position.X -= num;
					}
				}
			}
			windSpeedSpeed += (float)Main.rand.Next(-20, 21) * 0.0001f;
			if ((double)windSpeedSpeed < -0.002)
			{
				windSpeedSpeed = -0.002f;
			}
			else if ((double)windSpeedSpeed > 0.002)
			{
				windSpeedSpeed = 0.002f;
			}
			windSpeed += windSpeedSpeed;
			if ((double)windSpeed < -0.4)
			{
				windSpeed = -0.4f;
			}
			else if ((double)windSpeed > 0.4)
			{
				windSpeed = 0.4f;
			}
			numClouds += Main.rand.Next(-1, 2);
			if (numClouds < 0)
			{
				numClouds = 0;
			}
			else if (numClouds > 20)
			{
				numClouds = 20;
			}
			int num2 = 0;
			for (int l = 0; l < 20; l++)
			{
				fixed (Cloud* ptr = &cloud[l])
				{
					if (ptr->active)
					{
						ptr->Update();
						num2++;
					}
				}
			}
			if (num2 < numClouds)
			{
				addCloud();
			}
		}

		public void Update()
		{
			position.X += windSpeed * scale * 2f;
			if (windSpeed > 0f)
			{
				if (position.X > 960f)
				{
					active = false;
				}
			}
			else if (position.X < (float)(-width))
			{
				active = false;
			}
		}
	}
}
