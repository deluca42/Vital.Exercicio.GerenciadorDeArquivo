using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.InfraStructure.DSL.DesignByContract;


namespace Vital.Exercicio.GerenciadorDeArquivo
{
    /// <summary>
    ///  gerenciador de arquivo 
    /// </summary>
    public class GravarArquivoEmDisco
    {
        private FileWrapper _fileWrapper;

        /// <summary>
        /// Wrapper de file do .net framework
        /// </summary>
        public FileWrapper FileWrapper
        {
            get
            {
                if(_fileWrapper == null)
                    _fileWrapper = new FileWrapper();
                return _fileWrapper;
            }
            set { _fileWrapper = value; }
        }

        /// <summary>
        /// Carrega um arquivo em memoria de acordo com o path informado
        /// </summary>
        /// <param name="caminho">caminho do arquivo</param>
        /// <returns>memorystream</returns>
        public virtual MemoryStream CarregarArquivo(string caminho)
        {
            #region Pré-Condições

            IAssertion caminhoDoArquivoFoiEncontrado = Assertion.IsFalse(string.IsNullOrWhiteSpace(caminho), "O caminho do arquivo vazio");

            #endregion

            caminhoDoArquivoFoiEncontrado.Validate();

            MemoryStream memoryStream = null;
            using (var fileStream = FileWrapper.OpenRead(caminho))
            {
                memoryStream = new MemoryStream();
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
            }

            #region Pós-Condições

            IAssertion arquivoFoiCarregado = Assertion.GreaterThan(memoryStream.Length, default(long), "O Arquivo Retornado Esta Vazio (0 bytes)");

            #endregion

            arquivoFoiCarregado.Validate();

            return memoryStream;
        }

        /// <summary>
        /// Escreve o conteudo da memoria num arquivo em um local
        /// </summary>
        /// <param name="memoryStream">conteudo binario</param>
        public void GravarArquivo(MemoryStream memoryStream)
        {
            #region Pré-Condições

            IAssertion oArquivoRecebido = Assertion.GreaterThan(memoryStream.Length, default(long), "O Arquivo Recebido Esta Vazio (0 bytes)");
            IAssertion pathArquivosSalvos =  Assertion.IsFalse(string.IsNullOrWhiteSpace(System.Configuration.ConfigurationSettings.AppSettings["PathArquivoTeste"]), "O Path informado para leitura do Arquivo Esta Vazio");

            #endregion

            oArquivoRecebido.and(pathArquivosSalvos).Validate();

            using (FileStream file = new FileStream("file.jpg", FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(file);
            }

            #region Pós-Condições
            
           

            #endregion
        }

    }
}
