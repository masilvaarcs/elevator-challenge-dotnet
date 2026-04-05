using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul;

namespace DesafioApisul
{
    public partial class FrmTelaEstatisticas : Form
    {
        public FrmTelaEstatisticas()
        {
            InitializeComponent();
        }

        private void BtnLerJSON_Click(object sender, EventArgs e)
        {
            LoadJson();

        }

        public void LoadJson()
        {          
            Entradas ent = new Entradas();

            List<ElevadorModel> elevadoresModel = new List<ElevadorModel>();

            elevadoresModel = ent.RecebeEntradas();

            Elevadores elevadores = new Elevadores(elevadoresModel);

            //Resposta A
            elevadores.andarMenosUtilizado().ToString();
            txtMenosUtilizado.Text = elevadores.glbAndarMenosUtilizado; //A1
            txtOutrosMenosUtilizados.Text = elevadores.glbOutrosAndaresMenosUtilizado; //A2

            //Resposta B1 e B2
            elevadores.elevadorMaisFrequentado();
            elevadores.periodoMaiorFluxoElevadorMaisFrequentado();
            txtMaisFrequentadoMaiorFluxo.Text = elevadores.glbElevadorMaisFrequentadoMaiorFluxo;

            //Resposta C1 e C2
            elevadores.elevadorMenosFrequentado();
            elevadores.periodoMenorFluxoElevadorMenosFrequentado();
            txtMenosFrequentadoMenorFluxo.Text = elevadores.glbElevadorMenosFrequentadoMenorFluxo;

            //Resposta D
            elevadores.periodoMaiorUtilizacaoConjuntoElevadores();
            txtMaiorUtilizacaoConjuntoElevadores.Text = elevadores.glbPeriodoMaiorUtilizacaoConjuntoElevadores;

            //Resposta E - Percentuais de Cada Elevador
            var perUsoElevA = elevadores.percentualDeUsoElevadorA();
            decimal d;
            if (decimal.TryParse(perUsoElevA.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out d))
            {
                decimal t = Math.Truncate(d * 100) / 100;
                txtPercentualCadaElevadorA.Text += "Elevador A:" + t.ToString("0.##");
            }

            var perUsoElevB = elevadores.percentualDeUsoElevadorB();
            if (decimal.TryParse(perUsoElevB.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out d))
            {
                decimal t = Math.Truncate(d * 100) / 100;
                txtPercentualCadaElevadorB.Text += "Elevador B:" + t.ToString("0.##");
            }

            var perUsoElevC = elevadores.percentualDeUsoElevadorC();
            if (decimal.TryParse(perUsoElevC.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out d))
            {
                decimal t = Math.Truncate(d * 100) / 100;
                txtPercentualCadaElevadorC.Text += "Elevador C:" + t.ToString("0.##");
            }

            var perUsoElevD = elevadores.percentualDeUsoElevadorD();
            if (decimal.TryParse(perUsoElevD.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out d))
            {
                decimal t = Math.Truncate(d * 100) / 100;
                txtPercentualCadaElevadorD.Text += "Elevador D:" + t.ToString("0.##");
            }

            var perUsoElevE = elevadores.percentualDeUsoElevadorE();
            if (decimal.TryParse(perUsoElevE.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out d))
            {
                decimal t = Math.Truncate(d * 100) / 100;
                txtPercentualCadaElevadorE.Text += "Elevador E:" + t.ToString("0.##");
            }
        }

        private void TxtPercentualCadaElevador_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtMenosUtilizado_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
