using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter;

public interface ISelector
{
	void Draw(Vector2 position, float alpha);

	void Update();

	bool SelectLeft();

	bool SelectRight();

	bool SelectUp();

	bool SelectDown();

	void SetCursor(Vector2i cursor);

	void Reset();

	void Show();

	void FlashSelection(int duration);

	void CancelSelection();
}
