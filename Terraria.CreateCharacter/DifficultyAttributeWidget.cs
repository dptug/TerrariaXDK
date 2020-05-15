using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.CreateCharacter
{
	public class DifficultyAttributeWidget : AttributeWidget<DifficultySelector>, IAttributeWidget
	{
		private Action<Player, byte> modifier;

		public static DifficultyAttributeWidget Create(Action<Player, byte> modifier, Difficulty resetValue, string widgetDescription, string controlDescription)
		{
			DifficultySelector widget = new DifficultySelector(new Texture2D[3]
			{
				Assets.DIFFICULTY_SOFTCORE,
				Assets.DIFFICULTY_MEDIUMCORE,
				Assets.DIFFICULTY_HARDCORE
			}, resetValue);
			return new DifficultyAttributeWidget(widget, modifier, widgetDescription, controlDescription);
		}

		private DifficultyAttributeWidget(DifficultySelector widget, Action<Player, byte> modifier, string widgetDescription, string controlDescription)
		{
			base.widget = widget;
			this.modifier = modifier;
			base.WidgetDescription = widgetDescription;
			base.ControlDescription = controlDescription;
		}

		public void Apply(Player player)
		{
			modifier(player, (byte)widget.Selected);
		}
	}
}
