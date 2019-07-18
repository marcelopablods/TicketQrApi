using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Conexion
    {
        public static SqlConnection conectar() {

            SqlConnection con = new SqlConnection(@"Data Source=srv003;Initial Catalog=A5V2_Situr_Turistour_desarrollo;User ID=sa;Password=a51nk0");
            SqlConnection.ClearAllPools();
            Console.WriteLine(con.ToString());
            return con; 
        }

        //public static DataSet ejecutar_select(string query) {

        //    SqlConnection sqlCon = new SqlConnection(ClassGrid.Coneccion());
        //    SqlCommand command = new SqlCommand("sp_Paginacion_Grilla2", sqlCon);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add("PageSize", SqlDbType.Int).Value = pPageSize;//cantidad de registros
        //    command.Parameters.Add("CurrentPage", SqlDbType.Int).Value = pCurrentPage;//paginacion
        //    command.Parameters.Add("SortColumn", SqlDbType.VarChar, 40).Value = pSortColumn;//nombre de la columna con la que se ordena
        //    command.Parameters.Add("SortOrder", SqlDbType.VarChar, 4).Value = pSortOrder;// ass o dec
        //    command.Parameters.Add("tabla", SqlDbType.VarChar, 50).Value = tabla;// tabla
        //    command.Parameters.Add("filtro", SqlDbType.VarChar, 1000).Value = filtro;// Filtro manual
        //    command.Parameters.Add("IdUsuario", SqlDbType.VarChar, 50).Value = usuario;// idUsuario

        //    DataSet dataSet = new DataSet();
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //    dataAdapter.Fill(dataSet);
        //}

        public static DataSet ejecutar_select(string query)
        {
            conectar().Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conectar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            conectar().Close();
            return ds;
        }


        public static bool ejecutar_comando(string comando)
        {
            conectar().Open();
            SqlCommand cm = new SqlCommand(comando, conectar());
            bool rta;
            try
            {
                cm.Connection.Open();
                cm.ExecuteNonQuery();
                rta = true;
            }
            catch (Exception ex)
                {
                rta = false;
                Console.Write(ex);
            }
            return rta;
        }   
    }
}