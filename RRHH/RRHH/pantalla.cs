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
    public partial class pantalla : UserControl
    {
        public pantalla()
        {
            InitializeComponent();
        }
        int caso;
        private void PictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox6.BackgroundImage = PictureBox8.BackgroundImage;
            caso = 2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var f1 = (frm_inicio)Application.OpenForms["frm_inicio"];
            f1.BackgroundImage=PictureBox6.BackgroundImage;
            f1.BackgroundImageLayout= ImageLayout.Stretch;
            switch (caso)
            {
                case 1:
                    {
                        cambiarfondo("fondo 1.jpg");
                        break;
                    }

                case 2:
                    {
                        cambiarfondo("fondo 2.jpg");
                        break;
                    }

                case 3:
                    {
                        cambiarfondo("fondo 3.jpg");
                        break;
                    }

                case 4:
                    {
                        cambiarfondo("fondo 4.jpg");
                        break;
                    }

                case 5:
                    {
                        cambiarfondo("fondo 5.jpg");
                        break;
                    }
            }
        }
        public void cambiarfondo( string pic)
        {
            var busqueda = new StreamReader("configuracion.cfg");
            var temporal = new StreamWriter("temporal.cfg", true);

        
            String cadena;

            while ((cadena = busqueda.ReadLine()) != null)
            {
                string[] campos = cadena.Split(':');
                if (campos[0].Equals("Fondo"))
                    temporal.WriteLine("Fondo:" + pic);
                else if (campos[0].Equals("guardarusuario") & campos.Length > 2)
                    temporal.WriteLine(campos[0] + ":" + campos[1] + ":" + campos[2]);
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

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox6.BackgroundImage = PictureBox7.BackgroundImage;
            caso = 1;
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            PictureBox6.BackgroundImage = PictureBox9.BackgroundImage;
        caso = 9;
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            PictureBox6.BackgroundImage = PictureBox10.BackgroundImage;
            caso = 4;
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png)|*.jpg;*.png";
            if (opf.ShowDialog(this) == DialogResult.OK)
            {
                PictureBox6.BackgroundImage = Image.FromFile(opf.FileName);
                PictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
                File.Copy(opf.FileName, @"fondo\fondo 5.jpg");
                caso = 5;
            }
        }
    }
}
