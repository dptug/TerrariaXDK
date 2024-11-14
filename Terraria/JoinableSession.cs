using Microsoft.Xna.Framework.Net;

namespace Terraria;

public sealed class JoinableSession
{
	public const int SEARCH_DELAY = 5000;

	public string host;

	public int players;

	public AvailableNetworkSession joinableSession;

	public JoinableSession(AvailableNetworkSession session)
	{
		host = session.HostGamertag;
		players = session.CurrentGamerCount;
		joinableSession = session;
	}
}
