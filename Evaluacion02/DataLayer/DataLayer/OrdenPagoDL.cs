using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class OrdenPagoDL
    {

        public List<OrdenPago> get()
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("SELECT op.id,op.monto, op.moneda,op.estado, op.fecha_registro,b.id,b.nombre,s.id,s.nombre FROM Sucursal s join Banco b on (s.id_banco=b.id) join Orden_Pago op on (op.id_sucursal=s.id)order by op.id desc", cn.Obtener());
            cmd.CommandType = CommandType.Text;

            List<OrdenPago> resultado = new List<OrdenPago>();

            cn.Obtener().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resultado.Add(new OrdenPago
                {
                    id = int.Parse(dr[0].ToString()),
                    monto = decimal.Parse(dr[1].ToString()),
                    moneda = dr[2].ToString(),
                    estado = dr[3].ToString(),
                    fecharegistro = DateTime.Parse(dr[4].ToString()),
                    oSucursal = new Sucursal { oBanco = new Banco { id = Convert.ToInt32(dr[5].ToString()), nombre = dr[6].ToString() }, id = int.Parse(dr[7].ToString()), nombre = dr[8].ToString() }, 
                });
            }
            cn.Obtener().Close();

            return resultado;
        }

        public void add(OrdenPago oOrdenPago)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("INSERT INTO Orden_Pago (moneda, monto,estado, id_sucursal, fecha_registro) VALUES(@moneda, @monto,@estado, @idsucursal, @fecha_registro)", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@moneda", SqlDbType.VarChar).Value = oOrdenPago.moneda;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = oOrdenPago.monto;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = oOrdenPago.estado;
            cmd.Parameters.Add("@idsucursal", SqlDbType.Int).Value = oOrdenPago.oSucursal.id;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.DateTime).Value = oOrdenPago.fecharegistro;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public void update(OrdenPago oOrdenPago)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("update Orden_Pago set moneda=@moneda, monto=@monto,estado=@estado, id_sucursal=@idsucursal where id=@id", cn.Obtener());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = oOrdenPago.id;
            cmd.Parameters.Add("@moneda", SqlDbType.VarChar).Value = oOrdenPago.moneda;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = oOrdenPago.monto;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = oOrdenPago.estado;
            cmd.Parameters.Add("@idsucursal", SqlDbType.Int).Value = oOrdenPago.oSucursal.id;

            cn.Obtener().Open();

            cmd.ExecuteNonQuery();
            cn.Obtener().Close();
        }

        public List<OrdenPago> getBySucursalAndMoneda(string sucursal,string moneda)
        {
            Conexion cn = new Conexion();

            SqlCommand cmd = new SqlCommand("SELECT op.id,op.monto, op.moneda,op.estado, op.fecha_registro,b.id,b.nombre,s.id,s.nombre FROM Sucursal s join Banco b on (s.id_banco=b.id) join Orden_Pago op on (op.id_sucursal=s.id) where s.nombre=@sucursal and op.moneda=@moneda order by op.id desc", cn.Obtener());
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@sucursal", SqlDbType.VarChar).Value = sucursal;
            cmd.Parameters.Add("@moneda", SqlDbType.VarChar).Value = moneda;

            List<OrdenPago> resultado = new List<OrdenPago>();

            cn.Obtener().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resultado.Add(new OrdenPago
                {
                    id = int.Parse(dr[0].ToString()),
                    monto = decimal.Parse(dr[1].ToString()),
                    moneda = dr[2].ToString(),
                    estado = dr[3].ToString(),
                    fecharegistro = DateTime.Parse(dr[4].ToString()),
                    oSucursal = new Sucursal { oBanco = new Banco { id = Convert.ToInt32(dr[5].ToString()), nombre = dr[6].ToString() }, id = int.Parse(dr[7].ToString()), nombre = dr[8].ToString() },
                });
            }
            cn.Obtener().Close();

            return resultado;
        }
    }
}
