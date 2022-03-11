using System;
using System.Drawing;
using System.Drawing.Text;

namespace WS.CRUD
{
    public class RelatorioCampos : WS.CRUD.Base
    {
        public RelatorioCampos(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RelatorioCampos input = (Data.RelatorioCampos)parametros["Key"];
            Tables.RelatorioCampos bd = new Tables.RelatorioCampos();

            bd.idRelatorioCampo.isNull = true;
            bd.idRelatorioBanda.idRelatorioBanda.value = input.idRelatorioBanda;
            bd.nome.value = input.nome;
            bd.tipo.value = input.tipo;
            bd.campo.value = input.campo;
            bd.cantoBorda.value = input.cantoBorda;
            bd.linha.value = input.linha;
            bd.coluna.value = input.coluna;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.valor.value = input.valor;
            bd.formato.value = input.formato;
            bd.condicao.value = input.condicao;
            bd.fonteNome.value = input.fonteNome;
            bd.fonteTamanho.value = input.fonteTamanho;
            bd.fonteEstilo.value = input.fonteEstilo;
            bd.fonteCor.value = input.fonteCor;
            bd.alinhamento.value =
            (
                input.alinhamento == "Center" ? "C" :
                input.alinhamento == "Right" ? "D" :
                input.alinhamento == "LeftFit" ? "EA" :
                input.alinhamento == "CenterFit" ? "CA" :
                input.alinhamento == "RightFit" ? "DA" :
                "E"
            );

            this.m_EntityManager.persist(bd);

            ((Data.RelatorioCampos)parametros["Key"]).idRelatorioCampo = (int)bd.idRelatorioCampo.value;

            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioCampos input = (Data.RelatorioCampos)parametros["Key"];
            Tables.RelatorioCampos bd = (Tables.RelatorioCampos)this.m_EntityManager.find
            (
                typeof(Tables.RelatorioCampos),
                new Object[]
                {
                    input.idRelatorioCampo
                }
            );

            bd.idRelatorioBanda.idRelatorioBanda.value = input.idRelatorioBanda;
            bd.nome.value = input.nome;
            bd.tipo.value = input.tipo;
            bd.campo.value = input.campo;
            bd.cantoBorda.value = input.cantoBorda;
            bd.linha.value = input.linha;
            bd.coluna.value = input.coluna;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.valor.value = input.valor;
            bd.formato.value = input.formato;
            bd.condicao.value = input.condicao;
            bd.fonteNome.value = input.fonteNome;
            bd.fonteTamanho.value = input.fonteTamanho;
            bd.fonteEstilo.value = input.fonteEstilo;
            bd.fonteCor.value = input.fonteCor;
            bd.alinhamento.value =
            (
                input.alinhamento == "Center" ? "C" :
                input.alinhamento == "Right" ? "D" :
                input.alinhamento == "LeftFit" ? "EA" :
                input.alinhamento == "CenterFit" ? "CA" :
                input.alinhamento == "RightFit" ? "DA" :
                "E"
            );

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RelatorioCampos bd = new Tables.RelatorioCampos();

            bd.idRelatorioCampo.value = ((Data.RelatorioCampos)parametros["Key"]).idRelatorioCampo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.RelatorioCampos)bd).idRelatorioCampo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RelatorioCampos)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RelatorioCampos)input).idRelatorioCampo = ((Tables.RelatorioCampos)bd).idRelatorioCampo.value;
                    ((Data.RelatorioCampos)input).idRelatorioBanda = ((Tables.RelatorioCampos)bd).idRelatorioBanda.idRelatorioBanda.value;
                    ((Data.RelatorioCampos)input).nome = ((Tables.RelatorioCampos)bd).nome.value;
                    ((Data.RelatorioCampos)input).tipo = ((Tables.RelatorioCampos)bd).tipo.value;
                    ((Data.RelatorioCampos)input).campo = ((Tables.RelatorioCampos)bd).campo.value;
                    ((Data.RelatorioCampos)input).cantoBorda = ((Tables.RelatorioCampos)bd).cantoBorda.value;
                    ((Data.RelatorioCampos)input).linha = String.Format("{0:0000}", Utils.Utils.ToInt(((Tables.RelatorioCampos)bd).linha.value));
                    ((Data.RelatorioCampos)input).coluna = String.Format("{0:0000}", Utils.Utils.ToInt(((Tables.RelatorioCampos)bd).coluna.value));
                    ((Data.RelatorioCampos)input).largura = String.Format("{0:0000}", Utils.Utils.ToInt(((Tables.RelatorioCampos)bd).largura.value));
                    ((Data.RelatorioCampos)input).altura = String.Format("{0:0000}", Utils.Utils.ToInt(((Tables.RelatorioCampos)bd).altura.value));
                    ((Data.RelatorioCampos)input).valor = ((Tables.RelatorioCampos)bd).valor.value;
                    ((Data.RelatorioCampos)input).formato = ((Tables.RelatorioCampos)bd).formato.value;
                    ((Data.RelatorioCampos)input).condicao = ((Tables.RelatorioCampos)bd).condicao.value;
                    ((Data.RelatorioCampos)input).fonteNome = ((Tables.RelatorioCampos)bd).fonteNome.value;
                    ((Data.RelatorioCampos)input).fonteTamanho = ((Tables.RelatorioCampos)bd).fonteTamanho.value;
                    ((Data.RelatorioCampos)input).fonteEstilo = ((Tables.RelatorioCampos)bd).fonteEstilo.value;
                    ((Data.RelatorioCampos)input).fonteCor = ((Tables.RelatorioCampos)bd).fonteCor.value;
                    ((Data.RelatorioCampos)input).alinhamento =
                    (
                        ((Tables.RelatorioCampos)bd).alinhamento.value == "C" ? "Center" :
                        ((Tables.RelatorioCampos)bd).alinhamento.value == "D" ? "Right" :
                        ((Tables.RelatorioCampos)bd).alinhamento.value == "EA" ? "LeftFit" :
                        ((Tables.RelatorioCampos)bd).alinhamento.value == "CA" ? "CenterFit" :
                        ((Tables.RelatorioCampos)bd).alinhamento.value == "DA" ? "RightFit" :
                        "Left"
                    );

                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioCampos result = (Data.RelatorioCampos)parametros["Key"];

            try
            {
                result = (Data.RelatorioCampos)this.preencher
                (
                    new Data.RelatorioCampos(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RelatorioCampos),
                        new Object[]
                        {
                            result.idRelatorioCampo
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioCampos input = (Data.RelatorioCampos)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.RelatorioCampos),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RelatorioCampos _data in
                    (System.Collections.Generic.List<Tables.RelatorioCampos>)this.m_EntityManager.list
                    (
                        typeof(Tables.RelatorioCampos),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.RelatorioCampos(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
