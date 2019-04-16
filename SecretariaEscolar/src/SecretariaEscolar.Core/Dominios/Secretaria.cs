using System;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Secretaria
	{
		private List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
		private List<Aluno> Alunos { get; set; } = new List<Aluno>();
		private List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
		private List<Professor> Professores { get; set; } = new List<Professor>();

		public void Matricular(Aluno aluno)
		{
			if (!Alunos.Any(p => p.Matricula == aluno.Matricula))
				Alunos.Add(aluno);
		}

		public IEnumerable<Aluno> ObterAlunos()
		{
			return Alunos;
		}

		public Aluno ObterAlunoPorMatricula(Int32 matricula)
		{
			return Alunos.SingleOrDefault(a => a.Matricula == matricula);
		}

		public void Alterar(Aluno aluno)
		{
			var alunoEncontrado = ObterAlunoPorMatricula(aluno.Matricula);
			alunoEncontrado.AlterarNome(aluno.Nome);
		}



		public void Alterar(Disciplina disciplina)
		{
			var disciplinaEncontrada = ObterDisciplinaPorCodigoImpl(disciplina.Codigo);
			disciplinaEncontrada.AlterarNome(disciplina.Nome);
		}

		public Disciplina ObterDisciplinaPorCodigo(Int32 codigo)
		{
			return ObterDisciplinaPorCodigoImpl(codigo);
		}

		private Disciplina ObterDisciplinaPorCodigoImpl(Int32 codigo)
		{
			return Disciplinas.SingleOrDefault(d => d.Codigo == codigo);
		}

		public void CriarDisciplina(Disciplina disciplina)
		{
			Disciplinas.Add(disciplina);
		}

		public IEnumerable<Disciplina> ObterDisciplinas()
		{
			return Disciplinas;
		}



		public void Matricular(Professor professor)
		{
			if (!Professores.Any(p => p.Matricula == professor.Matricula))
				Professores.Add(professor);
		}

		public Professor ObterProfessorPorMatricula(Int32 matricula)
		{
			return Professores.SingleOrDefault(p => p.Matricula == matricula);
		}

		public IEnumerable<Professor> ObterProfessores()
		{
			return Professores;
		}



		public void Matricular(Pessoa pessoa)
		{
			if (!Pessoas.Any(p => p.Matricula == pessoa.Matricula))
			{
				Pessoas.Add(pessoa);
			}
		}

		public IEnumerable<Pessoa> ObterPessoas()
		{
			return Pessoas;
		}

		public Pessoa ObterPessoaPorMatricula(Int32 matricula)
		{
			return Pessoas.SingleOrDefault(p => p.Matricula == matricula);
		}


		public String GerarArquivoSaida()
		{
			var disciplinas = Disciplinas.OrderBy(d => d.Nome).Select(Disciplina.RelatorioSaida);
			var pessoas = Pessoas.OrderBy(p => p.Matricula).Select(Pessoa.RelatorioSaida);

			var relatorioDisciplinas = String.Join("\r\n", disciplinas);
			var relatorioPessoas = String.Join("\r\n", pessoas);
			return relatorioDisciplinas + "\r\n" + relatorioPessoas;
		}
	}
}