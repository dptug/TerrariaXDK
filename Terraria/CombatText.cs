using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public struct CombatText
	{
		public byte active;

		public bool crit;

		public short lifeTime;

		public float alpha;

		public float alphaDir;

		public string text;

		public Vector2 position;

		public Vector2 velocity;

		public Vector2 textSize;

		public float scale;

		public float rotation;

		public void Init()
		{
			active = 0;
		}

		public static void NewText(Vector2 pos, int w, int h, int amount, bool Crit = false)
		{
			int num = 0;
			while (true)
			{
				if (num < 32)
				{
					if (Main.combatText[num].active == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			w >>= 1;
			h >>= 1;
			int num2 = Crit ? 1 : 0;
			Main.combatText[num].text = amount.ToStringLookup();
			Vector2 vector = UI.MeasureString(UI.fontCombatText[num2], Main.combatText[num].text);
			Main.combatText[num].textSize = vector;
			Main.combatText[num].alpha = 1f;
			Main.combatText[num].alphaDir = -0.05f;
			Main.combatText[num].active = 1;
			Main.combatText[num].scale = 0f;
			Main.combatText[num].position.X = pos.X + (float)w - vector.X * 0.5f;
			Main.combatText[num].position.Y = pos.Y + (float)(h >> 1) - vector.Y * 0.5f;
			Main.combatText[num].position.X += Main.rand.Next(-w, w + 1);
			Main.combatText[num].position.Y += Main.rand.Next(-h, h + 1);
			Main.combatText[num].crit = Crit;
			if (Crit)
			{
				Main.combatText[num].lifeTime = 120;
				Main.combatText[num].velocity.Y = -14f;
				Main.combatText[num].velocity.X = (float)Main.rand.Next(-25, 26) * 0.05f;
				Main.combatText[num].rotation = ((Main.combatText[num].velocity.X < 0f) ? (-213f / (565f * (float)Math.PI)) : (213f / (565f * (float)Math.PI)));
			}
			else
			{
				Main.combatText[num].rotation = 0f;
				Main.combatText[num].velocity.Y = -7f;
				Main.combatText[num].lifeTime = 60;
			}
		}

		public void Update()
		{
			alpha += alphaDir;
			if (alpha <= 0.6f)
			{
				alphaDir = 0f - alphaDir;
			}
			else if (alpha >= 1f)
			{
				alpha = 1f;
				alphaDir = 0f - alphaDir;
			}
			velocity.Y *= 0.92f;
			if (crit)
			{
				velocity.Y *= 0.92f;
			}
			velocity.X *= 0.93f;
			position.X += velocity.X;
			position.Y += velocity.Y;
			if (--lifeTime <= 0)
			{
				scale -= 0.1f;
				if (scale < 0.1f)
				{
					active = 0;
				}
				lifeTime = 0;
				if (crit)
				{
					alphaDir = -1f;
					scale += 0.07f;
				}
				return;
			}
			if (crit)
			{
				if (velocity.X < 0f)
				{
					rotation += 0.001f;
				}
				else
				{
					rotation -= 0.001f;
				}
			}
			if (scale < 1f)
			{
				scale += 0.1f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
		}

		public static void UpdateCombatText()
		{
			for (int num = 31; num >= 0; num--)
			{
				if (Main.combatText[num].active != 0)
				{
					Main.combatText[num].Update();
				}
			}
		}
	}
}
