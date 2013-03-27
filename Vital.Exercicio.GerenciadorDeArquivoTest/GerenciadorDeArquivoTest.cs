using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Vital.Exercicio.GerenciadorDeArquivoTest
{
    [TestFixture]
    public class GerenciadorDeArquivoTest
    {
        private GravarArquivoEmDisco _gravarArquivoEmDisco;

        [TestFixtureSetUp]
        public void carregar_setup()
        {
            _gravarArquivoEmDisco = new GravarArquivoEmDisco();

        }

        [Test]
        public void teste_de_instancia()
        {
            Assert.IsNotNull(_gravarArquivoEmDisco, "instancia do objeto nula");
            Assert.That(_gravarArquivoEmDisco, Is.Not.Null);
        }

        [Test]
        public void teste_CarregarPathEmStream()
        {
            Assert.IsNotNull(_gravarArquivoEmDisco.CarregarArquivo(System.Configuration.ConfigurationSettings.AppSettings["PathArquivoTeste"]));
        }

        [Test]
        public void teste_EscreverStreamEmArquivo()
        {
            MemoryStream memoryStream = _gravarArquivoEmDisco.CarregarArquivo(System.Configuration.ConfigurationSettings.AppSettings["PathArquivoTeste"]);
         
                Assert.That(_gravarArquivoEmDisco.GravarArquivo(memoryStream), " Falha em escrever arquivo ");
      
        }



    }
}
