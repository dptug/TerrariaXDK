using System;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;

namespace Terraria;

public sealed class UserString
{
	public string text;

	public bool isVerified;

	public bool isCensored;

	private IAsyncResult asyncResult;

	public static implicit operator UserString(string s)
	{
		return new UserString(s, verified: true);
	}

	public UserString(string s, bool verified)
	{
		text = s;
		isVerified = verified;
		isCensored = false;
		asyncResult = null;
	}

	public UserString(BinaryReader input)
	{
		int num = input.ReadByte();
		isVerified = (num & 1) != 0;
		isCensored = (num & 2) != 0;
		if (isCensored)
		{
			text = null;
		}
		else
		{
			text = input.ReadString();
		}
		asyncResult = null;
	}

	public void Write(BinaryWriter output)
	{
		int num = (isVerified ? 1 : 0);
		if (isCensored)
		{
			num |= 2;
		}
		output.Write((byte)num);
		if (!isCensored)
		{
			output.Write(text);
		}
	}

	public void SetUserString(string s)
	{
		text = s;
		isVerified = s.Length == 0;
		isCensored = false;
	}

	public void SetSystemString(string s)
	{
		text = s;
		isVerified = true;
		isCensored = false;
	}

	public string GetString()
	{
		if (!isVerified && asyncResult == null && Main.netMode > 0)
		{
			asyncResult = StringChecker.BeginCheckString(text, OnCheckStringDone, null);
		}
		if (asyncResult != null)
		{
			return Lang.inter[76];
		}
		if (!isCensored)
		{
			return text;
		}
		return Lang.inter[77];
	}

	public bool IsEditable()
	{
		if (!isVerified)
		{
			return Main.netMode == 0;
		}
		return true;
	}

	private void OnCheckStringDone(object s)
	{
		try
		{
			isCensored = !StringChecker.EndCheckString(asyncResult);
			isVerified = true;
		}
		catch
		{
		}
		asyncResult = null;
	}
}
