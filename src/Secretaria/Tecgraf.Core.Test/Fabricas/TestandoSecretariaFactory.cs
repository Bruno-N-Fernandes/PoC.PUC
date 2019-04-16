using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Fabricas;
using System;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Fabricas
{
	[TestClass]
	public class TestandoSecretariaFactory
	{
		[TestMethod]
		public void QuandoSolicitarCriacaoDaSecretariaFactory_DeveRetornarCorretamenteUmaSecretaria()
		{
			var secretaria = SecretariaFactory.CriarPorConteudo(conteudoArquivoEntradaTxt);

			Assert.AreEqual(3, secretaria.ObterDisciplinas().Count());
			Assert.AreEqual(3, secretaria.ObterProfessores().Count());
			Assert.AreEqual(5, secretaria.ObterAlunos().Count());
			Assert.AreEqual(7, secretaria.ObterPessoas().Count());
		}

		private const String conteudoArquivoEntradaTxt = @"3
543 Historia
658 Patricia
2
123 Maria
222 Pedro
234 Algebra
741 Carla
3
123 Maria
246 Joao
369 Jose
987 Portugues
864 Silvia
4
246 Joao
369 Jose
222 Pedro
741 Carla";


	}
}