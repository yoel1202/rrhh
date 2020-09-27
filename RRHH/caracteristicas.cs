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
    public partial class caracteristicas : UserControl
    {
       public  frm_inicio f1;
        public caracteristicas()
        {
            InitializeComponent();
        }

        
        FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
        private void caracteristicas_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            ComboBox3.SelectedIndex = 0;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                
                f1.Label1.ForeColor = colorDialog1.Color;
          
               
                f1.Label4.ForeColor = colorDialog1.Color;
                f1.Label11.ForeColor = colorDialog1.Color;
                f1.Label12.ForeColor = colorDialog1.Color;


                MessageBox.Show("Se ha cambiado correctamente");
            }
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
            if (ComboBox1.SelectedIndex > 0 & ComboBox2.SelectedIndex > 0)
            {
                Font font1 = new Font("Arial", 20);
             
                f1.Label1.Font = new Font(fontFamily, f1.Label1.Font.Size + float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular, GraphicsUnit.Pixel);
                
              
                f1.Label4.Font = new Font(fontFamily, f1.Label4.Font.Size + float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
                f1.Label11.Font = new Font(fontFamily, f1.Label11.Font.Size +float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
                f1.Label12.Font = new Font(fontFamily, f1.Label12.Font.Size +float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
            }
            else if (ComboBox2.SelectedIndex == 0 & ComboBox1.SelectedIndex > 0)
            {
                f1.Label1.Font = new Font(fontFamily, f1.Label4.Font.Size + float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
             
              
                f1.Label4.Font = new Font(fontFamily, f1.Label4.Font.Size +float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
                f1.Label11.Font = new Font(fontFamily, f1.Label11.Font.Size +float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
                f1.Label12.Font = new Font(fontFamily, f1.Label12.Font.Size +float.Parse((string)ComboBox1.SelectedItem), FontStyle.Regular);
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ComboBox2.SelectedIndex > 0)
            {
                f1.Label1.Font = new Font(fontFamily, f1.Label1.Font.Size, FontStyle.Regular);
                
               
                f1.Label4.Font = new Font(fontFamily, f1.Label4.Font.Size, FontStyle.Regular);
                f1.Label11.Font = new Font(fontFamily, f1.Label11.Font.Size, FontStyle.Regular);
                f1.Label12.Font = new Font(fontFamily, f1.Label12.Font.Size, FontStyle.Regular);
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            try
            {
                if (ComboBox3.SelectedIndex > 0 & ComboBox2.SelectedIndex > 0)
                {
                    f1.Label1.Font = new Font(fontFamily, f1.Label1.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                    
                    
                    f1.Label4.Font = new Font(fontFamily, f1.Label4.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                    f1.Label11.Font = new Font(fontFamily, f1.Label11.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                    f1.Label12.Font = new Font(fontFamily, f1.Label12.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                }
                else if (ComboBox2.SelectedIndex == 0 & ComboBox3.SelectedIndex > 0)
                {
                    f1.Label1.Font = new Font(f1.Label1.Name, f1.Label1.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
           
                    
                    f1.Label4.Font = new Font(f1.Label4.Name, f1.Label4.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                    f1.Label11.Font = new Font(f1.Label11.Name, f1.Label11.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                    f1.Label12.Font = new Font(f1.Label11.Name, f1.Label12.Font.Size - float.Parse((string)ComboBox3.SelectedItem), FontStyle.Regular);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El tamaño es muy pequeño para disminuirse");
            }
        }
        }
    }
