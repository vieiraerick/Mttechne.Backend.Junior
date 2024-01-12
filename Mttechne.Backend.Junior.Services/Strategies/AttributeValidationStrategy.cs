using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services.Strategies
{
    public class AttributeValidationStrategy : IAttributeValidationStrategy
    {

        private string _erros = "";
        private bool _result = true;

        public string AddErro(string erro) => _erros += erro;
        public string RetornarErros() => _erros;
        public bool RetornarResultado() => _result;

        public bool IsMoneyValid(decimal money, string field = "")
        {
            if(money < 0)
            {
                _erros += $"{(string.IsNullOrEmpty(field) ? "" : field+":")} Valor informado não pode ser menor que zero.\n";
                _result = false;
            }
            
            return _result;
        }

        public bool IsNameValid(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                _erros += "Não foi informado o nome.\n";
                _result = false;
            }
            else if(name.Length <= 2)
            {
                _erros += "Nome informado é muito curto.\n";
                _result = false;
            }
                

            //Colocar eventuais validações de nome;

            return _result;
        }

        
        
    }
}