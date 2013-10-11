// Type: Terraria.Sign
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Net;
using System.IO;

namespace Terraria
{
  public struct Sign
  {
    public const int MAX_SIGNS = 1000;
    public short x;
    public short y;
    public UserString text;

    public void Init()
    {
      this.x = (short) -1;
      this.y = (short) -1;
      this.text = (UserString) null;
    }

    public static void KillSign(int x, int y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if ((int) Main.sign[index].x == x && (int) Main.sign[index].y == y)
        {
          Main.sign[index].Init();
          break;
        }
      }
    }

    public static int ReadSign(int i, int j)
    {
      int num1 = (int) Main.tile[i, j].frameX / 18 & 1;
      int num2 = (int) Main.tile[i, j].frameY / 18;
      int x = i - num1;
      int y = j - num2;
      if ((int) Main.tile[x, y].type != 55 && (int) Main.tile[x, y].type != 85)
      {
        Sign.KillSign(x, y);
        return -1;
      }
      else
      {
        int num3 = 0;
        for (int index = 0; index < 1000; ++index)
        {
          if ((int) Main.sign[index].x < 0)
            num3 = index;
          else if ((int) Main.sign[index].x == x && (int) Main.sign[index].y == y)
            return index;
        }
        for (int index = num3; index < 1000; ++index)
        {
          if ((int) Main.sign[index].x < 0)
          {
            Main.sign[index].x = (short) x;
            Main.sign[index].y = (short) y;
            Main.sign[index].text = new UserString("", true);
            return index;
          }
        }
        return -1;
      }
    }

    private unsafe bool Validate()
    {
      fixed (Tile* tilePtr = &Main.tile[(int) this.x, (int) this.y])
      {
        if ((int) tilePtr->active == 0 || (int) tilePtr->type != 55 && (int) tilePtr->type != 85)
        {
          this.Init();
          return false;
        }
        else
        {
          // ISSUE: __unpin statement
          __unpin(tilePtr);
          return true;
        }
      }
    }

    public void SetText(UserString s)
    {
      if (!this.Validate())
        return;
      this.text = s;
    }

    public void Read(PacketReader packetIn)
    {
      this.x = ((BinaryReader) packetIn).ReadInt16();
      this.y = ((BinaryReader) packetIn).ReadInt16();
      this.text = new UserString((BinaryReader) packetIn);
    }

    public void Read(BinaryReader fileIO, int release)
    {
      if (!fileIO.ReadBoolean())
        return;
      if (release >= 49)
      {
        this.x = fileIO.ReadInt16();
        this.y = fileIO.ReadInt16();
        this.text = new UserString(fileIO);
      }
      else
      {
        this.text = (UserString) fileIO.ReadString();
        this.x = fileIO.ReadInt16();
        this.y = fileIO.ReadInt16();
      }
      this.Validate();
    }

    public void Write(BinaryWriter fileIO)
    {
      if ((int) this.x < 0 || this.text == null)
      {
        fileIO.Write(false);
      }
      else
      {
        fileIO.Write(true);
        fileIO.Write(this.x);
        fileIO.Write(this.y);
        this.text.Write(fileIO);
      }
    }
  }
}
