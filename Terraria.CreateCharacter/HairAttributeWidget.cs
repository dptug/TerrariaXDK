using System;

namespace Terraria.CreateCharacter
{
	public class HairAttributeWidget : AttributeWidget<HairSelector>, IAttributeWidget
	{
		private Action<Player, int> modifier;

		public static HairAttributeWidget Create(Action<Player, int> modifier, Vector2i resetValue, string widgetDescription, string controlDescription)
		{
			HairSelector widget = new HairSelector(9, Assets.HAIR_SOURCES, Assets.HAIR_BACKGROUND, Assets.HAIR_PICKER, resetValue);
			return new HairAttributeWidget(widget, modifier, widgetDescription, controlDescription);
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
			modifier(player, widget.Selected);
		}
	}
}
