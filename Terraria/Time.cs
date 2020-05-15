using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public struct Time
	{
		private const int sunWidth = 64;

		private const int moonWidth = 50;

		public const int moonHeight = 50;

		public const int dayLength = 54000;

		public const int nightLength = 32400;

		public float dayRate;

		public float time;

		public bool dayTime;

		public bool bloodMoon;

		public byte moonPhase;

		public Color intermediateCelestialColor;

		public Color intermediateBgColor;

		public short celestialX;

		public short celestialY;

		public float celestialRotation;

		public float celestialScale;

		public Color celestialColor;

		public Color bgColor;

		public Color tileColor;

		public Vector3 tileColorf;

		public static bool xMas;

		public void reset(float speed)
		{
			dayRate = speed;
			time = 13500f;
			dayTime = true;
			bloodMoon = false;
			moonPhase = 0;
			intermediateCelestialColor.A = byte.MaxValue;
			intermediateBgColor.A = byte.MaxValue;
			tileColor.A = byte.MaxValue;
			updateDay();
		}

		private void updateNight()
		{
			celestialX = (short)((int)(time / 32400f * 1060f) - 50);
			celestialRotation = time / 16200f - 7.3f;
			float num = (!(time < 16200f)) ? ((time / 32400f - 0.5f) * 2f) : (1f - time / 16200f);
			num *= num;
			celestialY = (short)((int)(num * 250f) + 180);
			celestialScale = 1.2f - num * 0.4f;
			if (bloodMoon)
			{
				if (time < 16200f)
				{
					float num2 = 1f - time / 16200f;
					intermediateCelestialColor.R = (byte)(num2 * 10f + 205f);
					intermediateCelestialColor.G = (byte)(num2 * 170f + 55f);
					intermediateCelestialColor.B = (byte)(num2 * 200f + 55f);
					intermediateBgColor.R = (byte)(40f - num2 * 40f + 35f);
					intermediateBgColor.G = (byte)(num2 * 20f + 15f);
					intermediateBgColor.B = (byte)(num2 * 20f + 15f);
				}
				else if (time >= 16200f)
				{
					float num2 = (time / 32400f - 0.5f) * 2f;
					intermediateCelestialColor.R = (byte)(num2 * 10f + 205f);
					intermediateCelestialColor.G = (byte)(num2 * 170f + 55f);
					intermediateCelestialColor.B = (byte)(num2 * 200f + 55f);
					intermediateBgColor.R = (byte)(40f - num2 * 40f + 35f);
					intermediateBgColor.G = (byte)(num2 * 20f + 15f);
					intermediateBgColor.B = (byte)(num2 * 20f + 15f);
				}
			}
			else if (time < 16200f)
			{
				float num2 = 1f - time / 16200f;
				intermediateCelestialColor.R = (byte)(num2 * 10f + 205f);
				intermediateCelestialColor.G = (byte)(num2 * 70f + 155f);
				intermediateCelestialColor.B = (byte)(num2 * 100f + 155f);
				intermediateBgColor.R = (byte)(num2 * 20f + 15f);
				intermediateBgColor.G = (byte)(num2 * 20f + 15f);
				intermediateBgColor.B = (byte)(num2 * 20f + 15f);
			}
			else if (time >= 16200f)
			{
				float num2 = (time / 32400f - 0.5f) * 2f;
				intermediateCelestialColor.R = (byte)(num2 * 50f + 205f);
				intermediateCelestialColor.G = (byte)(num2 * 100f + 155f);
				intermediateCelestialColor.B = (byte)(num2 * 100f + 155f);
				intermediateBgColor.R = (byte)(num2 * 10f + 15f);
				intermediateBgColor.G = (byte)(num2 * 20f + 15f);
				intermediateBgColor.B = (byte)(num2 * 20f + 15f);
			}
			else
			{
				intermediateCelestialColor = Color.White;
				intermediateBgColor = Color.White;
			}
		}

		private void updateDay()
		{
			celestialX = (short)((int)(time / 54000f * 1088f) - 64);
			celestialRotation = time / 27000f - 7.3f;
			float num = (!(time < 27000f)) ? ((time / 54000f - 0.5f) * 2f) : (1f - time / 54000f * 2f);
			num *= num;
			celestialY = (short)((int)(num * 250f) + 180);
			celestialScale = (1.2f - num * 0.4f) * 1.1f;
			if (time < 13500f)
			{
				float num2 = time / 13500f;
				intermediateCelestialColor.R = (byte)(num2 * 200f + 55f);
				intermediateCelestialColor.G = (byte)(num2 * 180f + 75f);
				intermediateCelestialColor.B = (byte)(num2 * 250f + 5f);
				intermediateBgColor.R = (byte)(num2 * 230f + 25f);
				intermediateBgColor.G = (byte)(num2 * 220f + 35f);
				intermediateBgColor.B = (byte)(num2 * 220f + 35f);
			}
			else if (time > 45900f)
			{
				float num2 = 1f - (time / 54000f - 0.85f) * 6.66666651f;
				intermediateCelestialColor.R = (byte)(num2 * 120f + 55f);
				intermediateCelestialColor.G = (byte)(num2 * 100f + 25f);
				intermediateCelestialColor.B = (byte)(num2 * 120f + 55f);
				intermediateBgColor.R = (byte)(num2 * 200f + 35f);
				intermediateBgColor.G = (byte)(num2 * 85f + 35f);
				intermediateBgColor.B = (byte)(num2 * 135f + 35f);
			}
			else if (time > 37800f)
			{
				float num2 = 1f - (time / 54000f - 0.7f) * 6.66666651f;
				intermediateCelestialColor.R = (byte)(num2 * 80f + 175f);
				intermediateCelestialColor.G = (byte)(num2 * 130f + 125f);
				intermediateCelestialColor.B = (byte)(num2 * 100f + 155f);
				intermediateBgColor.R = (byte)(num2 * 20f + 235f);
				intermediateBgColor.G = (byte)(num2 * 135f + 120f);
				intermediateBgColor.B = (byte)(num2 * 85f + 170f);
			}
			else
			{
				intermediateCelestialColor = Color.White;
				intermediateBgColor = Color.White;
			}
		}

		public void applyJungle(float light)
		{
			if (light > 1f)
			{
				light = 1f;
			}
			int r = intermediateBgColor.R;
			int g = intermediateBgColor.G;
			int b = intermediateBgColor.B;
			r -= (int)(30f * light * ((float)r * 0.003921569f));
			b -= (int)(90f * light * ((float)b * 0.003921569f));
			if (r < 15)
			{
				r = 15;
			}
			if (b < 15)
			{
				b = 15;
			}
			bgColor.R = (byte)r;
			bgColor.G = (byte)g;
			bgColor.B = (byte)b;
			bgColor.A = byte.MaxValue;
			r = intermediateCelestialColor.R;
			g = intermediateCelestialColor.G;
			b = intermediateCelestialColor.B;
			if (dayTime)
			{
				r -= (int)(30f * light * ((float)r * 0.003921569f));
				b -= (int)(10f * light * ((float)g * 0.003921569f));
			}
			else
			{
				r -= (int)(140f * light * ((float)r * 0.003921569f));
				g -= (int)(190f * light * ((float)g * 0.003921569f));
				b -= (int)(170f * light * ((float)b * 0.003921569f));
			}
			if (r < 15)
			{
				r = 15;
			}
			if (g < 15)
			{
				g = 15;
			}
			if (b < 15)
			{
				b = 15;
			}
			celestialColor.R = (byte)r;
			celestialColor.G = (byte)g;
			celestialColor.B = (byte)b;
			celestialColor.A = byte.MaxValue;
		}

		public void applyEvil(float light)
		{
			if (light > 1f)
			{
				light = 1f;
			}
			int r = intermediateBgColor.R;
			int g = intermediateBgColor.G;
			int b = intermediateBgColor.B;
			r -= (int)(100f * light * ((float)r * 0.003921569f));
			g -= (int)(140f * light * ((float)g * 0.003921569f));
			b -= (int)(80f * light * ((float)b * 0.003921569f));
			if (r < 15)
			{
				r = 15;
			}
			if (g < 15)
			{
				g = 15;
			}
			if (b < 15)
			{
				b = 15;
			}
			bgColor.R = (byte)r;
			bgColor.G = (byte)g;
			bgColor.B = (byte)b;
			bgColor.A = byte.MaxValue;
			r = intermediateCelestialColor.R;
			g = intermediateCelestialColor.G;
			b = intermediateCelestialColor.B;
			if (dayTime)
			{
				r -= (int)(100f * light * ((float)r * 0.003921569f));
				g -= (int)(100f * light * ((float)g * 0.003921569f));
			}
			else
			{
				r -= (int)(140f * light * ((float)r * 0.003921569f));
				g -= (int)(190f * light * ((float)g * 0.003921569f));
				b -= (int)(170f * light * ((float)b * 0.003921569f));
			}
			if (r < 15)
			{
				r = 15;
			}
			if (g < 15)
			{
				g = 15;
			}
			if (b < 15)
			{
				b = 15;
			}
			celestialColor.R = (byte)r;
			celestialColor.G = (byte)g;
			celestialColor.B = (byte)b;
			celestialColor.A = byte.MaxValue;
		}

		public void applyNothing()
		{
			celestialColor = intermediateCelestialColor;
			bgColor = intermediateBgColor;
		}

		public void finalizeColors()
		{
			if (bloodMoon)
			{
				if (bgColor.R < 35)
				{
					bgColor.R = 35;
				}
				if (bgColor.G < 35)
				{
					bgColor.G = 35;
				}
				if (bgColor.B < 35)
				{
					bgColor.B = 35;
				}
			}
			else
			{
				if (bgColor.R < 25)
				{
					bgColor.R = 25;
				}
				if (bgColor.G < 25)
				{
					bgColor.G = 25;
				}
				if (bgColor.B < 25)
				{
					bgColor.B = 25;
				}
			}
			tileColor.R = (byte)((bgColor.G + bgColor.B + bgColor.R * 8) / 10);
			tileColor.G = (byte)((bgColor.R + bgColor.B + bgColor.G * 8) / 10);
			tileColor.B = (byte)((bgColor.R + bgColor.G + bgColor.B * 8) / 10);
			tileColorf.X = (float)(int)tileColor.R * 0.003921569f;
			tileColorf.Y = (float)(int)tileColor.G * 0.003921569f;
			tileColorf.Z = (float)(int)tileColor.B * 0.003921569f;
		}

		public bool update()
		{
			time += dayRate;
			if (!dayTime)
			{
				if (time > 32400f)
				{
					time = 0f;
					dayTime = true;
					bloodMoon = false;
					moonPhase = (byte)((moonPhase + 1) & 7);
					updateDay();
					return true;
				}
				updateNight();
			}
			else
			{
				if (time > 54000f)
				{
					time = 0f;
					dayTime = false;
					updateNight();
					return true;
				}
				updateDay();
			}
			return false;
		}

		public static void checkXMas()
		{
			DateTime now = DateTime.Now;
			xMas = (now.Month == 12 && now.Day >= 15);
		}
	}
}
