using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.CreateCharacter
{
	public class DifficultySelector : ISelector
	{
		private enum Direction
		{
			PREVIOUS = -1,
			NEXT = 1
		}

		private const float TRANSITION_SPEED = 0.1f;

		private const int DESCRIPTION_ID_START = 29;

		private const int TITLE_ID_START = 24;

		private const int MAX_DIFFICULTY = 2;

		private const int ARROW_OFFSET = 10;

		private static Vector2 TITLE_OFFSET = new Vector2(0f, -50f);

		private static Vector2 DESCRIPTION_OFFSET = new Vector2(0f, 50f);

		private static Vector2 SLIDE_OFFSET = new Vector2(120f, 0f);

		public Difficulty Selected;

		private Difficulty ResetValue;

		private Texture2D[] DifficultyIcons;

		private int FlashTimer;

		private float TransitionTween;

		private Direction TransitionDirection;

		private Difficulty PreviousSelected;

		public DifficultySelector(Texture2D[] difficultyIcons, Difficulty resetValue)
		{
			DifficultyIcons = difficultyIcons;
			ResetValue = resetValue;
			Selected = resetValue;
			TransitionTween = 0f;
		}

		public void Draw(Vector2 position, float alpha)
		{
			SpriteFont fontSmallOutline = Terraria.UI.fontSmallOutline;
			if (TransitionTween > 0f)
			{
				float num = 1f - Math.Min(TransitionTween, 0.5f) / 0.5f;
				float num2 = (Math.Max(0.5f, TransitionTween) - 0.5f) / 0.5f;
				DrawDescription(PreviousSelected, position, alpha * num2);
				DrawDescription(Selected, position, alpha * num);
				int transitionDirection = (int)TransitionDirection;
				Vector2 position2 = position + TITLE_OFFSET - SLIDE_OFFSET * (1f - TransitionTween) * transitionDirection;
				DrawTitle(PreviousSelected, position2, 1f, TransitionTween);
				Vector2 position3 = position + TITLE_OFFSET + SLIDE_OFFSET * TransitionTween * transitionDirection;
				DrawTitle(Selected, position3, 1f, 1f - TransitionTween);
			}
			else
			{
				DrawTitle(Selected, position + TITLE_OFFSET, 1f + 0.1f * (float)FlashTimer, alpha);
				string text = Lang.menu[(int)(26 - Selected)];
				Vector2 vector = Terraria.UI.MeasureString(fontSmallOutline, text);
				if (alpha > 0.9f)
				{
					DrawArrows(position + TITLE_OFFSET, new Vector2(vector.X * 0.5f + 10f, 0f));
				}
				DrawDescription(Selected, position, alpha);
			}
		}

		private void DrawTitle(Difficulty setting, Vector2 position, float scale, float alpha)
		{
			SpriteFont fontSmallOutline = Terraria.UI.fontSmallOutline;
			string text = Lang.menu[(int)(26 - setting)];
			Vector2 pivot = Terraria.UI.MeasureString(fontSmallOutline, text);
			pivot.X = (float)Math.Round((double)pivot.X * 0.5);
			pivot.Y = (float)Math.Round((double)pivot.Y * 0.5);
			Color value = (setting != Difficulty.HARDCORE) ? Color.White : Color.Red;
			Terraria.UI.DrawString(fontSmallOutline, text, position, value * alpha, 0f, pivot, scale);
		}

		private void DrawArrows(Vector2 position, Vector2 spacing)
		{
			Vector2 vector = position - spacing - new Vector2(8f, 8f);
			Rectangle rect = new Rectangle((int)vector.X, (int)vector.Y, 16, 16);
			SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
			Vector2 vector2 = position + spacing - new Vector2(8f, 8f);
			rect.X = (int)vector2.X;
			rect.Y = (int)vector2.Y;
			SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
		}

		private void DrawDescription(Difficulty difficulty, Vector2 position, float alpha)
		{
			Texture2D texture2D = DifficultyIcons[(int)difficulty];
			Vector2 origin = new Vector2(texture2D.Width >> 1, texture2D.Height >> 1);
			Main.spriteBatch.Draw(texture2D, position, null, Color.White * alpha, 0f, origin, 1f + 0.1f * (float)FlashTimer, SpriteEffects.None, 0f);
			string text = Lang.menu[(int)(31 - difficulty)];
			SpriteFont fontSmallOutline = Terraria.UI.fontSmallOutline;
			Vector2 pivot = Terraria.UI.MeasureString(fontSmallOutline, text);
			pivot.X = (float)Math.Round((double)pivot.X * 0.5);
			pivot.Y = (float)Math.Round((double)pivot.Y * 0.5);
			Terraria.UI.DrawString(fontSmallOutline, text, position + DESCRIPTION_OFFSET, Color.White * alpha, 0f, pivot, 1f);
		}

		public void Update()
		{
			if (TransitionTween > 0f)
			{
				TransitionTween -= 0.1f;
			}
			else
			{
				TransitionTween = 0f;
			}
			if (FlashTimer > 0)
			{
				FlashTimer--;
			}
		}

		public bool SelectLeft()
		{
			PreviousSelected = Selected;
			int selected = (int)Selected;
			selected--;
			if (selected < 0)
			{
				selected = 2;
			}
			Selected = (Difficulty)selected;
			TransitionTween = 1f;
			TransitionDirection = Direction.PREVIOUS;
			return true;
		}

		public bool SelectRight()
		{
			PreviousSelected = Selected;
			int selected = (int)Selected;
			selected++;
			if (selected > 2)
			{
				selected = 0;
			}
			Selected = (Difficulty)selected;
			TransitionTween = 1f;
			TransitionDirection = Direction.NEXT;
			return true;
		}

		public bool SelectUp()
		{
			return false;
		}

		public bool SelectDown()
		{
			return false;
		}

		public void SetCursor(Vector2i cursor)
		{
			int val = Math.Max(cursor.X, 0);
			int num = (int)(Selected = (Difficulty)Math.Min(val, 2));
		}

		public void Reset()
		{
			Selected = ResetValue;
		}

		public void Show()
		{
			ResetValue = Selected;
			FlashTimer = 0;
		}

		public void FlashSelection(int duration)
		{
			FlashTimer = duration;
		}

		public void CancelSelection()
		{
			Selected = ResetValue;
		}
	}
}
