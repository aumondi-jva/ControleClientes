namespace ControleClientes
{
    public class CidadeRepository
    {
        private ApplicationDBContext _dbContext = new ApplicationDBContext();

        public List<Cidade> ReadAll()
        {
            return _dbContext.Cidades.ToList();
        }

        public void Create(Cidade cliente)
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
        }

        public Cidade GetById(int id) => _dbContext.Cidades.FirstOrDefault(c => c.Id == id);
        public Cidade GetByName(string nome) => _dbContext.Cidades.FirstOrDefault(c => c.Nome == nome);

        public void Update(Cidade cliente)
        {
            Cidade clienteExistente = GetById(cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Uf = cliente.Uf;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Cidade cliente)
        {
            Cidade clienteExistente = GetById(cliente.Id);
            if (clienteExistente != null)
            {
                _dbContext.Remove(clienteExistente);
                _dbContext.SaveChanges();
            }
        }
    }
}
