using VisaPayApp.Droid.Services.Repositories;
using VisaPayApp.Model;
using VisaPayApp.Services.IServices;

namespace VisaPayApp.Services.Repositories
{
    public class PessoaRepository: RepositoryBase<Pessoa>, IPessoaRepository
    {
        public bool Validalogin()
        {
            if (Db._conexao != null && 
                Db._conexao.Table<Pessoa>() != null
                && Db._conexao.Table<Pessoa>().First().Nome != null)
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
