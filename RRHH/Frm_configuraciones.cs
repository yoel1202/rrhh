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
    public partial class Frm_configuraciones : Form
    {
       public frm_inicio f1;
        public Frm_configuraciones()
        {
            InitializeComponent();
        }
        public int ID;
        private void Frm_configuraciones_Load(object sender, EventArgs e)
        {
            seguridad1.ID = ID;
            pantalla1.BringToFront();
        }

        private void pantalla1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            pantalla1.BringToFront();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            //apagado1.BringToFront();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            seguridad1.BringToFront();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            caracteristicas2.f1 = f1;
            caracteristicas2.BringToFront();
        
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            actualizacion1.BringToFront();
        }

        private void actualizacion1_Load(object sender, EventArgs e)
        {

        }

        private void actualizacion1_Load_1(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
