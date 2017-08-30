using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.model
{
    public class Producto
    {
        private int id;
        private string descripcion;
        private double precio;
        private int cantidad;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }


    }
}
