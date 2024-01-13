namespace Mttechne.Backend.Junior.Services.Strategies.interfaces
{
    public interface IObjectValidationStrategy<T>
    {
        //Caso for usar uma entidade pra validar..
        bool IsValid(T entity);
        bool RetornarResultado();
        string RetornarErros();
    }
}