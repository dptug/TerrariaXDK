namespace Terraria;

public struct ControlDesc(int a, int x, int y, string t)
{
	public int alignment = a;

	public ushort X = (ushort)x;

	public ushort Y = (ushort)y;

	public string text = t;
}
