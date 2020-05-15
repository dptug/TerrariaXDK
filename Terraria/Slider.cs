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
				return progress;
			}
			set
			{
				progress = value;
				if (progress < 0f)
				{
					progress = 0f;
				}
				else if (progress > 1f)
				{
					progress = 1f;
				}
				leftComponent = filled;
				leftComponent.Width = (int)((float)leftComponent.Width * progress);
				rightComponent = empty;
				rightComponent.Width = (int)((float)rightComponent.Width * (1f - progress));
				rightComponent.X = leftComponent.Width;
				rightComponentOffset = new Vector2(leftComponent.Width, 0f);
			}
		}

		public Slider(Texture2D texture, Rectangle empty, Rectangle filled, Vector2 position)
		{
			this.texture = texture;
			this.empty = empty;
			this.filled = filled;
			this.position = position;
			Progress = 0f;
		}

		public void Draw(SpriteBatch screen)
		{
			screen.Draw(texture, position, leftComponent, Color.White);
			screen.Draw(texture, position + rightComponentOffset, rightComponent, Color.White);
		}
	}
}
