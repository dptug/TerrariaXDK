// Type: Terraria.SfxInstancePool
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Terraria
{
  public sealed class SfxInstancePool
  {
    private uint mLastFramePlayed;
    private short mCurrentIndex;
    private short mMaxInstanceMask;
    private SoundEffectInstance[] mInstances;
    private SoundEffectInstance mCurrentInstance;
    private SoundEffect mSoundEffect;

    public SfxInstancePool(ContentManager content, string name, int maxInstances)
    {
      this.mCurrentIndex = (short) 0;
      this.mMaxInstanceMask = (short) (maxInstances - 1);
      this.mInstances = new SoundEffectInstance[maxInstances];
      this.mSoundEffect = content.Load<SoundEffect>(name);
      for (int index = 0; index < maxInstances; ++index)
        this.mInstances[index] = this.mSoundEffect.CreateInstance();
    }

    public bool IsPlaying()
    {
      if (this.mCurrentInstance != null)
        return this.mCurrentInstance.State == SoundState.Playing;
      else
        return false;
    }

    public void Play(double volume, double pan = 0.0, double pitch = 0.0)
    {
      if ((int) this.mLastFramePlayed == (int) Main.frameCounter)
        return;
      this.mLastFramePlayed = Main.frameCounter;
      SoundEffectInstance soundEffectInstance = this.mInstances[(int) this.mCurrentIndex];
      int index = (int) this.mCurrentIndex + 1 & (int) this.mMaxInstanceMask;
      this.mInstances[index].Stop(true);
      this.mCurrentIndex = (short) index;
      soundEffectInstance.Volume = (float) volume;
      soundEffectInstance.Pan = (float) pan;
      soundEffectInstance.Pitch = (float) pitch;
      soundEffectInstance.Play();
      this.mCurrentInstance = soundEffectInstance;
    }

    public void Update(double volume, double pan = 0.0, double pitch = 0.0)
    {
      if (this.mCurrentInstance == null || this.mCurrentInstance.State != SoundState.Playing)
        return;
      this.mCurrentInstance.Volume = (float) volume;
      this.mCurrentInstance.Pan = (float) pan;
      this.mCurrentInstance.Pitch = (float) pitch;
    }

    public void UpdateOrPlay(double volume, double pan = 0.0, double pitch = 0.0)
    {
      if (this.mCurrentInstance != null && this.mCurrentInstance.State == SoundState.Playing)
      {
        this.mCurrentInstance.Volume = (float) volume;
        this.mCurrentInstance.Pan = (float) pan;
        this.mCurrentInstance.Pitch = (float) pitch;
      }
      else
        this.Play(volume, pan, pitch);
    }
  }
}
