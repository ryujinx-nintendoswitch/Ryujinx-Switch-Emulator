// rev-q3mh4o-20261022 EmulatorLauncher.cs
// rev-b8f3c1-20260825 EmulatorLauncher.cs
using System;
using System.Diagnostics;
using System.IO;

namespace YuzuLauncher
{
    /// <summary>
    /// Launches the Yuzu emulator executable.
    /// Yuzu emulator download path configured on first run.
    /// </summary>
    public static class EmulatorLauncher
    {
        public static void Launch(string yuzuExePath, string romPath = null)
        {
            if (!File.Exists(yuzuExePath))
                throw new FileNotFoundException("Yuzu executable not found.", yuzuExePath);

            var args = romPath != null ? $"\"{romPath}\"" : string.Empty;
            var psi = new ProcessStartInfo(yuzuExePath, args)
            {
                UseShellExecute  = true,
                WorkingDirectory = Path.GetDirectoryName(yuzuExePath),
            };
            Process.Start(psi);
        }

        public static bool IsRunning() =>
            Process.GetProcessesByName("yuzu").Length > 0 ||
            Process.GetProcessesByName("yuzu-cmd").Length > 0;

        public static string FindYuzuExe()
        {
            // Common install locations
            var candidates = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "yuzu", "yuzu-windows-msvc", "yuzu.exe"),
                Path.Combine(AppContext.BaseDirectory, "yuzu.exe"),
                Path.Combine(AppContext.BaseDirectory, "publish", "yuzu.exe"),
            };
            foreach (var c in candidates)
                if (File.Exists(c)) return c;
            return null;
        }
    }
}