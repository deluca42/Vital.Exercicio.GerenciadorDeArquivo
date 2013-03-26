using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Vital.Exercicio.GerenciadorDeArquivo;

namespace Vital.Exercicio.GerenciadorDeArquivoTest
{
    [TestFixture]
    public class GerenciadorDeArquivoTest
    {
        [Test]
        public void teste_de_instancia()
        {
            GerenciadorDeArquivoMain meuGerenciador = new GerenciadorDeArquivoMain();

            Assert.IsNotNull(meuGerenciador, "instacia Nula");

        }
    }
}
