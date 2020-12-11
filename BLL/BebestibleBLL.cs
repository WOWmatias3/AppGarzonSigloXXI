using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class BebestibleBLL
	{
        public int id_bebestible { get; set; }
        public string nombre_beb { get; set; }
        public string marca { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        public int stock_bar { get; set; }
        public Byte[] imagen { get; set; }
        public string habilitado { get; set; }
        public string con_prep { get; set; }
        public int orden_id_orden { get; set; }
        public int cantidad_beb { get; set; }
        


        public BebestibleBLL()
        {
        }
        public BebestibleBLL(int id_bebestible, string nombre_beb, string marca, int precio, int stock, int stock_bar, Byte[] imagen,string habilitado, string con_prep, int orden_id_orden, int cantidad_beb)
        {
            this.id_bebestible = id_bebestible;
            this.nombre_beb = nombre_beb;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
            this.stock_bar = stock_bar;
            this.imagen = imagen;
            this.habilitado = habilitado;
            this.con_prep = con_prep;
            this.orden_id_orden = orden_id_orden;
            this.cantidad_beb = cantidad_beb;
            
        }

        public DataTable getbeb_garzon()
        {
            BebestibleDAL beb = new BebestibleDAL();
            DataTable dt = beb.Get_garzon_beb();
            return dt;
        }


        public int Get_bebyid(string nom)
        {
            BebestibleDAL pd = new BebestibleDAL();
            return pd.Get_bebyid(nom);
        }


        public void Alter_bebestible_Despachado(int orden, int beb)
        {
            BebestibleDAL alt = new BebestibleDAL();
            alt.alter_bebestible_Desp(orden, beb);
        }


    }
}
