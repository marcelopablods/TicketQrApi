using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    
    public class TicketController : ApiController
    {
        // GET api/Ticket
        [HttpGet]
        public IEnumerable<Response> validarTicket(string idVentaRegularPasajero, string idUsuario)
        {
            IList<Response> listaVTN = new List<Response>();
            DataSet ds = Conexion.ejecutar_select("sp_validaPasajero_situr " + idVentaRegularPasajero + ", " + idUsuario + "");

            Response resp = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    resp = new Response();
                    resp.id = 1;
                    resp.mensaje = ds.Tables[0].Rows[i][0].ToString();
                    listaVTN.Add(resp);
                }
            }
            else
            {
                resp = new Response();
                resp.id = 0;
                resp.mensaje = "Problemas con el web service";
                listaVTN.Add(resp);

            }
            return listaVTN;
        }
        [HttpPost]
        public void abordarPasajero(string idVentaRegularPasajero, string idUsuario)
        {
            bool respuesta = Conexion.ejecutar_comando("sp_abordaPasajero_situr " + idVentaRegularPasajero + "," +  idUsuario + "'");
            if (respuesta)
            {
                Console.WriteLine("Modificado Correctamente");
            }
            else
            {
                Console.WriteLine("Error al modificar" + respuesta);
            }
        }
        
    }
}
