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
    public class GerenciadorDeArquivoMain
    {
        /// <summary>
        /// escrever arquivo 
        /// </summary>
        /// <param name="meuArquivo"> arquivo </param>
        public void EscreverStreamEmArquivo(Object meuArquivo)
        {
            #region Pré-Condições

            IAssertion oArquivoFoiInformado = Assertion.NotNull(meuArquivo, "O Arquivo não foi informado");


            #endregion

        }

        /// <summary>
        /// Carrega um arquivo em memoria de acordo com o path informado
        /// </summary>
        /// <param name="path">caminho do arquivo</param>
        /// <returns>memorystream</returns>
        public MemoryStream CarregarArquivoEmMemoria(String path)
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

            IAssertion arquivoFoiCarregado = Assertion.GreaterThan(memoryStream.Length, 0, "O Arquivo ");

            #endregion

            arquivoFoiCarregado.Validate();

            return memoryStream;
        }
    }
}
