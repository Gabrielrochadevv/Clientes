using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IClienteService
    {
        IEnumerable<ClienteModel> GetAll();
        ClienteModel GetById(int id);
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(int id);
    }
}
