using Microsoft.Xna.Framework;

namespace Terraria.CreateCharacter;

public class WidgetAnimation
{
	private Vector2 startPosition;

	private Vector2 delta;

	private float progress;

	private float speed;

	public bool Finished => progress >= 1f;

	public Vector2 Position => startPosition + delta * progress;

	public float Alpha => progress;

	public WidgetAnimation(Vector2 startPosition, Vector2 endPosition, float speed)
	{
		this.startPosition = startPosition;
		delta = endPosition - startPosition;
		this.speed = speed;
		progress = 0f;
	}

	public void Start()
	{
		progress = 0f;
	}

	public void Update()
	{
		progress += speed;
		if (progress >= 1f)
		{
			progress = 1f;
		}
	}
}
