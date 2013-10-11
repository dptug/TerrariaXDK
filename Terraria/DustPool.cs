// Type: Terraria.DustPool
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public struct DustPool
  {
    public WorldView view;
    public short snowDust;
    public short lavaBubbles;
    public short nextDust;
    public short size;
    public Dust[] dust;

    public DustPool(WorldView v, int sizePower2)
    {
      this.view = v;
      this.snowDust = (short) 0;
      this.lavaBubbles = (short) 0;
      this.nextDust = (short) 0;
      this.size = (short) sizePower2;
      this.dust = new Dust[sizePower2];
    }

    public void Init()
    {
      for (int index = (int) this.size - 1; index >= 0; --index)
        this.dust[index].Init();
    }

    private bool ClipDust(int x, int y)
    {
      if (this.view == null)
        return !WorldView.AnyViewContains(x, y);
      else
        return !this.view.clipArea.Contains(x, y);
    }

    public unsafe Dust* NewDust(int Type, ref Rectangle r, double SpeedX = 0.0, double SpeedY = 0.0, int Alpha = 0, Color newColor = null, double Scale = 1.0)
    {
      return this.NewDust(r.X, r.Y, r.Width, r.Height, Type, SpeedX, SpeedY, Alpha, newColor, Scale);
    }

    public unsafe Dust* NewDust(int X, int Y, int Width, int Height, int Type, double SpeedX = 0.0, double SpeedY = 0.0, int Alpha = 0, Color newColor = null, double Scale = 1.0)
    {
      if (this.ClipDust(X, Y))
        return (Dust*) null;
      int num1 = (int) this.nextDust;
      int num2 = (int) this.size - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        int index2 = num1 & num2;
        fixed (Dust* dustPtr = &this.dust[index2])
        {
          if ((int) dustPtr->active == 0)
          {
            dustPtr->active = (byte) 1;
            dustPtr->noGravity = false;
            dustPtr->noLight = false;
            dustPtr->type = (ushort) Type;
            dustPtr->color = newColor;
            dustPtr->alpha = (short) Alpha;
            dustPtr->fadeIn = 0.0f;
            dustPtr->rotation = 0.0f;
            dustPtr->scale = (float) (Scale + (double) Main.rand.Next(-20, 21) * 0.01 * Scale);
            dustPtr->frame.X = 10 * Type;
            dustPtr->frame.Y = 10 * Main.rand.Next(3);
            dustPtr->frame.Width = 8;
            dustPtr->frame.Height = 8;
            int num3 = Width;
            int num4 = Height;
            if (num3 < 5)
              num3 = 5;
            if (num4 < 5)
              num4 = 5;
            dustPtr->position.X = (float) (X + Main.rand.Next(num3 - 4) + 4);
            dustPtr->position.Y = (float) (Y + Main.rand.Next(num4 - 4) + 4);
            if (Type == 6 || Type == 75 || Type == 29 || Type >= 59 && Type <= 65)
            {
              dustPtr->velocity.X = (float) (((double) Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.3);
              dustPtr->velocity.Y = (float) Main.rand.Next(-10, 6) * 0.1f;
              IntPtr num5 = (IntPtr) dustPtr;
              double num6 = (double) ((Dust*) num5)->scale * 0.699999988079071;
              ((Dust*) num5)->scale = (float) num6;
            }
            else if (Type == 33 || Type == 52)
            {
              dustPtr->alpha = (short) 170;
              dustPtr->velocity.X = (float) (((double) Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.5);
              dustPtr->velocity.Y = (float) (((double) Main.rand.Next(-20, 21) * 0.1 + SpeedY) * 0.5 + 1.0);
            }
            else if (Type == 41)
            {
              dustPtr->velocity.X = 0.0f;
              dustPtr->velocity.Y = 0.0f;
            }
            else if (Type == 34)
            {
              dustPtr->position.Y -= 8f;
              if (!Collision.WetCollision(ref dustPtr->position, 4, 4))
              {
                dustPtr->active = (byte) 0;
                this.nextDust = (short) index2;
                return dustPtr;
              }
              else
              {
                dustPtr->position.Y += 8f;
                dustPtr->velocity.X = (float) (((double) Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.1);
                dustPtr->velocity.Y = -0.5f;
              }
            }
            else if (Type == 35)
            {
              dustPtr->velocity.X = (float) (((double) Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.1);
              dustPtr->velocity.Y = -0.5f;
            }
            else
            {
              dustPtr->velocity.X = (float) ((double) Main.rand.Next(-20, 21) * 0.1 + SpeedX);
              dustPtr->velocity.Y = (float) ((double) Main.rand.Next(-20, 21) * 0.1 + SpeedY);
            }
            this.nextDust = (short) (index2 + 1);
            return dustPtr;
          }
          else
          {
            // ISSUE: __unpin statement
            __unpin(dustPtr);
            ++num1;
          }
        }
      }
      return (Dust*) null;
    }

    public unsafe void UpdateDust()
    {
      this.lavaBubbles = (short) 0;
      this.snowDust = (short) 0;
      Vector3 rgb = new Vector3();
      fixed (Dust* dustPtr1 = this.dust)
      {
        Dust* dustPtr2 = dustPtr1;
        for (int index = (int) this.size - 1; index >= 0; --index)
        {
          if ((int) dustPtr2->active != 0)
          {
            int num1 = (int) dustPtr2->type;
            float num2 = dustPtr2->scale;
            dustPtr2->position.X += dustPtr2->velocity.X;
            dustPtr2->position.Y += dustPtr2->velocity.Y;
            int x = (int) dustPtr2->position.X;
            int y1 = (int) dustPtr2->position.Y;
            if (num1 == 6 || num1 == 75 || num1 == 29 || num1 >= 59 && num1 <= 65)
            {
              if (!dustPtr2->noLight)
              {
                if (this.ClipDust(x, y1))
                {
                  dustPtr2->active = (byte) 0;
                  goto label_220;
                }
                else
                {
                  num2 *= 1.4f;
                  switch (num1)
                  {
                    case 59:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = 0.0f;
                      rgb.Y = num2 * 0.1f;
                      rgb.Z = num2 * 1.3f;
                      break;
                    case 60:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = num2;
                      rgb.Y = rgb.Z = num2 * 0.1f;
                      break;
                    case 61:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = 0.0f;
                      rgb.Y = num2;
                      rgb.Z = num2 * 0.1f;
                      break;
                    case 62:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = rgb.Z = num2 * 0.9f;
                      rgb.Y = 0.0f;
                      break;
                    case 64:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = rgb.Y = num2 * 0.9f;
                      rgb.Z = 0.0f;
                      break;
                    case 65:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                      rgb.Y = 0.3f;
                      rgb.Z = Main.demonTorch + (float) (0.5 * (1.0 - (double) Main.demonTorch));
                      break;
                    case 75:
                      if ((double) num2 > 1.0)
                        num2 = 1f;
                      rgb.X = num2 * 0.7f;
                      rgb.Y = num2;
                      rgb.Z = num2 * 0.2f;
                      break;
                    case 6:
                      if ((double) num2 > 0.600000023841858)
                        num2 = 0.6f;
                      rgb.X = num2;
                      rgb.Y = num2 * 0.65f;
                      rgb.Z = num2 * 0.4f;
                      break;
                    case 29:
                      if ((double) num2 > 1.0)
                        num2 = 1f;
                      rgb.X = num2 * 0.1f;
                      rgb.Y = num2 * 0.4f;
                      rgb.Z = num2;
                      break;
                    default:
                      if ((double) num2 > 0.800000011920929)
                        num2 = 0.8f;
                      rgb.X = rgb.Y = rgb.Z = num2 * 1.3f;
                      break;
                  }
                  Lighting.addLight(x >> 4, y1 >> 4, rgb);
                }
              }
              if (!dustPtr2->noGravity)
                dustPtr2->velocity.Y += 0.05f;
            }
            else if (num1 == 14 || num1 == 16 || num1 == 46)
            {
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
            }
            else if (num1 == 31)
            {
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
              if (dustPtr2->noGravity)
              {
                dustPtr2->alpha += (short) 4;
                if ((int) dustPtr2->alpha > (int) byte.MaxValue)
                {
                  dustPtr2->active = (byte) 0;
                  goto label_220;
                }
                else
                {
                  dustPtr2->velocity.X *= 1.02f;
                  dustPtr2->velocity.Y *= 1.02f;
                  dustPtr2->scale += 0.02f;
                }
              }
            }
            else if (num1 == 32)
            {
              dustPtr2->scale -= 0.01f;
              dustPtr2->velocity.X *= 0.96f;
              dustPtr2->velocity.Y += 0.1f;
            }
            else if (num1 == 43)
            {
              dustPtr2->rotation += 0.1f * dustPtr2->scale;
              if ((double) num2 > 0.0480000004172325)
              {
                rgb.X = rgb.Y = rgb.Z = num2 * 1.010556f;
                Lighting.addLight(x >> 4, y1 >> 4, rgb);
                if ((int) dustPtr2->alpha < (int) byte.MaxValue)
                {
                  dustPtr2->scale += 0.09f;
                  if ((double) dustPtr2->scale >= 1.0)
                  {
                    dustPtr2->scale = 1f;
                    dustPtr2->alpha = (short) byte.MaxValue;
                  }
                }
                else if ((double) dustPtr2->scale < 0.5)
                  dustPtr2->scale -= 0.02f;
                else if ((double) dustPtr2->scale < 0.800000011920929)
                  dustPtr2->scale -= 0.01f;
              }
              else
              {
                dustPtr2->active = (byte) 0;
                goto label_220;
              }
            }
            else if (num1 == 15 || num1 == 57 || num1 == 58)
            {
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
              if (num1 != 15)
                num2 *= 0.8f;
              if (dustPtr2->noLight)
              {
                dustPtr2->velocity.X *= 0.95f;
                dustPtr2->velocity.Y *= 0.95f;
              }
              if ((double) num2 > 1.0)
                num2 = 1f;
              if (num1 == 15)
                Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2 * 0.45f, num2 * 0.55f, num2));
              else if (num1 == 57)
                Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2 * 0.95f, num2 * 0.95f, num2 * 0.45f));
              else if (num1 == 58)
                Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2, num2 * 0.55f, num2 * 0.75f));
            }
            else if (num1 == 66)
            {
              if ((double) dustPtr2->velocity.X < 0.0)
                --dustPtr2->rotation;
              else
                ++dustPtr2->rotation;
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
              dustPtr2->scale += 0.02f;
              num2 *= 0.003137255f;
              if ((double) num2 > 0.00392156885936856)
                num2 = 0.003921569f;
              rgb.X = num2 * (float) dustPtr2->color.R;
              rgb.Y = num2 * (float) dustPtr2->color.G;
              rgb.Z = num2 * (float) dustPtr2->color.B;
              Lighting.addLight(x >> 4, y1 >> 4, rgb);
            }
            else if (num1 == 20 || num1 == 21)
            {
              dustPtr2->scale += 0.005f;
              dustPtr2->velocity.X *= 0.94f;
              dustPtr2->velocity.Y *= 0.94f;
              if (num1 == 21)
              {
                num2 *= 0.4f;
                rgb.X = num2 * 0.8f;
                rgb.Y = num2 * 0.3f;
              }
              else
              {
                num2 *= 0.8f;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                rgb.X = num2 * 0.3f;
                rgb.Y = num2 * 0.6f;
              }
              rgb.Z = num2;
              Lighting.addLight(x >> 4, y1 >> 4, rgb);
            }
            else if (num1 == 27 || num1 == 45)
            {
              dustPtr2->velocity.X *= 0.94f;
              dustPtr2->velocity.Y *= 0.94f;
              dustPtr2->scale += 1.0 / 500.0;
              if (dustPtr2->noLight)
              {
                num2 *= 0.1f;
                dustPtr2->scale -= 0.06f;
                if ((double) dustPtr2->scale < 1.0)
                  dustPtr2->scale -= 0.06f;
                if (this.view != null)
                {
                  if (this.view.player.wet)
                  {
                    dustPtr2->position.X += this.view.player.velocity.X * 0.5f;
                    dustPtr2->position.Y += this.view.player.velocity.Y * 0.5f;
                  }
                  else
                  {
                    dustPtr2->position.X += this.view.player.velocity.X;
                    dustPtr2->position.Y += this.view.player.velocity.Y;
                  }
                }
              }
              if ((double) num2 > 1.0)
                num2 = 1f;
              Lighting.addLight((int) dustPtr2->position.X >> 4, (int) dustPtr2->position.Y >> 4, new Vector3(num2 * 0.6f, num2 * 0.2f, num2));
            }
            else if (num1 == 55 || num1 == 56 || (num1 == 73 || num1 == 74))
            {
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
              if (num1 == 55)
              {
                num2 *= 0.8f;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                rgb = new Vector3(num2, num2, num2 * 0.6f);
              }
              else if (num1 == 73)
              {
                num2 *= 0.8f;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                rgb = new Vector3(num2, num2 * 0.35f, num2 * 0.5f);
              }
              else if (num1 == 74)
              {
                num2 *= 0.8f;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                rgb = new Vector3(num2 * 0.35f, num2, num2 * 0.5f);
              }
              else
              {
                num2 *= 1.2f;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                rgb = new Vector3(num2 * 0.35f, num2 * 0.5f, num2);
              }
              Lighting.addLight(x >> 4, y1 >> 4, rgb);
            }
            else if (num1 == 71 || num1 == 72)
            {
              dustPtr2->velocity.X *= 0.98f;
              dustPtr2->velocity.Y *= 0.98f;
              if ((double) num2 > 1.0)
                num2 = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2 * 0.2f, 0.0f, num2 * 0.1f));
            }
            else if (num1 == 76)
            {
              ++this.snowDust;
              dustPtr2->scale += 0.009f;
              if (this.view != null)
              {
                if (Collision.SolidCollision(ref dustPtr2->position, 1, 1))
                {
                  dustPtr2->active = (byte) 0;
                  goto label_220;
                }
                else
                {
                  dustPtr2->position.X += this.view.player.velocity.X * 0.2f;
                  dustPtr2->position.Y += this.view.player.velocity.Y * 0.2f;
                }
              }
            }
            else if (!dustPtr2->noGravity)
            {
              if (num1 != 41 && num1 != 44)
                dustPtr2->velocity.Y += 0.1f;
            }
            else if (num1 == 5)
              dustPtr2->scale -= 0.04f;
            if (num1 == 33 || num1 == 52)
            {
              if ((double) dustPtr2->velocity.X == 0.0)
              {
                if (Collision.SolidCollision(ref dustPtr2->position, 2, 2))
                {
                  dustPtr2->active = (byte) 0;
                  goto label_220;
                }
                else
                {
                  dustPtr2->rotation += 0.5f;
                  dustPtr2->scale -= 0.01f;
                }
              }
              if (Collision.WetCollision(ref dustPtr2->position, 4, 4))
              {
                dustPtr2->scale -= 0.105f;
                dustPtr2->alpha += (short) 22;
              }
              else
              {
                dustPtr2->scale -= 0.005f;
                dustPtr2->alpha += (short) 2;
              }
              if ((int) dustPtr2->alpha > (int) byte.MaxValue)
              {
                dustPtr2->active = (byte) 0;
                goto label_220;
              }
              else
              {
                dustPtr2->velocity.X *= 0.93f;
                if ((double) dustPtr2->velocity.Y > 4.0)
                  dustPtr2->velocity.Y = 4f;
                if (dustPtr2->noGravity)
                {
                  if ((double) dustPtr2->velocity.X < 0.0)
                    dustPtr2->rotation -= 0.2f;
                  else
                    dustPtr2->rotation += 0.2f;
                  dustPtr2->scale += 0.03f;
                  dustPtr2->velocity.X *= 1.05f;
                  dustPtr2->velocity.Y += 0.15f;
                }
              }
            }
            else if (num1 == 67)
            {
              if ((double) num2 > 1.0)
                num2 = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(0.0f, num2 * 0.8f, num2));
            }
            else if (num1 == 34 || num1 == 35)
            {
              if (num1 == 35)
              {
                ++this.lavaBubbles;
                if (dustPtr2->noGravity)
                {
                  dustPtr2->scale += 0.03f;
                  if ((double) dustPtr2->scale < 1.0)
                    dustPtr2->velocity.Y += 0.075f;
                  dustPtr2->velocity.X *= 1.08f;
                  if ((double) dustPtr2->velocity.X > 0.0)
                    dustPtr2->rotation += 0.01f;
                  else
                    dustPtr2->rotation -= 0.01f;
                  dustPtr2->velocity.X *= 0.99f;
                  float num3 = (float) ((double) num2 * 0.600000023841858 + 0.0179999992251396);
                  if ((double) num3 > 1.0)
                    num3 = 1f;
                  rgb.X = num3;
                  rgb.Y = num3 * 0.3f;
                  rgb.Z = num3 * 0.1f;
                  Lighting.addLight(x >> 4, (y1 >> 4) + 1, rgb);
                  goto label_206;
                }
                else
                {
                  num2 = (float) ((double) num2 * 0.300000011920929 + 0.400000005960464);
                  if ((double) num2 > 1.0)
                    num2 = 1f;
                  rgb.X = num2;
                  rgb.Y = num2 * 0.5f;
                  rgb.Z = num2 * 0.3f;
                  Lighting.addLight(x >> 4, y1 >> 4, rgb);
                  dustPtr2->scale -= 0.01f;
                  dustPtr2->velocity.Y = -0.2f;
                  dustPtr2->alpha += (short) Main.rand.Next(2);
                }
              }
              else
              {
                dustPtr2->scale += 0.005f;
                dustPtr2->velocity.Y = -0.5f;
              }
              if ((int) ++dustPtr2->alpha > (int) byte.MaxValue)
              {
                dustPtr2->active = (byte) 0;
                goto label_220;
              }
              else
              {
                dustPtr2->position.Y -= 8f;
                if (!Collision.WetCollision(ref dustPtr2->position, 4, 4))
                {
                  dustPtr2->active = (byte) 0;
                  goto label_220;
                }
                else
                {
                  dustPtr2->position.Y += 8f;
                  dustPtr2->velocity.X += (float) Main.rand.Next(-10, 10) * (1.0 / 500.0);
                  if ((double) dustPtr2->velocity.X < -0.25)
                    dustPtr2->velocity.X = -0.25f;
                  else if ((double) dustPtr2->velocity.X > 0.25)
                    dustPtr2->velocity.X = 0.25f;
                }
              }
            }
            else if (num1 == 68)
            {
              num2 *= 0.3f;
              if ((double) num2 > 1.0)
                num2 = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2 * 0.1f, num2 * 0.2f, num2));
            }
            else if (num1 == 70)
            {
              num2 *= 0.3f;
              if ((double) num2 > 1.0)
                num2 = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(num2 * 0.5f, 0.0f, num2));
            }
            if (num1 == 41)
            {
              dustPtr2->velocity.X += (float) Main.rand.Next(-10, 11) * 0.01f;
              dustPtr2->velocity.Y += (float) Main.rand.Next(-10, 11) * 0.01f;
              if ((double) dustPtr2->velocity.X > 0.75)
                dustPtr2->velocity.X = 0.75f;
              else if ((double) dustPtr2->velocity.X < -0.75)
                dustPtr2->velocity.X = -0.75f;
              if ((double) dustPtr2->velocity.Y > 0.75)
                dustPtr2->velocity.Y = 0.75f;
              else if ((double) dustPtr2->velocity.Y < -0.75)
                dustPtr2->velocity.Y = -0.75f;
              dustPtr2->scale += 0.007f;
              float z = (float) ((double) num2 * 0.699999988079071 + 0.00490000005811453);
              if ((double) z > 1.0)
                z = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(z * 0.4f, z * 0.9f, z));
            }
            else if (num1 == 44)
            {
              dustPtr2->velocity.X += (float) Main.rand.Next(-10, 11) * (3.0 / 1000.0);
              dustPtr2->velocity.Y += (float) Main.rand.Next(-10, 11) * (3.0 / 1000.0);
              if ((double) dustPtr2->velocity.X > 0.349999994039536)
                dustPtr2->velocity.X = 0.35f;
              else if ((double) dustPtr2->velocity.X < -0.349999994039536)
                dustPtr2->velocity.X = -0.35f;
              if ((double) dustPtr2->velocity.Y > 0.349999994039536)
                dustPtr2->velocity.Y = 0.35f;
              else if ((double) dustPtr2->velocity.Y < -0.349999994039536)
                dustPtr2->velocity.Y = -0.35f;
              dustPtr2->scale += 0.0085f;
              float y2 = (float) ((double) num2 * 0.699999988079071 + 0.00595000013709068);
              if ((double) y2 > 1.0)
                y2 = 1f;
              Lighting.addLight(x >> 4, y1 >> 4, new Vector3(y2 * 0.7f, y2, y2 * 0.8f));
            }
            else
              dustPtr2->velocity.X *= 0.99f;
