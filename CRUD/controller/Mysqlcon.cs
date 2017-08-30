using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CRUD.controller
{
    public class Mysqlcon
    {
        public static MySqlConnection conn;
        public static String host;
        public static String database;
        public static String user;
        public static String passwd;

        public static void Open()
        {
            host = "localhost";
            database = "taller";
            user = "root";
            passwd = "";
            conn = new MySqlConnection("server=" + host + "; database=" + database + ";Uid=" + user + "; pwd=" + passwd + ";");
            conn.Open();
        }//end

        public static Boolean Exceute(String SQL)
        {
            Boolean estado = true;
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al ejecutar la consulta " + e.Message);
                estado = false;
            }
            return estado;
        }

        // esta clase es para hacer consultas select
        public static MySqlDataReader Query(String sql)
        {
            MySqlDataReader query=null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                query = cmd.ExecuteReader();
            }
             
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta "+ex.Message);
            }
            return query;
        }

    }
}
