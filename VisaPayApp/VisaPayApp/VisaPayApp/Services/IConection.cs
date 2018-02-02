using SQLite.Net.Interop;

namespace VisaPayApp.Services
{
    public interface IConection
    {
        string databasePath { get; }

        ISQLitePlatform plataform { get; }


    }
}