label_206:
            if ((double) dustPtr2->fadeIn > 0.0)
            {
              if (num1 == 46)
                dustPtr2->scale += 0.1f;
              else
                dustPtr2->scale += 0.03f;
              if ((double) dustPtr2->scale > (double) dustPtr2->fadeIn)
                dustPtr2->fadeIn = 0.0f;
            }
            else
              dustPtr2->scale -= 0.01f;
            if (dustPtr2->noGravity)
            {
              dustPtr2->velocity.X *= 0.92f;
              dustPtr2->velocity.Y *= 0.92f;
              if ((double) dustPtr2->fadeIn == 0.0)
                dustPtr2->scale -= 0.04f;
            }
            if ((double) dustPtr2->scale < 0.100000001490116)
              dustPtr2->active = (byte) 0;
            else if (num1 != 79)
              dustPtr2->rotation += dustPtr2->velocity.X * 0.5f;
          }
label_220:
          ++dustPtr2;
        }
      }
    }

    public unsafe void DrawDust(WorldView drawView)
    {
      fixed (Dust* dustPtr1 = this.dust)
      {
        Dust* dustPtr2 = dustPtr1;
        Vector2 pivot = new Vector2(4f, 4f);
        Vector2 pos = new Vector2();
        for (int index = (int) this.size - 1; index >= 0; --index)
        {
          if ((int) dustPtr2->active != 0)
          {
            int x = (int) dustPtr2->position.X;
            int y = (int) dustPtr2->position.Y;
            if (this.view != null || drawView.clipArea.Contains(x, y))
            {
              Color newColor = dustPtr2->noLight || (int) dustPtr2->type == 6 || (int) dustPtr2->type == 15 || (int) dustPtr2->type >= 59 && (int) dustPtr2->type <= 64 ? Color.White : drawView.lighting.GetColor(x + 4 >> 4, y + 4 >> 4);
              dustPtr2->GetAlpha(ref newColor);
              if ((int) newColor.PackedValue == 0)
              {
                dustPtr2->active = (byte) 0;
              }
              else
              {
                pos.X = (float) (x - drawView.screenPosition.X);
                pos.Y = (float) (y - drawView.screenPosition.Y);
                SpriteSheet<_sheetSprites>.Draw(218, ref pos, ref dustPtr2->frame, newColor, dustPtr2->rotation, ref pivot, dustPtr2->scale);
                if ((int) dustPtr2->color.PackedValue != 0)
                {
                  dustPtr2->GetColor(ref newColor);
                  SpriteSheet<_sheetSprites>.Draw(218, ref pos, ref dustPtr2->frame, newColor, dustPtr2->rotation, ref pivot, dustPtr2->scale);
                }
              }
            }
          }
          ++dustPtr2;
        }
      }
    }
  }
}
