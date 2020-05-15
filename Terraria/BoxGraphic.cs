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
			Rectangle[] box9Rectangles = GetBox9Rectangles(width, height, borderWidth);
			Rectangle[] box9Rectangles2 = GetBox9Rectangles(graphic.Width, graphic.Height, borderWidth);
			return new BoxGraphic(graphic, color, box9Rectangles2, box9Rectangles, width, height);
		}

		public BoxGraphic(Texture2D graphic, Color color, Rectangle[] sources, Rectangle[] destinations, int width, int height)
		{
			this.graphic = graphic;
			Color = color;
			this.destinations = destinations;
			this.sources = sources;
			Width = width;
			Height = height;
		}

		public void Draw(Vector2i position, float alpha)
		{
			for (int i = 0; i < 9; i++)
			{
				Rectangle destinationRectangle = destinations[i];
				destinationRectangle.Offset(position.X, position.Y);
				Main.spriteBatch.Draw(graphic, destinationRectangle, sources[i], Color * alpha);
			}
		}
	}
}
