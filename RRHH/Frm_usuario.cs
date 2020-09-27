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
    public partial class Frm_usuario : Form
    {
        public Frm_usuario()
        {
            InitializeComponent();
        }
        public BDconeccion conexion;
        private bool seleccionarusuario = false;
        private int ID_usuario;
        public int usuario;
        private void Frm_usuario_Load(object sender, EventArgs e)
        {
            // oculta elementos de la interfaz
            Button1.Hide();
            Button2.Hide();
            Button3.Hide();
            Button4.Hide();
            pictureBox1.Hide();
            PictureBox3.SetBounds(this.Width - 80, 25, PictureBox3.Width, PictureBox3.Height);
            Label6.Hide();
            //DataGridView1.Hide();
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
           
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Si o No", "¿ Esta seguro que desea hacer esta accion ?",
  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
  MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                // cumple la funcion de guardar se llama el metodo querycomando de la clase conexion para insertar los datos 
                if (validartexbox(tb_contra) & validartexbox(tb_usuario) & validartexbox(tb_cedula) & validartexbox(tb_nombre))
                {
                    if (conexion.querycomando("Insert into tbl_usuarios(usuario,pass,tipo,cedula,nombre) VALUES('" + tb_usuario.Text + "','" + tb_contra.Text + "','" + ComboBox2.SelectedItem.ToString() + "','" + tb_cedula.Text + "','" + tb_nombre.Text + "')"))
                        MessageBox.Show("Se ha guardado correctamente");
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                    actualizardato();
                    tb_contra.Clear();
                    tb_usuario.Clear();

                    tb_nombre.Clear();
                    tb_cedula.Clear();
                    ComboBox2.SelectedIndex = 0;

                }
                else
                    MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
            }
        }
        //esta funcion actualiza los datos del tabla cuando se inserte se actualize o se elimine
        public void actualizardato()
        {
            DataSet data = conexion.sqlconsulta("Select id_usuario,usuario as 'USUARIO',pass AS 'CONTRASEÑA',tipo AS 'TIPO',nombre As NOMBRE, cedula AS CEDULA, foto AS FOTO from tbl_usuarios  ");
            if (data.Tables.Count > 0)
            {
                DataGridView1.DataSource = data.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }
        // cumple la funcion de actualizar se llama el metodo querycomando de la clase conexion para actualizar los datos 
        private void Button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Si o No", "¿ Esta seguro que desea hacer esta accion ?",
  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
  MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                if (validartexbox(tb_contra) & validartexbox(tb_usuario) & validartexbox(tb_nombre) & validartexbox(tb_cedula))
                {
                    if (seleccionarusuario)
                    {
                        if (conexion.querycomando("Update tbl_usuarios set usuario='" + tb_usuario.Text + "',pass='" + tb_contra.Text + "',tipo='" + ComboBox2.SelectedItem.ToString() + "',cedula='" + tb_cedula.Text + "',nombre='" + tb_nombre.Text + "' WHERE id_usuario='" + ID_usuario.ToString() + "'"))
                            MessageBox.Show("Se ha actualizado correctamente");
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                    else
                        MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                    seleccionarusuario = false;
                    actualizardato();
                    tb_contra.Clear();
                    tb_usuario.Clear();

                    tb_nombre.Clear();
                    tb_cedula.Clear();
                    ComboBox2.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
            }
        }
        // cumple la funcion de eliminar se llama el metodo querycomando de la clase conexion para eliminar los datos 
        private void Button2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Si o No", "¿ Esta seguro que desea hacer esta accion ?",
  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
  MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                if (seleccionarusuario)
                {
                    if (conexion.querycomando("DELETE FROM tbl_usuarios WHERE id_usuario='" + ID_usuario.ToString() + "' "))
                        MessageBox.Show("Se ha eliminado correctamente");
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                    tb_contra.Clear();
                    tb_usuario.Clear();

                    tb_nombre.Clear();
                    tb_cedula.Clear();
                    ComboBox2.SelectedIndex = 0;
                    actualizardato();
                    seleccionarusuario = false;
                }
                else
                    MessageBox.Show("Seleccione un empleado de la lista");
            }
        }
        // medoto seleciona los datos de la datgrieview y los pones en los campos para cumplir con la funcionar actualizar y eliminar
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarusuario = true;
                ID_usuario =int.Parse( DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_usuario.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_contra.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                ComboBox2.SelectedItem = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_cedula.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                tb_nombre.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                
             

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

        // busca los datos en la data grieview por medio de los parametro del combo box
        private void tb_busqueda_TextChanged(object sender, EventArgs e)
        {
            if (tb_busqueda.Text != "")
            {
                if (ComboBox1.SelectedIndex == 0)
                {
                    DataSet ds = conexion.sqlconsulta("Select id_usuario,usuario as 'USUARIO',pass AS 'CONTRASEÑA',tipo AS 'TIPO',nombre As NOMBRE, cedula AS CEDULA, foto AS FOTO from tbl_usuarios WHERE cedula LIKE '" + tb_busqueda.Text + "%'");
                    DataGridView1.DataSource = ds.Tables[0];
                    DataGridView1.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_usuario,usuario as 'USUARIO',pass AS 'CONTRASEÑA',tipo AS 'TIPO',nombre As NOMBRE, cedula AS CEDULA, foto AS FOTO from tbl_usuarios");
                DataGridView1.DataSource = ds.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
