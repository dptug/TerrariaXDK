// Type: StorageDeviceManager
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using System;

public class StorageDeviceManager : GameComponent
{
  public bool isDone = true;
  private bool wasDeviceConnected;
  private bool showDeviceSelector;
  public StorageDevice Device;
  public PlayerIndex? Player;
  public PlayerIndex PlayerToPrompt;
  public int RequiredBytes;

  public event EventHandler DeviceSelected;

  public event EventHandler<EventArgs> DeviceSelectorCanceled;

  public event EventHandler<EventArgs> DeviceDisconnected;

  public StorageDeviceManager(Game game)
    : this(game, new PlayerIndex?(), 0)
  {
  }

  public StorageDeviceManager(Game game, PlayerIndex player)
    : this(game, player, 0)
  {
  }

  public StorageDeviceManager(Game game, int requiredBytes)
    : this(game, new PlayerIndex?(), requiredBytes)
  {
  }

  public StorageDeviceManager(Game game, PlayerIndex player, int requiredBytes)
    : this(game, new PlayerIndex?(player), requiredBytes)
  {
  }

  private StorageDeviceManager(Game game, PlayerIndex? player, int requiredBytes)
    : base(game)
  {
    this.Player = player;
    this.RequiredBytes = requiredBytes;
    this.PlayerToPrompt = PlayerIndex.One;
  }

  public void PromptForDevice()
  {
    if (!this.isDone)
      return;
    this.isDone = false;
    this.showDeviceSelector = true;
  }

  public override void Update(GameTime gameTime)
  {
    bool flag = false;
    if (this.Device != null)
    {
      flag = this.Device.IsConnected;
      if (!flag)
      {
        if (this.wasDeviceConnected)
          this.FireDeviceDisconnectedEvent();
      }
    }
    try
    {
      if (!Guide.IsVisible)
      {
        if (this.showDeviceSelector)
        {
          this.showDeviceSelector = false;
          if (this.Player.HasValue)
            StorageDevice.BeginShowSelector(this.Player.Value, this.RequiredBytes, 0, new AsyncCallback(this.deviceSelectorCallback), (object) null);
          else
            StorageDevice.BeginShowSelector(this.RequiredBytes, 0, new AsyncCallback(this.deviceSelectorCallback), (object) null);
        }
      }
    }
    catch (GamerServicesNotAvailableException ex)
    {
    }
    catch (GuideAlreadyVisibleException ex)
    {
    }
    this.wasDeviceConnected = flag;
  }

  private void deviceSelectorCallback(IAsyncResult ar)
  {
    this.Device = StorageDevice.EndShowSelector(ar);
    if (this.Device != null)
    {
      if (this.DeviceSelected != null)
        this.DeviceSelected((object) this, (EventArgs) null);
      this.wasDeviceConnected = true;
    }
    else
    {
      if (this.DeviceSelectorCanceled != null)
        this.DeviceSelectorCanceled((object) this, (EventArgs) null);
      this.showDeviceSelector = false;
    }
    this.isDone = true;
  }

  private void FireDeviceDisconnectedEvent()
  {
    this.Device = (StorageDevice) null;
    if (this.DeviceDisconnected != null)
      this.DeviceDisconnected((object) this, (EventArgs) null);
    this.showDeviceSelector = false;
  }
}
