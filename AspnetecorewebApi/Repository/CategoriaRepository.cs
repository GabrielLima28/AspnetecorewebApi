using AspnetecorewebApi.Cotexto;
using AspnetecorewebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AspnetecorewebApi.Repository
{
    public class CategoriaRepository : ICategoriaRepository


    {
        private AppDbContext contextecategoria;
        public CategoriaRepository(AppDbContext contextecategoria)
        {

            this.contextecategoria = contextecategoria;
        }
        public IEnumerable<Categoria> getCategorias()
        {

            return contextecategoria.Categoria.ToList();
        }
        public IEnumerable<Categoria> getCategoriasProdutos()
        {

            return contextecategoria.Categoria.Include(p => p.Produtos).ToList();
        }

        public Categoria getCategoriaId(int id)
        {
            return contextecategoria.Categoria.FirstOrDefault(x => x.CategoriaId == id);


        }
        public Categoria created(Categoria categoria)
        {
            if (categoria is null)

                throw new ArgumentNullException(nameof(categoria));
            contextecategoria.Categoria.Add(categoria);
            contextecategoria.SaveChanges();
            return categoria;

        }
         
        public Categoria updateCategoria(Categoria categoria)
        {
            if (categoria is null)
                throw new ArgumentNullException(nameof(categoria));
            contextecategoria.Categoria.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contextecategoria.SaveChanges();
            return categoria;
        }
        public Categoria  deleteCategoria(int id)
        {
            var valorIdCaateogria = contextecategoria.Categoria.FirstOrDefault(x => x.CategoriaId == id);
            if (valorIdCaateogria == null)
                throw new ArgumentNullException(nameof(valorIdCaateogria));
            contextecategoria.Categoria.Remove(valorIdCaateogria);
            contextecategoria.SaveChanges();
            return valorIdCaateogria;        }
    }
}