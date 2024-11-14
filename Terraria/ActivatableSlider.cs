using Microsoft.Xna.Framework.Graphics;

namespace Terraria;

public class ActivatableSlider
{
	private Slider selected;

	private Slider active;

	private Slider inactive;

	public float Progress
	{
		get
		{
			return active.Progress;
		}
		set
		{
			active.Progress = value;
			inactive.Progress = value;
		}
	}

	public bool Active
	{
		get
		{
			return selected == active;
		}
		set
		{
			if (value)
			{
				selected = active;
			}
			else
			{
				selected = inactive;
			}
		}
	}

	public ActivatableSlider(Slider active, Slider inactive)
	{
		this.active = active;
		this.inactive = inactive;
		selected = active;
	}

	public void Draw(SpriteBatch screen)
	{
		selected.Draw(screen);
	}
}
