using Domain.PCyP.Biz;
using Domain.PCyP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PCyP.BLL
{
    public class CategoryBusiness
    {
       
        public static void Add(Category categoria)
        {

            categoria.Id = Guid.NewGuid().ToString();
            categoria.CreatedOn = DateTime.Now;
            categoria.ChangedOn = DateTime.Now;
            var cdal = new CategoryRepository();
            cdal.Add(categoria);

        }

        public static List<Category> GetCategoryList()
        {
            var cdal = new CategoryRepository();
            return cdal.All();
        }

        public static Category Find(Category categoria)
        {
            var cdal = new CategoryRepository();
            return cdal.Find(categoria);
        }

        public static void Edit(Category categoria)
        {
            var cdal = new CategoryRepository(); 
            categoria.ChangedOn = DateTime.Now;
            cdal.Edit(categoria);
        }

        public static Category Find_Id(string Id)
        {
            var cdal = new CategoryRepository();
           return cdal.Find_id(Id);
           
        }

        public static void Delete(Category categoria)
        {
            var cdal = new CategoryRepository();
            cdal.Delete(categoria);
        }


    }
}
