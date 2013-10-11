// Type: Terraria.BoxGraphic
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
  internal class BoxGraphic
  {
    private Texture2D graphic;
    public Color Color;
    private Rectangle[] destinations;
    private Rectangle[] sources;
    public int Width;
    public int Height;

    public BoxGraphic(Texture2D graphic, Color color, Rectangle[] sources, Rectangle[] destinations, int width, int height)
    {
      this.graphic = graphic;
      this.Color = color;
      this.destinations = destinations;
      this.sources = sources;
      this.Width = width;
      this.Height = height;
    }

    private static Rectangle[] GetBox9Rectangles(int width, int height, int border)
    {
      return new Rectangle[9]
      {
        new Rectangle(0, 0, border, border),
        new Rectangle(border, 0, width - border * 2, border),
        new Rectangle(width - border, 0, border, border),
        new Rectangle(0, border, border, height - border * 2),
        new Rectangle(border, border, width - border * 2, height - border * 2),
        new Rectangle(width - border, border, border, height - border * 2),
        new Rectangle(0, height - border, border, border),
        new Rectangle(border, height - border, width - border * 2, border),
        new Rectangle(width - border, height - border, border, border)
      };
    }

    public static BoxGraphic Create(int width, int height, Texture2D graphic, int borderWidth, Color color)
    {
      Rectangle[] box9Rectangles1 = BoxGraphic.GetBox9Rectangles(width, height, borderWidth);
      Rectangle[] box9Rectangles2 = BoxGraphic.GetBox9Rectangles(graphic.Width, graphic.Height, borderWidth);
      return new BoxGraphic(graphic, color, box9Rectangles2, box9Rectangles1, width, height);
    }

    public void Draw(Vector2i position, float alpha)
    {
      for (int index = 0; index < 9; ++index)
      {
        Rectangle rectangle = this.destinations[index];
        rectangle.Offset(position.X, position.Y);
        Main.spriteBatch.Draw(this.graphic, rectangle, new Rectangle?(this.sources[index]), this.Color * alpha);
      }
    }
  }
}
