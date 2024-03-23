using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMI.Formats.Pck;
using OMI.Workers.Pck;

namespace PckStudio.Internal
{
    internal class PckFileSaveContext
    {
        public readonly string Filename;
        private FileInfo _file;
        private PckFileDirectory _directory;
        public PckFileDirectory Directory => _directory;

        public bool HasChanges { get; set; }

        public PckFileSaveContext(string filepath)
        {
            _file = new FileInfo(filepath);
            _directory = new PckFileDirectory(Path.GetDirectoryName(filepath));
            HasChanges = false;
            Filename = Path.GetFileName(filepath);
        }

        public bool Save(PckFile pckFile, OMI.Endianness endianness)
        {
            try
            {
                var writer = new PckFileWriter(pckFile, endianness);
                writer.WriteToFile(_file.FullName);
                HasChanges = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex, category: $"{nameof(PckFileSaveContext)}.{nameof(Save)}");
                return false;
            }
            return true;
        }

        public bool Exists => _file.Exists;

    }
}