// Type: Terraria.CreateCharacter.GenderAttributeWidget
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class GenderAttributeWidget : AttributeWidget<HorizontalListSelector>, IAttributeWidget
  {
    private Action<Player, bool> modifier;

    private GenderAttributeWidget(HorizontalListSelector widget, Action<Player, bool> modifier, string widgetDescription, string controlDescription)
    {
      this.widget = widget;
      this.modifier = modifier;
      this.WidgetDescription = widgetDescription;
      this.ControlDescription = controlDescription;
    }

    public static GenderAttributeWidget Create(Action<Player, bool> modifier, GenderAttributeWidget.Gender resetValue, string widgetDescription, string controlDescription)
    {
      return new GenderAttributeWidget(new HorizontalListSelector(new Texture2D[2]
      {
        Assets.OPTION_MALE,
        Assets.OPTION_FEMALE
      }, Assets.HORIZONTAL_BACKGROUND, Assets.HORIZONTAL_PICKER, resetValue == GenderAttributeWidget.Gender.MALE ? 0 : 1), modifier, widgetDescription, controlDescription);
    }

    public void Apply(Player player)
    {
      this.modifier(player, this.widget.Selected == 0);
    }

    public enum Gender
    {
      MALE,
      FEMALE,
    }
  }
}
