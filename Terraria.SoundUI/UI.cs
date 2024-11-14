using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.SoundUI;

internal class UI
{
	public struct Icon
	{
		public Texture2D texture;

		public Vector2 position;

		public Rectangle source;

		public Icon(Texture2D texture, Vector2 position, Rectangle source)
		{
			this.texture = texture;
			this.position = position;
			this.source = source;
		}
	}

	private const int SLIDER_SPACE_Y = 10;

	private const float SLIDER_STEPS = 0.05f;

	private Terraria.UI parentUI;

	private Icon soundIcon;

	private Icon musicIcon;

	private ActivatableSlider soundSlider;

	private ActivatableSlider musicSlider;

	private ActivatableSlider selected;

	private float stepSize;

	private int uiDelay;

	public static UI Create(Terraria.UI parentUI)
	{
		int num = Assets.SLIDER_EMPTY_RECT.Height + 10;
		Vector2 vector = new Vector2(300f, 300f);
		Vector2 position = vector + new Vector2(50f, 0f);
		Slider active = new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_RECT, Assets.SLIDER_FULL_RECT, position);
		Slider inactive = new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_INACTIVE_RECT, Assets.SLIDER_FULL_INACTIVE_RECT, position);
		ActivatableSlider activatableSlider = new ActivatableSlider(active, inactive);
		position.Y += num;
		Slider active2 = new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_RECT, Assets.SLIDER_FULL_RECT, position);
		Slider inactive2 = new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_INACTIVE_RECT, Assets.SLIDER_FULL_INACTIVE_RECT, position);
		ActivatableSlider activatableSlider2 = new ActivatableSlider(active2, inactive2);
		Vector2 position2 = vector + new Vector2(0f, Assets.SLIDER_EMPTY_RECT.Height - Assets.SOUND_ICON_RECT.Height);
		Icon icon = new Icon(Assets.SOUND_ICONS, position2, Assets.SOUND_ICON_RECT);
		position2.Y += num;
		Icon icon2 = new Icon(Assets.SOUND_ICONS, position2, Assets.MUSIC_ICON_RECT);
		return new UI(parentUI, icon, icon2, activatableSlider, activatableSlider2, 0.05f);
	}

	public UI(Terraria.UI parentUI, Icon soundIcon, Icon musicIcon, ActivatableSlider soundSlider, ActivatableSlider musicSlider, float stepSize)
	{
		this.parentUI = parentUI;
		this.soundIcon = soundIcon;
		this.musicIcon = musicIcon;
		this.soundSlider = soundSlider;
		this.musicSlider = musicSlider;
		SelectSoundSlider();
		this.stepSize = stepSize;
	}

	public void UpdateVolumes()
	{
		soundSlider.Progress = parentUI.soundVolume;
		musicSlider.Progress = parentUI.musicVolume;
	}

	private void SelectMusicSlider()
	{
		soundSlider.Active = false;
		musicSlider.Active = true;
		selected = musicSlider;
	}

	private void SelectSoundSlider()
	{
		soundSlider.Active = true;
		musicSlider.Active = false;
		selected = soundSlider;
	}

	public void Update()
	{
		if (uiDelay > 0)
		{
			uiDelay--;
			return;
		}
		bool flag = false;
		if (parentUI.IsRightButtonDown())
		{
			selected.Progress += stepSize;
			flag = true;
		}
		if (parentUI.IsLeftButtonDown())
		{
			selected.Progress -= stepSize;
			flag = true;
		}
		if (parentUI.IsUpButtonDown() || parentUI.IsDownButtonDown())
		{
			if (selected == soundSlider)
			{
				SelectMusicSlider();
			}
			else
			{
				SelectSoundSlider();
			}
			flag = true;
		}
		if (flag)
		{
			uiDelay = 12;
			Main.soundVolume = (parentUI.soundVolume = soundSlider.Progress);
			Main.musicVolume = (parentUI.musicVolume = musicSlider.Progress);
			parentUI.settingsDirty = true;
			Main.PlaySound(12);
		}
	}

	public void Draw(SpriteBatch screen)
	{
		screen.Draw(soundIcon.texture, soundIcon.position, (Rectangle?)soundIcon.source, Color.White);
		screen.Draw(musicIcon.texture, musicIcon.position, (Rectangle?)musicIcon.source, Color.White);
		soundSlider.Draw(screen);
		musicSlider.Draw(screen);
	}

	public void ControlDescription(StringBuilder strBuilder)
	{
		if (selected == musicSlider)
		{
			strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MUSIC_VOLUME));
			strBuilder.Append(' ');
		}
		else if (selected == soundSlider)
		{
			strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_SOUND_VOLUME));
			strBuilder.Append(' ');
		}
		strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
	}
}
