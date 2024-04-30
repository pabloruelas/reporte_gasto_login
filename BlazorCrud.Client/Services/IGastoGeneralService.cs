using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface IGastoGeneralService
    {
        Task<List<GastoGeneralDTO>> Lista();
        Task<GastoGeneralDTO> Buscar(int id);
        Task<int> Guardar(GastoGeneralDTO gastoGeneral);
        Task<int> Editar(GastoGeneralDTO gastoGeneral);
        Task<bool> Eliminar(int id);



    }
}
