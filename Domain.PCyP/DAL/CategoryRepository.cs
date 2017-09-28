using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Domain.PCyP.Biz;
using Domain.PCyP.DAL;

namespace Domain.PCyP.Data
{
    public class CategoryRepository : BaseRepository, ICrud<Category>
    {

        public void Add(Category category)
        {

            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(category);
                db.Commit();
                db.Close();
            }
        }
        
        public List<Category> All()
        {
            var lista = new List<Category>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category());
                while (result != null && result.HasNext()) lista.Add((Category)result.Next());

                db.Close();
            }
            return lista;
        }

        
        public void Delete(Category model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category { Id = model.Id });
                var proto = (Category)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        

       
        public void Edit(Category model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category { Id = model.Id });
                var proto = (Category)result[0];
                proto.CreatedOn = model.CreatedOn;
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Category Find_id(string id)
        {
            Category proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category { Id = id });
                proto = (Category)result[0];
                db.Close();
            }

            return proto;
        }

        
        public Category Find(Category model)
        {
            Category proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Category)result[0];
                db.Close();
            }
            return proto;
        }
        
        public ParallelQuery<Category> ParallelQuery()
        {
            var lista = new List<Category>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category());
                while (result != null && result.HasNext()) lista.Add((Category)result.Next());
                db.Close();
            }
            return lista.AsParallel();
        }

        //List<Category> ICrud<Category>.All()
        //{
        //    throw new NotImplementedException();
        //}

        //ParallelQuery<Category> ICrud<Category>.ParallelQuery()
        //{
        //    throw new NotImplementedException();
        //}


    }
}