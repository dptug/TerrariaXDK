// Type: Terraria.MessageBox
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;

namespace Terraria
{
  public static class MessageBox
  {
    public static IAsyncResult mbResult = (IAsyncResult) null;
    private static List<MessageBox.Message> queue = new List<MessageBox.Message>();
    public static MessageBox.Message current;
    public static int? choice;

    static MessageBox()
    {
      MessageBox.current.playerIndex = (sbyte) -1;
    }

    public static void Show(PlayerIndex controller, string caption, string contents, string[] options, bool autoUpdate = true)
    {
      lock (MessageBox.queue)
      {
        MessageBox.Message local_0;
        local_0.autoUpdate = autoUpdate;
        local_0.playerIndex = (sbyte) controller;
        local_0.caption = caption;
        local_0.contents = contents;
        local_0.options = options;
        if ((int) MessageBox.current.playerIndex < 0)
        {
          MessageBox.current = local_0;
        }
        else
        {
          if (!(MessageBox.current.contents != contents))
            return;
          for (int local_1 = MessageBox.queue.Count - 1; local_1 >= 0; --local_1)
          {
            if (contents == MessageBox.queue[local_1].contents)
              return;
          }
          MessageBox.queue.Add(local_0);
        }
      }
    }

    private static void NextMessage()
    {
      if (MessageBox.queue.Count > 0)
      {
        MessageBox.current = MessageBox.queue[0];
        MessageBox.queue.RemoveAt(0);
      }
      else
      {
        MessageBox.current.autoUpdate = false;
        MessageBox.current.playerIndex = (sbyte) -1;
      }
    }

    public static bool IsVisible()
    {
      return (int) MessageBox.current.playerIndex >= 0;
    }

    public static bool IsAutoUpdate()
    {
      return MessageBox.current.autoUpdate;
    }

    public static bool Update()
    {
      if ((int) MessageBox.current.playerIndex >= 0)
      {
        lock (MessageBox.queue)
        {
          if (!Guide.IsVisible)
          {
            try
            {
              MessageBox.mbResult = Guide.BeginShowMessageBox((PlayerIndex) MessageBox.current.playerIndex, MessageBox.current.caption, MessageBox.current.contents, (IEnumerable<string>) MessageBox.current.options, 0, MessageBoxIcon.None, (AsyncCallback) null, (object) null);
            }
            catch (GuideAlreadyVisibleException exception_0)
            {
            }
          }
          else if (MessageBox.mbResult != null)
          {
            if (MessageBox.mbResult.IsCompleted)
            {
              MessageBox.choice = Guide.EndShowMessageBox(MessageBox.mbResult);
              MessageBox.mbResult = (IAsyncResult) null;
              MessageBox.NextMessage();
              return true;
            }
          }
        }
      }
      return false;
    }

    public static int GetResult()
    {
      if (!MessageBox.choice.HasValue)
        return -1;
      else
        return MessageBox.choice.Value;
    }

    public static void RemoveMessagesFor(PlayerIndex controller)
    {
      while ((PlayerIndex) MessageBox.current.playerIndex == controller)
      {
        if (MessageBox.mbResult == null)
          MessageBox.NextMessage();
      }
      for (int index = MessageBox.queue.Count - 1; index >= 0; --index)
      {
        if ((PlayerIndex) MessageBox.queue[index].playerIndex == controller)
          MessageBox.queue.RemoveAt(index);
      }
    }

    public struct Message
    {
      public bool autoUpdate;
      public sbyte playerIndex;
      public string caption;
      public string contents;
      public string[] options;
    }
  }
}
