using AspnetecorewebApi.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetecorewebApi.Model
{
    /*
     
     RegularExpression: Permite usar expressões regulares em validação
    mais específicas.

    [Required(ErrorMessage = "informe o seu email")]
    [RegularExpression(@".+\\@.+\\..+", ErrorMessage = "Infomre um email válido...")]


     StringLength: Determina om comprimeento máximo e mínimo permitidos 
    [Required]
    [StringLength(10,MinimumLenght=4)]
    public string Passoword { get; set; }

    O parâmetro MInimumLenght define o comprimento mínima de caracteres permitida 
    [MaxLength(100)] - Determina o tamanho máximo do campo na tabels (EF Core) 
     
     
     
     
     
     
     */
    [Table("Categorias")]
    public class Categoria
    {


        [Key]
   public   int  CategoriaId { get; set; }
        [StringLength(50)]
        //validando se a letra é maiuscula ou não 
        [PrimeiraLetraMaiuscula]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(80)]
        public string? IMagemUrl { get; set; } 

        //IColletiom é uma interface que representa uma coleção de produtos 
        public ICollection<Produto> Produtos { get; set; }
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }


        //<summary>
        /// <summary>
        /// Validar se a primeira letra é maiuscula 
        /// </summary>
        /// <param name="validationContext">
        /// conteúdo do contexto de valdiação 
        /// </param>
        /// <returns></returns>

        public IEnumerable<ValidationResult> validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.Nombre))
            {
                var primeiraLetra = this.Nombre[0].ToString();
                if(primeiraLetra != primeiraLetra.ToUpper())
                {
                    yield return new ValidationResult
                        ("A primeira letra letra do produto deve ser maiúscula",
                        new[] { nameof(this.Nombre) });
                }



            }
        }
    }

     


}
