using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Vital.Exercicio.GerenciadorDeArquivo;


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
        public void carregar_arquivo_com_sucesso_com_mock_automatico()
        {
            string caminhoDoArquivo = @"C:\qualquerArquivo.txt";

            FileStream fileStream = MockRepository.GenerateMock<FileStream>();
            fileStream.Expect(x => x.Length).Return(2);
            fileStream.Expect(x => x.Read(new byte[2], 0, 2)).Return(1);

            var fileWrapper = MockRepository.GenerateMock<FileWrapper>();
            fileWrapper.Expect(x => x.OpenRead(caminhoDoArquivo)).Return(fileStream);

            _gravarArquivoEmDisco.FileWrapper = fileWrapper;

            Assert.AreEqual(_gravarArquivoEmDisco.CarregarArquivo(caminhoDoArquivo).Length, 2);
        }

        [Test]
        public void carregar_arquivo_com_vazio_retorna_excecao()
        {
            string caminhoDoArquivo = @"C:\qualquerArquivo.txt";

            FileStream fileStream = MockRepository.GenerateMock<FileStream>();
            fileStream.Expect(x => x.Length).Return(0);
            fileStream.Expect(x => x.Read(new byte[2], 0, 2)).Return(1);

            var fileWrapper = MockRepository.GenerateMock<FileWrapper>();
            fileWrapper.Expect(x => x.OpenRead(caminhoDoArquivo)).Return(fileStream);

            _gravarArquivoEmDisco.FileWrapper = fileWrapper;

            Assert.That(() => _gravarArquivoEmDisco.CarregarArquivo(caminhoDoArquivo),
                        Throws.Exception.TypeOf<Exception>()
                              .With.Property("Message").EqualTo("O Arquivo Retornado Esta Vazio (0 bytes)"));
        }


        [Test]
        public void carregar_arquivo_com_sucesso_com_mock_manual()
        {
            string caminhoDoArquivo = @"C:\qualquerArquivo.txt";

            FileStream fileStream = MockRepository.GenerateMock<FileStream>();
            fileStream.Expect(x => x.Length).Return(2);
            fileStream.Expect(x => x.Read(new byte[2], 0, 2)).Return(1);

            var fileWrapper = new FileWrapperMock();
            fileWrapper.FileStream = fileStream;

            _gravarArquivoEmDisco.FileWrapper = fileWrapper;
            
            Assert.AreEqual(_gravarArquivoEmDisco.CarregarArquivo(caminhoDoArquivo).Length, 2);
        }

        [Test]
        public void gravar_arquivo_vazio_retorna_excecao()
        {
            MemoryStream memoryStream = MockRepository.GenerateMock<MemoryStream>();
            memoryStream.Expect( x=> x.Length).Return(0);
            
            Assert.That(() => _gravarArquivoEmDisco.GravarArquivo(memoryStream),
                       Throws.Exception.TypeOf<Exception>()
                             .With.Property("Message").EqualTo("O Arquivo Retornado Esta Vazio (0 bytes)"));
        }

        [Test]
        public void teste_de_instancia()
        {
            Assert.IsNotNull(_gravarArquivoEmDisco, "instancia do objeto nula");
            Assert.That(_gravarArquivoEmDisco, Is.Not.Null);
        }

        [Test]
        public void teste_CarregarPathEmStream_retorna_exception()
        {
            Assert.That(() => _gravarArquivoEmDisco.CarregarArquivo(""),
                        Throws.Exception.TypeOf<Exception>().With.Property("Message").EqualTo("O Path informado para leitura do Arquivo Esta Vazio"));
        }
        [Test]
        public void teste_GravarArquivo()
        {
            MemoryStream memoryStream = _gravarArquivoEmDisco.CarregarArquivo(System.Configuration.ConfigurationSettings.AppSettings["PathArquivoTeste"]);

            _gravarArquivoEmDisco.GravarArquivo(memoryStream);

            Assert.IsNotNull(memoryStream, "Falha em escrever arquivo");

        }



    }
}
