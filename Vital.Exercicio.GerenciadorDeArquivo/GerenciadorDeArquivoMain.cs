using System;
using System.Collections.Generic;
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

    }
}
