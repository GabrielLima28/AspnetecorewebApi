using System.ComponentModel.DataAnnotations;

namespace AspnetecorewebApi.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute 
    {

        /// <summary>
        /// classe de validação personalizada para validar se as primeira letra do nome do produto é maiúsculas 
        /// 
        /// </summary>
        /// <param name="value"> valor da propriedade onde 
        /// o valor do atribúto está sendo aplicado</param>
        /// <param name="validationContext">
        /// Trás a informações do contexto de aonde estão sendo executado as informações 
        /// </param>
        /// <returns></returns>

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             if ( value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success; 
            }

            var primeeiraLetra = value.ToString()[0].ToString();
            if (primeeiraLetra != primeeiraLetra.ToUpper())
            {
                 

                return new ValidationResult ("A primeria letra do nome do produto deve ser maiúscula");


            }

            return  ValidationResult.Success; 

        }







    }
}
