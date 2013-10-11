// Type: Terraria.ActivatableSlider
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
  public class ActivatableSlider
  {
    private Slider selected;
    private Slider active;
    private Slider inactive;

    public float Progress
    {
      get
      {
        return this.active.Progress;
      }
      set
      {
        this.active.Progress = value;
        this.inactive.Progress = value;
      }
    }

    public bool Active
    {
      get
      {
        return this.selected == this.active;
      }
      set
      {
        if (value)
          this.selected = this.active;
        else
          this.selected = this.inactive;
      }
    }

    public ActivatableSlider(Slider active, Slider inactive)
    {
      this.active = active;
      this.inactive = inactive;
      this.selected = active;
    }

    public void Draw(SpriteBatch screen)
    {
      this.selected.Draw(screen);
    }
  }
}
