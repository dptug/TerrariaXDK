namespace Terraria
{
	public struct ControlDesc
	{
		public int alignment;

		public ushort X;

		public ushort Y;

		public string text;

		public ControlDesc(int a, int x, int y, string t)
		{
			alignment = a;
			X = (ushort)x;
			Y = (ushort)y;
			text = t;
		}
	}
}
