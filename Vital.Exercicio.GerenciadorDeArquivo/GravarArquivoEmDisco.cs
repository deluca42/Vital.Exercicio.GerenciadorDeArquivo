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
        /// <summary>
        /// Carrega um arquivo em memoria de acordo com o path informado
        /// </summary>
        /// <param name="path">caminho do arquivo</param>
        /// <returns>memorystream</returns>
        public MemoryStream CarregarArquivo(String path)
        {
            #region Pré-Condições

            IAssertion pathFoiEncontrado = Assertion.Equals(path,"", "O Path informado para leitura do Arquivo Esta Vazio");

            #endregion

            pathFoiEncontrado.Validate();

            MemoryStream memoryStream = null;
            using (var fileStream = File.OpenRead(path))
            {
                memoryStream = new MemoryStream();
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
            }

            #region Pós-Condições

            IAssertion arquivoFoiCarregado = Assertion.GreaterThan(memoryStream.Length, 0, "O Arquivo Retornado Esta Vazio (0 bytes)");

            #endregion

            arquivoFoiCarregado.Validate();

            return memoryStream;
        }

        /// <summary>
        /// Escreve o conteudo da memoria num arquivo em um local
        /// </summary>
        /// <param name="memoryStream">conteudo binario</param>
        public GravarArquivoEmDisco(MemoryStream memoryStream)
        {
            #region Pré-Condições

            IAssertion oArquivoRecebido = Assertion.GreaterThan(memoryStream.Length, 0, "O Arquivo Recebido Esta Vazio (0 bytes)");
            IAssertion pathArquivosSalvos = Assertion.Equals(System.Configuration.ConfigurationSettings.AppSettings["rootArquivosSalvos"], "", "O Path do Diretorio informado para leitura está vazio");

            #endregion

            oArquivoRecebido.and(pathArquivosSalvos).Validate();
       

            using (FileStream file = new FileStream("file.bin", FileMode.Create, FileAccess.Write)) {
             memoryStream.WriteTo(file);

        }

        }

    }
}
