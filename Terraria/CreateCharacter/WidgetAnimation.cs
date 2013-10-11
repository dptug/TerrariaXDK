// Type: Terraria.CreateCharacter.WidgetAnimation
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter
{
  public class WidgetAnimation
  {
    private Vector2 startPosition;
    private Vector2 delta;
    private float progress;
    private float speed;

    public bool Finished
    {
      get
      {
        return (double) this.progress >= 1.0;
      }
    }

    public Vector2 Position
    {
      get
      {
        return this.startPosition + this.delta * this.progress;
      }
    }

    public float Alpha
    {
      get
      {
        return this.progress;
      }
    }

    public WidgetAnimation(Vector2 startPosition, Vector2 endPosition, float speed)
    {
      this.startPosition = startPosition;
      this.delta = endPosition - startPosition;
      this.speed = speed;
      this.progress = 0.0f;
    }

    public void Start()
    {
      this.progress = 0.0f;
    }

    public void Update()
    {
      this.progress += this.speed;
      if ((double) this.progress < 1.0)
        return;
      this.progress = 1f;
    }
  }
}
