using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;

namespace DataLayer
{
    public class SucursalDL
    {

        public List<Sucursal> get()
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("SELECT s.id,s.nombre, s.direccion, s.fecha_registro,b.id,b.nombre FROM Sucursal s join Banco b on (s.id_banco=b.id) order by s.id desc", cn.Obtener());
            cmd.CommandType = CommandType.Text;

            List<Sucursal> resultado = new List<Sucursal>();

            cn.Obtener().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resultado.Add(new Sucursal
                {
                    id = Convert.ToInt32(dr[0].ToString()),
                    nombre = dr[1].ToString(),
                    direccion = dr[2].ToString(),
                    fecharegistro = DateTime.Parse(dr[3].ToString()),
                    oBanco = new Banco { id = Convert.ToInt32(dr[4].ToString()), nombre = dr[5].ToString() }
                });
            }
            cn.Obtener().Close();

            return resultado;
        }

        public bool existe_sucursal(int idbanco)
        {
            Conexion cn = new Conexion();
            bool resultado = false;
            SqlCommand cmd = new SqlCommand("SELECT id,nombre, direccion, fecha_registro,id_banco FROM Sucursal where id_banco=@id_banco", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_banco", SqlDbType.Int).Value = idbanco;
            cn.Obtener().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                resultado = true;
            }
            cn.Obtener().Close();

            return resultado;
        }

        public List<Sucursal> getbyBanco(string banco)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("SELECT s.id,s.nombre, s.direccion, s.fecha_registro,b.id,b.nombre FROM Sucursal s join Banco b on (s.id_banco=b.id) where b.nombre=@banco order by s.id desc", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@banco", SqlDbType.VarChar).Value = banco;

            List<Sucursal> resultado = new List<Sucursal>();

            cn.Obtener().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resultado.Add(new Sucursal
                {
                    id = Convert.ToInt32(dr[0].ToString()),
                    nombre = dr[1].ToString(),
                    direccion = dr[2].ToString(),
                    fecharegistro = DateTime.Parse(dr[3].ToString()),
                    oBanco = new Banco { id = Convert.ToInt32(dr[4].ToString()), nombre = dr[5].ToString() }
                });
            }
            cn.Obtener().Close();

            return resultado;
        }

        public void add(Sucursal oSucursal)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("INSERT INTO Sucursal (nombre, direccion, fecha_registro,id_banco) VALUES(@nombre, @direccion, @fecha_registro,@id_banco)", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oSucursal.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oSucursal.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.DateTime).Value = oSucursal.fecharegistro;
            cmd.Parameters.Add("@id_banco", SqlDbType.Int).Value = oSucursal.oBanco.id;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public void update(Sucursal oSucursal)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("update Sucursal set nombre=@nombre, direccion=@direccion,id_banco=@idbanco where id=@id", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = oSucursal.id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oSucursal.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = oSucursal.direccion;
            cmd.Parameters.Add("@idbanco", SqlDbType.VarChar).Value = oSucursal.oBanco.id;
            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public void delete(Sucursal oSucursal)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("delete from Sucursal  where id=@id", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = oSucursal.id;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }
    }
}
