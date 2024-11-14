namespace Terraria;

public struct Location
{
	public short X;

	public short Y;

	public Location(int x, int y)
	{
		X = (short)x;
		Y = (short)y;
	}
}
