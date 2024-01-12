using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services.Strategies
{
    public sealed class ProductValidationStrategy : AbstractObjectValidationStrategy<Produto>
    {
        public ProductValidationStrategy(IAttributeValidationStrategy attributeValidationStrategy) : base(attributeValidationStrategy)
        {
         
        }

        //Pra fazer eventuais validações de classe.
        public override bool IsValid(Produto produto)
        {
            _attributeValidationStrategy.IsNameValid(produto.Nome);
            _attributeValidationStrategy.IsMoneyValid(produto.Valor);

            //colocar eventuais validações de produto..            
            
            return RetornarResultado();
        }

        public bool IsMaximoMinimoValid(decimal minimo, decimal maximo)
        {
            _attributeValidationStrategy.IsMoneyValid(minimo,"Minimo");
            _attributeValidationStrategy.IsMoneyValid(maximo,"Máximo");

            if(_attributeValidationStrategy.RetornarResultado() && minimo > maximo)
            {
                _erros = "Minimo: Valor minimo é maior que valor máximo\n";
                _result = false;
            }

            return RetornarResultado();
        }
    }
}