namespace RRHH
{
    partial class Frm_empleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_empleados));
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.LinkLabel16 = new System.Windows.Forms.LinkLabel();
            this.tb_busqueda = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tb_cedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.tb_apellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_departamento = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_fechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.cb_nombramiento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_fechaescala = new System.Windows.Forms.DateTimePicker();
            this.dtp_fechavacaciones = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tb_puesto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "Cedula"});
            this.ComboBox1.Location = new System.Drawing.Point(1003, 107);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(116, 21);
            this.ComboBox1.TabIndex = 176;
            // 
            // LinkLabel16
            // 
            this.LinkLabel16.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.LinkLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabel16.LinkColor = System.Drawing.Color.DimGray;
            this.LinkLabel16.Location = new System.Drawing.Point(475, 129);
            this.LinkLabel16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkLabel16.Name = "LinkLabel16";
            this.LinkLabel16.Size = new System.Drawing.Size(525, 8);
            this.LinkLabel16.TabIndex = 175;
            this.LinkLabel16.TabStop = true;
            this.LinkLabel16.Text = resources.GetString("LinkLabel16.Text");
            this.LinkLabel16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_busqueda
            // 
            this.tb_busqueda.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_busqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_busqueda.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_busqueda.Location = new System.Drawing.Point(475, 109);
            this.tb_busqueda.Margin = new System.Windows.Forms.Padding(2);
            this.tb_busqueda.Multiline = true;
            this.tb_busqueda.Name = "tb_busqueda";
            this.tb_busqueda.Size = new System.Drawing.Size(524, 17);
            this.tb_busqueda.TabIndex = 174;
            this.tb_busqueda.Text = "Buscar";
            this.tb_busqueda.TextChanged += new System.EventHandler(this.tb_busqueda_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.Location = new System.Drawing.Point(469, 26);
            this.Label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(246, 37);
            this.Label7.TabIndex = 168;
            this.Label7.Text = "Modulo Empleados";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(466, 157);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(643, 245);
            this.DataGridView1.TabIndex = 167;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // PictureBox3
            // 
            this.PictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox3.BackgroundImage")));
            this.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox3.Location = new System.Drawing.Point(897, 26);
            this.PictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(62, 47);
            this.PictureBox3.TabIndex = 166;
            this.PictureBox3.TabStop = false;
            this.PictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // Button4
            // 
            this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button4.Location = new System.Drawing.Point(0, 251);
            this.Button4.Margin = new System.Windows.Forms.Padding(2);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(121, 63);
            this.Button4.TabIndex = 105;
            this.Button4.Text = "Lista";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(9, 10);
            this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(88, 24);
            this.Label6.TabIndex = 104;
            this.Label6.Text = "Viachica";
            // 
            // Button3
            // 
            this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button3.Image = ((System.Drawing.Image)(resources.GetObject("Button3.Image")));
            this.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button3.Location = new System.Drawing.Point(0, 128);
            this.Button3.Margin = new System.Windows.Forms.Padding(2);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(121, 63);
            this.Button3.TabIndex = 103;
            this.Button3.Text = "Actualizar";
            this.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Image = ((System.Drawing.Image)(resources.GetObject("Button2.Image")));
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button2.Location = new System.Drawing.Point(0, 69);
            this.Button2.Margin = new System.Windows.Forms.Padding(2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(121, 63);
            this.Button2.TabIndex = 102;
            this.Button2.Text = "Eliminar";
            this.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Image = ((System.Drawing.Image)(resources.GetObject("Button1.Image")));
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button1.Location = new System.Drawing.Point(0, 190);
            this.Button1.Margin = new System.Windows.Forms.Padding(2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(121, 63);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Guardar";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.Panel1.Controls.Add(this.Button4);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.Button3);
            this.Panel1.Controls.Add(this.Button2);
            this.Panel1.Controls.Add(this.PictureBox2);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(46, 557);
            this.Panel1.TabIndex = 178;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox2.BackgroundImage")));
            this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox2.InitialImage = null;
            this.PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.PictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(46, 47);
            this.PictureBox2.TabIndex = 101;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(103, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 24);
            this.pictureBox1.TabIndex = 180;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel2.Location = new System.Drawing.Point(255, 163);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(158, 8);
            this.linkLabel2.TabIndex = 183;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "                                                                                 " +
    "                                                                            ";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_cedula
            // 
            this.tb_cedula.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_cedula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_cedula.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cedula.Location = new System.Drawing.Point(257, 143);
            this.tb_cedula.Margin = new System.Windows.Forms.Padding(2);
            this.tb_cedula.Multiline = true;
            this.tb_cedula.Name = "tb_cedula";
            this.tb_cedula.Size = new System.Drawing.Size(148, 17);
            this.tb_cedula.TabIndex = 181;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Cedula";
            // 
            // linkLabel3
            // 
            this.linkLabel3.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel3.Location = new System.Drawing.Point(255, 200);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(158, 8);
            this.linkLabel3.TabIndex = 186;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "                                                                                 " +
    "                                                                            ";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_nombre
            // 
            this.tb_nombre.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_nombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_nombre.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nombre.Location = new System.Drawing.Point(257, 180);
            this.tb_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.tb_nombre.Multiline = true;
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(148, 17);
            this.tb_nombre.TabIndex = 184;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 185;
            this.label4.Text = "Nombre";
            // 
            // linkLabel4
            // 
            this.linkLabel4.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel4.Location = new System.Drawing.Point(255, 238);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(158, 8);
            this.linkLabel4.TabIndex = 189;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "                                                                                 " +
    "                                                                            ";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_apellido
            // 
            this.tb_apellido.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_apellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_apellido.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_apellido.Location = new System.Drawing.Point(257, 218);
            this.tb_apellido.Margin = new System.Windows.Forms.Padding(2);
            this.tb_apellido.Multiline = true;
            this.tb_apellido.Name = "tb_apellido";
            this.tb_apellido.Size = new System.Drawing.Size(148, 17);
            this.tb_apellido.TabIndex = 187;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 224);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 188;
            this.label5.Text = "Apellido";
            // 
            // cb_departamento
            // 
            this.cb_departamento.FormattingEnabled = true;
            this.cb_departamento.Location = new System.Drawing.Point(257, 107);
            this.cb_departamento.Margin = new System.Windows.Forms.Padding(2);
            this.cb_departamento.Name = "cb_departamento";
            this.cb_departamento.Size = new System.Drawing.Size(157, 21);
            this.cb_departamento.TabIndex = 177;
            this.cb_departamento.SelectedIndexChanged += new System.EventHandler(this.cb_departamento_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(141, 107);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 13);
            this.Label3.TabIndex = 165;
            this.Label3.Text = "Departamento";
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(145, 417);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 197;
            this.label2.Text = "Fecha de vacaciones";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 379);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 194;
            this.label8.Text = "Fecha Ubicacion escala";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 266);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 191;
            this.label9.Text = "Fecha Nacimiento";
            // 
            // dtp_fechanacimiento
            // 
            this.dtp_fechanacimiento.Location = new System.Drawing.Point(275, 266);
            this.dtp_fechanacimiento.Name = "dtp_fechanacimiento";
            this.dtp_fechanacimiento.Size = new System.Drawing.Size(152, 20);
            this.dtp_fechanacimiento.TabIndex = 199;
            // 
            // cb_nombramiento
            // 
            this.cb_nombramiento.FormattingEnabled = true;
            this.cb_nombramiento.Items.AddRange(new object[] {
            "Interino",
            "Plaza"});
            this.cb_nombramiento.Location = new System.Drawing.Point(276, 305);
            this.cb_nombramiento.Margin = new System.Windows.Forms.Padding(2);
            this.cb_nombramiento.Name = "cb_nombramiento";
            this.cb_nombramiento.Size = new System.Drawing.Size(151, 21);
            this.cb_nombramiento.TabIndex = 202;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 305);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 201;
            this.label10.Text = "Tipo de nombramiento";
            // 
            // dtp_fechaescala
            // 
            this.dtp_fechaescala.Location = new System.Drawing.Point(275, 373);
            this.dtp_fechaescala.Name = "dtp_fechaescala";
            this.dtp_fechaescala.Size = new System.Drawing.Size(152, 20);
            this.dtp_fechaescala.TabIndex = 203;
            // 
            // dtp_fechavacaciones
            // 
            this.dtp_fechavacaciones.Location = new System.Drawing.Point(276, 417);
            this.dtp_fechavacaciones.Name = "dtp_fechavacaciones";
            this.dtp_fechavacaciones.Size = new System.Drawing.Size(152, 20);
            this.dtp_fechavacaciones.TabIndex = 204;
            // 
            // linkLabel1
            // 
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel1.Location = new System.Drawing.Point(273, 465);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(158, 8);
            this.linkLabel1.TabIndex = 207;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "                                                                                 " +
    "                                                                            ";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_puesto
            // 
            this.tb_puesto.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_puesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_puesto.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_puesto.Location = new System.Drawing.Point(275, 445);
            this.tb_puesto.Margin = new System.Windows.Forms.Padding(2);
            this.tb_puesto.Multiline = true;
            this.tb_puesto.Name = "tb_puesto";
            this.tb_puesto.Size = new System.Drawing.Size(148, 17);
            this.tb_puesto.TabIndex = 205;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 451);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 206;
            this.label11.Text = "Puesto";
            // 
            // linkLabel5
            // 
            this.linkLabel5.DisabledLinkColor = System.Drawing.Color.SpringGreen;
            this.linkLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel5.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel5.Location = new System.Drawing.Point(274, 353);
            this.linkLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(158, 8);
            this.linkLabel5.TabIndex = 210;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "                                                                                 " +
    "                                                                            ";
            this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_codigo
            // 
            this.tb_codigo.BackColor = System.Drawing.Color.DarkCyan;
            this.tb_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_codigo.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_codigo.Location = new System.Drawing.Point(276, 333);
            this.tb_codigo.Margin = new System.Windows.Forms.Padding(2);
            this.tb_codigo.Multiline = true;
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(148, 17);
            this.tb_codigo.TabIndex = 208;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(146, 339);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 13);
            this.label12.TabIndex = 209;
            this.label12.Text = "Codigo de nombramiento";
            // 
            // Frm_empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1040, 557);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.tb_codigo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tb_puesto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtp_fechavacaciones);
            this.Controls.Add(this.dtp_fechaescala);
            this.Controls.Add(this.cb_nombramiento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtp_fechanacimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.tb_apellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.tb_cedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.cb_departamento);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.LinkLabel16);
            this.Controls.Add(this.tb_busqueda);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.Label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1040, 557);
            this.Name = "Frm_empleados";
            this.Text = "Frm_usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.LinkLabel LinkLabel16;
        internal System.Windows.Forms.TextBox tb_busqueda;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.LinkLabel linkLabel2;
        internal System.Windows.Forms.TextBox tb_cedula;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.LinkLabel linkLabel3;
        internal System.Windows.Forms.TextBox tb_nombre;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.LinkLabel linkLabel4;
        internal System.Windows.Forms.TextBox tb_apellido;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_departamento;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_fechanacimiento;
        internal System.Windows.Forms.ComboBox cb_nombramiento;
        internal System.Windows.Forms.Label label10;
        protected internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fechaescala;
        private System.Windows.Forms.DateTimePicker dtp_fechavacaciones;
        internal System.Windows.Forms.LinkLabel linkLabel1;
        internal System.Windows.Forms.TextBox tb_puesto;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.LinkLabel linkLabel5;
        internal System.Windows.Forms.TextBox tb_codigo;
        internal System.Windows.Forms.Label label12;
    }
}