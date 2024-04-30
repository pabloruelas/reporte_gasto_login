using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class GastoGeneralService : IGastoGeneralService
    {
        private readonly HttpClient _http;

        public GastoGeneralService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<GastoGeneralDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<GastoGeneralDTO>>>("api/GastoGeneral/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<GastoGeneralDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<GastoGeneralDTO>>($"api/GastoGeneral/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Guardar(GastoGeneralDTO gastoGeneral)
        {
            var result = await _http.PostAsJsonAsync("api/GastoGeneral/Guardar", gastoGeneral);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(GastoGeneralDTO gastoGeneral)
        {
            var result = await _http.PutAsJsonAsync($"api/GastoGeneral/Editar/{gastoGeneral.IdGasto}", gastoGeneral);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/GastoGeneral/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }



    }
}
