using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAdmissionalCSharpApisul
{
    public class Elevadores: IElevadorService
    {
        public List<ElevadorModel> elevadores { get; set; }

        //Variáveis utilizadas para jogar o resultado na tela
        public string glbAndarMenosUtilizado = string.Empty; //Resposta A
        public string glbOutrosAndaresMenosUtilizado = string.Empty; //Resposta A

        public string glbElevadorMaisFrequentadoMaiorFluxo = string.Empty; //Resposta B1
        public string glbPeriodoMaiorFluxoElevadorMaisFrequentado = string.Empty; //Resposta B2

        public string glbElevadorMenosFrequentadoMenorFluxo = string.Empty; //Resposta C1
        public string glbPeriodoMenorFluxoElevadorMenosFrequentado = string.Empty; //Resposta C2

        public string glbPeriodoMaiorUtilizacaoConjuntoElevadores = string.Empty;
        public string glbPercentualDeUsoElevadorA = string.Empty;
        public string glbPercentualDeUsoElevadorB = string.Empty;
        public string glbPercentualDeUsoElevadorC = string.Empty;
        public string glbPercentualDeUsoElevadorD = string.Empty;
        public string glbPercentualDeUsoElevadorE = string.Empty;

        public Elevadores(List<ElevadorModel> elevadores)
        {
            this.elevadores = elevadores;
        }

        public List<int> andarMenosUtilizado() //Resposta A
        {
            // Cria uma lista dos andares      
            List<int> andares = new List<int>();
            this.elevadores.ForEach(e => andares.Add(e.Andar));

            // Ordernação pelo andar MENOS frequente
            var andaresMenosUtilizados = (from x in andares
                                          group x by x into grupo
                                          orderby grupo.Count() ascending
                                          select grupo.Key).ToList();

            //Console.WriteLine("\nAndares menos utilizados:\n");

            System.Collections.IList list = andaresMenosUtilizados;
            string auxAndares = string.Empty;
            for (int i = 1; i < list.Count; i++)
            {
                string a = (string)list[i].ToString();
                auxAndares += a.ToString() + ", ";
            }
            // Retorno dos dados - Guardo em varíavel Global para jogar na tela posteriormente
            glbAndarMenosUtilizado = (string)list[0].ToString();
            glbOutrosAndaresMenosUtilizado = auxAndares.ToString().Substring(0,auxAndares.Length-2);
            return andaresMenosUtilizados.ToList();
        }

        public List<char> elevadorMaisFrequentado() //Resposta B1
        {
            // Cria uma lista dos elevadores      
            List<char> elevadores = new List<char>();
            this.elevadores.ForEach(e => elevadores.Add(e.Elevador));

            // Ordernação pelo andar de uso mais frequente

            var elevadoresMaisFrequentados = (from x in elevadores
                                              group x by x into grupo
                                              orderby grupo.Count() descending
                                              select grupo.Key).ToList();

            //Console.WriteLine("\nElevadores mais frequentados:\n");

            //// Retorno dos dados
            //elevadoresMaisFrequentados.ForEach(e => Console.WriteLine(e));

            //return elevadoresMaisFrequentados;
            System.Collections.IList list = elevadoresMaisFrequentados;
            string auxElevadores = string.Empty;
            for (int i = 1; i < list.Count; i++)
            {
                string a = (string)list[i].ToString();
                auxElevadores += a.ToString() + ", ";
            }
            // Retorno dos dados - Guardo em varíavel Global para jogar na tela posteriormente
            glbElevadorMaisFrequentadoMaiorFluxo = "Elevador: " + (string)list[0].ToString();
            return elevadoresMaisFrequentados.ToList();
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado() //Resposta B2
        {
            // Elevador mais frequentado 
            char elevadorMaisFrequentado = this.elevadorMaisFrequentado().First(); 

            var periodos = (from x in this.elevadores
                            where x.Elevador == elevadorMaisFrequentado
                            group x.Turno by x.Turno into grupo
                            orderby grupo.Count() descending
                            select grupo.Key).ToList();


            //Console.WriteLine("\nO elevador mais frequentado é " + elevadorMaisFrequentado + " e é mais utilizado no turno " +
            //                  periodos.First() + "\n");

            glbElevadorMaisFrequentadoMaiorFluxo += " Turno: " + periodos.First();
            return periodos;
        }

        public List<char> elevadorMenosFrequentado() //Resposta C1
        {
            /* Criar lista de elevadores */
            List<char> elevadores = new List<char>();
            this.elevadores.ForEach(e => elevadores.Add(e.Elevador));

            /* Ordernar pelo andar - frequente */

            var elevadoresMenosFrequentados = (from x in elevadores
                                               group x by x into grupo
                                               orderby grupo.Count() ascending
                                               select grupo.Key).ToList();

            //Console.WriteLine("\nElevadores menos frequentados:\n");

            //// deverá sair, pois é retorno
            //elevadoresMenosFrequentados.ForEach(e => Console.WriteLine(e));

            System.Collections.IList list = elevadoresMenosFrequentados;
            string auxElevadores = string.Empty;
            for (int i = 1; i < list.Count; i++)
            {
                string a = (string)list[i].ToString();
                auxElevadores += a.ToString() + ", ";
            }
            // Retorno dos dados - Guardo em varíavel Global para jogar na tela posteriormente
            glbElevadorMenosFrequentadoMenorFluxo = "Elevador: " + (string)list[0].ToString();


            return elevadoresMenosFrequentados.ToList();
        }
        public List<char> periodoMenorFluxoElevadorMenosFrequentado() //Resposta C2
        {
            /*  Pega o elevador - frequentado */
            char elevadorMenosFrequentado = this.elevadorMenosFrequentado().First();

            var periodos = (from x in this.elevadores
                            where x.Elevador == elevadorMenosFrequentado
                            group x.Turno by x.Turno into grupo
                            orderby grupo.Count() ascending
                            select grupo.Key).ToList();

            //Console.WriteLine("\nO elevador menos frequentado é " + elevadorMenosFrequentado + " e é menos utilizado no turno " +
            //                  periodos.First() + "\n");
            glbElevadorMenosFrequentadoMenorFluxo += " Turno: " + periodos.First();

            return periodos;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores() //Resposta D
        {
            // Criar lista de periodos      
            List<char> periodos = new List<char>();
            this.elevadores.ForEach(e => periodos.Add(e.Turno));

            // Ordernar pelo andar - frequente

            var periodoMaiorUtilizacao = (from x in periodos
                                          group x by x into grupo
                                          orderby grupo.Count() descending
                                          select grupo.Key).First();

            //Console.WriteLine("\nOs elevadores são mais utilizados no período " + periodoMaiorUtilizacao + "\n");
            glbPeriodoMaiorUtilizacaoConjuntoElevadores = periodoMaiorUtilizacao.ToString();

            return periodos;
        }

        public float percentualDeUsoElevadorA()
        {
            var percentual = calculaPercentual('A');

            return percentual;
        }
        public float percentualDeUsoElevadorB()
        {
            var percentual = calculaPercentual('B');

            return percentual;
        }
        public float percentualDeUsoElevadorC()
        {
            var percentual = calculaPercentual('C');

            return percentual;
        }

        public float percentualDeUsoElevadorD()
        {
            var percentual = calculaPercentual('D');

            return percentual;
        }

        public float percentualDeUsoElevadorE()
        {
            var percentual = calculaPercentual('E');

            return percentual;
        }

        private float calculaPercentual(char elevador)
        {
            List<int> elevadores = new List<int>();
            this.elevadores.ForEach(e => elevadores.Add(e.Elevador));

            var percentual = ((float)elevadores.Count(i => i == elevador)) / elevadores.Count * 100;

            return float.Parse(percentual.ToString("F2"));
        }
    }
}
