// Type: Terraria.Gore
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

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

    static Gore()
    {
    }

    public void Init()
    {
      this.active = (byte) 0;
    }

    public void Update()
    {
      if ((int) this.type == 11 || (int) this.type == 12 || ((int) this.type == 13 || (int) this.type == 61) || ((int) this.type == 62 || (int) this.type == 63 || (int) this.type == 99))
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale -= 0.007f;
        if ((double) this.scale < 0.100000001490116)
        {
          this.active = (byte) 0;
          return;
        }
      }
      else if ((int) this.type == 16 || (int) this.type == 17)
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale -= 0.01f;
        if ((double) this.scale < 0.100000001490116)
        {
          this.active = (byte) 0;
          return;
        }
      }
      else
        this.velocity.Y += 0.2f;
      this.rotation += this.velocity.X * 0.1f;
      if (this.sticky)
      {
        int num1 = SpriteSheet<_sheetSprites>.src[256 + (int) this.type].Width;
        if (SpriteSheet<_sheetSprites>.src[256 + (int) this.type].Height < num1)
          num1 = SpriteSheet<_sheetSprites>.src[256 + (int) this.type].Height;
        int num2 = (int) ((double) num1 * (double) this.scale * 0.899999976158142);
        Collision.TileCollision(ref this.position, ref this.velocity, num2, num2, false, false);
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.97f;
          if ((double) this.velocity.X > -0.00999999977648258 && (double) this.velocity.X < 0.00999999977648258)
            this.velocity.X = 0.0f;
        }
        if ((int) this.timeLeft > 0)
          --this.timeLeft;
        else
          ++this.alpha;
      }
      else
        this.alpha += (short) 2;
      if ((int) this.alpha >= (int) byte.MaxValue)
      {
        this.active = (byte) 0;
      }
      else
      {
        this.position.X += this.velocity.X;
        this.position.Y += this.velocity.Y;
        if ((double) this.light <= 0.0)
          return;
        float num = this.light * this.scale;
        Vector3 rgb = new Vector3(num, num, num);
        if ((int) this.type == 16)
        {
          rgb.Y *= 0.8f;
          rgb.Z *= 0.3f;
        }
        else if ((int) this.type == 17)
        {
          rgb.X *= 0.3f;
          rgb.Y *= 0.6f;
        }
        Lighting.addLight((int) ((double) this.position.X + (double) SpriteSheet<_sheetSprites>.src[256 + (int) this.type].Width * (double) this.scale * 0.5) >> 4, (int) ((double) this.position.Y + (double) SpriteSheet<_sheetSprites>.src[256 + (int) this.type].Height * (double) this.scale * 0.5) >> 4, rgb);
      }
    }

    public static unsafe int NewGore(Vector2 Position, Vector2 Velocity, int Type, double Scale = 1.0)
    {
      int index = Gore.lastGoreIndex++ & (int) sbyte.MaxValue;
      fixed (Gore* gorePtr = &Main.gore[index])
      {
        gorePtr->position = Position;
        gorePtr->velocity = Velocity;
        gorePtr->velocity.Y -= (float) Main.rand.Next(10, 31) * 0.1f;
        gorePtr->velocity.X += (float) Main.rand.Next(-20, 21) * 0.1f;
        gorePtr->type = (byte) Type;
        gorePtr->active = (byte) 1;
        gorePtr->rotation = 0.0f;
        if (Type == 16 || Type == 17)
        {
          gorePtr->sticky = false;
          gorePtr->alpha = (short) 100;
          gorePtr->scale = 0.7f;
          gorePtr->light = 1f;
          return index;
        }
        else
        {
          if (Type >= 11 && Type <= 13 || Type >= 61 && Type <= 63 || Type == 99)
          {
            gorePtr->sticky = false;
          }
          else
          {
            gorePtr->sticky = true;
            gorePtr->timeLeft = (short) 360;
          }
          gorePtr->scale = (float) Scale;
          gorePtr->alpha = (short) 0;
          gorePtr->light = 0.0f;
          // ISSUE: __unpin statement
          __unpin(gorePtr);
          return index;
        }
      }
    }

    public static unsafe int NewGore(int X, int Y, Vector2 Velocity, int Type)
    {
      int index = Gore.lastGoreIndex++ & (int) sbyte.MaxValue;
      fixed (Gore* gorePtr = &Main.gore[index])
      {
        gorePtr->position.X = (float) X;
        gorePtr->position.Y = (float) Y;
        gorePtr->velocity = Velocity;
        gorePtr->velocity.Y -= (float) Main.rand.Next(10, 31) * 0.1f;
        gorePtr->velocity.X += (float) Main.rand.Next(-20, 21) * 0.1f;
        gorePtr->type = (byte) Type;
        gorePtr->active = (byte) 1;
        gorePtr->rotation = 0.0f;
        if (Type == 16 || Type == 17)
        {
          gorePtr->sticky = false;
          gorePtr->alpha = (short) 100;
          gorePtr->scale = 0.7f;
          gorePtr->light = 1f;
          return index;
        }
        else
        {
          if (Type >= 11 && Type <= 13 || Type >= 61 && Type <= 63 || Type == 99)
          {
            gorePtr->sticky = false;
          }
          else
          {
            gorePtr->sticky = true;
            gorePtr->timeLeft = (short) 360;
          }
          gorePtr->scale = 1f;
          gorePtr->alpha = (short) 0;
          gorePtr->light = 0.0f;
          // ISSUE: __unpin statement
          __unpin(gorePtr);
          return index;
        }
      }
    }

    public Color GetAlpha(Color newColor)
    {
      int r;
      int g;
      int b;
      if ((int) this.type == 16 || (int) this.type == 17)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else
      {
        double num = ((double) byte.MaxValue - (double) this.alpha) * (1.0 / (double) byte.MaxValue);
        r = (int) ((double) newColor.R * num);
        g = (int) ((double) newColor.G * num);
        b = (int) ((double) newColor.B * num);
      }
      int a = (int) newColor.A - (int) this.alpha;
      return new Color(r, g, b, a);
    }
  }
}
