// Type: Terraria.NetClient
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using System.Collections.ObjectModel;

namespace Terraria
{
  public sealed class NetClient
  {
    public NetworkMachine machine;
    public NetworkGamer gamer;
    public short serverState;
    private bool isPublicSlotRequest;
    public bool[] playerSlots;
    public bool[,] tileSection;

    public NetClient(NetworkGamer g)
    {
      this.machine = g.Machine;
      this.gamer = g;
      this.serverState = (short) 0;
      this.isPublicSlotRequest = false;
      this.playerSlots = new bool[16];
      this.tileSection = new bool[(int) sbyte.MaxValue, 49];
    }

    public void RequestedPublicSlot()
    {
      --Netplay.session.PrivateGamerSlots;
      this.isPublicSlotRequest = true;
    }

    public void CanceledPublicSlot()
    {
      ++Netplay.session.PrivateGamerSlots;
      this.isPublicSlotRequest = false;
    }

    public void GamerJoined(Player player)
    {
      player.client = this;
      int index = (int) player.whoAmI;
      this.playerSlots[index] = true;
      this.playerSlots[index + 8] = this.isPublicSlotRequest;
      this.isPublicSlotRequest = false;
    }

    public bool GamerLeft(Player player)
    {
      int index = (int) player.whoAmI;
      this.playerSlots[index] = false;
      if (this.playerSlots[index + 8])
      {
        this.playerSlots[index + 8] = false;
        ++Netplay.session.PrivateGamerSlots;
      }
      player.client = (NetClient) null;
      return ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers).Count == 0;
    }

    public void ResetSections()
    {
      for (int index1 = 0; index1 < Main.maxSectionsX; ++index1)
      {
        for (int index2 = 0; index2 < Main.maxSectionsY; ++index2)
          this.tileSection[index1, index2] = false;
      }
    }

    public void ResetSections(ref Vector2i min, ref Vector2i max)
    {
      int num1 = min.X / 40;
      int num2 = min.Y / 30;
      int num3 = max.X / 40;
      int num4 = max.Y / 30;
      for (int index1 = num1; index1 <= num3; ++index1)
      {
        for (int index2 = num2; index2 <= num4; ++index2)
          this.tileSection[index1, index2] = false;
      }
    }

    public bool SectionRange(int size, int firstX, int firstY)
    {
      int index1 = firstX / 40;
      int index2 = firstY / 30;
      if (this.tileSection[index1, index2])
        return true;
      int index3 = (firstY + size) / 30;
      if (this.tileSection[index1, index3])
        return true;
      int index4 = (firstX + size) / 40;
      if (this.tileSection[index4, index2])
        return true;
      else
        return this.tileSection[index4, index3];
    }

    public bool IsReadyToReceive(byte[] packet)
    {
      if ((int) this.serverState < 10)
        return false;
      byte num = packet[0];
      if ((uint) num <= 20U)
      {
        if ((int) num != 13)
        {
          if ((int) num == 20)
            return this.SectionRange((int) packet[1], (int) packet[2] | (int) packet[3] << 8, (int) packet[4] | (int) packet[5] << 8);
        }
        else
        {
          Player player1 = Main.player[(int) packet[1] & 7];
          if ((int) player1.netSkip == 0)
            return true;
          Rectangle rectangle = player1.aabb;
          rectangle.X -= 2500;
          rectangle.Y -= 2500;
          rectangle.Width += 5000;
          rectangle.Height += 5000;
          for (int index = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers).Count - 1; index >= 0; --index)
          {
            Player player2 = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers)[index].Tag as Player;
            if (rectangle.Intersects(player2.aabb))
              return true;
          }
          return false;
        }
      }
      else if ((int) num == 23 || (int) num == 28)
      {
        NPC npc = Main.npc[(int) packet[1]];
        if (npc.life <= 0 || npc.townNPC)
          return true;
        Rectangle rectangle = npc.aabb;
        rectangle.X -= 3000;
        rectangle.Y -= 3000;
        rectangle.Width += 6000;
        rectangle.Height += 6000;
        for (int index = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers).Count - 1; index >= 0; --index)
        {
          Player player = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers)[index].Tag as Player;
          if (rectangle.Intersects(player.aabb))
            return true;
        }
        return false;
      }
      return true;
    }

    public bool IsReadyToReceiveProjectile(ref Projectile projectile)
    {
      if ((int) this.serverState == 10)
      {
        if ((int) projectile.type == 12)
          return true;
        Rectangle rectangle = projectile.aabb;
        rectangle.X -= 5000;
        rectangle.Y -= 5000;
        rectangle.Width += 10000;
        rectangle.Height += 10000;
        for (int index = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers).Count - 1; index >= 0; --index)
        {
          Player player = ((ReadOnlyCollection<NetworkGamer>) this.machine.Gamers)[index].Tag as Player;
          if (rectangle.Intersects(player.aabb))
            return true;
        }
      }
      return false;
    }
  }
}
