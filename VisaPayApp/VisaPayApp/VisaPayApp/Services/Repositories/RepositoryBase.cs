using System.Collections.Generic;
using VisaPayApp.Services;
using VisaPayApp.Services.IServices;

namespace VisaPayApp.Droid.Services.Repositories
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class 
    {
        public Conexao Db = new Conexao();
        
        public void add(T obj)
        {
            Db._conexao.Insert(obj);
        }

        public void update(T obj)
        {
            Db._conexao.Update(obj);
        }

        public IEnumerable<T> Get()
        {
           return Db._conexao.Table<T>();
        }

        public T GetId()
        {
            return Db._conexao.Table<T>().FirstOrDefault();
        }
    }
}
