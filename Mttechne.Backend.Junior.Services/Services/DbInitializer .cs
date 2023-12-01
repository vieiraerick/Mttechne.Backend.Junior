using Mttechne.Backend.Junior.Services.Data.Context;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MttechneDbContext _dbContext;

        public DbInitializer(MttechneDbContext context)
        {
            _dbContext = context;
        }

        public void Initialize()
        {
            // Verifica se já existem produtos no banco de dados
            if (!_dbContext.Produto.Any())
            {
                _dbContext.Produto.Add(new Produto() { Nome = "Placa de Vídeo", Valor = 1000 });
                _dbContext.Produto.Add(new Produto() { Nome = "Placa de Vídeo", Valor = 1500 });
                _dbContext.Produto.Add(new Produto() { Nome = "Placa de Vídeo", Valor = 1350 });
                _dbContext.Produto.Add(new Produto() { Nome = "Processador", Valor = 2000 });
                _dbContext.Produto.Add(new Produto() { Nome = "Processador", Valor = 2100 });
                _dbContext.Produto.Add(new Produto() { Nome = "Memória", Valor = 300 });
                _dbContext.Produto.Add(new Produto() { Nome = "Memória", Valor = 350 });
                _dbContext.Produto.Add(new Produto() { Nome = "Placa mãe", Valor = 1100 });
                _dbContext.SaveChanges();
            }
        }
    }
}
