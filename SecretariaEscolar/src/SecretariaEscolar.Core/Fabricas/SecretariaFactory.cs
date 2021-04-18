using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using PUC.Desafio.SecretariaEscolar.Core.Utilitarios;
using System;
using System.Collections.Generic;
using System.IO;

namespace PUC.Desafio.SecretariaEscolar.Core.Fabricas
{
	public class SecretariaFactory
	{
		public static Secretaria CriarPorArquivo(FileInfo arquivoEntrada)
		{
			var conteudo = File.ReadAllText(arquivoEntrada.FullName);
			return CriarPorConteudo(conteudo);
		}

		public static Secretaria CriarPorConteudo(String conteudo)
		{
			var leitor = new Leitor(conteudo);
			return CriarPorLeitor(leitor);
		}

		private static Secretaria CriarPorLeitor(Leitor leitor)
		{
			var secretaria = new Secretaria();

			CriarDisciplinas(leitor, secretaria);

			return secretaria;
		}

		private static void CriarDisciplinas(Leitor leitor, Secretaria secretaria)
		{
			var quantidadeDeDisciplinas = leitor.LerInteiro();
			for (var i = 0; i < quantidadeDeDisciplinas; i++)
			{
				var disciplina = CriarDisciplina(leitor);
				secretaria.AdicionarDisciplina(disciplina);

				var professor = CriarProfessor(leitor, secretaria);
				disciplina.DefinirTitular(professor);

				var alunos = CriarAlunos(leitor, secretaria);
				disciplina.InscreverAluno(alunos);
			}
		}

		private static Disciplina CriarDisciplina(Leitor leitor)
		{
			var linha = leitor.LerString().SplitFields();
			var disciplina = new Disciplina(linha.Codigo, linha.Descricao);
			return disciplina;
		}

		private static Professor CriarProfessor(Leitor leitor, Secretaria secretaria)
		{
			var linha = leitor.LerString().SplitFields();
			var professor = secretaria.ObterProfessorPorMatricula(linha.Codigo);
			if (professor == null)
			{
				var pessoa = ObterPessoa(linha.Codigo, linha.Descricao, secretaria);
				professor = pessoa.TransformarEm<Professor>();
				secretaria.Matricular(professor);
			}

			return professor;
		}

		private static IEnumerable<Aluno> CriarAlunos(Leitor leitor, Secretaria secretaria)
		{
			var alunos = new List<Aluno>();
			var quantidadeAlunos = leitor.LerInteiro();
			for (var i = 0; i < quantidadeAlunos; i++)
			{
				var aluno = CriarAluno(leitor, secretaria);
				alunos.Add(aluno);
			}
			return alunos;
		}

		private static Aluno CriarAluno(Leitor leitor, Secretaria secretaria)
		{
			var linha = leitor.LerString().SplitFields();
			var aluno = secretaria.ObterAlunoPorMatricula(linha.Codigo);
			if (aluno == null)
			{
				var pessoa = ObterPessoa(linha.Codigo, linha.Descricao, secretaria);
				aluno = pessoa.TransformarEm<Aluno>();
				secretaria.Matricular(aluno);
			}
			return aluno;
		}

		private static Pessoa ObterPessoa(int matricula, string nome, Secretaria secretaria)
		{
			var pessoa = secretaria.ObterPessoaPorMatricula(matricula);

			return pessoa ?? new Pessoa(matricula, nome);
		}
	}
}