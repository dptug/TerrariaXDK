// Type: Terraria.Cloud
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct Cloud
  {
    public static Cloud[] cloud = new Cloud[20];
    public static int numClouds = 20;
    public static float windSpeed = 0.0f;
    public static float windSpeedSpeed = 0.0f;
    public static bool resetClouds = true;
    public const int MAX_CLOUDS = 20;
    public const int MAX_CLOUD_TYPES = 4;
    public Vector2 position;
    public float scale;
    public bool active;
    public byte type;
    public ushort width;
    public ushort height;

    static Cloud()
    {
    }

    public static void Initialize()
    {
      for (int index = 0; index < 20; ++index)
        Cloud.cloud[index].Init();
    }

    public void Init()
    {
      this.active = false;
      this.type = (byte) 0;
      this.width = (ushort) 0;
      this.height = (ushort) 0;
    }

    public static unsafe void addCloud()
    {
      fixed (Cloud* cloudPtr1 = Cloud.cloud)
      {
        Cloud* cloudPtr2 = cloudPtr1;
        for (int index1 = 19; index1 >= 0; --index1)
        {
          if (!cloudPtr2->active)
          {
            cloudPtr2->type = (byte) Main.rand.Next(4);
            int index2 = (int) cloudPtr2->type + 8;
            cloudPtr2->scale = (float) Main.rand.Next(50, 131) * 0.01f;
            cloudPtr2->width = (ushort) ((double) SpriteSheet<_sheetTiles>.src[index2].Width * (double) cloudPtr2->scale);
            cloudPtr2->height = (ushort) ((double) SpriteSheet<_sheetTiles>.src[index2].Height * (double) cloudPtr2->scale);
            cloudPtr2->position.X = (double) Cloud.windSpeed <= 0.0 ? 960f : (float) -cloudPtr2->width;
            cloudPtr2->position.Y = (float) (Main.rand.Next(-135, 135) - Main.rand.Next(180));
            cloudPtr2->active = true;
            break;
          }
          else
            ++cloudPtr2;
        }
      }
    }

    public Color cloudColor(Color bgColor)
    {
      float num1 = (float) (((double) this.scale - 0.400000005960464) * 0.899999976158142);
      float num2 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.R) * 1.10000002384186);
      float num3 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.G) * 1.10000002384186);
      float num4 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.B) * 1.10000002384186);
      float num5 = (float) byte.MaxValue;
      float num6 = num2 * num1;
      float num7 = num3 * num1;
      float num8 = num4 * num1;
      float num9 = num5 * num1;
      if ((double) num6 < 0.0)
        num6 = 0.0f;
      if ((double) num7 < 0.0)
        num7 = 0.0f;
      if ((double) num8 < 0.0)
        num8 = 0.0f;
      if ((double) num9 < 0.0)
        num9 = 0.0f;
      return new Color((int) (byte) num6, (int) (byte) num7, (int) (byte) num8, (int) (byte) num9);
    }

    public static unsafe void UpdateClouds()
    {
      if (Cloud.resetClouds)
      {
        Cloud.resetClouds = false;
        Cloud.numClouds = Main.rand.Next(10, 20);
        do
        {
          Cloud.windSpeed = (float) Main.rand.Next(-100, 101) * 0.01f;
        }
        while ((double) Cloud.windSpeed == 0.0);
        for (int index = 0; index < 20; ++index)
          Cloud.cloud[index].active = false;
        for (int index = 0; index < Cloud.numClouds; ++index)
          Cloud.addCloud();
        for (int index = 0; index < Cloud.numClouds; ++index)
        {
          int num = Main.rand.Next(960);
          if ((double) Cloud.cloud[index].position.X < 0.0)
            Cloud.cloud[index].position.X += (float) num;
          else
            Cloud.cloud[index].position.X -= (float) num;
        }
      }
      Cloud.windSpeedSpeed += (float) Main.rand.Next(-20, 21) * 0.0001f;
      if ((double) Cloud.windSpeedSpeed < -0.002)
        Cloud.windSpeedSpeed = -1.0 / 500.0;
      else if ((double) Cloud.windSpeedSpeed > 0.002)
        Cloud.windSpeedSpeed = 1.0 / 500.0;
      Cloud.windSpeed += Cloud.windSpeedSpeed;
      if ((double) Cloud.windSpeed < -0.4)
        Cloud.windSpeed = -0.4f;
      else if ((double) Cloud.windSpeed > 0.4)
        Cloud.windSpeed = 0.4f;
      Cloud.numClouds += Main.rand.Next(-1, 2);
      if (Cloud.numClouds < 0)
        Cloud.numClouds = 0;
      else if (Cloud.numClouds > 20)
        Cloud.numClouds = 20;
      int num1 = 0;
      for (int index = 0; index < 20; ++index)
      {
        fixed (Cloud* cloudPtr = &Cloud.cloud[index])
        {
          if (cloudPtr->active)
          {
            cloudPtr->Update();
            ++num1;
          }
        }
      }
      if (num1 >= Cloud.numClouds)
        return;
      Cloud.addCloud();
    }

    public void Update()
    {
      this.position.X += (float) ((double) Cloud.windSpeed * (double) this.scale * 2.0);
      if ((double) Cloud.windSpeed > 0.0)
      {
        if ((double) this.position.X <= 960.0)
          return;
        this.active = false;
      }
      else
      {
        if ((double) this.position.X >= (double) -this.width)
          return;
        this.active = false;
      }
    }
  }
}
