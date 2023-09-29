using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.Utilts
{
    public static class Utilts
    {
        public static string GetUUID()
        {
            var procStartInfo = new ProcessStartInfo("cmd", "/c " + "wmic csproduct get UUID")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var proc = new Process() { StartInfo = procStartInfo };
            proc.Start();

            return proc.StandardOutput.ReadToEnd().Replace("UUID", string.Empty).Trim().ToUpper();
        }
    }
}
