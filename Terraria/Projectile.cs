using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using System;

namespace Terraria
{
	public struct Projectile
	{
		private struct PetAnim
		{
			private byte startFrame;

			private byte endFrame;

			private byte frameDelay;

			public PetAnim(int s, int e, int d)
			{
				startFrame = (byte)s;
				endFrame = (byte)e;
				frameDelay = (byte)d;
			}

			public void Update(ref Projectile p)
			{
				if (p.frame < startFrame || p.frame > endFrame)
				{
					p.frame = startFrame;
					p.frameCounter = 0;
				}
				else if (++p.frameCounter >= frameDelay)
				{
					p.frameCounter = 0;
					if (++p.frame > endFrame)
					{
						p.frame = startFrame;
					}
				}
			}
		}

		public const int MAX_PROJECTILE_TYPES = 120;

		public const int MAX_PROJECTILES = 512;

		public const int NUM_OLD_POS = 10;

		public const uint TOMBSTONE_TEXT_QUEUE = 8u;

		private static byte[] projFrameH = new byte[120];

		public static readonly byte[] petProj = new byte[6]
		{
			111,
			115,
			116,
			117,
			118,
			119
		};

		private static readonly PetAnim[] petAnimIdle = new PetAnim[6]
		{
			new PetAnim(0, 0, 255),
			new PetAnim(0, 1, 24),
			new PetAnim(0, 2, 2),
			new PetAnim(0, 4, 4),
			new PetAnim(0, 0, 255),
			new PetAnim(0, 0, 255)
		};

		private static readonly PetAnim[] petAnimMove = new PetAnim[6]
		{
			new PetAnim(0, 6, 6),
			new PetAnim(0, 1, 14),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(2, 15, 4),
			new PetAnim(0, 2, 14)
		};

