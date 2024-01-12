using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services.Strategies
{
    public class AbstractObjectValidationStrategy<T> : IObjectValidationStrategy<T>
    {

        protected IAttributeValidationStrategy _attributeValidationStrategy;
        protected bool _result = true;
        protected string _erros = "";
        public string RetornarErros() => _erros += _attributeValidationStrategy.RetornarErros();
        public bool RetornarResultado() => _result && _attributeValidationStrategy.RetornarResultado();

        public AbstractObjectValidationStrategy(IAttributeValidationStrategy attributeValidationStrategy)
        {
            _attributeValidationStrategy = attributeValidationStrategy;
        }

        public virtual bool IsValid(T entity)
        {
            throw new NotImplementedException();
        }
    }
}