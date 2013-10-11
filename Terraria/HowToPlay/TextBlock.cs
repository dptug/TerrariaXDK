// Type: Terraria.HowToPlay.TextBlock
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.HowToPlay
{
  public class TextBlock
  {
    public bool isScrollable;
    private BoxGraphic background;
    private CompiledText text;
    public short minOffsetY;
    private Texture2D textTexture;
    private Color textColor;
    private Color accentColor;
    private Rectangle textArea;
    private Vector2i dialogPosition;

    public TextBlock(ref Rectangle dialogArea, CompiledText text, ref Rectangle textArea, Texture2D background, int borderWidth, Color backColor, Color textColor, Color accentColor)
    {
      this.background = BoxGraphic.Create(dialogArea.Width, dialogArea.Height, background, borderWidth, backColor);
      this.dialogPosition = new Vector2i(dialogArea.X, dialogArea.Y);
      this.text = text;
      this.textArea = textArea;
      this.isScrollable = (int) text.Height > textArea.Height;
      this.minOffsetY = (short) -Math.Max(0, (int) text.Height - textArea.Height);
      this.textColor = textColor;
      this.accentColor = accentColor;
      this.textTexture = (Texture2D) null;
    }

    public void Draw(int ox = 0, int oy = 0, int scrollY = 0)
    {
      Rectangle rectangle1 = this.textArea;
      rectangle1.X = 0;
      rectangle1.Y = -scrollY;
      Rectangle rectangle2 = this.textArea;
      rectangle2.X += ox;
      rectangle2.Y += oy;
      Vector2i position = this.dialogPosition;
      position.X += ox;
      position.Y += oy;
      this.background.Draw(position, 1f);
      Main.spriteBatch.Draw(this.textTexture, rectangle2, new Rectangle?(rectangle1), Color.White);
      if (!this.isScrollable)
        return;
      Rectangle rect = new Rectangle(position.X + (this.background.Width >> 1) - 8, position.Y + 2, 16, 16);
      if (scrollY < 0)
        SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect, SpriteEffects.FlipVertically);
      if (scrollY <= (int) this.minOffsetY)
        return;
      rect.Y = position.Y + this.background.Height - 16 - 2;
      SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect);
    }

    public void GenerateCache(GraphicsDevice graphicsDevice)
    {
      RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, (int) this.text.Width, (int) this.text.Height + Terraria.UI.fontSmallOutline.LineSpacing);
      graphicsDevice.SetRenderTarget(renderTarget);
      graphicsDevice.Clear(Color.Transparent);
      Main.spriteBatch.Begin();
      this.text.Draw(Main.spriteBatch, new Rectangle(0, 0, (int) this.text.Width, (int) this.text.Height), this.textColor, this.accentColor);
      Main.spriteBatch.End();
      graphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.textTexture = (Texture2D) renderTarget;
    }
  }
}
