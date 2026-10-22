// rev-q3mh4o-20261022 ForkDownloader.cs
// rev-b8f3c1-20260825 ForkDownloader.cs
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace YuzuLauncher
{
    public static class ForkDownloader
    {
        private const string EDEN_API    = "https://api.github.com/repos/eden-emulator/eden/releases/latest";
        private const string SUDACHI_API = "https://api.github.com/repos/sudachi-emu/sudachi/releases/latest";

        private static readonly HttpClient _http = new HttpClient();

        static ForkDownloader()
        {
            _http.DefaultRequestHeaders.Add("User-Agent", "YuzuLauncher");
        }

        /// <summary>
        /// Yuzu emulator Android APK forks: Eden is the most active in 2026.
        /// </summary>
        public static async Task<string> GetEdenLatestAsync()
        {
            var json = await _http.GetStringAsync(EDEN_API);
            var tag  = System.Text.Json.JsonDocument.Parse(json)
                           .RootElement.GetProperty("tag_name").GetString();
            return tag ?? "unknown";
        }

        public static async Task<string> GetSudachiLatestAsync()
        {
            var json = await _http.GetStringAsync(SUDACHI_API);
            var tag  = System.Text.Json.JsonDocument.Parse(json)
                           .RootElement.GetProperty("tag_name").GetString();
            return tag ?? "unknown";
        }
    }
}