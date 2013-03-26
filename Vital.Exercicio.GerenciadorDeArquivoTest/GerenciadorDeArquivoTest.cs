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
        private GerenciadorDeArquivoMain _gerenciadorDeArquivo;
        [Test]
        public void teste_de_instancia()
        {
            var _gerenciadorDeArquivo = new GerenciadorDeArquivoMain();

            Assert.IsNotNull(_gerenciadorDeArquivo, "instancia do objeto nula");
        }
        [Test]
        public void teste_escreverArquivo()
        {
            _gerenciadorDeArquivo = new GerenciadorDeArquivoMain();
            Assert.That(GerenciadorDeArquivoMain.EscreverArquivo());
        }

    }
}
