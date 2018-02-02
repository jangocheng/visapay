using System;
using System.Collections.Generic;
using System.Text;

namespace VisaPayApp.Services.IServices
{
    public interface IRepositoryBase<T> where T: class
    {
        void add(T obj);
        void update(T obj);
        IEnumerable<T> Get();
        T GetId();
    }
}
