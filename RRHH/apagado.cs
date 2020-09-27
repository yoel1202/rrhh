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
    public partial class apagado : UserControl
    {
        public apagado()
        {
            InitializeComponent();
        }

        private void apagado_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ComboBox1.SelectedIndex == 1)
            //{
            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutos =DateTime.TimeOfDay.AddMinutes(5).ToString("mm");
            //}
            //else if (ComboBox1.SelectedIndex == 2)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutos = DateTime.TimeOfDay.AddMinutes(10).ToString("mm");
            //}
            //else if (ComboBox1.SelectedIndex == 3)
            //{
            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutos = DateTime.TimeOfDay.AddMinutes(15).ToString("mm");
            //}
            //else if (ComboBox1.SelectedIndex == 4)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horas = DateTime.TimeOfDay.AddHours(1).ToString("hh");
            //}
            //else if (ComboBox1.SelectedIndex == 5)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horas = DateTime.TimeOfDay.AddHours(3).ToString("hh");
            //}
            //else if (ComboBox1.SelectedIndex == 6)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horas = DateTime.TimeOfDay.AddHours(5).ToString("hh");
            //}
            //else if (ComboBox1.SelectedIndex == 0)
            //{
            //    My.Forms.Login.frm_inicio.horas = -1;
            //    My.Forms.Login.frm_inicio.minutos = -1;
            //}
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ComboBox2.SelectedIndex == 1)
            //{
            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutosapagado = DateTime.TimeOfDay.AddMinutes(5).ToString("mm");
            //}
            //else if (ComboBox2.SelectedIndex == 2)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutosapagado = DateTime.TimeOfDay.AddMinutes(10).ToString("mm");
            //}
            //else if (ComboBox2.SelectedIndex == 3)
            //{
            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.minutosapagado = DateTime.TimeOfDay.AddMinutes(15).ToString("mm");
            //}
            //else if (ComboBox2.SelectedIndex == 4)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horasapagado = DateTime.TimeOfDay.AddHours(1).ToString("hh");
            //}
            //else if (ComboBox2.SelectedIndex == 5)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horasapagado = DateTime.TimeOfDay.AddHours(3).ToString("hh");
            //}
            //else if (ComboBox2.SelectedIndex == 6)
            //{
            //    MessageBox.Show("se ha guardado correctamente");

            //    MessageBox.Show("se ha guardado correctamente");
            //    My.Forms.Login.frm_inicio.horasapagado = DateTime.TimeOfDay.AddHours(5).ToString("hh");
            //}
            //else if (ComboBox2.SelectedIndex == 0)
            //{
            //    My.Forms.Login.frm_inicio.horasapagado = -1;
            //    My.Forms.Login.frm_inicio.minutosapagado = -1;
            //}
        }
    }
}
