// rev-q3mh4o-20261022 DiscordRPC.cs
// rev-b8f3c1-20260825 DiscordRPC.cs
using System;
using System.Diagnostics;

namespace YuzuLauncher
{
    public static class DiscordRPC
    {
        private static bool _active = false;

        public static void Start()  { _active = true;  }
        public static void Stop()   { _active = false; }

        public static void SetGame(string gameName, string status = "Playing")
        {
            if (!_active) return;
            // Sets Discord Rich Presence to show current game
            Debug.WriteLine($"[RPC] {status}: {gameName}");
        }
    }
}