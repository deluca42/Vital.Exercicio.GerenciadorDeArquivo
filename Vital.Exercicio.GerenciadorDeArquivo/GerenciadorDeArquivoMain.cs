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
        public void EscreverArquivo(Object meuArquivo)
        {
            #region Pré-Condições

            IAssertion oArquivoFoiInformado = Assertion.NotNull(meuArquivo, "O Arquivo não foi informado");


            #endregion

        }
        public MemoryStream CarregarPathEmStream(String path)
        {
            MemoryStream memoryStream = null;
            using (var fileStream = File.OpenRead(path))
            {
                memoryStream = new MemoryStream();
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
          
            }
            return memoryStream;
        }

    }
}