		private static readonly PetAnim[] petAnimFall = new PetAnim[6]
		{
			new PetAnim(4, 4, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(1, 1, 255),
			new PetAnim(2, 2, 255)
		};

		private static readonly PetAnim[] petAnimJump = new PetAnim[6]
		{
			new PetAnim(6, 6, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(1, 1, 255),
			new PetAnim(2, 2, 255)
		};

		private static readonly PetAnim[] petAnimFly = new PetAnim[6]
		{
			new PetAnim(7, 7, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(8, 8, 255),
			new PetAnim(1, 1, 255)
		};

		public static readonly short[] petItem = new short[6]
		{
			603,
			621,
			622,
			623,
			624,
			625
		};

		private static uint lastProjectileIndex = 0u;

		public static uint tombstoneTextIndex = 0u;

		public static string[] tombstoneText = new string[8];

		public byte active;

		public byte type;

		public bool wet;

		public bool lavaWet;

		public bool hostile;

		public bool friendly;

		public bool tileCollide;

		public bool ignoreWater;

		public bool hide;

		public bool ownerHitCheck;

		public bool melee;

		public bool ranged;

		public bool magic;

		public byte maxUpdates;

		public sbyte numUpdates;

		public byte wetCount;

		public byte alpha;

		public byte aiStyle;

		public sbyte direction;

		public sbyte spriteDirection;

		public sbyte penetrate;

		public byte owner;

		public ushort width;

		public ushort height;

		public short whoAmI;

		public Rectangle aabb;

		public float knockBack;

		public float light;

		public Vector2 position;

		public Vector2 lastPosition;

		public Vector2 velocity;

		public float scale;

		public float rotation;

		public float ai0;

		public int ai1;

		public int timeLeft;

		public short soundDelay;

		public short damage;

		public ushort identity;

		public bool netUpdate;

		private sbyte localAI0;

		public byte tombstoneTextId;

		public byte frameCounter;

		public byte frame;

		public unsafe fixed sbyte playerImmune[8];

		public unsafe fixed float oldPos[20];

		public static void Initialize()
		{
			for (int i = 1; i < 120; i++)
			{
				projFrameH[i] = 0;
			}
			projFrameH[72] = (byte)(SpriteSheet<_sheetSprites>.src[1421].Height / 4);
			projFrameH[86] = (byte)(SpriteSheet<_sheetSprites>.src[1435].Height / 4);
			projFrameH[87] = (byte)(SpriteSheet<_sheetSprites>.src[1436].Height / 4);
			projFrameH[102] = (byte)(SpriteSheet<_sheetSprites>.src[1451].Height / 2);
			projFrameH[111] = (byte)(SpriteSheet<_sheetSprites>.src[1460].Height / 8);
			projFrameH[115] = (byte)(SpriteSheet<_sheetSprites>.src[1464].Height / 2);
			projFrameH[116] = (byte)(SpriteSheet<_sheetSprites>.src[1465].Height / 3);
			projFrameH[117] = (byte)(SpriteSheet<_sheetSprites>.src[1466].Height / 5);
			projFrameH[118] = (byte)(SpriteSheet<_sheetSprites>.src[1467].Height / 16);
			projFrameH[119] = (byte)(SpriteSheet<_sheetSprites>.src[1468].Height / 3);
		}

		public void Init()
		{
			active = 0;
			type = 0;
			direction = (spriteDirection = 1);
		}

		public bool isLocal()
		{
			if (owner != 8 || Main.netMode == 1)
			{
				return Main.player[owner].isLocal();
			}
			return true;
		}

		public unsafe void SetDefaults(int Type)
		{
			ai0 = 0f;
			ai1 = 0;
			localAI0 = 0;
			fixed (sbyte* ptr = playerImmune)
			{
				for (int i = 0; i < 8; i++)
				{
					ptr[i] = 0;
				}
			}
			soundDelay = 0;
			spriteDirection = 1;
			melee = false;
			ranged = false;
			magic = false;
			ownerHitCheck = false;
			hide = false;
			lavaWet = false;
			wetCount = 0;
			wet = false;
			ignoreWater = false;
			hostile = false;
			netUpdate = false;
			numUpdates = 0;
			maxUpdates = 0;
			identity = 0;
			light = 0f;
			penetrate = 1;
			tileCollide = true;
			position = default(Vector2);
			velocity = default(Vector2);
			aiStyle = 0;
			alpha = 0;
			type = (byte)Type;
			active = 1;
			rotation = 0f;
			scale = 1f;
			owner = 8;
			timeLeft = 3600;
			friendly = true;
			damage = 0;
			knockBack = 0f;
			if (type == 1)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				ranged = true;
			}
			else if (type == 2)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				light = 1f;
				ranged = true;
			}
			else if (type == 3)
			{
				width = 22;
				height = 22;
				aiStyle = 2;
				penetrate = 4;
				ranged = true;
			}
			else if (type == 4)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				light = 0.35f;
				penetrate = 5;
				ranged = true;
			}
			else if (type == 5)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				light = 0.4f;
				penetrate = -1;
				timeLeft = 40;
				alpha = 100;
				ignoreWater = true;
				ranged = true;
			}
			else if (type == 6)
			{
				width = 22;
				height = 22;
				aiStyle = 3;
				penetrate = -1;
				melee = true;
				light = 0.4f;
			}
			else if (type == 7 || type == 8)
			{
				width = 28;
				height = 28;
				aiStyle = 4;
				penetrate = -1;
				tileCollide = false;
				alpha = byte.MaxValue;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 9)
			{
				width = 24;
				height = 24;
				aiStyle = 5;
				penetrate = 2;
				alpha = 50;
				scale = 0.8f;
				tileCollide = false;
				magic = true;
			}
			else if (type == 10)
			{
				width = 64;
				height = 64;
				aiStyle = 6;
				tileCollide = false;
				penetrate = -1;
				alpha = byte.MaxValue;
				ignoreWater = true;
			}
			else if (type == 11)
			{
				width = 48;
				height = 48;
				aiStyle = 6;
				tileCollide = false;
				penetrate = -1;
				alpha = byte.MaxValue;
				ignoreWater = true;
			}
			else if (type == 12)
			{
				width = 16;
				height = 16;
				aiStyle = 5;
				penetrate = -1;
				alpha = 50;
				light = 1f;
			}
			else if (type == 13)
			{
				width = 18;
				height = 18;
				aiStyle = 7;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 14)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				penetrate = 1;
				light = 0.5f;
				alpha = byte.MaxValue;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 15)
			{
				width = 16;
				height = 16;
				aiStyle = 8;
				light = 0.8f;
				alpha = 100;
				magic = true;
			}
			else if (type == 16)
			{
				width = 10;
				height = 10;
				aiStyle = 9;
				light = 0.8f;
				alpha = 100;
				magic = true;
			}
			else if (type == 17)
			{
				width = 10;
				height = 10;
				aiStyle = 10;
			}
			else if (type == 18)
			{
				width = 32;
				height = 32;
				aiStyle = 11;
				light = 0.45f;
				alpha = 150;
				tileCollide = false;
				penetrate = -1;
				timeLeft = 18000;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 19)
			{
				width = 22;
				height = 22;
				aiStyle = 3;
				penetrate = -1;
				light = 1f;
				melee = true;
			}
			else if (type == 20)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				penetrate = 3;
				light = 0.75f;
				alpha = byte.MaxValue;
				maxUpdates = 2;
				scale = 1.4f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 21)
			{
				width = 16;
				height = 16;
				aiStyle = 2;
				scale = 1.2f;
				ranged = true;
			}
			else if (type == 22)
			{
				width = 18;
				height = 18;
				aiStyle = 12;
				alpha = byte.MaxValue;
				penetrate = -1;
				maxUpdates = 2;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 23)
			{
				width = 4;
				height = 4;
				aiStyle = 13;
				penetrate = -1;
				alpha = byte.MaxValue;
				ranged = true;
			}
			else if (type == 24)
			{
				width = 14;
				height = 14;
				aiStyle = 14;
				penetrate = 6;
				ranged = true;
			}
			else if (type == 25)
			{
				width = 22;
				height = 22;
				aiStyle = 15;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 26)
			{
				width = 22;
				height = 22;
				aiStyle = 15;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 27)
			{
				width = 16;
				height = 16;
				aiStyle = 8;
				light = 0.8f;
				alpha = 200;
				timeLeft = 1800;
				penetrate = 10;
				magic = true;
			}
			else if (type == 28)
			{
				width = 22;
				height = 22;
				aiStyle = 16;
				penetrate = -1;
			}
			else if (type == 29)
			{
				width = 10;
				height = 10;
				aiStyle = 16;
				penetrate = -1;
			}
			else if (type == 30)
			{
				width = 14;
				height = 14;
				aiStyle = 16;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 31)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 32)
			{
				width = 18;
				height = 18;
				aiStyle = 7;
				penetrate = -1;
				tileCollide = false;
				timeLeft = 36000;
			}
			else if (type == 33)
			{
				width = 28;
				height = 28;
				aiStyle = 3;
				scale = 0.9f;
				penetrate = -1;
				melee = true;
			}
			else if (type == 34)
			{
				width = 14;
				height = 14;
				aiStyle = 9;
				light = 0.8f;
				alpha = 100;
				penetrate = 1;
				magic = true;
			}
			else if (type == 35)
			{
				width = 22;
				height = 22;
				aiStyle = 15;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 36)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				penetrate = 2;
				light = 0.6f;
				alpha = byte.MaxValue;
				maxUpdates = 1;
				scale = 1.4f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 37)
			{
				width = 22;
				height = 22;
				aiStyle = 16;
				penetrate = -1;
				tileCollide = false;
			}
			else if (type == 38)
			{
				width = 14;
				height = 14;
				aiStyle = 0;
				hostile = true;
				penetrate = -1;
				aiStyle = 1;
				tileCollide = true;
				friendly = false;
			}
			else if (type == 39)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 40)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 41)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				penetrate = -1;
				ranged = true;
				light = 0.3f;
			}
			else if (type == 114)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				penetrate = -1;
				ranged = true;
				light = 0.4f;
			}
			else if (type == 42)
			{
				knockBack = 8f;
				width = 10;
				height = 10;
				aiStyle = 10;
				maxUpdates = 1;
			}
			else if (type == 43)
			{
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
				friendly = false;
			}
			else if (type == 44)
			{
				width = 48;
				height = 48;
				alpha = 100;
				light = 0.2f;
				aiStyle = 18;
				hostile = true;
				penetrate = -1;
				tileCollide = true;
				scale = 0.9f;
				friendly = false;
			}
			else if (type == 45)
			{
				width = 48;
				height = 48;
				alpha = 100;
				light = 0.2f;
				aiStyle = 18;
				penetrate = 5;
				tileCollide = true;
				scale = 0.9f;
				magic = true;
			}
			else if (type == 46)
			{
				width = 20;
				height = 20;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 47)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 48)
			{
				width = 12;
				height = 12;
				aiStyle = 2;
				penetrate = 2;
				ranged = true;
			}
			else if (type == 49)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.2f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 50)
			{
				width = 6;
				height = 6;
				aiStyle = 14;
				penetrate = -1;
				alpha = 75;
				light = 1f;
				timeLeft = 18000;
				friendly = false;
			}
			else if (type == 51)
			{
				width = 8;
				height = 8;
				aiStyle = 1;
			}
			else if (type == 52)
			{
				width = 22;
				height = 22;
				aiStyle = 3;
				penetrate = -1;
				melee = true;
			}
			else if (type == 53)
			{
				width = 6;
				height = 6;
				aiStyle = 14;
				penetrate = -1;
				alpha = 75;
				light = 1f;
				timeLeft = 18000;
				tileCollide = false;
				friendly = false;
			}
			else if (type == 54)
			{
				width = 12;
				height = 12;
				aiStyle = 2;
				penetrate = 2;
				ranged = true;
			}
			else if (type == 55)
			{
				width = 10;
				height = 10;
				aiStyle = 0;
				hostile = true;
				friendly = false;
				penetrate = -1;
				aiStyle = 1;
				tileCollide = true;
			}
			else if (type == 56)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 57)
			{
				width = 18;
				height = 18;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 58)
			{
				width = 18;
				height = 18;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.08f;
			}
			else if (type == 59)
			{
				width = 22;
				height = 22;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 60)
			{
				width = 22;
				height = 22;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 61)
			{
				width = 18;
				height = 18;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.16f;
			}
			else if (type == 62)
			{
				width = 22;
				height = 22;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 63)
			{
				width = 22;
				height = 22;
				aiStyle = 15;
				penetrate = -1;
				melee = true;
			}
			else if (type == 64)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.25f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 65)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				penetrate = -1;
				maxUpdates = 1;
			}
			else if (type == 66)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.27f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 67)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 68)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				penetrate = -1;
				maxUpdates = 1;
			}
			else if (type == 69)
			{
				width = 14;
				height = 14;
				aiStyle = 2;
				penetrate = 1;
			}
			else if (type == 70)
			{
				width = 14;
				height = 14;
				aiStyle = 2;
				penetrate = 1;
			}
			else if (type == 71)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 72)
			{
				width = 18;
				height = 18;
				aiStyle = 27;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft = 18000;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 73 || type == 74)
			{
				width = 18;
				height = 18;
				aiStyle = 7;
				penetrate = -1;
				tileCollide = false;
				timeLeft = 36000;
				light = 0.4f;
			}
			else if (type == 75)
			{
				width = 22;
				height = 22;
				aiStyle = 16;
				hostile = true;
				friendly = false;
				penetrate = -1;
			}
			else if (type == 76 || type == 77 || type == 78)
			{
				if (type == 76)
				{
					width = 10;
					height = 22;
				}
				else if (type == 77)
				{
					width = 18;
					height = 24;
				}
				else
				{
					width = 22;
					height = 24;
				}
				aiStyle = 21;
				ranged = true;
				alpha = 100;
				light = 0.3f;
				penetrate = -1;
				timeLeft = 180;
			}
			else if (type == 79)
			{
				width = 10;
				height = 10;
				aiStyle = 9;
				light = 0.8f;
				alpha = byte.MaxValue;
				magic = true;
			}
			else if (type == 80)
			{
				width = 16;
				height = 16;
				aiStyle = 22;
				magic = true;
				tileCollide = false;
				light = 0.5f;
			}
			else if (type == 81)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				ranged = true;
			}
			else if (type == 82)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				ranged = true;
			}
			else if (type == 83)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				penetrate = 3;
				light = 0.75f;
				alpha = byte.MaxValue;
				maxUpdates = 2;
				scale = 1.7f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 84)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				penetrate = 3;
				light = 0.75f;
				alpha = byte.MaxValue;
				maxUpdates = 2;
				scale = 1.2f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 85)
			{
				width = 6;
				height = 6;
				aiStyle = 23;
				alpha = byte.MaxValue;
				penetrate = 3;
				maxUpdates = 2;
				magic = true;
			}
			else if (type == 86)
			{
				width = 18;
				height = 18;
				aiStyle = 27;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft = 18000;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 87)
			{
				width = 18;
				height = 18;
				aiStyle = 27;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft = 18000;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 88)
			{
				width = 6;
				height = 6;
				aiStyle = 1;
				penetrate = 3;
				light = 0.75f;
				alpha = byte.MaxValue;
				maxUpdates = 4;
				scale = 1.4f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 89)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				penetrate = 1;
				light = 0.5f;
				alpha = byte.MaxValue;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 90)
			{
				width = 6;
				height = 6;
				aiStyle = 24;
				penetrate = 1;
				light = 0.5f;
				alpha = 50;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
				tileCollide = false;
			}
			else if (type == 91)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				ranged = true;
			}
			else if (type == 92)
			{
				width = 24;
				height = 24;
				aiStyle = 5;
				penetrate = 2;
				alpha = 50;
				scale = 0.8f;
				tileCollide = false;
				magic = true;
			}
			else if (type == 93)
			{
				light = 0.15f;
				width = 12;
				height = 12;
				aiStyle = 2;
				penetrate = 2;
				magic = true;
			}
			else if (type == 94)
			{
				ignoreWater = true;
				width = 8;
				height = 8;
				aiStyle = 24;
				light = 0.5f;
				alpha = 50;
				scale = 1.2f;
				timeLeft = 600;
				magic = true;
				tileCollide = true;
				penetrate = 1;
				fixed (float* ptr2 = oldPos)
				{
					for (int num = 19; num >= 0; num--)
					{
						ptr2[num] = 0f;
					}
				}
			}
			else if (type == 95)
			{
				width = 16;
				height = 16;
				aiStyle = 8;
				light = 0.8f;
				alpha = 100;
				magic = true;
				penetrate = 2;
			}
			else if (type == 96)
			{
				width = 16;
				height = 16;
				aiStyle = 8;
				hostile = true;
				friendly = false;
				light = 0.8f;
				alpha = 100;
				magic = true;
				penetrate = -1;
				scale = 0.9f;
				scale = 1.3f;
			}
			else if (type == 97)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 98)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				hostile = true;
				ranged = true;
				penetrate = -1;
			}
			else if (type == 99)
			{
				width = 31;
				height = 31;
				aiStyle = 25;
				hostile = true;
				ranged = true;
				penetrate = -1;
			}
			else if (type == 100)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				penetrate = 3;
				light = 0.75f;
				alpha = byte.MaxValue;
				maxUpdates = 2;
				scale = 1.8f;
				timeLeft = 1200;
				magic = true;
			}
			else if (type == 101)
			{
				width = 6;
				height = 6;
				aiStyle = 23;
				hostile = true;
				friendly = false;
				alpha = byte.MaxValue;
				penetrate = -1;
				maxUpdates = 3;
				magic = true;
			}
			else if (type == 102)
			{
				width = 22;
				height = 22;
				aiStyle = 16;
				hostile = true;
				friendly = false;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 103)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				light = 1f;
				ranged = true;
			}
			else if (type == 113)
			{
				width = 10;
				height = 10;
				aiStyle = 1;
				light = 1f;
				ranged = true;
			}
			else if (type == 104)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				penetrate = 1;
				light = 0.5f;
				alpha = byte.MaxValue;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 105)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.3f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 112)
			{
				width = 18;
				height = 18;
				aiStyle = 19;
				penetrate = -1;
				tileCollide = false;
				scale = 1.3f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 106)
			{
				width = 32;
				height = 32;
				aiStyle = 3;
				penetrate = -1;
				melee = true;
				light = 0.4f;
			}
			else if (type == 107)
			{
				width = 22;
				height = 22;
				aiStyle = 20;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.1f;
			}
			else if (type == 108)
			{
				width = 260;
				height = 260;
				aiStyle = 16;
				hostile = true;
				penetrate = -1;
				tileCollide = false;
				alpha = byte.MaxValue;
				timeLeft = 2;
			}
			else if (type == 109)
			{
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				friendly = false;
				scale = 0.9f;
				penetrate = -1;
			}
			else if (type == 110)
			{
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				friendly = false;
				penetrate = -1;
				light = 0.5f;
				alpha = byte.MaxValue;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 111)
			{
				width = 18;
				height = 18;
				aiStyle = 26;
				penetrate = -1;
				timeLeft = 18000;
			}
			else if (type == 115)
			{
				width = 18;
				height = 10;
				aiStyle = 26;
				penetrate = -1;
				timeLeft = 18000;
				localAI0 = 1;
			}
			else if (type == 116)
			{
				width = 12;
				height = 72;
				scale = 0.5f;
				aiStyle = 28;
				penetrate = -1;
				timeLeft = 18000;
				damage = 2;
				localAI0 = 2;
			}
			else if (type == 117)
			{
				width = 16;
				height = 48;
				aiStyle = 28;
				penetrate = -1;
				timeLeft = 18000;
				damage = 4;
				localAI0 = 3;
			}
			else if (type == 118)
			{
				width = 18;
				height = 26;
				aiStyle = 26;
				penetrate = -1;
				timeLeft = 18000;
				damage = 10;
				localAI0 = 4;
			}
			else if (type == 119)
			{
				width = 18;
				height = 24;
				aiStyle = 26;
				penetrate = -1;
				timeLeft = 18000;
				damage = 8;
				localAI0 = 5;
			}
			else
			{
				active = 0;
			}
			width = (ushort)((float)(int)width * scale);
			height = (ushort)((float)(int)height * scale);
			aabb.Width = width;
			aabb.Height = height;
		}

		public unsafe static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 8, bool send = true)
		{
			for (int i = 0; i < 512; i++)
			{
				uint num = lastProjectileIndex++ & 0x1FF;
				fixed (Projectile* ptr = &Main.projectile[num])
				{
					if (ptr->active == 0)
					{
						ptr->SetDefaults(Type);
						ptr->position.X = X - (float)(ptr->width >> 1);
						ptr->position.Y = Y - (float)(ptr->height >> 1);
						ptr->aabb.X = (int)ptr->position.X;
						ptr->aabb.Y = (int)ptr->position.Y;
						ptr->owner = (byte)Owner;
						ptr->velocity.X = SpeedX;
						ptr->velocity.Y = SpeedY;
						if (Damage != 0)
						{
							ptr->damage = (short)Damage;
						}
						ptr->knockBack = KnockBack;
						ptr->identity = (ushort)i;
						ptr->wet = Collision.WetCollision(ref ptr->position, ptr->width, ptr->height);
						if (ptr->isLocal())
						{
							switch (Type)
							{
							case 29:
								ptr->timeLeft = 300;
								break;
							case 28:
							case 30:
							case 37:
							case 75:
								ptr->timeLeft = 180;
								break;
							}
							if (send)
							{
								NetMessage.SendProjectile((int)num);
							}
						}
						return (int)num;
					}
				}
			}
			return -1;
		}

		public unsafe int NewClonedProjectile(int newType)
		{
			for (int i = 0; i < 512; i++)
			{
				uint num = lastProjectileIndex++ & 0x1FF;
				fixed (Projectile* ptr = &Main.projectile[num])
				{
					if (ptr->active == 0)
					{
						ptr->SetDefaults(newType);
						ptr->position = position;
						ptr->aabb.X = (int)position.X;
						ptr->aabb.Y = (int)position.Y;
						ptr->owner = owner;
						ptr->velocity = velocity;
						ptr->damage = damage;
						ptr->knockBack = knockBack;
						ptr->identity = (ushort)i;
						ptr->wet = wet;
						if (ptr->isLocal())
						{
							switch (newType)
							{
							case 29:
								ptr->timeLeft = 300;
								break;
							case 28:
							case 30:
							case 37:
							case 75:
								ptr->timeLeft = 180;
								break;
							}
						}
						return (int)num;
					}
				}
			}
			return -1;
		}

		public unsafe void Damage()
		{
			if (type == 18 || type == 72 || type == 86 || type == 87 || type == 111 || type == 115)
			{
				return;
			}
			Rectangle rectangle = aabb;
			if (type == 85 || type == 101)
			{
				rectangle.X -= 30;
				rectangle.Y -= 30;
				rectangle.Width += 60;
				rectangle.Height += 60;
			}
			if (friendly && isLocal())
			{
				if ((aiStyle == 16 || type == 41 || type == 114) && (timeLeft <= 1 || type == 108))
				{
					Player player = Main.player[owner];
					if (player.active != 0 && !player.dead && !player.immune && rectangle.Intersects(player.aabb))
					{
						if (player.aabb.X + 10 < aabb.X + (width >> 1))
						{
							direction = -1;
						}
						else
						{
							direction = 1;
						}
						int dmg = Main.DamageVar(damage);
						player.ApplyProjectileBuff(type);
						player.Hurt(dmg, direction, pvp: true, quiet: false, Lang.deathMsg(owner, 0, type));
						NetMessage.SendPlayerHurt(player.whoAmI, direction, dmg, pvp: true, critical: false, Lang.deathMsg(owner, 0, type));
					}
				}
				if (type < 116 && type != 69 && type != 70 && type != 10 && type != 11)
				{
					int num = aabb.X >> 4;
					int num2 = (aabb.X + width >> 4) + 1;
					int num3 = aabb.Y >> 4;
					int num4 = (aabb.Y + height >> 4) + 1;
					if (num < 0)
					{
						num = 0;
					}
					if (num2 > Main.maxTilesX)
					{
						num2 = Main.maxTilesX;
					}
					if (num3 < 0)
					{
						num3 = 0;
					}
					if (num4 > Main.maxTilesY)
					{
						num4 = Main.maxTilesY;
					}
					for (int i = num; i < num2; i++)
					{
						for (int j = num3; j < num4; j++)
						{
							if (Main.tileCut[Main.tile[i, j].type] && Main.tile[i, j + 1].type != 78)
							{
								WorldGen.KillTile(i, j);
								NetMessage.CreateMessage5(17, 0, i, j, 0);
								NetMessage.SendMessage();
							}
						}
					}
				}
			}
			if (isLocal())
			{
				Player player2 = Main.player[owner];
				if (damage > 0)
				{
					for (int k = 0; k < 196; k++)
					{
						NPC nPC = Main.npc[k];
						if (nPC.active == 0 || nPC.dontTakeDamage || ((!friendly || (nPC.friendly && (nPC.type != 22 || !player2.killGuide))) && (!nPC.friendly || !hostile)) || nPC.immune[owner] != 0 || (type == 11 && (nPC.type == 47 || nPC.type == 57)) || (type == 31 && nPC.type == 69) || (!nPC.noTileCollide && ownerHitCheck && !Collision.CanHit(ref player2.aabb, ref nPC.aabb)) || !rectangle.Intersects(nPC.aabb))
						{
							continue;
						}
						if (aiStyle == 3)
						{
							if (ai0 == 0f)
							{
								velocity.X = 0f - velocity.X;
								velocity.Y = 0f - velocity.Y;
								netUpdate = true;
							}
							ai0 = 1f;
						}
						else if (aiStyle == 16)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (nPC.aabb.X + (nPC.width >> 1) < aabb.X + (width >> 1))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						if ((type == 41 || type == 114) && timeLeft > 1)
						{
							timeLeft = 1;
						}
						bool flag = false;
						if (melee && Main.rand.Next(1, 101) <= player2.meleeCrit)
						{
							flag = true;
						}
						else if (ranged && Main.rand.Next(1, 101) <= player2.rangedCrit)
						{
							flag = true;
						}
						else if (magic && Main.rand.Next(1, 101) <= player2.magicCrit)
						{
							flag = true;
						}
						int dmg2 = Main.DamageVar(damage);
						nPC.ApplyProjectileBuff(type);
						nPC.StrikeNPC(dmg2, knockBack, direction, flag);
						NetMessage.SendNpcHurt(k, dmg2, knockBack, direction, flag);
						if (nPC.active == 0 && player2.ui != null)
						{
							StatisticEntry statisticEntryFromNetID = Statistics.GetStatisticEntryFromNetID(nPC.netID);
							player2.ui.Statistics.incStat(statisticEntryFromNetID);
						}
						if (penetrate != 1)
						{
							nPC.immune[owner] = 10;
						}
						if (penetrate > 0 && --penetrate == 0)
						{
							break;
						}
						if (aiStyle == 7)
						{
							ai0 = 1f;
							damage = 0;
							netUpdate = true;
						}
						else if (aiStyle == 13)
						{
							ai0 = 1f;
							netUpdate = true;
						}
					}
					if (player2.hostile)
					{
						for (int l = 0; l < 8; l++)
						{
							if (l == owner || Main.player[l].active == 0 || Main.player[l].dead || Main.player[l].immune || !Main.player[l].hostile)
							{
								continue;
							}
							reference = ref *playerImmune;
							if ((&reference)[l] > 0)
							{
								continue;
							}
							reference = 0u;
							if ((player2.team != 0 && player2.team == Main.player[l].team) || (ownerHitCheck && !Collision.CanHit(ref player2.aabb, ref Main.player[l].aabb)) || !rectangle.Intersects(Main.player[l].aabb))
							{
								continue;
							}
							if (aiStyle == 3)
							{
								if (ai0 == 0f)
								{
									velocity.X = 0f - velocity.X;
									velocity.Y = 0f - velocity.Y;
									netUpdate = true;
								}
								ai0 = 1f;
							}
							else if (aiStyle == 16)
							{
								if (timeLeft > 3)
								{
									timeLeft = 3;
								}
								if (Main.player[l].aabb.X + 10 < aabb.X + (width >> 1))
								{
									direction = -1;
								}
								else
								{
									direction = 1;
								}
							}
							if ((type == 41 || type == 114) && timeLeft > 1)
							{
								timeLeft = 1;
							}
							bool flag2 = false;
							if (melee && Main.rand.Next(1, 101) <= player2.meleeCrit)
							{
								flag2 = true;
							}
							int dmg3 = Main.DamageVar(damage);
							if (!Main.player[l].immune)
							{
								Main.player[l].ApplyProjectileBuffPvP(type);
							}
							Main.player[l].Hurt(dmg3, direction, pvp: true, quiet: false, Lang.deathMsg(owner, 0, type), flag2);
							NetMessage.SendPlayerHurt(l, direction, dmg3, pvp: true, flag2, Lang.deathMsg(owner, 0, type));
							fixed (sbyte* ptr = playerImmune)
							{
								ptr[l] = 40;
							}
							if (penetrate > 0 && --penetrate == 0)
							{
								break;
							}
							if (aiStyle == 7)
							{
								ai0 = 1f;
								damage = 0;
								netUpdate = true;
							}
							else if (aiStyle == 13)
							{
								ai0 = 1f;
								netUpdate = true;
							}
						}
					}
				}
			}
			if (type == 11 && Main.netMode != 1)
			{
				for (int m = 0; m < 196; m++)
				{
					if (Main.npc[m].active == 0)
					{
						continue;
					}
					if (Main.npc[m].type == 46)
					{
						if (rectangle.Intersects(Main.npc[m].aabb))
						{
							Main.npc[m].Transform(47);
						}
					}
					else if (Main.npc[m].type == 55 && rectangle.Intersects(Main.npc[m].aabb))
					{
						Main.npc[m].Transform(57);
					}
				}
			}
			if (!hostile || damage <= 0)
			{
				return;
			}
			for (int n = 0; n < 8; n++)
			{
				Player player3 = Main.player[n];
				if (!player3.isLocal() || player3.active == 0 || player3.dead || player3.immune)
				{
					continue;
				}
				Rectangle value = new Rectangle((int)player3.position.X, (int)player3.position.Y, 20, 42);
				if (rectangle.Intersects(value))
				{
					int num5 = direction;
					num5 = ((player3.aabb.X + 10 >= aabb.X + (width >> 1)) ? 1 : (-1));
					int num6 = Main.DamageVar(damage);
					if (!player3.immune)
					{
						player3.ApplyProjectileBuff(type);
					}
					player3.Hurt(num6 * 2, num5, pvp: false, quiet: false, Lang.deathMsg(-1, 0, type));
				}
			}
		}

		public unsafe void Update(int i)
		{
			if (aabb.X <= 0 || aabb.X + width >= Main.rightWorld || aabb.Y <= 0 || aabb.Y + height >= Main.bottomWorld)
			{
				active = 0;
				return;
			}
			whoAmI = (short)i;
			while (true)
			{
				if (soundDelay > 0)
				{
					soundDelay--;
				}
				netUpdate = false;
				fixed (sbyte* ptr = playerImmune)
				{
					for (int j = 0; j < 8; j++)
					{
						if (ptr[j] > 0)
						{
							ptr[j]--;
						}
					}
				}
				switch (aiStyle)
				{
				case 1:
					ArrowAI();
					break;
				case 2:
					ShurikenAI();
					break;
				case 3:
					BoomerangAI();
					break;
				case 4:
					VilethornAI();
					break;
				case 5:
					StarfuryAI();
					break;
				case 6:
					PowderAI();
					break;
				case 7:
					GrapplingAI();
					break;
				case 8:
					BallOfFireAI();
					break;
				case 9:
					MagicMissileAI();
					break;
				case 10:
					DirtBallAI();
					break;
				case 11:
					OrbOfLightAI();
					break;
				case 12:
					BlueFlameAI();
					break;
				case 13:
					HarpoonAI();
					break;
				case 14:
					SpikyBallAI();
					break;
				case 15:
					FlailAI();
					break;
				case 16:
					BombAI();
					break;
				case 17:
					TombstoneAI();
					break;
				case 18:
					DemonSickleAI();
					break;
				case 19:
					SpearAI();
					break;
				case 20:
					ChainsawAI();
					break;
				case 21:
					NoteAI();
					break;
				case 22:
					IceBlockAI();
					break;
				case 23:
					FlameAI();
					break;
				case 24:
					CrystalShardAI();
					break;
				case 25:
					BoulderAI();
					break;
				case 26:
					PetAI();
					break;
				case 27:
					FairyAI();
					break;
				case 28:
					FlyingPetAI();
					break;
				}
				if (owner < 8 && Main.player[owner].active == 0)
				{
					Kill();
				}
				if (!ignoreWater)
				{
					bool flag;
					bool flag2;
					try
					{
						flag = Collision.LavaCollision(ref position, width, height);
						flag2 = Collision.WetCollision(ref position, width, height);
						if (flag)
						{
							lavaWet = true;
						}
					}
					catch
					{
						active = 0;
						return;
					}
					if (wet && !lavaWet)
					{
						if (type == 85 || type == 15 || type == 34)
						{
							Kill();
						}
						else if (type == 2 || type == 82)
						{
							type--;
							light = 0f;
						}
					}
					if (type == 80)
					{
						flag2 = false;
						wet = false;
						if (flag && ai0 >= 0f)
						{
							Kill();
						}
					}
					else if (flag2)
					{
						if (wetCount == 0)
						{
							wetCount = 10;
							if (!wet)
							{
								wet = true;
								Main.PlaySound(19, aabb.X, aabb.Y);
								if (!flag)
								{
									for (int k = 0; k < 8; k++)
									{
										Dust* ptr2 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 33);
										if (ptr2 == null)
										{
											break;
										}
										ptr2->velocity.Y -= 4f;
										ptr2->velocity.X *= 2.5f;
										ptr2->scale = 1.3f;
										ptr2->alpha = 100;
										ptr2->noGravity = true;
									}
								}
								else
								{
									for (int l = 0; l < 8; l++)
									{
										Dust* ptr3 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 35);
										if (ptr3 == null)
										{
											break;
										}
										ptr3->velocity.Y -= 1.5f;
										ptr3->velocity.X *= 2.5f;
										ptr3->scale = 1.3f;
										ptr3->alpha = 100;
										ptr3->noGravity = true;
									}
								}
							}
						}
					}
					else if (wet)
					{
						wet = false;
						if (wetCount == 0)
						{
							wetCount = 10;
							Main.PlaySound(19, aabb.X, aabb.Y);
							if (!lavaWet)
							{
								for (int m = 0; m < 8; m++)
								{
									Dust* ptr4 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1), width + 12, 24, 33);
									if (ptr4 == null)
									{
										break;
									}
									ptr4->velocity.Y -= 4f;
									ptr4->velocity.X *= 2.5f;
									ptr4->scale = 1.3f;
									ptr4->alpha = 100;
									ptr4->noGravity = true;
								}
							}
							else
							{
								for (int n = 0; n < 8; n++)
								{
									Dust* ptr5 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 35);
									if (ptr5 == null)
									{
										break;
									}
									ptr5->velocity.Y -= 1.5f;
									ptr5->velocity.X *= 2.5f;
									ptr5->scale = 1.3f;
									ptr5->alpha = 100;
									ptr5->noGravity = true;
								}
							}
						}
					}
					if (!wet)
					{
						lavaWet = false;
					}
					if (wetCount > 0)
					{
						wetCount--;
					}
				}
				lastPosition = position;
				Vector2 vector = velocity;
				if (tileCollide)
				{
					Vector2 value = velocity;
					bool flag3 = type != 9 && type != 12 && type != 15 && type != 13 && type != 31 && type != 39 && type != 40 && aiStyle != 26;
					if (aiStyle == 10)
					{
						if (type == 42 || type == 65 || type == 68 || (type == 31 && ai0 == 2f))
						{
							Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
						}
						else
						{
							Collision.AnyCollision(ref position, ref velocity, width, height);
						}
					}
					else if (aiStyle == 18)
					{
						int num = width - 36;
						int num2 = height - 36;
						Vector2 Position = new Vector2(position.X + (float)(width >> 1) - (float)(num >> 1), position.Y + (float)(height >> 1) - (float)(num2 >> 1));
						Collision.TileCollision(ref Position, ref velocity, num, num2, flag3, flag3);
					}
					else if (wet)
					{
						Vector2 vector2 = velocity;
						Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
						vector = velocity;
						vector.X *= 0.5f;
						vector.Y *= 0.5f;
						if (velocity.X != vector2.X)
						{
							vector.X = velocity.X;
						}
						if (velocity.Y != vector2.Y)
						{
							vector.Y = velocity.Y;
						}
					}
					else
					{
						Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
					}
					if (value != velocity)
					{
						if (type == 94)
						{
							if (velocity.X != value.X)
							{
								velocity.X = 0f - value.X;
							}
							if (velocity.Y != value.Y)
							{
								velocity.Y = 0f - value.Y;
							}
						}
						else if (type == 99)
						{
							if (velocity.Y != value.Y && value.Y > 5f)
							{
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(0, aabb.X, aabb.Y);
								velocity.Y = (0f - value.Y) * 0.2f;
							}
							if (velocity.X != value.X)
							{
								Kill();
							}
						}
						else if (type == 36)
						{
							if (penetrate > 1)
							{
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(2, aabb.X, aabb.Y, 10);
								penetrate--;
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
								if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
							}
							else
							{
								Kill();
							}
						}
						else if (aiStyle == 21)
						{
							if (velocity.X != value.X)
							{
								velocity.X = 0f - value.X;
							}
							if (velocity.Y != value.Y)
							{
								velocity.Y = 0f - value.Y;
							}
						}
						else if (aiStyle == 17)
						{
							if (velocity.X != value.X)
							{
								velocity.X = value.X * -0.75f;
							}
							if (velocity.Y != value.Y && (double)value.Y > 1.5)
							{
								velocity.Y = value.Y * -0.7f;
							}
						}
						else if (aiStyle == 15)
						{
							bool flag4 = false;
							if (value.X != velocity.X)
							{
								if (Math.Abs(value.X) > 4f)
								{
									flag4 = true;
								}
								position.X += velocity.X;
								velocity.X = (0f - value.X) * 0.2f;
							}
							if (value.Y != velocity.Y)
							{
								if (Math.Abs(value.Y) > 4f)
								{
									flag4 = true;
								}
								position.Y += velocity.Y;
								velocity.Y = (0f - value.Y) * 0.2f;
							}
							ai0 = 1f;
							if (flag4)
							{
								netUpdate = true;
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(0, aabb.X, aabb.Y);
							}
						}
						else if (aiStyle == 3 || aiStyle == 13)
						{
							Collision.HitTiles(position, velocity, width, height);
							if (type == 33 || type == 106)
							{
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
								if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
							}
							else
							{
								ai0 = 1f;
								if (aiStyle == 3)
								{
									velocity.X = 0f - value.X;
									velocity.Y = 0f - value.Y;
								}
							}
							netUpdate = true;
							Main.PlaySound(0, aabb.X, aabb.Y);
						}
						else if (aiStyle == 8 && type != 96)
						{
							Main.PlaySound(2, aabb.X, aabb.Y, 10);
							ai0 += 1f;
							if (ai0 >= 5f)
							{
								position.X += velocity.X;
								position.Y += velocity.Y;
								Kill();
							}
							else
							{
								if (type == 15 && velocity.Y > 4f)
								{
									if (velocity.Y != value.Y)
									{
										velocity.Y = (0f - value.Y) * 0.8f;
									}
								}
								else if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
							}
						}
						else if (aiStyle == 14)
						{
							if (type == 50)
							{
								if (velocity.X != value.X)
								{
									velocity.X = value.X * -0.2f;
								}
								if (velocity.Y != value.Y && (double)value.Y > 1.5)
								{
									velocity.Y = value.Y * -0.2f;
								}
							}
							else
							{
								if (velocity.X != value.X)
								{
									velocity.X = value.X * -0.5f;
								}
								if (velocity.Y != value.Y && value.Y > 1f)
								{
									velocity.Y = value.Y * -0.5f;
								}
							}
						}
						else if (aiStyle == 16)
						{
							if (velocity.X != value.X)
							{
								velocity.X = value.X * -0.4f;
								if (type == 29)
								{
									velocity.X *= 0.8f;
								}
							}
							if (velocity.Y != value.Y && (double)value.Y > 0.7 && type != 102)
							{
								velocity.Y = value.Y * -0.4f;
								if (type == 29)
								{
									velocity.Y *= 0.8f;
								}
							}
						}
						else if ((aiStyle != 9 || isLocal()) && type != 111 && (type < 115 || type > 119))
						{
							position.X += velocity.X;
							position.Y += velocity.Y;
							Kill();
						}
					}
				}
				if (type != 7 && type != 8)
				{
					if (wet)
					{
						position.X += vector.X;
						position.Y += vector.Y;
					}
					else
					{
						position.X += velocity.X;
						position.Y += velocity.Y;
					}
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
				}
				if ((aiStyle != 3 || ai0 != 1f) && (aiStyle != 7 || ai0 != 1f) && (aiStyle != 13 || ai0 != 1f) && (aiStyle != 15 || ai0 != 1f) && aiStyle != 15 && aiStyle != 26)
				{
					direction = (sbyte)((!(velocity.X < 0f)) ? 1 : (-1));
				}
				if (active == 0)
				{
					return;
				}
				if (light > 0f)
				{
					float num3 = light;
					float num4 = light;
					float num5 = light;
					if (type == 2 || type == 82)
					{
						num4 *= 0.75f;
						num5 *= 0.55f;
					}
					else if (type == 94)
					{
						num3 *= 0.5f;
						num4 = 0f;
					}
					else if (type == 95 || type == 96 || type == 103 || type == 104)
					{
						num3 *= 0.35f;
						num5 = 0f;
					}
					else if (type == 4)
					{
						num4 *= 0.1f;
						num3 *= 0.5f;
					}
					else if (type == 9)
					{
						num4 *= 0.1f;
						num5 *= 0.6f;
					}
					else if (type == 92)
					{
						num4 *= 0.6f;
						num3 *= 0.8f;
					}
					else if (type == 93)
					{
						num4 *= 1f;
						num3 *= 1f;
						num5 *= 0.01f;
					}
					else if (type == 12)
					{
						num3 *= 0.9f;
						num4 *= 0.8f;
						num5 *= 0.1f;
					}
					else if (type == 14 || type == 110)
					{
						num4 *= 0.7f;
						num5 *= 0.1f;
					}
					else if (type == 15)
					{
						num4 *= 0.4f;
						num5 *= 0.1f;
						num3 = 1f;
					}
					else if (type == 16)
					{
						num3 *= 0.1f;
						num4 *= 0.4f;
						num5 = 1f;
					}
					else if (type == 113)
					{
						num3 *= 0.1f;
						num5 = 1f;
					}
					else if (type == 18)
					{
						num4 *= 0.7f;
						num5 *= 0.3f;
					}
					else if (type == 19)
					{
						num4 *= 0.5f;
						num5 *= 0.1f;
					}
					else if (type == 20)
					{
						num3 *= 0.1f;
						num5 *= 0.3f;
					}
					else if (type == 22)
					{
						num3 = 0f;
						num4 = 0f;
					}
					else if (type == 27)
					{
						num3 = 0f;
						num4 *= 0.3f;
						num5 = 1f;
					}
					else if (type == 34)
					{
						num4 *= 0.1f;
						num5 *= 0.1f;
					}
					else if (type == 36)
					{
						num3 = 0.8f;
						num4 *= 0.2f;
						num5 *= 0.6f;
					}
					else if (type == 41)
					{
						num4 *= 0.8f;
						num5 *= 0.6f;
					}
					else if (type == 114)
					{
						num3 = 1f;
						num4 = 1f;
						num5 *= 0.25f;
					}
					else if (type == 44 || type == 45)
					{
						num5 = 1f;
						num3 *= 0.6f;
						num4 *= 0.1f;
					}
					else if (type == 50)
					{
						num3 *= 0.7f;
						num5 *= 0.8f;
					}
					else if (type == 53)
					{
						num3 *= 0.7f;
						num4 *= 0.8f;
					}
					else if (type == 72)
					{
						num3 *= 0.45f;
						num4 *= 0.75f;
						num5 = 1f;
					}
					else if (type == 86)
					{
						num4 *= 0.45f;
						num5 = 0.75f;
					}
					else if (type == 87)
					{
						num3 *= 0.45f;
						num4 = 1f;
						num5 *= 0.75f;
					}
					else if (type == 73)
					{
						num3 *= 0.4f;
						num4 *= 0.6f;
					}
					else if (type == 74)
					{
						num4 *= 0.4f;
						num5 *= 0.6f;
					}
					else if (type == 76 || type == 77 || type == 78)
					{
						num4 *= 0.3f;
						num5 *= 0.6f;
					}
					else if (type == 79)
					{
						num3 = Main.DiscoRGB.X;
						num4 = Main.DiscoRGB.Y;
						num5 = Main.DiscoRGB.Z;
					}
					else if (type == 80)
					{
						num3 = 0f;
						num4 *= 0.8f;
						num5 *= 1f;
					}
					else if (type == 83 || type == 88)
					{
						num3 *= 0.7f;
						num4 = 0f;
						num5 *= 1f;
					}
					else if (type == 100)
					{
						num4 *= 0.5f;
						num5 = 0f;
					}
					else if (type == 84)
					{
						num3 *= 0.8f;
						num4 = 0f;
						num5 *= 0.5f;
					}
					else if (type == 89 || type == 90)
					{
						num4 *= 0.2f;
						num3 *= 0.05f;
					}
					else if (type == 106)
					{
						num3 = 0f;
						num4 *= 0.5f;
					}
					Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(num3, num4, num5));
				}
				if ((Main.frameCounter & 1) == 1)
				{
					if (type == 2 || type == 82)
					{
						Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100);
					}
					else if (type == 103)
					{
						Dust* ptr6 = Main.dust.NewDust(75, ref aabb, 0.0, 0.0, 100);
						if (Main.rand.Next(2) == 0 && ptr6 != null)
						{
							ptr6->noGravity = true;
							ptr6->scale *= 2f;
						}
					}
					else if (type == 4)
					{
						if (Main.rand.Next(3) == 0)
						{
							Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 150, default(Color), 1.1000000238418579);
						}
					}
					else if (type == 5)
					{
						int num6 = Main.rand.Next(3);
						num6 = ((num6 != 0) ? (num6 + 56) : 15);
						Main.dust.NewDust(num6, ref aabb, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2000000476837158);
					}
				}
				Damage();
				if (type == 99)
				{
					if (Main.netMode != 1)
					{
						Collision.SwitchTiles(position, width, height, lastPosition);
					}
				}
				else if (type == 94)
				{
					fixed (float* ptr7 = oldPos)
					{
						Vector2* ptr8 = (Vector2*)ptr7;
						for (int num7 = 9; num7 > 0; num7--)
						{
							ptr8[num7] = ptr8[num7 - 1];
						}
						*ptr8 = position;
					}
				}
				if (--timeLeft <= 0)
				{
					Kill();
					break;
				}
				if (penetrate == 0)
				{
					Kill();
					break;
				}
				if (active == 0)
				{
					break;
				}
				if (isLocal() && netUpdate)
				{
					NetMessage.SendProjectile(i, SendDataOptions.InOrder);
				}
				if (maxUpdates <= 0)
				{
					break;
				}
				if (--numUpdates < 0)
				{
					numUpdates = (sbyte)maxUpdates;
					break;
				}
			}
			netUpdate = false;
		}

		private unsafe void PetAI()
		{
			Player player = Main.player[owner];
			if (isLocal())
			{
				if (player.dead)
				{
					player.pet = -1;
				}
				else if (player.pet >= 0)
				{
					timeLeft = 2;
				}
			}
			if (player.rocketDelay2 > 0)
			{
				ai0 = 1f;
			}
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = player.position.X + 10f - vector.X;
			float num2 = player.position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (num3 > 2000f)
			{
				position.X = player.position.X + 10f - (float)(width >> 1);
				position.Y = player.position.Y + 21f - (float)(height >> 1);
				aabb.X = (int)position.X;
				aabb.Y = (int)position.Y;
			}
			else if (num3 > 500f || Math.Abs(num2) > 300f)
			{
				ai0 = 1f;
				if (num2 > 0f && velocity.Y < 0f)
				{
					velocity.Y = 0f;
				}
				if (num2 < 0f && velocity.Y > 0f)
				{
					velocity.Y = 0f;
				}
			}
			if (ai0 != 0f)
			{
				tileCollide = false;
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num4 = player.position.X + 10f - vector2.X;
				float num5 = player.position.Y + 21f - vector2.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				float num7 = 10f;
				if (num6 < 200f && player.velocity.Y == 0f && position.Y + (float)(int)height <= player.position.Y + 42f)
				{
					Vector2 Velocity = velocity;
					Collision.TileCollision(ref position, ref Velocity, width, height);
					tileCollide = (velocity.X != Velocity.X || velocity.Y != Velocity.Y);
					if (!tileCollide)
					{
						ai0 = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
				}
				if (num6 < 60f)
				{
					num4 = velocity.X;
					num5 = velocity.Y;
				}
				else
				{
					num6 = num7 / num6;
					num4 *= num6;
					num5 *= num6;
				}
				if (velocity.X < num4)
				{
					velocity.X += 0.2f;
					if (velocity.X < 0f)
					{
						velocity.X += 0.3f;
					}
				}
				if (velocity.X > num4)
				{
					velocity.X -= 0.2f;
					if (velocity.X > 0f)
					{
						velocity.X -= 0.3f;
					}
				}
				if (velocity.Y < num5)
				{
					velocity.Y += 0.2f;
					if (velocity.Y < 0f)
					{
						velocity.Y += 0.3f;
					}
				}
				if (velocity.Y > num5)
				{
					velocity.Y -= 0.2f;
					if (velocity.Y > 0f)
					{
						velocity.Y -= 0.3f;
					}
				}
				petAnimFly[localAI0].Update(ref this);
				if ((double)velocity.X > 0.5)
				{
					spriteDirection = -1;
				}
				else if ((double)velocity.X < -0.5)
				{
					spriteDirection = 1;
				}
				if (type < 116)
				{
					if (spriteDirection == -1)
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
					else
					{
						rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + Math.PI);
					}
				}
				if ((Main.frameCounter & 1) == 1)
				{
					Dust* ptr = Main.dust.NewDust((int)(position.X - velocity.X) + (width >> 1) - 4, (int)(position.Y - velocity.Y) + (height >> 1) - 4, 8, 8, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 50, default(Color), 1.7000000476837158);
					if (ptr != null)
					{
						ptr->velocity *= 0.2f;
						ptr->noGravity = true;
					}
				}
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			rotation = 0f;
			tileCollide = true;
			if (player.aabb.X + 10 < aabb.X + (width >> 1) - 60)
			{
				if ((double)velocity.X > -3.5)
				{
					velocity.X -= 0.08f;
				}
				else
				{
					velocity.X -= 0.02f;
				}
				flag = true;
			}
			else if (player.position.X + 10f > position.X + (float)(width >> 1) + 60f)
			{
				if ((double)velocity.X < 3.5)
				{
					velocity.X += 0.08f;
				}
				else
				{
					velocity.X += 0.02f;
				}
				flag2 = true;
			}
			else
			{
				velocity.X *= 0.9f;
				if ((double)velocity.X >= -0.08 && (double)velocity.X <= 0.08)
				{
					velocity.X = 0f;
				}
			}
			if (flag || flag2)
			{
				int num8 = aabb.X + (width >> 1) >> 4;
				int j = aabb.Y + (height >> 1) >> 4;
				num8 = ((!flag) ? (num8 + 1) : (num8 - 1));
				num8 += (int)velocity.X;
				if (WorldGen.CanStandOnTop(num8, j))
				{
					flag4 = true;
				}
			}
			if (player.position.Y + 42f > position.Y + (float)(int)height)
			{
				flag3 = true;
			}
			if (velocity.Y == 0f)
			{
				if (!flag3 && (velocity.X < 0f || velocity.X > 0f))
				{
					int num9 = aabb.X + (width >> 1) >> 4;
					int j2 = (aabb.Y + (height >> 1) >> 4) + 1;
					if (flag)
					{
						num9--;
					}
					if (flag2)
					{
						num9++;
					}
					if (!WorldGen.CanStandOnTop(num9, j2))
					{
						flag4 = true;
					}
				}
				if (flag4)
				{
					int i = aabb.X + (width >> 1) >> 4;
					int j3 = (aabb.Y + (height >> 1) >> 4) + 1;
					if (WorldGen.CanStandOnTop(i, j3))
					{
						velocity.Y = -9.1f;
					}
				}
			}
			if (velocity.X > 6.5f)
			{
				velocity.X = 6.5f;
			}
			else if (velocity.X < -6.5f)
			{
				velocity.X = -6.5f;
			}
			if ((double)velocity.X > 0.07 && flag2)
			{
				direction = 1;
			}
			else if ((double)velocity.X < -0.07 && flag)
			{
				direction = -1;
			}
			spriteDirection = (sbyte)(-direction);
			if (velocity.Y == 0f)
			{
				if ((double)Math.Abs(velocity.X) < 0.8)
				{
					petAnimIdle[localAI0].Update(ref this);
				}
				else
				{
					petAnimMove[localAI0].Update(ref this);
				}
			}
			else if (velocity.Y < 0f)
			{
				petAnimFall[localAI0].Update(ref this);
			}
			else if (velocity.Y > 0f)
			{
				petAnimJump[localAI0].Update(ref this);
			}
			velocity.Y += 0.4f;
			if (velocity.Y > 10f)
			{
				velocity.Y = 10f;
			}
		}

		private void FlyingPetAI()
		{
			Player player = Main.player[owner];
			if (isLocal())
			{
				if (player.dead)
				{
					player.pet = -1;
				}
				else if (player.pet >= 0)
				{
					timeLeft = 2;
				}
			}
			tileCollide = false;
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = player.position.X + 10f - vector.X;
			float num2 = player.position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			float num4 = 10f;
			if (num3 < 200f && player.velocity.Y == 0f && position.Y + (float)(int)height <= player.position.Y + 42f)
			{
				Vector2 Velocity = velocity;
				Collision.TileCollision(ref position, ref Velocity, width, height);
				tileCollide = (velocity.X != Velocity.X || velocity.Y != Velocity.Y);
				if (!tileCollide)
				{
					ai0 = 0f;
					if (velocity.Y < -6f)
					{
						velocity.Y = -6f;
					}
				}
			}
			if (num3 < 60f)
			{
				num = velocity.X;
				num2 = velocity.Y;
			}
			else
			{
				num3 = num4 / num3;
				num *= num3;
				num2 *= num3;
			}
			if (velocity.X < num)
			{
				velocity.X += 0.2f;
				if (velocity.X < 0f)
				{
					velocity.X += 0.3f;
				}
			}
			if (velocity.X > num)
			{
				velocity.X -= 0.2f;
				if (velocity.X > 0f)
				{
					velocity.X -= 0.3f;
				}
			}
			if (velocity.Y < num2)
			{
				velocity.Y += 0.2f;
				if (velocity.Y < 0f)
				{
					velocity.Y += 0.3f;
				}
			}
			if (velocity.Y > num2)
			{
				velocity.Y -= 0.2f;
				if (velocity.Y > 0f)
				{
					velocity.Y -= 0.3f;
				}
			}
			petAnimFly[localAI0].Update(ref this);
			if ((double)velocity.X > 0.5)
			{
				spriteDirection = -1;
			}
			else if ((double)velocity.X < -0.5)
			{
				spriteDirection = 1;
			}
		}

		private unsafe void ArrowAI()
		{
			if (ai1 == 0)
			{
				ai1 = 1;
				if (type == 83 || type == 100)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 33);
				}
				else if (type == 110)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 11);
				}
				else if (type == 84)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 12);
				}
				else if (type == 98)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 17);
				}
				else if (type == 81 || type == 82)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 5);
				}
			}
			if (type == 41)
			{
				Dust* ptr = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.6000000238418579);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr != null)
					{
						ptr->noGravity = true;
					}
				}
			}
			else if (type == 114)
			{
				Dust* ptr2 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.6000000238418579);
				if (ptr2 != null)
				{
					ptr2->noGravity = true;
					ptr2 = Main.dust.NewDust(64, ref aabb, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr2 != null)
					{
						ptr2->noGravity = true;
					}
				}
			}
			else if (type == 55)
			{
				Dust* ptr3 = Main.dust.NewDust(18, ref aabb, 0.0, 0.0, 0, default(Color), 0.89999997615814209);
				if (ptr3 != null)
				{
					ptr3->noGravity = true;
				}
			}
			else if (type == 91)
			{
				if (Main.rand.Next(3) == 0)
				{
					int num = (Main.rand.Next(2) != 0) ? 58 : 15;
					Dust* ptr4 = Main.dust.NewDust(num, ref aabb, velocity.X * 0.25f, velocity.Y * 0.25f, 150, default(Color), 0.89999997615814209);
					if (ptr4 != null)
					{
						ptr4->velocity.X *= 0.25f;
						ptr4->velocity.Y *= 0.25f;
					}
				}
			}
			else if (type == 88)
			{
				if (alpha > 10)
				{
					alpha -= 10;
				}
				else
				{
					alpha = 0;
				}
			}
			else if (type == 20 || type == 14 || type == 36 || type == 83 || type == 84 || type == 89 || type == 100 || type == 104 || type == 110)
			{
				if (alpha > 15)
				{
					alpha -= 15;
				}
				else
				{
					alpha = 0;
				}
			}
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 1.57);
			if (type != 5 && type != 14 && type != 20 && type != 36 && type != 38 && type != 55 && type != 83 && type != 84 && type != 88 && type != 89 && type != 98 && type != 100 && type != 104 && type != 110)
			{
				if ((ai0 += 1f) == 9f)
				{
					if (type == 114 && isLocal() && Main.rand.Next(4) == 0)
					{
						int num2 = NewClonedProjectile(114);
						if (num2 >= 0)
						{
							double num3 = velocity.Length();
							double num4 = (double)rotation - (double)Main.rand.Next(10, 28) * (Math.PI / 180.0);
							double num5 = (double)rotation + (double)Main.rand.Next(10, 28) * (Math.PI / 180.0);
							double num6 = 0.0 - Math.Cos(num4);
							double num7 = Math.Sin(num4);
							double num8 = num3 * num7;
							double num9 = num3 * num6;
							Main.projectile[num2].velocity.X = (float)num8;
							Main.projectile[num2].velocity.Y = (float)num9;
							Main.projectile[num2].ai0 = 9f;
							Main.projectile[num2].ai1 = 1;
							num6 = 0.0 - Math.Cos(num5);
							num7 = Math.Sin(num5);
							num8 = num3 * num7;
							num9 = num3 * num6;
							velocity.X = (float)num8;
							velocity.Y = (float)num9;
							NetMessage.SendProjectile(num2);
						}
					}
				}
				else if (ai0 >= 15f)
				{
					if (type == 81 || type == 91)
					{
						if (ai0 >= 20f)
						{
							velocity.Y += 0.07f;
						}
					}
					else
					{
						velocity.Y += 0.1f;
					}
				}
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void BoomerangAI()
		{
			if (soundDelay == 0)
			{
				soundDelay = 8;
				Main.PlaySound(2, aabb.X, aabb.Y, 7);
			}
			if (type == 19)
			{
				for (int i = 0; i < 2; i++)
				{
					Dust* ptr = Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr == null)
					{
						break;
					}
					ptr->noGravity = true;
					ptr->velocity.X *= 0.3f;
					ptr->velocity.Y *= 0.3f;
				}
			}
			else if (type == 33)
			{
				if (Main.rand.Next(2) == 0)
				{
					Dust* ptr2 = Main.dust.NewDust(40, ref aabb, velocity.X * 0.25f, velocity.Y * 0.25f, 0, default(Color), 1.3999999761581421);
					if (ptr2 != null)
					{
						ptr2->noGravity = true;
					}
				}
			}
			else if (type == 6 && Main.rand.Next(6) == 0)
			{
				int num;
				switch (Main.rand.Next(3))
				{
				case 0:
					num = 15;
					break;
				case 1:
					num = 57;
					break;
				default:
					num = 58;
					break;
				}
				Main.dust.NewDust(num, ref aabb, velocity.X * 0.25f, velocity.Y * 0.25f, 150, default(Color), 0.699999988079071);
			}
			if (ai0 == 0f)
			{
				ai1++;
				if (type == 106)
				{
					if (ai1 >= 45)
					{
						ai0 = 1f;
						ai1 = 0;
						netUpdate = true;
					}
				}
				else if (ai1 >= 30)
				{
					ai0 = 1f;
					ai1 = 0;
					netUpdate = true;
				}
			}
			else
			{
				tileCollide = false;
				float num2 = 9f;
				float num3 = 0.4f;
				if (type == 19)
				{
					num2 = 13f;
					num3 = 0.6f;
				}
				else if (type == 33)
				{
					num2 = 15f;
					num3 = 0.8f;
				}
				else if (type == 106)
				{
					num2 = 16f;
					num3 = 1.2f;
				}
				Vector2 vector = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
				float num4 = Main.player[owner].position.X + 10f - vector.X;
				float num5 = Main.player[owner].position.Y + 21f - vector.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				if (num6 > 3000f)
				{
					Kill();
				}
				num6 = num2 / num6;
				num4 *= num6;
				num5 *= num6;
				if (velocity.X < num4)
				{
					velocity.X += num3;
					if (velocity.X < 0f && num4 > 0f)
					{
						velocity.X += num3;
					}
				}
				else if (velocity.X > num4)
				{
					velocity.X -= num3;
					if (velocity.X > 0f && num4 < 0f)
					{
						velocity.X -= num3;
					}
				}
				if (velocity.Y < num5)
				{
					velocity.Y += num3;
					if (velocity.Y < 0f && num5 > 0f)
					{
						velocity.Y += num3;
					}
				}
				else if (velocity.Y > num5)
				{
					velocity.Y -= num3;
					if (velocity.Y > 0f && num5 < 0f)
					{
						velocity.Y -= num3;
					}
				}
				if (isLocal() && new Rectangle(aabb.X, aabb.Y, width, height).Intersects(Main.player[owner].aabb))
				{
					Kill();
				}
			}
			if (type == 106)
			{
				rotation += 0.3f * (float)direction;
			}
			else
			{
				rotation += 0.4f * (float)direction;
			}
		}

		private unsafe void ShurikenAI()
		{
			if (type == 93 && Main.rand.Next(5) == 0)
			{
				Dust* ptr = Main.dust.NewDust(57, ref aabb, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 0.30000001192092896);
				if (ptr != null)
				{
					ptr->velocity *= 0.3f;
				}
			}
			rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.03f * (float)direction;
			ai0 += 1f;
			if (type == 69 || type == 70)
			{
				if (ai0 >= 10f)
				{
					velocity.Y += 0.25f;
					velocity.X *= 0.99f;
				}
			}
			else if (ai0 >= 20f)
			{
				velocity.Y += 0.4f;
				velocity.X *= 0.97f;
			}
			else if (type == 48 || type == 54 || type == 93)
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
			if (type == 54 && Main.rand.Next(20) == 0)
			{
				Main.dust.NewDust(40, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75);
			}
		}

		private unsafe void VilethornAI()
		{
			rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			if (ai0 == 0f)
			{
				alpha -= 50;
				if (alpha > 0)
				{
					return;
				}
				alpha = 0;
				ai0 = 1f;
				if (ai1 == 0)
				{
					ai1 = 1;
					position.X += velocity.X;
					position.Y += velocity.Y;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
				}
				if (type == 7 && isLocal())
				{
					int num = NewClonedProjectile((ai1 >= 6) ? 8 : 7);
					if (num >= 0)
					{
						Main.projectile[num].position.X += velocity.X;
						Main.projectile[num].position.Y += velocity.Y;
						Main.projectile[num].aabb.X = (int)Main.projectile[num].position.X;
						Main.projectile[num].aabb.Y = (int)Main.projectile[num].position.Y;
						Main.projectile[num].ai1 = ai1 + 1;
						NetMessage.SendProjectile(num);
					}
				}
				return;
			}
			alpha += 5;
			if (alpha >= 170 && alpha < 175)
			{
				for (int i = 0; i < 2; i++)
				{
					Main.dust.NewDust(18, ref aabb, velocity.X * 0.025f, velocity.Y * 0.025f, 170, default(Color), 1.2000000476837158);
				}
				Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 170, default(Color), 1.1000000238418579);
			}
			else if (alpha >= byte.MaxValue)
			{
				Kill();
			}
		}

		private unsafe void StarfuryAI()
		{
			if (type == 92)
			{
				if (aabb.Y > ai1)
				{
					tileCollide = true;
				}
			}
			else
			{
				if (ai1 == 0 && !Collision.SolidCollision(ref position, width, height))
				{
					ai1 = 1;
					netUpdate = true;
				}
				if (ai1 != 0)
				{
					tileCollide = true;
				}
			}
			if (soundDelay == 0)
			{
				soundDelay = (short)(20 + Main.rand.Next(40));
				Main.PlaySound(2, aabb.X, aabb.Y, 9);
			}
			if (localAI0 == 0)
			{
				localAI0 = 1;
			}
			int num = alpha + 25 * localAI0;
			if (num > 200)
			{
				alpha = 200;
				localAI0 = -1;
			}
			else if (num < 0)
			{
				alpha = 0;
				localAI0 = 1;
			}
			else
			{
				alpha = (byte)num;
			}
			rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f * (float)direction;
			if (ai1 == 1 || type == 92)
			{
				light = 0.9f;
				if (Main.rand.Next(12) == 0)
				{
					Main.dust.NewDust(58, ref aabb, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2000000476837158);
				}
				if (Main.rand.Next(24) == 0)
				{
					Gore.NewGore(position, new Vector2(velocity.X * 0.2f, velocity.Y * 0.2f), Main.rand.Next(16, 18));
				}
			}
		}

		private unsafe void PowderAI()
		{
			velocity.X *= 0.95f;
			velocity.Y *= 0.95f;
			ai0 += 1f;
			if (ai0 == 180f)
			{
				Kill();
			}
			if (ai1 == 0)
			{
				ai1 = 1;
				for (int i = 0; i < 24; i++)
				{
					Main.dust.NewDust(10 + type, ref aabb, velocity.X, velocity.Y, 50);
				}
			}
			if (!isLocal())
			{
				return;
			}
			int num = (aabb.X >> 4) - 1;
			int num2 = (aabb.X + width >> 4) + 2;
			int num3 = (aabb.Y >> 4) - 1;
			int num4 = (aabb.Y + height >> 4) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			Vector2 vector = default(Vector2);
			for (int j = num; j < num2; j++)
			{
				for (int k = num3; k < num4; k++)
				{
					vector.X = j * 16;
					vector.Y = k * 16;
					if (!(position.X + (float)(int)width > vector.X) || !(position.X < vector.X + 16f) || !(position.Y + (float)(int)height > vector.Y) || !(position.Y < vector.Y + 16f) || Main.tile[j, k].active == 0)
					{
						continue;
					}
					int num5 = Main.tile[j, k].type;
					if (type == 10)
					{
						switch (num5)
						{
						case 23:
							Main.tile[j, k].type = 2;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						case 25:
							Main.tile[j, k].type = 1;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						case 112:
							Main.tile[j, k].type = 53;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						}
					}
					else
					{
						switch (num5)
						{
						case 109:
							Main.tile[j, k].type = 2;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						case 116:
							Main.tile[j, k].type = 53;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						case 117:
							Main.tile[j, k].type = 1;
							WorldGen.SquareTileFrame(j, k);
							NetMessage.SendTile(j, k);
							break;
						}
					}
				}
			}
		}

		private void GrapplingAI()
		{
			if (Main.player[owner].dead)
			{
				Kill();
				return;
			}
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.player[owner].position.X + 10f - vector.X;
			float num2 = Main.player[owner].position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			rotation = (float)Math.Atan2(num2, num) - 1.57f;
			if (ai0 == 0f)
			{
				if ((num3 > 300f && type == 13) || (num3 > 400f && type == 32) || (num3 > 440f && type == 73) || (num3 > 440f && type == 74))
				{
					ai0 = 1f;
				}
				int num4 = (aabb.X >> 4) - 1;
				int num5 = (aabb.X + width >> 4) + 2;
				int num6 = (aabb.Y >> 4) - 1;
				int num7 = (aabb.Y + height >> 4) + 2;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				Vector2 vector2 = default(Vector2);
				for (int i = num4; i < num5; i++)
				{
					for (int j = num6; j < num7; j++)
					{
						vector2.X = i * 16;
						vector2.Y = j * 16;
						if (!(position.X + (float)(int)width > vector2.X) || !(position.X < vector2.X + 16f) || !(position.Y + (float)(int)height > vector2.Y) || !(position.Y < vector2.Y + 16f) || Main.tile[i, j].active == 0 || !Main.tileSolid[Main.tile[i, j].type])
						{
							continue;
						}
						if (Main.player[owner].grapCount < 10)
						{
							Main.player[owner].grappling[Main.player[owner].grapCount] = whoAmI;
							Main.player[owner].grapCount++;
						}
						if (isLocal())
						{
							int num8 = 0;
							int num9 = -1;
							int num10 = 100000;
							if (type == 73 || type == 74)
							{
								for (int k = 0; k < 512; k++)
								{
									if (k != whoAmI && Main.projectile[k].active != 0 && Main.projectile[k].owner == owner && Main.projectile[k].aiStyle == 7 && Main.projectile[k].ai0 == 2f)
									{
										Main.projectile[k].Kill();
									}
								}
							}
							else
							{
								for (int l = 0; l < 512; l++)
								{
									if (Main.projectile[l].active != 0 && Main.projectile[l].owner == owner && Main.projectile[l].aiStyle == 7)
									{
										if (Main.projectile[l].timeLeft < num10)
										{
											num9 = l;
											num10 = Main.projectile[l].timeLeft;
										}
										num8++;
									}
								}
								if (num8 > 3)
								{
									Main.projectile[num9].Kill();
								}
							}
						}
						WorldGen.KillTile(i, j, fail: true, effectOnly: true);
						Main.PlaySound(0, i * 16, j * 16);
						velocity.X = 0f;
						velocity.Y = 0f;
						ai0 = 2f;
						position.X = (aabb.X = i * 16 + 8 - (width >> 1));
						position.Y = (aabb.Y = j * 16 + 8 - (height >> 1));
						damage = 0;
						netUpdate = true;
						if (isLocal())
						{
							NetMessage.CreateMessage1(13, owner);
							NetMessage.SendMessage();
						}
						break;
					}
					if (ai0 == 2f)
					{
						break;
					}
				}
			}
			else if (ai0 == 1f)
			{
				float num11 = 11f;
				if (type == 32)
				{
					num11 = 15f;
				}
				if (type == 73 || type == 74)
				{
					num11 = 17f;
				}
				if (num3 < 24f)
				{
					Kill();
				}
				num3 = num11 / num3;
				num *= num3;
				num2 *= num3;
				velocity.X = num;
				velocity.Y = num2;
			}
			else
			{
				if (ai0 != 2f)
				{
					return;
				}
				int num12 = (aabb.X >> 4) - 1;
				int num13 = (aabb.X + width >> 4) + 2;
				int num14 = (aabb.Y >> 4) - 1;
				int num15 = (aabb.Y + height >> 4) + 2;
				if (num12 < 0)
				{
					num12 = 0;
				}
				if (num13 > Main.maxTilesX)
				{
					num13 = Main.maxTilesX;
				}
				if (num14 < 0)
				{
					num14 = 0;
				}
				if (num15 > Main.maxTilesY)
				{
					num15 = Main.maxTilesY;
				}
				bool flag = true;
				Vector2 vector3 = default(Vector2);
				for (int m = num12; m < num13; m++)
				{
					for (int n = num14; n < num15; n++)
					{
						vector3.X = m * 16;
						vector3.Y = n * 16;
						if (position.X + (float)(width >> 1) > vector3.X && position.X + (float)(width >> 1) < vector3.X + 16f && position.Y + (float)(height >> 1) > vector3.Y && position.Y + (float)(height >> 1) < vector3.Y + 16f && Main.tile[m, n].active != 0 && Main.tileSolid[Main.tile[m, n].type])
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					ai0 = 1f;
				}
				else if (Main.player[owner].grapCount < 10)
				{
					Main.player[owner].grappling[Main.player[owner].grapCount] = whoAmI;
					Main.player[owner].grapCount++;
				}
			}
		}

		private unsafe void BallOfFireAI()
		{
			if (type == 96 && localAI0 == 0)
			{
				localAI0 = 1;
				Main.PlaySound(2, aabb.X, aabb.Y, 20);
			}
			if (type == 27)
			{
				Dust* ptr = Main.dust.NewDust((int)(position.X + velocity.X), (int)(position.Y + velocity.Y), width, height, 29, velocity.X, velocity.Y, 100, default(Color), 3.0);
				if (ptr != null)
				{
					ptr->noGravity = true;
					if (Main.rand.Next(12) == 0)
					{
						Main.dust.NewDust(29, ref aabb, velocity.X, velocity.Y, 100, default(Color), 1.3999999761581421);
					}
				}
			}
			else if (type == 95 || type == 96)
			{
				Dust* ptr2 = Main.dust.NewDust((int)(position.X + velocity.X), (int)(position.Y + velocity.Y), width, height, 75, velocity.X, velocity.Y, 100, default(Color), 3f * scale);
				if (ptr2 != null)
				{
					ptr2->noGravity = true;
				}
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					Dust* ptr3 = Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr3 == null)
					{
						break;
					}
					ptr3->noGravity = true;
					ptr3->velocity.X *= 0.3f;
					ptr3->velocity.Y *= 0.3f;
				}
			}
			if (type != 27 && type != 96 && ++ai1 >= 20)
			{
				velocity.Y += 0.2f;
			}
			rotation += 0.3f * (float)direction;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void MagicMissileAI()
		{
			if (type == 34)
			{
				Dust* ptr = Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 3.5);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 1.4f;
					ptr->velocity.Y *= 1.4f;
					Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 1.5);
				}
			}
			else if (type == 79)
			{
				if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
				{
					soundDelay = 10;
					Main.PlaySound(2, aabb.X, aabb.Y, 9);
				}
				Dust* ptr2 = Main.dust.NewDust(66, ref aabb, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.5);
				if (ptr2 != null)
				{
					ptr2->velocity.X *= 0.1f;
					ptr2->velocity.Y *= 0.1f;
					ptr2->velocity.X += velocity.X * 0.2f;
					ptr2->velocity.Y += velocity.Y * 0.2f;
					ptr2->position.X = aabb.X + (width >> 1) + 4 + Main.rand.Next(-2, 3);
					ptr2->position.Y = aabb.Y + (height >> 1) + Main.rand.Next(-2, 3);
					ptr2->noGravity = true;
				}
			}
			else
			{
				if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
				{
					soundDelay = 10;
					Main.PlaySound(2, aabb.X, aabb.Y, 9);
				}
				Dust* ptr3 = Main.dust.NewDust(15, ref aabb, 0.0, 0.0, 100, default(Color), 2.0);
				if (ptr3 != null)
				{
					ptr3->velocity.X *= 0.3f;
					ptr3->velocity.Y *= 0.3f;
					ptr3->position.X = aabb.X + (width >> 1) + 4 + Main.rand.Next(-4, 5);
					ptr3->position.Y = aabb.Y + (height >> 1) + Main.rand.Next(-4, 5);
					ptr3->noGravity = true;
				}
			}
			if (ai0 == 0f)
			{
				Player player = Main.player[owner];
				if (player.isLocal() && player.channel)
				{
					float num = (type == 16) ? 15 : 12;
					Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num2 = (float)(player.ui.mouseX + player.view.screenPosition.X) - vector.X;
					float num3 = (float)(player.ui.mouseY + player.view.screenPosition.Y) - vector.Y;
					float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					if (num4 > num)
					{
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					int num5 = (int)(num2 * 1000f);
					int num6 = (int)(velocity.X * 1000f);
					int num7 = (int)(num3 * 1000f);
					int num8 = (int)(velocity.Y * 1000f);
					if (num5 != num6 || num7 != num8)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					ai0 = 1f;
					netUpdate = true;
					float num9 = 12f;
					Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num10 = (float)(player.ui.mouseX + player.view.screenPosition.X) - vector2.X;
					float num11 = (float)(player.ui.mouseY + player.view.screenPosition.Y) - vector2.Y;
					float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
					if (num12 == 0f)
					{
						vector2 = new Vector2(player.position.X + 10f, player.position.Y + 21f);
						num10 = position.X + (float)(int)width * 0.5f - vector2.X;
						num11 = position.Y + (float)(int)height * 0.5f - vector2.Y;
						num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
					}
					num12 = num9 / num12;
					num10 *= num12;
					num11 *= num12;
					velocity.X = num10;
					velocity.Y = num11;
					if (velocity.X == 0f && velocity.Y == 0f)
					{
						Kill();
					}
				}
			}
			if (type == 34)
			{
				rotation += 0.3f * (float)direction;
			}
			else if (velocity.X != 0f || velocity.Y != 0f)
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 2.355f;
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void DirtBallAI()
		{
			if (type == 31 && ai0 != 2f)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr = Main.dust.NewDust(32, ref aabb, 0.0, velocity.Y * 0.5f);
					if (ptr != null)
					{
						ptr->velocity.X *= 0.4f;
					}
				}
			}
			else if (type == 39)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr2 = Main.dust.NewDust(38, ref aabb, 0.0, velocity.Y * 0.5f);
					if (ptr2 != null)
					{
						ptr2->velocity.X *= 0.4f;
					}
				}
			}
			else if (type == 40)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr3 = Main.dust.NewDust(36, ref aabb, 0.0, velocity.Y * 0.5f);
					if (ptr3 != null)
					{
						ptr3->velocity.X *= 0.4f;
						ptr3->velocity.Y *= 0.4f;
					}
				}
			}
			else if (type == 42 || type == 31)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr4 = Main.dust.NewDust(32, ref aabb);
					if (ptr4 != null)
					{
						ptr4->velocity.X *= 0.4f;
					}
				}
			}
			else if (type == 56 || type == 65)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr5 = Main.dust.NewDust(14, ref aabb);
					if (ptr5 != null)
					{
						ptr5->velocity.X *= 0.4f;
					}
				}
			}
			else if (type == 67 || type == 68)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr6 = Main.dust.NewDust(51, ref aabb);
					if (ptr6 != null)
					{
						ptr6->velocity.X *= 0.4f;
					}
				}
			}
			else if (type == 71)
			{
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr7 = Main.dust.NewDust(53, ref aabb);
					if (ptr7 != null)
					{
						ptr7->velocity.X *= 0.4f;
					}
				}
			}
			else if (type != 109 && Main.rand.Next(24) == 0)
			{
				Main.dust.NewDust(0, ref aabb);
			}
			if (ai0 == 0f)
			{
				Player player = Main.player[owner];
				if (player.isLocal() && player.channel)
				{
					float num = 12f;
					Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num2 = (float)(player.ui.mouseX + player.view.screenPosition.X) - vector.X;
					float num3 = (float)(player.ui.mouseY + player.view.screenPosition.Y) - vector.Y;
					float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					if (num4 > num)
					{
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					if (num2 != velocity.X || num3 != velocity.Y)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					ai0 = 1f;
					netUpdate = true;
				}
			}
			if (type != 109)
			{
				if (ai0 == 1f)
				{
					if (type == 42 || type == 65 || type == 68)
					{
						if (++ai1 >= 60)
						{
							velocity.Y += 0.2f;
						}
					}
					else
					{
						velocity.Y += 0.41f;
					}
				}
				else if (ai0 == 2f)
				{
					velocity.Y += 0.2f;
					if ((double)velocity.X < -0.04)
					{
						velocity.X += 0.04f;
					}
					else if ((double)velocity.X > 0.04)
					{
						velocity.X -= 0.04f;
					}
					else
					{
						velocity.X = 0f;
					}
				}
			}
			rotation += 0.1f;
			if (velocity.Y > 10f)
			{
				velocity.Y = 10f;
			}
		}

		private void OrbOfLightAI()
		{
			rotation += 0.02f;
			if (isLocal() && Main.player[owner].lightOrb)
			{
				timeLeft = 2;
			}
			if (!Main.player[owner].dead)
			{
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num = Main.player[owner].position.X + 10f - vector.X;
				float num2 = Main.player[owner].position.Y + 21f - vector.Y;
				float num3 = (float)Math.Sqrt(num * num + num2 * num2);
				num3 = (float)Math.Sqrt(num * num + num2 * num2);
				if (num3 > 800f)
				{
					position.X = (aabb.X = Main.player[owner].aabb.X + 10 - (width >> 1));
					position.Y = (aabb.Y = Main.player[owner].aabb.Y + 21 - (height >> 1));
				}
				else if (num3 > 70f)
				{
					num3 = 2.5f / num3;
					num *= num3;
					num2 *= num3;
					velocity.X = num;
					velocity.Y = num2;
				}
				else
				{
					velocity.X = 0f;
					velocity.Y = 0f;
				}
			}
			else
			{
				Kill();
			}
		}

		private unsafe void FairyAI()
		{
			if (velocity.X > 0f)
			{
				spriteDirection = -1;
			}
			else if (velocity.X < 0f)
			{
				spriteDirection = 1;
			}
			rotation = velocity.X * 0.1f;
			if (++frameCounter >= 4)
			{
				frameCounter = 0;
				frame = (byte)((frame + 1) & 3);
			}
			if (Main.rand.Next(6) == 0)
			{
				int num = 56;
				if (type == 86)
				{
					num = 73;
				}
				else if (type == 87)
				{
					num = 74;
				}
				Dust* ptr = Main.dust.NewDust(num, ref aabb, 0.0, 0.0, 200, default(Color), 0.800000011920929);
				if (ptr != null)
				{
					ptr->velocity.X *= 0.3f;
					ptr->velocity.Y *= 0.3f;
				}
			}
			if (isLocal() && Main.player[owner].fairy)
			{
				timeLeft = 2;
			}
			if (!Main.player[owner].dead)
			{
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num2 = Main.player[owner].position.X + 10f - vector.X;
				float num3 = Main.player[owner].position.Y + 21f - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				if (num4 > 800f)
				{
					position.X = (aabb.X = Main.player[owner].aabb.X + 10 - (width >> 1));
					position.Y = (aabb.Y = Main.player[owner].aabb.Y + 21 - (height >> 1));
				}
				else if (num4 > 40f)
				{
					num4 = 3.5f / num4;
					num2 *= num4;
					num3 *= num4;
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					velocity.X = 0f;
					velocity.Y = 0f;
				}
			}
			else
			{
				Kill();
			}
		}

		private unsafe void BlueFlameAI()
		{
			scale -= 0.04f;
			if (scale <= 0f)
			{
				Kill();
			}
			if (ai0 > 4f)
			{
				alpha = 150;
				light = 0.8f;
				Dust* ptr = Main.dust.NewDust(29, ref aabb, velocity.X, velocity.Y, 100, default(Color), 2.5);
				if (ptr != null)
				{
					ptr->noGravity = true;
					Main.dust.NewDust(29, ref aabb, velocity.X, velocity.Y, 100, default(Color), 1.5);
				}
			}
			else
			{
				ai0 += 1f;
			}
			rotation += 0.3f * (float)direction;
		}

		private void HarpoonAI()
		{
			if (Main.player[owner].dead)
			{
				Kill();
				return;
			}
			Main.player[owner].itemAnimation = 5;
			Main.player[owner].itemTime = 5;
			if (aabb.X + (width >> 1) > Main.player[owner].aabb.X + 10)
			{
				Main.player[owner].direction = 1;
			}
			else
			{
				Main.player[owner].direction = -1;
			}
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.player[owner].position.X + 10f - vector.X;
			float num2 = Main.player[owner].position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai0 == 0f)
			{
				if (num3 > 700f)
				{
					ai0 = 1f;
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				if (++ai1 > 2)
				{
					alpha = 0;
					if (ai1 >= 10)
					{
						velocity.Y += 0.3f;
					}
				}
			}
			else if (ai0 == 1f)
			{
				tileCollide = false;
				rotation = (float)Math.Atan2(num2, num) - 1.57f;
				float num4 = 20f;
				if (num3 < 50f)
				{
					Kill();
				}
				num3 = num4 / num3;
				num *= num3;
				num2 *= num3;
				velocity.X = num;
				velocity.Y = num2;
			}
		}

		private void SpikyBallAI()
		{
			if (type == 53)
			{
				int num = (aabb.X >> 4) - 1;
				int num2 = (aabb.X + width >> 4) + 2;
				int num3 = (aabb.Y >> 4) - 1;
				int num4 = (aabb.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.maxTilesX)
				{
					num2 = Main.maxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesY)
				{
					num4 = Main.maxTilesY;
				}
				Vector2 vector = default(Vector2);
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.tile[i, j].canStandOnTop())
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if (position.X + (float)(int)width > vector.X && position.X < vector.X + 16f && position.Y + (float)(int)height > vector.Y && position.Y < vector.Y + 16f)
							{
								velocity.X = 0f;
								velocity.Y = -0.2f;
							}
						}
					}
				}
			}
			ai0 += 1f;
			if (ai0 > 5f)
			{
				ai0 = 5f;
				if (velocity.Y == 0f && velocity.X != 0f)
				{
					velocity.X *= 0.97f;
					if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
					{
						velocity.X = 0f;
						netUpdate = true;
					}
				}
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void FlailAI()
		{
			if (type == 25)
			{
				if (Main.rand.Next(16) == 0)
				{
					Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 150, default(Color), 1.2999999523162842);
				}
			}
			else if (type == 26)
			{
				Dust* ptr = Main.dust.NewDust(29, ref aabb, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 2.5);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.5f;
				}
			}
			else if (type == 35)
			{
				Dust* ptr2 = Main.dust.NewDust(6, ref aabb, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 3.0);
				if (ptr2 != null)
				{
					ptr2->noGravity = true;
					ptr2->velocity.X *= 2f;
					ptr2->velocity.Y *= 2f;
				}
			}
			if (Main.player[owner].dead)
			{
				Kill();
				return;
			}
			Main.player[owner].itemAnimation = 10;
			Main.player[owner].itemTime = 10;
			if (aabb.X + (width >> 1) > Main.player[owner].aabb.X + 10)
			{
				Main.player[owner].direction = 1;
				direction = 1;
			}
			else
			{
				Main.player[owner].direction = -1;
				direction = -1;
			}
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.player[owner].position.X + 10f - vector.X;
			float num2 = Main.player[owner].position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai0 == 0f)
			{
				float num4 = 160f;
				if (type == 63)
				{
					num4 *= 1.5f;
				}
				tileCollide = true;
				if (num3 > num4)
				{
					ai0 = 1f;
					netUpdate = true;
				}
				else if (!Main.player[owner].channel)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y += 1f;
					velocity.X *= 0.9f;
				}
			}
			else if (ai0 == 1f)
			{
				float num5 = 14f / Main.player[owner].meleeSpeed;
				float num6 = 0.9f / Main.player[owner].meleeSpeed;
				float num7 = 300f;
				if (type == 63)
				{
					num7 *= 1.5f;
					num5 *= 1.5f;
					num6 *= 1.5f;
				}
				Math.Abs(num);
				Math.Abs(num2);
				if (ai1 == 1)
				{
					tileCollide = false;
				}
				if (!Main.player[owner].channel || num3 > num7 || !tileCollide)
				{
					ai1 = 1;
					if (tileCollide)
					{
						netUpdate = true;
					}
					tileCollide = false;
					if (num3 < 20f)
					{
						Kill();
					}
				}
				if (!tileCollide)
				{
					num6 *= 2f;
				}
				if (num3 > 60f || !tileCollide)
				{
					num3 = num5 / num3;
					num *= num3;
					num2 *= num3;
					new Vector2(velocity.X, velocity.Y);
					float num8 = num - velocity.X;
					float num9 = num2 - velocity.Y;
					float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
					num10 = num6 / num10;
					num8 *= num10;
					num9 *= num10;
					velocity.X *= 0.98f;
					velocity.Y *= 0.98f;
					velocity.X += num8;
					velocity.Y += num9;
				}
				else
				{
					if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 6f)
					{
						velocity.X *= 0.96f;
						velocity.Y += 0.2f;
					}
					if (Main.player[owner].velocity.X == 0f)
					{
						velocity.X *= 0.96f;
					}
				}
			}
			rotation = (float)Math.Atan2(num2, num) - velocity.X * 0.1f;
		}

		private unsafe void BombAI()
		{
			if (type == 108)
			{
				ai0 += 1f;
				if (ai0 > 3f)
				{
					Kill();
				}
			}
			if (type == 37)
			{
				int num = (aabb.X >> 4) - 1;
				int num2 = (aabb.X + width >> 4) + 2;
				int num3 = (aabb.Y >> 4) - 1;
				int num4 = (aabb.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.maxTilesX)
				{
					num2 = Main.maxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesY)
				{
					num4 = Main.maxTilesY;
				}
				Vector2 vector = default(Vector2);
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.tile[i, j].canStandOnTop())
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if (position.X + (float)(int)width - 4f > vector.X && position.X + 4f < vector.X + 16f && position.Y + (float)(int)height - 4f > vector.Y && position.Y + 4f < vector.Y + 16f)
							{
								velocity.X = 0f;
								velocity.Y = -0.2f;
							}
						}
					}
				}
			}
			if (type == 102)
			{
				if (velocity.Y > 10f)
				{
					velocity.Y = 10f;
				}
				if (localAI0 == 0)
				{
					localAI0 = 1;
					Main.PlaySound(2, aabb.X, aabb.Y, 10);
				}
				if (++frameCounter > 3)
				{
					frameCounter = 0;
					frame ^= 1;
				}
				if (velocity.Y == 0f && width != 128)
				{
					position.X += width >> 1;
					position.Y += height >> 1;
					aabb.Width = (width = 128);
					aabb.Height = (height = 128);
					position.X -= 64f;
					position.Y -= 64f;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
					damage = 40;
					knockBack = 8f;
					timeLeft = 3;
					netUpdate = true;
				}
			}
			if (timeLeft <= 3 && isLocal())
			{
				ai1 = 0;
				alpha = byte.MaxValue;
				if (type == 28 || type == 37 || type == 75)
				{
					if (width != 128)
					{
						position.X += width >> 1;
						position.Y += height >> 1;
						aabb.Width = (width = 128);
						aabb.Height = (height = 128);
						position.X -= 64f;
						position.Y -= 64f;
						aabb.X = (int)position.X;
						aabb.Y = (int)position.Y;
						damage = 100;
						knockBack = 8f;
					}
				}
				else if (type == 29)
				{
					if (width != 250)
					{
						position.X += width >> 1;
						position.Y += height >> 1;
						aabb.Width = (width = 250);
						aabb.Height = (height = 250);
						position.X -= 125f;
						position.Y -= 125f;
						aabb.X = (int)position.X;
						aabb.Y = (int)position.Y;
						damage = 250;
						knockBack = 10f;
					}
				}
				else if (type == 30 && width != 128)
				{
					position.X += width >> 1;
					position.Y += height >> 1;
					aabb.Width = (width = 128);
					aabb.Height = (height = 128);
					position.X -= 64f;
					position.Y -= 64f;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
					knockBack = 8f;
				}
			}
			else if (type != 30)
			{
				if (type != 108)
				{
					damage = 0;
				}
				if (Main.rand.Next(5) == 0)
				{
					Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100);
				}
			}
			ai0 += 1f;
			if ((type == 30 && ai0 > 10f) || (type != 30 && ai0 > 5f))
			{
				if (velocity.Y == 0f && velocity.X != 0f)
				{
					velocity.X *= 0.97f;
					if (type == 29)
					{
						velocity.X *= 0.99f;
					}
					if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
					{
						velocity.X = 0f;
						netUpdate = true;
					}
				}
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
		}

		private void TombstoneAI()
		{
			if (velocity.Y == 0f)
			{
				velocity.X *= 0.98f;
			}
			rotation += velocity.X * 0.1f;
			velocity.Y += 0.2f;
			if (!isLocal())
			{
				return;
			}
			int num = aabb.X + (width >> 1) >> 4;
			int num2 = aabb.Y + height - 4 >> 4;
			if (Main.tile[num, num2].active == 0 && WorldGen.PlaceTile(num, num2, 85))
			{
				NetMessage.CreateMessage5(17, 1, num, num2, 85);
				NetMessage.SendMessage();
				int num3 = Sign.ReadSign(num, num2);
				if (num3 >= 0)
				{
					Main.sign[num3].SetText(tombstoneText[tombstoneTextId]);
				}
				Kill();
			}
		}

		private unsafe void DemonSickleAI()
		{
			if (ai1 == 0 && type == 44)
			{
				ai1 = 1;
				Main.PlaySound(2, aabb.X, aabb.Y, 8);
			}
			rotation += (float)direction * 0.8f;
			if (!((ai0 += 1f) < 30f))
			{
				if (ai0 < 100f)
				{
					velocity.X *= 1.06f;
					velocity.Y *= 1.06f;
				}
				else
				{
					ai0 = 200f;
				}
			}
			for (int i = 0; i < 2; i++)
			{
				Dust* ptr = Main.dust.NewDust(27, ref aabb, 0.0, 0.0, 100);
				if (ptr == null)
				{
					break;
				}
				ptr->noGravity = true;
			}
		}

		private unsafe void SpearAI()
		{
			direction = Main.player[owner].direction;
			Main.player[owner].heldProj = whoAmI;
			Main.player[owner].itemTime = (byte)Main.player[owner].itemAnimation;
			position.X = Main.player[owner].position.X + (float)(20 - width >> 1);
			position.Y = Main.player[owner].position.Y + (float)(42 - height >> 1);
			if (type == 46)
			{
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 1.6f;
				}
				else
				{
					ai0 += 1.4f;
				}
			}
			else if (type == 105)
			{
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 2.4f;
				}
				else
				{
					ai0 += 2.1f;
				}
			}
			else if (type == 112)
			{
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 2.4f;
				}
				else
				{
					ai0 += 2.1f;
				}
			}
			else if (type == 47)
			{
				if (ai0 == 0f)
				{
					ai0 = 4f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 1.2f;
				}
				else
				{
					ai0 += 0.9f;
				}
			}
			else if (type == 49)
			{
				if (ai0 == 0f)
				{
					ai0 = 4f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 1.1f;
				}
				else
				{
					ai0 += 0.85f;
				}
			}
			else if (type == 64)
			{
				spriteDirection = (sbyte)(-direction);
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 1.9f;
				}
				else
				{
					ai0 += 1.7f;
				}
			}
			else if (type == 66 || type == 97)
			{
				spriteDirection = (sbyte)(-direction);
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 2.1f;
				}
				else
				{
					ai0 += 1.9f;
				}
			}
			else if (type == 97)
			{
				spriteDirection = (sbyte)(-direction);
				if (ai0 == 0f)
				{
					ai0 = 3f;
					netUpdate = true;
				}
				if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
				{
					ai0 -= 1.6f;
				}
				else
				{
					ai0 += 1.4f;
				}
			}
			position.X += velocity.X * ai0;
			position.Y += velocity.Y * ai0;
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			if (Main.player[owner].itemAnimation == 0)
			{
				Kill();
			}
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 2.355);
			if (spriteDirection == -1)
			{
				rotation -= 1.57f;
			}
			if (type == 46)
			{
				if (Main.rand.Next(6) == 0)
				{
					Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 150, default(Color), 1.3999999761581421);
				}
				Dust* ptr = Main.dust.NewDust(27, ref aabb, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.2000000476837158);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.5f;
					ptr = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f), width, height, 27, 0.0, 0.0, 150, default(Color), 1.3999999761581421);
					if (ptr != null)
					{
						ptr->velocity.X *= 0.2f;
						ptr->velocity.Y *= 0.2f;
					}
				}
			}
			else if (type == 105)
			{
				if (Main.rand.Next(4) == 0)
				{
					Dust* ptr2 = Main.dust.NewDust(57, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 200, default(Color), 1.2000000476837158);
					if (ptr2 != null)
					{
						ptr2->velocity.X += velocity.X * 0.3f;
						ptr2->velocity.Y += velocity.Y * 0.3f;
						ptr2->velocity.X *= 0.2f;
						ptr2->velocity.Y *= 0.2f;
					}
				}
				if (Main.rand.Next(5) == 0)
				{
					Dust* ptr3 = Main.dust.NewDust(43, ref aabb, 0.0, 0.0, 254, default(Color), 0.30000001192092896);
					if (ptr3 != null)
					{
						ptr3->velocity.X += velocity.X * 0.5f;
						ptr3->velocity.Y += velocity.Y * 0.5f;
						ptr3->velocity.X *= 0.5f;
						ptr3->velocity.Y *= 0.5f;
					}
				}
			}
			else
			{
				if (type != 112)
				{
					return;
				}
				if (Main.rand.Next(3) == 0)
				{
					Dust* ptr4 = Main.dust.NewDust(57, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 200, default(Color), 1.2000000476837158);
					if (ptr4 != null)
					{
						ptr4->velocity.X += velocity.X * 0.3f;
						ptr4->velocity.Y += velocity.Y * 0.3f;
						ptr4->velocity.X *= 0.2f;
						ptr4->velocity.Y *= 0.2f;
					}
				}
				if (Main.rand.Next(4) == 0)
				{
					Dust* ptr5 = Main.dust.NewDust(43, ref aabb, 0.0, 0.0, 254, default(Color), 0.30000001192092896);
					if (ptr5 != null)
					{
						ptr5->velocity.X += velocity.X * 0.5f;
						ptr5->velocity.Y += velocity.Y * 0.5f;
						ptr5->velocity.X *= 0.5f;
						ptr5->velocity.Y *= 0.5f;
					}
				}
			}
		}

		private unsafe void ChainsawAI()
		{
			if (soundDelay <= 0)
			{
				Main.PlaySound(2, aabb.X, aabb.Y, 22);
				soundDelay = 30;
			}
			Player player = Main.player[owner];
			if (player.isLocal())
			{
				if (player.channel)
				{
					float num = player.inventory[player.selectedItem].shootSpeed * scale;
					Vector2 vector = new Vector2(player.position.X + 10f, player.position.Y + 21f);
					float num2 = (float)(player.ui.mouseX + player.view.screenPosition.X) - vector.X;
					float num3 = (float)(player.ui.mouseY + player.view.screenPosition.Y) - vector.Y;
					float num4 = num2 * num2 + num3 * num3;
					if (num4 > 0f)
					{
						num4 = (float)Math.Sqrt(num4);
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					if (num2 != velocity.X || num3 != velocity.Y)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					Kill();
				}
			}
			if (velocity.X > 0f)
			{
				direction = 1;
			}
			else if (velocity.X < 0f)
			{
				direction = -1;
			}
			spriteDirection = direction;
			player.direction = direction;
			player.heldProj = whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			position.X = player.position.X + 10f - (float)(width >> 1);
			position.Y = player.position.Y + 21f - (float)(height >> 1);
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 1.5700000524520874);
			player.itemRotation = (float)Math.Atan2(velocity.Y * (float)direction, velocity.X * (float)direction);
			velocity.X *= 1f + (float)Main.rand.Next(-3, 4) * 0.01f;
			if (Main.rand.Next(8) == 0)
			{
				float num5 = (float)Main.rand.Next(6, 10) * 0.1f;
				Dust* ptr = Main.dust.NewDust((int)(position.X + velocity.X * num5) - 4, (int)(position.Y + velocity.Y * num5), width, height, 31, 0.0, 0.0, 80, default(Color), 1.3999999761581421);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 0.2f;
					ptr->velocity.Y = (float)(-Main.rand.Next(7, 13)) * 0.15f;
				}
			}
		}

		private unsafe void NoteAI()
		{
			rotation = velocity.X * 0.1f;
			spriteDirection = (sbyte)(-direction);
			if (Main.rand.Next(4) == 0)
			{
				Dust* ptr = Main.dust.NewDust(27, ref aabb, 0.0, 0.0, 80);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 0.2f;
					ptr->velocity.Y *= 0.2f;
				}
			}
			if (ai1 == 1)
			{
				ai1 = 0;
				Main.harpNote = ai0;
				Main.PlaySound(2, aabb.X, aabb.Y, 26);
			}
		}

		private unsafe void IceBlockAI()
		{
			if (velocity.X == 0f && velocity.Y == 0f)
			{
				alpha = byte.MaxValue;
			}
			if (ai1 < 0)
			{
				if (velocity.X > 0f)
				{
					rotation += 0.3f;
				}
				else
				{
					rotation -= 0.3f;
				}
				int num = (aabb.X >> 4) - 1;
				int num2 = (aabb.X + width >> 4) + 2;
				int num3 = (aabb.Y >> 4) - 1;
				int num4 = (aabb.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.maxTilesX)
				{
					num2 = Main.maxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesY)
				{
					num4 = Main.maxTilesY;
				}
				int num5 = aabb.X + 4;
				int num6 = aabb.Y + 4;
				Vector2 vector = default(Vector2);
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.tile[i, j].active == 0)
						{
							continue;
						}
						int num7 = Main.tile[i, j].type;
						if (num7 != 127 && Main.tileSolidNotSolidTop[num7])
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if ((float)(num5 + 8) > vector.X && (float)num5 < vector.X + 16f && (float)(num6 + 8) > vector.Y && (float)num6 < vector.Y + 16f)
							{
								Kill();
							}
						}
					}
				}
				Dust* ptr = Main.dust.NewDust(67, ref aabb);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 0.3f;
					ptr->velocity.Y *= 0.3f;
				}
				return;
			}
			if (ai0 < 0f)
			{
				if (ai0 == -1f)
				{
					for (int k = 0; k < 8; k++)
					{
						Dust* ptr2 = Main.dust.NewDust(67, ref aabb, 0.0, 0.0, 0, default(Color), 1.1000000238418579);
						if (ptr2 == null)
						{
							break;
						}
						ptr2->noGravity = true;
						ptr2->velocity.X *= 1.3f;
						ptr2->velocity.Y *= 1.3f;
					}
				}
				else if (Main.rand.Next(32) == 0)
				{
					Dust* ptr3 = Main.dust.NewDust(67, ref aabb, 0.0, 0.0, 100);
					if (ptr3 != null)
					{
						ptr3->velocity.X *= 0.2f;
						ptr3->velocity.Y *= 0.2f;
					}
				}
				int num8 = aabb.X >> 4;
				int num9 = aabb.Y >> 4;
				if (Main.tile[num8, num9].active == 0)
				{
					Kill();
				}
				if ((ai0 -= 1f) <= -300f && isLocal() && Main.tile[num8, num9].type == 127 && Main.tile[num8, num9].active != 0)
				{
					WorldGen.KillTile(num8, num9);
					NetMessage.CreateMessage5(17, 0, num8, num9, 0);
					NetMessage.SendMessage();
					Kill();
				}
				return;
			}
			int num10 = (aabb.X >> 4) - 1;
			int num11 = (aabb.X + width >> 4) + 2;
			int num12 = (aabb.Y >> 4) - 1;
			int num13 = (aabb.Y + height >> 4) + 2;
			if (num10 < 0)
			{
				num10 = 0;
			}
			if (num11 > Main.maxTilesX)
			{
				num11 = Main.maxTilesX;
			}
			if (num12 < 0)
			{
				num12 = 0;
			}
			if (num13 > Main.maxTilesY)
			{
				num13 = Main.maxTilesY;
			}
			int num14 = aabb.X + 4;
			int num15 = aabb.Y + 4;
			Vector2 vector2 = default(Vector2);
			for (int l = num10; l < num11; l++)
			{
				for (int m = num12; m < num13; m++)
				{
					if (Main.tile[l, m].active != 0 && Main.tile[l, m].type != 127 && Main.tileSolidNotSolidTop[Main.tile[l, m].type])
					{
						vector2.X = l * 16;
						vector2.Y = m * 16;
						if ((float)(num14 + 8) > vector2.X && (float)num14 < vector2.X + 16f && (float)(num15 + 8) > vector2.Y && (float)num15 < vector2.Y + 16f)
						{
							Kill();
						}
					}
				}
			}
			if (lavaWet)
			{
				Kill();
			}
			if (active == 0)
			{
				return;
			}
			Dust* ptr4 = Main.dust.NewDust(67, ref aabb);
			if (ptr4 != null)
			{
				ptr4->noGravity = true;
				ptr4->velocity.X *= 0.3f;
				ptr4->velocity.Y *= 0.3f;
			}
			int num16 = (int)ai0;
			int num17 = ai1;
			if (velocity.X > 0f)
			{
				rotation += 0.3f;
			}
			else
			{
				rotation -= 0.3f;
			}
			if (!isLocal())
			{
				return;
			}
			int num18 = aabb.X + (width >> 1) >> 4;
			int num19 = aabb.Y + (height >> 1) >> 4;
			if ((num18 == num16 && num19 == num17) || (((velocity.X <= 0f && num18 <= num16) || (velocity.X >= 0f && num18 >= num16)) && ((velocity.Y <= 0f && num19 <= num17) || (velocity.Y >= 0f && num19 >= num17))))
			{
				if (WorldGen.PlaceTile(num16, num17, 127, mute: false, forced: false, owner))
				{
					NetMessage.CreateMessage5(17, 1, (int)ai0, ai1, 127);
					NetMessage.SendMessage();
					damage = 0;
					ai0 = -1f;
					velocity.X = 0f;
					velocity.Y = 0f;
					alpha = byte.MaxValue;
					position.X = (aabb.X = num16 * 16);
					position.Y = (aabb.Y = num17 * 16);
					netUpdate = true;
				}
				else
				{
					ai1 = -1;
				}
			}
		}

		private unsafe void FlameAI()
		{
			if (timeLeft > 60)
			{
				timeLeft = 60;
			}
			if (ai0 > 7f)
			{
				float num = 1f;
				if (ai0 == 8f)
				{
					num = 0.25f;
				}
				else if (ai0 == 9f)
				{
					num = 0.5f;
				}
				else if (ai0 == 10f)
				{
					num = 0.75f;
				}
				ai0 += 1f;
				int num2 = (type == 101) ? 75 : 6;
				if (num2 == 6 || Main.rand.Next(3) == 0)
				{
					Dust* ptr = Main.dust.NewDust(num2, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100);
					if (ptr != null)
					{
						if (Main.rand.Next(3) != 0 || (num2 == 75 && Main.rand.Next(3) == 0))
						{
							ptr->noGravity = true;
							ptr->scale *= 3f;
							ptr->velocity.X *= 2f;
							ptr->velocity.Y *= 2f;
						}
						ptr->scale *= num * 1.5f;
						ptr->velocity.X *= 1.2f;
						ptr->velocity.Y *= 1.2f;
						if (num2 == 75)
						{
							ptr->velocity.X += velocity.X;
							ptr->velocity.Y += velocity.Y;
							if (!ptr->noGravity)
							{
								ptr->velocity.X *= 0.5f;
								ptr->velocity.Y *= 0.5f;
							}
						}
					}
				}
			}
			else
			{
				ai0 += 1f;
			}
			rotation += 0.3f * (float)direction;
		}

		private unsafe void CrystalShardAI()
		{
			light = scale * 0.5f;
			rotation += velocity.X * 0.2f;
			ai1++;
			if (type == 94)
			{
				if (Main.rand.Next(4) == 0)
				{
					Dust* ptr = Main.dust.NewDust(70, ref aabb);
					if (ptr != null)
					{
						ptr->noGravity = true;
						ptr->velocity.X *= 0.5f;
						ptr->velocity.Y *= 0.5f;
						ptr->scale *= 0.9f;
					}
				}
				velocity.X *= 0.985f;
				velocity.Y *= 0.985f;
				if (ai1 > 130)
				{
					scale -= 0.05f;
					if ((double)scale <= 0.2)
					{
						scale = 0.2f;
						Kill();
					}
				}
				return;
			}
			velocity.X *= 0.96f;
			velocity.Y *= 0.96f;
			if (ai1 > 15)
			{
				scale -= 0.05f;
				if ((double)scale <= 0.2)
				{
					scale = 0.2f;
					Kill();
				}
			}
		}

		private void BoulderAI()
		{
			if (ai0 != 0f && velocity.Y <= 0f && velocity.X == 0f)
			{
				int i = aabb.X - 8 >> 4;
				int num = aabb.Y >> 4;
				bool flag = WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
				i = aabb.X + width + 8 >> 4;
				bool flag2 = flag || WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
				if (flag)
				{
					velocity.X = 0.5f;
				}
				else if (flag2)
				{
					velocity.X = -0.5f;
				}
				else
				{
					i = aabb.X - 8 - 16 >> 4;
					num = aabb.Y >> 4;
					flag = (WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1));
					i = aabb.X + width + 8 + 16 >> 4;
					flag2 = (flag || WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1));
					if (flag)
					{
						velocity.X = 0.5f;
					}
					else if (flag2)
					{
						velocity.X = -0.5f;
					}
					else
					{
						i = aabb.X + 4 >> 4;
						num = aabb.Y + height + 8 >> 4;
						if (!WorldGen.SolidTile(i, num) && !WorldGen.SolidTile(i, num + 1))
						{
							velocity.X = 0.5f;
						}
						else
						{
							velocity.X = -0.5f;
						}
					}
				}
			}
			rotation += velocity.X * 0.06f;
			ai0 = 1f;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
			else if (velocity.Y <= 6f)
			{
				if (velocity.X > 0f && velocity.X < 7f)
				{
					velocity.X += 0.05f;
				}
				else if (velocity.X < 0f && velocity.X > -7f)
				{
					velocity.X -= 0.05f;
				}
			}
			velocity.Y += 0.3f;
		}

		public unsafe void Kill()
		{
			if (active == 0)
			{
				return;
			}
			timeLeft = 0;
			int num = aabb.X = (int)position.X;
			int num2 = aabb.Y = (int)position.Y;
			if (type == 1 || type == 81 || type == 98)
			{
				Main.PlaySound(0, num, num2);
				for (int i = 0; i < 8; i++)
				{
					Main.dust.NewDust(7, ref aabb);
				}
			}
			else if (type == 93)
			{
				Main.PlaySound(0, num, num2);
				for (int j = 0; j < 8; j++)
				{
					Dust* ptr = Main.dust.NewDust(57, ref aabb, 0.0, 0.0, 100, default(Color), 0.5);
					if (ptr == null)
					{
						break;
					}
					ptr->velocity *= 2f;
				}
			}
			else if (type == 99)
			{
				Main.PlaySound(0, num, num2);
				for (int k = 0; k < 24; k++)
				{
					Dust* ptr2 = Main.dust.NewDust(1, ref aabb);
					if (ptr2 == null)
					{
						break;
					}
					if (Main.rand.Next(2) == 0)
					{
						ptr2->scale *= 1.4f;
					}
					velocity.X *= 1.9f;
					velocity.Y *= 1.9f;
				}
			}
			else if (type == 91 || type == 92)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int l = 0; l < 8; l++)
				{
					Main.dust.NewDust(58, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2000000476837158);
				}
				for (int m = 0; m < 3; m++)
				{
					Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
				}
				if (type == 12 && damage < 500)
				{
					for (int n = 0; n < 8; n++)
					{
						Main.dust.NewDust(57, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2000000476837158);
					}
					for (int num3 = 0; num3 < 3; num3++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
					}
				}
				if ((type == 91 || (type == 92 && ai0 > 0f)) && isLocal())
				{
					int num4 = NewClonedProjectile(92);
					if (num4 >= 0)
					{
						float num5 = Main.rand.Next(-400, 400);
						float num6 = -Main.rand.Next(600, 900);
						Main.projectile[num4].position.X += num5;
						Main.projectile[num4].position.Y += num6;
						float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
						num7 = 22f / num7;
						num5 *= num7;
						num6 *= num7;
						Main.projectile[num4].velocity.X = num5;
						Main.projectile[num4].velocity.Y = num6;
						if (type == 91)
						{
							Main.projectile[num4].damage >>= 1;
							Main.projectile[num4].ai0 = 1f;
						}
						Main.projectile[num4].ai1 = num2;
						NetMessage.SendProjectile(num4);
					}
				}
			}
			else if (type == 89)
			{
				Main.PlaySound(0, num, num2);
				for (int num8 = 0; num8 < 3; num8++)
				{
					Dust* ptr3 = Main.dust.NewDust(68, ref aabb);
					if (ptr3 == null)
					{
						break;
					}
					ptr3->noGravity = true;
					ptr3->velocity.X *= 1.5f;
					ptr3->velocity.Y *= 1.5f;
					ptr3->scale *= 0.9f;
				}
				if (isLocal())
				{
					for (int num9 = 0; num9 < 3; num9++)
					{
						float num10 = (0f - velocity.X) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
						float num11 = (0f - velocity.Y) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
						NewProjectile(position.X + num10, position.Y + num11, num10, num11, 90, (int)((double)damage * 0.6), 0f, owner);
					}
				}
			}
			else if (type == 80)
			{
				if (ai0 >= 0f)
				{
					Main.PlaySound(2, num, num2, 27);
					for (int num12 = 0; num12 < 8; num12++)
					{
						Main.dust.NewDust(67, ref aabb);
					}
				}
				int num13 = num >> 4;
				int num14 = num2 >> 4;
				if (Main.tile[num13, num14].type == 127 && Main.tile[num13, num14].active != 0)
				{
					WorldGen.KillTile(num13, num14);
				}
			}
			else if (type == 76 || type == 77 || type == 78)
			{
				for (int num15 = 0; num15 < 4; num15++)
				{
					Dust* ptr4 = Main.dust.NewDust(27, ref aabb, 0.0, 0.0, 80, default(Color), 1.5);
					if (ptr4 == null)
					{
						break;
					}
					ptr4->noGravity = true;
				}
			}
			else if (type == 55)
			{
				for (int num16 = 0; num16 < 4; num16++)
				{
					Dust* ptr5 = Main.dust.NewDust(18, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
					if (ptr5 == null)
					{
						break;
					}
					ptr5->noGravity = true;
				}
			}
			else if (type == 51)
			{
				Main.PlaySound(0, num, num2);
				for (int num17 = 0; num17 < 4; num17++)
				{
					Main.dust.NewDust(0, ref aabb, 0.0, 0.0, 0, default(Color), 0.699999988079071);
				}
			}
			else if (type == 2 || type == 82)
			{
				Main.PlaySound(0, num, num2);
				for (int num18 = 0; num18 < 16; num18++)
				{
					Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100);
				}
			}
			else if (type == 103)
			{
				Main.PlaySound(0, num, num2);
				for (int num19 = 0; num19 < 14; num19++)
				{
					Dust* ptr6 = Main.dust.NewDust(75, ref aabb, 0.0, 0.0, 100);
					if (ptr6 == null)
					{
						break;
					}
					if (Main.rand.Next(2) == 0)
					{
						ptr6->scale *= 2.5f;
						ptr6->noGravity = true;
						ptr6->velocity.X *= 5f;
						ptr6->velocity.Y *= 5f;
					}
				}
			}
			else if (type == 3 || type == 48 || type == 54)
			{
				Main.PlaySound(0, num, num2);
				for (int num20 = 0; num20 < 7; num20++)
				{
					Main.dust.NewDust(1, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75);
				}
			}
			else if (type == 4)
			{
				Main.PlaySound(0, num, num2);
				for (int num21 = 0; num21 < 7; num21++)
				{
					Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 150, default(Color), 1.1000000238418579);
				}
			}
			else if (type == 5)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num22 = 0; num22 < 48; num22++)
				{
					int num23;
					switch (Main.rand.Next(3))
					{
					case 0:
						num23 = 15;
						break;
					case 1:
						num23 = 57;
						break;
					default:
						num23 = 58;
						break;
					}
					Main.dust.NewDust(num23, ref aabb, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.5);
				}
			}
			else if (type == 9 || type == 12)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num24 = 0; num24 < 8; num24++)
				{
					Main.dust.NewDust(58, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2000000476837158);
				}
				for (int num25 = 0; num25 < 3; num25++)
				{
					Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
				}
				if (type == 12 && damage < 100)
				{
					for (int num26 = 0; num26 < 8; num26++)
					{
						Main.dust.NewDust(57, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2000000476837158);
					}
					for (int num27 = 0; num27 < 3; num27++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
					}
				}
			}
			else if (type == 14 || type == 20 || type == 36 || type == 83 || type == 84 || type == 100 || type == 110)
			{
				Collision.HitTiles(position, velocity, width, height);
				Main.PlaySound(2, num, num2, 10);
			}
			else if (type == 15 || type == 34)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num28 = 0; num28 < 16; num28++)
				{
					Dust* ptr7 = Main.dust.NewDust(6, ref aabb, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default(Color), 2.0);
					if (ptr7 == null)
					{
						break;
					}
					ptr7->noGravity = true;
					ptr7->velocity.X *= 2f;
					ptr7->velocity.Y *= 2f;
					ptr7 = Main.dust.NewDust(6, ref aabb, velocity.X * -0.2f, velocity.Y * -0.2f, 100);
					if (ptr7 == null)
					{
						break;
					}
					ptr7->velocity.X *= 2f;
					ptr7->velocity.Y *= 2f;
				}
			}
			else if (type == 95 || type == 96)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num29 = 0; num29 < 16; num29++)
				{
					Dust* ptr8 = Main.dust.NewDust(75, ref aabb, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default(Color), 2f * scale);
					if (ptr8 == null)
					{
						break;
					}
					ptr8->noGravity = true;
					ptr8->velocity.X *= 2f;
					ptr8->velocity.Y *= 2f;
					ptr8 = Main.dust.NewDust(75, ref aabb, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default(Color), 1f * scale);
					if (ptr8 == null)
					{
						break;
					}
					ptr8->velocity.X *= 2f;
					ptr8->velocity.Y *= 2f;
				}
			}
			else if (type == 79)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num30 = 0; num30 < 12; num30++)
				{
					Dust* ptr9 = Main.dust.NewDust(66, ref aabb, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.0);
					if (ptr9 == null)
					{
						break;
					}
					ptr9->noGravity = true;
					ptr9->velocity.X *= 4f;
					ptr9->velocity.Y *= 4f;
				}
			}
			else if (type == 16)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num31 = 0; num31 < 12; num31++)
				{
					Dust* ptr10 = Main.dust.NewDust((int)(position.X - velocity.X), (int)(position.Y - velocity.Y), width, height, 15, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr10 == null)
					{
						break;
					}
					ptr10->noGravity = true;
					ptr10->velocity.X *= 2f;
					ptr10->velocity.Y *= 2f;
					Main.dust.NewDust((int)(position.X - velocity.X), (int)(position.Y - velocity.Y), width, height, 15, 0.0, 0.0, 100);
				}
			}
			else if (type == 17)
			{
				Main.PlaySound(0, num, num2);
				for (int num32 = 0; num32 < 2; num32++)
				{
					Main.dust.NewDust(0, ref aabb);
				}
			}
			else if (type == 31 || type == 42)
			{
				Main.PlaySound(0, num, num2);
				for (int num33 = 0; num33 < 2; num33++)
				{
					Dust* ptr11 = Main.dust.NewDust(32, ref aabb);
					if (ptr11 == null)
					{
						break;
					}
					ptr11->velocity.X *= 0.6f;
					ptr11->velocity.Y *= 0.6f;
				}
			}
			else if (type == 109)
			{
				Main.PlaySound(0, num, num2);
				for (int num34 = 0; num34 < 3; num34++)
				{
					Dust* ptr12 = Main.dust.NewDust(51, ref aabb, 0.0, 0.0, 0, default(Color), 0.60000002384185791);
					if (ptr12 == null)
					{
						break;
					}
					ptr12->velocity.X *= 0.6f;
					ptr12->velocity.Y *= 0.6f;
				}
			}
			else if (type == 39)
			{
				Main.PlaySound(0, num, num2);
				for (int num35 = 0; num35 < 3; num35++)
				{
					Dust* ptr13 = Main.dust.NewDust(38, ref aabb);
					if (ptr13 == null)
					{
						break;
					}
					ptr13->velocity.X *= 0.6f;
					ptr13->velocity.Y *= 0.6f;
				}
			}
			else if (type == 71)
			{
				Main.PlaySound(0, num, num2);
				for (int num36 = 0; num36 < 3; num36++)
				{
					Dust* ptr14 = Main.dust.NewDust(53, ref aabb);
					if (ptr14 == null)
					{
						break;
					}
					ptr14->velocity.X *= 0.6f;
					ptr14->velocity.Y *= 0.6f;
				}
			}
			else if (type == 40)
			{
				Main.PlaySound(0, num, num2);
				for (int num37 = 0; num37 < 3; num37++)
				{
					Dust* ptr15 = Main.dust.NewDust(36, ref aabb);
					if (ptr15 == null)
					{
						break;
					}
					ptr15->velocity.X *= 0.6f;
					ptr15->velocity.Y *= 0.6f;
				}
			}
			else if (type == 21)
			{
				Main.PlaySound(0, num, num2);
				for (int num38 = 0; num38 < 8; num38++)
				{
					Main.dust.NewDust(26, ref aabb, 0.0, 0.0, 0, default(Color), 0.800000011920929);
				}
			}
			else if (type == 24)
			{
				for (int num39 = 0; num39 < 6; num39++)
				{
					Main.dust.NewDust(1, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75);
				}
			}
			else if (type == 27)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num40 = 0; num40 < 20; num40++)
				{
					Dust* ptr16 = Main.dust.NewDust(29, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default(Color), 3.0);
					if (ptr16 == null)
					{
						break;
					}
					ptr16->noGravity = true;
					Main.dust.NewDust(29, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default(Color), 2.0);
				}
			}
			else if (type == 38)
			{
				for (int num41 = 0; num41 < 6; num41++)
				{
					Main.dust.NewDust(42, ref aabb, velocity.X * 0.1f, velocity.Y * 0.1f);
				}
			}
			else if (type == 44 || type == 45)
			{
				Main.PlaySound(2, num, num2, 10);
				for (int num42 = 0; num42 < 18; num42++)
				{
					Dust* ptr17 = Main.dust.NewDust(27, ref aabb, velocity.X, velocity.Y, 100, default(Color), 1.7000000476837158);
					if (ptr17 == null)
					{
						break;
					}
					ptr17->noGravity = true;
					Main.dust.NewDust(27, ref aabb, velocity.X, velocity.Y, 100);
				}
			}
			else if (type == 41 || type == 114)
			{
				Main.PlaySound(2, num, num2, 14);
				for (int num43 = 0; num43 < 6; num43++)
				{
					Dust* ptr18 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr18 == null)
					{
						break;
					}
				}
				int num44 = (type == 114) ? 64 : 6;
				for (int num45 = 0; num45 < 3; num45++)
				{
					Dust* ptr18 = Main.dust.NewDust(num44, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr18 == null)
					{
						break;
					}
					ptr18->noGravity = true;
					ptr18->velocity.X *= 3f;
					ptr18->velocity.Y *= 3f;
					ptr18 = Main.dust.NewDust(num44, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr18 == null)
					{
						break;
					}
					ptr18->velocity.X *= 2f;
					ptr18->velocity.Y *= 2f;
				}
				int num46 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num46].velocity *= 0.4f;
				Main.gore[num46].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
				Main.gore[num46].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
				num46 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num46].velocity *= 0.4f;
				Main.gore[num46].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
				Main.gore[num46].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
				if (isLocal())
				{
					penetrate = -1;
					position.X += width >> 1;
					position.Y += height >> 1;
					aabb.Width = (width = 64);
					aabb.Height = (height = 64);
					position.X -= width >> 1;
					position.Y -= height >> 1;
					num = (aabb.X = (int)position.X);
					num2 = (aabb.Y = (int)position.Y);
					Damage();
				}
			}
			else if (type == 28 || type == 30 || type == 37 || type == 75 || type == 102)
			{
				Main.PlaySound(2, num, num2, 14);
				position.X += width >> 1;
				position.Y += height >> 1;
				aabb.Width = (width = 22);
				aabb.Height = (height = 22);
				position.X -= width >> 1;
				position.Y -= height >> 1;
				num = (aabb.X = (int)position.X);
				num2 = (aabb.Y = (int)position.Y);
				for (int num47 = 0; num47 < 16; num47++)
				{
					Dust* ptr19 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr19 == null)
					{
						break;
					}
					ptr19->velocity.X *= 1.4f;
					ptr19->velocity.Y *= 1.4f;
				}
				for (int num48 = 0; num48 < 7; num48++)
				{
					Dust* ptr20 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr20 == null)
					{
						break;
					}
					ptr20->noGravity = true;
					ptr20->velocity.X *= 5f;
					ptr20->velocity.Y *= 5f;
					ptr20 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr20 == null)
					{
						break;
					}
					ptr20->velocity.X *= 3f;
					ptr20->velocity.Y *= 3f;
				}
				int num49 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num49].velocity *= 0.4f;
				Main.gore[num49].velocity.X += 1f;
				Main.gore[num49].velocity.Y += 1f;
				num49 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num49].velocity *= 0.4f;
				Main.gore[num49].velocity.X -= 1f;
				Main.gore[num49].velocity.Y += 1f;
				num49 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num49].velocity *= 0.4f;
				Main.gore[num49].velocity.X += 1f;
				Main.gore[num49].velocity.Y -= 1f;
				num49 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num49].velocity *= 0.4f;
				Main.gore[num49].velocity.X -= 1f;
				Main.gore[num49].velocity.Y -= 1f;
			}
			else if (type == 29 || type == 108)
			{
				Main.PlaySound(2, num, num2, 14);
				if (type == 29)
				{
					position.X += (width >> 1) - 100;
					position.Y += (height >> 1) - 100;
					num = (aabb.X = (int)position.X);
					num2 = (aabb.Y = (int)position.Y);
					aabb.Width = (width = 200);
					aabb.Height = (height = 200);
				}
				for (int num50 = 0; num50 < 40; num50++)
				{
					Dust* ptr21 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr21 == null)
					{
						break;
					}
					ptr21->velocity.X *= 1.4f;
					ptr21->velocity.Y *= 1.4f;
				}
				for (int num51 = 0; num51 < 64; num51++)
				{
					Dust* ptr22 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 3.0);
					if (ptr22 == null)
					{
						break;
					}
					ptr22->noGravity = true;
					ptr22->velocity.X *= 5f;
					ptr22->velocity.Y *= 5f;
					ptr22 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr22 == null)
					{
						break;
					}
					ptr22->velocity.X *= 3f;
					ptr22->velocity.Y *= 3f;
				}
				for (int num52 = 0; num52 < 2; num52++)
				{
					int num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num53].scale = 1.5f;
					Main.gore[num53].velocity.X += 1.5f;
					Main.gore[num53].velocity.Y += 1.5f;
					num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num53].scale = 1.5f;
					Main.gore[num53].velocity.X -= 1.5f;
					Main.gore[num53].velocity.Y += 1.5f;
					num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num53].scale = 1.5f;
					Main.gore[num53].velocity.X += 1.5f;
					Main.gore[num53].velocity.Y -= 1.5f;
					num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num53].scale = 1.5f;
					Main.gore[num53].velocity.X -= 1.5f;
					Main.gore[num53].velocity.Y -= 1.5f;
				}
				position.X += (width >> 1) - 5;
				position.Y += (height >> 1) - 5;
				num = (aabb.X = (int)position.X);
				num2 = (aabb.Y = (int)position.Y);
				aabb.Width = (width = 10);
				aabb.Height = (height = 10);
			}
			else if (type == 69)
			{
				Main.PlaySound(13, num, num2);
				for (int num54 = 0; num54 < 3; num54++)
				{
					Main.dust.NewDust(num, num2, width, height, 13);
				}
				for (int num55 = 0; num55 < 20; num55++)
				{
					Dust* ptr23 = Main.dust.NewDust(num, num2, width, height, 33, 0.0, -2.0, 0, default(Color), 1.1000000238418579);
					if (ptr23 == null)
					{
						break;
					}
					ptr23->alpha = 100;
					ptr23->velocity.X *= 4.5f;
					ptr23->velocity.Y *= 3f;
				}
			}
			else if (type == 70)
			{
				Main.PlaySound(13, num, num2);
				for (int num56 = 0; num56 < 3; num56++)
				{
					Main.dust.NewDust(num, num2, width, height, 13);
				}
				for (int num57 = 0; num57 < 20; num57++)
				{
					Dust* ptr24 = Main.dust.NewDust(num, num2, width, height, 52, 0.0, -2.0, 0, default(Color), 1.1000000238418579);
					if (ptr24 == null)
					{
						break;
					}
					ptr24->alpha = 100;
					ptr24->velocity.X *= 4.5f;
					ptr24->velocity.Y *= 3f;
				}
			}
			else if (type == 111 || (type >= 115 && type <= 119))
			{
				int num58 = Gore.NewGore(new Vector2(num - (width >> 1), num2 - (height >> 1)), default(Vector2), Main.rand.Next(11, 14), scale);
				Main.gore[num58].velocity *= 0.1f;
			}
			if (isLocal())
			{
				if (type == 28 || type == 29 || type == 37 || type == 75 || type == 108)
				{
					int num59 = 3;
					if (type == 29)
					{
						num59 = 7;
					}
					else if (type == 108)
					{
						num59 = 10;
					}
					int num60 = num >> 4;
					int num61 = num2 >> 4;
					int num62 = num60 - num59;
					int num63 = num60 + num59;
					int num64 = num61 - num59;
					int num65 = num61 + num59;
					if (num62 < 0)
					{
						num62 = 0;
					}
					if (num63 > Main.maxTilesX)
					{
						num63 = Main.maxTilesX;
					}
					if (num64 < 0)
					{
						num64 = 0;
					}
					if (num65 > Main.maxTilesY)
					{
						num65 = Main.maxTilesY;
					}
					bool flag = false;
					for (int num66 = num62; num66 <= num63; num66++)
					{
						for (int num67 = num64; num67 <= num65; num67++)
						{
							int num68 = Math.Abs(num66 - num60);
							int num69 = Math.Abs(num67 - num61);
							int num70 = num68 * num68 + num69 * num69;
							if (num70 < num59 * num59 && Main.tile[num66, num67].wall == 0)
							{
								flag = true;
								break;
							}
						}
					}
					for (int num71 = num62; num71 <= num63; num71++)
					{
						for (int num72 = num64; num72 <= num65; num72++)
						{
							int num73 = Math.Abs(num71 - num60);
							int num74 = Math.Abs(num72 - num61);
							int num75 = num73 * num73 + num74 * num74;
							if (num75 >= num59 * num59)
							{
								continue;
							}
							bool flag2 = true;
							if (Main.tile[num71, num72].active != 0)
							{
								int num76 = Main.tile[num71, num72].type;
								if (num76 == 21 || num76 == 26 || num76 == 107 || num76 == 108 || num76 == 111 || Main.tileDungeon[num76])
								{
									flag2 = false;
								}
								else if (num76 == 58 && !Main.hardMode)
								{
									flag2 = false;
								}
								else if (WorldGen.KillTile(num71, num72))
								{
									NetMessage.CreateMessage5(17, 0, num71, num72, 0);
									NetMessage.SendMessage();
								}
							}
							if (!flag2 || !flag)
							{
								continue;
							}
							for (int num77 = num71 - 1; num77 <= num71 + 1; num77++)
							{
								for (int num78 = num72 - 1; num78 <= num72 + 1; num78++)
								{
									if (Main.tile[num77, num78].wall > 0)
									{
										WorldGen.KillWall(num77, num78);
										if (Main.tile[num77, num78].wall == 0)
										{
											NetMessage.CreateMessage5(17, 2, num77, num78, 0);
											NetMessage.SendMessage();
										}
									}
								}
							}
						}
					}
				}
				NetMessage.CreateMessage2(29, identity, owner);
				NetMessage.SendMessage();
				int num79 = -1;
				if (aiStyle == 10)
				{
					int num80 = 0;
					int num81 = 0;
					switch (type)
					{
					case 31:
					case 42:
						num80 = 53;
						break;
					case 39:
						num80 = 59;
						num81 = 176;
						break;
					case 40:
						num80 = 57;
						num81 = 172;
						break;
					case 56:
					case 65:
						num80 = 112;
						break;
					case 67:
					case 68:
						num80 = 116;
						break;
					case 71:
						num80 = 123;
						break;
					case 109:
						num80 = 147;
						break;
					default:
						num79 = Item.NewItem(num, num2, width, height, 2);
						break;
					}
					if (num80 > 0)
					{
						int num82 = num + (width >> 1) >> 4;
						int num83 = num2 + (width >> 1) >> 4;
						if (Main.tile[num82, num83].active == 0 && WorldGen.PlaceTile(num82, num83, num80, mute: false, forced: true))
						{
							NetMessage.CreateMessage5(17, 1, num82, num83, num80);
							NetMessage.SendMessage();
						}
						else if (num81 > 0)
						{
							num79 = Item.NewItem(num, num2, width, height, num81);
						}
					}
				}
				if (type == 1)
				{
					if (Main.rand.Next(3) == 0)
					{
						num79 = Item.NewItem(num, num2, width, height, 40);
					}
				}
				else if (type == 2)
				{
					if (Main.rand.Next(3) == 0)
					{
						num79 = ((Main.rand.Next(3) != 0) ? Item.NewItem(num, num2, width, height, 40) : Item.NewItem(num, num2, width, height, 41));
					}
				}
				else if (type == 103)
				{
					if (Main.rand.Next(6) == 0)
					{
						num79 = ((Main.rand.Next(3) != 0) ? Item.NewItem(num, num2, width, height, 40) : Item.NewItem(num, num2, width, height, 545));
					}
				}
				else if (type == 113)
				{
					if (Main.rand.Next(4) == 0)
					{
						num79 = Item.NewItem(num, num2, width, height, 616);
					}
				}
				else if (type == 91 && Main.rand.Next(6) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 516);
				}
				else if (type == 50 && Main.rand.Next(3) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 282);
				}
				else if (type == 53 && Main.rand.Next(3) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 286);
				}
				else if (type == 48 && Main.rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 279);
				}
				else if (type == 54 && Main.rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 287);
				}
				else if (type == 3 && Main.rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 42);
				}
				else if (type == 4 && Main.rand.Next(4) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 47);
				}
				else if (type == 12 && damage > 100)
				{
					num79 = Item.NewItem(num, num2, width, height, 75);
				}
				else if (type == 69 || type == 70)
				{
					int num84 = num + (width >> 1) >> 4;
					int num85 = num2 + (height >> 1) >> 4;
					for (int num86 = num84 - 4; num86 <= num84 + 4; num86++)
					{
						for (int num87 = num85 - 4; num87 <= num85 + 4; num87++)
						{
							if (Math.Abs(num86 - num84) + Math.Abs(num87 - num85) >= 6)
							{
								continue;
							}
							int num88 = Main.tile[num86, num87].type;
							int num89 = 0;
							if (type == 69)
							{
								switch (num88)
								{
								case 2:
								case 23:
									num89 = 109;
									break;
								case 1:
								case 25:
									num89 = 117;
									break;
								case 53:
								case 112:
									num89 = 116;
									break;
								}
							}
							else
							{
								switch (num88)
								{
								case 2:
								case 109:
									num89 = 23;
									break;
								case 1:
								case 117:
									num89 = 25;
									break;
								case 53:
								case 116:
									num89 = 112;
									break;
								}
							}
							if (num89 > 0)
							{
								Main.tile[num86, num87].type = (byte)num89;
								WorldGen.SquareTileFrame(num86, num87);
								NetMessage.SendTile(num86, num87);
							}
						}
					}
				}
				else if (type == 21 && Main.rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, 154);
				}
				if (num79 >= 0)
				{
					NetMessage.CreateMessage2(21, UI.main.myPlayer, num79);
					NetMessage.SendMessage();
				}
			}
			active = 0;
		}

		public Color GetAlpha(Color newColor)
		{
			if (type == 34 || type == 15 || type == 93 || type == 94 || type == 95 || type == 96 || (type == 102 && alpha < byte.MaxValue))
			{
				return new Color(200, 200, 200, 25);
			}
			if (type == 83 || type == 88 || type == 89 || type == 90 || type == 100 || type == 104)
			{
				if (alpha < 200)
				{
					return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
				}
				return default(Color);
			}
			if (type == 34 || type == 35 || type == 15 || type == 19 || type == 44 || type == 45)
			{
				return Color.White;
			}
			if (type == 79)
			{
				return default(Color);
			}
			int r;
			int g;
			int b;
			if (type == 9 || type == 15 || type == 34 || type == 50 || type == 53 || type == 76 || type == 77 || type == 78 || type == 92 || type == 91)
			{
				r = newColor.R - (int)alpha / 3;
				g = newColor.G - (int)alpha / 3;
				b = newColor.B - (int)alpha / 3;
			}
			else if (type == 16 || type == 18 || type == 44 || type == 45)
			{
				r = newColor.R;
				g = newColor.G;
				b = newColor.B;
			}
			else
			{
				if (type == 12 || type == 72 || type == 86 || type == 87)
				{
					return new Color(255, 255, 255, newColor.A - alpha);
				}
				r = newColor.R - alpha;
				g = newColor.G - alpha;
				b = newColor.B - alpha;
			}
			int num = newColor.A - alpha;
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}

		public unsafe void Draw(WorldView view)
		{
			Player player = Main.player[owner];
			Vector2 pos;
			if (type == 32)
			{
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num = player.position.X + 10f - vector.X;
				float num2 = player.position.Y + 21f - vector.Y;
				float rotCenter = (float)Math.Atan2(num2, num) - 1.57f;
				bool flag = true;
				if (num == 0f && num2 == 0f)
				{
					flag = false;
				}
				else
				{
					float num3 = (float)Math.Sqrt(num * num + num2 * num2);
					num3 = 8f / num3;
					num *= num3;
					num2 *= num3;
					vector.X -= num;
					vector.Y -= num2;
					num = player.position.X + 10f - vector.X;
					num2 = player.position.Y + 21f - vector.Y;
				}
				while (flag)
				{
					float num4 = num * num + num2 * num2;
					if (num4 < 784f)
					{
						flag = false;
						continue;
					}
					float num5 = 28f / (float)Math.Sqrt(num4);
					num *= num5;
					num2 *= num5;
					vector.X += num;
					vector.Y += num2;
					num = player.position.X + 10f - vector.X;
					num2 = player.position.Y + 21f - vector.Y;
					pos = vector;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(190, ref pos, view.lighting.GetColor((int)vector.X >> 4, (int)vector.Y >> 4), rotCenter);
				}
			}
			else if (type == 73)
			{
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num6 = player.position.X + 10f - vector2.X;
				float num7 = player.position.Y + 21f - vector2.Y;
				float rotCenter2 = (float)Math.Atan2(num7, num6) - 1.57f;
				bool flag2 = true;
				while (flag2)
				{
					float num8 = num6 * num6 + num7 * num7;
					if (num8 < 625f)
					{
						flag2 = false;
						continue;
					}
					float num9 = 12f / (float)Math.Sqrt(num8);
					num6 *= num9;
					num7 *= num9;
					vector2.X += num6;
					vector2.Y += num7;
					num6 = player.position.X + 10f - vector2.X;
					num7 = player.position.Y + 21f - vector2.Y;
					pos = vector2;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(193, ref pos, view.lighting.GetColor((int)vector2.X >> 4, (int)vector2.Y >> 4), rotCenter2);
				}
			}
			else if (type == 74)
			{
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num10 = player.position.X + 10f - vector3.X;
				float num11 = player.position.Y + 21f - vector3.Y;
				float rotCenter3 = (float)Math.Atan2(num11, num10) - 1.57f;
				bool flag3 = true;
				while (flag3)
				{
					float num12 = num10 * num10 + num11 * num11;
					if (num12 < 625f)
					{
						flag3 = false;
						continue;
					}
					float num13 = 12f / (float)Math.Sqrt(num12);
					num10 *= num13;
					num11 *= num13;
					vector3.X += num10;
					vector3.Y += num11;
					num10 = player.position.X + 10f - vector3.X;
					num11 = player.position.Y + 21f - vector3.Y;
					pos = vector3;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(194, ref pos, view.lighting.GetColor((int)vector3.X >> 4, (int)vector3.Y >> 4), rotCenter3);
				}
			}
			else if (aiStyle == 7)
			{
				Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num14 = player.position.X + 10f - vector4.X;
				float num15 = player.position.Y + 21f - vector4.Y;
				float rotCenter4 = (float)Math.Atan2(num15, num14) - 1.57f;
				bool flag4 = true;
				while (flag4)
				{
					float num16 = num14 * num14 + num15 * num15;
					if (num16 < 625f)
					{
						flag4 = false;
						continue;
					}
					float num17 = 12f / (float)Math.Sqrt(num16);
					num14 *= num17;
					num15 *= num17;
					vector4.X += num14;
					vector4.Y += num15;
					num14 = player.position.X + 10f - vector4.X;
					num15 = player.position.Y + 21f - vector4.Y;
					pos = vector4;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(198, ref pos, view.lighting.GetColor((int)vector4.X >> 4, (int)vector4.Y >> 4), rotCenter4);
				}
			}
			else if (aiStyle == 13)
			{
				float num18 = position.X + 8f;
				float num19 = position.Y + 2f;
				float x = velocity.X;
				float y = velocity.Y;
				float num20 = (float)Math.Sqrt(x * x + y * y);
				num20 = 20f / num20;
				if (ai0 == 0f)
				{
					num18 -= velocity.X * num20;
					num19 -= velocity.Y * num20;
				}
				else
				{
					num18 += velocity.X * num20;
					num19 += velocity.Y * num20;
				}
				Vector2 vector5 = new Vector2(num18, num19);
				x = player.position.X + 10f - vector5.X;
				y = player.position.Y + 21f - vector5.Y;
				float rotCenter5 = (float)Math.Atan2(y, x) - 1.57f;
				if (alpha == 0)
				{
					int num21 = -1;
					if (position.X + (float)(width >> 1) < player.position.X + 10f)
					{
						num21 = 1;
					}
					player.itemRotation = (float)Math.Atan2(y * (float)num21, x * (float)num21);
				}
				while (true)
				{
					float num22 = x * x + y * y;
					if (num22 < 625f)
					{
						break;
					}
					num22 = 12f / (float)Math.Sqrt(num22);
					x *= num22;
					y *= num22;
					vector5.X += x;
					vector5.Y += y;
					x = player.position.X + 10f - vector5.X;
					y = player.position.Y + 21f - vector5.Y;
					pos = vector5;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(198, ref pos, view.lighting.GetColor((int)vector5.X >> 4, (int)vector5.Y >> 4), rotCenter5);
				}
			}
			else if (aiStyle == 15)
			{
				Vector2 vector6 = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
				float num23 = player.position.X + 10f - vector6.X;
				float num24 = player.position.Y + 21f - vector6.Y;
				float rotCenter6 = (float)Math.Atan2(num24, num23) - 1.57f;
				if (alpha == 0)
				{
					int num25 = -1;
					if (aabb.X + (width >> 1) < player.aabb.X + 10)
					{
						num25 = 1;
					}
					player.itemRotation = (float)Math.Atan2(num24 * (float)num25, num23 * (float)num25);
				}
				bool flag5 = true;
				do
				{
					float num26 = num23 * num23 + num24 * num24;
					if (num26 < 625f)
					{
						flag5 = false;
						continue;
					}
					num26 = 12f / (float)Math.Sqrt(num26);
					num23 *= num26;
					num24 *= num26;
					vector6.X += num23;
					vector6.Y += num24;
					num23 = player.position.X + 10f - vector6.X;
					num24 = player.position.Y + 21f - vector6.Y;
					pos = vector6;
					pos.X -= view.screenPosition.X;
					pos.Y -= view.screenPosition.Y;
					int id = 188;
					if (type == 25)
					{
						id = 187;
					}
					else if (type == 35)
					{
						id = 191;
					}
					else if (type == 63)
					{
						id = 192;
					}
					SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos, view.lighting.GetColor((int)vector6.X >> 4, (int)vector6.Y >> 4), rotCenter6);
				}
				while (flag5);
			}
			Color newColor = (type == 14) ? Color.White : ((!hide) ? view.lighting.GetColor(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4) : view.lighting.GetColor(player.aabb.X + 10 >> 4, player.aabb.Y + 21 >> 4));
			int num27 = 1349 + type;
			int num28 = SpriteSheet<_sheetSprites>.src[num27].Width >> 1;
			int num29 = num28;
			int num30 = 0;
			if (type == 16)
			{
				num30 = 6;
			}
			else if (type == 17 || type == 31)
			{
				num30 = 2;
			}
			else if (type == 25 || type == 26 || type == 35 || type == 63)
			{
				num30 = 6;
				num29 -= 6;
			}
			else if (type == 28 || type == 37 || type == 75)
			{
				num30 = 8;
			}
			else if (type == 29)
			{
				num30 = 11;
			}
			else if (type == 43)
			{
				num30 = 4;
			}
			else if (type == 69 || type == 70)
			{
				num30 = 4;
				num29 += 4;
			}
			else if (type == 50 || type == 53)
			{
				num29 -= 8;
			}
			else if (type == 72 || type == 86 || type == 87)
			{
				num29 -= 16;
				num30 = 8;
			}
			else if (type == 74)
			{
				num29 -= 6;
			}
			else if (type == 99)
			{
				num30 = 1;
			}
			else if (type == 111 || (type >= 115 && type <= 119))
			{
				num30 = (projFrameH[type] >> 1) - 2;
				num29 -= 16;
			}
			SpriteEffects e = (spriteDirection == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			pos = new Vector2(position.X - (float)view.screenPosition.X + (float)num29, position.Y - (float)view.screenPosition.Y + (float)(height >> 1));
			Vector2 pivot = new Vector2(num28, (height >> 1) + num30);
			Color color = GetAlpha(newColor);
			int num31 = projFrameH[type];
			if (num31 > 0)
			{
				int sy = num31 * frame;
				SpriteSheet<_sheetSprites>.Draw(num27, ref pos, sy, num31, color, rotation, ref pivot, scale, e);
				return;
			}
			if (aiStyle == 19)
			{
				pos.X -= pivot.X;
				pos.X += width >> 1;
				if (spriteDirection == -1)
				{
					pivot.X *= 2f;
				}
				else
				{
					pivot.X = 0f;
				}
				pivot.Y = 0f;
				SpriteSheet<_sheetSprites>.Draw(num27, ref pos, color, rotation, ref pivot, scale, e);
				return;
			}
			if (type == 94 && ai1 > 6)
			{
				fixed (float* ptr = oldPos)
				{
					for (int i = 0; i < 10; i++)
					{
						Color c = color;
						float num32 = (float)(9 - i) * 0.111111112f;
						c.R = (byte)((float)(int)c.R * num32);
						c.G = (byte)((float)(int)c.G * num32);
						c.B = (byte)((float)(int)c.B * num32);
						c.A = (byte)((float)(int)c.A * num32);
						Vector2 pos2 = new Vector2(ptr[i << 1] - (float)view.screenPosition.X + (float)num29, ptr[(i << 1) + 1] - (float)view.screenPosition.Y + (float)(height >> 1));
						SpriteSheet<_sheetSprites>.Draw(num27, ref pos2, c, rotation, ref pivot, scale * num32, e);
					}
				}
			}
			SpriteSheet<_sheetSprites>.Draw(num27, ref pos, color, rotation, ref pivot, scale, e);
			if (type == 106)
			{
				color.R = 200;
				color.G = 200;
				color.B = 200;
				color.A = 0;
				SpriteSheet<_sheetSprites>.Draw(1084, ref pos, color, rotation, ref pivot, scale, e);
			}
		}
	}
}
