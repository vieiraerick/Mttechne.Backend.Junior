
using Microsoft.AspNetCore.Mvc;
using Moq;
using Mttechne.Backend.Junior.Interface.Controllers;
using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Controllers
{
    public class ProdutoControllerTeste
    {
        [Fact]
        public async Task RetornarErroCasoNaoPasseAString()
        {
            var mock = new Mock<IProdutoService>();
            var produtoService = new ProdutoController(mock.Object);

            var result = (UnprocessableEntityResult)await produtoService.GetListaProdutosProNome("");
            Assert.Equal(422, result.StatusCode);
        }
    }
}
