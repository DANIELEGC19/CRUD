using CRUD.model;
using CRUD.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class frmproducto : Form
    {
        private Producto pr;
        public frmproducto()
        {
            InitializeComponent();
            Mysqlcon.Open();// abrir conexion
            pr = new Producto();

        }

        public void Capturar()
        {
            pr.Id = Convert.ToInt32(txtid.Text);
            pr.Descripcion = txtdesc.Text;
            pr.Precio = Convert.ToDouble(txtprecio.Text);
            pr.Cantidad = Convert.ToInt32(txtcantidad.Text);
        }
        public void Limpiar()
        {
            txtid.Clear();
            txtdesc.Clear();
            txtprecio.Clear();
            txtcantidad.Clear();

            txtid.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Capturar();
            Productodb.Guardar(pr);
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "") return;
            
            int id = Convert.ToInt32(txtid.Text);
            Productodb.Eliminar(id);
            Limpiar();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "") return;
            int id = Convert.ToInt32(txtid.Text);
            pr = Productodb.Buscarid(id);

            if (pr!=null){
                txtdesc.Text = pr.Descripcion;
                txtcantidad.Text = pr.Cantidad+"";
                txtprecio.Text = pr.Precio + "";
            }
            else
            {
                MessageBox.Show("Producto no encontrado");
            }



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
