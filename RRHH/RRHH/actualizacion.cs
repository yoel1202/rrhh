using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRHH
{
    public partial class actualizacion : UserControl
    {
        public actualizacion()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Increment(1);
            if (ProgressBar1.Value == 100)
            {
                Label4.Show();
                timer1.Stop();
            }
            Label3.Text = ProgressBar1.Value + (" %");
        }

        private void actualizacion_Load(object sender, EventArgs e)
        {
            ProgressBar1.Hide();
            Label3.Hide();
            Label4.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ProgressBar1.Show();
            Label3.Show();
            timer1.Start();
        }
    }
}
