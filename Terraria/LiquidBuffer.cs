namespace Terraria
{
	public struct LiquidBuffer
	{
		public const int MAX_LIQUID_BUFFER = 8192;

		public static int numLiquidBuffer;

		public short x;

		public short y;

		public static void AddBuffer(int x, int y)
		{
			if (numLiquidBuffer != 8191 && Main.tile[x, y].checkingLiquid == 0)
			{
				Main.tile[x, y].checkingLiquid = 64;
				Main.liquidBuffer[numLiquidBuffer].x = (short)x;
				Main.liquidBuffer[numLiquidBuffer].y = (short)y;
				numLiquidBuffer++;
			}
		}
	}
}
