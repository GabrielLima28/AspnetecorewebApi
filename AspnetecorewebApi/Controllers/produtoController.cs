using AspnetecorewebApi.Cotexto;
using AspnetecorewebApi.filter;
using AspnetecorewebApi.Model;
using AspnetecorewebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AspnetecorewebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary> Executando o fiter em nivel de classe</summary>
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public class produtoController : ControllerBase
    {
        private readonly AppDbContext _context;
        /// <param name="context"> as instancias 
        /// dos container são utilizadas para rastrear os parâmetros
        /// </param>
        public produtoController(AppDbContext context)
        {
            
            _context = context; 
        }
        [HttpGet("ListaspordutosviaSerivices")]
        ///
        ///<summary>
        ///          /// e a injeção de dependência do para bucar a lista de produtos do banco de dado 
        /// 
        /// </summary>
         public ActionResult<IEnumerable<Produto>> Get([FromServices]IMeuServico meuservico, Produto produto)
        {
            return meuservico.produtos(produto);
        }

        [HttpGet]

        //utilizando método assíncrono para buscar a lista de produtos
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            /*    var produtos = _context.Produto.ToList();
                if (produtos is null)
                {
                    return NotFound(); 

                return produtos; 
            }*/

            return await _context.Produto.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> identificador do produto
        /// <returns></returns>

        [HttpGet("{id:int}", Name= "ObterProduto")]
        //Assim, uma consulta desnecessária ao banco de
        // daods foi evitada
        //BindRequired: Este atributo
        //adiciona umm erro ao
        //ModeloState se a vinculação de dados
        //aos parâmetros não puder ocorrer 
        public ActionResult<Produto> Get ([FromQuery]int id)
        {
            // var nomeproduto = nome;
            // api/produto/1 
            ///<summary>
            ///
            /// Quando utiliza o FromQuer: ao passar  o parâmetro na URl 
            /// tipo quando eu passo o api/produto/1?id=2 
            /// ele vai buscar pelo id 2 que foi passado na quey string 
            /// </summary>
            var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null )
            {
                return NotFound("Produto não encontrado..."); 
            }
            return produto; 
        }

        [HttpPost]
        //aplicação do filtro 
        //essa seria a aplicação do filtro personalizado

        [ServiceFilter(typeof(ApiLoggingFilter))]

        ///<summary>Serviço que vai salvar os valores na tabéla do banco deo dados 
       public ActionResult Post(Produto produto)
        {

            if (produto is null)

                return BadRequest(); 
            _context.Produto.Add(produto);
            _context.SaveChanges();

            ///<sumary> Ele vai criar uma resposta http 201.
            ///
            ///<sumary> Ele cria uma rota de obter produto
            ///

            return new  CreatedAtRouteResult("ObterProduto", new
       { 
                id = produto.ProdutoId  }, produto);
        }
        ///<summary>  
        /// O erro 204 NoContent : erro de encontrar o caminho criado co


        [HttpPut("{id:int}")]
        /// <summary> a Entidadade do produto está 
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                //pagina não encontrado 
                return BadRequest(); 
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto); 
            
        }

        [HttpDelete("{id:int}", Name = "Metodo-Delete" )]
        public ActionResult Delete (int id)
        {
         
            var produto = _context.Produto.Find(id); 
            if (produto is null)
            {
                return NotFound("Produto não encontrado ...");

            }

            
            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return Ok(produto); 
        }
        
    }
}
