using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RRHH
{
    public partial class seguridad : UserControl
    {

        public seguridad()
        {
            InitializeComponent();
        }
        public int ID;
        private void seguridad_Load(object sender, EventArgs e)
        {
            if (File.Exists("configuracion.cfg"))
            {
                var busqueda = new StreamReader("configuracion.cfg");

                String cadena;
               
                while ((cadena = busqueda.ReadLine()) != null)
                {
                    string[] campos = cadena.Split(':');
                    if (campos[0].Equals("guardarpass"))
                    {
                        if (campos[1].Equals("True"))
                            rb_si.Checked = true;
                        else
                            rb_no.Checked = true;
                    }
                    else if (campos[0].Equals("guardarusuario"))
                    {
                        if (campos[1].Equals("True"))
                            rb_usuario_si.Checked = true;
                        else
                            rb_usuario_no.Checked = true;
                    }
                  
                }

                busqueda.Close();
            }
        }

        private void rb_si_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb_si_Click(object sender, EventArgs e)
        {
            rb_no.Checked = false;
            rb_si.Checked = true;
            if (rb_si.Checked)
            {
                StreamReader busqueda = new StreamReader("configuracion.cfg");
                StreamWriter temporal = new StreamWriter("temporal.cfg", true);



                String cadena;
                
                while ((cadena = busqueda.ReadLine()) != null)
                {
                    
                    string[] campos = cadena.Split(':');
                    if (campos[0].Equals("guardarpass"))
                        temporal.WriteLine("guardarpass:True" + ":" + ID.ToString());
                    else if (campos[0].Equals("guardarusuario") & campos.Length > 2)
                        temporal.WriteLine(campos[0] + ":" + campos[1] + ":" + campos[2]);
                    else
                        temporal.WriteLine(campos[0] + ":" + campos[1]);
                    
                }

                temporal.Close();
                busqueda.Close();
                File.Delete("configuracion.cfg");
                File.Move("temporal.cfg", "configuracion.cfg");
            }
        }

        private void rb_usuario_si_Click(object sender, EventArgs e)
        {
            rb_usuario_si.Checked = true;
            if (rb_usuario_si.Checked)
            {
                rb_usuario_no.Checked = false;
                var busqueda = new StreamReader("configuracion.cfg");
                var temporal = new StreamWriter("temporal.cfg", true);



                String cadena;

                while ((cadena = busqueda.ReadLine()) != null)
                {
                    string[] campos = cadena.Split(':');
                    if (campos[0].Equals("guardarusuario"))
                        temporal.WriteLine("guardarusuario:True" + ":" + ID.ToString());
                    else if (campos[0].Equals("guardarpass") & campos.Length > 2)
                        temporal.WriteLine(campos[0] + ":" + campos[1] + ":" + campos[2]);
                    else
                        temporal.WriteLine(campos[0] + ":" + campos[1]);
                   
                }

                temporal.Close();
                busqueda.Close();
                File.Delete("configuracion.cfg");
                File.Move("temporal.cfg", "configuracion.cfg");
            }
        }

        private void rb_no_Click(object sender, EventArgs e)
        {
            rb_no.Checked = true;
            if (rb_no.Checked)
            {
                rb_si.Checked = false;
                var busqueda = new StreamReader("configuracion.cfg");
                var temporal = new StreamWriter("temporal.cfg", true);


                string cadena;


                while ((cadena = busqueda.ReadLine()) != null)
                {
                    string[] campos = cadena.Split(':');
                    if (campos[0].Equals("guardarpass"))
                        temporal.WriteLine("guardarpass:False");
                    else if (campos[0].Equals("guardarusuario") & campos.Length > 2)
                        temporal.WriteLine(campos[0] + ":" + campos[1] + ":" + campos[2]);
                    else
                        temporal.WriteLine(campos[0] + ":" + campos[1]);
                  
                }

                temporal.Close();
                busqueda.Close();
                File.Delete("configuracion.cfg");
                File.Move("temporal.cfg", "configuracion.cfg");
            }
        }

        private void rb_usuario_no_Click(object sender, EventArgs e)
        {
            rb_usuario_si.Checked = false;
            rb_usuario_no.Checked = true;
            if (rb_usuario_no.Checked)
            {
                var busqueda = new StreamReader("configuracion.cfg");
                var temporal = new StreamWriter("temporal.cfg", true);



                String cadena;
                while ((cadena = busqueda.ReadLine()) != null)
                {
                    string[] campos = cadena.Split(':');
                    if (campos[0].Equals("guardarusuario"))
                        temporal.WriteLine("guardarusuario:False");
                    else if (campos[0].Equals("guardarpass") & campos.Length > 2)
                        temporal.WriteLine(campos[0] + ":" + campos[1] + ":" + campos[2]);
                    else
                        temporal.WriteLine(campos[0] + ":" + campos[1]);
                   
                }

                temporal.Close();
                busqueda.Close();
                File.Delete("configuracion.cfg");
                File.Move("temporal.cfg", "configuracion.cfg");
            }
        }
    }
}
