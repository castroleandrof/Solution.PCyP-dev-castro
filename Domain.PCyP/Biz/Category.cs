using Domain.PCyP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PCyP.Biz
{
    public class Category : EntityBase
    {
        public String name { get; set; }
        public string RowGuid { get; set; }

        public Category()
        {
          
            //Id = CategoryBusiness.GetCategoryList().Count;
        }
    }
}
