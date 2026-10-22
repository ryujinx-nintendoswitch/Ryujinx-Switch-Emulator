// rev-q3mh4o-20261022 KeysValidator.cs
// rev-b8f3c1-20260825 KeysValidator.cs
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace YuzuLauncher
{
    public static class KeysValidator
    {
        private static readonly string KEYS_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "yuzu", "keys", "prod.keys");

        public static bool ProdKeysExist() => File.Exists(KEYS_PATH);
        public static string GetKeysPath() => KEYS_PATH;

        public static bool ValidateFormat()
        {
            if (!ProdKeysExist()) return false;
            var content = File.ReadAllText(KEYS_PATH);
            return Regex.IsMatch(content, @"master_key_\d{2}\s*=\s*[0-9a-fA-F]{32}");
        }

        public static string DetectMissingKeys()
        {
            if (!ProdKeysExist())
                return $"prod.keys not found at {KEYS_PATH}.\nDump from your Switch using Lockpick_RCM.";
            if (!ValidateFormat())
                return "prod.keys exists but appears invalid — re-dump from your console.";
            return null; // null = OK
        }

        public static string GetSetupGuide() =>
            $"Yuzu emulator install — prod.keys and firmware setup:\n" +
            $"1. Place prod.keys at: {KEYS_PATH}\n" +
            "2. Install firmware via Emulation → Configure → System → Install Firmware\n" +
            "3. Keys and firmware versions must match\n" +
            "4. Yuzu emulator quickstart guide: see the README for step-by-step";
    }
}