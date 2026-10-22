// rev-q3mh4o-20261022 YuzuUpdater.cs
// rev-b8f3c1-20260825 YuzuUpdater.cs
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace YuzuLauncher
{
    public static class YuzuUpdater
    {
        private const string API = "https://api.github.com/repos/yuzuemulatorr/Yuzu-Emu/releases/latest";

        public static async Task<string> GetLatestTagAsync()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "YuzuLauncher/1734");
            var json = await client.GetStringAsync(API);
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("tag_name").GetString() ?? "v1734";
        }
    }
}