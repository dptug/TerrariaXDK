using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terraria.CreateCharacter;

public class UI
{
	private const int FLASH_DURATION = 10;

	private Terraria.UI parentUI;

	private CategorySelector categoryWidget;

	private IAttributeWidget[] attributes;

	private int uiDelay;

	private FastRandom rnd;

	private Player player;

	private IAttributeWidget previousAttribute;

	private string header;

	private Vector2 headerOrigin;

	private string footer;

	private Vector2 footerOrigin;

	private SpriteFont textFont;

	private float textScale;

	private IAttributeWidget SelectedAttribute => attributes[categoryWidget.SelectedIndex];

	private UI(Terraria.UI parentUI, CategorySelector categoryWidget, IAttributeWidget[] attributes)
	{
		this.parentUI = parentUI;
		this.categoryWidget = categoryWidget;
		this.attributes = attributes;
		uiDelay = 0;
		rnd = new FastRandom();
		textFont = Terraria.UI.fontBig;
		textScale = 0.5f;
	}

	public static UI Create(Terraria.UI parentUI)
	{
		CategorySelector categorySelector = new CategorySelector(Assets.CATEGORY_ICONS, Assets.CATEGORY_BACKGROUND, Assets.CATEGORY_BACKGROUND_SELECTED, new Vector2(54f, 0f));
		IAttributeWidget[] array = new IAttributeWidget[10];
		array[1] = HairAttributeWidget.Create(PlayerModifier.Hair, new Vector2i(4, 1), Lang.controls(Lang.CONTROLS.HAIR_TYPE), Lang.controls(Lang.CONTROLS.SELECT_TYPE));
		array[2] = ColorAttributeWidget.Create(PlayerModifier.HairColor, new Vector2i(4, 6), Lang.controls(Lang.CONTROLS.HAIR_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[5] = ColorAttributeWidget.Create(PlayerModifier.Shirt, new Vector2i(4, 2), Lang.controls(Lang.CONTROLS.SHIRT_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[6] = ColorAttributeWidget.Create(PlayerModifier.Undershirt, new Vector2i(2, 6), Lang.controls(Lang.CONTROLS.UNDERSHIRT_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[7] = ColorAttributeWidget.Create(PlayerModifier.Pants, new Vector2i(9, 7), Lang.controls(Lang.CONTROLS.PANTS_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[8] = ColorAttributeWidget.Create(PlayerModifier.Shoes, new Vector2i(0, 0), Lang.controls(Lang.CONTROLS.SHOE_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[3] = ColorAttributeWidget.Create(PlayerModifier.Eyes, new Vector2i(9, 2), Lang.controls(Lang.CONTROLS.EYE_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[4] = ColorAttributeWidget.Create(PlayerModifier.Skin, new Vector2i(3, 3), Lang.controls(Lang.CONTROLS.SKIN_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
		array[0] = GenderAttributeWidget.Create(PlayerModifier.Gender, GenderAttributeWidget.Gender.MALE, Lang.controls(Lang.CONTROLS.GENDER), Lang.controls(Lang.CONTROLS.SELECT_GENDER));
		array[9] = DifficultyAttributeWidget.Create(PlayerModifier.Difficulty, Difficulty.SOFTCORE, Lang.controls(Lang.CONTROLS.DIFFICULTY), Lang.controls(Lang.CONTROLS.SELECT_DIFFICULTY));
		return new UI(parentUI, categorySelector, array);
	}

	public void Update(Player player)
	{
		this.player = null;
		if (uiDelay > 0)
		{
			uiDelay--;
		}
		bool flag = updateCategoryInput(player);
		bool flag2 = updateWidgetInput(player);
		if (flag || flag2)
		{
			if (categoryWidget.SelectedIndex == 0 && flag2)
			{
				Main.PlaySound(player.male ? 1 : 20);
			}
			else
			{
				Main.PlaySound(12);
			}
			uiDelay = 12;
		}
		categoryWidget.Update();
		if (previousAttribute != null)
		{
			previousAttribute.Update();
		}
		SelectedAttribute.Update();
		if (parentUI.IsButtonTriggered(Buttons.Start))
		{
			parentUI.ClearInput();
			parentUI.SetMenu(MenuMode.NAME_CHARACTER);
		}
		if (parentUI.IsBackButtonTriggered())
		{
			parentUI.SetMenu(MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER);
		}
		this.player = player;
	}

	private bool IsButtonDown(Buttons button)
	{
		if (uiDelay == 0)
		{
			return parentUI.IsButtonDown(button);
		}
		return false;
	}

	private bool updateCategoryInput(Player player)
	{
		bool result = false;
		IAttributeWidget selectedAttribute = SelectedAttribute;
		if ((IsButtonDown(Buttons.RightShoulder) || parentUI.IsButtonTriggered(Buttons.A)) && categoryWidget.SelectNext())
		{
			result = true;
			previousAttribute = selectedAttribute;
			SelectedAttribute.Show();
			UpdateHeaderAndFooter();
			if (parentUI.IsButtonTriggered(Buttons.A))
			{
				previousAttribute.FlashSelection(10);
			}
		}
		if (IsButtonDown(Buttons.LeftShoulder) && categoryWidget.SelectPrevious())
		{
			result = true;
			previousAttribute = selectedAttribute;
			SelectedAttribute.Show();
			UpdateHeaderAndFooter();
		}
		if (parentUI.IsButtonTriggered(Buttons.Y))
		{
			Randomize(player);
			result = true;
		}
		return result;
	}

	private bool updateWidgetInput(Player player)
	{
		bool flag = false;
		IAttributeWidget selectedAttribute = SelectedAttribute;
		if (uiDelay == 0)
		{
			if (parentUI.IsDownButtonDown() && selectedAttribute.SelectDown())
			{
				flag = true;
			}
			if (parentUI.IsUpButtonDown() && selectedAttribute.SelectUp())
			{
				flag = true;
			}
			if (parentUI.IsLeftButtonDown() && selectedAttribute.SelectLeft())
			{
				flag = true;
			}
			if (parentUI.IsRightButtonDown() && selectedAttribute.SelectRight())
			{
				flag = true;
			}
		}
		if (flag)
		{
			selectedAttribute.Apply(player);
		}
		return flag;
	}

	private void UpdateHeaderAndFooter()
	{
		header = SelectedAttribute.WidgetDescription;
		headerOrigin = textFont.MeasureString(header) * 0.5f;
		footer = $"{categoryWidget.SelectedIndex + 1} / {attributes.Length}";
		footerOrigin = textFont.MeasureString(footer) * 0.5f;
	}

	public void Draw(WorldView view)
	{
		Texture2D fRAME = Assets.FRAME;
		int num = fRAME.Width >> 1;
		Vector2 vector = new Vector2(480 - num, view.SAFE_AREA_OFFSET_T + 32);
		Vector2 zero = Vector2.Zero;
		Main.spriteBatch.Draw(Assets.FRAME, vector, Color.White);
		zero.X = 228f;
		zero.Y = 32f;
		categoryWidget.Draw(vector + zero);
		zero.Y = 204f;
		if (categoryWidget.Scrolling)
		{
			float scrollTween = categoryWidget.ScrollTween;
			float num2 = Math.Min(scrollTween, 0.5f) / 0.5f;
			float alpha = (Math.Max(0.5f, scrollTween) - 0.5f) / 0.5f;
			previousAttribute.Draw(vector + zero, alpha);
			SelectedAttribute.Draw(vector + zero, 1f - num2);
		}
		else
		{
			SelectedAttribute.Draw(vector + zero, 1f);
		}
		zero.Y = 78f;
		Main.spriteBatch.DrawString(textFont, header, vector + zero, Color.White, 0f, headerOrigin, textScale, SpriteEffects.None, 0f);
		zero.Y = 340f;
		Main.spriteBatch.DrawString(textFont, footer, vector + zero, Color.White, 0f, footerOrigin, textScale, SpriteEffects.None, 0f);
		zero.Y = 385f;
		zero.X = num;
		string text = Lang.controls(Lang.CONTROLS.CREATE_CHARACTER);
		Vector2 vector2 = textFont.MeasureString(text);
		Main.spriteBatch.DrawString(textFont, text, vector + zero, Color.White, 0f, vector2 * 0.5f, textScale, SpriteEffects.None, 0f);
		if (player != null)
		{
			player.velocity.X = 1f;
			player.PlayerFrame();
			zero.X = 520f;
			zero.Y = 110f;
			parentUI.DrawPlayer(player, vector + zero, 4f);
		}
	}

	public void Randomize(Player player)
	{
		Vector2i[] array = RandomCharacter.create(rnd);
		for (int i = 0; i < attributes.Length; i++)
		{
			if (i != 9)
			{
				IAttributeWidget attributeWidget = attributes[i];
				attributeWidget.SetCursor(array[i]);
				attributeWidget.Apply(player);
			}
		}
	}

	public void ApplyDefaultAttributes(Player player)
	{
		Randomize(player);
		IAttributeWidget attributeWidget = attributes[9];
		attributeWidget.Reset();
		attributeWidget.Apply(player);
		categoryWidget.SelectedIndex = 0;
		UpdateHeaderAndFooter();
	}

	public void ControlDescription(StringBuilder strBuilder)
	{
		strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_CATEGORY));
		strBuilder.Append(' ');
		strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
		strBuilder.Append(' ');
		strBuilder.Append(Lang.controls(Lang.CONTROLS.RANDOMIZE));
	}
}
