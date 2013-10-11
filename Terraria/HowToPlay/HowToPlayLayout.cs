// Type: Terraria.HowToPlay.HowToPlayLayout
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.HowToPlay
{
  public class HowToPlayLayout
  {
    private static Color TEXT_COLOR = Color.White;
    private static Color ACCENT_COLOR = new Color((int) byte.MaxValue, 212, 64, (int) byte.MaxValue);
    private static Color BACK_COLOR = Terraria.UI.DEFAULT_DIALOG_COLOR;
    private const int MAX_HEIGHT = 454;
    public TextBlock textblock;
    private HowToPlayLayout.Image[] images;

    static HowToPlayLayout()
    {
    }

    private HowToPlayLayout(TextBlock textblock)
    {
      this.textblock = textblock;
      this.images = new HowToPlayLayout.Image[0];
    }

    private HowToPlayLayout(TextBlock textblock, HowToPlayLayout.Image[] images)
    {
      this.textblock = textblock;
      this.images = images;
    }

    public static HowToPlayLayout TextOnlyLayout(string text, int width)
    {
      int borderWidth = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
      int val2 = 454;
      CompiledText text1 = new CompiledText(text, width - borderWidth * 2, Terraria.UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
      int height = Math.Min((int) text1.Height + Terraria.UI.fontSmallOutline.LineSpacing + borderWidth * 2, val2);
      Rectangle dialogArea = new Rectangle(864 - width >> 1, 454 - height >> 1, width, height);
      Rectangle textArea = dialogArea;
      textArea.Inflate(-borderWidth, -borderWidth);
      return new HowToPlayLayout(new TextBlock(ref dialogArea, text1, ref textArea, Assets.TEXT_BACKGROUND, borderWidth, HowToPlayLayout.BACK_COLOR, HowToPlayLayout.TEXT_COLOR, HowToPlayLayout.ACCENT_COLOR));
    }

    public static HowToPlayLayout SideBySideLayout(string text, int width, Texture2D image, int padding = 20)
    {
      int borderWidth = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
      int val2 = 454;
      CompiledText text1 = new CompiledText(text, width - borderWidth * 2, Terraria.UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
      int height = Math.Min((int) text1.Height + Terraria.UI.fontSmallOutline.LineSpacing + borderWidth * 2, val2);
      int x = 864 - (image.Width + padding + width) >> 1;
      int y = 454 - height >> 1;
      Rectangle dialogArea = new Rectangle(x, y, width, height);
      Rectangle textArea = dialogArea;
      textArea.Inflate(-borderWidth, -borderWidth);
      TextBlock textblock = new TextBlock(ref dialogArea, text1, ref textArea, Assets.TEXT_BACKGROUND, borderWidth, HowToPlayLayout.BACK_COLOR, HowToPlayLayout.TEXT_COLOR, HowToPlayLayout.ACCENT_COLOR);
      int num1 = x + (width + padding);
      int num2 = 454 - image.Height >> 1;
      HowToPlayLayout.Image[] images = new HowToPlayLayout.Image[1]
      {
        new HowToPlayLayout.Image()
        {
          Position = new Vector2((float) num1, (float) num2),
          Texture = image
        }
      };
      return new HowToPlayLayout(textblock, images);
    }

    public static HowToPlayLayout StackedLayout(string text, int width, int height, Texture2D image, int padding = 20)
    {
      int borderWidth = Assets.TEXT_BACKGROUND_BORDER_WIDTH;
      CompiledText text1 = new CompiledText(text, width - borderWidth * 2, Terraria.UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
      height = Math.Min((int) text1.Height + Terraria.UI.fontSmallOutline.LineSpacing + borderWidth * 2, height);
      int num1 = height + padding + image.Height;
      int x = 864 - (int) text1.Width >> 1;
      int y = 454 - num1 >> 1;
      Rectangle dialogArea = new Rectangle(x, y, width, height);
      Rectangle textArea = dialogArea;
      textArea.Inflate(-borderWidth, -borderWidth);
      TextBlock textblock = new TextBlock(ref dialogArea, text1, ref textArea, Assets.TEXT_BACKGROUND, borderWidth, HowToPlayLayout.BACK_COLOR, HowToPlayLayout.TEXT_COLOR, HowToPlayLayout.ACCENT_COLOR);
      int num2 = 864 - image.Width >> 1;
      int num3 = y + (height + padding);
      HowToPlayLayout.Image[] images = new HowToPlayLayout.Image[1]
      {
        new HowToPlayLayout.Image()
        {
          Position = new Vector2((float) num2, (float) num3),
          Texture = image
        }
      };
      return new HowToPlayLayout(textblock, images);
    }

    public void Draw(int offsetX, int offsetY, int scrollY)
    {
      this.textblock.Draw(offsetX, offsetY, scrollY);
      foreach (HowToPlayLayout.Image image in this.images)
      {
        Vector2 position = image.Position;
        position.X += (float) offsetX;
        position.Y += (float) offsetY;
        Main.spriteBatch.Draw(image.Texture, position, Color.White);
      }
    }

    public void GenerateCache(GraphicsDevice graphicsDevice)
    {
      this.textblock.GenerateCache(graphicsDevice);
    }

    private struct Image
    {
      public Vector2 Position;
      public Texture2D Texture;
    }
  }
}
