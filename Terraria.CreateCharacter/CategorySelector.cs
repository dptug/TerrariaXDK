using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.CreateCharacter
{
	internal class CategorySelector
	{
		private enum ScrollDirection
		{
			PREVIOUS = -1,
			NEXT = 1
		}

		private const float SCROLL_SPEED = 0.075f;

		private const float UNSELECTED_SIZE = 0.75f;

		private Texture2D[] options;

		private Texture2D background;

		private Texture2D backgroundSelected;

		private Vector2 spacing;

		public float ScrollTween;

		public bool Scrolling;

		private ScrollDirection scrollDirection;

		private int previouslySelected;

		private int selected;

		public int SelectedIndex
		{
			get
			{
				return selected;
			}
			set
			{
				int val = Math.Max(0, value);
				val = (selected = Math.Min(options.Length - 1, val));
			}
		}

		public CategorySelector(Texture2D[] options, Texture2D background, Texture2D backgroundSelected, Vector2 spacing)
		{
			this.options = options;
			this.background = background;
			this.backgroundSelected = backgroundSelected;
			this.spacing = spacing;
			selected = 0;
			Scrolling = false;
			ScrollTween = 0f;
			scrollDirection = ScrollDirection.PREVIOUS;
			previouslySelected = 0;
		}

		public void Update()
		{
			if (Scrolling)
			{
				ScrollTween -= 0.075f;
				if (ScrollTween < 0f)
				{
					Scrolling = false;
					ScrollTween = 0f;
				}
			}
		}

		public void Draw(Vector2 position)
		{
			Vector2 origin = new Vector2(background.Width >> 1, background.Height >> 1);
			Vector2 origin2 = new Vector2(backgroundSelected.Width >> 1, backgroundSelected.Height >> 1);
			int num = 4;
			int num2 = num * 2 + 1;
			int num3 = num + 1;
			for (int num4 = num2; num4 > 0; num4--)
			{
				int num5 = selected - num3 + num4;
				if (num5 < 0)
				{
					num5 += options.Length;
				}
				else if (num5 >= options.Length)
				{
					num5 -= options.Length;
				}
				float num6 = (float)num - Math.Abs((float)(num4 - num3) + ScrollTween * (float)scrollDirection);
				float val = 1f - 0.25f * Math.Abs((float)(num4 - num3) + ScrollTween * (float)scrollDirection);
				val = Math.Max(0.75f, val);
				if (!(num6 < 0f) && !(val < 0f))
				{
					Texture2D texture2D = options[num5];
					Vector2 origin3 = new Vector2(texture2D.Width >> 1, texture2D.Height >> 1);
					Vector2 value = spacing * ScrollTween * (float)scrollDirection;
					Vector2 position2 = position + spacing * (num4 - num3) + value;
					if (num5 == selected)
					{
						Main.spriteBatch.Draw(backgroundSelected, position2, null, Color.White * num6, 0f, origin2, val, SpriteEffects.None, 0f);
					}
					else
					{
						Main.spriteBatch.Draw(background, position2, null, Color.White * num6, 0f, origin, 1f, SpriteEffects.None, 0f);
					}
					Main.spriteBatch.Draw(texture2D, position2, null, Color.White * num6, 0f, origin3, 1f, SpriteEffects.None, 0f);
				}
			}
			if (!Scrolling)
			{
				Vector2 value2 = spacing * ((float)num - 0.25f);
				Vector2 vector = position - value2 - new Vector2(8f, 8f);
				Rectangle rect = new Rectangle((int)vector.X, (int)vector.Y, 16, 16);
				SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
				Vector2 vector2 = position + value2 - new Vector2(8f, 8f);
				rect.X = (int)vector2.X;
				rect.Y = (int)vector2.Y;
				SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
			}
		}

		private void StartScrolling(ScrollDirection direction)
		{
			Scrolling = true;
			ScrollTween = 1f;
			scrollDirection = direction;
		}

		public bool SelectNext()
		{
			bool result = false;
			if (!Scrolling)
			{
				previouslySelected = selected;
				selected++;
				if (selected >= options.Length)
				{
					selected -= options.Length;
				}
				result = true;
				StartScrolling(ScrollDirection.NEXT);
			}
			return result;
		}

		public bool SelectPrevious()
		{
			bool result = false;
			if (!Scrolling)
			{
				previouslySelected = selected;
				selected--;
				if (selected < 0)
				{
					selected += options.Length;
				}
				result = true;
				StartScrolling(ScrollDirection.PREVIOUS);
			}
			return result;
		}
	}
}
