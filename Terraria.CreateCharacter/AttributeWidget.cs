using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter
{
	public abstract class AttributeWidget<T> where T : ISelector
	{
		protected T widget;

		public string WidgetDescription
		{
			get;
			protected set;
		}

		public string ControlDescription
		{
			get;
			protected set;
		}

		internal AttributeWidget()
		{
		}

		public virtual void Draw(Vector2 position, float alpha)
		{
			widget.Draw(position, alpha);
		}

		public void Update()
		{
			widget.Update();
		}

		public bool SelectLeft()
		{
			return widget.SelectLeft();
		}

		public bool SelectRight()
		{
			return widget.SelectRight();
		}

		public bool SelectUp()
		{
			return widget.SelectUp();
		}

		public bool SelectDown()
		{
			return widget.SelectDown();
		}

		public virtual void SetCursor(Vector2i cursor)
		{
			widget.SetCursor(cursor);
		}

		public void Reset()
		{
			widget.Reset();
		}

		public void Back()
		{
			widget.CancelSelection();
		}

		public void Show()
		{
			widget.Show();
		}

		public void FlashSelection(int duration)
		{
			widget.FlashSelection(duration);
		}
	}
}
