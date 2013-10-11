// Type: Terraria.Projectile
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using System;

namespace Terraria
{
  public struct Projectile
  {
    private static byte[] projFrameH = new byte[120];
    public static readonly byte[] petProj = new byte[6]
    {
      (byte) 111,
      (byte) 115,
      (byte) 116,
      (byte) 117,
      (byte) 118,
      (byte) 119
    };
    private static readonly Projectile.PetAnim[] petAnimIdle = new Projectile.PetAnim[6]
    {
      new Projectile.PetAnim(0, 0, (int) byte.MaxValue),
      new Projectile.PetAnim(0, 1, 24),
      new Projectile.PetAnim(0, 2, 2),
      new Projectile.PetAnim(0, 4, 4),
      new Projectile.PetAnim(0, 0, (int) byte.MaxValue),
      new Projectile.PetAnim(0, 0, (int) byte.MaxValue)
    };
    private static readonly Projectile.PetAnim[] petAnimMove = new Projectile.PetAnim[6]
    {
      new Projectile.PetAnim(0, 6, 6),
      new Projectile.PetAnim(0, 1, 14),
      new Projectile.PetAnim(0, 2, 1),
      new Projectile.PetAnim(0, 4, 3),
      new Projectile.PetAnim(2, 15, 4),
      new Projectile.PetAnim(0, 2, 14)
    };
    private static readonly Projectile.PetAnim[] petAnimFall = new Projectile.PetAnim[6]
    {
      new Projectile.PetAnim(4, 4, (int) byte.MaxValue),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue),
      new Projectile.PetAnim(0, 2, 1),
      new Projectile.PetAnim(0, 4, 3),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue),
      new Projectile.PetAnim(2, 2, (int) byte.MaxValue)
    };
    private static readonly Projectile.PetAnim[] petAnimJump = new Projectile.PetAnim[6]
    {
      new Projectile.PetAnim(6, 6, (int) byte.MaxValue),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue),
      new Projectile.PetAnim(0, 2, 1),
      new Projectile.PetAnim(0, 4, 3),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue),
      new Projectile.PetAnim(2, 2, (int) byte.MaxValue)
    };
    private static readonly Projectile.PetAnim[] petAnimFly = new Projectile.PetAnim[6]
    {
      new Projectile.PetAnim(7, 7, (int) byte.MaxValue),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue),
      new Projectile.PetAnim(0, 2, 1),
      new Projectile.PetAnim(0, 4, 3),
      new Projectile.PetAnim(8, 8, (int) byte.MaxValue),
      new Projectile.PetAnim(1, 1, (int) byte.MaxValue)
    };
    public static readonly short[] petItem = new short[6]
    {
      (short) 603,
      (short) 621,
      (short) 622,
      (short) 623,
      (short) 624,
      (short) 625
    };
    private static uint lastProjectileIndex = 0U;
    public static uint tombstoneTextIndex = 0U;
    public static string[] tombstoneText = new string[IntPtr(8)];
    public const int MAX_PROJECTILE_TYPES = 120;
    public const int MAX_PROJECTILES = 512;
    public const int NUM_OLD_POS = 10;
    public const uint TOMBSTONE_TEXT_QUEUE = 8U;
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

    static Projectile()
    {
    }

    public static void Initialize()
    {
      for (int index = 1; index < 120; ++index)
        Projectile.projFrameH[index] = (byte) 0;
      Projectile.projFrameH[72] = (byte) (SpriteSheet<_sheetSprites>.src[1421].Height / 4);
      Projectile.projFrameH[86] = (byte) (SpriteSheet<_sheetSprites>.src[1435].Height / 4);
      Projectile.projFrameH[87] = (byte) (SpriteSheet<_sheetSprites>.src[1436].Height / 4);
      Projectile.projFrameH[102] = (byte) (SpriteSheet<_sheetSprites>.src[1451].Height / 2);
      Projectile.projFrameH[111] = (byte) (SpriteSheet<_sheetSprites>.src[1460].Height / 8);
      Projectile.projFrameH[115] = (byte) (SpriteSheet<_sheetSprites>.src[1464].Height / 2);
      Projectile.projFrameH[116] = (byte) (SpriteSheet<_sheetSprites>.src[1465].Height / 3);
      Projectile.projFrameH[117] = (byte) (SpriteSheet<_sheetSprites>.src[1466].Height / 5);
      Projectile.projFrameH[118] = (byte) (SpriteSheet<_sheetSprites>.src[1467].Height / 16);
      Projectile.projFrameH[119] = (byte) (SpriteSheet<_sheetSprites>.src[1468].Height / 3);
    }

    public void Init()
    {
      this.active = (byte) 0;
      this.type = (byte) 0;
      this.direction = this.spriteDirection = (sbyte) 1;
    }

    public bool isLocal()
    {
      if ((int) this.owner != 8 || Main.netMode == 1)
        return Main.player[(int) this.owner].isLocal();
      else
        return true;
    }

    public unsafe void SetDefaults(int Type)
    {
      this.ai0 = 0.0f;
      this.ai1 = 0;
      this.localAI0 = (sbyte) 0;
      // ISSUE: reference to a compiler-generated field
      fixed (sbyte* numPtr = &this.playerImmune.FixedElementField)
      {
        for (int index = 0; index < 8; ++index)
          numPtr[index] = (sbyte) 0;
      }
      this.soundDelay = (short) 0;
      this.spriteDirection = (sbyte) 1;
      this.melee = false;
      this.ranged = false;
      this.magic = false;
      this.ownerHitCheck = false;
      this.hide = false;
      this.lavaWet = false;
      this.wetCount = (byte) 0;
      this.wet = false;
      this.ignoreWater = false;
      this.hostile = false;
      this.netUpdate = false;
      this.numUpdates = (sbyte) 0;
      this.maxUpdates = (byte) 0;
      this.identity = (ushort) 0;
      this.light = 0.0f;
      this.penetrate = (sbyte) 1;
      this.tileCollide = true;
      this.position = new Vector2();
      this.velocity = new Vector2();
      this.aiStyle = (byte) 0;
      this.alpha = (byte) 0;
      this.type = (byte) Type;
      this.active = (byte) 1;
      this.rotation = 0.0f;
      this.scale = 1f;
      this.owner = (byte) 8;
      this.timeLeft = 3600;
      this.friendly = true;
      this.damage = (short) 0;
      this.knockBack = 0.0f;
      if ((int) this.type == 1)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.ranged = true;
      }
      else if ((int) this.type == 2)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.light = 1f;
        this.ranged = true;
      }
      else if ((int) this.type == 3)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 4;
        this.ranged = true;
      }
      else if ((int) this.type == 4)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.light = 0.35f;
        this.penetrate = (sbyte) 5;
        this.ranged = true;
      }
      else if ((int) this.type == 5)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.light = 0.4f;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 40;
        this.alpha = (byte) 100;
        this.ignoreWater = true;
        this.ranged = true;
      }
      else if ((int) this.type == 6)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 3;
        this.penetrate = (sbyte) -1;
        this.melee = true;
        this.light = 0.4f;
      }
      else if ((int) this.type == 7 || (int) this.type == 8)
      {
        this.width = (ushort) 28;
        this.height = (ushort) 28;
        this.aiStyle = (byte) 4;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.alpha = byte.MaxValue;
        this.ignoreWater = true;
        this.magic = true;
      }
      else if ((int) this.type == 9)
      {
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 5;
        this.penetrate = (sbyte) 2;
        this.alpha = (byte) 50;
        this.scale = 0.8f;
        this.tileCollide = false;
        this.magic = true;
      }
      else if ((int) this.type == 10)
      {
        this.width = (ushort) 64;
        this.height = (ushort) 64;
        this.aiStyle = (byte) 6;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.alpha = byte.MaxValue;
        this.ignoreWater = true;
      }
      else if ((int) this.type == 11)
      {
        this.width = (ushort) 48;
        this.height = (ushort) 48;
        this.aiStyle = (byte) 6;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.alpha = byte.MaxValue;
        this.ignoreWater = true;
      }
      else if ((int) this.type == 12)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 5;
        this.penetrate = (sbyte) -1;
        this.alpha = (byte) 50;
        this.light = 1f;
      }
      else if ((int) this.type == 13)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 7;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.timeLeft *= 10;
      }
      else if ((int) this.type == 14)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 1;
        this.light = 0.5f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if ((int) this.type == 15)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 8;
        this.light = 0.8f;
        this.alpha = (byte) 100;
        this.magic = true;
      }
      else if ((int) this.type == 16)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 9;
        this.light = 0.8f;
        this.alpha = (byte) 100;
        this.magic = true;
      }
      else if ((int) this.type == 17)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
      }
      else if ((int) this.type == 18)
      {
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 11;
        this.light = 0.45f;
        this.alpha = (byte) 150;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 19)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 3;
        this.penetrate = (sbyte) -1;
        this.light = 1f;
        this.melee = true;
      }
      else if ((int) this.type == 20)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 3;
        this.light = 0.75f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 2;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if ((int) this.type == 21)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 2;
        this.scale = 1.2f;
        this.ranged = true;
      }
      else if ((int) this.type == 22)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 12;
        this.alpha = byte.MaxValue;
        this.penetrate = (sbyte) -1;
        this.maxUpdates = (byte) 2;
        this.ignoreWater = true;
        this.magic = true;
      }
      else if ((int) this.type == 23)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 13;
        this.penetrate = (sbyte) -1;
        this.alpha = byte.MaxValue;
        this.ranged = true;
      }
      else if ((int) this.type == 24)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 14;
        this.penetrate = (sbyte) 6;
        this.ranged = true;
      }
      else if ((int) this.type == 25)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 15;
        this.penetrate = (sbyte) -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 26)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 15;
        this.penetrate = (sbyte) -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 27)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 8;
        this.light = 0.8f;
        this.alpha = (byte) 200;
        this.timeLeft = 1800;
        this.penetrate = (sbyte) 10;
        this.magic = true;
      }
      else if ((int) this.type == 28)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 16;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 29)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 16;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 30)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 16;
        this.penetrate = (sbyte) -1;
        this.ranged = true;
      }
      else if ((int) this.type == 31)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 32)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 7;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.timeLeft = 36000;
      }
      else if ((int) this.type == 33)
      {
        this.width = (ushort) 28;
        this.height = (ushort) 28;
        this.aiStyle = (byte) 3;
        this.scale = 0.9f;
        this.penetrate = (sbyte) -1;
        this.melee = true;
      }
      else if ((int) this.type == 34)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 9;
        this.light = 0.8f;
        this.alpha = (byte) 100;
        this.penetrate = (sbyte) 1;
        this.magic = true;
      }
      else if ((int) this.type == 35)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 15;
        this.penetrate = (sbyte) -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 36)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 2;
        this.light = 0.6f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 1;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if ((int) this.type == 37)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 16;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
      }
      else if ((int) this.type == 38)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 0;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
        this.aiStyle = (byte) 1;
        this.tileCollide = true;
        this.friendly = false;
      }
      else if ((int) this.type == 39)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 40)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 41)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) -1;
        this.ranged = true;
        this.light = 0.3f;
      }
      else if ((int) this.type == 114)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) -1;
        this.ranged = true;
        this.light = 0.4f;
      }
      else if ((int) this.type == 42)
      {
        this.knockBack = 8f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.maxUpdates = (byte) 1;
      }
      else if ((int) this.type == 43)
      {
        this.knockBack = 12f;
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 17;
        this.penetrate = (sbyte) -1;
        this.friendly = false;
      }
      else if ((int) this.type == 44)
      {
        this.width = (ushort) 48;
        this.height = (ushort) 48;
        this.alpha = (byte) 100;
        this.light = 0.2f;
        this.aiStyle = (byte) 18;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
        this.tileCollide = true;
        this.scale = 0.9f;
        this.friendly = false;
      }
      else if ((int) this.type == 45)
      {
        this.width = (ushort) 48;
        this.height = (ushort) 48;
        this.alpha = (byte) 100;
        this.light = 0.2f;
        this.aiStyle = (byte) 18;
        this.penetrate = (sbyte) 5;
        this.tileCollide = true;
        this.scale = 0.9f;
        this.magic = true;
      }
      else if ((int) this.type == 46)
      {
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 47)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 48)
      {
        this.width = (ushort) 12;
        this.height = (ushort) 12;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 2;
        this.ranged = true;
      }
      else if ((int) this.type == 49)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.2f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 50)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 14;
        this.penetrate = (sbyte) -1;
        this.alpha = (byte) 75;
        this.light = 1f;
        this.timeLeft = 18000;
        this.friendly = false;
      }
      else if ((int) this.type == 51)
      {
        this.width = (ushort) 8;
        this.height = (ushort) 8;
        this.aiStyle = (byte) 1;
      }
      else if ((int) this.type == 52)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 3;
        this.penetrate = (sbyte) -1;
        this.melee = true;
      }
      else if ((int) this.type == 53)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 14;
        this.penetrate = (sbyte) -1;
        this.alpha = (byte) 75;
        this.light = 1f;
        this.timeLeft = 18000;
        this.tileCollide = false;
        this.friendly = false;
      }
      else if ((int) this.type == 54)
      {
        this.width = (ushort) 12;
        this.height = (ushort) 12;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 2;
        this.ranged = true;
      }
      else if ((int) this.type == 55)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 0;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) -1;
        this.aiStyle = (byte) 1;
        this.tileCollide = true;
      }
      else if ((int) this.type == 56)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 57)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 58)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.08f;
      }
      else if ((int) this.type == 59)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 60)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 61)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.16f;
      }
      else if ((int) this.type == 62)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 63)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 15;
        this.penetrate = (sbyte) -1;
        this.melee = true;
      }
      else if ((int) this.type == 64)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.25f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 65)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.penetrate = (sbyte) -1;
        this.maxUpdates = (byte) 1;
      }
      else if ((int) this.type == 66)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.27f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 67)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 68)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.penetrate = (sbyte) -1;
        this.maxUpdates = (byte) 1;
      }
      else if ((int) this.type == 69)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 1;
      }
      else if ((int) this.type == 70)
      {
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 1;
      }
      else if ((int) this.type == 71)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 72)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 27;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 73 || (int) this.type == 74)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 7;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.timeLeft = 36000;
        this.light = 0.4f;
      }
      else if ((int) this.type == 75)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 16;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 76 || (int) this.type == 77 || (int) this.type == 78)
      {
        if ((int) this.type == 76)
        {
          this.width = (ushort) 10;
          this.height = (ushort) 22;
        }
        else if ((int) this.type == 77)
        {
          this.width = (ushort) 18;
          this.height = (ushort) 24;
        }
        else
        {
          this.width = (ushort) 22;
          this.height = (ushort) 24;
        }
        this.aiStyle = (byte) 21;
        this.ranged = true;
        this.alpha = (byte) 100;
        this.light = 0.3f;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 180;
      }
      else if ((int) this.type == 79)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 9;
        this.light = 0.8f;
        this.alpha = byte.MaxValue;
        this.magic = true;
      }
      else if ((int) this.type == 80)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 22;
        this.magic = true;
        this.tileCollide = false;
        this.light = 0.5f;
      }
      else if ((int) this.type == 81)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.ranged = true;
      }
      else if ((int) this.type == 82)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.ranged = true;
      }
      else if ((int) this.type == 83)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) 3;
        this.light = 0.75f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 2;
        this.scale = 1.7f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if ((int) this.type == 84)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) 3;
        this.light = 0.75f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 2;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if ((int) this.type == 85)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 23;
        this.alpha = byte.MaxValue;
        this.penetrate = (sbyte) 3;
        this.maxUpdates = (byte) 2;
        this.magic = true;
      }
      else if ((int) this.type == 86)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 27;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 87)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 27;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if ((int) this.type == 88)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 3;
        this.light = 0.75f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 4;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if ((int) this.type == 89)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 1;
        this.light = 0.5f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if ((int) this.type == 90)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 24;
        this.penetrate = (sbyte) 1;
        this.light = 0.5f;
        this.alpha = (byte) 50;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
        this.tileCollide = false;
      }
      else if ((int) this.type == 91)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.ranged = true;
      }
      else if ((int) this.type == 92)
      {
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 5;
        this.penetrate = (sbyte) 2;
        this.alpha = (byte) 50;
        this.scale = 0.8f;
        this.tileCollide = false;
        this.magic = true;
      }
      else if ((int) this.type == 93)
      {
        this.light = 0.15f;
        this.width = (ushort) 12;
        this.height = (ushort) 12;
        this.aiStyle = (byte) 2;
        this.penetrate = (sbyte) 2;
        this.magic = true;
      }
      else if ((int) this.type == 94)
      {
        this.ignoreWater = true;
        this.width = (ushort) 8;
        this.height = (ushort) 8;
        this.aiStyle = (byte) 24;
        this.light = 0.5f;
        this.alpha = (byte) 50;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.magic = true;
        this.tileCollide = true;
        this.penetrate = (sbyte) 1;
        // ISSUE: reference to a compiler-generated field
        fixed (float* numPtr = &this.oldPos.FixedElementField)
        {
          for (int index = 19; index >= 0; --index)
            numPtr[index] = 0.0f;
        }
      }
      else if ((int) this.type == 95)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 8;
        this.light = 0.8f;
        this.alpha = (byte) 100;
        this.magic = true;
        this.penetrate = (sbyte) 2;
      }
      else if ((int) this.type == 96)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 8;
        this.hostile = true;
        this.friendly = false;
        this.light = 0.8f;
        this.alpha = (byte) 100;
        this.magic = true;
        this.penetrate = (sbyte) -1;
        this.scale = 0.9f;
        this.scale = 1.3f;
      }
      else if ((int) this.type == 97)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 98)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.ranged = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 99)
      {
        this.width = (ushort) 31;
        this.height = (ushort) 31;
        this.aiStyle = (byte) 25;
        this.hostile = true;
        this.ranged = true;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 100)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) 3;
        this.light = 0.75f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 2;
        this.scale = 1.8f;
        this.timeLeft = 1200;
        this.magic = true;
      }
      else if ((int) this.type == 101)
      {
        this.width = (ushort) 6;
        this.height = (ushort) 6;
        this.aiStyle = (byte) 23;
        this.hostile = true;
        this.friendly = false;
        this.alpha = byte.MaxValue;
        this.penetrate = (sbyte) -1;
        this.maxUpdates = (byte) 3;
        this.magic = true;
      }
      else if ((int) this.type == 102)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 16;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) -1;
        this.ranged = true;
      }
      else if ((int) this.type == 103)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.light = 1f;
        this.ranged = true;
      }
      else if ((int) this.type == 113)
      {
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 1;
        this.light = 1f;
        this.ranged = true;
      }
      else if ((int) this.type == 104)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.penetrate = (sbyte) 1;
        this.light = 0.5f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if ((int) this.type == 105)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.3f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 112)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 19;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.scale = 1.3f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if ((int) this.type == 106)
      {
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 3;
        this.penetrate = (sbyte) -1;
        this.melee = true;
        this.light = 0.4f;
      }
      else if ((int) this.type == 107)
      {
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 20;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.1f;
      }
      else if ((int) this.type == 108)
      {
        this.width = (ushort) 260;
        this.height = (ushort) 260;
        this.aiStyle = (byte) 16;
        this.hostile = true;
        this.penetrate = (sbyte) -1;
        this.tileCollide = false;
        this.alpha = byte.MaxValue;
        this.timeLeft = 2;
      }
      else if ((int) this.type == 109)
      {
        this.knockBack = 6f;
        this.width = (ushort) 10;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 10;
        this.hostile = true;
        this.friendly = false;
        this.scale = 0.9f;
        this.penetrate = (sbyte) -1;
      }
      else if ((int) this.type == 110)
      {
        this.width = (ushort) 4;
        this.height = (ushort) 4;
        this.aiStyle = (byte) 1;
        this.hostile = true;
        this.friendly = false;
        this.penetrate = (sbyte) -1;
        this.light = 0.5f;
        this.alpha = byte.MaxValue;
        this.maxUpdates = (byte) 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if ((int) this.type == 111)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 26;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
      }
      else if ((int) this.type == 115)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 10;
        this.aiStyle = (byte) 26;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.localAI0 = (sbyte) 1;
      }
      else if ((int) this.type == 116)
      {
        this.width = (ushort) 12;
        this.height = (ushort) 72;
        this.scale = 0.5f;
        this.aiStyle = (byte) 28;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.damage = (short) 2;
        this.localAI0 = (sbyte) 2;
      }
      else if ((int) this.type == 117)
      {
        this.width = (ushort) 16;
        this.height = (ushort) 48;
        this.aiStyle = (byte) 28;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.damage = (short) 4;
        this.localAI0 = (sbyte) 3;
      }
      else if ((int) this.type == 118)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 26;
        this.aiStyle = (byte) 26;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.damage = (short) 10;
        this.localAI0 = (sbyte) 4;
      }
      else if ((int) this.type == 119)
      {
        this.width = (ushort) 18;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 26;
        this.penetrate = (sbyte) -1;
        this.timeLeft = 18000;
        this.damage = (short) 8;
        this.localAI0 = (sbyte) 5;
      }
      else
        this.active = (byte) 0;
      this.width = (ushort) ((double) this.width * (double) this.scale);
      this.height = (ushort) ((double) this.height * (double) this.scale);
      this.aabb.Width = (int) this.width;
      this.aabb.Height = (int) this.height;
    }

    public static unsafe int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 8, bool send = true)
    {
      for (int index = 0; index < 512; ++index)
      {
        uint num = Projectile.lastProjectileIndex++ & 511U;
        fixed (Projectile* projectilePtr = &Main.projectile[(IntPtr) num])
        {
          if ((int) projectilePtr->active == 0)
          {
            projectilePtr->SetDefaults(Type);
            projectilePtr->position.X = X - (float) ((int) projectilePtr->width >> 1);
            projectilePtr->position.Y = Y - (float) ((int) projectilePtr->height >> 1);
            projectilePtr->aabb.X = (int) projectilePtr->position.X;
            projectilePtr->aabb.Y = (int) projectilePtr->position.Y;
            projectilePtr->owner = (byte) Owner;
            projectilePtr->velocity.X = SpeedX;
            projectilePtr->velocity.Y = SpeedY;
            if (Damage != 0)
              projectilePtr->damage = (short) Damage;
            projectilePtr->knockBack = KnockBack;
            projectilePtr->identity = (ushort) index;
            projectilePtr->wet = Collision.WetCollision(ref projectilePtr->position, (int) projectilePtr->width, (int) projectilePtr->height);
            if (projectilePtr->isLocal())
            {
              if (Type == 29)
                projectilePtr->timeLeft = 300;
              else if (Type == 28 || Type == 30 || (Type == 37 || Type == 75))
                projectilePtr->timeLeft = 180;
              if (send)
                NetMessage.SendProjectile((int) num, SendDataOptions.Reliable);
            }
            return (int) num;
          }
          else
          {
            // ISSUE: __unpin statement
            __unpin(projectilePtr);
          }
        }
      }
      return -1;
    }

    public unsafe int NewClonedProjectile(int newType)
    {
      for (int index = 0; index < 512; ++index)
      {
        uint num = Projectile.lastProjectileIndex++ & 511U;
        fixed (Projectile* projectilePtr = &Main.projectile[(IntPtr) num])
        {
          if ((int) projectilePtr->active == 0)
          {
            projectilePtr->SetDefaults(newType);
            projectilePtr->position = this.position;
            projectilePtr->aabb.X = (int) this.position.X;
            projectilePtr->aabb.Y = (int) this.position.Y;
            projectilePtr->owner = this.owner;
            projectilePtr->velocity = this.velocity;
            projectilePtr->damage = this.damage;
            projectilePtr->knockBack = this.knockBack;
            projectilePtr->identity = (ushort) index;
            projectilePtr->wet = this.wet;
            if (projectilePtr->isLocal())
            {
              if (newType == 29)
                projectilePtr->timeLeft = 300;
              else if (newType == 28 || newType == 30 || (newType == 37 || newType == 75))
                projectilePtr->timeLeft = 180;
            }
            return (int) num;
          }
          else
          {
            // ISSUE: __unpin statement
            __unpin(projectilePtr);
          }
        }
      }
      return -1;
    }

    public unsafe void Damage()
    {
      if ((int) this.type == 18 || (int) this.type == 72 || ((int) this.type == 86 || (int) this.type == 87) || ((int) this.type == 111 || (int) this.type == 115))
        return;
      Rectangle rectangle1 = this.aabb;
      if ((int) this.type == 85 || (int) this.type == 101)
      {
        rectangle1.X -= 30;
        rectangle1.Y -= 30;
        rectangle1.Width += 60;
        rectangle1.Height += 60;
      }
      if (this.friendly && this.isLocal())
      {
        if (((int) this.aiStyle == 16 || (int) this.type == 41 || (int) this.type == 114) && (this.timeLeft <= 1 || (int) this.type == 108))
        {
          Player player = Main.player[(int) this.owner];
          if ((int) player.active != 0 && !player.dead && (!player.immune && rectangle1.Intersects(player.aabb)))
          {
            this.direction = player.aabb.X + 10 >= this.aabb.X + ((int) this.width >> 1) ? (sbyte) 1 : (sbyte) -1;
            int num = Main.DamageVar((int) this.damage);
            player.ApplyProjectileBuff((int) this.type);
            player.Hurt(num, (int) this.direction, true, false, Lang.deathMsg((int) this.owner, 0, (int) this.type, -1), false);
            NetMessage.SendPlayerHurt((int) player.whoAmI, (int) this.direction, num, true, false, Lang.deathMsg((int) this.owner, 0, (int) this.type, -1));
          }
        }
        if ((int) this.type < 116 && (int) this.type != 69 && ((int) this.type != 70 && (int) this.type != 10) && (int) this.type != 11)
        {
          int num1 = this.aabb.X >> 4;
          int num2 = (this.aabb.X + (int) this.width >> 4) + 1;
          int num3 = this.aabb.Y >> 4;
          int num4 = (this.aabb.Y + (int) this.height >> 4) + 1;
          if (num1 < 0)
            num1 = 0;
          if (num2 > (int) Main.maxTilesX)
            num2 = (int) Main.maxTilesX;
          if (num3 < 0)
            num3 = 0;
          if (num4 > (int) Main.maxTilesY)
            num4 = (int) Main.maxTilesY;
          for (int index1 = num1; index1 < num2; ++index1)
          {
            for (int index2 = num3; index2 < num4; ++index2)
            {
              if (Main.tileCut[(int) Main.tile[index1, index2].type] && (int) Main.tile[index1, index2 + 1].type != 78)
              {
                WorldGen.KillTile(index1, index2);
                NetMessage.CreateMessage5(17, 0, index1, index2, 0, 0);
                NetMessage.SendMessage();
              }
            }
          }
        }
      }
      if (this.isLocal())
      {
        Player player = Main.player[(int) this.owner];
        if ((int) this.damage > 0)
        {
          for (int npcId = 0; npcId < 196; ++npcId)
          {
            NPC npc = Main.npc[npcId];
            if ((int) npc.active != 0 && !npc.dontTakeDamage && (this.friendly && (!npc.friendly || (int) npc.type == 22 && player.killGuide) || npc.friendly && this.hostile) && ((int) npc.immune[(int) this.owner] == 0 && ((int) this.type != 11 || (int) npc.type != 47 && (int) npc.type != 57) && (((int) this.type != 31 || (int) npc.type != 69) && (npc.noTileCollide || !this.ownerHitCheck || Collision.CanHit(ref player.aabb, ref npc.aabb))) && rectangle1.Intersects(npc.aabb)))
            {
              if ((int) this.aiStyle == 3)
              {
                if ((double) this.ai0 == 0.0)
                {
                  this.velocity.X = -this.velocity.X;
                  this.velocity.Y = -this.velocity.Y;
                  this.netUpdate = true;
                }
                this.ai0 = 1f;
              }
              else if ((int) this.aiStyle == 16)
              {
                if (this.timeLeft > 3)
                  this.timeLeft = 3;
                this.direction = npc.aabb.X + ((int) npc.width >> 1) >= this.aabb.X + ((int) this.width >> 1) ? (sbyte) 1 : (sbyte) -1;
              }
              if (((int) this.type == 41 || (int) this.type == 114) && this.timeLeft > 1)
                this.timeLeft = 1;
              bool flag = false;
              if (this.melee && Main.rand.Next(1, 101) <= (int) player.meleeCrit)
                flag = true;
              else if (this.ranged && Main.rand.Next(1, 101) <= (int) player.rangedCrit)
                flag = true;
              else if (this.magic && Main.rand.Next(1, 101) <= (int) player.magicCrit)
                flag = true;
              int num = Main.DamageVar((int) this.damage);
              npc.ApplyProjectileBuff((int) this.type);
              npc.StrikeNPC(num, this.knockBack, (int) this.direction, flag, false);
              NetMessage.SendNpcHurt(npcId, num, (double) this.knockBack, (int) this.direction, flag);
              if ((int) npc.active == 0 && player.ui != null)
              {
                StatisticEntry statisticEntryFromNetId = Statistics.GetStatisticEntryFromNetID(npc.netID);
                player.ui.Statistics.incStat(statisticEntryFromNetId);
              }
              if ((int) this.penetrate != 1)
                npc.immune[(int) this.owner] = (byte) 10;
              if ((int) this.penetrate <= 0 || (int) --this.penetrate != 0)
              {
                if ((int) this.aiStyle == 7)
                {
                  this.ai0 = 1f;
                  this.damage = (short) 0;
                  this.netUpdate = true;
                }
                else if ((int) this.aiStyle == 13)
                {
                  this.ai0 = 1f;
                  this.netUpdate = true;
                }
              }
              else
                break;
            }
          }
          if (player.hostile)
          {
            for (int playerId = 0; playerId < 8; ++playerId)
            {
              if (playerId != (int) this.owner && (int) Main.player[playerId].active != 0 && (!Main.player[playerId].dead && !Main.player[playerId].immune) && Main.player[playerId].hostile)
              {
                // ISSUE: reference to a compiler-generated field
                fixed (sbyte* numPtr1 = &this.playerImmune.FixedElementField)
                {
                  if ((int) numPtr1[playerId] <= 0)
                  {
                    // ISSUE: __unpin statement
                    __unpin(numPtr1);
                    if (((int) player.team == 0 || (int) player.team != (int) Main.player[playerId].team) && (!this.ownerHitCheck || Collision.CanHit(ref player.aabb, ref Main.player[playerId].aabb)) && rectangle1.Intersects(Main.player[playerId].aabb))
                    {
                      if ((int) this.aiStyle == 3)
                      {
                        if ((double) this.ai0 == 0.0)
                        {
                          this.velocity.X = -this.velocity.X;
                          this.velocity.Y = -this.velocity.Y;
                          this.netUpdate = true;
                        }
                        this.ai0 = 1f;
                      }
                      else if ((int) this.aiStyle == 16)
                      {
                        if (this.timeLeft > 3)
                          this.timeLeft = 3;
                        this.direction = Main.player[playerId].aabb.X + 10 >= this.aabb.X + ((int) this.width >> 1) ? (sbyte) 1 : (sbyte) -1;
                      }
                      if (((int) this.type == 41 || (int) this.type == 114) && this.timeLeft > 1)
                        this.timeLeft = 1;
                      bool flag = false;
                      if (this.melee && Main.rand.Next(1, 101) <= (int) player.meleeCrit)
                        flag = true;
                      int num = Main.DamageVar((int) this.damage);
                      if (!Main.player[playerId].immune)
                        Main.player[playerId].ApplyProjectileBuffPvP((int) this.type);
                      Main.player[playerId].Hurt(num, (int) this.direction, true, false, Lang.deathMsg((int) this.owner, 0, (int) this.type, -1), flag);
                      NetMessage.SendPlayerHurt(playerId, (int) this.direction, num, true, flag, Lang.deathMsg((int) this.owner, 0, (int) this.type, -1));
                      // ISSUE: reference to a compiler-generated field
                      fixed (sbyte* numPtr2 = &this.playerImmune.FixedElementField)
                        numPtr2[playerId] = (sbyte) 40;
                      if ((int) this.penetrate <= 0 || (int) --this.penetrate != 0)
                      {
                        if ((int) this.aiStyle == 7)
                        {
                          this.ai0 = 1f;
                          this.damage = (short) 0;
                          this.netUpdate = true;
                        }
                        else if ((int) this.aiStyle == 13)
                        {
                          this.ai0 = 1f;
                          this.netUpdate = true;
                        }
                      }
                      else
                        break;
                    }
                  }
                }
              }
            }
          }
        }
      }
      if ((int) this.type == 11 && Main.netMode != 1)
      {
        for (int index = 0; index < 196; ++index)
        {
          if ((int) Main.npc[index].active != 0)
          {
            if ((int) Main.npc[index].type == 46)
            {
              if (rectangle1.Intersects(Main.npc[index].aabb))
                Main.npc[index].Transform(47);
            }
            else if ((int) Main.npc[index].type == 55 && rectangle1.Intersects(Main.npc[index].aabb))
              Main.npc[index].Transform(57);
          }
        }
      }
      if (!this.hostile || (int) this.damage <= 0)
        return;
      for (int index = 0; index < 8; ++index)
      {
        Player player = Main.player[index];
        if (player.isLocal() && (int) player.active != 0 && (!player.dead && !player.immune))
        {
          Rectangle rectangle2 = new Rectangle((int) player.position.X, (int) player.position.Y, 20, 42);
          if (rectangle1.Intersects(rectangle2))
          {
            int num1 = (int) this.direction;
            int hitDirection = player.aabb.X + 10 >= this.aabb.X + ((int) this.width >> 1) ? 1 : -1;
            int num2 = Main.DamageVar((int) this.damage);
            if (!player.immune)
              player.ApplyProjectileBuff((int) this.type);
            player.Hurt(num2 * 2, hitDirection, false, false, Lang.deathMsg(-1, 0, (int) this.type, -1), false);
          }
        }
      }
    }

    public unsafe void Update(int i)
    {
      if (this.aabb.X <= 0 || this.aabb.X + (int) this.width >= Main.rightWorld || (this.aabb.Y <= 0 || this.aabb.Y + (int) this.height >= Main.bottomWorld))
      {
        this.active = (byte) 0;
      }
      else
      {
        this.whoAmI = (short) i;
        do
        {
          if ((int) this.soundDelay > 0)
            --this.soundDelay;
          this.netUpdate = false;
          // ISSUE: reference to a compiler-generated field
          fixed (sbyte* numPtr = &this.playerImmune.FixedElementField)
          {
            for (int index = 0; index < 8; ++index)
            {
              if ((int) numPtr[index] > 0)
              {
                IntPtr num1 = (IntPtr) (numPtr + index);
                int num2 = (int) (sbyte) ((int) *(sbyte*) num1 - 1);
                *(sbyte*) num1 = (sbyte) num2;
              }
            }
          }
          switch (this.aiStyle)
          {
            case (byte) 1:
              this.ArrowAI();
              break;
            case (byte) 2:
              this.ShurikenAI();
              break;
            case (byte) 3:
              this.BoomerangAI();
              break;
            case (byte) 4:
              this.VilethornAI();
              break;
            case (byte) 5:
              this.StarfuryAI();
              break;
            case (byte) 6:
              this.PowderAI();
              break;
            case (byte) 7:
              this.GrapplingAI();
              break;
            case (byte) 8:
              this.BallOfFireAI();
              break;
            case (byte) 9:
              this.MagicMissileAI();
              break;
            case (byte) 10:
              this.DirtBallAI();
              break;
            case (byte) 11:
              this.OrbOfLightAI();
              break;
            case (byte) 12:
              this.BlueFlameAI();
              break;
            case (byte) 13:
              this.HarpoonAI();
              break;
            case (byte) 14:
              this.SpikyBallAI();
              break;
            case (byte) 15:
              this.FlailAI();
              break;
            case (byte) 16:
              this.BombAI();
              break;
            case (byte) 17:
              this.TombstoneAI();
              break;
            case (byte) 18:
              this.DemonSickleAI();
              break;
            case (byte) 19:
              this.SpearAI();
              break;
            case (byte) 20:
              this.ChainsawAI();
              break;
            case (byte) 21:
              this.NoteAI();
              break;
            case (byte) 22:
              this.IceBlockAI();
              break;
            case (byte) 23:
              this.FlameAI();
              break;
            case (byte) 24:
              this.CrystalShardAI();
              break;
            case (byte) 25:
              this.BoulderAI();
              break;
            case (byte) 26:
              this.PetAI();
              break;
            case (byte) 27:
              this.FairyAI();
              break;
            case (byte) 28:
              this.FlyingPetAI();
              break;
          }
          if ((int) this.owner < 8 && (int) Main.player[(int) this.owner].active == 0)
            this.Kill();
          if (!this.ignoreWater)
          {
            bool flag1;
            bool flag2;
            try
            {
              flag1 = Collision.LavaCollision(ref this.position, (int) this.width, (int) this.height);
              flag2 = Collision.WetCollision(ref this.position, (int) this.width, (int) this.height);
              if (flag1)
                this.lavaWet = true;
            }
            catch
            {
              this.active = (byte) 0;
              return;
            }
            if (this.wet && !this.lavaWet)
            {
              if ((int) this.type == 85 || (int) this.type == 15 || (int) this.type == 34)
                this.Kill();
              else if ((int) this.type == 2 || (int) this.type == 82)
              {
                --this.type;
                this.light = 0.0f;
              }
            }
            if ((int) this.type == 80)
            {
              this.wet = false;
              if (flag1 && (double) this.ai0 >= 0.0)
                this.Kill();
            }
            else if (flag2)
            {
              if ((int) this.wetCount == 0)
              {
                this.wetCount = (byte) 10;
                if (!this.wet)
                {
                  this.wet = true;
                  Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                  if (!flag1)
                  {
                    for (int index = 0; index < 8; ++index)
                    {
                      Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
                      if ((IntPtr) dustPtr != IntPtr.Zero)
                      {
                        dustPtr->velocity.Y -= 4f;
                        dustPtr->velocity.X *= 2.5f;
                        dustPtr->scale = 1.3f;
                        dustPtr->alpha = (short) 100;
                        dustPtr->noGravity = true;
                      }
                      else
                        break;
                    }
                  }
                  else
                  {
                    for (int index = 0; index < 8; ++index)
                    {
                      Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
                      if ((IntPtr) dustPtr != IntPtr.Zero)
                      {
                        dustPtr->velocity.Y -= 1.5f;
                        dustPtr->velocity.X *= 2.5f;
                        dustPtr->scale = 1.3f;
                        dustPtr->alpha = (short) 100;
                        dustPtr->noGravity = true;
                      }
                      else
                        break;
                    }
                  }
                }
              }
            }
            else if (this.wet)
            {
              this.wet = false;
              if ((int) this.wetCount == 0)
              {
                this.wetCount = (byte) 10;
                Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                if (!this.lavaWet)
                {
                  for (int index = 0; index < 8; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1), (int) this.width + 12, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 4f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                }
                else
                {
                  for (int index = 0; index < 8; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 1.5f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                }
              }
            }
            if (!this.wet)
              this.lavaWet = false;
            if ((int) this.wetCount > 0)
              --this.wetCount;
          }
          this.lastPosition = this.position;
          Vector2 vector2_1 = this.velocity;
          if (this.tileCollide)
          {
            Vector2 vector2_2 = this.velocity;
            bool flag1 = (int) this.type != 9 && (int) this.type != 12 && ((int) this.type != 15 && (int) this.type != 13) && ((int) this.type != 31 && (int) this.type != 39 && (int) this.type != 40) && (int) this.aiStyle != 26;
            if ((int) this.aiStyle == 10)
            {
              if ((int) this.type == 42 || (int) this.type == 65 || (int) this.type == 68 || (int) this.type == 31 && (double) this.ai0 == 2.0)
                Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, flag1, flag1);
              else
                Collision.AnyCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height);
            }
            else if ((int) this.aiStyle == 18)
            {
              int Width = (int) this.width - 36;
              int Height = (int) this.height - 36;
              Vector2 Position = new Vector2(this.position.X + (float) ((int) this.width >> 1) - (float) (Width >> 1), this.position.Y + (float) ((int) this.height >> 1) - (float) (Height >> 1));
              Collision.TileCollision(ref Position, ref this.velocity, Width, Height, flag1, flag1);
            }
            else if (this.wet)
            {
              Vector2 vector2_3 = this.velocity;
              Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, flag1, flag1);
              vector2_1 = this.velocity;
              vector2_1.X *= 0.5f;
              vector2_1.Y *= 0.5f;
              if ((double) this.velocity.X != (double) vector2_3.X)
                vector2_1.X = this.velocity.X;
              if ((double) this.velocity.Y != (double) vector2_3.Y)
                vector2_1.Y = this.velocity.Y;
            }
            else
              Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, flag1, flag1);
            if (vector2_2 != this.velocity)
            {
              if ((int) this.type == 94)
              {
                if ((double) this.velocity.X != (double) vector2_2.X)
                  this.velocity.X = -vector2_2.X;
                if ((double) this.velocity.Y != (double) vector2_2.Y)
                  this.velocity.Y = -vector2_2.Y;
              }
              else if ((int) this.type == 99)
              {
                if ((double) this.velocity.Y != (double) vector2_2.Y && (double) vector2_2.Y > 5.0)
                {
                  Collision.HitTiles(this.position, this.velocity, (int) this.width, (int) this.height);
                  Main.PlaySound(0, this.aabb.X, this.aabb.Y, 1);
                  this.velocity.Y = (float) (-(double) vector2_2.Y * 0.200000002980232);
                }
                if ((double) this.velocity.X != (double) vector2_2.X)
                  this.Kill();
              }
              else if ((int) this.type == 36)
              {
                if ((int) this.penetrate > 1)
                {
                  Collision.HitTiles(this.position, this.velocity, (int) this.width, (int) this.height);
                  Main.PlaySound(2, this.aabb.X, this.aabb.Y, 10);
                  --this.penetrate;
                  if ((double) this.velocity.X != (double) vector2_2.X)
                    this.velocity.X = -vector2_2.X;
                  if ((double) this.velocity.Y != (double) vector2_2.Y)
                    this.velocity.Y = -vector2_2.Y;
                }
                else
                  this.Kill();
              }
              else if ((int) this.aiStyle == 21)
              {
                if ((double) this.velocity.X != (double) vector2_2.X)
                  this.velocity.X = -vector2_2.X;
                if ((double) this.velocity.Y != (double) vector2_2.Y)
                  this.velocity.Y = -vector2_2.Y;
              }
              else if ((int) this.aiStyle == 17)
              {
                if ((double) this.velocity.X != (double) vector2_2.X)
                  this.velocity.X = vector2_2.X * -0.75f;
                if ((double) this.velocity.Y != (double) vector2_2.Y && (double) vector2_2.Y > 1.5)
                  this.velocity.Y = vector2_2.Y * -0.7f;
              }
              else if ((int) this.aiStyle == 15)
              {
                bool flag2 = false;
                if ((double) vector2_2.X != (double) this.velocity.X)
                {
                  if ((double) Math.Abs(vector2_2.X) > 4.0)
                    flag2 = true;
                  this.position.X += this.velocity.X;
                  this.velocity.X = (float) (-(double) vector2_2.X * 0.200000002980232);
                }
                if ((double) vector2_2.Y != (double) this.velocity.Y)
                {
                  if ((double) Math.Abs(vector2_2.Y) > 4.0)
                    flag2 = true;
                  this.position.Y += this.velocity.Y;
                  this.velocity.Y = (float) (-(double) vector2_2.Y * 0.200000002980232);
                }
                this.ai0 = 1f;
                if (flag2)
                {
                  this.netUpdate = true;
                  Collision.HitTiles(this.position, this.velocity, (int) this.width, (int) this.height);
                  Main.PlaySound(0, this.aabb.X, this.aabb.Y, 1);
                }
              }
              else if ((int) this.aiStyle == 3 || (int) this.aiStyle == 13)
              {
                Collision.HitTiles(this.position, this.velocity, (int) this.width, (int) this.height);
                if ((int) this.type == 33 || (int) this.type == 106)
                {
                  if ((double) this.velocity.X != (double) vector2_2.X)
                    this.velocity.X = -vector2_2.X;
                  if ((double) this.velocity.Y != (double) vector2_2.Y)
                    this.velocity.Y = -vector2_2.Y;
                }
                else
                {
                  this.ai0 = 1f;
                  if ((int) this.aiStyle == 3)
                  {
                    this.velocity.X = -vector2_2.X;
                    this.velocity.Y = -vector2_2.Y;
                  }
                }
                this.netUpdate = true;
                Main.PlaySound(0, this.aabb.X, this.aabb.Y, 1);
              }
              else if ((int) this.aiStyle == 8 && (int) this.type != 96)
              {
                Main.PlaySound(2, this.aabb.X, this.aabb.Y, 10);
                ++this.ai0;
                if ((double) this.ai0 >= 5.0)
                {
                  this.position.X += this.velocity.X;
                  this.position.Y += this.velocity.Y;
                  this.Kill();
                }
                else
                {
                  if ((int) this.type == 15 && (double) this.velocity.Y > 4.0)
                  {
                    if ((double) this.velocity.Y != (double) vector2_2.Y)
                      this.velocity.Y = (float) (-(double) vector2_2.Y * 0.800000011920929);
                  }
                  else if ((double) this.velocity.Y != (double) vector2_2.Y)
                    this.velocity.Y = -vector2_2.Y;
                  if ((double) this.velocity.X != (double) vector2_2.X)
                    this.velocity.X = -vector2_2.X;
                }
              }
              else if ((int) this.aiStyle == 14)
              {
                if ((int) this.type == 50)
                {
                  if ((double) this.velocity.X != (double) vector2_2.X)
                    this.velocity.X = vector2_2.X * -0.2f;
                  if ((double) this.velocity.Y != (double) vector2_2.Y && (double) vector2_2.Y > 1.5)
                    this.velocity.Y = vector2_2.Y * -0.2f;
                }
                else
                {
                  if ((double) this.velocity.X != (double) vector2_2.X)
                    this.velocity.X = vector2_2.X * -0.5f;
                  if ((double) this.velocity.Y != (double) vector2_2.Y && (double) vector2_2.Y > 1.0)
                    this.velocity.Y = vector2_2.Y * -0.5f;
                }
              }
              else if ((int) this.aiStyle == 16)
              {
                if ((double) this.velocity.X != (double) vector2_2.X)
                {
                  this.velocity.X = vector2_2.X * -0.4f;
                  if ((int) this.type == 29)
                    this.velocity.X *= 0.8f;
                }
                if ((double) this.velocity.Y != (double) vector2_2.Y && (double) vector2_2.Y > 0.7 && (int) this.type != 102)
                {
                  this.velocity.Y = vector2_2.Y * -0.4f;
                  if ((int) this.type == 29)
                    this.velocity.Y *= 0.8f;
                }
              }
              else if (((int) this.aiStyle != 9 || this.isLocal()) && (int) this.type != 111 && ((int) this.type < 115 || (int) this.type > 119))
              {
                this.position.X += this.velocity.X;
                this.position.Y += this.velocity.Y;
                this.Kill();
              }
            }
          }
          if ((int) this.type != 7 && (int) this.type != 8)
          {
            if (this.wet)
            {
              this.position.X += vector2_1.X;
              this.position.Y += vector2_1.Y;
            }
            else
            {
              this.position.X += this.velocity.X;
              this.position.Y += this.velocity.Y;
            }
            this.aabb.X = (int) this.position.X;
            this.aabb.Y = (int) this.position.Y;
          }
          if (((int) this.aiStyle != 3 || (double) this.ai0 != 1.0) && ((int) this.aiStyle != 7 || (double) this.ai0 != 1.0) && (((int) this.aiStyle != 13 || (double) this.ai0 != 1.0) && ((int) this.aiStyle != 15 || (double) this.ai0 != 1.0)) && ((int) this.aiStyle != 15 && (int) this.aiStyle != 26))
            this.direction = (double) this.velocity.X < 0.0 ? (sbyte) -1 : (sbyte) 1;
          if ((int) this.active == 0)
            return;
          if ((double) this.light > 0.0)
          {
            float x = this.light;
            float y = this.light;
            float z = this.light;
            if ((int) this.type == 2 || (int) this.type == 82)
            {
              y *= 0.75f;
              z *= 0.55f;
            }
            else if ((int) this.type == 94)
            {
              x *= 0.5f;
              y = 0.0f;
            }
            else if ((int) this.type == 95 || (int) this.type == 96 || ((int) this.type == 103 || (int) this.type == 104))
            {
              x *= 0.35f;
              z = 0.0f;
            }
            else if ((int) this.type == 4)
            {
              y *= 0.1f;
              x *= 0.5f;
            }
            else if ((int) this.type == 9)
            {
              y *= 0.1f;
              z *= 0.6f;
            }
            else if ((int) this.type == 92)
            {
              y *= 0.6f;
              x *= 0.8f;
            }
            else if ((int) this.type == 93)
            {
              y *= 1f;
              x *= 1f;
              z *= 0.01f;
            }
            else if ((int) this.type == 12)
            {
              x *= 0.9f;
              y *= 0.8f;
              z *= 0.1f;
            }
            else if ((int) this.type == 14 || (int) this.type == 110)
            {
              y *= 0.7f;
              z *= 0.1f;
            }
            else if ((int) this.type == 15)
            {
              y *= 0.4f;
              z *= 0.1f;
              x = 1f;
            }
            else if ((int) this.type == 16)
            {
              x *= 0.1f;
              y *= 0.4f;
              z = 1f;
            }
            else if ((int) this.type == 113)
            {
              x *= 0.1f;
              z = 1f;
            }
            else if ((int) this.type == 18)
            {
              y *= 0.7f;
              z *= 0.3f;
            }
            else if ((int) this.type == 19)
            {
              y *= 0.5f;
              z *= 0.1f;
            }
            else if ((int) this.type == 20)
            {
              x *= 0.1f;
              z *= 0.3f;
            }
            else if ((int) this.type == 22)
            {
              x = 0.0f;
              y = 0.0f;
            }
            else if ((int) this.type == 27)
            {
              x = 0.0f;
              y *= 0.3f;
              z = 1f;
            }
            else if ((int) this.type == 34)
            {
              y *= 0.1f;
              z *= 0.1f;
            }
            else if ((int) this.type == 36)
            {
              x = 0.8f;
              y *= 0.2f;
              z *= 0.6f;
            }
            else if ((int) this.type == 41)
            {
              y *= 0.8f;
              z *= 0.6f;
            }
            else if ((int) this.type == 114)
            {
              x = 1f;
              y = 1f;
              z *= 0.25f;
            }
            else if ((int) this.type == 44 || (int) this.type == 45)
            {
              z = 1f;
              x *= 0.6f;
              y *= 0.1f;
            }
            else if ((int) this.type == 50)
            {
              x *= 0.7f;
              z *= 0.8f;
            }
            else if ((int) this.type == 53)
            {
              x *= 0.7f;
              y *= 0.8f;
            }
            else if ((int) this.type == 72)
            {
              x *= 0.45f;
              y *= 0.75f;
              z = 1f;
            }
            else if ((int) this.type == 86)
            {
              y *= 0.45f;
              z = 0.75f;
            }
            else if ((int) this.type == 87)
            {
              x *= 0.45f;
              y = 1f;
              z *= 0.75f;
            }
            else if ((int) this.type == 73)
            {
              x *= 0.4f;
              y *= 0.6f;
            }
            else if ((int) this.type == 74)
            {
              y *= 0.4f;
              z *= 0.6f;
            }
            else if ((int) this.type == 76 || (int) this.type == 77 || (int) this.type == 78)
            {
              y *= 0.3f;
              z *= 0.6f;
            }
            else if ((int) this.type == 79)
            {
              x = Main.DiscoRGB.X;
              y = Main.DiscoRGB.Y;
              z = Main.DiscoRGB.Z;
            }
            else if ((int) this.type == 80)
            {
              x = 0.0f;
              y *= 0.8f;
              z *= 1f;
            }
            else if ((int) this.type == 83 || (int) this.type == 88)
            {
              x *= 0.7f;
              y = 0.0f;
              z *= 1f;
            }
            else if ((int) this.type == 100)
            {
              y *= 0.5f;
              z = 0.0f;
            }
            else if ((int) this.type == 84)
            {
              x *= 0.8f;
              y = 0.0f;
              z *= 0.5f;
            }
            else if ((int) this.type == 89 || (int) this.type == 90)
            {
              y *= 0.2f;
              x *= 0.05f;
            }
            else if ((int) this.type == 106)
            {
              x = 0.0f;
              y *= 0.5f;
            }
            Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(x, y, z));
          }
          if (((int) Main.frameCounter & 1) == 1)
          {
            if ((int) this.type == 2 || (int) this.type == 82)
              Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
            else if ((int) this.type == 103)
            {
              Dust* dustPtr = Main.dust.NewDust(75, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
              if (Main.rand.Next(2) == 0 && (IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->scale *= 2f;
              }
            }
            else if ((int) this.type == 4)
            {
              if (Main.rand.Next(3) == 0)
                Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.10000002384186);
            }
            else if ((int) this.type == 5)
            {
              int num = Main.rand.Next(3);
              int Type = num != 0 ? num + 56 : 15;
              Main.dust.NewDust(Type, ref this.aabb, (double) this.velocity.X * 0.5, (double) this.velocity.Y * 0.5, 150, new Color(), 1.20000004768372);
            }
          }
          this.Damage();
          if ((int) this.type == 99)
          {
            if (Main.netMode != 1)
              Collision.SwitchTiles(this.position, (int) this.width, (int) this.height, this.lastPosition);
          }
          else if ((int) this.type == 94)
          {
            // ISSUE: reference to a compiler-generated field
            fixed (float* numPtr = &this.oldPos.FixedElementField)
            {
              for (int index = 9; index > 0; --index)
                ((Vector2*) numPtr)[index] = ((Vector2*) numPtr)[index - 1];
              *(Vector2*) numPtr = this.position;
            }
          }
          if (--this.timeLeft <= 0)
          {
            this.Kill();
            goto label_284;
          }
          else if ((int) this.penetrate == 0)
          {
            this.Kill();
            goto label_284;
          }
          else if ((int) this.active != 0)
          {
            if (this.isLocal() && this.netUpdate)
              NetMessage.SendProjectile(i, SendDataOptions.InOrder);
            if ((int) this.maxUpdates <= 0)
              goto label_284;
          }
          else
            goto label_284;
        }
        while ((int) --this.numUpdates >= 0);
        this.numUpdates = (sbyte) this.maxUpdates;
