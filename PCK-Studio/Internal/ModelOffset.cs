﻿using System;
using System.Linq;
using System.IO;
using PckStudio.Extensions;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PckStudio.Internal
{
    internal readonly struct ModelOffset
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        internal static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }

        private static readonly string[] ValidModelOffsetTypes = new string[]
        {
            // Body Offsets
            "HEAD",
            "BODY",
            "ARM0",
            "ARM1",
            "LEG0",
            "LEG1",

            // Armor Offsets
            "HELMET",
            "CHEST", "BODYARMOR",
            "SHOULDER0", "ARMARMOR0",
            "SHOULDER1", "ARMARMOR1",
            "BELT",
            "LEGGING0",
            "LEGGING1",
            "SOCK0", "BOOT0",
            "SOCK1", "BOOT1",

            "TOOL0",
            "TOOL1",
        };

        public readonly string Name;
        public readonly float Value;

        public ModelOffset(string name, float value)
        {
            Name = name;
            Value = value;
        }

        public static ModelOffset FromString(string offsetFormatString)
        {
            string[] offset = ReplaceWhitespace(offsetFormatString.TrimEnd('\n', '\r', ' '), ",").Split(',');
            if (offset.Length < 3)
                throw new InvalidDataException("Format string does not contain enough data.");

            string name = offset[0];

            if (!ValidModelOffsetTypes.Contains(name))
            {
                Debug.WriteLine($"'{name}' is an invalid offset type.");
            }

            // Ignore => Y assumed
            //if (offset[1] != "Y")

            if (!float.TryParse(offset[2], out float value))
            {
                Debug.WriteLine($"Failed to parse y offset for: '{name}'");
            }
            return new ModelOffset(name, value);
        }

        public (string, string) ToProperty()
        {
            string value = $"{Name} Y {Value}";
            return ("OFFSET", value.Replace(',', '.'));
        }
    }
}