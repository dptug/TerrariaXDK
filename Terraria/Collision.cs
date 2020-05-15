using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public sealed class Collision
	{
		public static bool up;

		public static bool down;

		public static bool CanHit(ref Rectangle aabb1, ref Rectangle aabb2)
		{
			int num = aabb1.X + (aabb1.Width >> 1) >> 4;
			int num2 = aabb1.Y + (aabb1.Height >> 1) >> 4;
			int num3 = aabb2.X + (aabb2.Width >> 1) >> 4;
			int num4 = aabb2.Y + (aabb2.Height >> 1) >> 4;
			try
			{
				do
				{
					int num5 = Math.Abs(num - num3);
					int num6 = Math.Abs(num2 - num4);
					if (num == num3 && num2 == num4)
					{
						return true;
					}
					if (num5 > num6)
					{
						num = ((num >= num3) ? (num - 1) : (num + 1));
						if (Main.tile[num, num2 - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num, num2 - 1].type] && Main.tile[num, num2 + 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num, num2 + 1].type])
						{
							return false;
						}
					}
					else
					{
						num2 = ((num2 >= num4) ? (num2 - 1) : (num2 + 1));
						if (Main.tile[num - 1, num2].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num - 1, num2].type] && Main.tile[num + 1, num2].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num + 1, num2].type])
						{
							return false;
						}
					}
				}
				while (Main.tile[num, num2].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num, num2].type]);
				return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool AnyPlayerOrNPC(int i, int j, int h)
		{
			Rectangle rectangle = default(Rectangle);
			rectangle.X = i * 16;
			rectangle.Y = j * 16;
			rectangle.Width = 16;
			rectangle.Height = h * 16;
			for (int num = 7; num >= 0; num--)
			{
				if (Main.player[num].active != 0 && rectangle.Intersects(Main.player[num].aabb))
				{
					return true;
				}
			}
			for (int num2 = 195; num2 >= 0; num2--)
			{
				if (Main.npc[num2].active != 0 && rectangle.Intersects(Main.npc[num2].aabb))
				{
					return true;
				}
			}
			return false;
		}

		public unsafe static bool DrownCollision(ref Vector2 Position, int Width, int Height, int gravDir)
		{
			Vector2 vector = Position;
			int num = 10;
			int num2 = 12;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector.X += Width >> 1;
			vector.X -= num >> 1;
			vector.Y -= 2f;
			if (gravDir == -1)
			{
				vector.Y += (Height >> 1) - 6;
			}
			int num3 = ((int)Position.X >> 4) - 1;
			int num4 = ((int)Position.X + Width >> 4) + 2;
			int num5 = ((int)Position.Y >> 4) - 1;
			int num6 = ((int)Position.Y + Height >> 4) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num3; i < num4; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num5);
					int num7 = num5;
					while (num7 < num6)
					{
						int liquid = ptr2->liquid;
						if (liquid > 0)
						{
							int num8 = i << 4;
							float num9 = num7 << 4;
							float num10 = 256 - liquid;
							num10 *= 0.0625f;
							num9 += num10;
							int num11 = 16 - (int)num10;
							if (vector.X + (float)num > (float)num8 && vector.X < (float)(num8 + 16) && vector.Y + (float)num2 > num9 && vector.Y < num9 + (float)num11)
							{
								return true;
							}
						}
						num7++;
						ptr2++;
					}
				}
			}
			return false;
		}

		public unsafe static bool WetCollision(ref Vector2 Position, int Width, int Height)
		{
			Vector2 vector = new Vector2(Position.X + (float)(Width >> 1), Position.Y + (float)(Height >> 1));
			int num = 10;
			int num2 = Height >> 1;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector.X -= num >> 1;
			vector.Y -= num2 >> 1;
			int num3 = ((int)Position.X >> 4) - 1;
			int num4 = ((int)Position.X + Width >> 4) + 2;
			int num5 = ((int)Position.Y >> 4) - 1;
			int num6 = ((int)Position.Y + Height >> 4) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num3; i < num4; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num5);
					int num7 = num5;
					while (num7 < num6)
					{
						int liquid = ptr2->liquid;
						if (liquid > 0)
						{
							int num8 = i << 4;
							float num9 = num7 << 4;
							int num10 = 16;
							float num11 = 256 - liquid;
							num11 *= 0.0625f;
							num9 += num11;
							num10 -= (int)num11;
							if (vector.X + (float)num > (float)num8 && vector.X < (float)(num8 + 16) && vector.Y + (float)num2 > num9 && vector.Y < num9 + (float)num10)
							{
								return true;
							}
						}
						num7++;
						ptr2++;
					}
				}
			}
			return false;
		}

		public unsafe static bool LavaCollision(ref Vector2 Position, int Width, int Height)
		{
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 2;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				Vector2 vector = default(Vector2);
				for (int i = num; i < num2; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						int liquid = ptr2->liquid;
						if (liquid > 0 && ptr2->lava != 0)
						{
							vector.X = i * 16;
							vector.Y = num5 * 16;
							int num6 = 16;
							float num7 = 256 - liquid;
							num7 *= 0.0625f;
							vector.Y += num7;
							num6 -= (int)num7;
							if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num6)
							{
								return true;
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
			return false;
		}

		public unsafe static void TileCollision(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false)
		{
			up = false;
			down = false;
			Vector2 vector = Velocity;
			float num = Position.X + (float)Width;
			float num2 = Position.Y + (float)Height;
			float num3 = Position.X + Velocity.X;
			float num4 = Position.Y + Velocity.Y;
			float num5 = num3 + (float)Width;
			float num6 = num4 + (float)Height;
			int num7 = ((int)Position.X >> 4) - 1;
			int num8 = ((int)num >> 4) + 2;
			int num9 = ((int)Position.Y >> 4) - 1;
			int num10 = ((int)num2 >> 4) + 2;
			int num11 = -1;
			int num12 = -1;
			int num13 = -1;
			int num14 = -1;
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesX)
			{
				num8 = Main.maxTilesX;
			}
			if (num9 < 0)
			{
				num9 = 0;
			}
			if (num10 > Main.maxTilesY)
			{
				num10 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num7; i < num8; i++)
				{
					int num15 = i << 4;
					if (num5 > (float)num15 && num3 < (float)(num15 + 16))
					{
						Tile* ptr2 = ptr + (i * 1440 + num9);
						int num16 = num9;
						while (num16 < num10)
						{
							if (ptr2->active != 0)
							{
								int type = ptr2->type;
								bool flag = Main.tileSolidTop[type];
								if ((flag && ptr2->frameY == 0) || Main.tileSolid[type])
								{
									int num17 = num16 << 4;
									if (num6 > (float)num17 && num4 < (float)(num17 + 16))
									{
										if (num2 <= (float)num17)
										{
											down = true;
											if (!flag || !fallThrough || (!(vector.Y <= 1f) && !fall2))
											{
												num13 = i;
												num14 = num16;
												if (num13 != num11)
												{
													Velocity.Y = (float)num17 - num2;
												}
											}
										}
										else if (!flag)
										{
											if (num <= (float)num15)
											{
												num11 = i;
												num12 = num16;
												if (num12 != num14)
												{
													Velocity.X = (float)num15 - num;
												}
												if (num13 == num11)
												{
													Velocity.Y = vector.Y;
												}
											}
											else if (Position.X >= (float)(num15 + 16))
											{
												num11 = i;
												num12 = num16;
												if (num12 != num14)
												{
													Velocity.X = (float)(num15 + 16) - Position.X;
												}
												if (num13 == num11)
												{
													Velocity.Y = vector.Y;
												}
											}
											else if (Position.Y >= (float)(num17 + 16))
											{
												up = true;
												num13 = i;
												num14 = num16;
												Velocity.Y = (float)(num17 + 16) - Position.Y;
												if (num14 == num12)
												{
													Velocity.X = vector.X;
												}
											}
										}
									}
								}
							}
							num16++;
							ptr2++;
						}
					}
				}
			}
		}

		public unsafe static bool SolidCollision(ref Vector2 Position, int Width, int Height)
		{
			float num = Position.X + (float)Width;
			float num2 = Position.Y + (float)Height;
			int num3 = ((int)Position.X >> 4) - 1;
			int num4 = ((int)num >> 4) + 2;
			int num5 = ((int)Position.Y >> 4) - 1;
			int num6 = ((int)num2 >> 4) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num3; i < num4; i++)
				{
					if (num > (float)(i << 4) && Position.X < (float)(i + 1 << 4))
					{
						Tile* ptr2 = ptr + (i * 1440 + num5);
						int num7 = num5;
						while (num7 < num6)
						{
							if (ptr2->active != 0 && num2 > (float)(num7 << 4) && Position.Y < (float)(num7 + 1 << 4) && Main.tileSolidNotSolidTop[ptr2->type])
							{
								return true;
							}
							num7++;
							ptr2++;
						}
					}
				}
			}
			return false;
		}

		public unsafe static Vector2 WaterCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false)
		{
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			Vector2 vector2 = Position;
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 2;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				Vector2 vector3 = default(Vector2);
				for (int i = num; i < num2; i++)
				{
					vector3.X = i * 16;
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						int liquid = ptr2->liquid;
						if (liquid > 0)
						{
							int num6 = liquid + 16 >> 5 << 1;
							vector3.Y = num5 * 16 + 16 - num6;
							if (vector.X + (float)Width > vector3.X && vector.X < vector3.X + 16f && vector.Y + (float)Height > vector3.Y && vector.Y < vector3.Y + (float)num6 && vector2.Y + (float)Height <= vector3.Y && !fallThrough)
							{
								result.Y = vector3.Y - (vector2.Y + (float)Height);
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
			return result;
		}

		public unsafe static void AnyCollision(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position + Velocity;
			Vector2 vector2 = Position;
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 2;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 2;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num; i < num2; i++)
				{
					double num9 = i << 4;
					if ((double)(vector.X + (float)Width) > num9 && (double)vector.X < num9 + 16.0)
					{
						Tile* ptr2 = ptr + (i * 1440 + num3);
						int num10 = num3;
						while (num10 < num4)
						{
							if (ptr2->active != 0)
							{
								double num11 = num10 << 4;
								if ((double)(vector.Y + (float)Height) > num11 && (double)vector.Y < num11 + 16.0)
								{
									if ((double)(vector2.Y + (float)Height) <= num11)
									{
										num7 = i;
										num8 = num10;
										if (num7 != num5)
										{
											Velocity.Y = (float)(num11 - (double)(vector2.Y + (float)Height));
										}
									}
									else if (!Main.tileSolidTop[ptr2->type])
									{
										if ((double)(vector2.X + (float)Width) <= num9)
										{
											num5 = i;
											num6 = num10;
											if (num6 != num8)
											{
												Velocity.X = (float)(num9 - (double)(vector2.X + (float)Width));
											}
										}
										else if ((double)vector2.X >= num9 + 16.0)
										{
											num5 = i;
											num6 = num10;
											if (num6 != num8)
											{
												Velocity.X = (float)(num9 + 16.0 - (double)vector2.X);
											}
										}
										else if ((double)vector2.Y >= num11 + 16.0)
										{
											num7 = i;
											num8 = num10;
											Velocity.Y = (float)(num11 + 16.0 - (double)vector2.Y + 0.01);
											if (num8 == num6)
											{
												Velocity.X += 0.01f;
											}
										}
									}
								}
							}
							num10++;
							ptr2++;
						}
					}
				}
			}
		}

		public unsafe static void HitTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position + Velocity;
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 1;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num; i < num2; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						if (ptr2->canStandOnTop())
						{
							double num6 = i << 4;
							double num7 = num5 << 4;
							if ((double)(vector.X + (float)Width) >= num6 && (double)vector.X <= num6 + 16.0 && (double)(vector.Y + (float)Height) >= num7 && (double)vector.Y <= num7 + 16.0)
							{
								WorldGen.KillTile(i, num5, fail: true, effectOnly: true);
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
		}

		public unsafe static int HurtTiles(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height, bool fireImmune = false)
		{
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 1;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num; i < num2; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						if (ptr2->active != 0)
						{
							int type = ptr2->type;
							if (type == 32 || type == 37 || type == 48 || type == 53 || type == 57 || type == 58 || type == 69 || type == 76 || type == 112 || type == 116 || type == 123)
							{
								double num6 = i << 4;
								double num7 = num5 << 4;
								int result = 0;
								switch (type)
								{
								case 32:
								case 69:
								case 80:
									if ((double)(Position.X + (float)Width) > num6 && (double)Position.X < num6 + 16.0 && (double)(Position.Y + (float)Height) > num7 && (double)Position.Y < num7 + 16.01)
									{
										result = 10;
										switch (type)
										{
										case 69:
											result = 17;
											break;
										case 80:
											result = 6;
											break;
										}
										if ((type == 32 || type == 69) && WorldGen.KillTile(i, num5))
										{
											NetMessage.CreateMessage5(17, 4, i, num5, 0);
											NetMessage.SendMessage();
										}
										return result;
									}
									break;
								case 53:
								case 112:
								case 116:
								case 123:
									if ((double)(Position.X + (float)Width - 2f) >= num6 && (double)(Position.X + 2f) <= num6 + 16.0 && (double)(Position.Y + (float)Height - 2f) >= num7 && (double)(Position.Y + 2f) <= num7 + 16.0)
									{
										return 20;
									}
									break;
								default:
									if ((double)(Position.X + (float)Width) >= num6 && (double)Position.X <= num6 + 16.0 && (double)(Position.Y + (float)Height) >= num7 && (double)Position.Y <= num7 + 16.01)
									{
										if (type == 48)
										{
											result = 40;
										}
										else if (!fireImmune && (type == 37 || type == 58 || type == 76))
										{
											result = 20;
										}
										return result;
									}
									break;
								}
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
			return 0;
		}

		public unsafe static bool SwitchTiles(Vector2 Position, int Width, int Height, Vector2 oldPosition)
		{
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 1;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num; i < num2; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						if (ptr2->type == 135 && ptr2->active != 0)
						{
							double num6 = i * 16;
							double num7 = num5 * 16 + 12;
							if ((double)(Position.X + (float)Width) > num6 && (double)Position.X < num6 + 16.0 && (double)(Position.Y + (float)Height) > num7 && (double)Position.Y < num7 + 4.01 && (!((double)(oldPosition.X + (float)Width) > num6) || !((double)oldPosition.X < num6 + 16.0) || !((double)(oldPosition.Y + (float)Height) > num7) || !((double)oldPosition.Y < num7 + 16.01)))
							{
								WorldGen.hitSwitch(i, num5);
								NetMessage.CreateMessage2(59, i, num5);
								NetMessage.SendMessage();
								return true;
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
			return false;
		}

		public unsafe static Vector2i StickyTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position;
			int num = ((int)Position.X >> 4) - 1;
			int num2 = ((int)Position.X + Width >> 4) + 2;
			int num3 = ((int)Position.Y >> 4) - 1;
			int num4 = ((int)Position.Y + Height >> 4) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = num; i < num2; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + num3);
					int num5 = num3;
					while (num5 < num4)
					{
						if (ptr2->type == 51 && ptr2->active != 0)
						{
							double num6 = i * 16;
							double num7 = num5 * 16;
							if ((double)(vector.X + (float)Width) > num6 && (double)vector.X < num6 + 16.0 && (double)(vector.Y + (float)Height) > num7 && (double)vector.Y < num7 + 16.01)
							{
								if (Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) > 0.7f && Main.rand.Next(30) == 0)
								{
									Main.dust.NewDust(i * 16, num5 * 16, 16, 16, 30);
								}
								return new Vector2i(i, num5);
							}
						}
						num5++;
						ptr2++;
					}
				}
			}
			return new Vector2i(-1, -1);
		}

		public unsafe static bool SolidTiles(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return true;
			}
			if (endX >= Main.maxTilesX)
			{
				return true;
			}
			if (startY < 0)
			{
				return true;
			}
			if (endY >= Main.maxTilesY)
			{
				return true;
			}
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = startX; i < endX + 1; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + startY);
					int num = startY;
					while (num < endY + 1)
					{
						if (ptr2->active != 0 && Main.tileSolidNotSolidTop[ptr2->type])
						{
							return true;
						}
						num++;
						ptr2++;
					}
				}
			}
			return false;
		}

		public static bool LineIntersection(ref Vector2 a1, ref Vector2 a2, Vector2 b1, Vector2 b2, ref Vector2 intersection)
		{
			Vector2 value = a2 - a1;
			Vector2 vector = b2 - b1;
			float num = value.X * vector.Y - value.Y * vector.X;
			if (num == 0f)
			{
				return false;
			}
			Vector2 vector2 = b1 - a1;
			float num2 = (vector2.X * vector.Y - vector2.Y * vector.X) / num;
			if (num2 < 0f || num2 > 1f)
			{
				return false;
			}
			float num3 = (vector2.X * value.Y - vector2.Y * value.X) / num;
			if (num3 < 0f || num3 > 1f)
			{
				return false;
			}
			intersection = a1 + num2 * value;
			return true;
		}
	}
}
