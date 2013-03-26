﻿using System;
using System.Collections.Generic;
using System.IO;
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
        private GerenciadorDeArquivoMain _gerenciadorDeArquivo;

        [TestFixtureSetUp]
        public void carregar_setup()
        {
            _gerenciadorDeArquivo = new GerenciadorDeArquivoMain();

        }

        [Test]
        public void teste_de_instancia()
        {
            Assert.IsNotNull(_gerenciadorDeArquivo, "instancia do objeto nula");
        }

        [Test]
        public void teste_escrever_Arquivo()
        {
            String testFilePath = @"C:\Users\Thyago\Desktop\arquivo.jpg";
            Assert.That(_gerenciadorDeArquivo.EscreverArquivo());
        }

    }
}
