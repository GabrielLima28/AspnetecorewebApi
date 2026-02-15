using AspnetecorewebApi.Cotexto;
using AspnetecorewebApi.Model;
using AspnetecorewebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AspnetecorewebApi.Controllers
{
    /// <summary>
    /// classe que vai gerenciar as categorias do sistemas 
    /// </summary>
    /// 
    ///<summary> Routing </summary>
    ///<summary>ele é responsavel por mapear ass requisições via URI</summary>
    ///Depacha as requisições para os endpoints 
    ///pode extrair valores da URL da requisição
    ///Pode gerar URLs que mspeiam para os endpoints 
    /// A rota é determinada com base nos atributos definidos nos Controladores e métodos 
    /// Action 
    /// As definições nos atributos irão realizar o mapeamento para as Actions do controlador 
    /// Podemos definir rotas nos atributos HttpGet, HttpPost 
    /// HttpPut e HttpDelete que irião compor a rota defínida no atributo Route 
    [Route("api/[controller]")]
     
    
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _contextCategoria;
        private readonly IConfiguration configuration;
        private readonly ILogger loggerDescripitiom;

        public CategoriaController (AppDbContext _contextCategoria, IConfiguration configuration)
        {
            _contextCategoria = _contextCategoria;

            configuration = configuration; 
        }


        [HttpGet("ListadeConfigurations")]
       public string Getconfiguratios()
        {
            var minhaConfiguracaochave1 = configuration["chave1"];
                        var minhaConfiguracaochave2 = configuration["chave2"];
            var secao = configuration["secao1:chave1"];
            return $"chyaves: {minhaConfiguracaochave1}: {minhaConfiguracaochave2} : {secao} ";
        }

        [HttpGet("lista-de-categorias")]
        
        public ActionResult<IEnumerable<Categoria>> getListaProduto()
        {
            //loguer que retona a mensagem da lista de usuário 
            loggerDescripitiom.LogInformation("######## Inicializando o retorno da Lista de Usuário #################");
                
            return _contextCategoria.Categoria.Include(p => p.Produtos).ToList();
        }

       // [HttpGet("primeiro")]
        [HttpGet("teste")]
       public ActionResult<IEnumerable<Categoria>> get ()
        {
            try
            {
                throw new DataMisalignedException();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ai tratar a sua solicitação"); 
            }
          
        }

        [HttpGet("UsandoFromServices/{nome}")]


        ///<summary>
        ///
        /// Sobrescreve o a fonte de associação injetando os valores via injeção 
        /// de dependência em um método Action específico.
        /// injetar as dependências direAction do Controlador que requer a dependência 
        /// tamente no método 
        /// Permite 
        /// 
        /// 
        /// </summary>
        public ActionResult<string> GetSaudacaoFromServices([FromServices] IMeuServico meuServico, string nome) { 
            return meuServico.Saudacao(nome); 
        }

        //segundo forma de obter a propriedade do serviço usando o recurso de injeção de dependência do asp
        [HttpGet("uSUANDOFromServicess/{id:int}")]
        public ActionResult<int> GetIdFromServices( IMeuServico meuServico, int id)
        {
            return meuServico.bucaid(id);
        }

        [HttpGet("{id:int}/{param2}", Name ="ObrigatoriedadeCategoria")]
        public ActionResult<Categoria> get (int id, string param2  )
        {
            try
            {
                var parametro = param2;

                var categoria = _contextCategoria.Categoria.FirstOrDefault(c => c.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada");
                }
                return Ok(categoria);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ai tratar a sua solicitação");

            }



        }

        [HttpPost("MetodoPost") ]
        public ActionResult Post (Categoria categoria)
        {
            if (categoria is null)
            
                return BadRequest();
            _contextCategoria.Add(categoria);
            _contextCategoria.SaveChanges();
            return Ok(categoria);

            return new CreatedAtRouteResult("ObrigatoriedadeCategoria",
                new { id = categoria.CategoriaId }, categoria);



        }
        [HttpPut("{id:int}", Name ="Indentificacao")] 
        public ActionResult Put (int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest(); 
            }
            _contextCategoria.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contextCategoria.SaveChanges();
            return Ok(categoria); 

        }
        //Ele vai definir um valor minimo para o caminho da áplicação
        //[HttpGet("{valor:alpha:length(5)
        //}")] são valores alpha numéricos 


        
        /// </summary>
        /// <param name="id">ObterProduto</param>
        /// O 404 foi devolvido pelo mecanismo de 
        /// roteamenot da ASP .NET Core 
        /// </summary>

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Categoria> Delete (int id)
        {
            var categoria = _contextCategoria.Categoria.FirstOrDefault(c => c.CategoriaId == id); 
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada ");

            }
            _contextCategoria.Remove(categoria);
            _contextCategoria.SaveChanges();
            return Ok(categoria); 
        }
    }
}
