// Type: Terraria.GameMode
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Terraria
{
  public static class GameMode
  {
    private static int cursorY = 2;

    static GameMode()
    {
    }

    public static void Update()
    {
      if (UI.main.IsBackButtonTriggered())
      {
        UI.main.PrevMenu(-1);
      }
      else
      {
        if (!UI.main.IsButtonTriggered(Buttons.A))
          return;
        switch (GameMode.cursorY)
        {
          case 0:
            UI ui1 = UI.main;
            int num1 = !ui1.isOnline ? 1 : 0;
            ui1.isOnline = num1 != 0;
            UI.main.settingsDirty = true;
            break;
          case 1:
            UI ui2 = UI.main;
            int num2 = !ui2.isInviteOnly ? 1 : 0;
            ui2.isInviteOnly = num2 != 0;
            UI.main.settingsDirty = true;
            break;
          case 2:
            GameMode.StartGame();
            break;
        }
      }
    }

    public static void UpdateCursor(int dx, int dy)
    {
      if (!UI.main.CanPlayOnline())
      {
        UI.main.isOnline = false;
        GameMode.cursorY = 2;
      }
      else
      {
        if (dy == 0)
          return;
        Main.PlaySound(12);
        int num = GameMode.cursorY;
        do
        {
          num += dy;
          if (num < 0)
            num = 2;
          else if (num > 2)
            num = 0;
        }
        while (num == 1 && !UI.main.isOnline);
        GameMode.cursorY = (int) (byte) num;
      }
    }

    public static void Draw(WorldView view)
    {
      Main.DrawRect(451, new Rectangle()
      {
        X = ((int) view.viewWidth >> 1) - 190,
        Y = 210,
        Width = 380,
        Height = 168
      }, 64, 0);
      Color c = Color.White;
      int x = ((int) view.viewWidth >> 1) - 100;
      int y1 = 230;
      bool flag = UI.main.CanPlayOnline();
      if (GameMode.cursorY == 0)
      {
        view.ui.DrawInventoryCursor(x, y1, 1.0, (int) byte.MaxValue);
      }
      else
      {
        c = flag ? Color.White : new Color(128, 128, 128, (int) byte.MaxValue);
        SpriteSheet<_sheetSprites>.Draw(451, x, y1, c);
      }
      if (UI.main.isOnline)
        SpriteSheet<_sheetSprites>.Draw(202, x + 10, y1 + 10, c);
      UI.DrawStringLC(UI.fontSmall, Lang.menu[6], x + 60, y1 + 26, c);
      int y2 = y1 + 64;
      if (GameMode.cursorY == 1)
      {
        view.ui.DrawInventoryCursor(x, y2, 1.0, (int) byte.MaxValue);
      }
      else
      {
        c = !flag || !UI.main.isOnline ? new Color(128, 128, 128, (int) byte.MaxValue) : Color.White;
        SpriteSheet<_sheetSprites>.Draw(451, x, y2, c);
      }
      if (UI.main.isInviteOnly)
        SpriteSheet<_sheetSprites>.Draw(202, x + 10, y2 + 10, c);
      UI.DrawStringLC(UI.fontSmall, Lang.menu[7], x + 60, y2 + 26, c);
      string str = WorldSelect.WorldName() != null ? Lang.menu[10] : Lang.menu[11];
      float scale = 1f;
      if (GameMode.cursorY == 2)
      {
        scale *= (float) (1.0 + (double) UI.cursorAlpha * 0.100000001490116);
        c = new Color((int) UI.cursorColor.A, (int) UI.cursorColor.A, 100, (int) byte.MaxValue);
      }
      else
        c = new Color(240, 240, 240, 240);
      Vector2 pivot = UI.MeasureString(UI.fontBig, str);
      pivot.X *= 0.5f;
      pivot.Y *= 0.5f;
      Vector2 pos = new Vector2((float) ((int) view.viewWidth >> 1), 454f);
      UI.DrawStringScaled(UI.fontBig, str, pos, c, pivot, scale);
    }

    public static void ControlDescription(StringBuilder strBuilder)
    {
      strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
      strBuilder.Append(' ');
      strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
    }

    private static void StartGame()
    {
      Main.PlaySound(10);
      string str = WorldSelect.WorldName();
      if (str == null)
      {
        UI.main.SetMenu(MenuMode.WORLD_SIZE, true, false);
      }
      else
      {
        UI.main.SetMenu(MenuMode.STATUS_SCREEN, true, false);
        Main.worldName = str;
        WorldGen.playWorld();
      }
    }
  }
}
