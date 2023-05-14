﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PckStudio.Forms.Utilities;

namespace PckStudio
{
    static class Program
    {
        public static readonly string ProjectUrl = "https://github.com/PhoenixARC/-PCK-Studio";
        public static readonly string BaseAPIUrl = "http://api.pckstudio.xyz/api/pck";
        public static readonly string BackUpAPIUrl = "https://raw.githubusercontent.com/PhoenixARC/pckstudio.tk/main/studio/PCK/api/";
        public static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PCK-Studio");
        public static readonly string AppDataCache = Path.Combine(AppData, "cache");

        public static MainForm MainInstance { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            ApplicationScope.Initialize();
            MainInstance = new MainForm();
            if (args.Length > 0 && File.Exists(args[0]) && args[0].EndsWith(".pck"))
                MainInstance.LoadPckFromFile(args[0]);
            Application.Run(MainInstance);
        }
    }
}
