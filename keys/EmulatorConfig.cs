// rev-q3mh4o-20261022 EmulatorConfig.cs
// rev-b8f3c1-20260825 EmulatorConfig.cs
using System;
using System.IO;
using System.Text.Json;

namespace YuzuLauncher
{
    public class EmulatorConfig
    {
        public string Renderer   { get; set; } = "Vulkan";
        public string Resolution { get; set; } = "1920x1080";
        public bool   LDNEnabled { get; set; } = true;
        public bool   ShaderCache{ get; set; } = true;
        public int    AudioVolume{ get; set; } = 100;
        public string AndroidFork{ get; set; } = "Eden";

        private static readonly string CONFIG_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "YuzuLauncher", "config.json");

        public static EmulatorConfig Load()
        {
            if (!File.Exists(CONFIG_PATH)) return new EmulatorConfig();
            try { return JsonSerializer.Deserialize<EmulatorConfig>(File.ReadAllText(CONFIG_PATH)) ?? new(); }
            catch { return new EmulatorConfig(); }
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(CONFIG_PATH)!);
            File.WriteAllText(CONFIG_PATH,
                JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}