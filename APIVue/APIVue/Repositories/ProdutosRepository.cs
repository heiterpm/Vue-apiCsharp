using APIVue.Interface;
using APIVue.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVue.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ProdutosDBContext _context;

        public ProdutosRepository(ProdutosDBContext context)
        {
            _context = context;
        }

        public void CreateProduto(Produtos produto)
        {
            _context.TbProdutos.Add(produto);
        }

        public void UptadeProduto(Produtos produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Produtos>> ReadAllProdutos()
        {
            return await _context.TbProdutos.Take(10).ToListAsync();
        }

        public async Task<Produtos> ReadProduto(int id)
        {
            return await _context.TbProdutos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void RemoveProduto(Produtos produto)
        {
            _context.TbProdutos.Remove(produto);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
