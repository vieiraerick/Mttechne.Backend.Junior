using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Strategies.interfaces
{
    public interface IAttributeValidationStrategy
    {
        
        bool IsMoneyValid(decimal money,string field="");

        bool IsNameValid(string name);
        bool RetornarResultado();
        string RetornarErros();

        string AddErro(string erros);

    }
}