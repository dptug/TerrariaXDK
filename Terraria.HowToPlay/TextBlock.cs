using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.HowToPlay;

public class TextBlock
{
	public bool isScrollable;

	private BoxGraphic background;

	private CompiledText text;

	public short minOffsetY;

	private Texture2D textTexture;

	private Color textColor;

	private Color accentColor;

	private Rectangle textArea;

	private Vector2i dialogPosition;

	public TextBlock(ref Rectangle dialogArea, CompiledText text, ref Rectangle textArea, Texture2D background, int borderWidth, Color backColor, Color textColor, Color accentColor)
	{
		this.background = BoxGraphic.Create(dialogArea.Width, dialogArea.Height, background, borderWidth, backColor);
		dialogPosition = new Vector2i(dialogArea.X, dialogArea.Y);
		this.text = text;
		this.textArea = textArea;
		isScrollable = text.Height > textArea.Height;
		minOffsetY = (short)(-Math.Max(0, text.Height - textArea.Height));
		this.textColor = textColor;
		this.accentColor = accentColor;
		textTexture = null;
	}

	public void Draw(int ox = 0, int oy = 0, int scrollY = 0)
	{
		Rectangle value = textArea;
		value.X = 0;
		value.Y = -scrollY;
		Rectangle rectangle = textArea;
		rectangle.X += ox;
		rectangle.Y += oy;
		Vector2i position = dialogPosition;
		position.X += ox;
		position.Y += oy;
		background.Draw(position, 1f);
		Main.spriteBatch.Draw(textTexture, rectangle, (Rectangle?)value, Color.White);
		if (isScrollable)
		{
			int x = position.X + (background.Width >> 1) - 8;
			Rectangle rect = new Rectangle(x, position.Y + 2, 16, 16);
			if (scrollY < 0)
			{
				SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect, SpriteEffects.FlipVertically);
			}
			if (scrollY > minOffsetY)
			{
				rect.Y = position.Y + background.Height - 16 - 2;
				SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect);
			}
		}
	}

	public void GenerateCache(GraphicsDevice graphicsDevice)
	{
		RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, text.Width, text.Height + Terraria.UI.fontSmallOutline.LineSpacing);
		graphicsDevice.SetRenderTarget(renderTarget);
		graphicsDevice.Clear(Color.Transparent);
		Main.spriteBatch.Begin();
		text.Draw(Main.spriteBatch, new Rectangle(0, 0, text.Width, text.Height), textColor, accentColor);
		Main.spriteBatch.End();
		graphicsDevice.SetRenderTarget(null);
		textTexture = renderTarget;
	}
}
