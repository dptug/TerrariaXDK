// Type: Terraria.Time
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public struct Time
  {
    private const int sunWidth = 64;
    private const int moonWidth = 50;
    public const int moonHeight = 50;
    public const int dayLength = 54000;
    public const int nightLength = 32400;
    public float dayRate;
    public float time;
    public bool dayTime;
    public bool bloodMoon;
    public byte moonPhase;
    public Color intermediateCelestialColor;
    public Color intermediateBgColor;
    public short celestialX;
    public short celestialY;
    public float celestialRotation;
    public float celestialScale;
    public Color celestialColor;
    public Color bgColor;
    public Color tileColor;
    public Vector3 tileColorf;
    public static bool xMas;

    static Time()
    {
    }

    public void reset(float speed)
    {
      this.dayRate = speed;
      this.time = 13500f;
      this.dayTime = true;
      this.bloodMoon = false;
      this.moonPhase = (byte) 0;
      this.intermediateCelestialColor.A = byte.MaxValue;
      this.intermediateBgColor.A = byte.MaxValue;
      this.tileColor.A = byte.MaxValue;
      this.updateDay();
    }

    private void updateNight()
    {
      this.celestialX = (short) ((int) ((double) this.time / 32400.0 * 1060.0) - 50);
      this.celestialRotation = (float) ((double) this.time / 16200.0 - 7.30000019073486);
      float num1 = (double) this.time >= 16200.0 ? (float) (((double) this.time / 32400.0 - 0.5) * 2.0) : (float) (1.0 - (double) this.time / 16200.0);
      float num2 = num1 * num1;
      this.celestialY = (short) ((int) ((double) num2 * 250.0) + 180);
      this.celestialScale = (float) (1.20000004768372 - (double) num2 * 0.400000005960464);
      if (this.bloodMoon)
      {
        if ((double) this.time < 16200.0)
        {
          float num3 = (float) (1.0 - (double) this.time / 16200.0);
          this.intermediateCelestialColor.R = (byte) ((double) num3 * 10.0 + 205.0);
          this.intermediateCelestialColor.G = (byte) ((double) num3 * 170.0 + 55.0);
          this.intermediateCelestialColor.B = (byte) ((double) num3 * 200.0 + 55.0);
          this.intermediateBgColor.R = (byte) (40.0 - (double) num3 * 40.0 + 35.0);
          this.intermediateBgColor.G = (byte) ((double) num3 * 20.0 + 15.0);
          this.intermediateBgColor.B = (byte) ((double) num3 * 20.0 + 15.0);
        }
        else
        {
          if ((double) this.time < 16200.0)
            return;
          float num3 = (float) (((double) this.time / 32400.0 - 0.5) * 2.0);
          this.intermediateCelestialColor.R = (byte) ((double) num3 * 10.0 + 205.0);
          this.intermediateCelestialColor.G = (byte) ((double) num3 * 170.0 + 55.0);
          this.intermediateCelestialColor.B = (byte) ((double) num3 * 200.0 + 55.0);
          this.intermediateBgColor.R = (byte) (40.0 - (double) num3 * 40.0 + 35.0);
          this.intermediateBgColor.G = (byte) ((double) num3 * 20.0 + 15.0);
          this.intermediateBgColor.B = (byte) ((double) num3 * 20.0 + 15.0);
        }
      }
      else if ((double) this.time < 16200.0)
      {
        float num3 = (float) (1.0 - (double) this.time / 16200.0);
        this.intermediateCelestialColor.R = (byte) ((double) num3 * 10.0 + 205.0);
        this.intermediateCelestialColor.G = (byte) ((double) num3 * 70.0 + 155.0);
        this.intermediateCelestialColor.B = (byte) ((double) num3 * 100.0 + 155.0);
        this.intermediateBgColor.R = (byte) ((double) num3 * 20.0 + 15.0);
        this.intermediateBgColor.G = (byte) ((double) num3 * 20.0 + 15.0);
        this.intermediateBgColor.B = (byte) ((double) num3 * 20.0 + 15.0);
      }
      else if ((double) this.time >= 16200.0)
      {
        float num3 = (float) (((double) this.time / 32400.0 - 0.5) * 2.0);
        this.intermediateCelestialColor.R = (byte) ((double) num3 * 50.0 + 205.0);
        this.intermediateCelestialColor.G = (byte) ((double) num3 * 100.0 + 155.0);
        this.intermediateCelestialColor.B = (byte) ((double) num3 * 100.0 + 155.0);
        this.intermediateBgColor.R = (byte) ((double) num3 * 10.0 + 15.0);
        this.intermediateBgColor.G = (byte) ((double) num3 * 20.0 + 15.0);
        this.intermediateBgColor.B = (byte) ((double) num3 * 20.0 + 15.0);
      }
      else
      {
        this.intermediateCelestialColor = Color.White;
        this.intermediateBgColor = Color.White;
      }
    }

    private void updateDay()
    {
      this.celestialX = (short) ((int) ((double) this.time / 54000.0 * 1088.0) - 64);
      this.celestialRotation = (float) ((double) this.time / 27000.0 - 7.30000019073486);
      float num1 = (double) this.time >= 27000.0 ? (float) (((double) this.time / 54000.0 - 0.5) * 2.0) : (float) (1.0 - (double) this.time / 54000.0 * 2.0);
      float num2 = num1 * num1;
      this.celestialY = (short) ((int) ((double) num2 * 250.0) + 180);
      this.celestialScale = (float) ((1.20000004768372 - (double) num2 * 0.400000005960464) * 1.10000002384186);
      if ((double) this.time < 13500.0)
      {
        float num3 = this.time / 13500f;
        this.intermediateCelestialColor.R = (byte) ((double) num3 * 200.0 + 55.0);
        this.intermediateCelestialColor.G = (byte) ((double) num3 * 180.0 + 75.0);
        this.intermediateCelestialColor.B = (byte) ((double) num3 * 250.0 + 5.0);
        this.intermediateBgColor.R = (byte) ((double) num3 * 230.0 + 25.0);
        this.intermediateBgColor.G = (byte) ((double) num3 * 220.0 + 35.0);
        this.intermediateBgColor.B = (byte) ((double) num3 * 220.0 + 35.0);
      }
      else if ((double) this.time > 45900.0)
      {
        float num3 = (float) (1.0 - ((double) this.time / 54000.0 - 0.850000023841858) * 6.66666650772095);
        this.intermediateCelestialColor.R = (byte) ((double) num3 * 120.0 + 55.0);
        this.intermediateCelestialColor.G = (byte) ((double) num3 * 100.0 + 25.0);
        this.intermediateCelestialColor.B = (byte) ((double) num3 * 120.0 + 55.0);
        this.intermediateBgColor.R = (byte) ((double) num3 * 200.0 + 35.0);
        this.intermediateBgColor.G = (byte) ((double) num3 * 85.0 + 35.0);
        this.intermediateBgColor.B = (byte) ((double) num3 * 135.0 + 35.0);
      }
      else if ((double) this.time > 37800.0)
      {
        float num3 = (float) (1.0 - ((double) this.time / 54000.0 - 0.699999988079071) * 6.66666650772095);
        this.intermediateCelestialColor.R = (byte) ((double) num3 * 80.0 + 175.0);
        this.intermediateCelestialColor.G = (byte) ((double) num3 * 130.0 + 125.0);
        this.intermediateCelestialColor.B = (byte) ((double) num3 * 100.0 + 155.0);
        this.intermediateBgColor.R = (byte) ((double) num3 * 20.0 + 235.0);
        this.intermediateBgColor.G = (byte) ((double) num3 * 135.0 + 120.0);
        this.intermediateBgColor.B = (byte) ((double) num3 * 85.0 + 170.0);
      }
      else
      {
        this.intermediateCelestialColor = Color.White;
        this.intermediateBgColor = Color.White;
      }
    }

    public void applyJungle(float light)
    {
      if ((double) light > 1.0)
        light = 1f;
      int num1 = (int) this.intermediateBgColor.R;
      int num2 = (int) this.intermediateBgColor.G;
      int num3 = (int) this.intermediateBgColor.B;
      int num4 = num1 - (int) (30.0 * (double) light * ((double) num1 * 0.00392156885936856));
      int num5 = num3 - (int) (90.0 * (double) light * ((double) num3 * 0.00392156885936856));
      if (num4 < 15)
        num4 = 15;
      if (num5 < 15)
        num5 = 15;
      this.bgColor.R = (byte) num4;
      this.bgColor.G = (byte) num2;
      this.bgColor.B = (byte) num5;
      this.bgColor.A = byte.MaxValue;
      int num6 = (int) this.intermediateCelestialColor.R;
      int num7 = (int) this.intermediateCelestialColor.G;
      int num8 = (int) this.intermediateCelestialColor.B;
      int num9;
      int num10;
      if (this.dayTime)
      {
        num9 = num6 - (int) (30.0 * (double) light * ((double) num6 * 0.00392156885936856));
        num10 = num8 - (int) (10.0 * (double) light * ((double) num7 * 0.00392156885936856));
      }
      else
      {
        num9 = num6 - (int) (140.0 * (double) light * ((double) num6 * 0.00392156885936856));
        num7 -= (int) (190.0 * (double) light * ((double) num7 * 0.00392156885936856));
        num10 = num8 - (int) (170.0 * (double) light * ((double) num8 * 0.00392156885936856));
      }
      if (num9 < 15)
        num9 = 15;
      if (num7 < 15)
        num7 = 15;
      if (num10 < 15)
        num10 = 15;
      this.celestialColor.R = (byte) num9;
      this.celestialColor.G = (byte) num7;
      this.celestialColor.B = (byte) num10;
      this.celestialColor.A = byte.MaxValue;
    }

    public void applyEvil(float light)
    {
      if ((double) light > 1.0)
        light = 1f;
      int num1 = (int) this.intermediateBgColor.R;
      int num2 = (int) this.intermediateBgColor.G;
      int num3 = (int) this.intermediateBgColor.B;
      int num4 = num1 - (int) (100.0 * (double) light * ((double) num1 * 0.00392156885936856));
      int num5 = num2 - (int) (140.0 * (double) light * ((double) num2 * 0.00392156885936856));
      int num6 = num3 - (int) (80.0 * (double) light * ((double) num3 * 0.00392156885936856));
      if (num4 < 15)
        num4 = 15;
      if (num5 < 15)
        num5 = 15;
      if (num6 < 15)
        num6 = 15;
      this.bgColor.R = (byte) num4;
      this.bgColor.G = (byte) num5;
      this.bgColor.B = (byte) num6;
      this.bgColor.A = byte.MaxValue;
      int num7 = (int) this.intermediateCelestialColor.R;
      int num8 = (int) this.intermediateCelestialColor.G;
      int num9 = (int) this.intermediateCelestialColor.B;
      int num10;
      int num11;
      if (this.dayTime)
      {
        num10 = num7 - (int) (100.0 * (double) light * ((double) num7 * 0.00392156885936856));
        num11 = num8 - (int) (100.0 * (double) light * ((double) num8 * 0.00392156885936856));
      }
      else
      {
        num10 = num7 - (int) (140.0 * (double) light * ((double) num7 * 0.00392156885936856));
        num11 = num8 - (int) (190.0 * (double) light * ((double) num8 * 0.00392156885936856));
        num9 -= (int) (170.0 * (double) light * ((double) num9 * 0.00392156885936856));
      }
      if (num10 < 15)
        num10 = 15;
      if (num11 < 15)
        num11 = 15;
      if (num9 < 15)
        num9 = 15;
      this.celestialColor.R = (byte) num10;
      this.celestialColor.G = (byte) num11;
      this.celestialColor.B = (byte) num9;
      this.celestialColor.A = byte.MaxValue;
    }

    public void applyNothing()
    {
      this.celestialColor = this.intermediateCelestialColor;
      this.bgColor = this.intermediateBgColor;
    }

    public void finalizeColors()
    {
      if (this.bloodMoon)
      {
        if ((int) this.bgColor.R < 35)
          this.bgColor.R = (byte) 35;
        if ((int) this.bgColor.G < 35)
          this.bgColor.G = (byte) 35;
        if ((int) this.bgColor.B < 35)
          this.bgColor.B = (byte) 35;
      }
      else
      {
        if ((int) this.bgColor.R < 25)
          this.bgColor.R = (byte) 25;
        if ((int) this.bgColor.G < 25)
          this.bgColor.G = (byte) 25;
        if ((int) this.bgColor.B < 25)
          this.bgColor.B = (byte) 25;
      }
      this.tileColor.R = (byte) (((int) this.bgColor.G + (int) this.bgColor.B + (int) this.bgColor.R * 8) / 10);
      this.tileColor.G = (byte) (((int) this.bgColor.R + (int) this.bgColor.B + (int) this.bgColor.G * 8) / 10);
      this.tileColor.B = (byte) (((int) this.bgColor.R + (int) this.bgColor.G + (int) this.bgColor.B * 8) / 10);
      this.tileColorf.X = (float) this.tileColor.R * 0.003921569f;
      this.tileColorf.Y = (float) this.tileColor.G * 0.003921569f;
      this.tileColorf.Z = (float) this.tileColor.B * 0.003921569f;
    }

    public bool update()
    {
      this.time += this.dayRate;
      if (!this.dayTime)
      {
        if ((double) this.time > 32400.0)
        {
          this.time = 0.0f;
          this.dayTime = true;
          this.bloodMoon = false;
          this.moonPhase = (byte) ((int) this.moonPhase + 1 & 7);
          this.updateDay();
          return true;
        }
        else
          this.updateNight();
      }
      else if ((double) this.time > 54000.0)
      {
        this.time = 0.0f;
        this.dayTime = false;
        this.updateNight();
        return true;
      }
      else
        this.updateDay();
      return false;
    }

    public static void checkXMas()
    {
      DateTime now = DateTime.Now;
      Time.xMas = now.Month == 12 && now.Day >= 15;
    }
  }
}
