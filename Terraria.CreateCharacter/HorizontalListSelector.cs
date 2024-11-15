using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.CreateCharacter;

public class HorizontalListSelector : ISelector
{
	private const int ITEM_SPACING = 4;

	private Texture2D[] options;

	private Texture2D background;

	private Vector2 backgroundOrigin;

	private Texture2D picker;

	private Vector2 pickerOrigin;

	private int flashTimer;

	public int Selected;

	private int revertValue;

	private int resetValue;

	public HorizontalListSelector(Texture2D[] options, Texture2D background, Texture2D picker, int resetValue)
	{
		this.background = background;
		backgroundOrigin = new Vector2(background.Width >> 1, background.Height >> 1);
		this.options = options;
		this.picker = picker;
		pickerOrigin = new Vector2(picker.Bounds.Width >> 1, picker.Bounds.Height >> 1);
		Selected = resetValue;
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
		float num = ((flashTimer > 0) ? (2f + 0.1f * (float)flashTimer) : 2f);
		Color color = Color.White * alpha;
		float num2 = (float)background.Width * 2f + 4f;
		int num3 = (options.Length - 1) * (int)num2 - 4;
		position.X -= num3 >> 1;
		Vector2 vector = Vector2.Zero;
		Vector2 vector2 = Vector2.Zero;
		Texture2D texture2D = null;
		for (int i = 0; i < options.Length; i++)
		{
			Texture2D texture2D2 = options[i];
			Vector2 vector3 = new Vector2(texture2D2.Width >> 1, texture2D2.Height >> 1);
			if (i == Selected)
			{
				texture2D = texture2D2;
				vector2 = vector3;
				vector = position;
			}
			else
			{
				Main.spriteBatch.Draw(background, position, (Rectangle?)null, color, 0f, backgroundOrigin, 2f, SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(texture2D2, position, (Rectangle?)null, color, 0f, vector3, 2f, SpriteEffects.None, 0f);
			}
			position.X += num2;
		}
		if (texture2D != null)
		{
			Main.spriteBatch.Draw(picker, vector, (Rectangle?)null, color, 0f, pickerOrigin, num, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(texture2D, vector, (Rectangle?)null, color, 0f, vector2, num, SpriteEffects.None, 0f);
		}
	}

	public bool SelectLeft()
	{
		if (Selected > 0)
		{
			Selected--;
		}
		else
		{
			Selected = options.Length - 1;
		}
		return true;
	}

	public bool SelectRight()
	{
		if (Selected < options.Length - 1)
		{
			Selected++;
		}
		else
		{
			Selected = 0;
		}
		return true;
	}

	public bool SelectUp()
	{
		return false;
	}

	public bool SelectDown()
	{
		return false;
	}

	public void Reset()
	{
		Selected = resetValue;
	}

	public void Show()
	{
		revertValue = Selected;
		flashTimer = 0;
	}

	public void FlashSelection(int duration)
	{
		flashTimer = duration;
	}

	public void CancelSelection()
	{
		Selected = revertValue;
	}

	public void SetCursor(Vector2i cursor)
	{
		int num = cursor.X;
		if (num < 0)
		{
			num = 0;
		}
		else if (num > options.Length - 1)
		{
			num = options.Length - 1;
		}
		Selected = num;
	}
}
