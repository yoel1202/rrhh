using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RRHH.CONEXION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRHH
{
    public partial class Frm_pagos : Form
    {
        public BDconeccion conexion;
        private int ID_usuario;
        private int ID_remuneracion;
        private bool seleccionarremuneracion = false;
        private bool seleccionarempleado = false;
        private bool seleccionarpresupuesto = false;
        private bool seleccionarextras = false;
        private bool seleccionarextraordinario = false;
        private bool seleccionarpersonal = false;
        private int ID_presupuesto;
        private int ID_extras;
        private int ID_extraordinario;
        private int ID_personal;
        private int ID_incapacidad;
        private bool seleccionarincapacidad = false;
        public int usuario;
        public Frm_pagos()
        {
            InitializeComponent();
        }

        private void empleado_Click(object sender, EventArgs e)
        {

        }

        public void actualizardato(DataGridView dgv, string sql)
        {
            DataSet data = conexion.sqlconsulta(sql);
            if (data.Tables.Count > 0)
            {
                dgv.DataSource = data.Tables[0];
                dgv.Columns[0].Visible = false;
            }
        }

        private void Frm_pagos_Load(object sender, EventArgs e)
        {
            tb_monto_actual_presupuesto.Enabled = false;
            // actualiza los datagrieview con la informacion 
            actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL'  from tbl_presupuestos");
            actualizardato(dgv_empleado, "Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento   ");
            actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
          // inicia los combobox con la informacion
               cb_tipo_renumeracion.SelectedIndex = 0;
            cb_tipo_extraordinario.SelectedIndex = 0;
            cb_empleado_busqueda.SelectedIndex = 0;
            cb_busqueda_remuneracion.SelectedIndex = 0;
            cb_extras_busqueda.SelectedIndex = 0;
            cb_busqueda_extraordinario.SelectedIndex = 0;
            cb_busqueda_personal.SelectedIndex = 0;
            cb_tipo_reporte.SelectedIndex = 0;
            cb_tipo_presupuesto.SelectedIndex = 0;
            cb_dato_reporte.SelectedIndex = 0;
            cb_incapacidad.SelectedIndex = 0;
            llb_raya_reporte.Hide();
            tb_reporte.Hide();
            lb_dato.Hide();

            llb_raya_reporte.Show();
            tb_reporte.Show();
            lb_dato.Show();
            lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
            dtp_fecha_reporte.Hide();
            conexion.llenarComboBox("SELECT * from tbl_departamentos", cb_departamento, "id_departamento", "nombre");
            cb_departamento.SelectedIndex = 0;
           
            // notifica cuando el monto esta apunto de llegar a una cantidad
            notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
            notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);
            notificaciones("", lb_notificacion_accion_personal, 5000000);
            notificaciones("Extras", lb_notificacion_extraordinario, 5000000);


        }

        // metodo recibe 3 parametro el primero es el tipo de monto que queremos consultar  y el segundo el monto que es el tope donde debe de estar verifica si el monto es superior va pintar label 
        private void notificaciones(string tipo,Label lb, decimal monto_disponible) {
            DataSet ds;
            ds = conexion.sqlconsulta("select    monto_actual as 'MONTO ACTUAL'  from tbl_presupuestos where tipo_presupuesto='"+tipo+"'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string monto = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                
                if (decimal.Parse(monto) > monto_disponible)
                {
                    lb.Text = "Monto actual: " + monto;
                    lb.ForeColor = Color.Green;
                }
                else
                {
                    if (decimal.Parse(monto) < monto_disponible )
                    {
                        lb.Text = "Monto actual: " + monto;
                        lb.ForeColor = Color.Red;
                        //try
                        //{

                        //    //SoundPlayer simpleSound = new SoundPlayer(@"notificacion.wav");
                        //    //simpleSound.Play();
                        //}
                        //catch (Exception e) {

                        ////    MessageBox.Show(e.Message);
                        //}
                        
                    }


                }
               
            }

        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // llena los datos del empleado que se escoge con la celda que pasemos el cursos
                seleccionarempleado = true;
                ID_usuario = int.Parse(dgv_empleado.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_cedula.Text = dgv_empleado.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_nombre.Text = dgv_empleado.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_apellido.Text = dgv_empleado.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_codigo_plaza_extras.Text = dgv_empleado.Rows[e.RowIndex].Cells[6].Value.ToString();
                tb_plaza_extraordinario.Text = dgv_empleado.Rows[e.RowIndex].Cells[6].Value.ToString();

                // actualiza los datagridview dependiendo del empleado que escogemos 
                actualizardato(dgv_renumeracion, "Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_extras_corrientes, "Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_extraordinario, "Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_personal, "Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_incapacidades, "Select id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");

                actualizardato(dgv_reportes, "Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");

            }
            catch (Exception ex)
            {
            }
        }

        private void tab_Click(object sender, EventArgs e)
        {

        }
        // valida los textbox de que no esten en blanco
        public bool validartexbox(TextBox tb)
        {
            if (tb.Text == "")
                return false;
            else
                return true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // valida los texbox que no esten en blanco
            if (validartexbox(tb_monto_remuneracion) & validartexbox(tb_movimiento_remuneracion))
            {
                // verifica si el empleado esta selecciona
                if (seleccionarempleado)
                {
                    // identifica el tipo de renumeracion 
                    if (cb_tipo_renumeracion.SelectedItem.ToString() == "remuneracion por vacaciones")
                    {
                        // disminuye el monto del presupuesto por medio de este metodo
                        if (actualizarmontodisminuir("Remuneracion por vacaciones", tb_monto_remuneracion))
                        {

                            // inserta las renumeraciones se separa para poder descontar el monto de cada una
                            if (conexion.querycomando("Insert into tbl_remuneraciones(tipo,numero_movimiento,fecha_pago,monto,codigo,fecha_registro_renumeracion) VALUES('" + cb_tipo_renumeracion.SelectedItem.ToString() + "','" + tb_movimiento_remuneracion.Text + "','" + dtp_fecha_pago_remuneracion.Value.Date + "','" + tb_monto_remuneracion.Text + "','" + tb_codigo_remuneracion.Text + "',GETDATE())"))
                            {
                                DataSet ds;
                                ds = conexion.sqlconsulta("SELECT * FROM tbl_remuneraciones WHERE id_remuneracion = (SELECT MAX(id_remuneracion) FROM tbl_remuneraciones)");

                                conexion.querycomando("Insert into tbl_empleados_remuneraciones(fk_remuneracion,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                                conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','RENUMERACION','INSERTO UN REGISTRO','" + usuario + "',GETDATE())");
                                MessageBox.Show("Se ha guardado correctamente");
                            }
                            else
                                MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");


                           
                        }

                    }
                    else
                    {

                        //renumeracion por maternidad
                        if (conexion.querycomando("Insert into tbl_remuneraciones(tipo,numero_movimiento,fecha_pago,monto,codigo,fecha_registro_renumeracion) VALUES('" + cb_tipo_renumeracion.SelectedItem.ToString() + "','" + tb_movimiento_remuneracion.Text + "','" + dtp_fecha_pago_remuneracion.Value.Date + "','" + tb_monto_remuneracion.Text + "','" + tb_codigo_remuneracion.Text + "',GETDATE())"))
                        {
                            DataSet ds;
                            ds = conexion.sqlconsulta("SELECT * FROM tbl_remuneraciones WHERE id_remuneracion = (SELECT MAX(id_remuneracion) FROM tbl_remuneraciones)");

                            conexion.querycomando("Insert into tbl_empleados_remuneraciones(fk_remuneracion,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','RENUMERACION','INSERTO UN REGISTRO','"+usuario+"')");
                            MessageBox.Show("Se ha guardado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");




                    }

                    // limpia los texbox

                    tb_movimiento_remuneracion.Clear();
                    tb_monto_remuneracion.Clear();
                    tb_codigo_remuneracion.Clear();

                    cb_tipo_renumeracion.SelectedIndex = 0;
                    actualizardato(dgv_renumeracion, "Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,tr.codigo AS CODIGO,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones tr INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                    actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                    notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
                }
                else
                    MessageBox.Show("selecciona un empleado ");



            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        // boton hace la funcion de actualizar las renumeraciones para ello aplica funciones para devolver o aumentar el monto
        private void button5_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_apellido) & validartexbox(tb_nombre) & validartexbox(tb_cedula))
            {
                if (seleccionarremuneracion)
                {
                    if (cb_tipo_renumeracion.SelectedItem.ToString() == "remuneracion por vacaciones")
                    {
                        string sql = "SELECT monto FROM tbl_remuneraciones WHERE id_remuneracion = '" + ID_remuneracion.ToString() + "'";
                        if (actualizarmontoaumentar(sql, "Remuneracion por vacaciones"))
                        {
                            actualizarmontodisminuir("Remuneracion por vacaciones", tb_monto_remuneracion);

                            if (conexion.querycomando("Update tbl_remuneraciones set tipo='" + cb_tipo_renumeracion.SelectedItem.ToString() + "',numero_movimiento='" + tb_movimiento_remuneracion.Text + "',fecha_pago='" + dtp_fecha_pago_remuneracion.Value.Date + "',monto='" + tb_monto_remuneracion.Text + "', codigo='" + tb_codigo_remuneracion.Text + "' WHERE id_remuneracion='" + ID_remuneracion.ToString() + "'"))
                            {
                                MessageBox.Show("Se ha actualizado correctamente");
                                conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_remuneracion.ToString() + "','RENUMERACION','ACTUALIZO UN REGISTRO','" + usuario + "')");
                            }
                            else
                                MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                        }
                    }
                    else
                    {


                        if (conexion.querycomando("Update tbl_remuneraciones set tipo='" + cb_tipo_renumeracion.SelectedItem.ToString() + "',numero_movimiento='" + tb_movimiento_remuneracion.Text + "',fecha_pago='" + dtp_fecha_pago_remuneracion.Value.Date + "',monto='" + tb_monto_remuneracion.Text + "', codigo='" + tb_codigo_remuneracion.Text + "' WHERE id_remuneracion='" + ID_remuneracion.ToString() + "'"))
                        {
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro) VALUES('" + ID_remuneracion.ToString() + "','RENUMERACION','ACTUALIZO UN REGISTRO','" + usuario + "',GETDATE())");
                            MessageBox.Show("Se ha actualizado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarremuneracion = false;
                actualizardato(dgv_renumeracion, "Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,tr.codigo AS CODIGO,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones tr INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);

                tb_movimiento_remuneracion.Clear();
                tb_monto_remuneracion.Clear();
                tb_codigo_remuneracion.Clear();

                cb_tipo_renumeracion.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        // boton de eliminar de las renumeraciones
        private void button4_Click(object sender, EventArgs e)
        {
            if (seleccionarremuneracion)
            {
                if (cb_tipo_renumeracion.SelectedItem.ToString() == "remuneracion por vacaciones")
                {
                    string sql = "SELECT monto FROM tbl_remuneraciones WHERE id_remuneracion = '" + ID_remuneracion.ToString() + "'";
                    if (actualizarmontoaumentar(sql, "Remuneracion por vacaciones"))
                    {

                        if (conexion.querycomando("DELETE FROM tbl_empleados_remuneraciones WHERE fk_remuneracion='" + ID_remuneracion.ToString() + "' "))
                        {
                            
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro,registro) VALUES('" + ID_remuneracion.ToString() + "','RENUMERACION','ELIMINO UN REGISTRO','" + usuario + "',GETDATE(),'"+  " TIPO: "+  cb_tipo_renumeracion.SelectedItem.ToString() + " NUMERO DE MOVIMIENTO: " + tb_movimiento_remuneracion.Text + " FECHA DE PAGO: " + dtp_fecha_pago_remuneracion.Value.Date + " MONTO: " + tb_monto_remuneracion.Text + " CODIGO: " + tb_codigo_remuneracion.Text + "' )");
                            if (conexion.querycomando("DELETE FROM tbl_remuneraciones WHERE id_remuneracion='" + ID_remuneracion.ToString() + "' "))
                            {
                                
                                MessageBox.Show("Se ha eliminado correctamente");
                            }
                            else
                                MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                        }
                    }


                }
                else
                {
                    if (conexion.querycomando("DELETE FROM tbl_empleados_remuneraciones WHERE fk_remuneracion='" + ID_remuneracion.ToString() + "' "))
                    {
                        conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro,registro) VALUES('" + ID_remuneracion.ToString() + "','RENUMERACION','ELIMINO UN REGISTRO','" + usuario + "',GETDATE(),'" + " TIPO: " + cb_tipo_renumeracion.SelectedItem.ToString() + " NUMERO DE MOVIMIENTO: " + tb_movimiento_remuneracion.Text + " FECHA DE PAGO: " + dtp_fecha_pago_remuneracion.Value.Date + " MONTO: " + tb_monto_remuneracion.Text + " CODIGO: " + tb_codigo_remuneracion.Text + "' )");
                        if (conexion.querycomando("DELETE FROM tbl_remuneraciones WHERE id_remuneracion='" + ID_remuneracion.ToString() + "' ")) { 
                           
                        MessageBox.Show("Se ha eliminado correctamente");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                }

                tb_movimiento_remuneracion.Clear();
                tb_monto_remuneracion.Clear();
                tb_codigo_remuneracion.Clear();
                notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
                cb_tipo_renumeracion.SelectedIndex = 0;
                actualizardato(dgv_renumeracion, "Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,tr.codigo AS CODIGO,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones tr INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                seleccionarremuneracion = false;
            }
            else
            {
                MessageBox.Show("Seleccione un empleado de la lista");
            }


        }
        // seleciona los datos de la datagridview  de renumeraciones y setea los texbox
        private void dgv_renumeracion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarremuneracion = true;
                ID_remuneracion = int.Parse(dgv_renumeracion.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_movimiento_remuneracion.Text = dgv_renumeracion.Rows[e.RowIndex].Cells[1].Value.ToString();
                cb_tipo_renumeracion.SelectedItem = dgv_renumeracion.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtp_fecha_pago_remuneracion.Text = dgv_renumeracion.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_monto_remuneracion.Text = dgv_renumeracion.Rows[e.RowIndex].Cells[4].Value.ToString();
                tb_codigo_remuneracion.Text = dgv_renumeracion.Rows[e.RowIndex].Cells[5].Value.ToString();



            }
            catch (Exception ex)
            {
            }
        }



        private void tb_monto_remuneracion_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_monto_remuneracion_MouseLeave(object sender, EventArgs e)
        {

        }
        // busca  de las renumeraciones de acuerdo a los datos de los texbox basado en la opcion que se escoba en el combo box hace una consulta y devuelve los datos en la datagridview
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string selector = "";
            if (tb_buscar_remuneracion.Text != "" & tb_buscar_remuneracion.Text != "Buscar")
            {
                if (cb_busqueda_remuneracion.SelectedIndex >= 0)
                {

                    switch (cb_busqueda_remuneracion.SelectedItem)
                    {

                        case "Numero de movimiento":
                            selector = "numero_movimiento";
                            break;
                        case "Tipo renumeracion":
                            selector = "tipo";
                            break;
                        case "Fecha de pago":
                            selector = "fecha_pago";
                            break;
                        case "Codigo":
                            selector = "codigo";
                            break;
                    }
                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,TR.codigo AS CODIGO,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones as TR INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  AND" + " TR." + selector.Trim() + "  LIKE '" + tb_buscar_remuneracion.Text + "%'");
                    dgv_renumeracion.DataSource = ds.Tables[0];
                    dgv_renumeracion.Columns[0].Visible = false;

                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,tr.codigo AS CODIGO,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones tr INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                dgv_renumeracion.DataSource = ds.Tables[0];
                dgv_renumeracion.Columns[0].Visible = false;
            }
        }

        private void tb_busqueda_TextChanged(object sender, EventArgs e)
        {

            if (tb_busqueda_empleado.Text != "" & tb_busqueda_empleado.Text != "Buscar")
            {
                if (cb_empleado_busqueda.SelectedIndex >= 0)
                {

                    DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento WHERE" + " TE." + cb_empleado_busqueda.SelectedItem + " " + " LIKE '" + tb_busqueda_empleado.Text + "%'");
                    dgv_empleado.DataSource = ds.Tables[0];
                    dgv_empleado.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento");
                dgv_empleado.DataSource = ds.Tables[0];
                dgv_empleado.Columns[0].Visible = false;
            }
        }

        // boton insertar presupuesto por medio de una consulta sql ademas llama la funcion notificaciones para validar que monto no llegado al limite permitido
        private void button9_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_monto_presupuesto) & cb_tipo_presupuesto.SelectedIndex >= 0)
            {

                if (conexion.querycomando("Insert into tbl_presupuestos(tipo_presupuesto,monto_presupuesto,monto_actual) VALUES('" + cb_tipo_presupuesto.SelectedItem.ToString() + "','" + tb_monto_presupuesto.Text + "','" + tb_monto_presupuesto.Text + "')"))
                    MessageBox.Show("Se ha guardado correctamente");

                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL' from tbl_presupuestos");

                tb_monto_presupuesto.Clear();

                cb_tipo_presupuesto.SelectedIndex = 0;
                notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
                notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);
                notificaciones("", lb_notificacion_accion_personal, 5000000);
                notificaciones("Extras", lb_notificacion_extraordinario, 5000000);
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_monto_presupuesto) & cb_tipo_presupuesto.SelectedIndex >= 0)
            {
                if (seleccionarpresupuesto)
                {
                    if (conexion.querycomando("Update tbl_presupuestos set monto_actual='"+tb_monto_actual_presupuesto+"' ,tipo_presupuesto='" + cb_tipo_presupuesto.SelectedItem.ToString() + "',monto_presupuesto='" + double.Parse(tb_monto_presupuesto.Text) + "' WHERE id_presupuesto='" + ID_presupuesto.ToString() + "'"))
                        MessageBox.Show("Se ha actualizado correctamente");
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarpresupuesto = false;
                actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL' from tbl_presupuestos");

                tb_monto_presupuesto.Clear();

                cb_tipo_presupuesto.SelectedIndex = 0;
                notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
                notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);
                notificaciones("", lb_notificacion_accion_personal, 5000000);
                notificaciones("Extras", lb_notificacion_extraordinario, 5000000);
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (seleccionarpresupuesto)
            {
                if (conexion.querycomando("DELETE FROM tbl_presupuestos WHERE id_presupuesto='" + ID_presupuesto.ToString() + "' "))
                    MessageBox.Show("Se ha eliminado correctamente");
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");


                seleccionarpresupuesto = false;
                actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL'  from tbl_presupuestos");
                notificaciones("Remuneracion por vacaciones", lb_notificaciones_renumeracion, 5000000);
                notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);
                notificaciones("", lb_notificacion_accion_personal, 5000000);
                notificaciones("Extras", lb_notificacion_extraordinario, 5000000);
                tb_monto_presupuesto.Clear();

                cb_tipo_presupuesto.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Seleccione un empleado de la lista");
        }

        private void tb_busqueda_presupuesto_TextChanged(object sender, EventArgs e)
        {
            if (tb_busqueda_presupuesto.Text != "")
            {
                if (cb_presupuesto_busqueda.SelectedIndex == 0)
                {
                    DataSet ds = conexion.sqlconsulta(" select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL'  from tbl_presupuestos WHERE tipo_presupuesto LIKE '" + tb_busqueda_presupuesto.Text + "%'");
                    dgv_presupuesto.DataSource = ds.Tables[0];
                    dgv_presupuesto.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL'  from tbl_presupuestos");
                dgv_presupuesto.DataSource = ds.Tables[0];
                dgv_presupuesto.Columns[0].Visible = false;
            }
        }

        private void dgv_presupuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarpresupuesto = true;
                tb_monto_actual_presupuesto.Enabled = true;
                ID_presupuesto = int.Parse(dgv_presupuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
                cb_tipo_presupuesto.SelectedItem = dgv_presupuesto.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_monto_presupuesto.Text = dgv_presupuesto.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_monto_actual_presupuesto.Text = dgv_presupuesto.Rows[e.RowIndex].Cells[3].Value.ToString();




            }
            catch (Exception ex)
            {
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (validartexbox(tb_monto_cancelar_extras) & validartexbox(tb_codigo_plaza_extras) & validartexbox(tb_cantidad_extras))
            {
                if (seleccionarempleado)
                {
                    if (actualizarmontodisminuir("Extras corrientes medicas", tb_monto_cancelar_extras))
                    {
                        if (conexion.querycomando("Insert into tbl_extras_medicas(fecha_pago,codigo_plaza,cantidad_horas,monto_cancelar,fecha_registro_extras) VALUES('" + dtp_fecha_pago_extras.Value.Date + "','" + tb_codigo_plaza_extras.Text.ToString() + "','" + tb_cantidad_extras.Text + "','" + tb_monto_cancelar_extras.Text + "',GETDATE())"))
                        {
                            DataSet ds;
                            ds = conexion.sqlconsulta("SELECT * FROM tbl_extras_medicas WHERE id_extras = (SELECT MAX(id_extras) FROM tbl_extras_medicas)");

                            conexion.querycomando("Insert into tbl_extras_medicas_empleados(fk_extras,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','EXTRAS','INSERTO UN REGISTRO','" + usuario + "',GETDATE())");
                            MessageBox.Show("Se ha guardado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                    actualizardato(dgv_extras_corrientes, "Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                    actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                    tb_cantidad_extras.Clear();
                    // tb_codigo_plaza_extras.Clear();
                    tb_monto_cancelar_extras.Clear();
                    notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);


                }
                else
                    MessageBox.Show("selecciona un empleado ");



            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_monto_cancelar_extras) & validartexbox(tb_codigo_plaza_extras) & validartexbox(tb_cantidad_extras))
            {

                if (seleccionarextras)
                {
                    string sql = "SELECT monto_cancelar FROM tbl_extras_medicas WHERE id_extras = '" + ID_extras.ToString() + "'";
                    if (actualizarmontoaumentar(sql, "Extras corrientes medicas"))
                    {
                        actualizarmontodisminuir("Extras corrientes medicas", tb_monto_cancelar_extras);

                        if (conexion.querycomando("Update tbl_extras_medicas set fecha_pago='" + dtp_fecha_pago_extras.Value.Date + "',codigo_plaza='" + tb_codigo_plaza_extras.Text + "', cantidad_horas='" + tb_cantidad_extras.Text + "', monto_cancelar='" + tb_monto_cancelar_extras.Text + "', WHERE id_extras='" + ID_extras.ToString() + "'"))
                        {
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_extras + "','EXTRAS','ACTUALIZO ESTE REGISTRO UN REGISTRO','" + usuario + "')");
                            MessageBox.Show("Se ha actualizado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                    }
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarextras = false;
                actualizardato(dgv_extras_corrientes, "Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                tb_cantidad_extras.Clear();
                //tb_codigo_plaza_extras.Clear();
                tb_monto_cancelar_extras.Clear();
                notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);

            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void dgv_extras_corrientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarextras = true;
                ID_extras = int.Parse(dgv_extras_corrientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                dtp_fecha_pago_extras.Text = dgv_extras_corrientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_codigo_plaza_extras.Text = dgv_extras_corrientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_cantidad_extras.Text = dgv_extras_corrientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_monto_cancelar_extras.Text = dgv_extras_corrientes.Rows[e.RowIndex].Cells[4].Value.ToString();





            }
            catch (Exception ex)
            {
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (seleccionarextras)
            {
                string sql = "SELECT monto_cancelar FROM tbl_extras_medicas WHERE id_extras = '" + ID_extras.ToString() + "'";
                if (actualizarmontoaumentar(sql, "Extras corrientes medicas"))
                {
                    if (conexion.querycomando("DELETE FROM tbl_extras_medicas_empleados WHERE fk_extras='" + ID_extras.ToString() + "' "))
                    {
                        conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro,registro) VALUES('" + ID_remuneracion.ToString() + "','EXTRAS','ELIMINO UN REGISTRO','" + usuario + "',GETDATE(),'" + " FECHA DE PAGO: " + dtp_fecha_pago_extras.Text.ToString() + " CODIGO DE PLAZA: " + tb_codigo_plaza_extras.Text + " CANTIDAD DE HORAS: " +  tb_cantidad_extras.Text + " MONTO: " + tb_monto_cancelar_extras.Text + "' )");
                        if (conexion.querycomando("DELETE FROM tbl_extras_medicas WHERE id_extras='" + ID_extras.ToString() + "' "))
                        {
                            
                            MessageBox.Show("Se ha eliminado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                seleccionarextras = false;
                actualizardato(dgv_extras_corrientes, "Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                tb_cantidad_extras.Clear();
                //tb_codigo_plaza_extras.Clear();
                tb_monto_cancelar_extras.Clear();
                notificaciones("Extras corrientes medicas", lb_notificacion_extras, 5000000);

            }
            else
                MessageBox.Show("Seleccione un empleado de la lista");
        }

        private void tb_busqueda_extras_TextChanged(object sender, EventArgs e)
        {
            String selector = "";
            if (tb_busqueda_extras.Text != "" & tb_busqueda_extras.Text != "Buscar")
            {

                switch (cb_extras_busqueda.SelectedItem)
                {

                    case "Fecha de Pago":
                        selector = "fecha_pago";
                        break;
                    case "Codigo de plaza":
                        selector = "codigo_plaza";
                        break;

                }
                if (cb_extras_busqueda.SelectedIndex >= 0)
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas TEM INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "' and  TEM." + selector + " LIKE '" + tb_busqueda_extras.Text + "%'");
                    dgv_extras_corrientes.DataSource = ds.Tables[0];
                    dgv_extras_corrientes.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "' ");
                dgv_extras_corrientes.DataSource = ds.Tables[0];
                dgv_extras_corrientes.Columns[0].Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            switch (cb_tipo_extraordinario.SelectedItem) {
                case "Extras":
                    if (actualizarmontodisminuir("Extras", tb_monto_extraordinario))
                    {
                        error = true;
                    }

                    break;
                case "Recargo Nocturno":
                    if (actualizarmontodisminuir("Recargo nocturno", tb_monto_extraordinario))
                    {
                        error = true;
                    }

                    break;
                case "Guardias Medicas":
                    if (actualizarmontodisminuir("Guardias medicas", tb_monto_extraordinario))
                    {
                        error = true;
                    }

                    break;
                case "Disponibilidades Medicas":

                    error = true;


                    break;

            }
            if (error) {
                if (validartexbox(tb_plaza_extraordinario) & validartexbox(tb_cantidad_extraordinario) & validartexbox(tb_monto_extraordinario))
                {
                    if (seleccionarempleado)
                    {
                        if (conexion.querycomando("Insert into tbl_extraordinario(fecha_pago,codigo_plaza,cantidad_horas,monto,tipo_extraordinario,fk_departamento,fecha_registro_ordinario) VALUES('" + dtp_extraordinario.Value.Date + "','" + tb_plaza_extraordinario.Text.ToString() + "','" + tb_cantidad_extraordinario.Text + "','" + tb_monto_extraordinario.Text + "','" + cb_tipo_extraordinario.SelectedItem + "','" + cb_departamento.SelectedValue.ToString() + "',GETDATE())"))
                        {
                            DataSet ds;
                            ds = conexion.sqlconsulta("SELECT * FROM tbl_extraordinario WHERE id_extraordinario = (SELECT MAX(id_extraordinario) FROM tbl_extraordinario)");

                            conexion.querycomando("Insert into tbl_extraordinario_empleados(fk_extraordinario,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','EXTRAORDINARIO','INSERTO UN REGISTRO','" + usuario + "',GETDATE())");
                            MessageBox.Show("Se ha guardado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                        actualizardato(dgv_extraordinario, "Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,dp.nombre AS DEPARTAMENTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN tbl_departamentos  as dp ON fk_departamento=id_departamento  INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                        actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                        tb_monto_extraordinario.Clear();
                        // tb_codigo_plaza_extras.Clear();
                        tb_monto_extraordinario.Clear();
                        cb_departamento.SelectedIndex = 0;
                        cb_tipo_extraordinario.SelectedIndex = 0;


                    }
                    else
                        MessageBox.Show("selecciona un empleado ");



                }
                else
                    MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            string sql = "SELECT monto FROM tbl_extraordinario WHERE id_extraordinario = '" + ID_extraordinario.ToString() + "'";

            switch (cb_tipo_extraordinario.SelectedItem)
            {
                case "Extras":

                    if (actualizarmontoaumentar(sql, "Extras"))
                    {
                        actualizarmontodisminuir("Extras", tb_monto_extraordinario);
                        error = true;
                    }

                    break;
                case "Recargo Nocturno":
                    if (actualizarmontoaumentar(sql, "Recargo nocturno"))
                    {
                        actualizarmontodisminuir("Recargo nocturno", tb_monto_extraordinario);
                        error = true;
                    }

                    break;
                case "Guardias Medicas":
                    if (actualizarmontoaumentar(sql, "Guardias medicas"))
                    {
                        actualizarmontodisminuir("Guardias medicas", tb_monto_extraordinario);
                        error = true;
                    }

                    break;
                case "Disponibilidades Medicas":

                    error = true;


                    break;

            }
            if (error) {
                if (validartexbox(tb_plaza_extraordinario) & validartexbox(tb_cantidad_extraordinario) & validartexbox(tb_monto_extraordinario))
                {
                    if (seleccionarextraordinario)
                    {
                        if (conexion.querycomando("Update tbl_extraordinario set tipo_extraordinario='" + cb_tipo_extraordinario.SelectedItem + "', fecha_pago='" + dtp_extraordinario.Value.Date + "',codigo_plaza='" + tb_plaza_extraordinario.Text + "', cantidad_horas='" + tb_cantidad_extraordinario.Text + "', monto='" + tb_monto_extraordinario.Text + "',fk_departamento='" + cb_departamento.SelectedValue.ToString() + "' WHERE id_extraordinario='" + ID_extraordinario.ToString() + "'"))
                        {
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_extraordinario + "','EXTRAORDINARIO','ACTUALIZO UN REGISTRO','" + usuario + "')");
                            MessageBox.Show("Se ha actualizado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                    else
                        MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                    seleccionarextraordinario = false;
                    actualizardato(dgv_extraordinario, "Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,dp.nombre AS DEPARTAMENTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN tbl_departamentos  as dp ON fk_departamento=id_departamento  INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                    actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                    tb_monto_extraordinario.Clear();
                    // tb_codigo_plaza_extras.Clear();
                    tb_monto_extraordinario.Clear();
                    cb_departamento.SelectedIndex = 0;
                    cb_tipo_extraordinario.SelectedIndex = 0;

                }
                else
                    MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
            }
        }

        private void dgv_extraordinario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarextraordinario = true;
                ID_extraordinario = int.Parse(dgv_extraordinario.Rows[e.RowIndex].Cells[0].Value.ToString());
                cb_tipo_extraordinario.SelectedItem = dgv_extraordinario.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtp_extraordinario.Text = dgv_extraordinario.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_plaza_extraordinario.Text = dgv_extraordinario.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_cantidad_extraordinario.Text = dgv_extraordinario.Rows[e.RowIndex].Cells[4].Value.ToString();
                tb_monto_extraordinario.Text = dgv_extraordinario.Rows[e.RowIndex].Cells[5].Value.ToString();
                cb_departamento.SelectedValue = dgv_extraordinario.Rows[e.RowIndex].Cells[6].Value.ToString();




            }
            catch (Exception ex)
            {
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            string sql = "SELECT monto FROM tbl_extraordinario WHERE id_extraordinario = '" + ID_extraordinario.ToString() + "'";

            switch (cb_tipo_extraordinario.SelectedItem)
            {
                case "Extras":

                    if (actualizarmontoaumentar(sql, "Extras"))
                    {
                        error = true;
                    }

                    break;
                case "Recargo Nocturno":
                    if (actualizarmontoaumentar(sql, "Recargo nocturno"))
                    {
                        error = true;
                    }

                    break;
                case "Guardias Medicas":
                    if (actualizarmontoaumentar(sql, "Guardias medicas"))
                    {
                        error = true;
                    }

                    break;
                case "Disponibilidades Medicas":

                    error = true;


                    break;

            }

            if (error) {

                if (seleccionarextraordinario)
                {
                    if (conexion.querycomando("DELETE FROM tbl_extraordinario_empleados WHERE fk_extraordinario='" + ID_extraordinario.ToString() + "' "))
                    {
                        if (conexion.querycomando("DELETE FROM tbl_extraordinario WHERE id_extraordinario='" + ID_extraordinario.ToString() + "' "))
                        {
                            conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_extraordinario + "','EXTRAORDINARIO','ELIMINO UN REGISTRO','" + usuario + "')");
                            MessageBox.Show("Se ha eliminado correctamente");
                        }
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    seleccionarextraordinario = false;
                    actualizardato(dgv_extraordinario, "Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,dp.nombre AS DEPARTAMENTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN tbl_departamentos  as dp ON fk_departamento=id_departamento  INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                    actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                    tb_monto_extraordinario.Clear();
                    // tb_codigo_plaza_extras.Clear();
                    tb_monto_extraordinario.Clear();
                    cb_tipo_extraordinario.SelectedIndex = 0;

                }
                else
                    MessageBox.Show("Seleccione un empleado de la lista");
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            string selector = "";
            if (tb_busqueda_extraordinario.Text != "" & tb_busqueda_extraordinario.Text != "Buscar")
            {
                switch (cb_busqueda_extraordinario.SelectedItem)
                {

                    case "Tipo":
                        selector = "tipo_extraordinario";
                        break;
                    case "Fecha de pago":
                        selector = "fecha_pago";
                        break;
                    case "Codigo de Plaza":
                        selector = "codigo_plaza";
                        break;

                }
                if (cb_busqueda_extraordinario.SelectedIndex >= 0)
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,dp.nombre AS DEPARTAMENTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN tbl_departamentos  as dp ON fk_departamento=id_departamento INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "' and  TEX." + selector + " LIKE '" + tb_busqueda_extraordinario.Text + "%'");
                    dgv_extraordinario.DataSource = ds.Tables[0];
                    dgv_extraordinario.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,dp.nombre AS DEPARTAMENTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN tbl_departamentos  as dp ON fk_departamento=id_departamento INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "' ");
                dgv_extraordinario.DataSource = ds.Tables[0];
                dgv_extraordinario.Columns[0].Visible = false;
            }
        }

        private void acciones_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_numero_accion_personal) & validartexbox(tb_costo_personal) & validartexbox(tb_codigo_personal) & validartexbox(tb_puesto_personal) & validartexbox(tb_dias_personal))
            {
                if (seleccionarempleado)
                {
                    if (conexion.querycomando("Insert into tbl_accion_personal(numero_accion,motivo,sustitucion,costo,codigo_plaza,puesto,rige_desde,rige_hasta,total_dias,fecha_ubicacion,fecha_vacaciones,fecha_pago,observaciones,fecha_registro_accion_personal) VALUES('" + tb_numero_accion_personal.Text + "','" + cb_motivo_personal.SelectedItem + "','" + cb_sustitucion_personal.SelectedItem + "','" + tb_costo_personal.Text + "','" + tb_codigo_personal.Text + "','" + tb_puesto_personal.Text + "','" + dtp_desde_personal.Value.Date + "','" + dtp_hasta_personal.Value.Date + "','" + tb_dias_personal.Text + "','" + dtp_fechaescala_personal.Value.Date + "','" + dtp_fechavacaciones_personal.Value.Date + "','" + dtp_fecha_pago_personal.Value.Date + "','" + rtb_observaciones_personal.Text + "',GETDATE())"))
                    {
                        DataSet ds;
                        ds = conexion.sqlconsulta("SELECT * FROM tbl_accion_personal WHERE id_accion_personal = (SELECT MAX(id_accion_personal) FROM tbl_accion_personal)");

                        conexion.querycomando("Insert into tbl_accion_personal_empleados(fk_accion_personal,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                        conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario,fecha_registro) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','ACCION DE PERSONAL','INSERTO UN REGISTRO','" + usuario + "',GETDATE())");
                        MessageBox.Show("Se ha guardado correctamente");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");

                    actualizardato(dgv_personal, "Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                    actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                    tb_numero_accion_personal.Clear();
                    tb_costo_personal.Clear();
                    tb_costo_personal.Clear();
                    tb_puesto_personal.Clear();
                    tb_dias_personal.Clear();
                    cb_motivo_personal.SelectedIndex = 0;
                    cb_sustitucion_personal.SelectedIndex = 0;



                }
                else
                    MessageBox.Show("selecciona un empleado ");



            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (validartexbox(tb_numero_accion_personal) & validartexbox(tb_costo_personal) & validartexbox(tb_codigo_personal) & validartexbox(tb_puesto_personal) & validartexbox(tb_dias_personal))
            {
                if (seleccionarpersonal)
                {
                    if (conexion.querycomando("Update tbl_accion_personal set numero_accion='" + tb_numero_accion_personal.Text + "', motivo='" + cb_motivo_personal.SelectedItem + "',sustitucion='" + cb_sustitucion_personal.SelectedItem + "', costo='" + tb_costo_personal.Text + "', codigo_plaza='" + tb_codigo_personal.Text + "', puesto='" + tb_puesto_personal.Text + "', rige_desde='" + dtp_desde_personal.Value.Date + "', rige_hasta='" + dtp_hasta_personal.Value.Date + "', total_dias='" + tb_dias_personal.Text + "', fecha_ubicacion='" + dtp_fechaescala_personal.Value.Date + "', fecha_vacaciones='" + dtp_fechavacaciones_personal.Value.Date + "', fecha_pago='" + dtp_fecha_pago_personal.Value.Date + "', observaciones='" + rtb_observaciones_personal.Text + "' WHERE id_accion_personal='" + ID_personal.ToString() + "'"))
                    {
                        conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_personal + "','ACCION DE PERSONAL','ACTUALIZO UN REGISTRO','" + usuario + "')");
                        MessageBox.Show("Se ha actualizado correctamente");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                else
                    MessageBox.Show("Seleccione algun cliente para realizar esta accion");

                seleccionarpersonal = false;
                actualizardato(dgv_personal, "Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                tb_numero_accion_personal.Clear();
                tb_costo_personal.Clear();
                tb_costo_personal.Clear();
                tb_puesto_personal.Clear();
                tb_dias_personal.Clear();
                cb_motivo_personal.SelectedIndex = 0;
                cb_sustitucion_personal.SelectedIndex = 0;

            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (seleccionarpersonal)
            {
                if (conexion.querycomando("DELETE FROM tbl_accion_personal_empleados WHERE fk_accion_personal='" + ID_personal.ToString() + "' "))
                {
                    if (conexion.querycomando("DELETE FROM tbl_accion_personal WHERE id_accion_personal='" + ID_personal.ToString() + "' "))
                    {
                        conexion.querycomando("Insert into tbl_registros(numero_movimiento ,tipo_movimiento,accion,fk_usuario) VALUES('" + ID_personal + "','ACCION DE PERSONAL','ELIMINO UN REGISTRO','" + usuario + "')");
                        MessageBox.Show("Se ha eliminado correctamente");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                }
                else
                    MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                seleccionarpersonal = false;
                actualizardato(dgv_personal, "Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                actualizardato(dgv_registro, "Select id_registro,numero_movimiento 'NUMERO DE MOVIMIENTO',tipo_movimiento 'TIPO DE MOVIMIENTO',accion 'ACCCION',TU.nombre 'NOMBRE', fecha_registro AS 'FECHA DE REGISTRO',registro as REGISTRO ,TU.usuario AS 'USUARIO' FROM tbl_registros AS TE INNER JOIN tbl_usuarios AS TU on id_usuario=fk_usuario   ");
                tb_numero_accion_personal.Clear();
                tb_costo_personal.Clear();
                tb_costo_personal.Clear();
                tb_puesto_personal.Clear();
                tb_dias_personal.Clear();
                cb_motivo_personal.SelectedIndex = 0;
                cb_sustitucion_personal.SelectedIndex = 0;

            }
            else
                MessageBox.Show("Seleccione un empleado de la lista");
        }

        private void dgv_personal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarpersonal = true;
                ID_personal = int.Parse(dgv_personal.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_numero_accion_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[1].Value.ToString();
                cb_motivo_personal.SelectedItem = dgv_personal.Rows[e.RowIndex].Cells[2].Value.ToString();
                cb_sustitucion_personal.SelectedItem = dgv_personal.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_costo_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[4].Value.ToString();
                tb_codigo_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[5].Value.ToString();
                tb_puesto_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[6].Value.ToString();
                dtp_desde_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtp_hasta_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[8].Value.ToString();
                tb_dias_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[9].Value.ToString();
                dtp_fechaescala_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[10].Value.ToString();
                dtp_fechavacaciones_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[11].Value.ToString();
                dtp_fecha_pago_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[12].Value.ToString();
                rtb_observaciones_personal.Text = dgv_personal.Rows[e.RowIndex].Cells[13].Value.ToString();






            }
            catch (Exception ex)
            {
            }
        }

        private void tb_costo_personal_MouseEnter(object sender, EventArgs e)
        {
            //// El control TextBox ha tomado el foco.
            ////
            //// Referenciamos el control TextBox que ha
            //// desencadenado el evento.
            ////
            //TextBox tb = (TextBox)sender;

            //// Mostramos en el control TextBox el valor
            //// de la propiedad Tag sin formatear.
            ////
            //string tbtexto = tb.Text;
            //tb.Text = Convert.ToString(tbtexto);
        }

        private void tb_costo_personal_MouseLeave(object sender, EventArgs e)
        {
            //// El control TextBox ha perdido el foco.
            ////
            //// Referenciamos el control TextBox que ha
            //// desencadenado el evento.
            ////
            //TextBox tb = (TextBox)sender;

            //// Primero verificamos si el valor se puede convertir a Decimal.
            ////
            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);

            //if ((!(bln)))
            //{
            //    // No es un valor decimal válido; limpiamos el control.
            //    tb.Clear();
            //    return;
            //}

            //// En la propiedad Tag guardamos el valor con todos los decimales.
            ////
            //tb.Tag = numero;

            //// Y acto seguido formateamos el valor
            //// a monetario con dos decimales.
            ////
            //tb.Text = string.Format("{0:#.00}", numero);
        }

        private void tb_monto_extraordinario_MouseEnter(object sender, EventArgs e)
        {
            //// El control TextBox ha tomado el foco.
            ////
            //// Referenciamos el control TextBox que ha
            //// desencadenado el evento.
            ////
            //TextBox tb = (TextBox)sender;

            //// Mostramos en el control TextBox el valor
            //// de la propiedad Tag sin formatear.
            ////
            //string tbtexto = tb.Text;
            //tb.Text = Convert.ToString(tbtexto);
        }

        private void tb_monto_extraordinario_MouseLeave(object sender, EventArgs e)
        {
            //// El control TextBox ha perdido el foco.
            ////
            //// Referenciamos el control TextBox que ha
            //// desencadenado el evento.
            ////
            //TextBox tb = (TextBox)sender;

            //// Primero verificamos si el valor se puede convertir a Decimal.
            ////
            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);

            //if ((!(bln)))
            //{
            //    // No es un valor decimal válido; limpiamos el control.
            //    tb.Clear();
            //    return;
            //}

            //// En la propiedad Tag guardamos el valor con todos los decimales.
            ////
            //tb.Tag = numero;

            //// Y acto seguido formateamos el valor
            //// a monetario con dos decimales.
            ////
            //tb.Text = string.Format("{0:#.00}", numero);
        }

        private void tb_monto_cancelar_extras_MouseEnter(object sender, EventArgs e)
        {

            //TextBox tb = (TextBox)sender;


            //string tbtexto = tb.Text;
            //tb.Text = Convert.ToString(tbtexto);
        }

        private void tb_monto_cancelar_extras_MouseLeave(object sender, EventArgs e)
        {

            //TextBox tb = (TextBox)sender;


            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);

            //if ((!(bln)))
            //{

            //    tb.Clear();
            //    return;
            //}


            //tb.Tag = numero;


            //tb.Text = string.Format("{0:#.00}", numero);
        }

        private void tb_monto_presupuesto_MouseEnter(object sender, EventArgs e)
        {
            //    TextBox tb = (TextBox)sender;


            //    string tbtexto = tb.Text;
            //    tb.Text = Convert.ToString(tbtexto);
        }

        private void tb_monto_presupuesto_MouseLeave(object sender, EventArgs e)
        {
            //TextBox tb = (TextBox)sender;


            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);

            //if ((!(bln)))
            //{

            //    tb.Clear();
            //    return;
            //}


            //tb.Tag = numero;


            //tb.Text = string.Format("{0:#.00}", numero);
        }

        private void tb_monto_remuneracion_MouseEnter(object sender, EventArgs e)
        {
            //TextBox tb = (TextBox)sender;


            //string tbtexto = tb.Text;
            //tb.Text = Convert.ToString(tbtexto);
        }

        private void tb_monto_remuneracion_MouseLeave_1(object sender, EventArgs e)
        {
            //TextBox tb = (TextBox)sender;


            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);

            //if ((!(bln)))
            //{

            //    tb.Clear();
            //    return;
            //}


            //tb.Tag = numero;


            //tb.Text = string.Format("{0:#.00}", numero);
        }

        private void tb_busqueda_extras_MouseEnter(object sender, EventArgs e)
        {
            if (tb_busqueda_extras.Text == "Buscar")
            {
                tb_busqueda_extras.Clear();
            }
        }

        private void tb_busqueda_extras_MouseLeave(object sender, EventArgs e)
        {
            if (tb_busqueda_extras.Text == "")
            {
                tb_busqueda_extras.Text = "Buscar";
            }
        }

        private void tb_buscar_remuneracion_MouseEnter(object sender, EventArgs e)
        {
            if (tb_buscar_remuneracion.Text == "Buscar")
            {
                tb_buscar_remuneracion.Clear();
            }
        }

        private void tb_buscar_remuneracion_MouseLeave(object sender, EventArgs e)
        {
            if (tb_buscar_remuneracion.Text == "")
            {
                tb_buscar_remuneracion.Text = "Buscar";
            }
        }

        private void tb_busqueda_empleado_MouseEnter(object sender, EventArgs e)
        {
            if (tb_busqueda_empleado.Text == "Buscar")
            {
                tb_busqueda_empleado.Clear();
            }
        }

        private void tb_busqueda_empleado_MouseLeave(object sender, EventArgs e)
        {
            if (tb_busqueda_empleado.Text == "")
            {
                tb_busqueda_empleado.Text = "Buscar";
            }
        }

        private void tb_busqueda_extraordinario_MouseEnter(object sender, EventArgs e)
        {
            if (tb_busqueda_extraordinario.Text == "Buscar")
            {
                tb_busqueda_extraordinario.Clear();
            }
        }

        private void tb_busqueda_extraordinario_MouseLeave(object sender, EventArgs e)
        {
            if (tb_busqueda_extraordinario.Text == "")
            {
                tb_busqueda_extraordinario.Text = "Buscar";
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            string selector = "";
            if (tb_busqueda_personal.Text != "" & tb_busqueda_personal.Text != "Buscar")
            {
                switch (cb_busqueda_personal.SelectedItem)
                {

                    case "Numero accion":
                        selector = "numero_accion";
                        break;
                    case "Motivo":
                        selector = "motivo";
                        break;
                    case "Sustitucion":
                        selector = "sustitucion";
                        break;

                }
                if (cb_busqueda_personal.SelectedIndex >= 0)
                {

                    DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "'  and  TAP." + selector + " LIKE '" + tb_busqueda_personal.Text + "%'");
                    dgv_personal.DataSource = ds.Tables[0];
                    dgv_personal.Columns[0].Visible = false;
                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where id_empleado ='" + ID_usuario + "' ");
                dgv_personal.DataSource = ds.Tables[0];
                dgv_personal.Columns[0].Visible = false;
            }
        }

        private void tb_busqueda_personal_MouseEnter(object sender, EventArgs e)
        {
            if (tb_busqueda_personal.Text == "Buscar")
            {
                tb_busqueda_personal.Clear();
            }
        }

        private void tb_busqueda_personal_MouseLeave(object sender, EventArgs e)
        {
            if (tb_busqueda_personal.Text == "")
            {
                tb_busqueda_personal.Text = "Buscar";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo_reporte.SelectedIndex == 0)
            {
                cb_dato_reporte.Items.Clear();
                cb_dato_reporte.Items.Add("Cedula");
                cb_dato_reporte.Items.Add("Nombre");
                cb_dato_reporte.Items.Add("Apellido");
                cb_dato_reporte.Items.Add("Puesto");
                cb_dato_reporte.Items.Add("Departamento");
                cb_dato_reporte.SelectedIndex = 0;
                DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento");
                dgv_reportes.DataSource = ds.Tables[0];
                dgv_reportes.Columns[0].Visible = false;
            }
            else
            {
                if (cb_tipo_reporte.SelectedIndex == 1)
                {
                    cb_dato_reporte.Items.Clear();
                    cb_dato_reporte.Items.Add("Numero de movimiento");
                    cb_dato_reporte.Items.Add("Tipo remuneracion");
                    cb_dato_reporte.Items.Add("Fecha de pago");
                    cb_dato_reporte.SelectedIndex = 0;
                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado   ");
                    dgv_reportes.DataSource = ds.Tables[0];
                    dgv_reportes.Columns[0].Visible = false;

                }
                else
                {
                    if (cb_tipo_reporte.SelectedIndex == 2)
                    {
                        cb_dato_reporte.Items.Clear();
                        cb_dato_reporte.Items.Add("Tipo presupuesto");
                        cb_dato_reporte.Items.Add("Monto");

                        cb_dato_reporte.SelectedIndex = 0;
                        DataSet ds = conexion.sqlconsulta("select * from tbl_presupuestos");
                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;

                    }
                    else
                    {
                        if (cb_tipo_reporte.SelectedIndex == 3)
                        {
                            cb_dato_reporte.Items.Clear();

                            cb_dato_reporte.Items.Add("Codigo de plaza");
                            cb_dato_reporte.Items.Add("Cantidad de horas");
                            cb_dato_reporte.Items.Add("Monto");
                            cb_dato_reporte.Items.Add("Fecha de pago");

                            cb_dato_reporte.SelectedIndex = 0;
                            DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                            dgv_reportes.DataSource = ds.Tables[0];
                            dgv_reportes.Columns[0].Visible = false;

                        }
                        else
                        {
                            if (cb_tipo_reporte.SelectedIndex == 4)
                            {
                                cb_dato_reporte.Items.Clear();
                                cb_dato_reporte.Items.Add("Tipo extraordinario");
                                cb_dato_reporte.Items.Add("Codigo de plaza");
                                cb_dato_reporte.Items.Add("Cantidad de horas");
                                cb_dato_reporte.Items.Add("Monto");
                                cb_dato_reporte.Items.Add("Fecha de pago");
                                cb_dato_reporte.SelectedIndex = 0;
                                DataSet ds = conexion.sqlconsulta("Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                                dgv_reportes.DataSource = ds.Tables[0];
                                dgv_reportes.Columns[0].Visible = false;

                            }
                            else
                            {
                                if (cb_tipo_reporte.SelectedIndex == 5)
                                {
                                    cb_dato_reporte.Items.Clear();
                                    cb_dato_reporte.Items.Add("Numero de accion");
                                    cb_dato_reporte.Items.Add("Motivo");
                                    cb_dato_reporte.Items.Add("Sustitucion");
                                    cb_dato_reporte.Items.Add("Puesto");
                                    cb_dato_reporte.Items.Add("Total de dias");
                                    cb_dato_reporte.Items.Add("Fecha de regir");
                                    cb_dato_reporte.Items.Add("Fecha de pago");
                                    cb_dato_reporte.SelectedIndex = 0;

                                    DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado ");
                                    dgv_reportes.DataSource = ds.Tables[0];
                                    dgv_reportes.Columns[0].Visible = false;
                                }


                            }


                        }


                    }

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_reportes.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                //if (sfd.ShowDialog() == DialogResult.OK)
                //{
                //if (File.Exists(sfd.FileName))
                //{
                //    try
                //    {
                //        File.Delete(sfd.FileName);
                //    }
                //    catch (IOException ex)
                //    {
                //        fileError = true;
                //        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                //    }
                //}
                if (!fileError)
                {

                    try
                    {
                        PdfPTable pdfTable = new PdfPTable(dgv_reportes.Columns.Count);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in dgv_reportes.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable.AddCell(cell);

                        }

                        foreach (DataGridViewRow row in dgv_reportes.Rows)
                        {

                            foreach (DataGridViewCell cell in row.Cells)
                            {

                                pdfTable.AddCell(cell.Value.ToString());

                            }
                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);

                            pdfDoc.Open();
                            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("rh.png");
                            //image1.ScalePercent(50f);

                            image1.ScaleAbsoluteWidth(150);
                            image1.ScaleAbsoluteHeight(45);
                            pdfDoc.Add(image1);
                            Paragraph title = new Paragraph();
                            title.Alignment = Element.ALIGN_CENTER;
                            title.Font = FontFactory.GetFont(FontFactory.TIMES, 20f, BaseColor.BLACK);
                            title.Add(cb_tipo_reporte.SelectedItem.ToString());
                            title.SpacingAfter = 20;
                            pdfDoc.Add(title);

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();

                        }
                        System.Diagnostics.Process.Start(sfd.FileName);
                        //webBrowser1.Navigate(sfd.FileName);
                        //webBrowser1.Show();
                        MessageBox.Show("Informacion se exporto correctamente !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
            //}
            //else
            //{
            //    MessageBox.Show("No Record To Export !!!", "Info");
            //}
        }

        private void cb_dato_personal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo_reporte.SelectedIndex == 0 & cb_dato_reporte.SelectedIndex >= 0)
            {
                llb_raya_reporte.Show();
                tb_reporte.Show();
                lb_dato.Show();
                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                lb_desde_reporte.Show();
                lb_hasta_reporte.Show();
                dtp_desde_reporte.Show();
                dtp_hasta_reporte.Show();
                dtp_fecha_reporte.Hide();




            }
            else
            {
                if (cb_tipo_reporte.SelectedIndex == 1 & cb_dato_reporte.SelectedIndex < 2)
                {
                    llb_raya_reporte.Show();
                    tb_reporte.Show();
                    lb_dato.Show();
                    lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                    lb_desde_reporte.Show();
                    lb_hasta_reporte.Show();
                    dtp_desde_reporte.Show();
                    dtp_hasta_reporte.Show();
                    dtp_fecha_reporte.Hide();

                }
                else
                {
                    if (cb_tipo_reporte.SelectedIndex == 1 & cb_dato_reporte.SelectedIndex > 1)
                    {

                        llb_raya_reporte.Hide();
                        tb_reporte.Hide();
                        lb_dato.Show();
                        lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                        dtp_fecha_reporte.Show();
                        lb_desde_reporte.Show();
                        lb_hasta_reporte.Show();
                        dtp_desde_reporte.Show();
                        dtp_hasta_reporte.Show();


                    }
                    else
                    {

                        if (cb_tipo_reporte.SelectedIndex == 2 & cb_dato_reporte.SelectedIndex >= 0)
                        {
                            llb_raya_reporte.Show();
                            tb_reporte.Show();
                            lb_dato.Show();
                            lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                            lb_desde_reporte.Show();
                            lb_hasta_reporte.Show();
                            dtp_desde_reporte.Show();
                            dtp_hasta_reporte.Show();
                            dtp_fecha_reporte.Hide();
                            lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();


                        }
                        else
                        {
                            if (cb_tipo_reporte.SelectedIndex == 3 & cb_dato_reporte.SelectedIndex >= 0 & cb_dato_reporte.SelectedIndex < 3)
                            {


                                llb_raya_reporte.Show();
                                tb_reporte.Show();
                                lb_dato.Show();
                                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                lb_desde_reporte.Show();
                                lb_hasta_reporte.Show();
                                dtp_desde_reporte.Show();
                                dtp_hasta_reporte.Show();
                                dtp_fecha_reporte.Hide();
                                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();



                            }
                            else
                            {
                                if (cb_tipo_reporte.SelectedIndex == 3 & cb_dato_reporte.SelectedIndex > 2)
                                {

                                    llb_raya_reporte.Hide();
                                    tb_reporte.Hide();
                                    lb_dato.Show();
                                    lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                    dtp_fecha_reporte.Show();
                                    lb_desde_reporte.Show();
                                    lb_hasta_reporte.Show();
                                    dtp_desde_reporte.Show();
                                    dtp_hasta_reporte.Show();

                                }
                                else
                                {
                                    if (cb_tipo_reporte.SelectedIndex == 4 & cb_dato_reporte.SelectedIndex >= 0 & cb_dato_reporte.SelectedIndex < 4)
                                    {


                                        llb_raya_reporte.Show();
                                        tb_reporte.Show();
                                        lb_dato.Show();
                                        lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                        lb_desde_reporte.Show();
                                        lb_hasta_reporte.Show();
                                        dtp_desde_reporte.Show();
                                        dtp_hasta_reporte.Show();
                                        dtp_fecha_reporte.Hide();
                                        lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();


                                    }
                                    else
                                    {
                                        if (cb_tipo_reporte.SelectedIndex == 4 & cb_dato_reporte.SelectedIndex > 3)
                                        {

                                            llb_raya_reporte.Hide();
                                            tb_reporte.Hide();
                                            lb_dato.Show();
                                            lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                            dtp_fecha_reporte.Show();
                                            lb_desde_reporte.Show();
                                            lb_hasta_reporte.Show();
                                            dtp_desde_reporte.Show();
                                            dtp_hasta_reporte.Show();

                                        }
                                        else
                                        {
                                            if (cb_tipo_reporte.SelectedIndex == 5 & cb_dato_reporte.SelectedIndex >= 0 & cb_dato_reporte.SelectedIndex < 5)
                                            {


                                                llb_raya_reporte.Show();
                                                tb_reporte.Show();
                                                lb_dato.Show();
                                                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                                lb_desde_reporte.Show();
                                                lb_hasta_reporte.Show();
                                                dtp_desde_reporte.Show();
                                                dtp_hasta_reporte.Show();
                                                dtp_fecha_reporte.Hide();
                                                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();


                                            }
                                            else
                                            {

                                                llb_raya_reporte.Hide();
                                                tb_reporte.Hide();
                                                lb_dato.Show();
                                                lb_dato.Text = cb_dato_reporte.SelectedItem.ToString();
                                                dtp_fecha_reporte.Show();
                                                lb_desde_reporte.Show();
                                                lb_hasta_reporte.Show();
                                                dtp_desde_reporte.Show();
                                                dtp_hasta_reporte.Show();
                                            }
                                        }

                                    }



                                }

                            }



                        }

                    }
                }
            }
        }

        private void tb_reporte_TextChanged(object sender, EventArgs e)
        {
            if (cb_tipo_reporte.SelectedIndex == 0 & cb_dato_reporte.SelectedIndex >= 0)
            {
                String selector = "";
                switch (cb_dato_reporte.SelectedItem)
                {
                    case "Cedula":
                        selector = "cedula";
                        break;
                    case "Nombre":
                        selector = "nombre";
                        break;
                    case "Apellido":
                        selector = "apellido";
                        break;
                    case "Puesto":
                        selector = "puesto";
                        break;
                    case "Departamento":
                        selector = "fk_departamento";
                        break;

                }
                if (tb_reporte.Text != "")
                {
                    if (cb_empleado_busqueda.SelectedIndex >= 0)
                    {

                        DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento WHERE" + " TE." + selector + " " + " LIKE '" + tb_reporte.Text + "%'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            dgv_reportes.DataSource = ds.Tables[0];
                            dgv_reportes.Columns[0].Visible = false;
                        }
                    }
                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_empleado,cedula as CEDULA,TE.nombre AS NOMBRE,apellido AS APELLIDO,fecha_nacimiento AS 'FECHA NACIMIENTO',tipo_nombramiento AS 'TIPO DE NOMBRAMIENTO',TE.codigo AS CODIGO,fecha_escala AS 'FECHA ESCALA',fecha_vacaciones AS 'FECHA DE VACACIONES',puesto AS PUESTO ,TD.nombre AS NOMBRE from tbl_empleados AS TE INNER JOIN tbl_departamentos AS TD on id_departamento=fk_departamento");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }





            if (cb_tipo_reporte.SelectedIndex == 1 & cb_dato_reporte.SelectedIndex >= 0)
            {

                string selector = "";
                switch (cb_dato_reporte.SelectedItem)
                {

                    case "Numero de movimiento":
                        selector = "numero_movimiento";
                        break;
                    case "Tipo renumeracion":
                        selector = "tipo";
                        break;

                }

                if (tb_reporte.Text != "")
                {


                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones as TR INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where " + " TR." + selector.Trim() + "  LIKE '" + tb_reporte.Text + "%'  and fecha_registro_renumeracion BETWEEN '"+dtp_desde_reporte.Value.Date+"' AND '"+dtp_hasta_reporte.Value.Date+"'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;

                    }

                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado   ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }




            }







            if (cb_tipo_reporte.SelectedIndex == 2 & cb_dato_reporte.SelectedIndex >= 0)
            {
                string selector = "";

                switch (cb_dato_reporte.SelectedItem)
                {

                    case "Tipo presupuesto":
                        selector = "numero_movimiento";
                        break;
                    case "Monto":
                        selector = "tipo";
                        break;

                }
                if (tb_reporte.Text != "")
                {
                    if (cb_dato_reporte.SelectedIndex >= 0)
                    {
                        DataSet ds = conexion.sqlconsulta(" select * from tbl_presupuestos WHERE " + selector + " LIKE '" + tb_reporte.Text + "%'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            dgv_reportes.DataSource = ds.Tables[0];
                            dgv_reportes.Columns[0].Visible = false;
                        }
                    }
                }
                else
                {
                    

                        DataSet ds = conexion.sqlconsulta("select * from tbl_presupuestos");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }

            }




            if (cb_tipo_reporte.SelectedIndex == 3 & cb_dato_reporte.SelectedIndex >= 0)
            {

                string selector = "";
                switch (cb_dato_reporte.SelectedItem)
                {

                    case "Codigo de plaza":
                        selector = "codigo_plaza";
                        break;
                    case "Cantidad de horas":
                        selector = "cantidad_horas";
                        break;
                    case "Monto":
                        selector = "monto_cancelar";
                        break;
                    case "Fecha de pago":
                        selector = "fecha_pago";
                        break;
                }

                if (tb_reporte.Text != "")
                {


                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas TEM INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where   TEM." + selector + " LIKE '" + tb_reporte.Text + "%' and fecha_registro_extras BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }


                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }








            if (cb_tipo_reporte.SelectedIndex == 4 & cb_dato_reporte.SelectedIndex >= 0)
            {

                string selector = "";
                switch (cb_dato_reporte.SelectedItem)
                {
                    case "Tipo extraordinario":
                        selector = "tipo_extraordinario";
                        break;
                    case "Codigo de plaza":
                        selector = "codigo_plaza";
                        break;
                    case "Cantidad de horas":
                        selector = "cantidad_horas";
                        break;
                    case "Monto":
                        selector = "monto";
                        break;

                }

                if (tb_reporte.Text != "")
                {


                    DataSet ds = conexion.sqlconsulta("Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where   TEX." + selector + " LIKE '" + tb_reporte.Text + "%' and fecha_registro_ordinario BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;

                    }

                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }








            if (cb_tipo_reporte.SelectedIndex == 5 & cb_dato_reporte.SelectedIndex >= 0)
            {


                String selector = "";
                switch (cb_dato_reporte.SelectedItem)
                {
                    case "Numero de accion":
                        selector = "numero_accion";
                        break;
                    case "Motivo":
                        selector = "motivo";
                        break;
                    case "Sustitucion":
                        selector = "sustitucion";
                        break;
                    case "Puesto":
                        selector = "puesto";
                        break;
                    case "Total de dias":
                        selector = "total_dias";
                        break;

                }
                if (tb_reporte.Text != "")
                {
                    if (cb_empleado_busqueda.SelectedIndex >= 0)
                    {

                        DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where  TAP." + selector + " LIKE '" + tb_reporte.Text + "%' and fecha_registro_accion_personal BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            dgv_reportes.DataSource = ds.Tables[0];
                            dgv_reportes.Columns[0].Visible = false;
                        }
                    }
                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }




        }

        private void dtp_fecha_reporte_ValueChanged(object sender, EventArgs e)
        {

            if (cb_tipo_reporte.SelectedIndex == 1 & cb_dato_reporte.SelectedIndex >= 2)
            {


                if (dtp_fecha_reporte.Text != "")
                {


                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones as TR INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where  TR.fecha_pago  = '" + dtp_fecha_reporte.Value.Date + "' and fecha_registro_renumeracion BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;


                    }
                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_remuneracion,numero_movimiento AS 'NUMERO MOVIMIENTO',tipo AS TIPO,fecha_pago AS 'FECHA DE PAGO',monto AS MONTO ,te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_remuneraciones INNER JOIN  tbl_empleados_remuneraciones  ON fk_remuneracion=id_remuneracion INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado   ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }



            }

            if (cb_dato_reporte.SelectedIndex >= 3)
            {
                if (dtp_fecha_reporte.Text != "")
                {

                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extras_medicas TEM INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where   TEM.fecha_pago = '" + dtp_fecha_reporte.Value.Date + "' and fecha_registro_extras BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }





            if (cb_dato_reporte.SelectedIndex >= 4)
            {
                if (dtp_fecha_reporte.Text != "")
                {

                    DataSet ds = conexion.sqlconsulta("Select id_extraordinario,tipo_extraordinario AS 'TIPO DE EXTRAORDINARIO',fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto AS MONTO,te.nombre AS NOMBRE,te.apellido AS APELLIDO from tbl_extraordinario TEX INNER JOIN  tbl_extraordinario_empleados  ON fk_extraordinario=id_extraordinario INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where   TEX.fecha_pago = '" + dtp_fecha_reporte.Value.Date + "' and fecha_registro_ordinario BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }

                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_extras,fecha_pago AS 'FECHA DE PAGO',codigo_plaza AS 'CODIGO DE PLAZA',cantidad_horas AS 'CANTIDAD DE HORAS',monto_cancelar AS 'MONTO A CANCELAR',te.nombre AS NOMBRE ,te.apellido AS APELLIDO from tbl_extras_medicas INNER JOIN  tbl_extras_medicas_empleados  ON fk_extras=id_extras INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado  ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }



            string selector = "";

            if (cb_dato_reporte.SelectedIndex >= 5)
            {

                switch (cb_dato_reporte.SelectedItem)
                {
                    case "Fecha de regir":
                        selector = "rige_desde";
                        break;
                    case "Fecha de pago":
                        selector = "fecha_pago";
                        break;


                }
                if (dtp_fecha_reporte.Text != "")
                {

                    DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado where  TAP." + selector + " = '" + dtp_fecha_reporte.Value.Date + "' and fecha_registro_accion_personal BETWEEN '" + dtp_desde_reporte.Value.Date + "' AND '" + dtp_hasta_reporte.Value.Date + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
                else
                {
                    DataSet ds = conexion.sqlconsulta("Select id_accion_personal,numero_accion AS 'NUMERO DE ACCION',motivo AS MOTIVO,sustitucion AS SUSTITUCION,costo AS COSTO,codigo_plaza AS 'CODIGO DE PLAZA',TAP.puesto AS PUESTO,rige_desde AS 'RIGE DESDE',rige_hasta AS 'RIGE HASTA',total_dias AS 'TOTAL DE DIAS',fecha_ubicacion 'FECHA DE UBICACION',TAP.fecha_vacaciones AS 'FECHA DE VACACIONES',fecha_pago AS 'FECHA DE PAGO',observaciones AS 'OBSERVACIONES' from tbl_accion_personal TAP INNER JOIN  tbl_accion_personal_empleados  ON fk_accion_personal=id_accion_personal INNER JOIN  tbl_empleados as te on id_empleado = fk_empleado ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_reportes.DataSource = ds.Tables[0];
                        dgv_reportes.Columns[0].Visible = false;
                    }
                }
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.Title = "To Excel";
            saveFileDialog1.FileName = this.Text + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(this.Text);
                for (int i = 0; i < dgv_reportes.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dgv_reportes.Columns[i].Name;
                }

                for (int i = 0; i < dgv_reportes.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_reportes.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgv_reportes.Rows[i].Cells[j].Value.ToString();

                        if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                        {
                            XLAlignmentHorizontalValues align;

                            switch (dgv_reportes.Rows[i].Cells[j].Style.Alignment)
                            {
                                case DataGridViewContentAlignment.BottomRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.MiddleRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.TopRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;

                                case DataGridViewContentAlignment.BottomCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.MiddleCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.TopCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;

                                default:
                                    align = XLAlignmentHorizontalValues.Left;
                                    break;
                            }

                            worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;

                            XLColor xlColor = XLColor.FromColor(dgv_reportes.Rows[i].Cells[j].Style.SelectionBackColor);
                            worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);

                            worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dgv_reportes.Font.Name;
                            worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dgv_reportes.Font.Size;

                        }
                    }
                }
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
                //MessageBox.Show("Done");
            }
        }

        private void tiempo_extraordinario_Click(object sender, EventArgs e)
        {

        }

        private void tb_codigo_personal_TextChanged(object sender, EventArgs e)
        {

            DataGridView dgv = new DataGridView();
            DataSet ds = conexion.sqlconsulta("Select puesto from tbl_plazas  where codigo='" + tb_codigo_personal.Text + "'");
            dgv.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {

                tb_puesto_personal.Text = ds.Tables[0].Rows[0][0].ToString();
            }


        }

        private void tb_monto_presupuesto_TextChanged(object sender, EventArgs e)
        {
            tb_monto_actual_presupuesto.Text = tb_monto_presupuesto.Text;
        }

        public Boolean actualizarmontodisminuir(string texto, TextBox tb_text)
        {


            DataSet data;
            data = conexion.sqlconsulta("SELECT id_presupuesto,monto_actual FROM tbl_presupuestos WHERE tipo_presupuesto='" + texto + "'");
            if (data.Tables[0].Rows.Count > 0)
            {
                double monto = double.Parse(data.Tables[0].Rows[0].ItemArray[1].ToString());
                int id_presupuesto = int.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString());

                if (monto > 0 & monto >= int.Parse(tb_text.Text))
                {
                    double monto_actual = monto - double.Parse(tb_text.Text);

                    if (conexion.querycomando("Update tbl_presupuestos set monto_actual='" + monto_actual + "' WHERE id_presupuesto='" + id_presupuesto.ToString() + "'"))
                    {
                        actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL' from tbl_presupuestos");

                        return true;
                    }
                    else {

                        MessageBox.Show("ocurrio un error");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("NO HAY MONTO SUFICIENTE");
                    return false;

                }
            }
            else
            {

                MessageBox.Show("NO HAY SALDO DISPONIBLE ");
                return false;
            }




        }

        public Boolean actualizarmontoaumentar(string sql, string texto)
        {
            DataSet data;
            data = conexion.sqlconsulta("SELECT id_presupuesto,monto_actual FROM tbl_presupuestos WHERE tipo_presupuesto='" + texto + "'");
            if (data.Tables[0].Rows.Count > 0)
            {
                double monto = double.Parse(data.Tables[0].Rows[0].ItemArray[1].ToString());
                int id_presupuesto = int.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString());

                data = conexion.sqlconsulta(sql);
                double monto_renumeracion = double.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString());
                double monto_actual = monto + monto_renumeracion;
                if (conexion.querycomando("Update tbl_presupuestos set monto_actual='" + monto_actual + "' WHERE id_presupuesto='" + id_presupuesto.ToString() + "'"))
                {
                    actualizardato(dgv_presupuesto, "select id_presupuesto ,tipo_presupuesto as 'TIPO DE PRESUPUESTO',monto_presupuesto as MONTO,monto_actual as 'MONTO ACTUAL' from tbl_presupuestos");
                    return true;
                } else
                    MessageBox.Show("ocurrio un error");
                return false;
            }
            else
            {

                MessageBox.Show("NO HAY SALDO DISPONIBLE ");
                return false;
            }



        }

        private void button19_Click(object sender, EventArgs e)
        {

            if (validartexbox(tb_boleta_incapacidades) & validartexbox(tb_plaza_incapacidades) & validartexbox(tb_puesto_incapacidades))
            {
                if (seleccionarempleado)
                {



                    //renumeracion por maternidad
                    if (conexion.querycomando("Insert into tbl_incapacidades(numero_boleta,tipo_incapacidad,fecha_pago,numero_plaza,puesto,fecha_registro) VALUES('" + tb_boleta_incapacidades.Text + "','" + cb_incapacidad.SelectedItem + "','" + dtp_fecha_pago_incapacidades.Value.Date + "','" + tb_plaza_incapacidades.Text + "','" + tb_puesto_incapacidades.Text + "',GETDATE() )"))
                    {
                        DataSet ds;
                        ds = conexion.sqlconsulta("SELECT * FROM tbl_incapacidades WHERE id_incapacidad = (SELECT MAX(id_incapacidad) FROM tbl_incapacidades)");

                        conexion.querycomando("Insert into tbl_incapacidades_empleados(fk_incapacidad,fk_empleado) VALUES('" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + ID_usuario + "')");
                        MessageBox.Show("Se ha guardado correctamente");
                    }
                    else
                        MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");




                }else
                MessageBox.Show("selecciona un empleado ");


                actualizardato(dgv_incapacidades, "Select id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");

                tb_boleta_incapacidades.Clear();
                tb_plaza_incapacidades.Clear();
                tb_puesto_incapacidades.Clear();

                cb_incapacidad.SelectedIndex = 0;

            }
              else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (validartexbox(tb_boleta_incapacidades) & validartexbox(tb_plaza_incapacidades) & validartexbox(tb_puesto_incapacidades))
            {
                if (seleccionarincapacidad)
                {
                   

                        if (conexion.querycomando("Update tbl_incapacidades set numero_boleta='" + tb_boleta_incapacidades.Text + "',tipo_incapacidad='" + cb_incapacidad.SelectedItem + "',fecha_pago='" + dtp_fecha_pago_incapacidades.Value.Date + "',numero_plaza='" + tb_plaza_incapacidades.Text + "', puesto='" + tb_puesto_incapacidades.Text + "' WHERE id_incapacidad='" + ID_incapacidad.ToString() + "'"))
                            MessageBox.Show("Se ha actualizado correctamente");
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    
                }
                else
                    MessageBox.Show("Seleccione alguna incapacidad para realizar esta accion");

                seleccionarremuneracion = false;
                actualizardato(dgv_incapacidades, "Select id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");


                tb_boleta_incapacidades.Clear();
                tb_plaza_incapacidades.Clear();
                tb_puesto_incapacidades.Clear();

                cb_incapacidad.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Hay campos en blanco no se puede guardar, por favor rellenar todos los campos pendientes");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (seleccionarincapacidad)
            {
               
                    if (conexion.querycomando("DELETE FROM tbl_incapacidades_empleados WHERE fk_incapacidad='" + ID_incapacidad.ToString() + "' "))
                    {
                        if (conexion.querycomando("DELETE FROM tbl_incapacidades WHERE id_incapacidad='" + ID_incapacidad.ToString() + "' "))
                            MessageBox.Show("Se ha eliminado correctamente");
                        else
                            MessageBox.Show("Ocurrio un error a la hora de guardar esta operacion, puede ser un error por la cedula que se este duplicando o reintentelo de nuevo o contacte al servicio tecnico");
                    }


                tb_boleta_incapacidades.Clear();
                tb_plaza_incapacidades.Clear();
                tb_puesto_incapacidades.Clear();

                cb_incapacidad.SelectedIndex = 0;
                actualizardato(dgv_incapacidades, "Select id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");

                seleccionarincapacidad = false;
            }
            else
            {
                MessageBox.Show("Seleccione un empleado de la lista");
            }
        }

        private void dgv_incapacidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionarincapacidad = true;
                ID_incapacidad = int.Parse(dgv_incapacidades.Rows[e.RowIndex].Cells[0].Value.ToString());
                tb_boleta_incapacidades.Text = dgv_incapacidades.Rows[e.RowIndex].Cells[1].Value.ToString();
                cb_incapacidad.SelectedItem = dgv_incapacidades.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtp_fecha_pago_incapacidades.Text = dgv_incapacidades.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_plaza_incapacidades.Text = dgv_incapacidades.Rows[e.RowIndex].Cells[4].Value.ToString();
                tb_puesto_incapacidades.Text = dgv_incapacidades.Rows[e.RowIndex].Cells[5].Value.ToString();



            }
            catch (Exception ex)
            {
            }
        }

        private void tb_plaza_incapacidades_TextChanged(object sender, EventArgs e)
        {
            DataGridView dgv = new DataGridView();
            DataSet ds = conexion.sqlconsulta("Select puesto from tbl_plazas  where codigo='" + tb_plaza_incapacidades.Text + "'");
            dgv.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {

                tb_puesto_incapacidades.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

        private void tb_buscar_incapacidad_TextChanged(object sender, EventArgs e)
        {
            string selector = "";
            if (tb_buscar_incapacidad.Text != "" & tb_buscar_incapacidad.Text != "Buscar")
            {
                if (cb_busqueda_incapacidades.SelectedIndex >= 0)
                {

                    switch (cb_busqueda_incapacidades.SelectedItem)
                    {

                        case "Numero de boleta":
                            selector = "numero_boleta";
                            break;
                        case "Tipo incapacidad":
                            selector = "tipo_incapacidad";
                            break;
                        case "Puesto":
                            selector = "puesto";
                            break;
                    }
                    DataSet ds = conexion.sqlconsulta("id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  AND" + " TR." + selector.Trim() + "  LIKE '" + tb_buscar_incapacidad.Text + "%'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        dgv_incapacidades.DataSource = ds.Tables[0];
                        dgv_incapacidades.Columns[0].Visible = false;
                    }

                }
            }
            else
            {
                DataSet ds = conexion.sqlconsulta("id_incapacidad,numero_boleta as 'NUMERO BOLETA',tipo_incapacidad AS 'TIPO DE INCAPACIDAD' ,fecha_pago AS 'FECHA DE PAGO',numero_plaza AS 'NUMERO DE PLAZA',ti.puesto AS 'PUESTO' from tbl_incapacidades ti INNER JOIN  tbl_incapacidades_empleados  ON fk_incapacidad=id_incapacidad INNER JOIN  tbl_empleados as te on id_empleado =fk_empleado where id_empleado ='" + ID_usuario + "'  ");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    dgv_incapacidades.DataSource = ds.Tables[0];
                    dgv_incapacidades.Columns[0].Visible = false;
                }
            }
        }
    }  
    } 

