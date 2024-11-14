using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;

public class StorageDeviceManager : GameComponent
{
	private bool wasDeviceConnected;

	private bool showDeviceSelector;

	public bool isDone = true;

	public StorageDevice Device;

	public PlayerIndex? Player;

	public PlayerIndex PlayerToPrompt;

	public int RequiredBytes;

	public event EventHandler DeviceSelected;

	public event EventHandler<EventArgs> DeviceSelectorCanceled;

	public event EventHandler<EventArgs> DeviceDisconnected;

	public StorageDeviceManager(Game game)
		: this(game, null, 0)
	{
	}

	public StorageDeviceManager(Game game, PlayerIndex player)
		: this(game, player, 0)
	{
	}

	public StorageDeviceManager(Game game, int requiredBytes)
		: this(game, null, requiredBytes)
	{
	}

	public StorageDeviceManager(Game game, PlayerIndex player, int requiredBytes)
		: this(game, (PlayerIndex?)player, requiredBytes)
	{
	}

	private StorageDeviceManager(Game game, PlayerIndex? player, int requiredBytes)
		: base(game)
	{
		Player = player;
		RequiredBytes = requiredBytes;
		PlayerToPrompt = PlayerIndex.One;
	}

	public void PromptForDevice()
	{
		if (isDone)
		{
			isDone = false;
			showDeviceSelector = true;
		}
	}

	public override void Update(GameTime gameTime)
	{
		bool flag = false;
		if (Device != null)
		{
			flag = Device.IsConnected;
			if (!flag && wasDeviceConnected)
			{
				FireDeviceDisconnectedEvent();
			}
		}
		try
		{
			if (!Guide.IsVisible && showDeviceSelector)
			{
				showDeviceSelector = false;
				if (Player.HasValue)
				{
					StorageDevice.BeginShowSelector(Player.Value, RequiredBytes, 0, (AsyncCallback)deviceSelectorCallback, (object)null);
				}
				else
				{
					StorageDevice.BeginShowSelector(RequiredBytes, 0, (AsyncCallback)deviceSelectorCallback, (object)null);
				}
			}
		}
		catch (GamerServicesNotAvailableException)
		{
		}
		catch (GuideAlreadyVisibleException)
		{
		}
		wasDeviceConnected = flag;
	}

	private void deviceSelectorCallback(IAsyncResult ar)
	{
		Device = StorageDevice.EndShowSelector(ar);
		if (Device != null)
		{
			if (this.DeviceSelected != null)
			{
				this.DeviceSelected(this, null);
			}
			wasDeviceConnected = true;
		}
		else
		{
			if (this.DeviceSelectorCanceled != null)
			{
				this.DeviceSelectorCanceled(this, null);
			}
			showDeviceSelector = false;
		}
		isDone = true;
	}

	private void FireDeviceDisconnectedEvent()
	{
		Device = null;
		if (this.DeviceDisconnected != null)
		{
			this.DeviceDisconnected(this, null);
		}
		showDeviceSelector = false;
	}
}
