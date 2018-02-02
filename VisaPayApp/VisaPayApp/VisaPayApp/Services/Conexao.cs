using System;
using SQLite.Net;
using VisaPayApp.Model;
using Xamarin.Forms;

namespace VisaPayApp.Services
{
    public class Conexao
    {
        public readonly SQLiteConnection _conexao;

        public Conexao()
        {
            try
            {
                var con = DependencyService.Get<IConection>();
                _conexao = new SQLiteConnection(con.plataform, 
                    System.IO.Path.Combine(con.databasePath, "visapay.db"));
                _conexao.CreateTable<Pessoa>();
                _conexao.CreateTable<Dispositivo>();
                _conexao.CreateTable<Cartao>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
        
        
    }
}
