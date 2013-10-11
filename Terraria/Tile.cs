// Type: Terraria.Tile
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

namespace Terraria
{
  public struct Tile
  {
    public byte active;
    public byte type;
    public Tile.Flags flags;
    public byte liquid;
    public byte lava;
    public byte wall;
    public ushort wallFrameX;
    public byte wallFrameY;
    public byte frameNumber;
    public short frameX;
    public short frameY;

    public int wallFrameNumber
    {
      get
      {
        return (int) (this.flags & Tile.Flags.WALLFRAME_MASK);
      }
      set
      {
        this.flags = (Tile.Flags) value | this.flags & (Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
      }
    }

    public int checkingLiquid
    {
      get
      {
        return (int) (this.flags & Tile.Flags.CHECKING_LIQUID);
      }
      set
      {
        this.flags = (Tile.Flags) value | this.flags & (Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.SKIP_LIQUID);
      }
    }

    public int skipLiquid
    {
      get
      {
        return (int) (this.flags & Tile.Flags.SKIP_LIQUID);
      }
      set
      {
        this.flags = (Tile.Flags) value | this.flags & (Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID);
      }
    }

    public int wire
    {
      get
      {
        return (int) (this.flags & Tile.Flags.WIRE);
      }
      set
      {
        this.flags = (Tile.Flags) value | this.flags & (Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
      }
    }

    public void Clear()
    {
      this.active = (byte) 0;
      this.flags = ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
      this.type = (byte) 0;
      this.wall = (byte) 0;
      this.wallFrameX = (ushort) 0;
      this.wallFrameY = (byte) 0;
      this.liquid = (byte) 0;
      this.lava = (byte) 0;
      this.frameNumber = (byte) 0;
    }

    public bool isTheSameAsExcludingVisibility(ref Tile compTile)
    {
      return (int) this.active == (int) compTile.active && ((int) this.active == 0 || (int) this.type == (int) compTile.type && (!Main.tileFrameImportant[(int) this.type] || (int) this.frameX == (int) compTile.frameX && (int) this.frameY == (int) compTile.frameY)) && ((int) this.wall == (int) compTile.wall && (int) this.liquid == (int) compTile.liquid && (this.flags & Tile.Flags.WIRE) == (compTile.flags & Tile.Flags.WIRE));
    }

    public bool isTheSameAs(ref Tile compTile)
    {
      return (int) this.active == (int) compTile.active && ((int) this.active == 0 || (int) this.type == (int) compTile.type && (!Main.tileFrameImportant[(int) this.type] || (int) this.frameX == (int) compTile.frameX && (int) this.frameY == (int) compTile.frameY)) && ((int) this.wall == (int) compTile.wall && (int) this.liquid == (int) compTile.liquid && (this.flags & (Tile.Flags.VISITED | Tile.Flags.WIRE)) == (compTile.flags & (Tile.Flags.VISITED | Tile.Flags.WIRE)));
    }

    public bool isFullTile()
    {
      if ((int) this.active != 0 && (int) this.type != 10 && ((int) this.type != 54 && (int) this.type != 138) && Main.tileSolidNotSolidTop[(int) this.type])
      {
        int num1 = (int) this.frameY;
        if (num1 == 18)
        {
          int num2 = (int) this.frameX;
          if (num2 >= 18 && num2 <= 54 || num2 >= 108 && num2 <= 144)
            return true;
        }
        else if (num1 >= 90 && num1 <= 196)
        {
          int num2 = (int) this.frameX;
          if (num2 <= 70 || num2 >= 144 && num2 <= 232)
            return true;
        }
      }
      return false;
    }

    public bool canStandOnTop()
    {
      if ((int) this.active == 0)
        return false;
      if (Main.tileSolid[(int) this.type])
        return true;
      if ((int) this.frameY == 0)
        return Main.tileSolidTop[(int) this.type];
      else
        return false;
    }

    [System.Flags]
    public enum Flags : byte
    {
      WALLFRAME_MASK = (byte) 3,
      NEARBY = (byte) 4,
      VISITED = (byte) 8,
      WIRE = (byte) 16,
      SELECTED = (byte) 32,
      LAVA = SELECTED,
      CHECKING_LIQUID = (byte) 64,
      SKIP_LIQUID = (byte) 128,
      HIGHLIGHT_MASK = LAVA | NEARBY,
    }
  }
}
