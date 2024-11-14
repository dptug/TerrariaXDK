using Microsoft.Xna.Framework;

namespace Terraria;

public struct DustPool
{
	public WorldView view;

	public short snowDust;

	public short lavaBubbles;

	public short nextDust;

	public short size;

	public Dust[] dust;

	public DustPool(WorldView v, int sizePower2)
	{
		view = v;
		snowDust = 0;
		lavaBubbles = 0;
		nextDust = 0;
		size = (short)sizePower2;
		dust = new Dust[sizePower2];
	}

	public void Init()
	{
		for (int num = size - 1; num >= 0; num--)
		{
			dust[num].Init();
		}
	}

	private bool ClipDust(int x, int y)
	{
		if (view == null)
		{
			return !WorldView.AnyViewContains(x, y);
		}
		return !view.clipArea.Contains(x, y);
	}

	public unsafe Dust* NewDust(int Type, ref Rectangle r, double SpeedX = 0.0, double SpeedY = 0.0, int Alpha = 0, Color newColor = default(Color), double Scale = 1.0)
	{
		return NewDust(r.X, r.Y, r.Width, r.Height, Type, SpeedX, SpeedY, Alpha, newColor, Scale);
	}

	public unsafe Dust* NewDust(int X, int Y, int Width, int Height, int Type, double SpeedX = 0.0, double SpeedY = 0.0, int Alpha = 0, Color newColor = default(Color), double Scale = 1.0)
	{
		if (ClipDust(X, Y))
		{
			return null;
		}
		int num = nextDust;
		int num2 = size - 1;
		for (int i = 0; i <= num2; i++)
		{
			int num3 = num & num2;
			fixed (Dust* ptr = &dust[num3])
			{
				if (ptr->active == 0)
				{
					ptr->active = 1;
					ptr->noGravity = false;
					ptr->noLight = false;
					ptr->type = (ushort)Type;
					ptr->color = newColor;
					ptr->alpha = (short)Alpha;
					ptr->fadeIn = 0f;
					ptr->rotation = 0f;
					ptr->scale = (float)(Scale + (double)Main.rand.Next(-20, 21) * 0.01 * Scale);
					ptr->frame.X = 10 * Type;
					ptr->frame.Y = 10 * Main.rand.Next(3);
					ptr->frame.Width = 8;
					ptr->frame.Height = 8;
					int num4 = Width;
					int num5 = Height;
					if (num4 < 5)
					{
						num4 = 5;
					}
					if (num5 < 5)
					{
						num5 = 5;
					}
					ptr->position.X = X + Main.rand.Next(num4 - 4) + 4;
					ptr->position.Y = Y + Main.rand.Next(num5 - 4) + 4;
					switch (Type)
					{
					case 6:
					case 29:
					case 59:
					case 60:
					case 61:
					case 62:
					case 63:
					case 64:
					case 65:
					case 75:
						ptr->velocity.X = (float)(((double)Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.3);
						ptr->velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
						ptr->scale *= 0.7f;
						break;
					default:
						switch (Type)
						{
						case 33:
						case 52:
							ptr->alpha = 170;
							ptr->velocity.X = (float)(((double)Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.5);
							ptr->velocity.Y = (float)(((double)Main.rand.Next(-20, 21) * 0.1 + SpeedY) * 0.5 + 1.0);
							break;
						case 41:
							ptr->velocity.X = 0f;
							ptr->velocity.Y = 0f;
							break;
						case 34:
							ptr->position.Y -= 8f;
							if (!Collision.WetCollision(ref ptr->position, 4, 4))
							{
								ptr->active = 0;
								nextDust = (short)num3;
								return ptr;
							}
							ptr->position.Y += 8f;
							ptr->velocity.X = (float)(((double)Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.1);
							ptr->velocity.Y = -0.5f;
							break;
						case 35:
							ptr->velocity.X = (float)(((double)Main.rand.Next(-20, 21) * 0.1 + SpeedX) * 0.1);
							ptr->velocity.Y = -0.5f;
							break;
						default:
							ptr->velocity.X = (float)((double)Main.rand.Next(-20, 21) * 0.1 + SpeedX);
							ptr->velocity.Y = (float)((double)Main.rand.Next(-20, 21) * 0.1 + SpeedY);
							break;
						}
						break;
					}
					nextDust = (short)(num3 + 1);
					return ptr;
				}
			}
			num++;
		}
		return null;
	}

	public unsafe void UpdateDust()
	{
		lavaBubbles = 0;
		snowDust = 0;
		Vector3 rgb = default(Vector3);
		fixed (Dust* ptr = dust)
		{
			Dust* ptr2 = ptr;
			for (int num = size - 1; num >= 0; ptr2++, num--)
			{
				if (ptr2->active == 0)
				{
					continue;
				}
				int type = ptr2->type;
				float num2 = ptr2->scale;
				ptr2->position.X += ptr2->velocity.X;
				ptr2->position.Y += ptr2->velocity.Y;
				int num3 = (int)ptr2->position.X;
				int num4 = (int)ptr2->position.Y;
				switch (type)
				{
				case 6:
				case 29:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
				case 64:
				case 65:
				case 75:
					if (!ptr2->noLight)
					{
						if (ClipDust(num3, num4))
						{
							ptr2->active = 0;
							continue;
						}
						num2 *= 1.4f;
						switch (type)
						{
						case 6:
							if (num2 > 0.6f)
							{
								num2 = 0.6f;
							}
							rgb.X = num2;
							rgb.Y = num2 * 0.65f;
							rgb.Z = num2 * 0.4f;
							break;
						case 29:
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb.X = num2 * 0.1f;
							rgb.Y = num2 * 0.4f;
							rgb.Z = num2;
							break;
						case 59:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = 0f;
							rgb.Y = num2 * 0.1f;
							rgb.Z = num2 * 1.3f;
							break;
						case 60:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = num2;
							rgb.Y = (rgb.Z = num2 * 0.1f);
							break;
						case 61:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = 0f;
							rgb.Y = num2;
							rgb.Z = num2 * 0.1f;
							break;
						case 62:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = (rgb.Z = num2 * 0.9f);
							rgb.Y = 0f;
							break;
						default:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = (rgb.Y = (rgb.Z = num2 * 1.3f));
							break;
						case 64:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = (rgb.Y = num2 * 0.9f);
							rgb.Z = 0f;
							break;
						case 65:
							if (num2 > 0.8f)
							{
								num2 = 0.8f;
							}
							rgb.X = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
							rgb.Y = 0.3f;
							rgb.Z = Main.demonTorch + 0.5f * (1f - Main.demonTorch);
							break;
						case 75:
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb.X = num2 * 0.7f;
							rgb.Y = num2;
							rgb.Z = num2 * 0.2f;
							break;
						}
						Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
					}
					if (!ptr2->noGravity)
					{
						ptr2->velocity.Y += 0.05f;
					}
					break;
				default:
					switch (type)
					{
					case 14:
					case 16:
					case 46:
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						break;
					case 31:
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						if (ptr2->noGravity)
						{
							ptr2->alpha += 4;
							if (ptr2->alpha > 255)
							{
								ptr2->active = 0;
								continue;
							}
							ptr2->velocity.X *= 1.02f;
							ptr2->velocity.Y *= 1.02f;
							ptr2->scale += 0.02f;
						}
						break;
					case 32:
						ptr2->scale -= 0.01f;
						ptr2->velocity.X *= 0.96f;
						ptr2->velocity.Y += 0.1f;
						break;
					case 43:
						ptr2->rotation += 0.1f * ptr2->scale;
						if (num2 > 0.048f)
						{
							rgb.X = (rgb.Y = (rgb.Z = num2 * 1.0105556f));
							Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
							if (ptr2->alpha < 255)
							{
								ptr2->scale += 0.09f;
								if (ptr2->scale >= 1f)
								{
									ptr2->scale = 1f;
									ptr2->alpha = 255;
								}
							}
							else if (ptr2->scale < 0.5f)
							{
								ptr2->scale -= 0.02f;
							}
							else if (ptr2->scale < 0.8f)
							{
								ptr2->scale -= 0.01f;
							}
							break;
						}
						ptr2->active = 0;
						continue;
					case 15:
					case 57:
					case 58:
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						if (type != 15)
						{
							num2 *= 0.8f;
						}
						if (ptr2->noLight)
						{
							ptr2->velocity.X *= 0.95f;
							ptr2->velocity.Y *= 0.95f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						switch (type)
						{
						case 15:
							Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.45f, num2 * 0.55f, num2));
							break;
						case 57:
							Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.95f, num2 * 0.95f, num2 * 0.45f));
							break;
						case 58:
							Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2, num2 * 0.55f, num2 * 0.75f));
							break;
						}
						break;
					case 66:
						if (ptr2->velocity.X < 0f)
						{
							ptr2->rotation -= 1f;
						}
						else
						{
							ptr2->rotation += 1f;
						}
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						ptr2->scale += 0.02f;
						num2 *= 0.0031372549f;
						if (num2 > 0.003921569f)
						{
							num2 = 0.003921569f;
						}
						rgb.X = num2 * (float)(int)ptr2->color.R;
						rgb.Y = num2 * (float)(int)ptr2->color.G;
						rgb.Z = num2 * (float)(int)ptr2->color.B;
						Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
						break;
					case 20:
					case 21:
						ptr2->scale += 0.005f;
						ptr2->velocity.X *= 0.94f;
						ptr2->velocity.Y *= 0.94f;
						if (type == 21)
						{
							num2 *= 0.4f;
							rgb.X = num2 * 0.8f;
							rgb.Y = num2 * 0.3f;
						}
						else
						{
							num2 *= 0.8f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb.X = num2 * 0.3f;
							rgb.Y = num2 * 0.6f;
						}
						rgb.Z = num2;
						Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
						break;
					case 27:
					case 45:
						ptr2->velocity.X *= 0.94f;
						ptr2->velocity.Y *= 0.94f;
						ptr2->scale += 0.002f;
						if (ptr2->noLight)
						{
							num2 *= 0.1f;
							ptr2->scale -= 0.06f;
							if (ptr2->scale < 1f)
							{
								ptr2->scale -= 0.06f;
							}
							if (view != null)
							{
								if (view.player.wet)
								{
									ptr2->position.X += view.player.velocity.X * 0.5f;
									ptr2->position.Y += view.player.velocity.Y * 0.5f;
								}
								else
								{
									ptr2->position.X += view.player.velocity.X;
									ptr2->position.Y += view.player.velocity.Y;
								}
							}
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						Lighting.addLight((int)ptr2->position.X >> 4, (int)ptr2->position.Y >> 4, new Vector3(num2 * 0.6f, num2 * 0.2f, num2));
						break;
					case 55:
					case 56:
					case 73:
					case 74:
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						switch (type)
						{
						case 55:
							num2 *= 0.8f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb = new Vector3(num2, num2, num2 * 0.6f);
							break;
						case 73:
							num2 *= 0.8f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb = new Vector3(num2, num2 * 0.35f, num2 * 0.5f);
							break;
						case 74:
							num2 *= 0.8f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb = new Vector3(num2 * 0.35f, num2, num2 * 0.5f);
							break;
						default:
							num2 *= 1.2f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb = new Vector3(num2 * 0.35f, num2 * 0.5f, num2);
							break;
						}
						Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
						break;
					case 71:
					case 72:
						ptr2->velocity.X *= 0.98f;
						ptr2->velocity.Y *= 0.98f;
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.2f, 0f, num2 * 0.1f));
						break;
					case 76:
						snowDust++;
						ptr2->scale += 0.009f;
						if (view != null)
						{
							if (Collision.SolidCollision(ref ptr2->position, 1, 1))
							{
								ptr2->active = 0;
								continue;
							}
							ptr2->position.X += view.player.velocity.X * 0.2f;
							ptr2->position.Y += view.player.velocity.Y * 0.2f;
						}
						break;
					default:
						if (!ptr2->noGravity)
						{
							if (type != 41 && type != 44)
							{
								ptr2->velocity.Y += 0.1f;
							}
						}
						else if (type == 5)
						{
							ptr2->scale -= 0.04f;
						}
						break;
					}
					break;
				}
				if (type == 33 || type == 52)
				{
					if (ptr2->velocity.X == 0f)
					{
						if (Collision.SolidCollision(ref ptr2->position, 2, 2))
						{
							ptr2->active = 0;
							continue;
						}
						ptr2->rotation += 0.5f;
						ptr2->scale -= 0.01f;
					}
					if (Collision.WetCollision(ref ptr2->position, 4, 4))
					{
						ptr2->scale -= 0.105f;
						ptr2->alpha += 22;
					}
					else
					{
						ptr2->scale -= 0.005f;
						ptr2->alpha += 2;
					}
					if (ptr2->alpha > 255)
					{
						ptr2->active = 0;
						continue;
					}
					ptr2->velocity.X *= 0.93f;
					if (ptr2->velocity.Y > 4f)
					{
						ptr2->velocity.Y = 4f;
					}
					if (ptr2->noGravity)
					{
						if (ptr2->velocity.X < 0f)
						{
							ptr2->rotation -= 0.2f;
						}
						else
						{
							ptr2->rotation += 0.2f;
						}
						ptr2->scale += 0.03f;
						ptr2->velocity.X *= 1.05f;
						ptr2->velocity.Y += 0.15f;
					}
				}
				else if (type == 67)
				{
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(0f, num2 * 0.8f, num2));
				}
				else if (type == 34 || type == 35)
				{
					if (type == 35)
					{
						lavaBubbles++;
						if (ptr2->noGravity)
						{
							ptr2->scale += 0.03f;
							if (ptr2->scale < 1f)
							{
								ptr2->velocity.Y += 0.075f;
							}
							ptr2->velocity.X *= 1.08f;
							if (ptr2->velocity.X > 0f)
							{
								ptr2->rotation += 0.01f;
							}
							else
							{
								ptr2->rotation -= 0.01f;
							}
							ptr2->velocity.X *= 0.99f;
							num2 = num2 * 0.6f + 0.018f;
							if (num2 > 1f)
							{
								num2 = 1f;
							}
							rgb.X = num2;
							rgb.Y = num2 * 0.3f;
							rgb.Z = num2 * 0.1f;
							Lighting.addLight(num3 >> 4, (num4 >> 4) + 1, rgb);
							goto IL_152a;
						}
						num2 = num2 * 0.3f + 0.4f;
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						rgb.X = num2;
						rgb.Y = num2 * 0.5f;
						rgb.Z = num2 * 0.3f;
						Lighting.addLight(num3 >> 4, num4 >> 4, rgb);
						ptr2->scale -= 0.01f;
						ptr2->velocity.Y = -0.2f;
						ptr2->alpha += (short)Main.rand.Next(2);
					}
					else
					{
						ptr2->scale += 0.005f;
						ptr2->velocity.Y = -0.5f;
					}
					if (++ptr2->alpha > 255)
					{
						ptr2->active = 0;
						continue;
					}
					ptr2->position.Y -= 8f;
					if (!Collision.WetCollision(ref ptr2->position, 4, 4))
					{
						ptr2->active = 0;
						continue;
					}
					ptr2->position.Y += 8f;
					ptr2->velocity.X += (float)Main.rand.Next(-10, 10) * 0.002f;
					if (ptr2->velocity.X < -0.25f)
					{
						ptr2->velocity.X = -0.25f;
					}
					else if (ptr2->velocity.X > 0.25f)
					{
						ptr2->velocity.X = 0.25f;
					}
				}
				else
				{
					switch (type)
					{
					case 68:
						num2 *= 0.3f;
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.1f, num2 * 0.2f, num2));
						break;
					case 70:
						num2 *= 0.3f;
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.5f, 0f, num2));
						break;
					}
				}
				switch (type)
				{
				case 41:
					ptr2->velocity.X += (float)Main.rand.Next(-10, 11) * 0.01f;
					ptr2->velocity.Y += (float)Main.rand.Next(-10, 11) * 0.01f;
					if (ptr2->velocity.X > 0.75f)
					{
						ptr2->velocity.X = 0.75f;
					}
					else if (ptr2->velocity.X < -0.75f)
					{
						ptr2->velocity.X = -0.75f;
					}
					if (ptr2->velocity.Y > 0.75f)
					{
						ptr2->velocity.Y = 0.75f;
					}
					else if (ptr2->velocity.Y < -0.75f)
					{
						ptr2->velocity.Y = -0.75f;
					}
					ptr2->scale += 0.007f;
					num2 = num2 * 0.7f + 0.0049f;
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.4f, num2 * 0.9f, num2));
					break;
				case 44:
					ptr2->velocity.X += (float)Main.rand.Next(-10, 11) * 0.003f;
					ptr2->velocity.Y += (float)Main.rand.Next(-10, 11) * 0.003f;
					if (ptr2->velocity.X > 0.35f)
					{
						ptr2->velocity.X = 0.35f;
					}
					else if (ptr2->velocity.X < -0.35f)
					{
						ptr2->velocity.X = -0.35f;
					}
					if (ptr2->velocity.Y > 0.35f)
					{
						ptr2->velocity.Y = 0.35f;
					}
					else if (ptr2->velocity.Y < -0.35f)
					{
						ptr2->velocity.Y = -0.35f;
					}
					ptr2->scale += 0.0085f;
					num2 = num2 * 0.7f + 0.00595f;
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					Lighting.addLight(num3 >> 4, num4 >> 4, new Vector3(num2 * 0.7f, num2, num2 * 0.8f));
					break;
				default:
					ptr2->velocity.X *= 0.99f;
					break;
				}
				goto IL_152a;
				IL_152a:
				if (ptr2->fadeIn > 0f)
				{
					if (type == 46)
					{
						ptr2->scale += 0.1f;
					}
					else
					{
						ptr2->scale += 0.03f;
					}
					if (ptr2->scale > ptr2->fadeIn)
					{
						ptr2->fadeIn = 0f;
					}
				}
				else
				{
					ptr2->scale -= 0.01f;
				}
				if (ptr2->noGravity)
				{
					ptr2->velocity.X *= 0.92f;
					ptr2->velocity.Y *= 0.92f;
					if (ptr2->fadeIn == 0f)
					{
						ptr2->scale -= 0.04f;
					}
				}
				if (ptr2->scale < 0.1f)
				{
					ptr2->active = 0;
				}
				else if (type != 79)
				{
					ptr2->rotation += ptr2->velocity.X * 0.5f;
				}
			}
		}
	}

	public unsafe void DrawDust(WorldView drawView)
	{
		fixed (Dust* ptr = dust)
		{
			Dust* ptr2 = ptr;
			Vector2 pivot = new Vector2(4f, 4f);
			Vector2 pos = default(Vector2);
			for (int num = size - 1; num >= 0; num--)
			{
				if (ptr2->active != 0)
				{
					int num2 = (int)ptr2->position.X;
					int num3 = (int)ptr2->position.Y;
					if (view != null || drawView.clipArea.Contains(num2, num3))
					{
						Color newColor = ((!ptr2->noLight && ptr2->type != 6 && ptr2->type != 15 && (ptr2->type < 59 || ptr2->type > 64)) ? drawView.lighting.GetColor(num2 + 4 >> 4, num3 + 4 >> 4) : Color.White);
						ptr2->GetAlpha(ref newColor);
						if (newColor.PackedValue == 0)
						{
							ptr2->active = 0;
						}
						else
						{
							pos.X = num2 - drawView.screenPosition.X;
							pos.Y = num3 - drawView.screenPosition.Y;
							SpriteSheet<_sheetSprites>.Draw(218, ref pos, ref ptr2->frame, newColor, ptr2->rotation, ref pivot, ptr2->scale);
							if (ptr2->color.PackedValue != 0)
							{
								ptr2->GetColor(ref newColor);
								SpriteSheet<_sheetSprites>.Draw(218, ref pos, ref ptr2->frame, newColor, ptr2->rotation, ref pivot, ptr2->scale);
							}
						}
					}
				}
				ptr2++;
			}
		}
	}
}
