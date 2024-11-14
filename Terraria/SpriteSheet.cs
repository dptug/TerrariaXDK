using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria;

public class SpriteSheet<T>
{
	protected static Texture2D tex;

	public static Rectangle[] src;

	public static void Draw(int id, int x, int y, int sy, int sh, Color c, float rotCenter, float scaleCenter)
	{
		Rectangle value = src[id];
		value.Y += sy;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)value, c, rotCenter, new Vector2(value.Width >> 1, sh >> 1), scaleCenter, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, int x, int y, int sx, int sw, int sh, Color c)
	{
		Rectangle value = src[id];
		value.X += sx;
		value.Width = sw;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)value, c);
	}

	public static void Draw(int id, ref Vector2 pos, int sy, int sh, Color c, SpriteEffects e)
	{
		Rectangle value = src[id];
		value.Y += sy;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, 0f, default(Vector2), 1f, e, 0f);
	}

	public static void DrawRotated(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, SpriteEffects e)
	{
		Rectangle value = src[id];
		value.Y += sy;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, rot, new Vector2(value.Width >> 1, sh >> 1), 1f, e, 0f);
	}

	public static void DrawRotated(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, ref Vector2 pivot, SpriteEffects e)
	{
		Rectangle value = src[id];
		value.Y += sy;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, rot, pivot, 1f, e, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, ref Vector2 pivot, float scale, SpriteEffects e)
	{
		Rectangle value = src[id];
		value.Y += sy;
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, rot, pivot, scale, e, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c, float rot, ref Vector2 pivot, float scale, SpriteEffects e)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, rot, pivot, scale, e, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c);
	}

	public static void Draw(int id, ref Vector2 pos, ref Rectangle s, Color c)
	{
		Rectangle value = src[id];
		value.X += s.X;
		value.Y += s.Y;
		value.Width = s.Width;
		value.Height = s.Height;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c);
	}

	public static void DrawStretched(int id, Rectangle s, ref Rectangle dest, Color c)
	{
		s.X += src[id].X;
		s.Y += src[id].Y;
		Main.spriteBatch.Draw(tex, dest, (Rectangle?)s, c);
	}

	public static void DrawStretchedX(int id, ref Rectangle dest, Color c)
	{
		Rectangle value = src[id];
		value.X += 4;
		value.Width -= 8;
		Main.spriteBatch.Draw(tex, dest, (Rectangle?)value, c);
	}

	public static void DrawStretchedY(int id, ref Rectangle dest, Color c)
	{
		Rectangle value = src[id];
		value.Y += 4;
		value.Height -= 8;
		Main.spriteBatch.Draw(tex, dest, (Rectangle?)value, c);
	}

	public static void Draw(int id, int x, int y)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], Color.White);
	}

	public static void DrawCentered(int id, int x, int y, Rectangle rect, Color c)
	{
		rect.X += src[id].X;
		rect.Y += src[id].Y;
		Main.spriteBatch.Draw(tex, new Vector2(x - (rect.Width >> 1), y - (rect.Height >> 1)), (Rectangle?)rect, c);
	}

	public static void DrawCentered(int id, int x, int y, Rectangle rect, Color c, float scale)
	{
		rect.X += src[id].X;
		rect.Y += src[id].Y;
		Vector2 vector = new Vector2(rect.Width >> 1, rect.Height >> 1);
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)rect, c, 0f, vector, scale, SpriteEffects.None, 0f);
	}

	public static void DrawCentered(int id, ref Rectangle rect)
	{
		Main.spriteBatch.Draw(tex, new Vector2(rect.X + (rect.Width >> 1) - (src[id].Width >> 1), rect.Y + (rect.Height >> 1) - (src[id].Height >> 1)), (Rectangle?)src[id], Color.White);
	}

	public static void DrawCentered(int id, ref Rectangle rect, SpriteEffects se)
	{
		Main.spriteBatch.Draw(tex, new Vector2(rect.X + (rect.Width >> 1) - (src[id].Width >> 1), rect.Y + (rect.Height >> 1) - (src[id].Height >> 1)), (Rectangle?)src[id], Color.White, 0f, default(Vector2), 1f, se, 0f);
	}

	public static void Draw(int id, int x, int y, Color c)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c);
	}

	public static void Draw(int id, int x, int y, Color c, SpriteEffects se)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, default(Vector2), 1f, se, 0f);
	}

	public static void DrawScaled(int id, int x, int y, float scaleCenter, Color c)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, new Vector2(src[id].Width >> 1, src[id].Height >> 1), scaleCenter, SpriteEffects.None, 0f);
	}

	public static void DrawRotated(int id, ref Vector2 pos, Color c, float rotCenter)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, rotCenter, new Vector2(src[id].Width >> 1, src[id].Height >> 1), 1f, SpriteEffects.None, 0f);
	}

	public static void DrawRotatedTL(int id, int x, int y, Color c, float rotTL)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, rotTL, default(Vector2), 1f, SpriteEffects.None, 0f);
	}

	public static void DrawScaled(int id, ref Vector2 pos, Color c, float scaleCenter)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, 0f, new Vector2(src[id].Width >> 1, src[id].Height >> 1), scaleCenter, SpriteEffects.None, 0f);
	}

	public static void DrawScaledTL(int id, ref Vector2 pos, Color c, float scale)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, 0f, default(Vector2), scale, SpriteEffects.None, 0f);
	}

	public static void DrawScaledTL(int id, int x, int y, Color c, float scale)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, default(Vector2), scale, SpriteEffects.None, 0f);
	}

	public static void DrawScaled(int id, int x, int y, float scaleCenter, Color c, SpriteEffects e)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, new Vector2(src[id].Width >> 1, src[id].Height >> 1), scaleCenter, e, 0f);
	}

	public static void Draw(int id, int x, int y, Color c, float rotCenter, float scaleCenter)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, rotCenter, new Vector2(src[id].Width >> 1, src[id].Height >> 1), scaleCenter, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c, SpriteEffects se)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, 0f, default(Vector2), 1f, se, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c, float rotCenter, SpriteEffects se)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, rotCenter, new Vector2(src[id].Width >> 1, src[id].Height >> 1), 1f, se, 0f);
	}

	public static void DrawTL(int id, ref Vector2 pos, Color c, float scaleTopLeft)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, 0f, default(Vector2), scaleTopLeft, SpriteEffects.None, 0f);
	}

	public static void DrawTL(int id, int x, int y, Color c, float scaleTopLeft)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, default(Vector2), scaleTopLeft, SpriteEffects.None, 0f);
	}

	public static void DrawL(int id, int x, int y, Color c, float scaleCenterLeft)
	{
		Main.spriteBatch.Draw(tex, new Vector2(x, y), (Rectangle?)src[id], c, 0f, new Vector2(0f, src[id].Height >> 1), scaleCenterLeft, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c, float rot, float scale)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, rot, new Vector2(src[id].Width >> 1, src[id].Height >> 1), scale, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, ref Rectangle s, Color c, float rot, ref Vector2 pivot, float scale)
	{
		Rectangle value = src[id];
		value.X += s.X;
		value.Y += s.Y;
		value.Width = s.Width;
		value.Height = s.Height;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, rot, pivot, scale, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, int sh, Color c, float rot, float scale = 1f)
	{
		Rectangle value = src[id];
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, rot, new Vector2(value.Width >> 1, src[id].Height >> 1), scale, SpriteEffects.None, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, int sh, Color c, SpriteEffects se)
	{
		Rectangle value = src[id];
		value.Height = sh;
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)value, c, 0f, default(Vector2), 1f, se, 0f);
	}

	public static void Draw(int id, ref Vector2 pos, Color c, float rot, ref Vector2 pivot, float scale)
	{
		Main.spriteBatch.Draw(tex, pos, (Rectangle?)src[id], c, rot, pivot, scale, SpriteEffects.None, 0f);
	}

	public static Vector2 GetCenterPivot(int id)
	{
		return new Vector2(src[id].Width >> 1, src[id].Height >> 1);
	}

	public static int GetCenterPivotY(int id)
	{
		return src[id].Height >> 1;
	}
}
