using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Terraria;

public static class GameMode
{
	private static int cursorY = 2;

	public static void Update()
	{
		if (UI.main.IsBackButtonTriggered())
		{
			UI.main.PrevMenu();
		}
		else if (UI.main.IsButtonTriggered(Buttons.A))
		{
			switch (cursorY)
			{
			case 0:
			{
				UI main2 = UI.main;
				main2.isOnline = !main2.isOnline;
				UI.main.settingsDirty = true;
				break;
			}
			case 1:
			{
				UI main = UI.main;
				main.isInviteOnly = !main.isInviteOnly;
				UI.main.settingsDirty = true;
				break;
			}
			case 2:
				StartGame();
				break;
			}
		}
	}

	public static void UpdateCursor(int dx, int dy)
	{
		if (!UI.main.CanPlayOnline())
		{
			UI.main.isOnline = false;
			cursorY = 2;
		}
		else
		{
			if (dy == 0)
			{
				return;
			}
			Main.PlaySound(12);
			int num = cursorY;
			do
			{
				num += dy;
				if (num < 0)
				{
					num = 2;
				}
				else if (num > 2)
				{
					num = 0;
				}
			}
			while (num == 1 && !UI.main.isOnline);
			cursorY = (byte)num;
		}
	}

	public static void Draw(WorldView view)
	{
		Rectangle rect = default(Rectangle);
		rect.X = (view.viewWidth >> 1) - 190;
		rect.Y = 210;
		rect.Width = 380;
		rect.Height = 168;
		Main.DrawRect(451, rect, 64);
		Color c = Color.White;
		int num = (view.viewWidth >> 1) - 100;
		int num2 = 230;
		bool flag = UI.main.CanPlayOnline();
		if (cursorY == 0)
		{
			view.ui.DrawInventoryCursor(num, num2, 1.0);
		}
		else
		{
			c = (flag ? Color.White : new Color(128, 128, 128, 255));
			SpriteSheet<_sheetSprites>.Draw(451, num, num2, c);
		}
		if (UI.main.isOnline)
		{
			SpriteSheet<_sheetSprites>.Draw(202, num + 10, num2 + 10, c);
		}
		UI.DrawStringLC(UI.fontSmall, Lang.menu[6], num + 60, num2 + 26, c);
		num2 += 64;
		if (cursorY == 1)
		{
			view.ui.DrawInventoryCursor(num, num2, 1.0);
		}
		else
		{
			c = ((flag && UI.main.isOnline) ? Color.White : new Color(128, 128, 128, 255));
			SpriteSheet<_sheetSprites>.Draw(451, num, num2, c);
		}
		if (UI.main.isInviteOnly)
		{
			SpriteSheet<_sheetSprites>.Draw(202, num + 10, num2 + 10, c);
		}
		UI.DrawStringLC(UI.fontSmall, Lang.menu[7], num + 60, num2 + 26, c);
		string text = ((WorldSelect.WorldName() != null) ? Lang.menu[10] : Lang.menu[11]);
		float num3 = 1f;
		if (cursorY == 2)
		{
			num3 *= 1f + UI.cursorAlpha * 0.1f;
			c = new Color(UI.cursorColor.A, UI.cursorColor.A, 100, 255);
		}
		else
		{
			c = new Color(240, 240, 240, 240);
		}
		Vector2 pivot = UI.MeasureString(UI.fontBig, text);
		pivot.X *= 0.5f;
		pivot.Y *= 0.5f;
		UI.DrawStringScaled(pos: new Vector2(view.viewWidth >> 1, 454f), font: UI.fontBig, s: text, c: c, pivot: pivot, scale: num3);
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
		string text = WorldSelect.WorldName();
		if (text == null)
		{
			UI.main.SetMenu(MenuMode.WORLD_SIZE);
			return;
		}
		UI.main.SetMenu(MenuMode.STATUS_SCREEN);
		Main.worldName = text;
		WorldGen.playWorld();
	}
}
