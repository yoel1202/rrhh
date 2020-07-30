﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRHH.CONEXION
{
    public class BDconeccion
    {
        SqlConnection cnn;
        public BDconeccion(){
            string connetionString = null;
            
            connetionString = "Server=localhost\\SQLEXPRESS01;Database=bd_RRHH;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }

        }


        public DataSet sqlconsulta(String sql) {
            SqlCommand cmd = new SqlCommand(sql, cnn);
          DataSet ds= new DataSet() ;

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN LA CONSULTA "+ ex);
            }


            return ds;
     }

        public bool querycomando( string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void llenarComboBox( string sql, ComboBox  cb,  string id,  string nombre)
        {
            try
            {
                DataSet data = sqlconsulta(sql);

                if (data.Tables[0].Rows.Count > 0)
                {
                    cb.DataSource = data.Tables[0];
                    cb.DisplayMember = nombre;
                    cb.ValueMember = id;
                }
            }


            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + "error");
            }
        }
    }
}
