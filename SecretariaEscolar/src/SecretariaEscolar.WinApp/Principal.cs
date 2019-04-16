using System;
using System.Windows.Forms;

namespace PUC.Desafio.SecretariaEscolar.WinApp
{
	public static class Principal
	{
		[STAThread]
		public static void Main(String[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}