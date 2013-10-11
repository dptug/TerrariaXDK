// Type: Terraria.Slider
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
  public class Slider
  {
    private Texture2D texture;
    private Rectangle empty;
    private Rectangle filled;
    private Vector2 position;
    private float progress;
    private Rectangle leftComponent;
    private Vector2 rightComponentOffset;
    private Rectangle rightComponent;

    public float Progress
    {
      get
      {
        return this.progress;
      }
      set
      {
        this.progress = value;
        if ((double) this.progress < 0.0)
          this.progress = 0.0f;
        else if ((double) this.progress > 1.0)
          this.progress = 1f;
        this.leftComponent = this.filled;
        this.leftComponent.Width = (int) ((double) this.leftComponent.Width * (double) this.progress);
        this.rightComponent = this.empty;
        this.rightComponent.Width = (int) ((double) this.rightComponent.Width * (1.0 - (double) this.progress));
        this.rightComponent.X = this.leftComponent.Width;
        this.rightComponentOffset = new Vector2((float) this.leftComponent.Width, 0.0f);
      }
    }

    public Slider(Texture2D texture, Rectangle empty, Rectangle filled, Vector2 position)
    {
      this.texture = texture;
      this.empty = empty;
      this.filled = filled;
      this.position = position;
      this.Progress = 0.0f;
    }

    public void Draw(SpriteBatch screen)
    {
      screen.Draw(this.texture, this.position, new Rectangle?(this.leftComponent), Color.White);
      screen.Draw(this.texture, this.position + this.rightComponentOffset, new Rectangle?(this.rightComponent), Color.White);
    }
  }
}
