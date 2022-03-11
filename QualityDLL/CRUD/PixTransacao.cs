using System;

namespace WS.CRUD
{
    public class PixTransacao : WS.CRUD.Base
    {
        public PixTransacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PixTransacao input = (Data.PixTransacao)parametros["Key"];
            Tables.PixTransacao bd = new Tables.PixTransacao();

            bd.idPixTransacao.isNull = true;
            bd.pix.idPix.value = input.pix.idPix;
            bd.endToEndId.value = input.endToEndId;
            bd.valor.value = input.valor;
            bd.horario.value = input.horario;
            bd.pagadorCpfCnpj.value = input.pagadorCpfCnpj;
            bd.pagadorNome.value = input.pagadorNome;

            this.m_EntityManager.persist(bd);

            ((Data.PixTransacao)parametros["Key"]).idPixTransacao = (int)bd.idPixTransacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PixTransacao input = (Data.PixTransacao)parametros["Key"];
            Tables.PixTransacao bd = (Tables.PixTransacao)this.m_EntityManager.find
            (
                typeof(Tables.PixTransacao),
                new Object[]
                {
                    input.idPixTransacao
                }
            );

            bd.pix.idPix.value = input.pix.idPix;
            bd.endToEndId.value = input.endToEndId;
            bd.valor.value = input.valor;
            bd.horario.value = input.horario;
            bd.pagadorCpfCnpj.value = input.pagadorCpfCnpj;
            bd.pagadorNome.value = input.pagadorNome;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PixTransacao bd = new Tables.PixTransacao();

            bd.idPixTransacao.value = ((Data.PixTransacao)parametros["Key"]).idPixTransacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PixTransacao)bd).idPixTransacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PixTransacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PixTransacao)input).idPixTransacao = ((Tables.PixTransacao)bd).idPixTransacao.value;
                    ((Data.PixTransacao)input).endToEndId = ((Tables.PixTransacao)bd).endToEndId.value;
                    ((Data.PixTransacao)input).valor = ((Tables.PixTransacao)bd).valor.value;
                    ((Data.PixTransacao)input).horario = ((Tables.PixTransacao)bd).horario.value;
                    ((Data.PixTransacao)input).pagadorNome = ((Tables.PixTransacao)bd).pagadorNome.value;
                    ((Data.PixTransacao)input).pagadorCpfCnpj = ((Tables.PixTransacao)bd).pagadorCpfCnpj.value;

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PixTransacao result = (Data.PixTransacao)parametros["Key"];

            try
            {
                result = (Data.PixTransacao)this.preencher
                (
                    new Data.PixTransacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PixTransacao),
                        new Object[]
                        {
                            result.idPixTransacao
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

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

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
            }
            else { }

            Data.PixTransacao _input = (Data.PixTransacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPixTransacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PixTransacao.idPixTransacao = @idPixTransacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPixTransacao", _input.idPixTransacao));
                    if (!sqlOrderBy.Contains("PixTransacao.idPixTransacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PixTransacao.idPixTransacao");
                    else { }
                }
                else { }

                if (_input.pix != null)
                {

                    if (_input.pix.idPix > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pix.idPix = @idPix");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPix", _input.pix.idPix));
                        if (!sqlOrderBy.Contains("pix.idPix"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pix.idPix");
                        else { }
                    }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   PixTransacao.* " +
                    "from " +
                    (
                        "   PixTransacao PixTransacao " +
                        "       inner join pix pix " +
                        "           on	pix.idPix = PixTransacao.idPix "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PixTransacao input = (Data.PixTransacao)parametros["Key"];
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
                    typeof(Tables.PixTransacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PixTransacao _data in
                    (System.Collections.Generic.List<Tables.PixTransacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.PixTransacao),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.PixTransacao(), _data, level);

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
