using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Internals
{
    internal class PckFileDirectory
    {
        private DirectoryInfo _directory;

        public PckFileDirectory(string path)
        {
            _directory = new DirectoryInfo(path);
        }

        public DirectoryInfo GetDataDirectory()
        {
            return new DirectoryInfo(GetDataPath());
        }

        public string GetDataPath()
        {
            return Path.Combine(_directory.FullName, "Data");
        }

        public bool HasDataFolder()
        {
            return Directory.Exists(GetDataPath());
        }

        public string Name => _directory.Name;

        public bool Exists => _directory.Exists;
    }
}
