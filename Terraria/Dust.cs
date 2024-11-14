using Microsoft.Xna.Framework;

namespace Terraria;

public struct Dust
{
	public const int NUM_GLOBAL = 256;

	public const int NUM_LOCAL = 128;

	public byte active;

	public bool noGravity;

	public bool noLight;

	public ushort type;

	public short alpha;

	public Color color;

	public float fadeIn;

	public float rotation;

	public float scale;

	public Rectangle frame;

	public Vector2 position;

	public Vector2 velocity;

	public void Init()
	{
		active = 0;
		noGravity = false;
		noLight = false;
		type = 0;
		fadeIn = 0f;
	}

	public void GetAlpha(ref Color newColor)
	{
		if (type == 6 || type == 75 || type == 20 || type == 21)
		{
			newColor.A = 25;
			return;
		}
		if ((type == 68 || type == 70) && noGravity)
		{
			newColor = new Color(255, 255, 255, 0);
			return;
		}
		if (type == 66)
		{
			newColor.A = 0;
			return;
		}
		if (type == 71)
		{
			newColor = new Color(200, 200, 200, 0);
			return;
		}
		if (type == 72)
		{
			newColor = new Color(200, 200, 200, 200);
			return;
		}
		float num = (float)(255 - alpha) * 0.003921569f;
		if (type == 15 || type == 29 || type == 35 || type == 41 || type == 44 || type == 27 || type == 45 || type == 55 || type == 56 || type == 57 || type == 58 || type == 73 || type == 74)
		{
			num = (num + 3f) * 0.25f;
		}
		else if (type == 43)
		{
			num = (num + 9f) * 0.1f;
		}
		newColor.R = (byte)((float)(int)newColor.R * num);
		newColor.G = (byte)((float)(int)newColor.G * num);
		newColor.B = (byte)((float)(int)newColor.B * num);
		newColor.A -= (byte)alpha;
	}

	public void GetColor(ref Color newColor)
	{
		int r = color.R - (255 - newColor.R);
		int g = color.G - (255 - newColor.G);
		int b = color.B - (255 - newColor.B);
		int a = color.A - (255 - newColor.A);
		newColor = new Color(r, g, b, a);
	}
}
