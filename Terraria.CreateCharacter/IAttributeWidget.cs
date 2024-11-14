using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter;

public interface IAttributeWidget
{
	string ControlDescription { get; }

	string WidgetDescription { get; }

	void Draw(Vector2 position, float alpha);

	void Update();

	bool SelectLeft();

	bool SelectRight();

	bool SelectUp();

	bool SelectDown();

	void Back();

	void SetCursor(Vector2i cursor);

	void Apply(Player player);

	void Reset();

	void Show();

	void FlashSelection(int duration);
}
