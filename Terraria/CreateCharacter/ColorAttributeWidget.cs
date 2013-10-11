// Type: Terraria.CreateCharacter.ColorAttributeWidget
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class ColorAttributeWidget : AttributeWidget<ColorSelector>, IAttributeWidget
  {
    private Action<Player, Color> modifier;

    private ColorAttributeWidget(ColorSelector widget, Action<Player, Color> modifier, string widgetDescription, string controlDescription)
    {
      this.widget = widget;
      this.modifier = modifier;
      this.WidgetDescription = widgetDescription;
      this.ControlDescription = controlDescription;
    }

    public static ColorAttributeWidget Create(Action<Player, Color> modifier, Vector2i resetValue, string widgetDescription, string controlDescription)
    {
      return new ColorAttributeWidget(new ColorSelector(Assets.COLOR_PALETTE, Assets.COLOR_PICKER, resetValue), modifier, widgetDescription, controlDescription);
    }

    public void Apply(Player player)
    {
      this.modifier(player, this.widget.Selected);
    }
  }
}
