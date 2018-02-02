using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace VisaPayApp.Model
{
    public class Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CodigoTag { get; set; }
        public string Descricao { get; set; }

    }
}