label_284:
        this.netUpdate = false;
      }
    }

    private unsafe void PetAI()
    {
      Player player = Main.player[(int) this.owner];
      if (this.isLocal())
      {
        if (player.dead)
          player.pet = (sbyte) -1;
        else if ((int) player.pet >= 0)
          this.timeLeft = 2;
      }
      if ((int) player.rocketDelay2 > 0)
        this.ai0 = 1f;
      Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = player.position.X + 10f - vector2_1.X;
      float num2 = player.position.Y + 21f - vector2_1.Y;
      float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      if ((double) num3 > 2000.0)
      {
        this.position.X = player.position.X + 10f - (float) ((int) this.width >> 1);
        this.position.Y = player.position.Y + 21f - (float) ((int) this.height >> 1);
        this.aabb.X = (int) this.position.X;
        this.aabb.Y = (int) this.position.Y;
      }
      else if ((double) num3 > 500.0 || (double) Math.Abs(num2) > 300.0)
      {
        this.ai0 = 1f;
        if ((double) num2 > 0.0 && (double) this.velocity.Y < 0.0)
          this.velocity.Y = 0.0f;
        if ((double) num2 < 0.0 && (double) this.velocity.Y > 0.0)
          this.velocity.Y = 0.0f;
      }
      if ((double) this.ai0 != 0.0)
      {
        this.tileCollide = false;
        Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num4 = player.position.X + 10f - vector2_2.X;
        float num5 = player.position.Y + 21f - vector2_2.Y;
        float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
        float num7 = 10f;
        if ((double) num6 < 200.0 && (double) player.velocity.Y == 0.0 && (double) this.position.Y + (double) this.height <= (double) player.position.Y + 42.0)
        {
          Vector2 Velocity = this.velocity;
          Collision.TileCollision(ref this.position, ref Velocity, (int) this.width, (int) this.height, false, false);
          this.tileCollide = (double) this.velocity.X != (double) Velocity.X || (double) this.velocity.Y != (double) Velocity.Y;
          if (!this.tileCollide)
          {
            this.ai0 = 0.0f;
            if ((double) this.velocity.Y < -6.0)
              this.velocity.Y = -6f;
          }
        }
        float num8;
        float num9;
        if ((double) num6 < 60.0)
        {
          num8 = this.velocity.X;
          num9 = this.velocity.Y;
        }
        else
        {
          float num10 = num7 / num6;
          num8 = num4 * num10;
          num9 = num5 * num10;
        }
        if ((double) this.velocity.X < (double) num8)
        {
          this.velocity.X += 0.2f;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X += 0.3f;
        }
        if ((double) this.velocity.X > (double) num8)
        {
          this.velocity.X -= 0.2f;
          if ((double) this.velocity.X > 0.0)
            this.velocity.X -= 0.3f;
        }
        if ((double) this.velocity.Y < (double) num9)
        {
          this.velocity.Y += 0.2f;
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y += 0.3f;
        }
        if ((double) this.velocity.Y > (double) num9)
        {
          this.velocity.Y -= 0.2f;
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y -= 0.3f;
        }
        Projectile.petAnimFly[(int) this.localAI0].Update(ref this);
        if ((double) this.velocity.X > 0.5)
          this.spriteDirection = (sbyte) -1;
        else if ((double) this.velocity.X < -0.5)
          this.spriteDirection = (sbyte) 1;
        if ((int) this.type < 116)
          this.rotation = (int) this.spriteDirection != -1 ? (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + Math.PI) : (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
        if (((int) Main.frameCounter & 1) != 1)
          return;
        Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X) + ((int) this.width >> 1) - 4, (int) ((double) this.position.Y - (double) this.velocity.Y) + ((int) this.height >> 1) - 4, 8, 8, 16, (double) this.velocity.X * -0.5, (double) this.velocity.Y * 0.5, 50, new Color(), 1.70000004768372);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          return;
        dustPtr->velocity *= 0.2f;
        dustPtr->noGravity = true;
      }
      else
      {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        this.rotation = 0.0f;
        this.tileCollide = true;
        if (player.aabb.X + 10 < this.aabb.X + ((int) this.width >> 1) - 60)
        {
          if ((double) this.velocity.X > -3.5)
            this.velocity.X -= 0.08f;
          else
            this.velocity.X -= 0.02f;
          flag1 = true;
        }
        else if ((double) player.position.X + 10.0 > (double) this.position.X + (double) ((int) this.width >> 1) + 60.0)
        {
          if ((double) this.velocity.X < 3.5)
            this.velocity.X += 0.08f;
          else
            this.velocity.X += 0.02f;
          flag2 = true;
        }
        else
        {
          this.velocity.X *= 0.9f;
          if ((double) this.velocity.X >= -0.08 && (double) this.velocity.X <= 0.08)
            this.velocity.X = 0.0f;
        }
        if (flag1 || flag2)
        {
          int num4 = this.aabb.X + ((int) this.width >> 1) >> 4;
          int j = this.aabb.Y + ((int) this.height >> 1) >> 4;
          if (WorldGen.CanStandOnTop((!flag1 ? num4 + 1 : num4 - 1) + (int) this.velocity.X, j))
            flag4 = true;
        }
        if ((double) player.position.Y + 42.0 > (double) this.position.Y + (double) this.height)
          flag3 = true;
        if ((double) this.velocity.Y == 0.0)
        {
          if (!flag3 && ((double) this.velocity.X < 0.0 || (double) this.velocity.X > 0.0))
          {
            int i = this.aabb.X + ((int) this.width >> 1) >> 4;
            int j = (this.aabb.Y + ((int) this.height >> 1) >> 4) + 1;
            if (flag1)
              --i;
            if (flag2)
              ++i;
            if (!WorldGen.CanStandOnTop(i, j))
              flag4 = true;
          }
          if (flag4 && WorldGen.CanStandOnTop(this.aabb.X + ((int) this.width >> 1) >> 4, (this.aabb.Y + ((int) this.height >> 1) >> 4) + 1))
            this.velocity.Y = -9.1f;
        }
        if ((double) this.velocity.X > 6.5)
          this.velocity.X = 6.5f;
        else if ((double) this.velocity.X < -6.5)
          this.velocity.X = -6.5f;
        if ((double) this.velocity.X > 0.07 && flag2)
          this.direction = (sbyte) 1;
        else if ((double) this.velocity.X < -0.07 && flag1)
          this.direction = (sbyte) -1;
        this.spriteDirection = -this.direction;
        if ((double) this.velocity.Y == 0.0)
        {
          if ((double) Math.Abs(this.velocity.X) < 0.8)
            Projectile.petAnimIdle[(int) this.localAI0].Update(ref this);
          else
            Projectile.petAnimMove[(int) this.localAI0].Update(ref this);
        }
        else if ((double) this.velocity.Y < 0.0)
          Projectile.petAnimFall[(int) this.localAI0].Update(ref this);
        else if ((double) this.velocity.Y > 0.0)
          Projectile.petAnimJump[(int) this.localAI0].Update(ref this);
        this.velocity.Y += 0.4f;
        if ((double) this.velocity.Y <= 10.0)
          return;
        this.velocity.Y = 10f;
      }
    }

    private void FlyingPetAI()
    {
      Player player = Main.player[(int) this.owner];
      if (this.isLocal())
      {
        if (player.dead)
          player.pet = (sbyte) -1;
        else if ((int) player.pet >= 0)
          this.timeLeft = 2;
      }
      this.tileCollide = false;
      Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = player.position.X + 10f - vector2.X;
      float num2 = player.position.Y + 21f - vector2.Y;
      float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      float num4 = 10f;
      if ((double) num3 < 200.0 && (double) player.velocity.Y == 0.0 && (double) this.position.Y + (double) this.height <= (double) player.position.Y + 42.0)
      {
        Vector2 Velocity = this.velocity;
        Collision.TileCollision(ref this.position, ref Velocity, (int) this.width, (int) this.height, false, false);
        this.tileCollide = (double) this.velocity.X != (double) Velocity.X || (double) this.velocity.Y != (double) Velocity.Y;
        if (!this.tileCollide)
        {
          this.ai0 = 0.0f;
          if ((double) this.velocity.Y < -6.0)
            this.velocity.Y = -6f;
        }
      }
      float num5;
      float num6;
      if ((double) num3 < 60.0)
      {
        num5 = this.velocity.X;
        num6 = this.velocity.Y;
      }
      else
      {
        float num7 = num4 / num3;
        num5 = num1 * num7;
        num6 = num2 * num7;
      }
      if ((double) this.velocity.X < (double) num5)
      {
        this.velocity.X += 0.2f;
        if ((double) this.velocity.X < 0.0)
          this.velocity.X += 0.3f;
      }
      if ((double) this.velocity.X > (double) num5)
      {
        this.velocity.X -= 0.2f;
        if ((double) this.velocity.X > 0.0)
          this.velocity.X -= 0.3f;
      }
      if ((double) this.velocity.Y < (double) num6)
      {
        this.velocity.Y += 0.2f;
        if ((double) this.velocity.Y < 0.0)
          this.velocity.Y += 0.3f;
      }
      if ((double) this.velocity.Y > (double) num6)
      {
        this.velocity.Y -= 0.2f;
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y -= 0.3f;
      }
      Projectile.petAnimFly[(int) this.localAI0].Update(ref this);
      if ((double) this.velocity.X > 0.5)
      {
        this.spriteDirection = (sbyte) -1;
      }
      else
      {
        if ((double) this.velocity.X >= -0.5)
          return;
        this.spriteDirection = (sbyte) 1;
      }
    }

    private unsafe void ArrowAI()
    {
      if (this.ai1 == 0)
      {
        this.ai1 = 1;
        if ((int) this.type == 83 || (int) this.type == 100)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 33);
        else if ((int) this.type == 110)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 11);
        else if ((int) this.type == 84)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 12);
        else if ((int) this.type == 98)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 17);
        else if ((int) this.type == 81 || (int) this.type == 82)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 5);
      }
      if ((int) this.type == 41)
      {
        Dust* dustPtr1 = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.60000002384186);
        if ((IntPtr) dustPtr1 != IntPtr.Zero)
        {
          dustPtr1->noGravity = true;
          Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr2 != IntPtr.Zero)
            dustPtr2->noGravity = true;
        }
      }
      else if ((int) this.type == 114)
      {
        Dust* dustPtr1 = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.60000002384186);
        if ((IntPtr) dustPtr1 != IntPtr.Zero)
        {
          dustPtr1->noGravity = true;
          Dust* dustPtr2 = Main.dust.NewDust(64, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr2 != IntPtr.Zero)
            dustPtr2->noGravity = true;
        }
      }
      else if ((int) this.type == 55)
      {
        Dust* dustPtr = Main.dust.NewDust(18, ref this.aabb, 0.0, 0.0, 0, new Color(), 0.899999976158142);
        if ((IntPtr) dustPtr != IntPtr.Zero)
          dustPtr->noGravity = true;
      }
      else if ((int) this.type == 91)
      {
        if (Main.rand.Next(3) == 0)
        {
          int Type = Main.rand.Next(2) != 0 ? 58 : 15;
          Dust* dustPtr = Main.dust.NewDust(Type, ref this.aabb, (double) this.velocity.X * 0.25, (double) this.velocity.Y * 0.25, 150, new Color(), 0.899999976158142);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.25f;
            dustPtr->velocity.Y *= 0.25f;
          }
        }
      }
      else if ((int) this.type == 88)
      {
        if ((int) this.alpha > 10)
          this.alpha -= (byte) 10;
        else
          this.alpha = (byte) 0;
      }
      else if ((int) this.type == 20 || (int) this.type == 14 || ((int) this.type == 36 || (int) this.type == 83) || ((int) this.type == 84 || (int) this.type == 89 || ((int) this.type == 100 || (int) this.type == 104)) || (int) this.type == 110)
      {
        if ((int) this.alpha > 15)
          this.alpha -= (byte) 15;
        else
          this.alpha = (byte) 0;
      }
      this.rotation = (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57);
      if ((int) this.type != 5 && (int) this.type != 14 && ((int) this.type != 20 && (int) this.type != 36) && ((int) this.type != 38 && (int) this.type != 55 && ((int) this.type != 83 && (int) this.type != 84)) && ((int) this.type != 88 && (int) this.type != 89 && ((int) this.type != 98 && (int) this.type != 100) && ((int) this.type != 104 && (int) this.type != 110)))
      {
        if ((double) ++this.ai0 == 9.0)
        {
          if ((int) this.type == 114 && this.isLocal() && Main.rand.Next(4) == 0)
          {
            int number = this.NewClonedProjectile(114);
            if (number >= 0)
            {
              double num1 = (double) this.velocity.Length();
              double num2 = (double) this.rotation - (double) Main.rand.Next(10, 28) * (Math.PI / 180.0);
              double num3 = (double) this.rotation + (double) Main.rand.Next(10, 28) * (Math.PI / 180.0);
              double num4 = -Math.Cos(num2);
              double num5 = Math.Sin(num2);
              double num6 = num1 * num5;
              double num7 = num1 * num4;
              Main.projectile[number].velocity.X = (float) num6;
              Main.projectile[number].velocity.Y = (float) num7;
              Main.projectile[number].ai0 = 9f;
              Main.projectile[number].ai1 = 1;
              double num8 = -Math.Cos(num3);
              double num9 = Math.Sin(num3);
              double num10 = num1 * num9;
              double num11 = num1 * num8;
              this.velocity.X = (float) num10;
              this.velocity.Y = (float) num11;
              NetMessage.SendProjectile(number, SendDataOptions.Reliable);
            }
          }
        }
        else if ((double) this.ai0 >= 15.0)
        {
          if ((int) this.type == 81 || (int) this.type == 91)
          {
            if ((double) this.ai0 >= 20.0)
              this.velocity.Y += 0.07f;
          }
          else
            this.velocity.Y += 0.1f;
        }
      }
      if ((double) this.velocity.Y <= 16.0)
        return;
      this.velocity.Y = 16f;
    }

    private unsafe void BoomerangAI()
    {
      if ((int) this.soundDelay == 0)
      {
        this.soundDelay = (short) 8;
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 7);
      }
      if ((int) this.type == 19)
      {
        for (int index = 0; index < 2; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 33)
      {
        if (Main.rand.Next(2) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(40, ref this.aabb, (double) this.velocity.X * 0.25, (double) this.velocity.Y * 0.25, 0, new Color(), 1.39999997615814);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->noGravity = true;
        }
      }
      else if ((int) this.type == 6 && Main.rand.Next(6) == 0)
      {
        int Type;
        switch (Main.rand.Next(3))
        {
          case 0:
            Type = 15;
            break;
          case 1:
            Type = 57;
            break;
          default:
            Type = 58;
            break;
        }
        Main.dust.NewDust(Type, ref this.aabb, (double) this.velocity.X * 0.25, (double) this.velocity.Y * 0.25, 150, new Color(), 0.699999988079071);
      }
      if ((double) this.ai0 == 0.0)
      {
        ++this.ai1;
        if ((int) this.type == 106)
        {
          if (this.ai1 >= 45)
          {
            this.ai0 = 1f;
            this.ai1 = 0;
            this.netUpdate = true;
          }
        }
        else if (this.ai1 >= 30)
        {
          this.ai0 = 1f;
          this.ai1 = 0;
          this.netUpdate = true;
        }
      }
      else
      {
        this.tileCollide = false;
        float num1 = 9f;
        float num2 = 0.4f;
        if ((int) this.type == 19)
        {
          num1 = 13f;
          num2 = 0.6f;
        }
        else if ((int) this.type == 33)
        {
          num1 = 15f;
          num2 = 0.8f;
        }
        else if ((int) this.type == 106)
        {
          num1 = 16f;
          num2 = 1.2f;
        }
        Vector2 vector2 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
        float num3 = Main.player[(int) this.owner].position.X + 10f - vector2.X;
        float num4 = Main.player[(int) this.owner].position.Y + 21f - vector2.Y;
        float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
        if ((double) num5 > 3000.0)
          this.Kill();
        float num6 = num1 / num5;
        float num7 = num3 * num6;
        float num8 = num4 * num6;
        if ((double) this.velocity.X < (double) num7)
        {
          this.velocity.X += num2;
          if ((double) this.velocity.X < 0.0 && (double) num7 > 0.0)
            this.velocity.X += num2;
        }
        else if ((double) this.velocity.X > (double) num7)
        {
          this.velocity.X -= num2;
          if ((double) this.velocity.X > 0.0 && (double) num7 < 0.0)
            this.velocity.X -= num2;
        }
        if ((double) this.velocity.Y < (double) num8)
        {
          this.velocity.Y += num2;
          if ((double) this.velocity.Y < 0.0 && (double) num8 > 0.0)
            this.velocity.Y += num2;
        }
        else if ((double) this.velocity.Y > (double) num8)
        {
          this.velocity.Y -= num2;
          if ((double) this.velocity.Y > 0.0 && (double) num8 < 0.0)
            this.velocity.Y -= num2;
        }
        if (this.isLocal() && new Rectangle(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height).Intersects(Main.player[(int) this.owner].aabb))
          this.Kill();
      }
      if ((int) this.type == 106)
        this.rotation += 0.3f * (float) this.direction;
      else
        this.rotation += 0.4f * (float) this.direction;
    }

    private unsafe void ShurikenAI()
    {
      if ((int) this.type == 93 && Main.rand.Next(5) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(57, ref this.aabb, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 0.300000011920929);
        if ((IntPtr) dustPtr != IntPtr.Zero)
          dustPtr->velocity *= 0.3f;
      }
      this.rotation += (float) (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y)) * 0.0299999993294477) * (float) this.direction;
      ++this.ai0;
      if ((int) this.type == 69 || (int) this.type == 70)
      {
        if ((double) this.ai0 >= 10.0)
        {
          this.velocity.Y += 0.25f;
          this.velocity.X *= 0.99f;
        }
      }
      else if ((double) this.ai0 >= 20.0)
      {
        this.velocity.Y += 0.4f;
        this.velocity.X *= 0.97f;
      }
      else if ((int) this.type == 48 || (int) this.type == 54 || (int) this.type == 93)
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
      if ((double) this.velocity.Y > 16.0)
        this.velocity.Y = 16f;
      if ((int) this.type != 54 || Main.rand.Next(20) != 0)
        return;
      Main.dust.NewDust(40, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 0, new Color(), 0.75);
    }

    private unsafe void VilethornAI()
    {
      this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
      if ((double) this.ai0 == 0.0)
      {
        this.alpha -= (byte) 50;
        if ((int) this.alpha > 0)
          return;
        this.alpha = (byte) 0;
        this.ai0 = 1f;
        if (this.ai1 == 0)
        {
          this.ai1 = 1;
          this.position.X += this.velocity.X;
          this.position.Y += this.velocity.Y;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
        }
        if ((int) this.type != 7 || !this.isLocal())
          return;
        int number = this.NewClonedProjectile(this.ai1 >= 6 ? 8 : 7);
        if (number < 0)
          return;
        Main.projectile[number].position.X += this.velocity.X;
        Main.projectile[number].position.Y += this.velocity.Y;
        Main.projectile[number].aabb.X = (int) Main.projectile[number].position.X;
        Main.projectile[number].aabb.Y = (int) Main.projectile[number].position.Y;
        Main.projectile[number].ai1 = this.ai1 + 1;
        NetMessage.SendProjectile(number, SendDataOptions.Reliable);
      }
      else
      {
        this.alpha += (byte) 5;
        if ((int) this.alpha >= 170 && (int) this.alpha < 175)
        {
          for (int index = 0; index < 2; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) this.velocity.X * 0.025000000372529, (double) this.velocity.Y * 0.025000000372529, 170, new Color(), 1.20000004768372);
          Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 170, new Color(), 1.10000002384186);
        }
        else
        {
          if ((int) this.alpha < (int) byte.MaxValue)
            return;
          this.Kill();
        }
      }
    }

    private unsafe void StarfuryAI()
    {
      if ((int) this.type == 92)
      {
        if (this.aabb.Y > this.ai1)
          this.tileCollide = true;
      }
      else
      {
        if (this.ai1 == 0 && !Collision.SolidCollision(ref this.position, (int) this.width, (int) this.height))
        {
          this.ai1 = 1;
          this.netUpdate = true;
        }
        if (this.ai1 != 0)
          this.tileCollide = true;
      }
      if ((int) this.soundDelay == 0)
      {
        this.soundDelay = (short) (20 + Main.rand.Next(40));
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 9);
      }
      if ((int) this.localAI0 == 0)
        this.localAI0 = (sbyte) 1;
      int num = (int) this.alpha + 25 * (int) this.localAI0;
      if (num > 200)
      {
        this.alpha = (byte) 200;
        this.localAI0 = (sbyte) -1;
      }
      else if (num < 0)
      {
        this.alpha = (byte) 0;
        this.localAI0 = (sbyte) 1;
      }
      else
        this.alpha = (byte) num;
      this.rotation += (float) (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y)) * 0.00999999977648258) * (float) this.direction;
      if (this.ai1 != 1 && (int) this.type != 92)
        return;
      this.light = 0.9f;
      if (Main.rand.Next(12) == 0)
        Main.dust.NewDust(58, ref this.aabb, (double) this.velocity.X * 0.5, (double) this.velocity.Y * 0.5, 150, new Color(), 1.20000004768372);
      if (Main.rand.Next(24) != 0)
        return;
      Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1.0);
    }

    private unsafe void PowderAI()
    {
      this.velocity.X *= 0.95f;
      this.velocity.Y *= 0.95f;
      ++this.ai0;
      if ((double) this.ai0 == 180.0)
        this.Kill();
      if (this.ai1 == 0)
      {
        this.ai1 = 1;
        for (int index = 0; index < 24; ++index)
          Main.dust.NewDust(10 + (int) this.type, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 50, new Color(), 1.0);
      }
      if (!this.isLocal())
        return;
      int num1 = (this.aabb.X >> 4) - 1;
      int num2 = (this.aabb.X + (int) this.width >> 4) + 2;
      int num3 = (this.aabb.Y >> 4) - 1;
      int num4 = (this.aabb.Y + (int) this.height >> 4) + 2;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      for (int index1 = num1; index1 < num2; ++index1)
      {
        for (int index2 = num3; index2 < num4; ++index2)
        {
          Vector2 vector2;
          vector2.X = (float) (index1 * 16);
          vector2.Y = (float) (index2 * 16);
          if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && ((double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0) && (int) Main.tile[index1, index2].active != 0)
          {
            int num5 = (int) Main.tile[index1, index2].type;
            if ((int) this.type == 10)
            {
              if (num5 == 23)
              {
                Main.tile[index1, index2].type = (byte) 2;
                WorldGen.SquareTileFrame(index1, index2, -1);
                NetMessage.SendTile(index1, index2);
              }
              else if (num5 == 25)
              {
                Main.tile[index1, index2].type = (byte) 1;
                WorldGen.SquareTileFrame(index1, index2, -1);
                NetMessage.SendTile(index1, index2);
              }
              else if (num5 == 112)
              {
                Main.tile[index1, index2].type = (byte) 53;
                WorldGen.SquareTileFrame(index1, index2, -1);
                NetMessage.SendTile(index1, index2);
              }
            }
            else if (num5 == 109)
            {
              Main.tile[index1, index2].type = (byte) 2;
              WorldGen.SquareTileFrame(index1, index2, -1);
              NetMessage.SendTile(index1, index2);
            }
            else if (num5 == 116)
            {
              Main.tile[index1, index2].type = (byte) 53;
              WorldGen.SquareTileFrame(index1, index2, -1);
              NetMessage.SendTile(index1, index2);
            }
            else if (num5 == 117)
            {
              Main.tile[index1, index2].type = (byte) 1;
              WorldGen.SquareTileFrame(index1, index2, -1);
              NetMessage.SendTile(index1, index2);
            }
          }
        }
      }
    }

    private void GrapplingAI()
    {
      if (Main.player[(int) this.owner].dead)
      {
        this.Kill();
      }
      else
      {
        Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.owner].position.X + 10f - vector2_1.X;
        float num2 = Main.player[(int) this.owner].position.Y + 21f - vector2_1.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.rotation = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        if ((double) this.ai0 == 0.0)
        {
          if ((double) num3 > 300.0 && (int) this.type == 13 || (double) num3 > 400.0 && (int) this.type == 32 || ((double) num3 > 440.0 && (int) this.type == 73 || (double) num3 > 440.0 && (int) this.type == 74))
            this.ai0 = 1f;
          int num4 = (this.aabb.X >> 4) - 1;
          int num5 = (this.aabb.X + (int) this.width >> 4) + 2;
          int num6 = (this.aabb.Y >> 4) - 1;
          int num7 = (this.aabb.Y + (int) this.height >> 4) + 2;
          if (num4 < 0)
            num4 = 0;
          if (num5 > (int) Main.maxTilesX)
            num5 = (int) Main.maxTilesX;
          if (num6 < 0)
            num6 = 0;
          if (num7 > (int) Main.maxTilesY)
            num7 = (int) Main.maxTilesY;
          for (int i = num4; i < num5; ++i)
          {
            for (int j = num6; j < num7; ++j)
            {
              Vector2 vector2_2;
              vector2_2.X = (float) (i * 16);
              vector2_2.Y = (float) (j * 16);
              if ((double) this.position.X + (double) this.width > (double) vector2_2.X && (double) this.position.X < (double) vector2_2.X + 16.0 && ((double) this.position.Y + (double) this.height > (double) vector2_2.Y && (double) this.position.Y < (double) vector2_2.Y + 16.0) && ((int) Main.tile[i, j].active != 0 && Main.tileSolid[(int) Main.tile[i, j].type]))
              {
                if ((int) Main.player[(int) this.owner].grapCount < 10)
                {
                  Main.player[(int) this.owner].grappling[(int) Main.player[(int) this.owner].grapCount] = this.whoAmI;
                  ++Main.player[(int) this.owner].grapCount;
                }
                if (this.isLocal())
                {
                  int num8 = 0;
                  int index1 = -1;
                  int num9 = 100000;
                  if ((int) this.type == 73 || (int) this.type == 74)
                  {
                    for (int index2 = 0; index2 < 512; ++index2)
                    {
                      if (index2 != (int) this.whoAmI && (int) Main.projectile[index2].active != 0 && ((int) Main.projectile[index2].owner == (int) this.owner && (int) Main.projectile[index2].aiStyle == 7) && (double) Main.projectile[index2].ai0 == 2.0)
                        Main.projectile[index2].Kill();
                    }
                  }
                  else
                  {
                    for (int index2 = 0; index2 < 512; ++index2)
                    {
                      if ((int) Main.projectile[index2].active != 0 && (int) Main.projectile[index2].owner == (int) this.owner && (int) Main.projectile[index2].aiStyle == 7)
                      {
                        if (Main.projectile[index2].timeLeft < num9)
                        {
                          index1 = index2;
                          num9 = Main.projectile[index2].timeLeft;
                        }
                        ++num8;
                      }
                    }
                    if (num8 > 3)
                      Main.projectile[index1].Kill();
                  }
                }
                WorldGen.KillTile(i, j, true, true, false);
                Main.PlaySound(0, i * 16, j * 16, 1);
                this.velocity.X = 0.0f;
                this.velocity.Y = 0.0f;
                this.ai0 = 2f;
                this.position.X = (float) (this.aabb.X = i * 16 + 8 - ((int) this.width >> 1));
                this.position.Y = (float) (this.aabb.Y = j * 16 + 8 - ((int) this.height >> 1));
                this.damage = (short) 0;
                this.netUpdate = true;
                if (this.isLocal())
                {
                  NetMessage.CreateMessage1(13, (int) this.owner);
                  NetMessage.SendMessage();
                  break;
                }
                else
                  break;
              }
            }
            if ((double) this.ai0 == 2.0)
              break;
          }
        }
        else if ((double) this.ai0 == 1.0)
        {
          float num4 = 11f;
          if ((int) this.type == 32)
            num4 = 15f;
          if ((int) this.type == 73 || (int) this.type == 74)
            num4 = 17f;
          if ((double) num3 < 24.0)
            this.Kill();
          float num5 = num4 / num3;
          float num6 = num1 * num5;
          float num7 = num2 * num5;
          this.velocity.X = num6;
          this.velocity.Y = num7;
        }
        else
        {
          if ((double) this.ai0 != 2.0)
            return;
          int num4 = (this.aabb.X >> 4) - 1;
          int num5 = (this.aabb.X + (int) this.width >> 4) + 2;
          int num6 = (this.aabb.Y >> 4) - 1;
          int num7 = (this.aabb.Y + (int) this.height >> 4) + 2;
          if (num4 < 0)
            num4 = 0;
          if (num5 > (int) Main.maxTilesX)
            num5 = (int) Main.maxTilesX;
          if (num6 < 0)
            num6 = 0;
          if (num7 > (int) Main.maxTilesY)
            num7 = (int) Main.maxTilesY;
          bool flag = true;
          for (int index1 = num4; index1 < num5; ++index1)
          {
            for (int index2 = num6; index2 < num7; ++index2)
            {
              Vector2 vector2_2;
              vector2_2.X = (float) (index1 * 16);
              vector2_2.Y = (float) (index2 * 16);
              if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) vector2_2.X && (double) this.position.X + (double) ((int) this.width >> 1) < (double) vector2_2.X + 16.0 && ((double) this.position.Y + (double) ((int) this.height >> 1) > (double) vector2_2.Y && (double) this.position.Y + (double) ((int) this.height >> 1) < (double) vector2_2.Y + 16.0) && ((int) Main.tile[index1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2].type]))
                flag = false;
            }
          }
          if (flag)
          {
            this.ai0 = 1f;
          }
          else
          {
            if ((int) Main.player[(int) this.owner].grapCount >= 10)
              return;
            Main.player[(int) this.owner].grappling[(int) Main.player[(int) this.owner].grapCount] = this.whoAmI;
            ++Main.player[(int) this.owner].grapCount;
          }
        }
      }
    }

    private unsafe void BallOfFireAI()
    {
      if ((int) this.type == 96 && (int) this.localAI0 == 0)
      {
        this.localAI0 = (sbyte) 1;
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 20);
      }
      if ((int) this.type == 27)
      {
        Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X + (double) this.velocity.X), (int) ((double) this.position.Y + (double) this.velocity.Y), (int) this.width, (int) this.height, 29, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 3.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          if (Main.rand.Next(12) == 0)
            Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 1.39999997615814);
        }
      }
      else if ((int) this.type == 95 || (int) this.type == 96)
      {
        Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X + (double) this.velocity.X), (int) ((double) this.position.Y + (double) this.velocity.Y), (int) this.width, (int) this.height, 75, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 3.0 * (double) this.scale);
        if ((IntPtr) dustPtr != IntPtr.Zero)
          dustPtr->noGravity = true;
      }
      else
      {
        for (int index = 0; index < 2; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
          }
          else
            break;
        }
      }
      if ((int) this.type != 27 && (int) this.type != 96 && ++this.ai1 >= 20)
        this.velocity.Y += 0.2f;
      this.rotation += 0.3f * (float) this.direction;
      if ((double) this.velocity.Y <= 16.0)
        return;
      this.velocity.Y = 16f;
    }

    private unsafe void MagicMissileAI()
    {
      if ((int) this.type == 34)
      {
        Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 3.5);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 1.4f;
          dustPtr->velocity.Y *= 1.4f;
          Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.5);
        }
      }
      else if ((int) this.type == 79)
      {
        if ((int) this.soundDelay == 0 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 2.0)
        {
          this.soundDelay = (short) 10;
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 9);
        }
        Dust* dustPtr = Main.dust.NewDust(66, ref this.aabb, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.5);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.1f;
          dustPtr->velocity.Y *= 0.1f;
          dustPtr->velocity.X += this.velocity.X * 0.2f;
          dustPtr->velocity.Y += this.velocity.Y * 0.2f;
          dustPtr->position.X = (float) (this.aabb.X + ((int) this.width >> 1) + 4 + Main.rand.Next(-2, 3));
          dustPtr->position.Y = (float) (this.aabb.Y + ((int) this.height >> 1) + Main.rand.Next(-2, 3));
          dustPtr->noGravity = true;
        }
      }
      else
      {
        if ((int) this.soundDelay == 0 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 2.0)
        {
          this.soundDelay = (short) 10;
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 9);
        }
        Dust* dustPtr = Main.dust.NewDust(15, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.3f;
          dustPtr->velocity.Y *= 0.3f;
          dustPtr->position.X = (float) (this.aabb.X + ((int) this.width >> 1) + 4 + Main.rand.Next(-4, 5));
          dustPtr->position.Y = (float) (this.aabb.Y + ((int) this.height >> 1) + Main.rand.Next(-4, 5));
          dustPtr->noGravity = true;
        }
      }
      if ((double) this.ai0 == 0.0)
      {
        Player player = Main.player[(int) this.owner];
        if (player.isLocal() && player.channel)
        {
          float num1 = (int) this.type == 16 ? 15f : 12f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num2 = (float) ((int) player.ui.mouseX + player.view.screenPosition.X) - vector2.X;
          float num3 = (float) ((int) player.ui.mouseY + player.view.screenPosition.Y) - vector2.Y;
          float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          if ((double) num4 > (double) num1)
          {
            float num5 = num1 / num4;
            num2 *= num5;
            num3 *= num5;
          }
          if ((int) ((double) num2 * 1000.0) != (int) ((double) this.velocity.X * 1000.0) || (int) ((double) num3 * 1000.0) != (int) ((double) this.velocity.Y * 1000.0))
            this.netUpdate = true;
          this.velocity.X = num2;
          this.velocity.Y = num3;
        }
        else
        {
          this.ai0 = 1f;
          this.netUpdate = true;
          float num1 = 12f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num2 = (float) ((int) player.ui.mouseX + player.view.screenPosition.X) - vector2.X;
          float num3 = (float) ((int) player.ui.mouseY + player.view.screenPosition.Y) - vector2.Y;
          float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          if ((double) num4 == 0.0)
          {
            vector2 = new Vector2(player.position.X + 10f, player.position.Y + 21f);
            num2 = this.position.X + (float) this.width * 0.5f - vector2.X;
            num3 = this.position.Y + (float) this.height * 0.5f - vector2.Y;
            num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          }
          float num5 = num1 / num4;
          float num6 = num2 * num5;
          float num7 = num3 * num5;
          this.velocity.X = num6;
          this.velocity.Y = num7;
          if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
            this.Kill();
        }
      }
      if ((int) this.type == 34)
        this.rotation += 0.3f * (float) this.direction;
      else if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y != 0.0)
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 2.355f;
      if ((double) this.velocity.Y <= 16.0)
        return;
      this.velocity.Y = 16f;
    }

    private unsafe void DirtBallAI()
    {
      if ((int) this.type == 31 && (double) this.ai0 != 2.0)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(32, ref this.aabb, 0.0, (double) this.velocity.Y * 0.5, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type == 39)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(38, ref this.aabb, 0.0, (double) this.velocity.Y * 0.5, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type == 40)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(36, ref this.aabb, 0.0, (double) this.velocity.Y * 0.5, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.4f;
            dustPtr->velocity.Y *= 0.4f;
          }
        }
      }
      else if ((int) this.type == 42 || (int) this.type == 31)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(32, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type == 56 || (int) this.type == 65)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type == 67 || (int) this.type == 68)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(51, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type == 71)
      {
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(53, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity.X *= 0.4f;
        }
      }
      else if ((int) this.type != 109 && Main.rand.Next(24) == 0)
        Main.dust.NewDust(0, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
      if ((double) this.ai0 == 0.0)
      {
        Player player = Main.player[(int) this.owner];
        if (player.isLocal() && player.channel)
        {
          float num1 = 12f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num2 = (float) ((int) player.ui.mouseX + player.view.screenPosition.X) - vector2.X;
          float num3 = (float) ((int) player.ui.mouseY + player.view.screenPosition.Y) - vector2.Y;
          float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          float num5 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          if ((double) num5 > (double) num1)
          {
            float num6 = num1 / num5;
            num2 *= num6;
            num3 *= num6;
          }
          if ((double) num2 != (double) this.velocity.X || (double) num3 != (double) this.velocity.Y)
            this.netUpdate = true;
          this.velocity.X = num2;
          this.velocity.Y = num3;
        }
        else
        {
          this.ai0 = 1f;
          this.netUpdate = true;
        }
      }
      if ((int) this.type != 109)
      {
        if ((double) this.ai0 == 1.0)
        {
          if ((int) this.type == 42 || (int) this.type == 65 || (int) this.type == 68)
          {
            if (++this.ai1 >= 60)
              this.velocity.Y += 0.2f;
          }
          else
            this.velocity.Y += 0.41f;
        }
        else if ((double) this.ai0 == 2.0)
        {
          this.velocity.Y += 0.2f;
          if ((double) this.velocity.X < -0.04)
            this.velocity.X += 0.04f;
          else if ((double) this.velocity.X > 0.04)
            this.velocity.X -= 0.04f;
          else
            this.velocity.X = 0.0f;
        }
      }
      this.rotation += 0.1f;
      if ((double) this.velocity.Y <= 10.0)
        return;
      this.velocity.Y = 10f;
    }

    private void OrbOfLightAI()
    {
      this.rotation += 0.02f;
      if (this.isLocal() && Main.player[(int) this.owner].lightOrb)
        this.timeLeft = 2;
      if (!Main.player[(int) this.owner].dead)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.owner].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.owner].position.Y + 21f - vector2.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        float num4 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        if ((double) num4 > 800.0)
        {
          this.position.X = (float) (this.aabb.X = Main.player[(int) this.owner].aabb.X + 10 - ((int) this.width >> 1));
          this.position.Y = (float) (this.aabb.Y = Main.player[(int) this.owner].aabb.Y + 21 - ((int) this.height >> 1));
        }
        else if ((double) num4 > 70.0)
        {
          float num5 = 2.5f / num4;
          float num6 = num1 * num5;
          float num7 = num2 * num5;
          this.velocity.X = num6;
          this.velocity.Y = num7;
        }
        else
        {
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
        }
      }
      else
        this.Kill();
    }

    private unsafe void FairyAI()
    {
      if ((double) this.velocity.X > 0.0)
        this.spriteDirection = (sbyte) -1;
      else if ((double) this.velocity.X < 0.0)
        this.spriteDirection = (sbyte) 1;
      this.rotation = this.velocity.X * 0.1f;
      if ((int) ++this.frameCounter >= 4)
      {
        this.frameCounter = (byte) 0;
        this.frame = (byte) ((int) this.frame + 1 & 3);
      }
      if (Main.rand.Next(6) == 0)
      {
        int Type = 56;
        if ((int) this.type == 86)
          Type = 73;
        else if ((int) this.type == 87)
          Type = 74;
        Dust* dustPtr = Main.dust.NewDust(Type, ref this.aabb, 0.0, 0.0, 200, new Color(), 0.800000011920929);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.3f;
          dustPtr->velocity.Y *= 0.3f;
        }
      }
      if (this.isLocal() && Main.player[(int) this.owner].fairy)
        this.timeLeft = 2;
      if (!Main.player[(int) this.owner].dead)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.owner].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.owner].position.Y + 21f - vector2.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        if ((double) num3 > 800.0)
        {
          this.position.X = (float) (this.aabb.X = Main.player[(int) this.owner].aabb.X + 10 - ((int) this.width >> 1));
          this.position.Y = (float) (this.aabb.Y = Main.player[(int) this.owner].aabb.Y + 21 - ((int) this.height >> 1));
        }
        else if ((double) num3 > 40.0)
        {
          float num4 = 3.5f / num3;
          float num5 = num1 * num4;
          float num6 = num2 * num4;
          this.velocity.X = num5;
          this.velocity.Y = num6;
        }
        else
        {
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
        }
      }
      else
        this.Kill();
    }

    private unsafe void BlueFlameAI()
    {
      this.scale -= 0.04f;
      if ((double) this.scale <= 0.0)
        this.Kill();
      if ((double) this.ai0 > 4.0)
      {
        this.alpha = (byte) 150;
        this.light = 0.8f;
        Dust* dustPtr = Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 2.5);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 1.5);
        }
      }
      else
        ++this.ai0;
      this.rotation += 0.3f * (float) this.direction;
    }

    private void HarpoonAI()
    {
      if (Main.player[(int) this.owner].dead)
      {
        this.Kill();
      }
      else
      {
        Main.player[(int) this.owner].itemAnimation = (short) 5;
        Main.player[(int) this.owner].itemTime = (byte) 5;
        Main.player[(int) this.owner].direction = this.aabb.X + ((int) this.width >> 1) <= Main.player[(int) this.owner].aabb.X + 10 ? (sbyte) -1 : (sbyte) 1;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.owner].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.owner].position.Y + 21f - vector2.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        if ((double) this.ai0 == 0.0)
        {
          if ((double) num3 > 700.0)
            this.ai0 = 1f;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
          if (++this.ai1 <= 2)
            return;
          this.alpha = (byte) 0;
          if (this.ai1 < 10)
            return;
          this.velocity.Y += 0.3f;
        }
        else
        {
          if ((double) this.ai0 != 1.0)
            return;
          this.tileCollide = false;
          this.rotation = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
          float num4 = 20f;
          if ((double) num3 < 50.0)
            this.Kill();
          float num5 = num4 / num3;
          float num6 = num1 * num5;
          float num7 = num2 * num5;
          this.velocity.X = num6;
          this.velocity.Y = num7;
        }
      }
    }

    private void SpikyBallAI()
    {
      if ((int) this.type == 53)
      {
        int num1 = (this.aabb.X >> 4) - 1;
        int num2 = (this.aabb.X + (int) this.width >> 4) + 2;
        int num3 = (this.aabb.Y >> 4) - 1;
        int num4 = (this.aabb.Y + (int) this.height >> 4) + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > (int) Main.maxTilesX)
          num2 = (int) Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesY)
          num4 = (int) Main.maxTilesY;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if (Main.tile[index1, index2].canStandOnTop())
            {
              Vector2 vector2;
              vector2.X = (float) (index1 * 16);
              vector2.Y = (float) (index2 * 16);
              if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && ((double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0))
              {
                this.velocity.X = 0.0f;
                this.velocity.Y = -0.2f;
              }
            }
          }
        }
      }
      ++this.ai0;
      if ((double) this.ai0 > 5.0)
      {
        this.ai0 = 5f;
        if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X != 0.0)
        {
          this.velocity.X *= 0.97f;
          if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
          {
            this.velocity.X = 0.0f;
            this.netUpdate = true;
          }
        }
        this.velocity.Y += 0.2f;
      }
      this.rotation += this.velocity.X * 0.1f;
      if ((double) this.velocity.Y <= 16.0)
        return;
      this.velocity.Y = 16f;
    }

    private unsafe void FlailAI()
    {
      if ((int) this.type == 25)
      {
        if (Main.rand.Next(16) == 0)
          Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.29999995231628);
      }
      else if ((int) this.type == 26)
      {
        Dust* dustPtr = Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X * 0.400000005960464, (double) this.velocity.Y * 0.400000005960464, 100, new Color(), 2.5);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.5f;
        }
      }
      else if ((int) this.type == 35)
      {
        Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.400000005960464, (double) this.velocity.Y * 0.400000005960464, 100, new Color(), 3.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 2f;
          dustPtr->velocity.Y *= 2f;
        }
      }
      if (Main.player[(int) this.owner].dead)
      {
        this.Kill();
      }
      else
      {
        Main.player[(int) this.owner].itemAnimation = (short) 10;
        Main.player[(int) this.owner].itemTime = (byte) 10;
        if (this.aabb.X + ((int) this.width >> 1) > Main.player[(int) this.owner].aabb.X + 10)
        {
          Main.player[(int) this.owner].direction = (sbyte) 1;
          this.direction = (sbyte) 1;
        }
        else
        {
          Main.player[(int) this.owner].direction = (sbyte) -1;
          this.direction = (sbyte) -1;
        }
        Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.owner].position.X + 10f - vector2_1.X;
        float num2 = Main.player[(int) this.owner].position.Y + 21f - vector2_1.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        if ((double) this.ai0 == 0.0)
        {
          float num4 = 160f;
          if ((int) this.type == 63)
            num4 *= 1.5f;
          this.tileCollide = true;
          if ((double) num3 > (double) num4)
          {
            this.ai0 = 1f;
            this.netUpdate = true;
          }
          else if (!Main.player[(int) this.owner].channel)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.9f;
            ++this.velocity.Y;
            this.velocity.X *= 0.9f;
          }
        }
        else if ((double) this.ai0 == 1.0)
        {
          float num4 = 14f / Main.player[(int) this.owner].meleeSpeed;
          float num5 = 0.9f / Main.player[(int) this.owner].meleeSpeed;
          float num6 = 300f;
          if ((int) this.type == 63)
          {
            num6 *= 1.5f;
            num4 *= 1.5f;
            num5 *= 1.5f;
          }
          double num7 = (double) Math.Abs(num1);
          double num8 = (double) Math.Abs(num2);
          if (this.ai1 == 1)
            this.tileCollide = false;
          if (!Main.player[(int) this.owner].channel || (double) num3 > (double) num6 || !this.tileCollide)
          {
            this.ai1 = 1;
            if (this.tileCollide)
              this.netUpdate = true;
            this.tileCollide = false;
            if ((double) num3 < 20.0)
              this.Kill();
          }
          if (!this.tileCollide)
            num5 *= 2f;
          if ((double) num3 > 60.0 || !this.tileCollide)
          {
            float num9 = num4 / num3;
            num1 *= num9;
            num2 *= num9;
            Vector2 vector2_2 = new Vector2(this.velocity.X, this.velocity.Y);
            float num10 = num1 - this.velocity.X;
            float num11 = num2 - this.velocity.Y;
            float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
            float num13 = num5 / num12;
            float num14 = num10 * num13;
            float num15 = num11 * num13;
            this.velocity.X *= 0.98f;
            this.velocity.Y *= 0.98f;
            this.velocity.X += num14;
            this.velocity.Y += num15;
          }
          else
          {
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < 6.0)
            {
              this.velocity.X *= 0.96f;
              this.velocity.Y += 0.2f;
            }
            if ((double) Main.player[(int) this.owner].velocity.X == 0.0)
              this.velocity.X *= 0.96f;
          }
        }
        this.rotation = (float) Math.Atan2((double) num2, (double) num1) - this.velocity.X * 0.1f;
      }
    }

    private unsafe void BombAI()
    {
      if ((int) this.type == 108)
      {
        ++this.ai0;
        if ((double) this.ai0 > 3.0)
          this.Kill();
      }
      if ((int) this.type == 37)
      {
        int num1 = (this.aabb.X >> 4) - 1;
        int num2 = (this.aabb.X + (int) this.width >> 4) + 2;
        int num3 = (this.aabb.Y >> 4) - 1;
        int num4 = (this.aabb.Y + (int) this.height >> 4) + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > (int) Main.maxTilesX)
          num2 = (int) Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesY)
          num4 = (int) Main.maxTilesY;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if (Main.tile[index1, index2].canStandOnTop())
            {
              Vector2 vector2;
              vector2.X = (float) (index1 * 16);
              vector2.Y = (float) (index2 * 16);
              if ((double) this.position.X + (double) this.width - 4.0 > (double) vector2.X && (double) this.position.X + 4.0 < (double) vector2.X + 16.0 && ((double) this.position.Y + (double) this.height - 4.0 > (double) vector2.Y && (double) this.position.Y + 4.0 < (double) vector2.Y + 16.0))
              {
                this.velocity.X = 0.0f;
                this.velocity.Y = -0.2f;
              }
            }
          }
        }
      }
      if ((int) this.type == 102)
      {
        if ((double) this.velocity.Y > 10.0)
          this.velocity.Y = 10f;
        if ((int) this.localAI0 == 0)
        {
          this.localAI0 = (sbyte) 1;
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 10);
        }
        if ((int) ++this.frameCounter > 3)
        {
          this.frameCounter = (byte) 0;
          this.frame ^= (byte) 1;
        }
        if ((double) this.velocity.Y == 0.0 && (int) this.width != 128)
        {
          this.position.X += (float) ((int) this.width >> 1);
          this.position.Y += (float) ((int) this.height >> 1);
          this.aabb.Width = (int) (this.width = (ushort) 128);
          this.aabb.Height = (int) (this.height = (ushort) 128);
          this.position.X -= 64f;
          this.position.Y -= 64f;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
          this.damage = (short) 40;
          this.knockBack = 8f;
          this.timeLeft = 3;
          this.netUpdate = true;
        }
      }
      if (this.timeLeft <= 3 && this.isLocal())
      {
        this.ai1 = 0;
        this.alpha = byte.MaxValue;
        if ((int) this.type == 28 || (int) this.type == 37 || (int) this.type == 75)
        {
          if ((int) this.width != 128)
          {
            this.position.X += (float) ((int) this.width >> 1);
            this.position.Y += (float) ((int) this.height >> 1);
            this.aabb.Width = (int) (this.width = (ushort) 128);
            this.aabb.Height = (int) (this.height = (ushort) 128);
            this.position.X -= 64f;
            this.position.Y -= 64f;
            this.aabb.X = (int) this.position.X;
            this.aabb.Y = (int) this.position.Y;
            this.damage = (short) 100;
            this.knockBack = 8f;
          }
        }
        else if ((int) this.type == 29)
        {
          if ((int) this.width != 250)
          {
            this.position.X += (float) ((int) this.width >> 1);
            this.position.Y += (float) ((int) this.height >> 1);
            this.aabb.Width = (int) (this.width = (ushort) 250);
            this.aabb.Height = (int) (this.height = (ushort) 250);
            this.position.X -= 125f;
            this.position.Y -= 125f;
            this.aabb.X = (int) this.position.X;
            this.aabb.Y = (int) this.position.Y;
            this.damage = (short) 250;
            this.knockBack = 10f;
          }
        }
        else if ((int) this.type == 30 && (int) this.width != 128)
        {
          this.position.X += (float) ((int) this.width >> 1);
          this.position.Y += (float) ((int) this.height >> 1);
          this.aabb.Width = (int) (this.width = (ushort) 128);
          this.aabb.Height = (int) (this.height = (ushort) 128);
          this.position.X -= 64f;
          this.position.Y -= 64f;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
          this.knockBack = 8f;
        }
      }
      else if ((int) this.type != 30)
      {
        if ((int) this.type != 108)
          this.damage = (short) 0;
        if (Main.rand.Next(5) == 0)
          Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
      }
      ++this.ai0;
      if ((int) this.type == 30 && (double) this.ai0 > 10.0 || (int) this.type != 30 && (double) this.ai0 > 5.0)
      {
        if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X != 0.0)
        {
          this.velocity.X *= 0.97f;
          if ((int) this.type == 29)
            this.velocity.X *= 0.99f;
          if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
          {
            this.velocity.X = 0.0f;
            this.netUpdate = true;
          }
        }
        this.velocity.Y += 0.2f;
      }
      this.rotation += this.velocity.X * 0.1f;
    }

    private void TombstoneAI()
    {
      if ((double) this.velocity.Y == 0.0)
        this.velocity.X *= 0.98f;
      this.rotation += this.velocity.X * 0.1f;
      this.velocity.Y += 0.2f;
      if (!this.isLocal())
        return;
      int index1 = this.aabb.X + ((int) this.width >> 1) >> 4;
      int index2 = this.aabb.Y + (int) this.height - 4 >> 4;
      if ((int) Main.tile[index1, index2].active != 0 || !WorldGen.PlaceTile(index1, index2, 85, false, false, -1, 0))
        return;
      NetMessage.CreateMessage5(17, 1, index1, index2, 85, 0);
      NetMessage.SendMessage();
      int index3 = Sign.ReadSign(index1, index2);
      if (index3 >= 0)
        Main.sign[index3].SetText((UserString) Projectile.tombstoneText[(int) this.tombstoneTextId]);
      this.Kill();
    }

    private unsafe void DemonSickleAI()
    {
      if (this.ai1 == 0 && (int) this.type == 44)
      {
        this.ai1 = 1;
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
      }
      this.rotation += (float) this.direction * 0.8f;
      if ((double) ++this.ai0 >= 30.0)
      {
        if ((double) this.ai0 < 100.0)
        {
          this.velocity.X *= 1.06f;
          this.velocity.Y *= 1.06f;
        }
        else
          this.ai0 = 200f;
      }
      for (int index = 0; index < 2; ++index)
      {
        Dust* dustPtr = Main.dust.NewDust(27, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          break;
        dustPtr->noGravity = true;
      }
    }

    private unsafe void SpearAI()
    {
      this.direction = Main.player[(int) this.owner].direction;
      Main.player[(int) this.owner].heldProj = this.whoAmI;
      Main.player[(int) this.owner].itemTime = (byte) Main.player[(int) this.owner].itemAnimation;
      this.position.X = Main.player[(int) this.owner].position.X + (float) (20 - (int) this.width >> 1);
      this.position.Y = Main.player[(int) this.owner].position.Y + (float) (42 - (int) this.height >> 1);
      if ((int) this.type == 46)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 1.6f;
        else
          this.ai0 += 1.4f;
      }
      else if ((int) this.type == 105)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 2.4f;
        else
          this.ai0 += 2.1f;
      }
      else if ((int) this.type == 112)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 2.4f;
        else
          this.ai0 += 2.1f;
      }
      else if ((int) this.type == 47)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 4f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 1.2f;
        else
          this.ai0 += 0.9f;
      }
      else if ((int) this.type == 49)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 4f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 1.1f;
        else
          this.ai0 += 0.85f;
      }
      else if ((int) this.type == 64)
      {
        this.spriteDirection = -this.direction;
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 1.9f;
        else
          this.ai0 += 1.7f;
      }
      else if ((int) this.type == 66 || (int) this.type == 97)
      {
        this.spriteDirection = -this.direction;
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 2.1f;
        else
          this.ai0 += 1.9f;
      }
      else if ((int) this.type == 97)
      {
        this.spriteDirection = -this.direction;
        if ((double) this.ai0 == 0.0)
        {
          this.ai0 = 3f;
          this.netUpdate = true;
        }
        if ((int) Main.player[(int) this.owner].itemAnimation < (int) Main.player[(int) this.owner].itemAnimationMax / 3)
          this.ai0 -= 1.6f;
        else
          this.ai0 += 1.4f;
      }
      this.position.X += this.velocity.X * this.ai0;
      this.position.Y += this.velocity.Y * this.ai0;
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      if ((int) Main.player[(int) this.owner].itemAnimation == 0)
        this.Kill();
      this.rotation = (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 2.355);
      if ((int) this.spriteDirection == -1)
        this.rotation -= 1.57f;
      if ((int) this.type == 46)
      {
        if (Main.rand.Next(6) == 0)
          Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.39999997615814);
        Dust* dustPtr1 = Main.dust.NewDust(27, ref this.aabb, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.20000004768372);
        if ((IntPtr) dustPtr1 == IntPtr.Zero)
          return;
        dustPtr1->noGravity = true;
        dustPtr1->velocity.X *= 0.5f;
        dustPtr1->velocity.Y *= 0.5f;
        Dust* dustPtr2 = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0), (int) this.width, (int) this.height, 27, 0.0, 0.0, 150, new Color(), 1.39999997615814);
        if ((IntPtr) dustPtr2 == IntPtr.Zero)
          return;
        dustPtr2->velocity.X *= 0.2f;
        dustPtr2->velocity.Y *= 0.2f;
      }
      else if ((int) this.type == 105)
      {
        if (Main.rand.Next(4) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(57, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 200, new Color(), 1.20000004768372);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X += this.velocity.X * 0.3f;
            dustPtr->velocity.Y += this.velocity.Y * 0.3f;
            dustPtr->velocity.X *= 0.2f;
            dustPtr->velocity.Y *= 0.2f;
          }
        }
        if (Main.rand.Next(5) != 0)
          return;
        Dust* dustPtr1 = Main.dust.NewDust(43, ref this.aabb, 0.0, 0.0, 254, new Color(), 0.300000011920929);
        if ((IntPtr) dustPtr1 == IntPtr.Zero)
          return;
        dustPtr1->velocity.X += this.velocity.X * 0.5f;
        dustPtr1->velocity.Y += this.velocity.Y * 0.5f;
        dustPtr1->velocity.X *= 0.5f;
        dustPtr1->velocity.Y *= 0.5f;
      }
      else
      {
        if ((int) this.type != 112)
          return;
        if (Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(57, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 200, new Color(), 1.20000004768372);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X += this.velocity.X * 0.3f;
            dustPtr->velocity.Y += this.velocity.Y * 0.3f;
            dustPtr->velocity.X *= 0.2f;
            dustPtr->velocity.Y *= 0.2f;
          }
        }
        if (Main.rand.Next(4) != 0)
          return;
        Dust* dustPtr1 = Main.dust.NewDust(43, ref this.aabb, 0.0, 0.0, 254, new Color(), 0.300000011920929);
        if ((IntPtr) dustPtr1 == IntPtr.Zero)
          return;
        dustPtr1->velocity.X += this.velocity.X * 0.5f;
        dustPtr1->velocity.Y += this.velocity.Y * 0.5f;
        dustPtr1->velocity.X *= 0.5f;
        dustPtr1->velocity.Y *= 0.5f;
      }
    }

    private unsafe void ChainsawAI()
    {
      if ((int) this.soundDelay <= 0)
      {
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 22);
        this.soundDelay = (short) 30;
      }
      Player player = Main.player[(int) this.owner];
      if (player.isLocal())
      {
        if (player.channel)
        {
          float num1 = player.inventory[(int) player.selectedItem].shootSpeed * this.scale;
          Vector2 vector2 = new Vector2(player.position.X + 10f, player.position.Y + 21f);
          float num2 = (float) ((int) player.ui.mouseX + player.view.screenPosition.X) - vector2.X;
          float num3 = (float) ((int) player.ui.mouseY + player.view.screenPosition.Y) - vector2.Y;
          float num4 = (float) ((double) num2 * (double) num2 + (double) num3 * (double) num3);
          if ((double) num4 > 0.0)
          {
            float num5 = (float) Math.Sqrt((double) num4);
            float num6 = num1 / num5;
            num2 *= num6;
            num3 *= num6;
          }
          if ((double) num2 != (double) this.velocity.X || (double) num3 != (double) this.velocity.Y)
            this.netUpdate = true;
          this.velocity.X = num2;
          this.velocity.Y = num3;
        }
        else
          this.Kill();
      }
      if ((double) this.velocity.X > 0.0)
        this.direction = (sbyte) 1;
      else if ((double) this.velocity.X < 0.0)
        this.direction = (sbyte) -1;
      this.spriteDirection = this.direction;
      player.direction = this.direction;
      player.heldProj = this.whoAmI;
      player.itemTime = (byte) 2;
      player.itemAnimation = (short) 2;
      this.position.X = player.position.X + 10f - (float) ((int) this.width >> 1);
      this.position.Y = player.position.Y + 21f - (float) ((int) this.height >> 1);
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      this.rotation = (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57000005245209);
      player.itemRotation = (float) Math.Atan2((double) this.velocity.Y * (double) this.direction, (double) this.velocity.X * (double) this.direction);
      this.velocity.X *= (float) (1.0 + (double) Main.rand.Next(-3, 4) * 0.00999999977648258);
      if (Main.rand.Next(8) != 0)
        return;
      float num = (float) Main.rand.Next(6, 10) * 0.1f;
      Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X + (double) this.velocity.X * (double) num) - 4, (int) ((double) this.position.Y + (double) this.velocity.Y * (double) num), (int) this.width, (int) this.height, 31, 0.0, 0.0, 80, new Color(), 1.39999997615814);
      if ((IntPtr) dustPtr == IntPtr.Zero)
        return;
      dustPtr->noGravity = true;
      dustPtr->velocity.X *= 0.2f;
      dustPtr->velocity.Y = (float) -Main.rand.Next(7, 13) * 0.15f;
    }

    private unsafe void NoteAI()
    {
      this.rotation = this.velocity.X * 0.1f;
      this.spriteDirection = -this.direction;
      if (Main.rand.Next(4) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(27, ref this.aabb, 0.0, 0.0, 80, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 0.2f;
          dustPtr->velocity.Y *= 0.2f;
        }
      }
      if (this.ai1 != 1)
        return;
      this.ai1 = 0;
      Main.harpNote = this.ai0;
      Main.PlaySound(2, this.aabb.X, this.aabb.Y, 26);
    }

    private unsafe void IceBlockAI()
    {
      if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        this.alpha = byte.MaxValue;
      if (this.ai1 < 0)
      {
        if ((double) this.velocity.X > 0.0)
          this.rotation += 0.3f;
        else
          this.rotation -= 0.3f;
        int num1 = (this.aabb.X >> 4) - 1;
        int num2 = (this.aabb.X + (int) this.width >> 4) + 2;
        int num3 = (this.aabb.Y >> 4) - 1;
        int num4 = (this.aabb.Y + (int) this.height >> 4) + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > (int) Main.maxTilesX)
          num2 = (int) Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesY)
          num4 = (int) Main.maxTilesY;
        int num5 = this.aabb.X + 4;
        int num6 = this.aabb.Y + 4;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
            {
              int index3 = (int) Main.tile[index1, index2].type;
              if (index3 != (int) sbyte.MaxValue && Main.tileSolidNotSolidTop[index3])
              {
                Vector2 vector2;
                vector2.X = (float) (index1 * 16);
                vector2.Y = (float) (index2 * 16);
                if ((double) (num5 + 8) > (double) vector2.X && (double) num5 < (double) vector2.X + 16.0 && ((double) (num6 + 8) > (double) vector2.Y && (double) num6 < (double) vector2.Y + 16.0))
                  this.Kill();
              }
            }
          }
        }
        Dust* dustPtr = Main.dust.NewDust(67, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          return;
        dustPtr->noGravity = true;
        dustPtr->velocity.X *= 0.3f;
        dustPtr->velocity.Y *= 0.3f;
      }
      else if ((double) this.ai0 < 0.0)
      {
        if ((double) this.ai0 == -1.0)
        {
          for (int index = 0; index < 8; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(67, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.10000002384186);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->noGravity = true;
              dustPtr->velocity.X *= 1.3f;
              dustPtr->velocity.Y *= 1.3f;
            }
            else
              break;
          }
        }
        else if (Main.rand.Next(32) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(67, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.2f;
            dustPtr->velocity.Y *= 0.2f;
          }
        }
        int index1 = this.aabb.X >> 4;
        int index2 = this.aabb.Y >> 4;
        if ((int) Main.tile[index1, index2].active == 0)
          this.Kill();
        if ((double) --this.ai0 > -300.0 || !this.isLocal() || ((int) Main.tile[index1, index2].type != (int) sbyte.MaxValue || (int) Main.tile[index1, index2].active == 0))
          return;
        WorldGen.KillTile(index1, index2);
        NetMessage.CreateMessage5(17, 0, index1, index2, 0, 0);
        NetMessage.SendMessage();
        this.Kill();
      }
      else
      {
        int num1 = (this.aabb.X >> 4) - 1;
        int num2 = (this.aabb.X + (int) this.width >> 4) + 2;
        int num3 = (this.aabb.Y >> 4) - 1;
        int num4 = (this.aabb.Y + (int) this.height >> 4) + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > (int) Main.maxTilesX)
          num2 = (int) Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesY)
          num4 = (int) Main.maxTilesY;
        int num5 = this.aabb.X + 4;
        int num6 = this.aabb.Y + 4;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type != (int) sbyte.MaxValue && Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2].type])
            {
              Vector2 vector2;
              vector2.X = (float) (index1 * 16);
              vector2.Y = (float) (index2 * 16);
              if ((double) (num5 + 8) > (double) vector2.X && (double) num5 < (double) vector2.X + 16.0 && ((double) (num6 + 8) > (double) vector2.Y && (double) num6 < (double) vector2.Y + 16.0))
                this.Kill();
            }
          }
        }
        if (this.lavaWet)
          this.Kill();
        if ((int) this.active == 0)
          return;
        Dust* dustPtr = Main.dust.NewDust(67, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 0.3f;
          dustPtr->velocity.Y *= 0.3f;
        }
        int i = (int) this.ai0;
        int j = this.ai1;
        if ((double) this.velocity.X > 0.0)
          this.rotation += 0.3f;
        else
          this.rotation -= 0.3f;
        if (!this.isLocal())
          return;
        int num7 = this.aabb.X + ((int) this.width >> 1) >> 4;
        int num8 = this.aabb.Y + ((int) this.height >> 1) >> 4;
        if ((num7 != i || num8 != j) && (((double) this.velocity.X > 0.0 || num7 > i) && ((double) this.velocity.X < 0.0 || num7 < i) || ((double) this.velocity.Y > 0.0 || num8 > j) && ((double) this.velocity.Y < 0.0 || num8 < j)))
          return;
        if (WorldGen.PlaceTile(i, j, (int) sbyte.MaxValue, false, false, (int) this.owner, 0))
        {
          NetMessage.CreateMessage5(17, 1, (int) this.ai0, this.ai1, (int) sbyte.MaxValue, 0);
          NetMessage.SendMessage();
          this.damage = (short) 0;
          this.ai0 = -1f;
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
          this.alpha = byte.MaxValue;
          this.position.X = (float) (this.aabb.X = i * 16);
          this.position.Y = (float) (this.aabb.Y = j * 16);
          this.netUpdate = true;
        }
        else
          this.ai1 = -1;
      }
    }

    private unsafe void FlameAI()
    {
      if (this.timeLeft > 60)
        this.timeLeft = 60;
      if ((double) this.ai0 > 7.0)
      {
        float num = 1f;
        if ((double) this.ai0 == 8.0)
          num = 0.25f;
        else if ((double) this.ai0 == 9.0)
          num = 0.5f;
        else if ((double) this.ai0 == 10.0)
          num = 0.75f;
        ++this.ai0;
        int Type = (int) this.type == 101 ? 75 : 6;
        if (Type == 6 || Main.rand.Next(3) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(Type, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            if (Main.rand.Next(3) != 0 || Type == 75 && Main.rand.Next(3) == 0)
            {
              dustPtr->noGravity = true;
              dustPtr->scale *= 3f;
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
            }
            dustPtr->scale *= num * 1.5f;
            dustPtr->velocity.X *= 1.2f;
            dustPtr->velocity.Y *= 1.2f;
            if (Type == 75)
            {
              dustPtr->velocity.X += this.velocity.X;
              dustPtr->velocity.Y += this.velocity.Y;
              if (!dustPtr->noGravity)
              {
                dustPtr->velocity.X *= 0.5f;
                dustPtr->velocity.Y *= 0.5f;
              }
            }
          }
        }
      }
      else
        ++this.ai0;
      this.rotation += 0.3f * (float) this.direction;
    }

    private unsafe void CrystalShardAI()
    {
      this.light = this.scale * 0.5f;
      this.rotation += this.velocity.X * 0.2f;
      ++this.ai1;
      if ((int) this.type == 94)
      {
        if (Main.rand.Next(4) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(70, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 0.5f;
            dustPtr->velocity.Y *= 0.5f;
            dustPtr->scale *= 0.9f;
          }
        }
        this.velocity.X *= 0.985f;
        this.velocity.Y *= 0.985f;
        if (this.ai1 <= 130)
          return;
        this.scale -= 0.05f;
        if ((double) this.scale > 0.2)
          return;
        this.scale = 0.2f;
        this.Kill();
      }
      else
      {
        this.velocity.X *= 0.96f;
        this.velocity.Y *= 0.96f;
        if (this.ai1 <= 15)
          return;
        this.scale -= 0.05f;
        if ((double) this.scale > 0.2)
          return;
        this.scale = 0.2f;
        this.Kill();
      }
    }

    private void BoulderAI()
    {
      if ((double) this.ai0 != 0.0 && (double) this.velocity.Y <= 0.0 && (double) this.velocity.X == 0.0)
      {
        int i1 = this.aabb.X - 8 >> 4;
        int j1 = this.aabb.Y >> 4;
        bool flag1 = WorldGen.SolidTile(i1, j1) || WorldGen.SolidTile(i1, j1 + 1);
        int i2 = this.aabb.X + (int) this.width + 8 >> 4;
        bool flag2 = flag1 || WorldGen.SolidTile(i2, j1) || WorldGen.SolidTile(i2, j1 + 1);
        if (flag1)
          this.velocity.X = 0.5f;
        else if (flag2)
        {
          this.velocity.X = -0.5f;
        }
        else
        {
          int i3 = this.aabb.X - 8 - 16 >> 4;
          int j2 = this.aabb.Y >> 4;
          bool flag3 = WorldGen.SolidTile(i3, j2) || WorldGen.SolidTile(i3, j2 + 1);
          int i4 = this.aabb.X + (int) this.width + 8 + 16 >> 4;
          bool flag4 = flag3 || WorldGen.SolidTile(i4, j2) || WorldGen.SolidTile(i4, j2 + 1);
          if (flag3)
            this.velocity.X = 0.5f;
          else if (flag4)
          {
            this.velocity.X = -0.5f;
          }
          else
          {
            int i5 = this.aabb.X + 4 >> 4;
            int j3 = this.aabb.Y + (int) this.height + 8 >> 4;
            this.velocity.X = WorldGen.SolidTile(i5, j3) || WorldGen.SolidTile(i5, j3 + 1) ? -0.5f : 0.5f;
          }
        }
      }
      this.rotation += this.velocity.X * 0.06f;
      this.ai0 = 1f;
      if ((double) this.velocity.Y > 16.0)
        this.velocity.Y = 16f;
      else if ((double) this.velocity.Y <= 6.0)
      {
        if ((double) this.velocity.X > 0.0 && (double) this.velocity.X < 7.0)
          this.velocity.X += 0.05f;
        else if ((double) this.velocity.X < 0.0 && (double) this.velocity.X > -7.0)
          this.velocity.X -= 0.05f;
      }
      this.velocity.Y += 0.3f;
    }

    public unsafe void Kill()
    {
      if ((int) this.active == 0)
        return;
      this.timeLeft = 0;
      int num1 = this.aabb.X = (int) this.position.X;
      int num2 = this.aabb.Y = (int) this.position.Y;
      if ((int) this.type == 1 || (int) this.type == 81 || (int) this.type == 98)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 8; ++index)
          Main.dust.NewDust(7, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
      }
      else if ((int) this.type == 93)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 8; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(57, ref this.aabb, 0.0, 0.0, 100, new Color(), 0.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->velocity *= 2f;
          else
            break;
        }
      }
      else if ((int) this.type == 99)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 24; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(1, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            if (Main.rand.Next(2) == 0)
              dustPtr->scale *= 1.4f;
            this.velocity.X *= 1.9f;
            this.velocity.Y *= 1.9f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 91 || (int) this.type == 92)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 8; ++index)
          Main.dust.NewDust(58, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 150, new Color(), 1.20000004768372);
        for (int index = 0; index < 3; ++index)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1.0);
        if ((int) this.type == 12 && (int) this.damage < 500)
        {
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(57, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 150, new Color(), 1.20000004768372);
          for (int index = 0; index < 3; ++index)
            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1.0);
        }
        if (((int) this.type == 91 || (int) this.type == 92 && (double) this.ai0 > 0.0) && this.isLocal())
        {
          int number = this.NewClonedProjectile(92);
          if (number >= 0)
          {
            float num3 = (float) Main.rand.Next(-400, 400);
            float num4 = (float) -Main.rand.Next(600, 900);
            Main.projectile[number].position.X += num3;
            Main.projectile[number].position.Y += num4;
            float num5 = 22f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
            float num6 = num3 * num5;
            float num7 = num4 * num5;
            Main.projectile[number].velocity.X = num6;
            Main.projectile[number].velocity.Y = num7;
            if ((int) this.type == 91)
            {
              Main.projectile[number].damage >>= 1;
              Main.projectile[number].ai0 = 1f;
            }
            Main.projectile[number].ai1 = num2;
            NetMessage.SendProjectile(number, SendDataOptions.Reliable);
          }
        }
      }
      else if ((int) this.type == 89)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(68, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
            dustPtr->scale *= 0.9f;
          }
          else
            break;
        }
        if (this.isLocal())
        {
          for (int index = 0; index < 3; ++index)
          {
            float SpeedX = (float) (-(double) this.velocity.X * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
            float SpeedY = (float) (-(double) this.velocity.Y * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
            Projectile.NewProjectile(this.position.X + SpeedX, this.position.Y + SpeedY, SpeedX, SpeedY, 90, (int) ((double) this.damage * 0.6), 0.0f, (int) this.owner, true);
          }
        }
      }
      else if ((int) this.type == 80)
      {
        if ((double) this.ai0 >= 0.0)
        {
          Main.PlaySound(2, num1, num2, 27);
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(67, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
        }
        int i = num1 >> 4;
        int j = num2 >> 4;
        if ((int) Main.tile[i, j].type == (int) sbyte.MaxValue && (int) Main.tile[i, j].active != 0)
          WorldGen.KillTile(i, j);
      }
      else if ((int) this.type == 76 || (int) this.type == 77 || (int) this.type == 78)
      {
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(27, ref this.aabb, 0.0, 0.0, 80, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->noGravity = true;
          else
            break;
        }
      }
      else if ((int) this.type == 55)
      {
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(18, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
            dustPtr->noGravity = true;
          else
            break;
        }
      }
      else if ((int) this.type == 51)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 4; ++index)
          Main.dust.NewDust(0, ref this.aabb, 0.0, 0.0, 0, new Color(), 0.699999988079071);
      }
      else if ((int) this.type == 2 || (int) this.type == 82)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 16; ++index)
          Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
      }
      else if ((int) this.type == 103)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 14; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(75, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            if (Main.rand.Next(2) == 0)
            {
              dustPtr->scale *= 2.5f;
              dustPtr->noGravity = true;
              dustPtr->velocity.X *= 5f;
              dustPtr->velocity.Y *= 5f;
            }
          }
          else
            break;
        }
      }
      else if ((int) this.type == 3 || (int) this.type == 48 || (int) this.type == 54)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 7; ++index)
          Main.dust.NewDust(1, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 0, new Color(), 0.75);
      }
      else if ((int) this.type == 4)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 7; ++index)
          Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.10000002384186);
      }
      else if ((int) this.type == 5)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 48; ++index)
        {
          int Type;
          switch (Main.rand.Next(3))
          {
            case 0:
              Type = 15;
              break;
            case 1:
              Type = 57;
              break;
            default:
              Type = 58;
              break;
          }
          Main.dust.NewDust(Type, ref this.aabb, (double) this.velocity.X * 0.5, (double) this.velocity.Y * 0.5, 150, new Color(), 1.5);
        }
      }
      else if ((int) this.type == 9 || (int) this.type == 12)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 8; ++index)
          Main.dust.NewDust(58, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 150, new Color(), 1.20000004768372);
        for (int index = 0; index < 3; ++index)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1.0);
        if ((int) this.type == 12 && (int) this.damage < 100)
        {
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(57, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 150, new Color(), 1.20000004768372);
          for (int index = 0; index < 3; ++index)
            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1.0);
        }
      }
      else if ((int) this.type == 14 || (int) this.type == 20 || ((int) this.type == 36 || (int) this.type == 83) || ((int) this.type == 84 || (int) this.type == 100 || (int) this.type == 110))
      {
        Collision.HitTiles(this.position, this.velocity, (int) this.width, (int) this.height);
        Main.PlaySound(2, num1, num2, 10);
      }
      else if ((int) this.type == 15 || (int) this.type == 34)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 2f;
            dustPtr1->velocity.Y *= 2f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.200000002980232, 100, new Color(), 1.0);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 2f;
              dustPtr2->velocity.Y *= 2f;
            }
            else
              break;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 95 || (int) this.type == 96)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(75, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.200000002980232, 100, new Color(), 2.0 * (double) this.scale);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 2f;
            dustPtr1->velocity.Y *= 2f;
            Dust* dustPtr2 = Main.dust.NewDust(75, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.200000002980232, 100, new Color(), 1.0 * (double) this.scale);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 2f;
              dustPtr2->velocity.Y *= 2f;
            }
            else
              break;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 79)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 12; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(66, ref this.aabb, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 4f;
            dustPtr->velocity.Y *= 4f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 16)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 12; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X), (int) ((double) this.position.Y - (double) this.velocity.Y), (int) this.width, (int) this.height, 15, 0.0, 0.0, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 2f;
            dustPtr->velocity.Y *= 2f;
            Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X), (int) ((double) this.position.Y - (double) this.velocity.Y), (int) this.width, (int) this.height, 15, 0.0, 0.0, 100, new Color(), 1.0);
          }
          else
            break;
        }
      }
      else if ((int) this.type == 17)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 2; ++index)
          Main.dust.NewDust(0, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
      }
      else if ((int) this.type == 31 || (int) this.type == 42)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 2; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(32, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.6f;
            dustPtr->velocity.Y *= 0.6f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 109)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(51, ref this.aabb, 0.0, 0.0, 0, new Color(), 0.600000023841858);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.6f;
            dustPtr->velocity.Y *= 0.6f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 39)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(38, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.6f;
            dustPtr->velocity.Y *= 0.6f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 71)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(53, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.6f;
            dustPtr->velocity.Y *= 0.6f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 40)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(36, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.6f;
            dustPtr->velocity.Y *= 0.6f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 21)
      {
        Main.PlaySound(0, num1, num2, 1);
        for (int index = 0; index < 8; ++index)
          Main.dust.NewDust(26, ref this.aabb, 0.0, 0.0, 0, new Color(), 0.800000011920929);
      }
      else if ((int) this.type == 24)
      {
        for (int index = 0; index < 6; ++index)
          Main.dust.NewDust(1, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 0, new Color(), 0.75);
      }
      else if ((int) this.type == 27)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 20; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 100, new Color(), 3.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 100, new Color(), 2.0);
          }
          else
            break;
        }
      }
      else if ((int) this.type == 38)
      {
        for (int index = 0; index < 6; ++index)
          Main.dust.NewDust(42, ref this.aabb, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 0, new Color(), 1.0);
      }
      else if ((int) this.type == 44 || (int) this.type == 45)
      {
        Main.PlaySound(2, num1, num2, 10);
        for (int index = 0; index < 18; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(27, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 1.70000004768372);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            Main.dust.NewDust(27, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 1.0);
          }
          else
            break;
        }
      }
      else if ((int) this.type == 41 || (int) this.type == 114)
      {
        Main.PlaySound(2, num1, num2, 14);
        int num3 = 0;
        while (num3 < 6 && (IntPtr) Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5) != IntPtr.Zero)
          ++num3;
        int Type = (int) this.type == 114 ? 64 : 6;
        for (int index = 0; index < 3; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(Type, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 3f;
            dustPtr1->velocity.Y *= 3f;
            Dust* dustPtr2 = Main.dust.NewDust(Type, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 2f;
              dustPtr2->velocity.Y *= 2f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity *= 0.4f;
        Main.gore[index1].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
        Main.gore[index1].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity *= 0.4f;
        Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
        Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
        if (this.isLocal())
        {
          this.penetrate = (sbyte) -1;
          this.position.X += (float) ((int) this.width >> 1);
          this.position.Y += (float) ((int) this.height >> 1);
          this.aabb.Width = (int) (this.width = (ushort) 64);
          this.aabb.Height = (int) (this.height = (ushort) 64);
          this.position.X -= (float) ((int) this.width >> 1);
          this.position.Y -= (float) ((int) this.height >> 1);
          num1 = this.aabb.X = (int) this.position.X;
          num2 = this.aabb.Y = (int) this.position.Y;
          this.Damage();
        }
      }
      else if ((int) this.type == 28 || (int) this.type == 30 || ((int) this.type == 37 || (int) this.type == 75) || (int) this.type == 102)
      {
        Main.PlaySound(2, num1, num2, 14);
        this.position.X += (float) ((int) this.width >> 1);
        this.position.Y += (float) ((int) this.height >> 1);
        this.aabb.Width = (int) (this.width = (ushort) 22);
        this.aabb.Height = (int) (this.height = (ushort) 22);
        this.position.X -= (float) ((int) this.width >> 1);
        this.position.Y -= (float) ((int) this.height >> 1);
        num1 = this.aabb.X = (int) this.position.X;
        num2 = this.aabb.Y = (int) this.position.Y;
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 7; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity *= 0.4f;
        ++Main.gore[index1].velocity.X;
        ++Main.gore[index1].velocity.Y;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity *= 0.4f;
        --Main.gore[index2].velocity.X;
        ++Main.gore[index2].velocity.Y;
        int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index3].velocity *= 0.4f;
        ++Main.gore[index3].velocity.X;
        --Main.gore[index3].velocity.Y;
        int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index4].velocity *= 0.4f;
        --Main.gore[index4].velocity.X;
        --Main.gore[index4].velocity.Y;
      }
      else if ((int) this.type == 29 || (int) this.type == 108)
      {
        Main.PlaySound(2, num1, num2, 14);
        if ((int) this.type == 29)
        {
          this.position.X += (float) (((int) this.width >> 1) - 100);
          this.position.Y += (float) (((int) this.height >> 1) - 100);
          num1 = this.aabb.X = (int) this.position.X;
          num2 = this.aabb.Y = (int) this.position.Y;
          this.aabb.Width = (int) (this.width = (ushort) 200);
          this.aabb.Height = (int) (this.height = (ushort) 200);
        }
        for (int index = 0; index < 40; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 64; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 3.0);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.0);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        for (int index1 = 0; index1 < 2; ++index1)
        {
          int index2 = Gore.NewGore(num1 + ((int) this.width >> 1) - 24, num2 + ((int) this.height >> 1) - 24, new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index2].scale = 1.5f;
          Main.gore[index2].velocity.X += 1.5f;
          Main.gore[index2].velocity.Y += 1.5f;
          int index3 = Gore.NewGore(num1 + ((int) this.width >> 1) - 24, num2 + ((int) this.height >> 1) - 24, new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index3].scale = 1.5f;
          Main.gore[index3].velocity.X -= 1.5f;
          Main.gore[index3].velocity.Y += 1.5f;
          int index4 = Gore.NewGore(num1 + ((int) this.width >> 1) - 24, num2 + ((int) this.height >> 1) - 24, new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index4].scale = 1.5f;
          Main.gore[index4].velocity.X += 1.5f;
          Main.gore[index4].velocity.Y -= 1.5f;
          int index5 = Gore.NewGore(num1 + ((int) this.width >> 1) - 24, num2 + ((int) this.height >> 1) - 24, new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index5].scale = 1.5f;
          Main.gore[index5].velocity.X -= 1.5f;
          Main.gore[index5].velocity.Y -= 1.5f;
        }
        this.position.X += (float) (((int) this.width >> 1) - 5);
        this.position.Y += (float) (((int) this.height >> 1) - 5);
        num1 = this.aabb.X = (int) this.position.X;
        num2 = this.aabb.Y = (int) this.position.Y;
        this.aabb.Width = (int) (this.width = (ushort) 10);
        this.aabb.Height = (int) (this.height = (ushort) 10);
      }
      else if ((int) this.type == 69)
      {
        Main.PlaySound(13, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
          Main.dust.NewDust(num1, num2, (int) this.width, (int) this.height, 13, 0.0, 0.0, 0, new Color(), 1.0);
        for (int index = 0; index < 20; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(num1, num2, (int) this.width, (int) this.height, 33, 0.0, -2.0, 0, new Color(), 1.10000002384186);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->alpha = (short) 100;
            dustPtr->velocity.X *= 4.5f;
            dustPtr->velocity.Y *= 3f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 70)
      {
        Main.PlaySound(13, num1, num2, 1);
        for (int index = 0; index < 3; ++index)
          Main.dust.NewDust(num1, num2, (int) this.width, (int) this.height, 13, 0.0, 0.0, 0, new Color(), 1.0);
        for (int index = 0; index < 20; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(num1, num2, (int) this.width, (int) this.height, 52, 0.0, -2.0, 0, new Color(), 1.10000002384186);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->alpha = (short) 100;
            dustPtr->velocity.X *= 4.5f;
            dustPtr->velocity.Y *= 3f;
          }
          else
            break;
        }
      }
      else if ((int) this.type == 111 || (int) this.type >= 115 && (int) this.type <= 119)
      {
        int index = Gore.NewGore(new Vector2((float) (num1 - ((int) this.width >> 1)), (float) (num2 - ((int) this.height >> 1))), new Vector2(), Main.rand.Next(11, 14), (double) this.scale);
        Main.gore[index].velocity *= 0.1f;
      }
      if (this.isLocal())
      {
        if ((int) this.type == 28 || (int) this.type == 29 || ((int) this.type == 37 || (int) this.type == 75) || (int) this.type == 108)
        {
          int num3 = 3;
          if ((int) this.type == 29)
            num3 = 7;
          else if ((int) this.type == 108)
            num3 = 10;
          int num4 = num1 >> 4;
          int num5 = num2 >> 4;
          int num6 = num4 - num3;
          int num7 = num4 + num3;
          int num8 = num5 - num3;
          int num9 = num5 + num3;
          if (num6 < 0)
            num6 = 0;
          if (num7 > (int) Main.maxTilesX)
            num7 = (int) Main.maxTilesX;
          if (num8 < 0)
            num8 = 0;
          if (num9 > (int) Main.maxTilesY)
            num9 = (int) Main.maxTilesY;
          bool flag1 = false;
          for (int index1 = num6; index1 <= num7; ++index1)
          {
            for (int index2 = num8; index2 <= num9; ++index2)
            {
              int num10 = Math.Abs(index1 - num4);
              int num11 = Math.Abs(index2 - num5);
              if (num10 * num10 + num11 * num11 < num3 * num3 && (int) Main.tile[index1, index2].wall == 0)
              {
                flag1 = true;
                break;
              }
            }
          }
          for (int index1 = num6; index1 <= num7; ++index1)
          {
            for (int index2 = num8; index2 <= num9; ++index2)
            {
              int num10 = Math.Abs(index1 - num4);
              int num11 = Math.Abs(index2 - num5);
              if (num10 * num10 + num11 * num11 < num3 * num3)
              {
                bool flag2 = true;
                if ((int) Main.tile[index1, index2].active != 0)
                {
                  int index3 = (int) Main.tile[index1, index2].type;
                  switch (index3)
                  {
                    case 21:
                    case 26:
                    case 107:
                    case 108:
                    case 111:
                      flag2 = false;
                      break;
                    default:
                      if (!Main.tileDungeon[index3])
                      {
                        if (index3 == 58 && !Main.hardMode)
                        {
                          flag2 = false;
                          break;
                        }
                        else if (WorldGen.KillTile(index1, index2))
                        {
                          NetMessage.CreateMessage5(17, 0, index1, index2, 0, 0);
                          NetMessage.SendMessage();
                          break;
                        }
                        else
                          break;
                      }
                      else
                        goto case 21;
                  }
                }
                if (flag2 && flag1)
                {
                  for (int index3 = index1 - 1; index3 <= index1 + 1; ++index3)
                  {
                    for (int index4 = index2 - 1; index4 <= index2 + 1; ++index4)
                    {
                      if ((int) Main.tile[index3, index4].wall > 0)
                      {
                        WorldGen.KillWall(index3, index4, false);
                        if ((int) Main.tile[index3, index4].wall == 0)
                        {
                          NetMessage.CreateMessage5(17, 2, index3, index4, 0, 0);
                          NetMessage.SendMessage();
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        NetMessage.CreateMessage2(29, (int) this.identity, (int) this.owner);
        NetMessage.SendMessage();
        int number2 = -1;
        if ((int) this.aiStyle == 10)
        {
          int num3 = 0;
          int Type = 0;
          byte num4 = this.type;
          if ((uint) num4 <= 42U)
          {
            switch (num4)
            {
              case (byte) 31:
              case (byte) 42:
                num3 = 53;
                goto label_297;
              case (byte) 39:
                num3 = 59;
                Type = 176;
                goto label_297;
              case (byte) 40:
                num3 = 57;
                Type = 172;
                goto label_297;
            }
          }
          else
          {
            switch (num4)
            {
              case (byte) 56:
              case (byte) 65:
                num3 = 112;
                goto label_297;
              case (byte) 67:
              case (byte) 68:
                num3 = 116;
                goto label_297;
              case (byte) 71:
                num3 = 123;
                goto label_297;
              case (byte) 109:
                num3 = 147;
                goto label_297;
            }
          }
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 2, 1, false, 0);
label_297:
          if (num3 > 0)
          {
            int index1 = num1 + ((int) this.width >> 1) >> 4;
            int index2 = num2 + ((int) this.width >> 1) >> 4;
            if ((int) Main.tile[index1, index2].active == 0 && WorldGen.PlaceTile(index1, index2, num3, false, true, -1, 0))
            {
              NetMessage.CreateMessage5(17, 1, index1, index2, num3, 0);
              NetMessage.SendMessage();
            }
            else if (Type > 0)
              number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, Type, 1, false, 0);
          }
        }
        if ((int) this.type == 1)
        {
          if (Main.rand.Next(3) == 0)
            number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 40, 1, false, 0);
        }
        else if ((int) this.type == 2)
        {
          if (Main.rand.Next(3) == 0)
            number2 = Main.rand.Next(3) != 0 ? Item.NewItem(num1, num2, (int) this.width, (int) this.height, 40, 1, false, 0) : Item.NewItem(num1, num2, (int) this.width, (int) this.height, 41, 1, false, 0);
        }
        else if ((int) this.type == 103)
        {
          if (Main.rand.Next(6) == 0)
            number2 = Main.rand.Next(3) != 0 ? Item.NewItem(num1, num2, (int) this.width, (int) this.height, 40, 1, false, 0) : Item.NewItem(num1, num2, (int) this.width, (int) this.height, 545, 1, false, 0);
        }
        else if ((int) this.type == 113)
        {
          if (Main.rand.Next(4) == 0)
            number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 616, 1, false, 0);
        }
        else if ((int) this.type == 91 && Main.rand.Next(6) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 516, 1, false, 0);
        else if ((int) this.type == 50 && Main.rand.Next(3) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 282, 1, false, 0);
        else if ((int) this.type == 53 && Main.rand.Next(3) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 286, 1, false, 0);
        else if ((int) this.type == 48 && Main.rand.Next(2) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 279, 1, false, 0);
        else if ((int) this.type == 54 && Main.rand.Next(2) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 287, 1, false, 0);
        else if ((int) this.type == 3 && Main.rand.Next(2) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 42, 1, false, 0);
        else if ((int) this.type == 4 && Main.rand.Next(4) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 47, 1, false, 0);
        else if ((int) this.type == 12 && (int) this.damage > 100)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 75, 1, false, 0);
        else if ((int) this.type == 69 || (int) this.type == 70)
        {
          int num3 = num1 + ((int) this.width >> 1) >> 4;
          int num4 = num2 + ((int) this.height >> 1) >> 4;
          for (int index1 = num3 - 4; index1 <= num3 + 4; ++index1)
          {
            for (int index2 = num4 - 4; index2 <= num4 + 4; ++index2)
            {
              if (Math.Abs(index1 - num3) + Math.Abs(index2 - num4) < 6)
              {
                int num5 = (int) Main.tile[index1, index2].type;
                int num6 = 0;
                if ((int) this.type == 69)
                {
                  if (num5 == 2 || num5 == 23)
                    num6 = 109;
                  else if (num5 == 1 || num5 == 25)
                    num6 = 117;
                  else if (num5 == 53 || num5 == 112)
                    num6 = 116;
                }
                else if (num5 == 2 || num5 == 109)
                  num6 = 23;
                else if (num5 == 1 || num5 == 117)
                  num6 = 25;
                else if (num5 == 53 || num5 == 116)
                  num6 = 112;
                if (num6 > 0)
                {
                  Main.tile[index1, index2].type = (byte) num6;
                  WorldGen.SquareTileFrame(index1, index2, -1);
                  NetMessage.SendTile(index1, index2);
                }
              }
            }
          }
        }
        else if ((int) this.type == 21 && Main.rand.Next(2) == 0)
          number2 = Item.NewItem(num1, num2, (int) this.width, (int) this.height, 154, 1, false, 0);
        if (number2 >= 0)
        {
          NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, number2);
          NetMessage.SendMessage();
        }
      }
      this.active = (byte) 0;
    }

    public Color GetAlpha(Color newColor)
    {
      if ((int) this.type == 34 || (int) this.type == 15 || ((int) this.type == 93 || (int) this.type == 94) || ((int) this.type == 95 || (int) this.type == 96 || (int) this.type == 102 && (int) this.alpha < (int) byte.MaxValue))
        return new Color(200, 200, 200, 25);
      if ((int) this.type == 83 || (int) this.type == 88 || ((int) this.type == 89 || (int) this.type == 90) || ((int) this.type == 100 || (int) this.type == 104))
      {
        if ((int) this.alpha < 200)
          return new Color((int) byte.MaxValue - (int) this.alpha, (int) byte.MaxValue - (int) this.alpha, (int) byte.MaxValue - (int) this.alpha, 0);
        else
          return new Color();
      }
      else
      {
        if ((int) this.type == 34 || (int) this.type == 35 || ((int) this.type == 15 || (int) this.type == 19) || ((int) this.type == 44 || (int) this.type == 45))
          return Color.White;
        if ((int) this.type == 79)
          return new Color();
        int r;
        int g;
        int b;
        if ((int) this.type == 9 || (int) this.type == 15 || ((int) this.type == 34 || (int) this.type == 50) || ((int) this.type == 53 || (int) this.type == 76 || ((int) this.type == 77 || (int) this.type == 78)) || ((int) this.type == 92 || (int) this.type == 91))
        {
          r = (int) newColor.R - (int) this.alpha / 3;
          g = (int) newColor.G - (int) this.alpha / 3;
          b = (int) newColor.B - (int) this.alpha / 3;
        }
        else if ((int) this.type == 16 || (int) this.type == 18 || ((int) this.type == 44 || (int) this.type == 45))
        {
          r = (int) newColor.R;
          g = (int) newColor.G;
          b = (int) newColor.B;
        }
        else
        {
          if ((int) this.type == 12 || (int) this.type == 72 || ((int) this.type == 86 || (int) this.type == 87))
            return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) newColor.A - (int) this.alpha);
          r = (int) newColor.R - (int) this.alpha;
          g = (int) newColor.G - (int) this.alpha;
          b = (int) newColor.B - (int) this.alpha;
        }
        int a = (int) newColor.A - (int) this.alpha;
        if (a < 0)
          a = 0;
        if (a > (int) byte.MaxValue)
          a = (int) byte.MaxValue;
        return new Color(r, g, b, a);
      }
    }

    public unsafe void Draw(WorldView view)
    {
      Player player = Main.player[(int) this.owner];
      Vector2 pos1;
      if ((int) this.type == 32)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = player.position.X + 10f - vector2.X;
        float num2 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        bool flag = true;
        if ((double) num1 == 0.0 && (double) num2 == 0.0)
        {
          flag = false;
        }
        else
        {
          float num3 = 8f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
          float num4 = num1 * num3;
          float num5 = num2 * num3;
          vector2.X -= num4;
          vector2.Y -= num5;
          num1 = player.position.X + 10f - vector2.X;
          num2 = player.position.Y + 21f - vector2.Y;
        }
        while (flag)
        {
          float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num3 < 784.0)
          {
            flag = false;
          }
          else
          {
            float num4 = 28f / (float) Math.Sqrt((double) num3);
            float num5 = num1 * num4;
            float num6 = num2 * num4;
            vector2.X += num5;
            vector2.Y += num6;
            num1 = player.position.X + 10f - vector2.X;
            num2 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            SpriteSheet<_sheetSprites>.DrawRotated(190, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
        }
      }
      else if ((int) this.type == 73)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = player.position.X + 10f - vector2.X;
        float num2 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num3 < 625.0)
          {
            flag = false;
          }
          else
          {
            float num4 = 12f / (float) Math.Sqrt((double) num3);
            float num5 = num1 * num4;
            float num6 = num2 * num4;
            vector2.X += num5;
            vector2.Y += num6;
            num1 = player.position.X + 10f - vector2.X;
            num2 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            SpriteSheet<_sheetSprites>.DrawRotated(193, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
        }
      }
      else if ((int) this.type == 74)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = player.position.X + 10f - vector2.X;
        float num2 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num3 < 625.0)
          {
            flag = false;
          }
          else
          {
            float num4 = 12f / (float) Math.Sqrt((double) num3);
            float num5 = num1 * num4;
            float num6 = num2 * num4;
            vector2.X += num5;
            vector2.Y += num6;
            num1 = player.position.X + 10f - vector2.X;
            num2 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            SpriteSheet<_sheetSprites>.DrawRotated(194, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
        }
      }
      else if ((int) this.aiStyle == 7)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = player.position.X + 10f - vector2.X;
        float num2 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num3 < 625.0)
          {
            flag = false;
          }
          else
          {
            float num4 = 12f / (float) Math.Sqrt((double) num3);
            float num5 = num1 * num4;
            float num6 = num2 * num4;
            vector2.X += num5;
            vector2.Y += num6;
            num1 = player.position.X + 10f - vector2.X;
            num2 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            SpriteSheet<_sheetSprites>.DrawRotated(198, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
        }
      }
      else if ((int) this.aiStyle == 13)
      {
        float num1 = this.position.X + 8f;
        float num2 = this.position.Y + 2f;
        float num3 = this.velocity.X;
        float num4 = this.velocity.Y;
        float num5 = 20f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
        float x;
        float y;
        if ((double) this.ai0 == 0.0)
        {
          x = num1 - this.velocity.X * num5;
          y = num2 - this.velocity.Y * num5;
        }
        else
        {
          x = num1 + this.velocity.X * num5;
          y = num2 + this.velocity.Y * num5;
        }
        Vector2 vector2 = new Vector2(x, y);
        float num6 = player.position.X + 10f - vector2.X;
        float num7 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num7, (double) num6) - 1.57f;
        if ((int) this.alpha == 0)
        {
          int num8 = -1;
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) player.position.X + 10.0)
            num8 = 1;
          player.itemRotation = (float) Math.Atan2((double) num7 * (double) num8, (double) num6 * (double) num8);
        }
        while (true)
        {
          float num8 = (float) ((double) num6 * (double) num6 + (double) num7 * (double) num7);
          if ((double) num8 >= 625.0)
          {
            float num9 = 12f / (float) Math.Sqrt((double) num8);
            float num10 = num6 * num9;
            float num11 = num7 * num9;
            vector2.X += num10;
            vector2.Y += num11;
            num6 = player.position.X + 10f - vector2.X;
            num7 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            SpriteSheet<_sheetSprites>.DrawRotated(198, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
          else
            break;
        }
      }
      else if ((int) this.aiStyle == 15)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
        float num1 = player.position.X + 10f - vector2.X;
        float num2 = player.position.Y + 21f - vector2.Y;
        float rotCenter = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        if ((int) this.alpha == 0)
        {
          int num3 = -1;
          if (this.aabb.X + ((int) this.width >> 1) < player.aabb.X + 10)
            num3 = 1;
          player.itemRotation = (float) Math.Atan2((double) num2 * (double) num3, (double) num1 * (double) num3);
        }
        bool flag = true;
        do
        {
          float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num3 < 625.0)
          {
            flag = false;
          }
          else
          {
            float num4 = 12f / (float) Math.Sqrt((double) num3);
            float num5 = num1 * num4;
            float num6 = num2 * num4;
            vector2.X += num5;
            vector2.Y += num6;
            num1 = player.position.X + 10f - vector2.X;
            num2 = player.position.Y + 21f - vector2.Y;
            pos1 = vector2;
            pos1.X -= (float) view.screenPosition.X;
            pos1.Y -= (float) view.screenPosition.Y;
            int id = 188;
            if ((int) this.type == 25)
              id = 187;
            else if ((int) this.type == 35)
              id = 191;
            else if ((int) this.type == 63)
              id = 192;
            SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos1, view.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
          }
        }
        while (flag);
      }
      Color newColor = (int) this.type != 14 ? (!this.hide ? view.lighting.GetColor(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4) : view.lighting.GetColor(player.aabb.X + 10 >> 4, player.aabb.Y + 21 >> 4)) : Color.White;
      int id1 = 1349 + (int) this.type;
      int num12 = SpriteSheet<_sheetSprites>.src[id1].Width >> 1;
      int num13 = num12;
      int num14 = 0;
      if ((int) this.type == 16)
        num14 = 6;
      else if ((int) this.type == 17 || (int) this.type == 31)
        num14 = 2;
      else if ((int) this.type == 25 || (int) this.type == 26 || ((int) this.type == 35 || (int) this.type == 63))
      {
        num14 = 6;
        num13 -= 6;
      }
      else if ((int) this.type == 28 || (int) this.type == 37 || (int) this.type == 75)
        num14 = 8;
      else if ((int) this.type == 29)
        num14 = 11;
      else if ((int) this.type == 43)
        num14 = 4;
      else if ((int) this.type == 69 || (int) this.type == 70)
      {
        num14 = 4;
        num13 += 4;
      }
      else if ((int) this.type == 50 || (int) this.type == 53)
        num13 -= 8;
      else if ((int) this.type == 72 || (int) this.type == 86 || (int) this.type == 87)
      {
        num13 -= 16;
        num14 = 8;
      }
      else if ((int) this.type == 74)
        num13 -= 6;
      else if ((int) this.type == 99)
        num14 = 1;
      else if ((int) this.type == 111 || (int) this.type >= 115 && (int) this.type <= 119)
      {
        num14 = ((int) Projectile.projFrameH[(int) this.type] >> 1) - 2;
        num13 -= 16;
      }
      SpriteEffects e = (int) this.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
      pos1 = new Vector2(this.position.X - (float) view.screenPosition.X + (float) num13, this.position.Y - (float) view.screenPosition.Y + (float) ((int) this.height >> 1));
      Vector2 pivot = new Vector2((float) num12, (float) (((int) this.height >> 1) + num14));
      Color alpha = this.GetAlpha(newColor);
      int sh = (int) Projectile.projFrameH[(int) this.type];
      if (sh > 0)
      {
        int sy = sh * (int) this.frame;
        SpriteSheet<_sheetSprites>.Draw(id1, ref pos1, sy, sh, alpha, this.rotation, ref pivot, this.scale, e);
      }
      else if ((int) this.aiStyle == 19)
      {
        pos1.X -= pivot.X;
        pos1.X += (float) ((int) this.width >> 1);
        if ((int) this.spriteDirection == -1)
          pivot.X *= 2f;
        else
          pivot.X = 0.0f;
        pivot.Y = 0.0f;
        SpriteSheet<_sheetSprites>.Draw(id1, ref pos1, alpha, this.rotation, ref pivot, this.scale, e);
      }
      else
      {
        if ((int) this.type == 94 && this.ai1 > 6)
        {
          // ISSUE: reference to a compiler-generated field
          fixed (float* numPtr = &this.oldPos.FixedElementField)
          {
            for (int index = 0; index < 10; ++index)
            {
              Color c = alpha;
              float num1 = (float) (9 - index) * 0.1111111f;
              c.R = (byte) ((double) c.R * (double) num1);
              c.G = (byte) ((double) c.G * (double) num1);
              c.B = (byte) ((double) c.B * (double) num1);
              c.A = (byte) ((double) c.A * (double) num1);
              Vector2 pos2 = new Vector2(numPtr[index << 1] - (float) view.screenPosition.X + (float) num13, numPtr[(index << 1) + 1] - (float) view.screenPosition.Y + (float) ((int) this.height >> 1));
              SpriteSheet<_sheetSprites>.Draw(id1, ref pos2, c, this.rotation, ref pivot, this.scale * num1, e);
            }
          }
        }
        SpriteSheet<_sheetSprites>.Draw(id1, ref pos1, alpha, this.rotation, ref pivot, this.scale, e);
        if ((int) this.type != 106)
          return;
        alpha.R = (byte) 200;
        alpha.G = (byte) 200;
        alpha.B = (byte) 200;
        alpha.A = (byte) 0;
        SpriteSheet<_sheetSprites>.Draw(1084, ref pos1, alpha, this.rotation, ref pivot, this.scale, e);
      }
    }

    private struct PetAnim
    {
      private byte startFrame;
      private byte endFrame;
      private byte frameDelay;

      public PetAnim(int s, int e, int d)
      {
        this.startFrame = (byte) s;
        this.endFrame = (byte) e;
        this.frameDelay = (byte) d;
      }

      public void Update(ref Projectile p)
      {
        if ((int) p.frame < (int) this.startFrame || (int) p.frame > (int) this.endFrame)
        {
          p.frame = this.startFrame;
          p.frameCounter = (byte) 0;
        }
        else
        {
          if ((int) ++p.frameCounter < (int) this.frameDelay)
            return;
          p.frameCounter = (byte) 0;
          if ((int) ++p.frame <= (int) this.endFrame)
            return;
          p.frame = this.startFrame;
        }
      }
    }
  }
}
