namespace ControleClientes
{
    public class ClienteRepository
    {
        private ApplicationDBContext _dbContext = new ApplicationDBContext();
        
        public List<Cliente> ReadAll()
        { 
            return _dbContext.Clientes.ToList();            
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.Nome.Contains(nome))
                .ToList();
        }

        public void Create(Cliente cliente)
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
        }


        public Cliente GetById(int id) => _dbContext.Clientes.FirstOrDefault(c => c.Id == id);        

        public void Update(Cliente cliente)
        {
            Cliente clienteExistente = GetById(cliente.Id);
            if (clienteExistente != null) 
            { 
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Email = cliente.Email;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            Cliente clienteExistente = GetById(cliente.Id);
            if (clienteExistente != null)
            {
                _dbContext.Remove(clienteExistente);
                _dbContext.SaveChanges();
            }
        }
    }
}
