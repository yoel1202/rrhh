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
    public partial class frm_inicio : Form
    {

        public string tipo_usuario;
        public BDconeccion conexion;
        public int ID;
        public int minutos = -1;
        public int horas = -1;
        public int minutosapagado = -1;
        public int horasapagado = -1;
        public bool paso = true;
        public bool pasar = true;
        public frm_inicio()
        {

            InitializeComponent();
        }

        private void frm_inicio_Load(object sender, EventArgs e)
        {
            // metodo pone un timer a funcionar para ir mostrado la hora en el sistema y se cambie
            timer1.Start();
            // antes de iniciar el programa implementa parametros para acomodar la interfaz dependiendo de la pantalla de computador
            PictureBox1.SetBounds(Screen.PrimaryScreen.Bounds.Width - 150, 15, PictureBox1.Width, PictureBox1.Height);
            PictureBox2.SetBounds(0, Screen.PrimaryScreen.Bounds.Height - 70, PictureBox2.Width, PictureBox2.Height);
            PictureBox3.SetBounds(Screen.PrimaryScreen.Bounds.Width - 60, 15, PictureBox3.Width, PictureBox3.Height);
            PictureBox4.SetBounds(10, 30, PictureBox4.Width, PictureBox4.Height);
            PictureBox5.SetBounds(this.Width - 200, this.Height - 100, PictureBox5.Width, PictureBox5.Height);
            Label1.SetBounds(100, 30, Label1.Width, Label1.Height);
            nombre.SetBounds(Screen.PrimaryScreen.Bounds.Width - 290, PictureBox1.Height - 40, nombre.Width, nombre.Height);
            Label3.SetBounds(Screen.PrimaryScreen.Bounds.Width - 290, PictureBox1.Height - 15, Label3.Width, Label3.Height);
            Label11.SetBounds(this.Width - 245, this.Height - 120, Label11.Width, Label11.Height);
            Label12.SetBounds(Screen.PrimaryScreen.Bounds.Width - 60, PictureBox3.Height + 15, Label12.Width, Label12.Height);
            Label4.SetBounds(Screen.PrimaryScreen.Bounds.Width - 220, PictureBox1.Height, Label4.Width, Label4.Height);
            pn_principal.SetBounds(PictureBox4.Width + 50, PictureBox4.Height + 40, Panel1.Width +  pn_empleados.Width + Pn_pagos.Width+400, Panel4.Height+ Panel1.Height+100);
            Panel1.SetBounds(PictureBox4.Width + 50, PictureBox4.Height + 40, Panel1.Width, Panel1.Height);
            pn_empleados.SetBounds(Panel1.Width + 350, PictureBox4.Height + 40, pn_empleados.Width, pn_empleados.Height);
            Pn_pagos.SetBounds(pn_empleados.Width + 800, PictureBox4.Height + 40, Pn_pagos.Width, Pn_pagos.Height);
            Panel4.SetBounds(PictureBox4.Width + 50, Panel1.Height + 200, Panel4.Width, Panel4.Height);
            Panel5.SetBounds(Panel4.Width + 350, Panel1.Height + 200, Panel5.Width, Panel5.Height);
            pn_configuracion.SetBounds(Panel5.Width + 800, Panel1.Height + 200, Panel5.Width, Panel5.Height);
            pn_principal.Hide();


            // obtiene los datos del usuario actual por medio de la variable ID 

            DataSet ds = conexion.sqlconsulta("Select nombre,puesto,cedula,foto from  tbl_usuarios  where id_usuario='" + ID.ToString() + "'");
            nombre.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            Label3.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

            try
            {
                PictureBox1.BackgroundImage = Image.FromFile(ds.Tables[0].Rows[0].ItemArray[3].ToString());
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                PictureBox1.BackgroundImage = Image.FromFile(@"perfiles\profile.png");
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }

            var busqueda = new StreamReader("configuracion.cfg");

            String cadena;
           
            while ((cadena = busqueda.ReadLine()) != null)
            {
                string[] campos = cadena.Split(':');
                if (campos[0].Equals("Fondo"))
                {
                    this.BackgroundImage = Image.FromFile("fondo/" + campos[1]);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                cadena = busqueda.ReadLine();
            }


            busqueda.Close();

        }



        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label11.Text = DateTime.Now.ToLongDateString();
        Label12.Text = DateTime.Now.ToLongTimeString();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (pn_principal.Visible == true)
            {
                pn_principal.Controls.RemoveAt(0);

                pn_principal.Hide();
                if (pasar == true)
                {
                    Panel1.Show();
                    pn_empleados.Show();
                    Pn_pagos.Show();
                    Panel4.Show();
                    Panel5.Show();
                    pn_configuracion.Show();
                }
                else
                {
                    Panel1.Show();
                    Panel4.Show();
                }
                paso = false;
            }

            if (paso == true)
            {
                if (pasar == true)
                {
                    Panel1.Hide();
                    pn_empleados.Hide();
                    Pn_pagos.Hide();
                    Panel4.Hide();
                    Panel5.Hide();
                    pn_configuracion.Hide();
                }
                else
                {
                    Panel1.Hide();
                    Panel4.Hide();
                }
                paso = false;
            }
            else
            {
                if (pasar == true)
                {
                    Panel1.Show();
                    pn_empleados.Show();
                    Pn_pagos.Show();
                    Panel4.Show();
                    Panel5.Show();
                    pn_configuracion.Show();
                }
                else
                {
                    Panel1.Show();
                    Panel4.Show();
                }

                paso = true;
            }
        }

        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox2.Image = Image.FromFile("imagenes/OS_Windows_82.png");
        }

        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox2.Image = Image.FromFile("imagenes/OS_Windows_8.png");
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pasar)
                Panel1.BackgroundImage = Image.FromFile("imagenes/clientes 2.png");
            else
                Panel1.BackgroundImage = Image.FromFile("imagenes/ayuda (2).png");
        }

        private void Panel1_MouseLeave(object sender, EventArgs e)
        {
            if (pasar)
                Panel1.BackgroundImage = Image.FromFile("imagenes/clientes 1.png");
            else
                Panel1.BackgroundImage = Image.FromFile("imagenes/ayuda (1).png");
        }

        private void pn_empleados_MouseMove(object sender, MouseEventArgs e)
        {
            pn_empleados.BackgroundImage = Image.FromFile("imagenes/funcionario (2).png");
        }

        private void pn_empleados_MouseLeave(object sender, EventArgs e)
        {
            pn_empleados.BackgroundImage = Image.FromFile("imagenes/funcionario (1).png");
        }

        private void Pn_pagos_MouseMove(object sender, MouseEventArgs e)
        {
            Pn_pagos.BackgroundImage = Image.FromFile("imagenes/pagos 2.png");
        }

        private void Pn_pagos_MouseLeave(object sender, EventArgs e)
        {
            Pn_pagos.BackgroundImage = Image.FromFile("imagenes/pagos 1.png");
        }

        private void Panel4_MouseLeave(object sender, EventArgs e)
        {
            if (pasar)
                Panel4.BackgroundImage = Image.FromFile("imagenes/turnos 1.png");
            else
                Panel4.BackgroundImage = Image.FromFile("imagenes/Acerca (2).png");
        }

        private void Panel4_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (pasar)
                Panel4.BackgroundImage = Image.FromFile("imagenes/turnos 2.png");
            else
                Panel4.BackgroundImage = Image.FromFile("imagenes/Acerca (1).png");
        }

        private void Panel5_MouseMove(object sender, MouseEventArgs e)
        {
            Panel5.BackgroundImage = Image.FromFile("imagenes/group.png");
        }

        private void Panel5_MouseLeave(object sender, EventArgs e)
        {
            Panel5.BackgroundImage = Image.FromFile("imagenes/group (1).png");
        }

        private void pn_configuracion_MouseMove(object sender, MouseEventArgs e)
        {
            pn_configuracion.BackgroundImage = Image.FromFile("imagenes/configuracion (1).png");
        }

        private void pn_configuracion_MouseLeave(object sender, EventArgs e)
        {
            pn_configuracion.BackgroundImage = Image.FromFile("imagenes/configuracion (2).png");
        }

        private void PictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox3.Image = Image.FromFile("imagenes/unnamed - copia.png");
        }

        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox3.Image = Image.FromFile("imagenes/unnamed.png");
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            if (pasar)
            {
                pn_empleados.Hide();
                Pn_pagos.Hide();
                Panel5.Hide();
                pn_configuracion.Hide();
                pasar = false;
                PictureBox5.BackgroundImage = Image.FromFile("imagenes/left.png");
                Panel1.BackgroundImage = Image.FromFile("imagenes/ayuda (1).png");
                Label5.Text = "Ayuda del Sistema";
                Panel4.BackgroundImage = Image.FromFile("imagenes/Acerca (2).png");
                Label8.Text = "Acerca de";
            }
            else
            {
                pn_empleados.Show();
                Pn_pagos.Show();
                Panel5.Show();
                pn_configuracion.Show();
                pasar = true;
                PictureBox5.BackgroundImage = Image.FromFile("imagenes/right.png");
                Panel1.BackgroundImage = Image.FromFile("imagenes/clientes 1.png");
                Label5.Text = "Clientes";
                Panel4.BackgroundImage = Image.FromFile("imagenes/turnos 1.png");
                Label8.Text = "Turnos";
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            Frm_usuario myForm = new Frm_usuario();
            myForm.conexion = this.conexion;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.usuario = ID;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            Frm_departamentos myForm = new Frm_departamentos();
            myForm.conexion = this.conexion;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }

        private void pn_empleados_Click(object sender, EventArgs e)
        {
            Frm_empleados myForm = new Frm_empleados();
            myForm.conexion = this.conexion;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }

        private void pn_configuracion_Click(object sender, EventArgs e)
        {
            Frm_configuraciones myForm = new Frm_configuraciones();
            myForm.ID = this.ID; 
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }

        private void Pn_pagos_Click(object sender, EventArgs e)
        {
            Frm_pagos myForm = new Frm_pagos();
            myForm.conexion = this.conexion;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.usuario = ID;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }

        private void Panel4_Click(object sender, EventArgs e)
        {
            Frm_plazas myForm = new Frm_plazas();
            myForm.conexion = this.conexion;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            pn_principal.Controls.Add(myForm);
            myForm.Show();

            pn_principal.Show();
        }
    }
}
    