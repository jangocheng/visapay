using VisaPayApp.Services.Repositories;

namespace VisaPayApp.Services
{
    public class ValidaLogin
    {
        public PessoaRepository _conexao { get; set; }

        public ValidaLogin()
        {
            _conexao = new PessoaRepository();
        }
        public bool Login()
        {
            
            if (_conexao.Validalogin())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
