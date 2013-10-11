// Type: Terraria.SpriteSheet`1
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
  public class SpriteSheet<T>
  {
    protected static Texture2D tex;
    public static Rectangle[] src;

    public static void Draw(int id, int x, int y, int sy, int sh, Color c, float rotCenter, float scaleCenter)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += sy;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(rectangle), c, rotCenter, new Vector2((float) (rectangle.Width >> 1), (float) (sh >> 1)), scaleCenter, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, int x, int y, int sx, int sw, int sh, Color c)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.X += sx;
      rectangle.Width = sw;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(rectangle), c);
    }

    public static void Draw(int id, ref Vector2 pos, int sy, int sh, Color c, SpriteEffects e)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += sy;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, 0.0f, new Vector2(), 1f, e, 0.0f);
    }

    public static void DrawRotated(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, SpriteEffects e)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += sy;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, rot, new Vector2((float) (rectangle.Width >> 1), (float) (sh >> 1)), 1f, e, 0.0f);
    }

    public static void DrawRotated(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, ref Vector2 pivot, SpriteEffects e)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += sy;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, rot, pivot, 1f, e, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, int sy, int sh, Color c, float rot, ref Vector2 pivot, float scale, SpriteEffects e)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += sy;
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, rot, pivot, scale, e, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c, float rot, ref Vector2 pivot, float scale, SpriteEffects e)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, rot, pivot, scale, e, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c);
    }

    public static void Draw(int id, ref Vector2 pos, ref Rectangle s, Color c)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.X += s.X;
      rectangle.Y += s.Y;
      rectangle.Width = s.Width;
      rectangle.Height = s.Height;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c);
    }

    public static void DrawStretched(int id, Rectangle s, ref Rectangle dest, Color c)
    {
      s.X += SpriteSheet<T>.src[id].X;
      s.Y += SpriteSheet<T>.src[id].Y;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, dest, new Rectangle?(s), c);
    }

    public static void DrawStretchedX(int id, ref Rectangle dest, Color c)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.X += 4;
      rectangle.Width -= 8;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, dest, new Rectangle?(rectangle), c);
    }

    public static void DrawStretchedY(int id, ref Rectangle dest, Color c)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Y += 4;
      rectangle.Height -= 8;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, dest, new Rectangle?(rectangle), c);
    }

    public static void Draw(int id, int x, int y)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), Color.White);
    }

    public static void DrawCentered(int id, int x, int y, Rectangle rect, Color c)
    {
      rect.X += SpriteSheet<T>.src[id].X;
      rect.Y += SpriteSheet<T>.src[id].Y;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) (x - (rect.Width >> 1)), (float) (y - (rect.Height >> 1))), new Rectangle?(rect), c);
    }

    public static void DrawCentered(int id, int x, int y, Rectangle rect, Color c, float scale)
    {
      rect.X += SpriteSheet<T>.src[id].X;
      rect.Y += SpriteSheet<T>.src[id].Y;
      Vector2 vector2 = new Vector2((float) (rect.Width >> 1), (float) (rect.Height >> 1));
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(rect), c, 0.0f, vector2, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawCentered(int id, ref Rectangle rect)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) (rect.X + (rect.Width >> 1) - (SpriteSheet<T>.src[id].Width >> 1)), (float) (rect.Y + (rect.Height >> 1) - (SpriteSheet<T>.src[id].Height >> 1))), new Rectangle?(SpriteSheet<T>.src[id]), Color.White);
    }

    public static void DrawCentered(int id, ref Rectangle rect, SpriteEffects se)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) (rect.X + (rect.Width >> 1) - (SpriteSheet<T>.src[id].Width >> 1)), (float) (rect.Y + (rect.Height >> 1) - (SpriteSheet<T>.src[id].Height >> 1))), new Rectangle?(SpriteSheet<T>.src[id]), Color.White, 0.0f, new Vector2(), 1f, se, 0.0f);
    }

    public static void Draw(int id, int x, int y, Color c)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c);
    }

    public static void Draw(int id, int x, int y, Color c, SpriteEffects se)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), 1f, se, 0.0f);
    }

    public static void DrawScaled(int id, int x, int y, float scaleCenter, Color c)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scaleCenter, SpriteEffects.None, 0.0f);
    }

    public static void DrawRotated(int id, ref Vector2 pos, Color c, float rotCenter)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, rotCenter, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawRotatedTL(int id, int x, int y, Color c, float rotTL)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, rotTL, new Vector2(), 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawScaled(int id, ref Vector2 pos, Color c, float scaleCenter)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scaleCenter, SpriteEffects.None, 0.0f);
    }

    public static void DrawScaledTL(int id, ref Vector2 pos, Color c, float scale)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawScaledTL(int id, int x, int y, Color c, float scale)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawScaled(int id, int x, int y, float scaleCenter, Color c, SpriteEffects e)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scaleCenter, e, 0.0f);
    }

    public static void Draw(int id, int x, int y, Color c, float rotCenter, float scaleCenter)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, rotCenter, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scaleCenter, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c, SpriteEffects se)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), 1f, se, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c, float rotCenter, SpriteEffects se)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, rotCenter, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), 1f, se, 0.0f);
    }

    public static void DrawTL(int id, ref Vector2 pos, Color c, float scaleTopLeft)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), scaleTopLeft, SpriteEffects.None, 0.0f);
    }

    public static void DrawTL(int id, int x, int y, Color c, float scaleTopLeft)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(), scaleTopLeft, SpriteEffects.None, 0.0f);
    }

    public static void DrawL(int id, int x, int y, Color c, float scaleCenterLeft)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, new Vector2((float) x, (float) y), new Rectangle?(SpriteSheet<T>.src[id]), c, 0.0f, new Vector2(0.0f, (float) (SpriteSheet<T>.src[id].Height >> 1)), scaleCenterLeft, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c, float rot, float scale)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, rot, new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scale, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, ref Rectangle s, Color c, float rot, ref Vector2 pivot, float scale)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.X += s.X;
      rectangle.Y += s.Y;
      rectangle.Width = s.Width;
      rectangle.Height = s.Height;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, rot, pivot, scale, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, int sh, Color c, float rot, float scale = 1f)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, rot, new Vector2((float) (rectangle.Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1)), scale, SpriteEffects.None, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, int sh, Color c, SpriteEffects se)
    {
      Rectangle rectangle = SpriteSheet<T>.src[id];
      rectangle.Height = sh;
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(rectangle), c, 0.0f, new Vector2(), 1f, se, 0.0f);
    }

    public static void Draw(int id, ref Vector2 pos, Color c, float rot, ref Vector2 pivot, float scale)
    {
      Main.spriteBatch.Draw(SpriteSheet<T>.tex, pos, new Rectangle?(SpriteSheet<T>.src[id]), c, rot, pivot, scale, SpriteEffects.None, 0.0f);
    }

    public static Vector2 GetCenterPivot(int id)
    {
      return new Vector2((float) (SpriteSheet<T>.src[id].Width >> 1), (float) (SpriteSheet<T>.src[id].Height >> 1));
    }

    public static int GetCenterPivotY(int id)
    {
      return SpriteSheet<T>.src[id].Height >> 1;
    }
  }
}
