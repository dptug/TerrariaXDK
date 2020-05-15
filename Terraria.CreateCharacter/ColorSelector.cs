using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.CreateCharacter
{
	public class ColorSelector : ISelector
	{
		private const int ITEM_WIDTH = 16;

		private const int ITEM_HEIGHT = 16;

		private const int ITEM_SELECTED_WIDTH = 20;

		private const int ITEM_SELECTED_HEIGHT = 20;

		private const int ITEM_SPACING = 6;

		private Texture2D palette;

		private Rectangle paletteBounds;

		private Texture2D picker;

		private Rectangle pickerBounds;

		private Vector2i selected;

		private Vector2i revertValue;

		private Vector2i resetValue;

		private int flashTimer;

		public Color Selected;

		public ColorSelector(Texture2D palette, Texture2D picker, Vector2i resetValue)
		{
			this.palette = palette;
			paletteBounds = palette.Bounds;
			this.picker = picker;
			pickerBounds = picker.Bounds;
			selected = resetValue;
			this.resetValue = resetValue;
			this.resetValue = resetValue;
			UpdateColor();
		}

		public void Update()
		{
			if (flashTimer > 0)
			{
				flashTimer--;
			}
		}

		public void Draw(Vector2 position, float alpha)
		{
			Rectangle rectangle = paletteBounds;
			Rectangle value = new Rectangle(0, 0, 1, 1);
			Rectangle destinationRectangle = new Rectangle(0, 0, 16, 16);
			Vector2 position2 = default(Vector2);
			Vector2i vector2i = new Vector2i(8, 8);
			int num = rectangle.Width * 22 - 6;
			int num2 = rectangle.Height * 22 - 6;
			position.X -= num >> 1;
			position.Y -= num2 >> 1;
			position.X += 8f;
			position.Y += 8f;
			Color color = Color.White * alpha;
			Color color2 = Color.Black * alpha;
			for (int num3 = rectangle.Height - 1; num3 > -1; num3--)
			{
				for (int num4 = rectangle.Width - 1; num4 > -1; num4--)
				{
					if (selected.X != num4 || selected.Y != num3)
					{
						value.X = num4;
						value.Y = num3;
						destinationRectangle.X = (int)position.X + num4 * 22 - vector2i.X;
						destinationRectangle.Y = (int)position.Y + num3 * 22 - vector2i.Y;
						Main.spriteBatch.Draw(palette, destinationRectangle, value, color);
						position2.X = destinationRectangle.X - (pickerBounds.Width - 16 >> 1);
						position2.Y = destinationRectangle.Y - (pickerBounds.Height - 16 >> 1);
						Main.spriteBatch.Draw(picker, position2, color2);
					}
				}
			}
			Vector2 position3 = default(Vector2);
			position3.X = position.X + (float)(selected.X * 22);
			position3.Y = position.Y + (float)(selected.Y * 22);
			value.X = selected.X;
			value.Y = selected.Y;
			float num5 = (flashTimer > 0) ? (1f + 0.1f * (float)flashTimer) : 1f;
			destinationRectangle.X = (int)position.X + selected.X * 22 - (int)((float)vector2i.X * num5);
			destinationRectangle.Y = (int)position.Y + selected.Y * 22 - (int)((float)vector2i.Y * num5);
			destinationRectangle.Width = (int)((float)destinationRectangle.Width * num5);
			destinationRectangle.Height = (int)((float)destinationRectangle.Height * num5);
			Main.spriteBatch.Draw(palette, destinationRectangle, value, color);
			Main.spriteBatch.Draw(picker, position3, null, color, 0f, new Vector2(pickerBounds.Width >> 1, pickerBounds.Height >> 1), num5, SpriteEffects.None, 0f);
		}

		private void UpdateColor()
		{
			Rectangle value = new Rectangle(selected.X, selected.Y, 1, 1);
			Color[] array = new Color[1];
			palette.GetData(0, value, array, 0, 1);
			Selected = array[0];
		}

		public bool SelectLeft()
		{
			if (selected.X > 0)
			{
				selected.X--;
			}
			else
			{
				selected.X = paletteBounds.Width - 1;
			}
			UpdateColor();
			return true;
		}

		public bool SelectRight()
		{
			if (selected.X < paletteBounds.Width - 1)
			{
				selected.X++;
			}
			else
			{
				selected.X = 0;
			}
			UpdateColor();
			return true;
		}

		public bool SelectUp()
		{
			if (selected.Y > 0)
			{
				selected.Y--;
			}
			else
			{
				selected.Y = paletteBounds.Height - 1;
			}
			UpdateColor();
			return true;
		}

		public bool SelectDown()
		{
			if (selected.Y < paletteBounds.Height - 1)
			{
				selected.Y++;
			}
			else
			{
				selected.Y = 0;
			}
			UpdateColor();
			return true;
		}

		public void SetCursor(Vector2i cursor)
		{
			selected = cursor;
			UpdateColor();
		}

		public void Reset()
		{
			selected = resetValue;
			UpdateColor();
		}

		public void Show()
		{
			revertValue = selected;
			flashTimer = 0;
		}

		public void FlashSelection(int duration)
		{
			flashTimer = duration;
		}

		public void CancelSelection()
		{
			selected = revertValue;
			UpdateColor();
		}
	}
}
