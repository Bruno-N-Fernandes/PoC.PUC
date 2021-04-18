using System;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Secretaria
	{
		private List<Aluno> Alunos { get; set; } = new List<Aluno>();
		private List<Professor> Professores { get; set; } = new List<Professor>();
		private List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

		public IEnumerable<Aluno> ObterAlunos() => Alunos;
		public IEnumerable<Professor> ObterProfessores() => Professores;
		public IEnumerable<Disciplina> ObterDisciplinas() => Disciplinas;

		public IEnumerable<Pessoa> ObterPessoas() => Alunos.OfType<IPessoaWrapper>().Select(a => a.Pessoa).Union(Professores.OfType<IPessoaWrapper>().Select(p => p.Pessoa));
		public Pessoa ObterPessoaPorMatricula(Int32 matricula) => ObterPessoas().SingleOrDefault(p => p.Matricula == matricula);

		public Aluno ObterAlunoPorMatricula(Int32 matricula) => Alunos.SingleOrDefault(a => a.Matricula == matricula);
		public Professor ObterProfessorPorMatricula(Int32 matricula) => Professores.SingleOrDefault(p => p.Matricula == matricula);
		public Disciplina ObterDisciplinaPorCodigo(Int32 codigo) => Disciplinas.SingleOrDefault(d => d.Codigo == codigo);


		public void Matricular(Aluno aluno)
		{
			if (!Alunos.Any(p => p.Matricula == aluno.Matricula))
				Alunos.Add(aluno);
		}

		public void Alterar(Aluno aluno)
		{
			var alunoEncontrado = ObterAlunoPorMatricula(aluno.Matricula);
			alunoEncontrado.AlterarNome(aluno.Nome);
		}


		public void Matricular(Professor professor)
		{
			if (!Professores.Any(p => p.Matricula == professor.Matricula))
				Professores.Add(professor);
		}

		public void Alterar(Professor professor)
		{
			var professorEncontrado = ObterProfessorPorMatricula(professor.Matricula);
			professorEncontrado.AlterarNome(professor.Nome);
		}


		public void AdicionarDisciplina(Disciplina disciplina)
		{
			if (!Disciplinas.Any(p => p.Codigo == disciplina.Codigo))
				Disciplinas.Add(disciplina);
		}

		public void Alterar(Disciplina disciplina)
		{
			var disciplinaEncontrada = ObterDisciplinaPorCodigo(disciplina.Codigo);
			disciplinaEncontrada.AlterarNome(disciplina.Nome);
		}


		public String GerarArquivoSaida()
		{
			var disciplinas = Disciplinas.OrderBy(d => d.Nome).Select(Disciplina.RelatorioSaida);
			var pessoas = ObterPessoas().OrderBy(p => p.Matricula).Select(Pessoa.RelatorioSaida);

			var relatorioDisciplinas = String.Join("\r\n", disciplinas);
			var relatorioPessoas = String.Join("\r\n", pessoas);
			return relatorioDisciplinas + "\r\n" + relatorioPessoas;
		}
	}
}