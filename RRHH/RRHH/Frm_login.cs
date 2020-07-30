using RRHH.CONEXION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRHH
{
    public partial class Form1 : Form
    {
        private BDconeccion conexion  = new BDconeccion();
        public frm_inicio frm_inicio = new frm_inicio();
        public  Form1()
        {
            InitializeComponent();
        }
        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            pb_iniciar.Show();
            lb_iniciar.Show();

            tb_usuario.Enabled = false;
            tb_password.Enabled = false;



            btn_iniciar.Hide();

            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            pb_iniciar.Hide();
            ProgressBar1.Hide();
            lb_iniciar.Hide();
           
            Label2.Text = "© " + DateTime.Today.Year.ToString() + " - Todos los derechos reservados";

            StreamReader busqueda = new StreamReader("configuracion.cfg");

            string cadena;
          
            while ((cadena = busqueda.ReadLine()) != null)
            {
                string[] campos = cadena.Split(':');
                
                if (campos[0].Equals("guardarusuario") & campos.Length > 2)
                {
                   
                   
                    DataSet ds;
                    ds = conexion.sqlconsulta("Select usuario from tbl_usuarios where id_usuario='" + campos[2] + "'");
                    tb_usuario.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else if (campos[0].Equals("guardarpass") & campos.Length > 2)
                {
                 
                    DataSet ds;
                    ds = conexion.sqlconsulta("Select pass from tbl_usuarios where id_usuario='" + campos[2] + "'");
                    tb_password.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
              
            }


            busqueda.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Increment(2);



            if (ProgressBar1.Value == 0)
            {
                cambiar("imagenes/image (1).png");

                lb_iniciar.Text = ".";
            }
            else if (ProgressBar1.Value == 8)
            {
                cambiar("imagenes/image (2).png");
                lb_iniciar.Text = "..";
            }
            else if (ProgressBar1.Value == 16)
            {
                cambiar("imagenes/image (3).png");
                lb_iniciar.Text = "...";
            }
            else if (ProgressBar1.Value == 24)
            {
                cambiar("imagenes/image (4).png");
                lb_iniciar.Text = ".";
            }
            else if (ProgressBar1.Value == 32)
            {
                cambiar("imagenes/image (5).png");
                lb_iniciar.Text = "..";
            }
            else if (ProgressBar1.Value == 40)
            {
                cambiar("imagenes/image (6).png");
                lb_iniciar.Text = "...";
            }
            else if (ProgressBar1.Value == 48)
            {
                cambiar("imagenes/image (7).png");
                lb_iniciar.Text = ".";
            }
            else if (ProgressBar1.Value == 56)
            {
                cambiar("imagenes/image (8).png");
                lb_iniciar.Text = "..";
            }
            else if (ProgressBar1.Value == 64)
            {
                cambiar("imagenes/image (9).png");
                lb_iniciar.Text = "...";
            }
            else if (ProgressBar1.Value == 72)
            {
                cambiar("imagenes/image (10).png");
                lb_iniciar.Text = ".";
            }
            else if (ProgressBar1.Value == 80)
            {
                cambiar("imagenes/image (11).png");
                lb_iniciar.Text = "..";
            }
            else if (ProgressBar1.Value == 88)
            {
                cambiar("imagenes/image (12).png");
                lb_iniciar.Text = "...";
            }
            else if (ProgressBar1.Value == 96)
            {
                cambiar("imagenes/image (2).png");
                lb_iniciar.Text = ".";
            }
            else if (ProgressBar1.Value == 100)
            {
                lb_iniciar.Text = "Iniciando...";
                pb_iniciar.Hide();
                btn_iniciar.Show();
                ProgressBar1.Value = 0;

                lb_iniciar.Hide();

                DataSet ds;
                ds = conexion.sqlconsulta("Select id_usuario,tipo from tbl_usuarios where usuario='" + tb_usuario.Text + "' and pass='" + tb_password.Text + "' ");
                try
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show("Su nombre o contraseña son incorrectos");
                        tb_password.Enabled = true;
                        tb_usuario.Enabled = true;
                    }
                    else
                    {
                        var tipo = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                        int ID = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                        if (tipo.Trim() == "ADMINISTRADOR")
                        {
                            frm_inicio.conexion = this.conexion;
                            frm_inicio.ID = ID;
                            frm_inicio.Show();
                        }
                        else if (tipo.Trim() == "USUARIO")
                        {
                            frm_inicio.ID = ID;
                            frm_inicio.conexion = this.conexion;
                            frm_inicio.tipo_usuario = "USUARIO";
                            frm_inicio.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                }







                timer1.Stop();
            }
        }

        public void cambiar(string ruta)
        {
            pb_iniciar.Image = Image.FromFile(ruta);
            pb_iniciar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_usuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
