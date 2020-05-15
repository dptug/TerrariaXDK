using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Terraria
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			Marshal.PrelinkAll(typeof(Main));
			ThreadPool.SetMinThreads(0, 0);
			ThreadPool.SetMaxThreads(0, 0);
			using (Main main = new Main())
			{
				try
				{
					main.Run();
				}
				catch (Exception value)
				{
					try
					{
						using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", append: true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(value);
							streamWriter.WriteLine("");
						}
					}
					catch
					{
					}
				}
			}
		}
	}
}
