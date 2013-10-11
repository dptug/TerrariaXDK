// Type: Terraria.NetPlayer
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

namespace Terraria
{
  public sealed class NetPlayer
  {
    public Item[] inventory = new Item[49];
    public Item[] armor = new Item[11];
    public Buff[] buff = new Buff[10];
    public bool zoneDungeon;
    public bool zoneEvil;
    public bool zoneHoly;
    public bool zoneMeteor;
    public bool zoneJungle;
    public sbyte selectedItem;
    public bool controlUp;
    public bool controlDown;
    public bool controlLeft;
    public bool controlRight;
    public bool controlJump;
    public bool controlUseItem;
    public short statLifeMax;
    public short statLife;
    public short statMana;
    public short statManaMax;
    public short chest;
    public short talkNPC;
  }
}
