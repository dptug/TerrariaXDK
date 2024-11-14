using System;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.CreateCharacter;

public class GenderAttributeWidget : AttributeWidget<HorizontalListSelector>, IAttributeWidget
{
	public enum Gender
	{
		MALE,
		FEMALE
	}

	private Action<Player, bool> modifier;

	public static GenderAttributeWidget Create(Action<Player, bool> modifier, Gender resetValue, string widgetDescription, string controlDescription)
	{
		HorizontalListSelector horizontalListSelector = new HorizontalListSelector(new Texture2D[2]
		{
			Assets.OPTION_MALE,
			Assets.OPTION_FEMALE
		}, Assets.HORIZONTAL_BACKGROUND, Assets.HORIZONTAL_PICKER, (resetValue != 0) ? 1 : 0);
		return new GenderAttributeWidget(horizontalListSelector, modifier, widgetDescription, controlDescription);
	}

	private GenderAttributeWidget(HorizontalListSelector widget, Action<Player, bool> modifier, string widgetDescription, string controlDescription)
	{
		base.widget = widget;
		this.modifier = modifier;
		base.WidgetDescription = widgetDescription;
		base.ControlDescription = controlDescription;
	}

	public void Apply(Player player)
	{
		modifier.Invoke(player, widget.Selected == 0);
	}
}
