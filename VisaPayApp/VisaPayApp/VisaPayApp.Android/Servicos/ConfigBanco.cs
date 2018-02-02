using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using System.IO;
using VisaPayApp.Droid.Servicos;
using VisaPayApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ConfigBanco))]

namespace VisaPayApp.Droid.Servicos
{
    public class ConfigBanco: IConection
    {
        public ConfigBanco() { }
        public string _databasePath;
        public string databasePath
        {
            get
            {
                if (String.IsNullOrEmpty(_databasePath))
                {
                    _databasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    if (!File.Exists(_databasePath))
                    {
                        File.Create(_databasePath);
                    }
                }

                return _databasePath;
            }
        }

        public ISQLitePlatform _plataform;
        public ISQLitePlatform plataform {
            get
            {
                if (plataform == null)
                {
                    _plataform = new SQLitePlatformAndroid();
                }

                return _plataform;
            }}


    }
}