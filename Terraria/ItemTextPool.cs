// Type: Terraria.ItemTextPool
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public sealed class ItemTextPool
  {
    public const int MAX_ITEM_TEXT = 4;
    public int numActive;
    public WorldView view;
    public ItemText[] itemText;

    public ItemTextPool(WorldView view)
    {
      this.numActive = 0;
      this.view = view;
      this.itemText = new ItemText[4];
    }

    public void Clear()
    {
      for (int index = 3; index >= 0; --index)
        this.itemText[index].Init();
    }

    public void Update()
    {
      int num = 0;
      for (int whoAmI = 3; whoAmI >= 0; --whoAmI)
      {
        if ((int) this.itemText[whoAmI].active != 0)
        {
          ++num;
          this.itemText[whoAmI].Update(whoAmI, this);
        }
      }
      this.numActive = num;
    }

    public void NewText(ref Item newItem, int stack)
    {
      if ((int) this.view.ui.inventoryMode > 0 || !this.view.ui.showItemText || (int) newItem.active == 0)
        return;
      int index1 = -1;
      for (int index2 = 3; index2 >= 0; --index2)
      {
        if ((int) this.itemText[index2].active != 0)
        {
          if ((int) this.itemText[index2].netID == (int) newItem.netID && (int) newItem.prefix == 0)
          {
            this.itemText[index2].stack += stack;
            Main.strBuilder.Length = 0;
            Main.strBuilder.Append(Lang.itemName((int) newItem.netID));
            Main.strBuilder.Append(ToStringExtensions.ToStackString(this.itemText[index2].stack));
            Vector2 vector2 = UI.fontSmallOutline.MeasureString(Main.strBuilder);
            this.itemText[index2].text = ((object) Main.strBuilder).ToString();
            this.itemText[index2].textSize = vector2;
            this.itemText[index2].lifeTime = (short) 56;
            this.itemText[index2].scale = 0.0f;
            this.itemText[index2].position.X = newItem.position.X + (float) (((double) newItem.width - (double) vector2.X) * 0.5);
            this.itemText[index2].position.Y = (float) ((double) newItem.position.Y + (double) ((int) newItem.height >> 2) - (double) vector2.Y * 0.5);
            this.itemText[index2].velocityY = -7f;
            return;
          }
        }
        else
          index1 = index2;
      }
      if (index1 < 0)
      {
        float num = (float) Main.bottomWorld;
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if ((double) num > (double) this.itemText[index2].position.Y)
          {
            index1 = index2;
            num = this.itemText[index2].position.Y;
          }
        }
      }
      if (index1 < 0)
        return;
      string text = newItem.AffixName();
      this.itemText[index1].active = (byte) 1;
      this.itemText[index1].lifeTime = (short) 56;
      this.itemText[index1].netID = newItem.netID;
      this.itemText[index1].stack = stack;
      if (stack > 1)
        text = text + ToStringExtensions.ToStackString(stack);
      this.itemText[index1].text = text;
      Vector2 vector2_1 = UI.MeasureString(UI.fontSmallOutline, text);
      this.itemText[index1].textSize = vector2_1;
      this.itemText[index1].alpha = 1f;
      this.itemText[index1].alphaDir = -0.01f;
      this.itemText[index1].scale = 0.0f;
      this.itemText[index1].velocityY = -7f;
      this.itemText[index1].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2_1.X * 0.5);
      this.itemText[index1].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2_1.Y * 0.5);
      if ((int) newItem.rare == 1)
        this.itemText[index1].color = new Color(150, 150, (int) byte.MaxValue);
      else if ((int) newItem.rare == 2)
        this.itemText[index1].color = new Color(150, (int) byte.MaxValue, 150);
      else if ((int) newItem.rare == 3)
        this.itemText[index1].color = new Color((int) byte.MaxValue, 200, 150);
      else if ((int) newItem.rare == 4)
        this.itemText[index1].color = new Color((int) byte.MaxValue, 150, 150);
      else if ((int) newItem.rare == 5)
        this.itemText[index1].color = new Color((int) byte.MaxValue, 150, (int) byte.MaxValue);
      else if ((int) newItem.rare == -1)
        this.itemText[index1].color = new Color(130, 130, 130);
      else if ((int) newItem.rare == 6)
        this.itemText[index1].color = new Color(210, 160, (int) byte.MaxValue);
      else
        this.itemText[index1].color = Color.White;
    }
  }
}
