using Microsoft.Xna.Framework;

namespace Terraria;

public struct ChatLine
{
	public Color color;

	public int showTime;

	public string text;

	public void Init()
	{
		color = Color.White;
		showTime = 0;
		text = null;
	}
}
