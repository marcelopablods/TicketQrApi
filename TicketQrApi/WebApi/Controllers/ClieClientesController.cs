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
    public class ClieClientesController : ApiController
    {
        public class ClienteController : ApiController
        {
            // GET api/ClieCliente/obtenerCliente
            [HttpGet]
            public IEnumerable<ClieCliente> obtenerCliente(int id)
            {
                IList<ClieCliente> listaTabla = new List<ClieCliente>();
                string tabla = "ClieCliente";
                DataSet ds = Conexion.ejecutar_select("sp_generico_sel '" + tabla + "','" + id + "'");

                ClieCliente cliente = new ClieCliente();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        cliente.idClieCliente = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        cliente.idClieEstado = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                        cliente.idClieTipoCliente = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
                        cliente.idClieHolding = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
                        cliente.idMaeEmpresa = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());

                        cliente.idMaeSucursal = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
                        cliente.idMaeDireccion = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
                        cliente.idMaeDireccionDespacho = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
                        cliente.esNacional = Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
                        cliente.rut = ds.Tables[0].Rows[0][9].ToString();

                        cliente.nombre = ds.Tables[0].Rows[0][10].ToString();
                        cliente.apellido = ds.Tables[0].Rows[0][11].ToString();
                        cliente.razonSocial = ds.Tables[0].Rows[0][12].ToString();
                        cliente.telefono = ds.Tables[0].Rows[0][13].ToString();
                        cliente.email = ds.Tables[0].Rows[0][14].ToString();

                        cliente.nombreContacto = ds.Tables[0].Rows[0][15].ToString();
                        cliente.cargoContacto = ds.Tables[0].Rows[0][16].ToString();
                        cliente.web = ds.Tables[0].Rows[0][17].ToString();
                        cliente.esEmpresa = Convert.ToBoolean(ds.Tables[0].Rows[0][18].ToString());
                        cliente.giroActividad = ds.Tables[0].Rows[0][19].ToString();

                        cliente.usuarioExtranet = ds.Tables[0].Rows[0][20].ToString();
                        cliente.passwordExtranet = ds.Tables[0].Rows[0][21].ToString();
                        cliente.codigoProvedor = Convert.ToInt32(ds.Tables[0].Rows[0][22].ToString());
                        cliente.codigoOld = ds.Tables[0].Rows[0][23].ToString();
                        cliente.emailFacturacion = ds.Tables[0].Rows[0][24].ToString();

                        cliente.plazoPagoDias = Convert.ToInt16(ds.Tables[0].Rows[0][25].ToString());
                        cliente.esFacturacionAutomatica = Convert.ToBoolean(ds.Tables[0].Rows[0][26].ToString());
                        cliente.esComprobarDeuda = Convert.ToBoolean(ds.Tables[0].Rows[0][27].ToString());
                        cliente.montoDeudaLimite = ds.Tables[0].Rows[0][28].ToString();
                        cliente.esExentoFee = Convert.ToBoolean(ds.Tables[0].Rows[0][29].ToString());

                        cliente.esFacturaDolares = Convert.ToBoolean(ds.Tables[0].Rows[0][30].ToString());
                        cliente.esPagoAnticipado = Convert.ToBoolean(ds.Tables[0].Rows[0][31].ToString());
                        cliente.codigoSernatur = ds.Tables[0].Rows[0][32].ToString();
                        cliente.esCorporativo = Convert.ToBoolean(ds.Tables[0].Rows[0][33].ToString());
                        cliente.codigoClienteCorporativo = ds.Tables[0].Rows[0][34].ToString();

                        cliente.validaCentroCosto = Convert.ToBoolean(ds.Tables[0].Rows[0][35].ToString());
                        cliente.validaSubCentroCosto = Convert.ToBoolean(ds.Tables[0].Rows[0][36].ToString());
                        cliente.validaReasonCode = Convert.ToBoolean(ds.Tables[0].Rows[0][37].ToString());
                        cliente.validaOrdenCompra = Convert.ToBoolean(ds.Tables[0].Rows[0][38].ToString());
                        cliente.estado = Convert.ToBoolean(ds.Tables[0].Rows[0][39].ToString());

                        cliente.idClieDiasPlazo = Convert.ToInt32(ds.Tables[0].Rows[0][40].ToString());
                        cliente.idMaeDepartamento = Convert.ToInt32(ds.Tables[0].Rows[0][41].ToString());
                        cliente.esPersona = Convert.ToBoolean(ds.Tables[0].Rows[0][42].ToString());
                        cliente.esActivoVenta = Convert.ToBoolean(ds.Tables[0].Rows[0][43].ToString());
                        cliente.idVendVendedora = Convert.ToInt32(ds.Tables[0].Rows[0][44].ToString());

                        listaTabla.Add(cliente);
                    }
                }
                else
                {
                    //else
                }
                return listaTabla;
            }

            [HttpGet]
            public IEnumerable<ClieCliente> getLista(string tabla, string nombreCampo, string nombreValor, string campoRetorno, string idUsuario)
            {
                IList<ClieCliente> listaClientes = new List<ClieCliente>();
                DataSet ds = Conexion.ejecutar_select("sp_generico_lst2 '" + tabla + "','" + nombreCampo + "','" + nombreValor + "','" + campoRetorno + "'");

                ClieCliente cli = new ClieCliente();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        cli = new ClieCliente();
                        cli.idClieCliente = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                        cli.rut = ds.Tables[0].Rows[i][2].ToString();
                        cli.nombre = ds.Tables[0].Rows[i][3].ToString();
                        cli.apellido = ds.Tables[0].Rows[i][4].ToString();
                        cli.razonSocial = ds.Tables[0].Rows[i][5].ToString();
                        listaClientes.Add(cli);

                    }
                }
                else
                {

                }
                return listaClientes;
            }
        }
    }
}
