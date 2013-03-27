using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Exercicio.GerenciadorDeArquivo
{
    /// <summary>
    /// Wrapper da classe File do .Net Framework (Mal escrita)
    /// </summary>
    public class FileWrapper
    {
        /// <summary>
        /// Abre um arquivo qualquer em um diretório
        /// </summary>
        /// <param name="path">caminho do arquivo</param>
        /// <returns>FileStream</returns>
        public virtual FileStream OpenRead(string path)
        {
            return File.OpenRead(path);
        }
    }

    public class FileWrapperMock : FileWrapper
    {
        public FileStream FileStream { get; set; }

        public override FileStream OpenRead(string path)
        {
            //Comportamento falso
            return FileStream;
        }
    }
}
