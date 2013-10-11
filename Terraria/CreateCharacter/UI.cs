// Type: Terraria.CreateCharacter.UI
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using Terraria;

namespace Terraria.CreateCharacter
{
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

    private IAttributeWidget SelectedAttribute
    {
      get
      {
        return this.attributes[this.categoryWidget.SelectedIndex];
      }
    }

    private UI(Terraria.UI parentUI, CategorySelector categoryWidget, IAttributeWidget[] attributes)
    {
      this.parentUI = parentUI;
      this.categoryWidget = categoryWidget;
      this.attributes = attributes;
      this.uiDelay = 0;
      this.rnd = new FastRandom();
      this.textFont = Terraria.UI.fontBig;
      this.textScale = 0.5f;
    }

    public static UI Create(Terraria.UI parentUI)
    {
      CategorySelector categoryWidget = new CategorySelector(Assets.CATEGORY_ICONS, Assets.CATEGORY_BACKGROUND, Assets.CATEGORY_BACKGROUND_SELECTED, new Vector2(54f, 0.0f));
      IAttributeWidget[] attributes = new IAttributeWidget[10]
      {
        null,
        (IAttributeWidget) HairAttributeWidget.Create(new Action<Player, int>(PlayerModifier.Hair), new Vector2i(4, 1), Lang.controls(Lang.CONTROLS.HAIR_TYPE), Lang.controls(Lang.CONTROLS.SELECT_TYPE)),
        (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.HairColor), new Vector2i(4, 6), Lang.controls(Lang.CONTROLS.HAIR_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR)),
        null,
        null,
        (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Shirt), new Vector2i(4, 2), Lang.controls(Lang.CONTROLS.SHIRT_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR)),
        (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Undershirt), new Vector2i(2, 6), Lang.controls(Lang.CONTROLS.UNDERSHIRT_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR)),
        (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Pants), new Vector2i(9, 7), Lang.controls(Lang.CONTROLS.PANTS_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR)),
        (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Shoes), new Vector2i(0, 0), Lang.controls(Lang.CONTROLS.SHOE_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR)),
        null
      };
      attributes[3] = (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Eyes), new Vector2i(9, 2), Lang.controls(Lang.CONTROLS.EYE_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
      attributes[4] = (IAttributeWidget) ColorAttributeWidget.Create(new Action<Player, Color>(PlayerModifier.Skin), new Vector2i(3, 3), Lang.controls(Lang.CONTROLS.SKIN_COLOR), Lang.controls(Lang.CONTROLS.SELECT_COLOR));
      attributes[0] = (IAttributeWidget) GenderAttributeWidget.Create(new Action<Player, bool>(PlayerModifier.Gender), GenderAttributeWidget.Gender.MALE, Lang.controls(Lang.CONTROLS.GENDER), Lang.controls(Lang.CONTROLS.SELECT_GENDER));
      attributes[9] = (IAttributeWidget) DifficultyAttributeWidget.Create(new Action<Player, byte>(PlayerModifier.Difficulty), Difficulty.SOFTCORE, Lang.controls(Lang.CONTROLS.DIFFICULTY), Lang.controls(Lang.CONTROLS.SELECT_DIFFICULTY));
      return new UI(parentUI, categoryWidget, attributes);
    }

    public void Update(Player player)
    {
      this.player = (Player) null;
      if (this.uiDelay > 0)
        --this.uiDelay;
      bool flag1 = this.updateCategoryInput(player);
      bool flag2 = this.updateWidgetInput(player);
      if (flag1 || flag2)
      {
        if (this.categoryWidget.SelectedIndex == 0 && flag2)
          Main.PlaySound(player.male ? 1 : 20);
        else
          Main.PlaySound(12);
        this.uiDelay = 12;
      }
      this.categoryWidget.Update();
      if (this.previousAttribute != null)
        this.previousAttribute.Update();
      this.SelectedAttribute.Update();
      if (this.parentUI.IsButtonTriggered(Buttons.Start))
      {
        this.parentUI.ClearInput();
        this.parentUI.SetMenu(MenuMode.NAME_CHARACTER, true, false);
      }
      if (this.parentUI.IsBackButtonTriggered())
        this.parentUI.SetMenu(MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER, true, false);
      this.player = player;
    }

    private bool IsButtonDown(Buttons button)
    {
      if (this.uiDelay == 0)
        return this.parentUI.IsButtonDown(button);
      else
        return false;
    }

    private bool updateCategoryInput(Player player)
    {
      bool flag = false;
      IAttributeWidget selectedAttribute = this.SelectedAttribute;
      if ((this.IsButtonDown(Buttons.RightShoulder) || this.parentUI.IsButtonTriggered(Buttons.A)) && this.categoryWidget.SelectNext())
      {
        flag = true;
        this.previousAttribute = selectedAttribute;
        this.SelectedAttribute.Show();
        this.UpdateHeaderAndFooter();
        if (this.parentUI.IsButtonTriggered(Buttons.A))
          this.previousAttribute.FlashSelection(10);
      }
      if (this.IsButtonDown(Buttons.LeftShoulder) && this.categoryWidget.SelectPrevious())
      {
        flag = true;
        this.previousAttribute = selectedAttribute;
        this.SelectedAttribute.Show();
        this.UpdateHeaderAndFooter();
      }
      if (this.parentUI.IsButtonTriggered(Buttons.Y))
      {
        this.Randomize(player);
        flag = true;
      }
      return flag;
    }

    private bool updateWidgetInput(Player player)
    {
      bool flag = false;
      IAttributeWidget selectedAttribute = this.SelectedAttribute;
      if (this.uiDelay == 0)
      {
        if (this.parentUI.IsDownButtonDown() && selectedAttribute.SelectDown())
          flag = true;
        if (this.parentUI.IsUpButtonDown() && selectedAttribute.SelectUp())
          flag = true;
        if (this.parentUI.IsLeftButtonDown() && selectedAttribute.SelectLeft())
          flag = true;
        if (this.parentUI.IsRightButtonDown() && selectedAttribute.SelectRight())
          flag = true;
      }
      if (flag)
        selectedAttribute.Apply(player);
      return flag;
    }

    private void UpdateHeaderAndFooter()
    {
      this.header = this.SelectedAttribute.WidgetDescription;
      this.headerOrigin = this.textFont.MeasureString(this.header) * 0.5f;
      this.footer = string.Format("{0} / {1}", (object) (this.categoryWidget.SelectedIndex + 1), (object) this.attributes.Length);
      this.footerOrigin = this.textFont.MeasureString(this.footer) * 0.5f;
    }

    public void Draw(WorldView view)
    {
      int num1 = Assets.FRAME.Width >> 1;
      Vector2 position = new Vector2((float) (480 - num1), (float) (view.SAFE_AREA_OFFSET_T + 32));
      Vector2 zero = Vector2.Zero;
      Main.spriteBatch.Draw(Assets.FRAME, position, Color.White);
      zero.X = 228f;
      zero.Y = 32f;
      this.categoryWidget.Draw(position + zero);
      zero.Y = 204f;
      if (this.categoryWidget.Scrolling)
      {
        float num2 = this.categoryWidget.ScrollTween;
        float num3 = Math.Min(num2, 0.5f) / 0.5f;
        float alpha = (float) (((double) Math.Max(0.5f, num2) - 0.5) / 0.5);
        this.previousAttribute.Draw(position + zero, alpha);
        this.SelectedAttribute.Draw(position + zero, 1f - num3);
      }
      else
        this.SelectedAttribute.Draw(position + zero, 1f);
      zero.Y = 78f;
      Main.spriteBatch.DrawString(this.textFont, this.header, position + zero, Color.White, 0.0f, this.headerOrigin, this.textScale, SpriteEffects.None, 0.0f);
      zero.Y = 340f;
      Main.spriteBatch.DrawString(this.textFont, this.footer, position + zero, Color.White, 0.0f, this.footerOrigin, this.textScale, SpriteEffects.None, 0.0f);
      zero.Y = 385f;
      zero.X = (float) num1;
      string text = Lang.controls(Lang.CONTROLS.CREATE_CHARACTER);
      Vector2 vector2 = this.textFont.MeasureString(text);
      Main.spriteBatch.DrawString(this.textFont, text, position + zero, Color.White, 0.0f, vector2 * 0.5f, this.textScale, SpriteEffects.None, 0.0f);
      if (this.player == null)
        return;
      this.player.velocity.X = 1f;
      this.player.PlayerFrame();
      zero.X = 520f;
      zero.Y = 110f;
      this.parentUI.DrawPlayer(this.player, position + zero, 4f);
    }

    public void Randomize(Player player)
    {
      Vector2i[] vector2iArray = RandomCharacter.create(this.rnd);
      for (int index = 0; index < this.attributes.Length; ++index)
      {
        if (index != 9)
        {
          IAttributeWidget attributeWidget = this.attributes[index];
          attributeWidget.SetCursor(vector2iArray[index]);
          attributeWidget.Apply(player);
        }
      }
    }

    public void ApplyDefaultAttributes(Player player)
    {
      this.Randomize(player);
      IAttributeWidget attributeWidget = this.attributes[9];
      attributeWidget.Reset();
      attributeWidget.Apply(player);
      this.categoryWidget.SelectedIndex = 0;
      this.UpdateHeaderAndFooter();
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
}
