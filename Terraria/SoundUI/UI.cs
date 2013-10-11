// Type: Terraria.SoundUI.UI
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Terraria;

namespace Terraria.SoundUI
{
  internal class UI
  {
    private const int SLIDER_SPACE_Y = 10;
    private const float SLIDER_STEPS = 0.05f;
    private Terraria.UI parentUI;
    private UI.Icon soundIcon;
    private UI.Icon musicIcon;
    private ActivatableSlider soundSlider;
    private ActivatableSlider musicSlider;
    private ActivatableSlider selected;
    private float stepSize;
    private int uiDelay;

    public UI(Terraria.UI parentUI, UI.Icon soundIcon, UI.Icon musicIcon, ActivatableSlider soundSlider, ActivatableSlider musicSlider, float stepSize)
    {
      this.parentUI = parentUI;
      this.soundIcon = soundIcon;
      this.musicIcon = musicIcon;
      this.soundSlider = soundSlider;
      this.musicSlider = musicSlider;
      this.SelectSoundSlider();
      this.stepSize = stepSize;
    }

    public static UI Create(Terraria.UI parentUI)
    {
      int num = Assets.SLIDER_EMPTY_RECT.Height + 10;
      Vector2 vector2 = new Vector2(300f, 300f);
      Vector2 position1 = vector2 + new Vector2(50f, 0.0f);
      ActivatableSlider soundSlider = new ActivatableSlider(new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_RECT, Assets.SLIDER_FULL_RECT, position1), new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_INACTIVE_RECT, Assets.SLIDER_FULL_INACTIVE_RECT, position1));
      position1.Y += (float) num;
      ActivatableSlider musicSlider = new ActivatableSlider(new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_RECT, Assets.SLIDER_FULL_RECT, position1), new Slider(Assets.SLIDER, Assets.SLIDER_EMPTY_INACTIVE_RECT, Assets.SLIDER_FULL_INACTIVE_RECT, position1));
      Vector2 position2 = vector2 + new Vector2(0.0f, (float) (Assets.SLIDER_EMPTY_RECT.Height - Assets.SOUND_ICON_RECT.Height));
      UI.Icon soundIcon = new UI.Icon(Assets.SOUND_ICONS, position2, Assets.SOUND_ICON_RECT);
      position2.Y += (float) num;
      UI.Icon musicIcon = new UI.Icon(Assets.SOUND_ICONS, position2, Assets.MUSIC_ICON_RECT);
      return new UI(parentUI, soundIcon, musicIcon, soundSlider, musicSlider, 0.05f);
    }

    public void UpdateVolumes()
    {
      this.soundSlider.Progress = this.parentUI.soundVolume;
      this.musicSlider.Progress = this.parentUI.musicVolume;
    }

    private void SelectMusicSlider()
    {
      this.soundSlider.Active = false;
      this.musicSlider.Active = true;
      this.selected = this.musicSlider;
    }

    private void SelectSoundSlider()
    {
      this.soundSlider.Active = true;
      this.musicSlider.Active = false;
      this.selected = this.soundSlider;
    }

    public void Update()
    {
      if (this.uiDelay > 0)
      {
        --this.uiDelay;
      }
      else
      {
        bool flag = false;
        if (this.parentUI.IsRightButtonDown())
        {
          this.selected.Progress += this.stepSize;
          flag = true;
        }
        if (this.parentUI.IsLeftButtonDown())
        {
          this.selected.Progress -= this.stepSize;
          flag = true;
        }
        if (this.parentUI.IsUpButtonDown() || this.parentUI.IsDownButtonDown())
        {
          if (this.selected == this.soundSlider)
            this.SelectMusicSlider();
          else
            this.SelectSoundSlider();
          flag = true;
        }
        if (!flag)
          return;
        this.uiDelay = 12;
        Main.soundVolume = this.parentUI.soundVolume = this.soundSlider.Progress;
        Main.musicVolume = this.parentUI.musicVolume = this.musicSlider.Progress;
        this.parentUI.settingsDirty = true;
        Main.PlaySound(12);
      }
    }

    public void Draw(SpriteBatch screen)
    {
      screen.Draw(this.soundIcon.texture, this.soundIcon.position, new Rectangle?(this.soundIcon.source), Color.White);
      screen.Draw(this.musicIcon.texture, this.musicIcon.position, new Rectangle?(this.musicIcon.source), Color.White);
      this.soundSlider.Draw(screen);
      this.musicSlider.Draw(screen);
    }

    public void ControlDescription(StringBuilder strBuilder)
    {
      if (this.selected == this.musicSlider)
      {
        strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MUSIC_VOLUME));
        strBuilder.Append(' ');
      }
      else if (this.selected == this.soundSlider)
      {
        strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_SOUND_VOLUME));
        strBuilder.Append(' ');
      }
      strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
    }

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
  }
}
