using APIVue.Models;

namespace APIVue.Interface
{
    public interface IProdutosRepository
    {
        void CreateProduto(Produtos produto);
        void RemoveProduto(Produtos produto);
        void UptadeProduto(Produtos produto);

        Task<Produtos> ReadProduto(int id);
        Task<IEnumerable<Produtos>> ReadAllProdutos();

        Task<bool> SaveAllAsync();
    }
}
