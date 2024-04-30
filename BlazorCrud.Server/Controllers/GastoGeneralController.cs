using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;


namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoGeneralController : ControllerBase
    {

        private readonly DbreporteGastosContext _dbContext;

        public GastoGeneralController(DbreporteGastosContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<GastoGeneralDTO>>();
            var listaGastoGeneralDTO = new List<GastoGeneralDTO>();

            try
            {
                foreach (var item in await _dbContext.GastoGenerals.Include(d => d.IdTipoGastoNavigation).ToListAsync())
                {
                    listaGastoGeneralDTO.Add(new GastoGeneralDTO
                    {
                        IdGasto = item.IdGasto,
                        ConceptoGasto = item.ConceptoGasto,
                        IdTipoGasto = item.IdTipoGasto,
                        Monto = item.Monto,
                        FechaGasto = item.FechaGasto,
                        TipoGasto = new TipoGastoDTO
                        { 
                            IdTipoGasto = item.IdTipoGastoNavigation.IdTipoGasto,
                            Tipo = item.IdTipoGastoNavigation.Tipo
                        }

                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaGastoGeneralDTO;
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }


        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<GastoGeneralDTO>();
            var GastoGeneralDTO = new GastoGeneralDTO();

            try
            {
                var dbGastoGeneral = await _dbContext.GastoGenerals.FirstOrDefaultAsync(x => x.IdGasto == id);

                if (dbGastoGeneral != null)
                {
                    GastoGeneralDTO.IdGasto = dbGastoGeneral.IdGasto;
                    GastoGeneralDTO.ConceptoGasto = dbGastoGeneral.ConceptoGasto;
                    GastoGeneralDTO.IdTipoGasto = dbGastoGeneral.IdTipoGasto;
                    GastoGeneralDTO.Monto = dbGastoGeneral.Monto;
                    GastoGeneralDTO.FechaGasto = dbGastoGeneral.FechaGasto;



                    responseApi.EsCorrecto = true;
                    responseApi.Valor = GastoGeneralDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }



            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(GastoGeneralDTO gastogeneral)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbGastoGeneral = new GastoGeneral
                {
                    ConceptoGasto = gastogeneral.ConceptoGasto,
                    IdTipoGasto = gastogeneral.IdTipoGasto,
                    Monto = gastogeneral.Monto,
                    FechaGasto = gastogeneral.FechaGasto,
                };

                _dbContext.GastoGenerals.Add(dbGastoGeneral);
                await _dbContext.SaveChangesAsync();

                if(dbGastoGeneral.IdGasto !=0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbGastoGeneral.IdGasto;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(GastoGeneralDTO gastogeneral, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {



                var dbGastoGeneral = await _dbContext.GastoGenerals.FirstOrDefaultAsync(e => e.IdGasto == id);

                if (dbGastoGeneral != null)
                {

                    dbGastoGeneral.ConceptoGasto = gastogeneral.ConceptoGasto;
                    dbGastoGeneral.IdTipoGasto = gastogeneral.IdTipoGasto;
                    dbGastoGeneral.Monto = gastogeneral.Monto;
                    dbGastoGeneral.FechaGasto = gastogeneral.FechaGasto;

                    _dbContext.GastoGenerals.Update(dbGastoGeneral);
                    await _dbContext.SaveChangesAsync();


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbGastoGeneral.IdGasto;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Gasto no encontrado";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {



                var dbGastoGeneral = await _dbContext.GastoGenerals.FirstOrDefaultAsync(e => e.IdGasto == id);

                if (dbGastoGeneral != null)
                {
                    _dbContext.GastoGenerals.Remove(dbGastoGeneral);
                    await _dbContext.SaveChangesAsync();


                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Gasto no encontrado";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }


    }
}
