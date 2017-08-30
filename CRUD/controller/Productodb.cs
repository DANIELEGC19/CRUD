using CRUD.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.controller
{
    public class Productodb
    {
        private static String SQL;

        public static void Guardar(Producto pr)
        {
            SQL = "INSERT INTO productos VALUES (" + pr.Id + ",'" + pr.Descripcion 
                + "'," + pr.Precio + "," + pr.Cantidad + ")";

            if (Mysqlcon.Exceute(SQL))
            {
                MessageBox.Show("Registro guardado");
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }
        }// end guardar

        public static void Eliminar(int id)
        {
            SQL = "DELETE FROM productos WHERE id=" + id;

            if (Mysqlcon.Exceute(SQL))
            {
                MessageBox.Show("Registro Borrado");
            }
            else
            {
                MessageBox.Show("Error al Borrar");
            }
        }

        public static Producto Buscarid(int id)
        {
            Producto pr = null;
            SQL = "SELECT * FROM productos WHERE id=" + id;

            MySqlDataReader reg = Mysqlcon.Query(SQL);

            if (reg.Read())
            {
                pr = new Producto();
                pr.Id = id;
                pr.Descripcion = reg["descripcion"].ToString();
                pr.Precio = Convert.ToDouble(reg["precio"].ToString());
                pr.Cantidad = Convert.ToInt32(reg["cantidad"].ToString());

            }

            return pr;

            


  
        }
        
    }
}
