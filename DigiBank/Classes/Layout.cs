using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                                                 ");
            Console.WriteLine("            Digite a opção desejada:             ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("               1 - Criar Conta                   ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("            2 - Entrar com CPF e senha           ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        }

        private static void TelaCriarConta()
        {
            Console.Clear();


            Console.WriteLine("                                                 ");
            Console.WriteLine("               Digite seu nome:                  ");
            string nome = Console.ReadLine();
            Console.WriteLine("            ########################             ");
            Console.WriteLine("               1 - Digite o CPF                  ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ########################             ");
            Console.WriteLine("               2 - Digite sua senha              ");
            string senha = Console.ReadLine();
            Console.WriteLine("                                                 ");

            Console.WriteLine(nome);
            Console.WriteLine(cpf);
            Console.WriteLine(senha);

            //criar conta

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();


            Console.WriteLine("         Conta cadastrada com sucesso            ");
            Console.WriteLine("            ########################             ");

            Thread.Sleep(1500);
            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                 ");
            Console.WriteLine("                 Digite o CPF:                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ########################             ");
            Console.WriteLine("               Digite sua senha:                 ");
            string senha = Console.ReadLine();
            Console.WriteLine("            ########################             ");


            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear(); 

                Console.WriteLine("             Pessoa não cadastrada               ");
                Console.WriteLine("            ########################             ");
                Console.WriteLine("                                                 ");
                Console.WriteLine("                                                 ");
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBoasVindas =
            $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} " +
            $"| Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroDaConta()}";

            Console.WriteLine("                                                  ");
            Console.WriteLine($"         Seja Bem-vindo, {msgTelaBoasVindas}     ");
            Console.WriteLine("                                                  ");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("             Digite a opção desejada:            ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("                1 - Deposito                     ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("                2 - Saque                        ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("                3 - Saldo                        ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("                4 - Extrato                      ");
            Console.WriteLine("            ########################             ");
            Console.WriteLine("                5 - Sair                         ");

            opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5: TelaPrincipal();
                    break;
                default:
                    Console.WriteLine("                Opção inválida!                  ");
                    Console.WriteLine("            ########################             ");
                    break;
            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("               Digite o valor do deposito:                  ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("               ===========================                  ");

            pessoa.Conta.Deposita(valor);

            Console.Clear() ;

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("              Deposito realizado com sucesso!               ");
            Console.WriteLine("               ===========================                  ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                            ");

        }

        private static void OpcaoVoltarLogado(Pessoa pessoa) 
        {
            Console.WriteLine("              Escolha uma opção abaixo                      ");
            Console.WriteLine("              ===========================                   ");
            Console.WriteLine("              1 - Voltar para minha conta                   ");
            Console.WriteLine("              ===========================                   ");
            Console.WriteLine("              2 - Sair                                      ");
            Console.WriteLine("              ===========================                   ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();

        }
    }
     
            

    

    
        

}

    
       
