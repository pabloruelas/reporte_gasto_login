using BlazorCrud.Shared;


namespace BlazorCrud.Client.Services
{
    public interface ITipoGastoService
    {
        Task<List<TipoGastoDTO>> Lista();
    }
}
