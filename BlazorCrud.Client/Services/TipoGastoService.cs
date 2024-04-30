
using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class TipoGastoService : ITipoGastoService
    {

        private readonly HttpClient _http;

        public TipoGastoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TipoGastoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TipoGastoDTO>>>("api/TipoGasto/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        
        }
    }
}
