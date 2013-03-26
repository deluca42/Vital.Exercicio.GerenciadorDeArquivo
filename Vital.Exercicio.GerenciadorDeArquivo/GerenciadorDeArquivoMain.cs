using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.InfraStructure.DSL.DesignByContract;


namespace Vital.Exercicio.GerenciadorDeArquivo
{
    public class GerenciadorDeArquivoMain
    {
        public void EscreverArquivo(Object meuArquivo)
        {
            #region Pré-Condições

            IAssertion oArquivoFoiInformado = Assertion.NotNull(meuArquivo, "O Arquivo não foi informado");
            IAssertion oPathdoDoArquivo = Assertion.NotNull(meuArquivo.getPath, "O Path do Esta Arquivo Nulo");

            oArquivoFoiInformado.and(oPathdoDoArquivo).Validate();

            #endregion

           


        }

        public void LerArquivo()
        {
            
        }


    }
}
