using System;

namespace Terraria.CreateCharacter;

public class HairAttributeWidget : AttributeWidget<HairSelector>, IAttributeWidget
{
	private Action<Player, int> modifier;

	public static HairAttributeWidget Create(Action<Player, int> modifier, Vector2i resetValue, string widgetDescription, string controlDescription)
	{
		HairSelector hairSelector = new HairSelector(9, Assets.HAIR_SOURCES, Assets.HAIR_BACKGROUND, Assets.HAIR_PICKER, resetValue);
		return new HairAttributeWidget(hairSelector, modifier, widgetDescription, controlDescription);
	}

	private HairAttributeWidget(HairSelector widget, Action<Player, int> modifier, string widgetDescription, string controlDescription)
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
