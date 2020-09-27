namespace RRHH
{
    partial class seguridad
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rb_usuario_no = new System.Windows.Forms.RadioButton();
            this.rb_usuario_si = new System.Windows.Forms.RadioButton();
            this.rb_no = new System.Windows.Forms.RadioButton();
            this.rb_si = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rb_usuario_no
            // 
            this.rb_usuario_no.AutoCheck = false;
            this.rb_usuario_no.AutoSize = true;
            this.rb_usuario_no.Location = new System.Drawing.Point(275, 189);
            this.rb_usuario_no.Margin = new System.Windows.Forms.Padding(2);
            this.rb_usuario_no.Name = "rb_usuario_no";
            this.rb_usuario_no.Size = new System.Drawing.Size(39, 17);
            this.rb_usuario_no.TabIndex = 21;
            this.rb_usuario_no.Text = "No";
            this.rb_usuario_no.UseVisualStyleBackColor = true;
            this.rb_usuario_no.Click += new System.EventHandler(this.rb_usuario_no_Click);
            // 
            // rb_usuario_si
            // 
            this.rb_usuario_si.AutoCheck = false;
            this.rb_usuario_si.AutoSize = true;
            this.rb_usuario_si.Location = new System.Drawing.Point(209, 189);
            this.rb_usuario_si.Margin = new System.Windows.Forms.Padding(2);
            this.rb_usuario_si.Name = "rb_usuario_si";
            this.rb_usuario_si.Size = new System.Drawing.Size(34, 17);
            this.rb_usuario_si.TabIndex = 20;
            this.rb_usuario_si.Text = "Si";
            this.rb_usuario_si.UseVisualStyleBackColor = true;
            this.rb_usuario_si.Click += new System.EventHandler(this.rb_usuario_si_Click);
            // 
            // rb_no
            // 
            this.rb_no.AutoCheck = false;
            this.rb_no.AutoSize = true;
            this.rb_no.Location = new System.Drawing.Point(275, 145);
            this.rb_no.Margin = new System.Windows.Forms.Padding(2);
            this.rb_no.Name = "rb_no";
            this.rb_no.Size = new System.Drawing.Size(39, 17);
            this.rb_no.TabIndex = 19;
            this.rb_no.Text = "No";
            this.rb_no.UseVisualStyleBackColor = true;
            this.rb_no.Click += new System.EventHandler(this.rb_no_Click);
            // 
            // rb_si
            // 
            this.rb_si.AutoCheck = false;
            this.rb_si.AutoSize = true;
            this.rb_si.Location = new System.Drawing.Point(209, 145);
            this.rb_si.Margin = new System.Windows.Forms.Padding(2);
            this.rb_si.Name = "rb_si";
            this.rb_si.Size = new System.Drawing.Size(34, 17);
            this.rb_si.TabIndex = 18;
            this.rb_si.Text = "Si";
            this.rb_si.UseVisualStyleBackColor = true;
            this.rb_si.CheckedChanged += new System.EventHandler(this.rb_si_CheckedChanged);
            this.rb_si.Click += new System.EventHandler(this.rb_si_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(71, 190);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(99, 16);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "Guardar usuario";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(71, 145);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(119, 16);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Guardar contraseña";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label1.Location = new System.Drawing.Point(173, 50);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(382, 27);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Cambiar la configuracion de seguridad";
            // 
            // seguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.rb_usuario_no);
            this.Controls.Add(this.rb_usuario_si);
            this.Controls.Add(this.rb_no);
            this.Controls.Add(this.rb_si);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "seguridad";
            this.Size = new System.Drawing.Size(876, 552);
            this.Load += new System.EventHandler(this.seguridad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton rb_usuario_no;
        internal System.Windows.Forms.RadioButton rb_usuario_si;
        internal System.Windows.Forms.RadioButton rb_no;
        internal System.Windows.Forms.RadioButton rb_si;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}
