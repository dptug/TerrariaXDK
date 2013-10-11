// Type: Terraria.CreateCharacter.DifficultyAttributeWidget
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.CreateCharacter
{
  public class DifficultyAttributeWidget : AttributeWidget<DifficultySelector>, IAttributeWidget
  {
    private Action<Player, byte> modifier;

    private DifficultyAttributeWidget(DifficultySelector widget, Action<Player, byte> modifier, string widgetDescription, string controlDescription)
    {
      this.widget = widget;
      this.modifier = modifier;
      this.WidgetDescription = widgetDescription;
      this.ControlDescription = controlDescription;
    }

    public static DifficultyAttributeWidget Create(Action<Player, byte> modifier, Difficulty resetValue, string widgetDescription, string controlDescription)
    {
      return new DifficultyAttributeWidget(new DifficultySelector(new Texture2D[3]
      {
        Assets.DIFFICULTY_SOFTCORE,
        Assets.DIFFICULTY_MEDIUMCORE,
        Assets.DIFFICULTY_HARDCORE
      }, resetValue), modifier, widgetDescription, controlDescription);
    }

    public void Apply(Player player)
    {
      this.modifier(player, (byte) this.widget.Selected);
    }
  }
}
