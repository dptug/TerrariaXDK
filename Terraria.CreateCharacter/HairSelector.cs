using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.CreateCharacter;

public class HairSelector : ISelector
{
	private const int ITEM_SPACING = 2;

	private Texture2D background;

	private Texture2D picker;

	private Vector2 pickerOrigin;

	private int columns;

	private int rows;

	private Rectangle[] sources;

	private int flashTimer;

	private Vector2i selected;

	private Vector2i revertValue;

	private Vector2i resetValue;

	public int Selected => selected.X + selected.Y * columns;

	public HairSelector(int columns, Rectangle[] sources, Texture2D background, Texture2D picker, Vector2i resetValue)
	{
		this.background = background;
		this.picker = picker;
		pickerOrigin = new Vector2(picker.Bounds.Width >> 1, picker.Bounds.Height >> 1);
		this.columns = columns;
		rows = sources.Length / columns;
		this.sources = sources;
		selected = resetValue;
		revertValue = resetValue;
		this.resetValue = resetValue;
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
		Rectangle bounds = background.Bounds;
		int num = bounds.Width + 2;
		int num2 = bounds.Height + 2;
		int num3 = bounds.Width >> 1;
		int num4 = bounds.Height >> 1;
		int num5 = num * columns - 2;
		int num6 = num2 * rows - 2;
		position.X -= num5 >> 1;
		position.Y -= num6 >> 1;
		position.X += num3;
		position.Y += num4;
		Color color = Color.White * alpha;
		Vector2 position2 = default(Vector2);
		for (int num7 = rows - 1; num7 > -1; num7--)
		{
			int num8 = (int)position.Y + num7 * num2;
			for (int num9 = columns - 1; num9 > -1; num9--)
			{
				if (num7 != selected.Y || num9 != selected.X)
				{
					int num10 = (int)position.X + num9 * num;
					int num11 = num7 * columns + num9;
					position2.X = num10 - num3;
					position2.Y = num8 - num4;
					Main.spriteBatch.Draw(background, position2, color);
					SpriteSheet<_sheetSprites>.DrawCentered(1269 + num11, num10, num8, sources[num11], color);
				}
			}
		}
		Vector2 vector = default(Vector2);
		float num12 = ((flashTimer > 0) ? (1f + 0.1f * (float)flashTimer) : 1f);
		vector.X = position.X + (float)(selected.X * num);
		vector.Y = position.Y + (float)(selected.Y * num2);
		Main.spriteBatch.Draw(picker, vector, (Rectangle?)null, color, 0f, pickerOrigin, num12, SpriteEffects.None, 0f);
		SpriteSheet<_sheetSprites>.DrawCentered(1269 + Selected, (int)vector.X, (int)vector.Y, sources[Selected], color, num12);
	}

	public bool SelectLeft()
	{
		if (selected.X > 0)
		{
			selected.X--;
		}
		else
		{
			selected.X = columns - 1;
		}
		return true;
	}

	public bool SelectRight()
	{
		if (selected.X < columns - 1)
		{
			selected.X++;
		}
		else
		{
			selected.X = 0;
		}
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
			selected.Y = rows - 1;
		}
		return true;
	}

	public bool SelectDown()
	{
		if (selected.Y < rows - 1)
		{
			selected.Y++;
		}
		else
		{
			selected.Y = 0;
		}
		return true;
	}

	public void SetCursor(Vector2i cursor)
	{
		selected = cursor;
	}

	public void Reset()
	{
		selected = resetValue;
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
	}
}
