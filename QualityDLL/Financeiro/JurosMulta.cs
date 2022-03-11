using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Financeiro
{
    public class JurosMulta
    {
        public double valorJuros { get; set; }
        public double valorMulta { get; set; }
        public int idNaturezaOperacao { get; set; }
        public int idContasAReceberItem { get; set; }
        public DateTime dataInicioCobrancaJuros { get; set; }

        public static JurosMulta CalculaJurosMulta(int idContasAReceberItem, int idEmpresa, DateTime? dataVencimento = null)
        {
            JurosMulta result = new JurosMulta();
            Service sr = Utils.Utils.sr(idEmpresa);
            Data.ContasAReceberItem cri = new Data.ContasAReceberItem
            {
                idContasAReceberItem = idContasAReceberItem
            };
            cri = (Data.ContasAReceberItem)sr.consultar(cri);

            if (cri == null || (cri != null && cri.idContasAReceberItem == 0))
                throw new Exception("Contas a receber item inexistente!");

            Data.NaturezaOperacao no = new Data.NaturezaOperacao
            {
                idNaturezaOperacao = cri.idNaturezaOperacao
            };
            no = (Data.NaturezaOperacao)sr.consultar(no);
            if (no == null || (no != null && no.idNaturezaOperacao == 0))
                throw new Exception("Natureza de oparação inexistente!");

            if (no.parametroAcrescimo != null && no.parametroAcrescimo.idParametroAcrescimo > 0)
            {
                Data.ParametroAcrescimo pa = no.parametroAcrescimo;
                string
                    tipoJuro = pa.tipoJuro,
                    tipoMulta = pa.tipoMulta,
                    tipoCarenciaJuros = pa.tipoCarenciaJuros,
                    tipoCarenciaMulta = pa.tipoCarenciaMulta;

                int
                    diasCarenciaJuros = pa.diasCarenciaJuros,
                    diasCarenciaMulta = pa.diasCarenciaMulta;

                double
                    valorJuros = pa.valorJuros,
                    valorMulta = pa.valorMulta;


                DateTime
                    dataVencimentoJuros = (dataVencimento == null ? cri.idContasAReceber.dataVencimento : ((DateTime)dataVencimento).Date).AddDays(diasCarenciaJuros),
                    dataVencimentoMulta = (dataVencimento == null ? cri.idContasAReceber.dataVencimento : ((DateTime)dataVencimento).Date).AddDays(diasCarenciaMulta);

                double valorBase = (cri.valor / cri.idContasAReceber.valor) * (cri.idContasAReceber.valor - cri.idContasAReceber.valorRecebido);

                /* Calculando Juros */
                {
                    DateTime
                    dataVencimentoUtil = getProximaDataUtil(dataVencimentoJuros, idEmpresa),
                    dataVencimentoOriginal = cri.idContasAReceber.dataVencimento,
                    dataOrigem = dataVencimento == null ? DateTime.Now.Date : ((DateTime)dataVencimento).Date;

                    if (dataVencimento == null && dataVencimentoUtil.Date.Ticks >= DateTime.Now.Date.Ticks)
                        return result;


                    int diasACalcular = (dataOrigem - dataVencimentoOriginal.Date).Days;
                    double valorAPagarJuros = 0;
                    if (tipoJuro == "p")
                        valorAPagarJuros = Convert.ToDouble(((valorBase * valorJuros * diasACalcular) / 3000).ToString("0.00"));
                    else
                        valorAPagarJuros = Convert.ToDouble((valorJuros * diasACalcular).ToString("0.00"));

                    if (result == null) result = new JurosMulta();
                    result.valorJuros = valorAPagarJuros;
                }

                /* Calculando Multa */
                {
                    DateTime
                    dataVencimentoUtil = getProximaDataUtil(dataVencimentoMulta, idEmpresa),
                    dataVencimentoOriginal = cri.idContasAReceber.dataVencimento;

                    if (dataVencimento == null && dataVencimentoUtil.Date.Ticks >= DateTime.Now.Date.Ticks)
                        return result;

                    double valorAPagarMulta = 0;
                    if (tipoJuro == "p")
                        valorAPagarMulta = Convert.ToDouble(((valorMulta * valorBase) / 100).ToString("0.00"));
                    else
                        valorAPagarMulta = valorMulta;

                    if (result == null) result = new JurosMulta();
                    result.valorMulta = valorAPagarMulta;
                }

                result.idNaturezaOperacao = cri.idNaturezaOperacao;
                result.idContasAReceberItem = cri.idContasAReceberItem;

            }
            return result;
        }

        public static JurosMulta CalculaJurosMultaGrupoCobranca(Data.ParametroAcrescimo pa, int idEmpresa, Data.Boleto boleto, DateTime? dataVencimento = null)
        {
            JurosMulta result = new JurosMulta();
            Service sr = Utils.Utils.sr(idEmpresa);

            if (pa == null || (pa != null && pa.idParametroAcrescimo == 0))
                return result;

            if (pa != null && pa.idParametroAcrescimo > 0)
            {
                string
                    tipoJuro = pa.tipoJuro,
                    tipoMulta = pa.tipoMulta,
                    tipoCarenciaJuros = pa.tipoCarenciaJuros,
                    tipoCarenciaMulta = pa.tipoCarenciaMulta;

                int
                    diasCarenciaJuros = pa.diasCarenciaJuros,
                    diasCarenciaMulta = pa.diasCarenciaMulta;

                double
                    valorJuros = pa.valorJuros,
                    valorMulta = pa.valorMulta;


                DateTime
                    dataVencimentoJuros = (dataVencimento == null ? boleto.dataVencimento : ((DateTime)dataVencimento).Date).AddDays(diasCarenciaJuros + 1),
                    dataVencimentoMulta = (dataVencimento == null ? boleto.dataVencimento : ((DateTime)dataVencimento).Date).AddDays(diasCarenciaMulta);

                if (boleto.boletoItems == null)
                    boleto = (Data.Boleto)Utils.Utils.sr(idEmpresa).consultar(boleto);
                double valorBase = Convert.ToDouble(boleto.boletoItems.Where(T => T.contasAReceber.dataVencimento.Ticks >= boleto.dataVencimento.Ticks).Sum(T => T.valor).ToString("0.00"));

                /* Calculando Juros */
                {
                    DateTime
                    dataVencimentoUtil = getProximaDataUtil(dataVencimentoJuros, idEmpresa),
                    dataVencimentoOriginal = boleto.dataVencimento,
                    dataOrigem = dataVencimento == null ? DateTime.Now.Date : ((DateTime)dataVencimento).Date;

                    if (dataVencimento == null && dataVencimentoUtil.Date.Ticks >= DateTime.Now.Date.Ticks)
                        return result;


                    int diasACalcular = (dataOrigem - dataVencimentoOriginal.Date).Days;
                    double valorAPagarJuros = 0;
                    if (tipoJuro == "p")
                        valorAPagarJuros = Convert.ToDouble(((valorBase * valorJuros) / 3000).ToString("0.00"));
                    else
                        valorAPagarJuros = Convert.ToDouble((valorJuros).ToString("0.00"));

                    if (result == null) result = new JurosMulta();
                    result.valorJuros = valorAPagarJuros;
                    result.dataInicioCobrancaJuros = dataVencimentoJuros;

                }

                /* Calculando Multa */
                {
                    DateTime
                    dataVencimentoUtil = getProximaDataUtil(dataVencimentoMulta, idEmpresa),
                    dataVencimentoOriginal = boleto.dataVencimento;

                    if (dataVencimento == null && dataVencimentoUtil.Date.Ticks >= DateTime.Now.Date.Ticks)
                        return result;

                    double valorAPagarMulta = 0;
                    if (tipoJuro == "p")
                        valorAPagarMulta = Convert.ToDouble(((valorMulta * valorBase) / 100).ToString("0.00"));
                    else
                        valorAPagarMulta = valorMulta;

                    if (result == null) result = new JurosMulta();
                    result.valorMulta = valorAPagarMulta;
                }
            }
            return result;
        }

        public static bool isFeriado(DateTime data, int idEmpresa)
        {

            if (((int)data.DayOfWeek) == 0 || ((int)data.DayOfWeek) == 6)
                return true;

            string _filter = String.Format("feriado.dia = CAST('{0}' AS INT) AND feriado.mes = CAST('{1}' AS INT) AND (feriado.ano = CAST('{2}' AS INT) OR feriado.ano IS NULL)", data.Day, data.Month, data.Year);
            List<NameValue> _params = new List<NameValue>
            {
                new NameValue{name = "Filter", value = _filter }
            };

            List<Data.Base> results = Utils.Utils.listaDados(idEmpresa, new Data.Feriado(), 0, _params);
            if (results != null && results.Count > 0)
                return true;
            return false;

        }

        public static DateTime getProximaDataUtil(DateTime date, int idEmpresa)
        {
            bool feriado = isFeriado(date, idEmpresa);
            if (!feriado)
                return date;

            return getProximaDataUtil(date.AddDays(1), idEmpresa);
        }
    }
}
