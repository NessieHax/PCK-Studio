﻿using PckStudio.Classes.FileTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Classes.IO
{
    internal class PCKFileWriter
    {
        internal bool isLittleEndian = false;
        internal PCKFile _file;

        public static void Write(Stream stream, PCKFile file, bool isLittleEndian)
        {
            new PCKFileWriter(file, isLittleEndian).WriteFileToStream(stream);
        }

        private PCKFileWriter(PCKFile file, bool isLittleEndian)
        {
            _file = file;
            this.isLittleEndian = isLittleEndian;
        }

        private void WriteFileToStream(Stream stream)
        {
            WriteInt(stream, _file.type);
            WriteMetaEntries(stream);
            WriteFileEntries(stream);
        }

        internal void WriteInt(Stream stream, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian && !isLittleEndian)
                Array.Reverse(buffer);
            stream.Write(buffer, 0, buffer.Length);
        }

        internal void WriteString(Stream stream, string s)
        {
            WriteInt(stream, s.Length);
            byte[] byteString = Encoding.BigEndianUnicode.GetBytes(s);
            stream.Write(byteString, 0, byteString.Length);
        }

        internal void WriteMetaEntries(Stream stream)
        {
            WriteInt(stream, _file.meta_data.Count);
            bool has_xmlverion_tag = false;
            foreach (var metaEntry in _file.meta_data)
            {
                if (metaEntry.Key == "XMLVERION") has_xmlverion_tag = true;
                WriteInt(stream, metaEntry.Value);
                WriteString(stream, metaEntry.Key);
                WriteInt(stream, 0);
            }
            if (has_xmlverion_tag)
                WriteInt(stream, 0);
        }

        internal void WriteFileEntries(Stream stream)
        {
            WriteInt(stream, _file.file_entries.Count);
            foreach (var entry in _file.file_entries)
            {
                WriteInt(stream, entry.size);
                WriteInt(stream, entry.type);
                WriteString(stream, entry.name);
                WriteInt(stream, 0);
            }
            foreach (var entry in _file.file_entries)
            {
                WriteInt(stream, entry.properties.Count);
                foreach (var property in entry.properties)
                {
                    if (!_file.meta_data.ContainsKey(property.Item1))
                        throw new Exception("invalid meta type" + property.Item1);
                    WriteInt(stream, _file.meta_data[property.Item1]);
                    WriteString(stream, property.Item2);
                    WriteInt(stream, 0);
                }
                stream.Write(entry.data, 0, entry.size);
            }
        }

    }
}
