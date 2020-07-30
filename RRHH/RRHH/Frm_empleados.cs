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
    public partial class Frm_empleados : Form
    {
        public Frm_empleados()
        {
            InitializeComponent();
        }
        public BDconeccion conexion;
        private bool seleccionarusuario = false;
        private int ID_usuario;
        private void Frm_usuario_Load(object sender, EventArgs e)
        {
            Button1.Hide();
            Button2.Hide();
            Button3.Hide();
            Button4.Hide();
            pictureBox1.Hide();
            PictureBox3.SetBounds(this.Width - 80, 25, PictureBox3.Width, PictureBox3.Height);
            Label6.Hide();
            DataGridView1.Hide();
            ComboBox1.SelectedIndex = 0;
                 conexion.llenarComboBox("SELECT * from tbl_departamentos", cb_departamento, "id_departamento", "nombre");
            cb_departamento.SelectedIndex = 0;
            cb_nombramiento.SelectedIndex = 0;
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
            if ( validartexbox(tb_apellido) & validartexbox(tb_cedula) & validartexbox(tb_nombre))
            {
               
                if (conexion.querycomando("Insert into tbl_empleados(fk_departamento,cedula,nombre,apellido,fecha_nacimiento,tipo_nombramiento,codigo,fecha_escala,fecha_vacaciones,puesto) VALUES('" + cb_departamento.SelectedValue.ToString() + "','" + tb_cedula.Text + "','" + tb_nombre.Text + "','" + tb_apellido.Text + "','" + dtp_fechanacimiento.Value.Date + "','" + cb_nombramiento.SelectedItem.ToString() + "','" + tb_codigo.Text + "','" + dtp_fechaescala.Value.Date + "','" + dtp_fechavacaciones.Value.Date + "','" + tb_puesto.Text + "')"))
                    MessageBox.Show("Se ha guardado correctamente");
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                actualizardato();
                
                tb_apellido.Clear();
                tb_nombre.Clear();
                tb_cedula.Clear();
                tb_codigo.Clear();
                cb_nombramiento.SelectedIndex = 0;
                cb_departamento.SelectedIndex = 0;
                tb_puesto.Clear();
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }
        public void actualizardato()
        {
            DataSet data = conexion.sqlconsulta("Select id_empleado,cedula,TE.nombre,apellido,fecha_nacimiento,tipo_nombramiento,TE.codigo,fecha_escala,fecha_vacaciones,puesto,TD.nombre from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento   ");
            if (data.Tables.Count > 0)
            {
                DataGridView1.DataSource = data.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if ( validartexbox(tb_apellido) & validartexbox(tb_nombre) & validartexbox(tb_cedula))
            {
                if (seleccionarusuario)
                {
                    if (conexion.querycomando("Update tbl_empleados set cedula='" + tb_cedula.Text + "',nombre='" + tb_nombre.Text + "',apellido='" + tb_apellido.Text + "',fecha_nacimiento='" + dtp_fechanacimiento.Value.Date + "',tipo_nombramiento='" + cb_nombramiento.SelectedItem.ToString() + "',codigo='" + tb_codigo.Text + "',fecha_escala='" + dtp_fechaescala.Value.Date + "',fecha_vacaciones='" + dtp_fechavacaciones.Value.Date + "',puesto='" + tb_puesto.Text + "',fk_departamento='" + cb_departamento.SelectedValue.ToString() + "' WHERE id_empleado='" + ID_usuario.ToString() + "'"))
                        MessageBox.Show("Se ha actualizado correctamente");
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarusuario = false;
                actualizardato();

                tb_apellido.Clear();
                tb_nombre.Clear();
                tb_cedula.Clear();
                cb_departamento.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (seleccionarusuario)
            {
                if (conexion.querycomando("DELETE FROM tbl_empleados WHERE id_empleado='" + ID_usuario.ToString() + "' "))
                    MessageBox.Show("Se ha eliminado correctamente");
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

               
                tb_apellido.Clear();
                tb_nombre.Clear();
                tb_cedula.Clear();
                cb_departamento.SelectedIndex = 0;
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
                tb_cedula.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_nombre.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_apellido.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtp_fechaescala.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cb_nombramiento.SelectedItem = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                tb_codigo.Text = DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                dtp_fechaescala.Text = DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtp_fechavacaciones.Text = DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                tb_puesto.Text = DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                cb_departamento.SelectedItem = DataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        
               

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
                    DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula,TE.nombre,apellido,fecha_nacimiento,tipo_nombramiento,TE.codigo,fecha_escala,fecha_vacaciones,puesto,TD.nombre from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento WHERE cedula LIKE '" + tb_busqueda.Text + "%'");
                    DataGridView1.DataSource = ds.Tables[0];
                    DataGridView1.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula,TE.nombre,apellido,fecha_nacimiento,tipo_nombramiento,TE.codigo,fecha_escala,fecha_vacaciones,puesto,TD.nombre from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento");
                DataGridView1.DataSource = ds.Tables[0];
                DataGridView1.Columns[0].Visible = false;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
