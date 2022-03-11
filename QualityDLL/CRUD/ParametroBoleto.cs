using System;

namespace WS.CRUD
{
    public class ParametroBoleto : WS.CRUD.Base
    {
        public ParametroBoleto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoleto input = (Data.ParametroBoleto)parametros["Key"];
            Tables.ParametroBoleto bd = new Tables.ParametroBoleto();

            bd.idParametroBoleto.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.codigoConvenio.value = input.codigoConvenio;
            bd.codigoConvenioDigito.value = input.codigoConvenioDigito;
            bd.codigoCarteira.value = input.codigoCarteira;
            bd.valorTaxa.value = input.valorTaxa;
            bd.variacao.value = input.variacao;
            bd.padraoArquivo.value = input.padraoArquivo;
            bd.tipoCadastramento.value = input.tipoCadastramento;
            bd.tipoDocumento.value = input.tipoDocumento;
            bd.identificadorEmissao.value = input.identificadorEmissao;
            bd.especieTitulo.value = input.especieTitulo;
            bd.instrucaoCodificada1.value = input.instrucaoCodificada1;
            bd.instrucaoCodificada2.value = input.instrucaoCodificada2;
            bd.prazoProtesto.value = input.prazoProtesto;
            bd.codigoDevolucao.value = input.codigoDevolucao;
            bd.prazoDevolucao.value = input.prazoDevolucao;
            bd.tipoJuro.value = input.tipoJuro;
            bd.tipoMulta.value = input.tipoMulta;
            bd.codigoEstacao.value = input.codigoEstacao;
            bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            

            this.m_EntityManager.persist(bd);

            ((Data.ParametroBoleto)parametros["Key"]).idParametroBoleto = (int)bd.idParametroBoleto.value;

            //Processa ParametroBoletoNossoNumero
            if (input.parametroBoletoNossoNumeros != null)
            {
                WS.CRUD.ParametroBoletoNossoNumero parametroBoletoNossoNumeroCRUD = new WS.CRUD.ParametroBoletoNossoNumero(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.parametroBoletoNossoNumeros.Length; i++)
                {
                    input.parametroBoletoNossoNumeros[i].parametroBoleto = new Data.ParametroBoleto();
                    input.parametroBoletoNossoNumeros[i].parametroBoleto.idParametroBoleto = bd.idParametroBoleto.value;
                    _parameters.Add("Key", input.parametroBoletoNossoNumeros[i]);
                    parametroBoletoNossoNumeroCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                parametroBoletoNossoNumeroCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoleto input = (Data.ParametroBoleto)parametros["Key"];
            Tables.ParametroBoleto bd = (Tables.ParametroBoleto)this.m_EntityManager.find
            (
                typeof(Tables.ParametroBoleto),
                new Object[]
                {
                    input.idParametroBoleto
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.codigoConvenio.value = input.codigoConvenio;
            bd.codigoConvenioDigito.value = input.codigoConvenioDigito;
            bd.codigoCarteira.value = input.codigoCarteira;
            bd.valorTaxa.value = input.valorTaxa;
            bd.variacao.value = input.variacao;
            bd.padraoArquivo.value = input.padraoArquivo;
            bd.tipoCadastramento.value = input.tipoCadastramento;
            bd.tipoDocumento.value = input.tipoDocumento;
            bd.identificadorEmissao.value = input.identificadorEmissao;
            bd.especieTitulo.value = input.especieTitulo;
            bd.instrucaoCodificada1.value = input.instrucaoCodificada1;
            bd.instrucaoCodificada2.value = input.instrucaoCodificada2;
            bd.prazoProtesto.value = input.prazoProtesto;
            bd.codigoDevolucao.value = input.codigoDevolucao;
            bd.prazoDevolucao.value = input.prazoDevolucao;
            bd.tipoJuro.value = input.tipoJuro;
            bd.tipoMulta.value = input.tipoMulta;
            bd.codigoEstacao.value = input.codigoEstacao;
            bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;

            this.m_EntityManager.merge(bd);

            //Processa ParametroBoletoNossoNumero
            if (input.parametroBoletoNossoNumeros != null)
            {
                WS.CRUD.ParametroBoletoNossoNumero parametroBoletoNossoNumeroCRUD = new WS.CRUD.ParametroBoletoNossoNumero(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.parametroBoletoNossoNumeros.Length; i++)
                {
                    input.parametroBoletoNossoNumeros[i].parametroBoleto = new Data.ParametroBoleto();
                    input.parametroBoletoNossoNumeros[i].parametroBoleto.idParametroBoleto = bd.idParametroBoleto.value;
                    _parameters.Add("Key", input.parametroBoletoNossoNumeros[i]);
                    if (input.parametroBoletoNossoNumeros[i].operacao == ENum.eOperacao.NONE)
                        input.parametroBoletoNossoNumeros[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    parametroBoletoNossoNumeroCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                parametroBoletoNossoNumeroCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ParametroBoleto bd = new Tables.ParametroBoleto();

            bd.idParametroBoleto.value = ((Data.ParametroBoleto)parametros["Key"]).idParametroBoleto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ParametroBoleto)bd).idParametroBoleto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ParametroBoleto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ParametroBoleto)input).idParametroBoleto = ((Tables.ParametroBoleto)bd).idParametroBoleto.value;
                    ((Data.ParametroBoleto)input).idEmpresa = ((Tables.ParametroBoleto)bd).idEmpresa.value;
                    ((Data.ParametroBoleto)input).descricao = ((Tables.ParametroBoleto)bd).descricao.value;
                    ((Data.ParametroBoleto)input).codigoConvenio = ((Tables.ParametroBoleto)bd).codigoConvenio.value;
                    ((Data.ParametroBoleto)input).codigoConvenioDigito = ((Tables.ParametroBoleto)bd).codigoConvenioDigito.value;
                    ((Data.ParametroBoleto)input).codigoCarteira = ((Tables.ParametroBoleto)bd).codigoCarteira.value;
                    ((Data.ParametroBoleto)input).valorTaxa = ((Tables.ParametroBoleto)bd).valorTaxa.value;
                    ((Data.ParametroBoleto)input).variacao = ((Tables.ParametroBoleto)bd).variacao.value;
                    ((Data.ParametroBoleto)input).padraoArquivo = ((Tables.ParametroBoleto)bd).padraoArquivo.value;
                    ((Data.ParametroBoleto)input).tipoCadastramento = ((Tables.ParametroBoleto)bd).tipoCadastramento.value;
                    ((Data.ParametroBoleto)input).tipoDocumento = ((Tables.ParametroBoleto)bd).tipoDocumento.value;
                    ((Data.ParametroBoleto)input).identificadorEmissao = ((Tables.ParametroBoleto)bd).identificadorEmissao.value;
                    ((Data.ParametroBoleto)input).especieTitulo = ((Tables.ParametroBoleto)bd).especieTitulo.value;
                    ((Data.ParametroBoleto)input).instrucaoCodificada1 = ((Tables.ParametroBoleto)bd).instrucaoCodificada1.value;
                    ((Data.ParametroBoleto)input).instrucaoCodificada2 = ((Tables.ParametroBoleto)bd).instrucaoCodificada2.value;
                    ((Data.ParametroBoleto)input).prazoProtesto = ((Tables.ParametroBoleto)bd).prazoProtesto.value;
                    ((Data.ParametroBoleto)input).codigoDevolucao = ((Tables.ParametroBoleto)bd).codigoDevolucao.value;
                    ((Data.ParametroBoleto)input).prazoDevolucao = ((Tables.ParametroBoleto)bd).prazoDevolucao.value;
                    ((Data.ParametroBoleto)input).tipoJuro = ((Tables.ParametroBoleto)bd).tipoJuro.value;
                    ((Data.ParametroBoleto)input).tipoMulta = ((Tables.ParametroBoleto)bd).tipoMulta.value;
                    ((Data.ParametroBoleto)input).codigoEstacao = ((Tables.ParametroBoleto)bd).codigoEstacao.value;
                    ((Data.ParametroBoleto)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.ParametroBoleto)bd).contaPagamento,
                        level + 1
                    );
                }
                else { }

