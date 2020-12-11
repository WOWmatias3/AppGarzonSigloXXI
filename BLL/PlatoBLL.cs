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
    public class PlatoBLL
    {

        public int Id_plato { get; set; }
        public String Nombre_plato { get; set; }
        public int Precio { get; set; }
        public String Categoria { get; set; }
        public Byte[] Imagen { get; set; }
        public String Habilitado { get; set; }

        public static PlatoBLL instance = null;

        public PlatoBLL()
        {

        }

        public PlatoBLL(int id_plato,
        String nombre_plato,
        int precio,
        String categoria,
        Byte[] imagen,
        String habilitado)

        {
            this.Id_plato = id_plato;
            this.Nombre_plato = nombre_plato;
            this.Precio = precio;
            this.Categoria = categoria;
            this.Imagen = imagen;
            this.Habilitado = habilitado;
        }

        public DataTable Getplato_garzon()
        {
            PlatoDAL beb = new PlatoDAL();
            DataTable dt = beb.Get_garzon_plato();
            return dt;
        }


        public int Platoidbynb(string nomb)
        {
            PlatoDAL pld = new PlatoDAL();
            return pld.Get_idplatobyname(nomb);
        }
        public void Alter_Plato_Despachado(int orden, int beb)
        {
            PlatoDAL alt = new PlatoDAL();
            alt.alter_Plato_Desp(orden, beb);
        }


    }
}
