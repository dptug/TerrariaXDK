using System;
using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter;

public class ColorAttributeWidget : AttributeWidget<ColorSelector>, IAttributeWidget
{
	private Action<Player, Color> modifier;

	public static ColorAttributeWidget Create(Action<Player, Color> modifier, Vector2i resetValue, string widgetDescription, string controlDescription)
	{
		ColorSelector colorSelector = new ColorSelector(Assets.COLOR_PALETTE, Assets.COLOR_PICKER, resetValue);
		return new ColorAttributeWidget(colorSelector, modifier, widgetDescription, controlDescription);
	}

	private ColorAttributeWidget(ColorSelector widget, Action<Player, Color> modifier, string widgetDescription, string controlDescription)
	{
		base.widget = widget;
		this.modifier = modifier;
		base.WidgetDescription = widgetDescription;
		base.ControlDescription = controlDescription;
	}

	public void Apply(Player player)
	{
		modifier.Invoke(player, widget.Selected);
	}
}
