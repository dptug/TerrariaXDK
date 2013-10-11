// Type: Terraria.CreateCharacter.AttributeWidget`1
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Terraria;

namespace Terraria.CreateCharacter
{
  public abstract class AttributeWidget<T> where T : ISelector
  {
    protected T widget;

    public string WidgetDescription { get; protected set; }

    public string ControlDescription { get; protected set; }

    internal AttributeWidget()
    {
    }

    public virtual void Draw(Vector2 position, float alpha)
    {
      this.widget.Draw(position, alpha);
    }

    public void Update()
    {
      this.widget.Update();
    }

    public bool SelectLeft()
    {
      return this.widget.SelectLeft();
    }

    public bool SelectRight()
    {
      return this.widget.SelectRight();
    }

    public bool SelectUp()
    {
      return this.widget.SelectUp();
    }

    public bool SelectDown()
    {
      return this.widget.SelectDown();
    }

    public virtual void SetCursor(Vector2i cursor)
    {
      this.widget.SetCursor(cursor);
    }

    public void Reset()
    {
      this.widget.Reset();
    }

    public void Back()
    {
      this.widget.CancelSelection();
    }

    public void Show()
    {
      this.widget.Show();
    }

    public void FlashSelection(int duration)
    {
      this.widget.FlashSelection(duration);
    }
  }
}
