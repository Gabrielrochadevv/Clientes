using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        } 
        
        public IEnumerable<ClienteModel> GetAll() => _repository.GetAll();  
        
        public ClienteModel GetById(int id) => _repository.GetById(id);

        public void Add(ClienteModel cliente) => _repository.Add(cliente);
        
        public void Update(ClienteModel cliente) => _repository.Update(cliente);

        public void Delete(int id)
        { 
        var cliente = _repository.GetById(id);
            if(cliente == null)
            {
                _repository.Delete(cliente);
            }
        }

    }
}
