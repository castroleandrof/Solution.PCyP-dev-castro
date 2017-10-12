using Domain.PCyP.Biz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PCyP.BLL
{
    class CargarDatos
    {

        public static void Controller()
        {
            ArrayList apellidos = new ArrayList();
            ArrayList nombres = new ArrayList();
            string line_nombre, line_apellido;
            System.IO.StreamReader file_nombres = new System.IO.StreamReader(@"D:\leandro.castro\nombres.txt");
            while ((line_nombre = file_nombres.ReadLine()) != null)
            {
                nombres.Add(line_nombre);
            }
            file_nombres.Close();
            System.IO.StreamReader file_apellidos = new System.IO.StreamReader(@"D:\leandro.castro\apellidos.txt");
            while ((line_apellido = file_apellidos.ReadLine()) != null)
            {
                apellidos.Add(line_apellido);
            }

            file_apellidos.Close();

            for (int i = 0; i < apellidos.Count; i++)
            {
                for (int j = 0; j < nombres.Count; j++)
                {
                    Student s = new Student();
                    s.FirstName = (String)nombres[j];
                    s.LastName = (String)apellidos[i];
                    StudentBusiness.Add(s);
                }
            }


        }
    }
}
