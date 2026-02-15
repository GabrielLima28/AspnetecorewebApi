using AspnetecorewebApi.Model;

namespace AspnetecorewebApi.Services
{
    public interface IMeuServico
    {

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nome">Iimplementação do serviços nome</param>
       /// <returns></returns>
        string Saudacao(string nome);
        int bucaid(int id); 

        List<Produto>  produtos( Produto produto);
    }
}
