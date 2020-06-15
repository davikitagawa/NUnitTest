using NUnit.Framework;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace NUnitTest
{

    [TestFixture]
    public class Tests
    {
        Pessoa Pessoa;
        // 45317828791 CPF DO BOLSONABO
        [SetUp]
        public void Setup()
        {
            this.Pessoa = new Pessoa()
            {
                Nome = "Bill Gates",
                Cpf = "45317828791",
                Idade = 10
            };
        }

        [Test]
        [Ignore("Espera ai campeão")]
        public void ValidaPessoa()
        {
            var pessoa = new Usuario();

            Assert.IsInstanceOf<Pessoa>(pessoa);            
        }

        [Test]
        [Ignore("Espera aí campeão")]
        public void ValidaPodeBeber()
        {
            Assert.IsFalse(Enumerable.Range(0, 18).Contains(this.Pessoa.Idade));            
        }


        [Test]
       [Ignore("Espera ai campeão")]
        public void ValidaCpf()
        {
            Assert.IsTrue(IsCpf(Pessoa.Cpf));
        }


        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

    }
}

public class Pessoa
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
}
public class Programador : Pessoa
{


}
public class Usuario
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
}
