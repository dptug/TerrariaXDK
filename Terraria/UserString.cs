// Type: Terraria.UserString
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using System;
using System.IO;

namespace Terraria
{
  public sealed class UserString
  {
    public string text;
    public bool isVerified;
    public bool isCensored;
    private IAsyncResult asyncResult;

    public UserString(string s, bool verified)
    {
      this.text = s;
      this.isVerified = verified;
      this.isCensored = false;
      this.asyncResult = (IAsyncResult) null;
    }

    public UserString(BinaryReader input)
    {
      int num = (int) input.ReadByte();
      this.isVerified = (num & 1) != 0;
      this.isCensored = (num & 2) != 0;
      this.text = !this.isCensored ? input.ReadString() : (string) null;
      this.asyncResult = (IAsyncResult) null;
    }

    public static implicit operator UserString(string s)
    {
      return new UserString(s, true);
    }

    public void Write(BinaryWriter output)
    {
      int num = this.isVerified ? 1 : 0;
      if (this.isCensored)
        num |= 2;
      output.Write((byte) num);
      if (this.isCensored)
        return;
      output.Write(this.text);
    }

    public void SetUserString(string s)
    {
      this.text = s;
      this.isVerified = s.Length == 0;
      this.isCensored = false;
    }

    public void SetSystemString(string s)
    {
      this.text = s;
      this.isVerified = true;
      this.isCensored = false;
    }

    public string GetString()
    {
      if (!this.isVerified && this.asyncResult == null && Main.netMode > 0)
        this.asyncResult = StringChecker.BeginCheckString(this.text, new AsyncCallback(this.OnCheckStringDone), (object) null);
      if (this.asyncResult != null)
        return Lang.inter[76];
      if (!this.isCensored)
        return this.text;
      else
        return Lang.inter[77];
    }

    public bool IsEditable()
    {
      if (!this.isVerified)
        return Main.netMode == 0;
      else
        return true;
    }

    private void OnCheckStringDone(object s)
    {
      try
      {
        this.isCensored = !StringChecker.EndCheckString(this.asyncResult);
        this.isVerified = true;
      }
      catch
      {
      }
      this.asyncResult = (IAsyncResult) null;
    }
  }
}
