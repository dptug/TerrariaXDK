// Type: Terraria.CreateCharacter.IAttributeWidget
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Terraria;

namespace Terraria.CreateCharacter
{
  public interface IAttributeWidget
  {
    string ControlDescription { get; }

    string WidgetDescription { get; }

    void Draw(Vector2 position, float alpha);

    void Update();

    bool SelectLeft();

    bool SelectRight();

    bool SelectUp();

    bool SelectDown();

    void Back();

    void SetCursor(Vector2i cursor);

    void Apply(Player player);

    void Reset();

    void Show();

    void FlashSelection(int duration);
  }
}
