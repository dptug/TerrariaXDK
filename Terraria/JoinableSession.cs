// Type: Terraria.JoinableSession
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Net;

namespace Terraria
{
  public sealed class JoinableSession
  {
    public const int SEARCH_DELAY = 5000;
    public string host;
    public int players;
    public AvailableNetworkSession joinableSession;

    public JoinableSession(AvailableNetworkSession session)
    {
      this.host = session.HostGamertag;
      this.players = session.CurrentGamerCount;
      this.joinableSession = session;
    }
  }
}
