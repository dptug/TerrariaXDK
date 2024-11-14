using Microsoft.Xna.Framework;

namespace Terraria;

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
		for (int i = 0; i < 32; i++)
		{
			if (Main.combatText[i].active == 0)
			{
				w >>= 1;
				h >>= 1;
				int num = (Crit ? 1 : 0);
				Main.combatText[i].text = amount.ToStringLookup();
				Vector2 vector = UI.MeasureString(UI.fontCombatText[num], Main.combatText[i].text);
				Main.combatText[i].textSize = vector;
				Main.combatText[i].alpha = 1f;
				Main.combatText[i].alphaDir = -0.05f;
				Main.combatText[i].active = 1;
				Main.combatText[i].scale = 0f;
				Main.combatText[i].position.X = pos.X + (float)w - vector.X * 0.5f;
				Main.combatText[i].position.Y = pos.Y + (float)(h >> 1) - vector.Y * 0.5f;
				Main.combatText[i].position.X += Main.rand.Next(-w, w + 1);
				Main.combatText[i].position.Y += Main.rand.Next(-h, h + 1);
				Main.combatText[i].crit = Crit;
				if (Crit)
				{
					Main.combatText[i].lifeTime = 120;
					Main.combatText[i].velocity.Y = -14f;
					Main.combatText[i].velocity.X = (float)Main.rand.Next(-25, 26) * 0.05f;
					Main.combatText[i].rotation = ((Main.combatText[i].velocity.X < 0f) ? (-0.120000005f) : 0.120000005f);
				}
				else
				{
					Main.combatText[i].rotation = 0f;
					Main.combatText[i].velocity.Y = -7f;
					Main.combatText[i].lifeTime = 60;
				}
				break;
			}
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
