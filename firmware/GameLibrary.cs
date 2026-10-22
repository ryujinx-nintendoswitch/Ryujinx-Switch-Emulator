// rev-q3mh4o-20261022 GameLibrary.cs
// rev-b8f3c1-20260825 GameLibrary.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace YuzuLauncher
{
    public class GameLibrary
    {
        public class GameEntry
        {
            public string Name      { get; set; }
            public string FilePath  { get; set; }
            public string Extension { get; set; }
            public long   SizeBytes { get; set; }
        }

        private readonly List<string> _directories = new();

        public void AddDirectory(string path)
        {
            if (Directory.Exists(path) && !_directories.Contains(path))
                _directories.Add(path);
        }

        public IEnumerable<GameEntry> Scan()
        {
            foreach (var dir in _directories)
            {
                foreach (var ext in new[] { ".nsp", ".xci", ".nca" })
                {
                    foreach (var file in Directory.GetFiles(dir, $"*{ext}", SearchOption.AllDirectories))
                    {
                        var info = new FileInfo(file);
                        yield return new GameEntry
                        {
                            Name      = Path.GetFileNameWithoutExtension(file),
                            FilePath  = file,
                            Extension = ext,
                            SizeBytes = info.Length,
                        };
                    }
                }
            }
        }
    }
}