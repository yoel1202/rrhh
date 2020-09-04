using RRHH.CONEXION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRHH
{
    public partial class Frm_departamentos : Form
    {
        public Frm_departamentos()
        {
            InitializeComponent();
        }
        public BDconeccion conexion;
        private bool seleccionarusuario = false;
        private int ID_usuario;
        private void Frm_usuario_Load(object sender, EventArgs e)
        {
            // oculta elementos de la interfaz  como los botones de guardar actualizar y eliminar
            Button1.Hide();
            Button2.Hide();
            Button3.Hide();
            Button4.Hide();
            pictureBox1.Hide();
            PictureBox3.SetBounds(this.Width - 80, 25, PictureBox3.Width, PictureBox3.Height);
            Label6.Hide();
            DataGridView1.Hide();
            ComboBox1.SelectedIndex = 0;
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Label6.Hide();
            Panel1.Size = new Size(45, 727);
            pictureBox1.Hide();
            Button1.Hide();
            Button2.Hide();
            Button3.Hide();
            Button4.Hide();
            PictureBox2.Show();
            DataGridView1.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Panel1.Size = new Size(136, 727);

            Button1.Show();
            Button2.Show();
            Button3.Show();
            Button4.Show();
            pictureBox1.Show();
            Label6.Show();

            PictureBox2.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            frm_inicio f1 = (frm_inicio)Application.OpenForms["frm_inicio"];
            f1.pn_principal.Controls.Clear();
            f1.pn_principal.Hide();





        }
        public bool validartexbox( TextBox tb)
        {
            if (tb.Text == "")
                return false;
            else
                return true;
        }
        // cumple la funcion de guardar se llama el metodo querycomando de la clase conexion para insertar los datos 
        private void Button1_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_codigo) & validartexbox(tb_nombre) )
            {
                if (conexion.querycomando("Insert into tbl_departamentos(nombre,codigo) VALUES('" + tb_nombre.Text + "','" + tb_codigo.Text + "')"))
                    MessageBox.Show("Se ha guardado correctamente");
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                actualizardato();
                tb_codigo.Clear();
                tb_nombre.Clear();
              
         
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }
        public void actualizardato()
        {
            DataSet data = conexion.sqlconsulta("Select id_departamento,nombre,codigo from tbl_departamentos");
            if (data.Tables.Count > 0)
            {
                DataGridView1.DataSource = data.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_codigo) & validartexbox(tb_nombre)  )
            {
                if (seleccionarusuario)
                {
                    if (conexion.querycomando("Update tbl_departamentos set codigo='" + tb_codigo.Text + "',nombre='" + tb_nombre.Text + "'  WHERE id_departamento='" + ID_usuario.ToString() + "'"))
                        MessageBox.Show("Se ha actualizado correctamente");
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarusuario = false;
                actualizardato();
                tb_codigo.Clear();
                tb_nombre.Clear();
              
               
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (seleccionarusuario)
            {
                if (conexion.querycomando("DELETE FROM tbl_departamentos WHERE id_departamento='" + ID_usuario.ToString() + "' "))
                    MessageBox.Show("Se ha eliminado correctamente");
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                tb_codigo.Clear();
                tb_nombre.Clear();
               
              
              
                actualizardato();
                seleccionarusuario = false;
            }
            else
                MessageBox.Show("Seleccione un empleado de la lista");
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarusuario = true;
                ID_usuario =int.Parse( DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_nombre.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_codigo.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                

            }
            catch (Exception ex)
            {
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DataGridView1.Show();
        actualizardato();
        }

        private void tb_busqueda_TextChanged(object sender, EventArgs e)
        {
            if (tb_busqueda.Text != "")
            {
                if (ComboBox1.SelectedIndex == 0)
                {
                    DataSet ds = conexion.sqlconsulta("Select id_departamento,nombre,codigo from tbl_departamentos WHERE nombre LIKE '" + tb_busqueda.Text + "%'");
                    DataGridView1.DataSource = ds.Tables[0];
                    DataGridView1.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_departamento,nombre,codigo from tbl_departamentos");
                DataGridView1.DataSource = ds.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
