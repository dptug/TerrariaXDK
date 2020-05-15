using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;

namespace Terraria
{
	public static class MessageBox
	{
		public struct Message
		{
			public bool autoUpdate;

			public sbyte playerIndex;

			public string caption;

			public string contents;

			public string[] options;
		}

		public static IAsyncResult mbResult;

		public static Message current;

		private static List<Message> queue;

		public static int? choice;

		static MessageBox()
		{
			mbResult = null;
			queue = new List<Message>();
			current.playerIndex = -1;
		}

		public static void Show(PlayerIndex controller, string caption, string contents, string[] options, bool autoUpdate = true)
		{
			lock (queue)
			{
				Message item = default(Message);
				item.autoUpdate = autoUpdate;
				item.playerIndex = (sbyte)controller;
				item.caption = caption;
				item.contents = contents;
				item.options = options;
				if (current.playerIndex < 0)
				{
					current = item;
				}
				else if (current.contents != contents)
				{
					for (int num = queue.Count - 1; num >= 0; num--)
					{
						if (contents == queue[num].contents)
						{
							return;
						}
					}
					queue.Add(item);
				}
			}
		}

		private static void NextMessage()
		{
			if (queue.Count > 0)
			{
				current = queue[0];
				queue.RemoveAt(0);
			}
			else
			{
				current.autoUpdate = false;
				current.playerIndex = -1;
			}
		}

		public static bool IsVisible()
		{
			return current.playerIndex >= 0;
		}

		public static bool IsAutoUpdate()
		{
			return current.autoUpdate;
		}

		public static bool Update()
		{
			if (current.playerIndex >= 0)
			{
				lock (queue)
				{
					if (!Guide.IsVisible)
					{
						try
						{
							mbResult = Guide.BeginShowMessageBox((PlayerIndex)current.playerIndex, current.caption, current.contents, current.options, 0, MessageBoxIcon.None, null, null);
						}
						catch (GuideAlreadyVisibleException)
						{
						}
					}
					else if (mbResult != null && mbResult.IsCompleted)
					{
						choice = Guide.EndShowMessageBox(mbResult);
						mbResult = null;
						NextMessage();
						return true;
					}
				}
			}
			return false;
		}

		public static int GetResult()
		{
			if (!choice.HasValue)
			{
				return -1;
			}
			return choice.Value;
		}

		public static void RemoveMessagesFor(PlayerIndex controller)
		{
			while ((PlayerIndex)current.playerIndex == controller)
			{
				if (mbResult == null)
				{
					NextMessage();
				}
			}
			for (int num = queue.Count - 1; num >= 0; num--)
			{
				if ((PlayerIndex)queue[num].playerIndex == controller)
				{
					queue.RemoveAt(num);
				}
			}
		}
	}
}
