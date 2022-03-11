using System;

public static class Extenso
{
    private static String toExtenso(int valor)
    {
        String[]
            Centena = new String[]
                {
                    "CEM",
                    "CENTO", "DUZENTOS", "TREZENTOS", "QUATROCENTOS", "QUINHENTOS", "SEISCENTOS", "SETECENTOS", "OITOCENTOS", "NOVECENTOS"                    
                },
            Dezena = new String[]
                {
                    "", "", "VINTE", "TRINTA", "QUARENTA", "CINQUENTA", "SESSENTA", "SETENTA", "OITENTA", "NOVENTA"
                },
            Unidade = new String[]
                {
                    "",
                    "UM", "DOIS", "TRÊS", "QUATRO", "CINCO", "SEIS", "SETE", "OITO", "NOVE", "DEZ",
                    "ONZE", "DOZE", "TREZE", "QUATORZE", "QUINZE", "DEZESSEIS", "DEZESSETE", "DEZOITO", "DEZENOVE"
                };

        String valorExtenso = "";

        while (valor > 0)
        {
            if (valor > 99)
            {
                valorExtenso = Centena[(valor == 100 ? 0 : (valor / 100))];
                valor = valor % 100;
            }
            else
            {
                if (valor > 19)
                {
                    valorExtenso += ((valorExtenso.Length > 0 ? " E " : "") + Dezena[(valor / 10)]);
                    valor = valor % 10;
                }
                else
                {
                    valorExtenso += ((valorExtenso.Length > 0 ? " E " : "") + Unidade[valor]);
                    valor = 0;
                }
            }
        }

        return valorExtenso;
    }

    public static string toExtenso(Object valor)
    {
        String
            strValor = System.Convert.ToDecimal(valor).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, ""),
            valor_por_extenso = String.Empty;

        String[,] Unidades = new String[,]
        {
            {"CENTAVO", "CENTAVOS"},
            {"REAL", "DE REAIS"},
            {"MIL", "MIL"},
            {"MILHÃO", "MILHÕES"},
            {"BILHÃO", "BILHÕES"},
            {"TRILHÃO", "TRILHÕES"}
        };

        int
            iUnidade = 0,
            _valor = 0,
            _valorAnterior = 0,
            centavos = 0;

        while (strValor.Length > 0)
        {
            String parte = strValor.Substring(strValor.Length - (strValor.Length > 3 ? 3 : strValor.Length));
            _valorAnterior = _valor;
            _valor = int.Parse(parte.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, "0"));

            if (iUnidade == 0)
            {
                centavos = _valor;
                _valorAnterior = 0;
            }
            else
            {
                if (((iUnidade == 1) || (iUnidade == 2)) && (_valor > 0))
                    Unidades[1, 1] = "REAIS";
                else { }

                valor_por_extenso =
                (
                    toExtenso(_valor) +
                    (
                        (iUnidade > 1) ?
                        (" " + Unidades[iUnidade, (_valor > 1 ? 1 : 0)]) :
                        ""
                    ) +
                    (
                        (valor_por_extenso.Length > 0) ?
                        " " :
                        ""
                    ) +
                    (
                        (
                            (iUnidade > 1) &&
                            (_valorAnterior > 0) &&
                            (
                                (_valorAnterior == 100) ||
                                ((int)(_valorAnterior / 100) != 1)
                            )
                        )?
                        "E ":
                        ""
                    ) +
                    valor_por_extenso.Trim()
                );
            }

            if (strValor.Length > 3)
                strValor = strValor.Substring(0, strValor.Length - 3);
            else
                strValor = "";

            if (strValor.Length > 0)
                iUnidade++;
            else { }
        }

        valor_por_extenso = valor_por_extenso.Trim();

        if (iUnidade == 1)
        {
            switch (_valor)
            {
                case 0:
                    Unidades[0, 0] = "CENTAVO DE REAL";
                    Unidades[0, 1] = "CENTAVOS DE REAL";
                    break;

                case 1:
                    valor_por_extenso += (" " + Unidades[1, 0]);
                    break;

                default:
                    valor_por_extenso += (" " + Unidades[1, 1]);
                    break;
            }
        }
        else
            valor_por_extenso += (" " + Unidades[1, 1]);

        if (centavos > 0)
            valor_por_extenso += (valor_por_extenso.Length > 0 ? " E " : "") + (toExtenso(centavos) + (" " + Unidades[0, (centavos == 1 ? 0 : 1)]));
        else { }

        return valor_por_extenso;
    }
}
