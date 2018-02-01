using System;
using System.Collections.Generic;
using System.Text;

namespace VisaPayApp.Model
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int DiaVencimento { get; set; }
        public int AnoVencimento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodigoSeguranca { get; set; }

    }
}
