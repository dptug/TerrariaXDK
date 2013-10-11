// Type: Terraria.CreateCharacter.HairAttributeWidget
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class HairAttributeWidget : AttributeWidget<HairSelector>, IAttributeWidget
  {
    private Action<Player, int> modifier;

    private HairAttributeWidget(HairSelector widget, Action<Player, int> modifier, string widgetDescription, string controlDescription)
    {
      this.widget = widget;
      this.modifier = modifier;
      this.WidgetDescription = widgetDescription;
      this.ControlDescription = controlDescription;
    }

    public static HairAttributeWidget Create(Action<Player, int> modifier, Vector2i resetValue, string widgetDescription, string controlDescription)
    {
      return new HairAttributeWidget(new HairSelector(9, Assets.HAIR_SOURCES, Assets.HAIR_BACKGROUND, Assets.HAIR_PICKER, resetValue), modifier, widgetDescription, controlDescription);
    }

    public void Apply(Player player)
    {
      this.modifier(player, this.widget.Selected);
    }
  }
}
