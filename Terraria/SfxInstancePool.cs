using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Terraria;

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
		mCurrentIndex = 0;
		mMaxInstanceMask = (short)(maxInstances - 1);
		mInstances = new SoundEffectInstance[maxInstances];
		mSoundEffect = content.Load<SoundEffect>(name);
		for (int i = 0; i < maxInstances; i++)
		{
			mInstances[i] = mSoundEffect.CreateInstance();
		}
	}

	public bool IsPlaying()
	{
		if (mCurrentInstance != null)
		{
			return mCurrentInstance.State == SoundState.Playing;
		}
		return false;
	}

	public void Play(double volume, double pan = 0.0, double pitch = 0.0)
	{
		if (mLastFramePlayed != Main.frameCounter)
		{
			mLastFramePlayed = Main.frameCounter;
			SoundEffectInstance soundEffectInstance = mInstances[mCurrentIndex];
			int num = (mCurrentIndex + 1) & mMaxInstanceMask;
			mInstances[num].Stop(immediate: true);
			mCurrentIndex = (short)num;
			soundEffectInstance.Volume = (float)volume;
			soundEffectInstance.Pan = (float)pan;
			soundEffectInstance.Pitch = (float)pitch;
			soundEffectInstance.Play();
			mCurrentInstance = soundEffectInstance;
		}
	}

	public void Update(double volume, double pan = 0.0, double pitch = 0.0)
	{
		if (mCurrentInstance != null && mCurrentInstance.State == SoundState.Playing)
		{
			mCurrentInstance.Volume = (float)volume;
			mCurrentInstance.Pan = (float)pan;
			mCurrentInstance.Pitch = (float)pitch;
		}
	}

	public void UpdateOrPlay(double volume, double pan = 0.0, double pitch = 0.0)
	{
		if (mCurrentInstance != null && mCurrentInstance.State == SoundState.Playing)
		{
			mCurrentInstance.Volume = (float)volume;
			mCurrentInstance.Pan = (float)pan;
			mCurrentInstance.Pitch = (float)pitch;
		}
		else
		{
			Play(volume, pan, pitch);
		}
	}
}
