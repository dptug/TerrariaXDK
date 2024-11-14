using Microsoft.Xna.Framework;

namespace Terraria;

public sealed class ItemTextPool
{
	public const int MAX_ITEM_TEXT = 4;

	public int numActive;

	public WorldView view;

	public ItemText[] itemText;

	public ItemTextPool(WorldView view)
	{
		numActive = 0;
		this.view = view;
		itemText = new ItemText[4];
	}

	public void Clear()
	{
		for (int num = 3; num >= 0; num--)
		{
			itemText[num].Init();
		}
	}

	public void Update()
	{
		int num = 0;
		for (int num2 = 3; num2 >= 0; num2--)
		{
			if (itemText[num2].active != 0)
			{
				num++;
				itemText[num2].Update(num2, this);
			}
		}
		numActive = num;
	}

	public void NewText(ref Item newItem, int stack)
	{
		if (view.ui.inventoryMode > 0 || !view.ui.showItemText || newItem.active == 0)
		{
			return;
		}
		int num = -1;
		for (int num2 = 3; num2 >= 0; num2--)
		{
			if (itemText[num2].active != 0)
			{
				if (itemText[num2].netID == newItem.netID && newItem.prefix == 0)
				{
					itemText[num2].stack += stack;
					Main.strBuilder.Length = 0;
					Main.strBuilder.Append(Lang.itemName(newItem.netID));
					Main.strBuilder.Append(itemText[num2].stack.ToStackString());
					Vector2 textSize = UI.fontSmallOutline.MeasureString(Main.strBuilder);
					itemText[num2].text = Main.strBuilder.ToString();
					itemText[num2].textSize = textSize;
					itemText[num2].lifeTime = 56;
					itemText[num2].scale = 0f;
					itemText[num2].position.X = newItem.position.X + ((float)(int)newItem.width - textSize.X) * 0.5f;
					itemText[num2].position.Y = newItem.position.Y + (float)(newItem.height >> 2) - textSize.Y * 0.5f;
					itemText[num2].velocityY = -7f;
					return;
				}
			}
			else
			{
				num = num2;
			}
		}
		if (num < 0)
		{
			float num3 = Main.bottomWorld;
			for (int i = 0; i < 4; i++)
			{
				if (num3 > itemText[i].position.Y)
				{
					num = i;
					num3 = itemText[i].position.Y;
				}
			}
		}
		if (num >= 0)
		{
			string text = newItem.AffixName();
			itemText[num].active = 1;
			itemText[num].lifeTime = 56;
			itemText[num].netID = newItem.netID;
			itemText[num].stack = stack;
			if (stack > 1)
			{
				text += stack.ToStackString();
			}
			itemText[num].text = text;
			Vector2 textSize2 = UI.MeasureString(UI.fontSmallOutline, text);
			itemText[num].textSize = textSize2;
			itemText[num].alpha = 1f;
			itemText[num].alphaDir = -0.01f;
			itemText[num].scale = 0f;
			itemText[num].velocityY = -7f;
			itemText[num].position.X = newItem.position.X + (float)(int)newItem.width * 0.5f - textSize2.X * 0.5f;
			itemText[num].position.Y = newItem.position.Y + (float)(int)newItem.height * 0.25f - textSize2.Y * 0.5f;
			if (newItem.rare == 1)
			{
				itemText[num].color = new Color(150, 150, 255);
			}
			else if (newItem.rare == 2)
			{
				itemText[num].color = new Color(150, 255, 150);
			}
			else if (newItem.rare == 3)
			{
				itemText[num].color = new Color(255, 200, 150);
			}
			else if (newItem.rare == 4)
			{
				itemText[num].color = new Color(255, 150, 150);
			}
			else if (newItem.rare == 5)
			{
				itemText[num].color = new Color(255, 150, 255);
			}
			else if (newItem.rare == -1)
			{
				itemText[num].color = new Color(130, 130, 130);
			}
			else if (newItem.rare == 6)
			{
				itemText[num].color = new Color(210, 160, 255);
			}
			else
			{
				itemText[num].color = Color.White;
			}
		}
	}
}
