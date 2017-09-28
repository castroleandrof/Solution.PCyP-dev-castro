using Domain.PCyP.Biz;
using Domain.PCyP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PCyP.BLL
{
    public class StudentBusiness
    {
        public static void Add(Student student)
        {

            student.Id = Guid.NewGuid().ToString();
            student.CreatedOn = DateTime.Now;
            student.ChangedOn = DateTime.Now;
            char c = student.FirstName.FirstOrDefault();
            student.Alias = c + student.LastName;
            var cdal = new StudentRepository();
            cdal.Add(student);

        }


        public static List<Student> GetStudentList()
        {
            var cdal = new StudentRepository();
            return cdal.All();
        }

        public static Student Find(Student student)
        {
            var cdal = new StudentRepository();
            return cdal.Find(student);
        }

        public static void Edit(Student student)
        {
            var cdal = new StudentRepository();
            student.ChangedOn = DateTime.Now;
            cdal.Edit(student);
        }

        public static Student Find_Id(string Id)
        {
            var cdal = new StudentRepository();
            return cdal.Find_id(Id);

        }

        public static void Delete(Biz.Student student)
        {
            var cdal = new StudentRepository();
            cdal.Delete(student);
        }

        public static void Controller()
        {
            string line_nombre, line_apellido;
            System.IO.StreamReader file_apellidos = new System.IO.StreamReader(@"D:\leandro.castro\apellidos.txt");
            System.IO.StreamReader file_nombres = new System.IO.StreamReader(@"D:\leandro.castro\nombres.txt");
            while ((line_nombre = file_nombres.ReadLine()) != null)
            {

                while ((line_apellido = file_apellidos.ReadLine()) != null)
                {
                    Student student = new Student();
                    student.FirstName = line_nombre;
                    student.LastName = line_apellido;
                    Add(student);
                }
            }

        }
    }
}
