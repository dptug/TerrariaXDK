// Type: Terraria.Program
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

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
      Marshal.PrelinkAll(typeof (Main));
      ThreadPool.SetMinThreads(0, 0);
      ThreadPool.SetMaxThreads(0, 0);
      using (Main main = new Main())
      {
        try
        {
          main.Run();
        }
        catch (Exception ex)
        {
          try
          {
            using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
            {
              streamWriter.WriteLine((object) DateTime.Now);
              streamWriter.WriteLine((object) ex);
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
