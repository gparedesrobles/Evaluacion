using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class BancoDL
    {
        public void add(Banco oBanco)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("INSERT INTO Banco (nombre, direccion, fecha_registro) VALUES(@nombre, @direccion, @fecha_registro)", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oBanco.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oBanco.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.DateTime).Value = oBanco.fecharegistro;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public List<Banco> get()
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("SELECT id,nombre, direccion, fecha_registro FROM Banco order by id desc", cn.Obtener());
            cmd.CommandType = CommandType.Text;

            List<Banco> resultado = new List<Banco>();

                cn.Obtener().Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                resultado.Add(new Banco
                {
                    id = Convert.ToInt32(dr[0].ToString()),
                    nombre = dr[1].ToString(),
                    direccion = dr[2].ToString(),
                    fecharegistro = DateTime.Parse(dr[3].ToString())
                });
                }
                cn.Obtener().Close();
                   
            return resultado;
        }

        public void update(Banco oBanco)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("update Banco set nombre=@nombre, direccion=@direccion where id=@id", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = oBanco.id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oBanco.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oBanco.direccion;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public void delete(Banco oBanco)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("delete from Banco  where id=@id", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = oBanco.id;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }
    }
}
