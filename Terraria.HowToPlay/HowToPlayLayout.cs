using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.HowToPlay
{
	public class HowToPlayLayout
	{
		private struct Image
		{
			public Vector2 Position;

			public Texture2D Texture;
		}

		private const int MAX_HEIGHT = 454;

		private static Color TEXT_COLOR = Color.White;

		private static Color ACCENT_COLOR = new Color(255, 212, 64, 255);

		private static Color BACK_COLOR = Terraria.UI.DEFAULT_DIALOG_COLOR;

		public TextBlock textblock;

		private Image[] images;

		public static HowToPlayLayout TextOnlyLayout(string text, int width)
		{
			int tEXT_BACKGROUND_BORDER_WIDTH = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
			int val = 454;
			CompiledText compiledText = new CompiledText(text, width - tEXT_BACKGROUND_BORDER_WIDTH * 2, Terraria.UI.styleFontSmallOutline);
			val = Math.Min(compiledText.Height + Terraria.UI.fontSmallOutline.LineSpacing + tEXT_BACKGROUND_BORDER_WIDTH * 2, val);
			int x = 864 - width >> 1;
			int y = 454 - val >> 1;
			Rectangle dialogArea = new Rectangle(x, y, width, val);
			Rectangle textArea = dialogArea;
			textArea.Inflate(-tEXT_BACKGROUND_BORDER_WIDTH, -tEXT_BACKGROUND_BORDER_WIDTH);
			TextBlock textBlock = new TextBlock(ref dialogArea, compiledText, ref textArea, Assets.TEXT_BACKGROUND, tEXT_BACKGROUND_BORDER_WIDTH, BACK_COLOR, TEXT_COLOR, ACCENT_COLOR);
			return new HowToPlayLayout(textBlock);
		}

		public static HowToPlayLayout SideBySideLayout(string text, int width, Texture2D image, int padding = 20)
		{
			int tEXT_BACKGROUND_BORDER_WIDTH = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
			int val = 454;
			CompiledText compiledText = new CompiledText(text, width - tEXT_BACKGROUND_BORDER_WIDTH * 2, Terraria.UI.styleFontSmallOutline);
			val = Math.Min(compiledText.Height + Terraria.UI.fontSmallOutline.LineSpacing + tEXT_BACKGROUND_BORDER_WIDTH * 2, val);
			int num = image.Width + padding + width;
			int num2 = 864 - num >> 1;
			int y = 454 - val >> 1;
			Rectangle dialogArea = new Rectangle(num2, y, width, val);
			Rectangle textArea = dialogArea;
			textArea.Inflate(-tEXT_BACKGROUND_BORDER_WIDTH, -tEXT_BACKGROUND_BORDER_WIDTH);
			TextBlock textBlock = new TextBlock(ref dialogArea, compiledText, ref textArea, Assets.TEXT_BACKGROUND, tEXT_BACKGROUND_BORDER_WIDTH, BACK_COLOR, TEXT_COLOR, ACCENT_COLOR);
			num2 += width + padding;
			y = 454 - image.Height >> 1;
			Image[] array = new Image[1]
			{
				new Image
				{
					Position = new Vector2(num2, y),
					Texture = image
				}
			};
			return new HowToPlayLayout(textBlock, array);
		}

		public static HowToPlayLayout StackedLayout(string text, int width, int height, Texture2D image, int padding = 20)
		{
			int tEXT_BACKGROUND_BORDER_WIDTH = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
			CompiledText compiledText = new CompiledText(text, width - tEXT_BACKGROUND_BORDER_WIDTH * 2, Terraria.UI.styleFontSmallOutline);
			height = Math.Min(compiledText.Height + Terraria.UI.fontSmallOutline.LineSpacing + tEXT_BACKGROUND_BORDER_WIDTH * 2, height);
			int num = height + padding + image.Height;
			int x = 864 - compiledText.Width >> 1;
			int num2 = 454 - num >> 1;
			Rectangle dialogArea = new Rectangle(x, num2, width, height);
			Rectangle textArea = dialogArea;
			textArea.Inflate(-tEXT_BACKGROUND_BORDER_WIDTH, -tEXT_BACKGROUND_BORDER_WIDTH);
			TextBlock textBlock = new TextBlock(ref dialogArea, compiledText, ref textArea, Assets.TEXT_BACKGROUND, tEXT_BACKGROUND_BORDER_WIDTH, BACK_COLOR, TEXT_COLOR, ACCENT_COLOR);
			x = 864 - image.Width >> 1;
			num2 += height + padding;
			Image[] array = new Image[1]
			{
				new Image
				{
					Position = new Vector2(x, num2),
					Texture = image
				}
			};
			return new HowToPlayLayout(textBlock, array);
		}

		private HowToPlayLayout(TextBlock textblock)
		{
			this.textblock = textblock;
			images = new Image[0];
		}

		private HowToPlayLayout(TextBlock textblock, Image[] images)
		{
			this.textblock = textblock;
			this.images = images;
		}

		public void Draw(int offsetX, int offsetY, int scrollY)
		{
			textblock.Draw(offsetX, offsetY, scrollY);
			Image[] array = images;
			for (int i = 0; i < array.Length; i++)
			{
				Image image = array[i];
				Vector2 position = image.Position;
				position.X += offsetX;
				position.Y += offsetY;
				Main.spriteBatch.Draw(image.Texture, position, Color.White);
			}
		}

		public void GenerateCache(GraphicsDevice graphicsDevice)
		{
			textblock.GenerateCache(graphicsDevice);
		}
	}
}