                if (level < 1)
                {
                    //Preencher ParametroBoletoNossoNumeros
                    if (((Tables.ParametroBoleto)bd).parametroBoletoNossoNumeros != null)
                    {
                        System.Collections.Generic.List<Data.ParametroBoletoNossoNumero> _list = new System.Collections.Generic.List<Data.ParametroBoletoNossoNumero>();

                        foreach (Tables.ParametroBoletoNossoNumero _item in ((Tables.ParametroBoleto)bd).parametroBoletoNossoNumeros)
                        {
                            _list.Add
                            (
                                (Data.ParametroBoletoNossoNumero)
                                (new WS.CRUD.ParametroBoletoNossoNumero(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ParametroBoletoNossoNumero(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ParametroBoleto)input).parametroBoletoNossoNumeros = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ParametroBoleto)input).parametroBoletoNossoNumeros != null)
                        {
                            System.Collections.Generic.List<Data.ParametroBoletoNossoNumero> _list = new System.Collections.Generic.List<Data.ParametroBoletoNossoNumero>();

                            foreach (Data.ParametroBoletoNossoNumero _item in ((Data.ParametroBoleto)input).parametroBoletoNossoNumeros)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ParametroBoleto)input).parametroBoletoNossoNumeros = _list.ToArray();
                            else
                                ((Data.ParametroBoleto)input).parametroBoletoNossoNumeros = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoleto result = (Data.ParametroBoleto)parametros["Key"];

            try
            {
                result = (Data.ParametroBoleto)this.preencher
                (
                    new Data.ParametroBoleto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ParametroBoleto),
                        new Object[]
                        {
                            result.idParametroBoleto
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            bool onlyCount = false;


            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.ParametroBoleto _input = (Data.ParametroBoleto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idParametroBoleto > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoleto.idParametroBoleto = @idParametroBoleto");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoleto", _input.idParametroBoleto));
                    if (!sqlOrderBy.Contains("ParametroBoleto.idParametroBoleto"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoleto.idParametroBoleto");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ParametroBoleto.* ") +
                    "from " +
                    "   ParametroBoleto " +

                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );

                table = null;
            }
            else { }

            return result;
        }
        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoleto input = (Data.ParametroBoleto)parametros["Key"];
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
                    typeof(Tables.ParametroBoleto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ParametroBoleto _data in
                    (System.Collections.Generic.List<Tables.ParametroBoleto>)this.m_EntityManager.list
                    (
                        typeof(Tables.ParametroBoleto),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ParametroBoleto(), _data, level);

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
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
