using AspnetecorewebApi.Model;

namespace AspnetecorewebApi.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> getCategorias();
        IEnumerable<Categoria> getCategoriasProdutos();

        Categoria getCategoriaId(int id);
        Categoria created(Categoria categoria);
        
        Categoria updateCategoria(Categoria categoria);
        Categoria deleteCategoria(int id);
    }
}
