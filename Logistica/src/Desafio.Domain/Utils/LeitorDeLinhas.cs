using System;

namespace PUC.Desafio.Logistica.Domain.Utils
{
	public class LeitorDeLinhas
    {
        private int LinhaAtual { get; set; } = 0;
        private string[] Linhas { get; }
        public LeitorDeLinhas(string[] conteudo)
        {
            Linhas = conteudo;
        }

        public void PularLinha() => LinhaAtual++;
        public string[] LerArray() => Ler().Split(' ');
        public int LerLinha() => Convert.ToInt32(Ler());

        private string Ler()
        {
            try
            {
                return Linhas[LinhaAtual];
            }
            finally
            {
                PularLinha();
            }
        }
    }
}