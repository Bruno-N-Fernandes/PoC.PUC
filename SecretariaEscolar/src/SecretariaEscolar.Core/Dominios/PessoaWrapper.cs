using System;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	/// <summary>
	/// Classe que Abstrai os comportamentos padrões entre aluno e professor
	/// </summary>
	public abstract class PessoaWrapper : IPessoaWrapper
	{
		Pessoa IPessoaWrapper.Pessoa { get => Pessoa; set => Pessoa = value; }
		protected Pessoa Pessoa { get; private set; }
		protected List<Disciplina> Disciplinas { get; private set; }

		public Int32 Matricula => Pessoa.Matricula;
		public String Nome => Pessoa.Nome;

		public abstract TipoPessoa TipoPessoa { get; }

		protected PessoaWrapper() { Disciplinas = new List<Disciplina>(); }

		protected PessoaWrapper(Pessoa pessoa) : this()
		{
			Pessoa = pessoa;
		}

		public virtual void AlterarNome(String nome)
		{
			Pessoa.AlterarNome(nome);
		}

		public virtual IEnumerable<Disciplina> ObterDisciplinas()
		{
			return Disciplinas.ToArray();
		}

		public virtual Disciplina ObterDisciplinaPor(Int32 codigo)
		{
			return Disciplinas.SingleOrDefault(d => d.Codigo == codigo);
		}

		protected virtual Boolean Existe(Disciplina disciplina)
		{
			return Disciplinas.Any(d => d.Codigo == disciplina.Codigo);
		}

		protected virtual Boolean Adicionar(Disciplina disciplina)
		{
			if (!Existe(disciplina))
			{
				Disciplinas.Add(disciplina);
				return true;
			}
			return false;
		}
	}
}