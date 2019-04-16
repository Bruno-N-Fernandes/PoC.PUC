using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Utilitarios;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Utilitarios
{
    [TestClass]
    public class TestandoLeitor
	{
        [TestMethod]
        public void QuandoInstanciarUmLeitorComOConteudoDoArquivo_DeveTransformarCadaLinhaDoConteudoEmUmArray()
        {   
            var conteudo = "Linha1";
            var leitor = new Leitor(conteudo);

            Assert.AreEqual(1, leitor.Count);
        }

        [TestMethod]
        public void QuandoInstanciaUmLeitorComConteudoDeArquivo_PosicaoInicialDeveSerZero()
        {
            var conteudo = "Linha1";
            var leitor = new Leitor(conteudo);

            Assert.AreEqual(0, leitor.Posicao);
        }

        [TestMethod]
        public void QuandoLerAPrimeiraLinha_PosicaoAtualDeveSerUM()
        {
            var conteudo = "Linha1";
            var leitor = new Leitor(conteudo);

            leitor.LerString();

            Assert.AreEqual(1, leitor.Posicao);
        }

        [TestMethod]
        public void QuandoLerAPrimeiraLinha_DeveRetornarOConteudoDaPrimeiraLinha()
        {
            var conteudo = "Linha1";
            var leitor = new Leitor(conteudo);

            var conteudoLinha1 = leitor.LerString();
            
            Assert.AreEqual("Linha1", conteudoLinha1);
        }
    }
}
