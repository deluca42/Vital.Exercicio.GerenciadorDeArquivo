﻿using System;
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
        [Test]
        public void teste_de_instancia()
        {
            var meuGerenciador = new GerenciadorDeArquivoMain();

            Assert.IsNotNull(meuGerenciador, "instancia do objeto nula");
        }


    }
}
