using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.PCyP.Biz;

namespace Domain.PCyP.DAL
{
    public interface ICrud<T> where T : class
    {
    
        void Add(T model);
        
        void Edit(T model);
        
        void Delete(T model);
        
        T Find(T model);
        ParallelQuery<T> ParallelQuery();
        
        List<T> All();
    }
}