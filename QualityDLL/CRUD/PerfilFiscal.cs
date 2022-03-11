using System;

namespace WS.CRUD
{
    public class PerfilFiscal : WS.CRUD.Base
    {
        public PerfilFiscal(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PerfilFiscal input = (Data.PerfilFiscal)parametros["Key"];
            Tables.PerfilFiscal bd = new Tables.PerfilFiscal();

            bd.idPerfilFiscal.isNull = true;
            bd.descricao.value = input.descricao;
            bd.sequencia.value = input.sequencia;
            bd.idEmpresa.value = input.idEmpresa;

            if (input.cfop != null && input.cfop.idCfop > 0)
                bd.cfop.idCfop.value = input.cfop.idCfop;
            else
                bd.cfop.idCfop.isNull = true;

            if (input.cstIcms != null && input.cstIcms.idcstIcms > 0)
                bd.cstIcms.idcstIcms.value = input.cstIcms.idcstIcms;
            else
                bd.cstIcms.idcstIcms.isNull = true;

            if (input.cstPis != null && input.cstPis.idcstpis > 0)
                bd.cstPis.idcstpis.value = input.cstPis.idcstpis;
            else
                bd.cstPis.idcstpis.isNull = true;

            if (input.cstCofins != null && input.cstCofins.idcstCofins > 0)
                bd.cstCofins.idcstCofins.value = input.cstCofins.idcstCofins;
            else
                bd.cstCofins.idcstCofins.isNull = true;

            if (input.cstIpi != null && input.cstIpi.idcstipi > 0)
                bd.cstIpi.idcstipi.value = input.cstIpi.idcstipi;
            else
                bd.cstIpi.idcstipi.isNull = true;

            bd.tipo.value = input.tipo;
            bd.icms.value = input.icms == "s" ? true : false;
            bd.icmsSt.value = input.icmsSt == "s" ? true : false;
            bd.ipi.value = input.ipi == "s" ? true : false;
            bd.icmsSIpi.value = input.icmsSIpi == "s" ? true : false;
            bd.redBcIcms.value = input.redBcIcms == "s" ? true : false;
            bd.redBCIcmsSt.value = input.redBCIcmsSt == "s" ? true : false;
            bd.icmsDiferido.value = input.icmsDiferido == "s" ? true : false;
            bd.fcpIcms.value = input.fcpIcms == "s" ? true : false;
            bd.fcpIcmsSt.value = input.fcpIcmsSt == "s" ? true : false;
            bd.aplicarAliquotaIcms.value = input.aplicarAliquotaIcms == "s" ? true : false;
            bd.aplicarAliquotaIcmsSt.value = input.aplicarAliquotaIcmsSt == "s" ? true : false;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.aliquotaIcmsSt.value = input.aliquotaIcmsSt;

            this.m_EntityManager.persist(bd);

            ((Data.PerfilFiscal)parametros["Key"]).idPerfilFiscal = (int)bd.idPerfilFiscal.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PerfilFiscal input = (Data.PerfilFiscal)parametros["Key"];
            Tables.PerfilFiscal bd = (Tables.PerfilFiscal)this.m_EntityManager.find
            (
                typeof(Tables.PerfilFiscal),
                new Object[]
                {
                    input.idPerfilFiscal
                }
            );

            bd.descricao.value = input.descricao;
            bd.sequencia.value = input.sequencia;
            bd.idEmpresa.value = input.idEmpresa;

            if (input.cfop != null && input.cfop.idCfop > 0)
                bd.cfop.idCfop.value = input.cfop.idCfop;
            else
                bd.cfop.idCfop.isNull = true;

            if (input.cstIcms != null && input.cstIcms.idcstIcms > 0)
                bd.cstIcms.idcstIcms.value = input.cstIcms.idcstIcms;
            else
                bd.cstIcms.idcstIcms.isNull = true;

            if (input.cstPis != null && input.cstPis.idcstpis > 0)
                bd.cstPis.idcstpis.value = input.cstPis.idcstpis;
            else
                bd.cstPis.idcstpis.isNull = true;

            if (input.cstCofins != null && input.cstCofins.idcstCofins > 0)
                bd.cstCofins.idcstCofins.value = input.cstCofins.idcstCofins;
            else
                bd.cstCofins.idcstCofins.isNull = true;

            if (input.cstIpi != null && input.cstIpi.idcstipi > 0)
                bd.cstIpi.idcstipi.value = input.cstIpi.idcstipi;
            else
                bd.cstIpi.idcstipi.isNull = true;

            bd.tipo.value = input.tipo;
            bd.icms.value = input.icms == "s" ? true : false;
            bd.icmsSt.value = input.icmsSt == "s" ? true : false;
            bd.ipi.value = input.ipi == "s" ? true : false;
            bd.icmsSIpi.value = input.icmsSIpi == "s" ? true : false;
            bd.redBcIcms.value = input.redBcIcms == "s" ? true : false;
            bd.redBCIcmsSt.value = input.redBCIcmsSt == "s" ? true : false;
            bd.icmsDiferido.value = input.icmsDiferido == "s" ? true : false;
            bd.fcpIcms.value = input.fcpIcms == "s" ? true : false;
            bd.fcpIcmsSt.value = input.fcpIcmsSt == "s" ? true : false;
            bd.aplicarAliquotaIcms.value = input.aplicarAliquotaIcms == "s" ? true : false;
            bd.aplicarAliquotaIcmsSt.value = input.aplicarAliquotaIcmsSt == "s" ? true : false;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.aliquotaIcmsSt.value = input.aliquotaIcmsSt;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PerfilFiscal bd = new Tables.PerfilFiscal();

            bd.idPerfilFiscal.value = ((Data.PerfilFiscal)parametros["Key"]).idPerfilFiscal;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PerfilFiscal)bd).idPerfilFiscal.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PerfilFiscal)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PerfilFiscal)input).idPerfilFiscal = ((Tables.PerfilFiscal)bd).idPerfilFiscal.value;
                    ((Data.PerfilFiscal)input).descricao = ((Tables.PerfilFiscal)bd).descricao.value;
                    ((Data.PerfilFiscal)input).sequencia = ((Tables.PerfilFiscal)bd).sequencia.value;
                    ((Data.PerfilFiscal)input).idEmpresa = ((Tables.PerfilFiscal)bd).idEmpresa.value;

                    ((Data.PerfilFiscal)input).cfop = (Data.CfOp)(new WS.CRUD.CfOp(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CfOp(),
                        ((Tables.PerfilFiscal)bd).cfop,
                        level + 1
                    );

                    ((Data.PerfilFiscal)input).cstIcms = (Data.CstIcms)(new WS.CRUD.CstIcms(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CstIcms(),
                        ((Tables.PerfilFiscal)bd).cstIcms,
                        level + 1
                    );

                    ((Data.PerfilFiscal)input).cstPis = (Data.CstPis)(new WS.CRUD.CstPis(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CstPis(),
                        ((Tables.PerfilFiscal)bd).cstPis,
                        level + 1
                    );

                    ((Data.PerfilFiscal)input).cstCofins = (Data.CstCofins)(new WS.CRUD.CstCofins(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CstCofins(),
                        ((Tables.PerfilFiscal)bd).cstCofins,
                        level + 1
                    );

                    ((Data.PerfilFiscal)input).cstIpi = (Data.CstIpi)(new WS.CRUD.CstIpi(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CstIpi(),
                        ((Tables.PerfilFiscal)bd).cstIpi,
                        level + 1
                    );

                    ((Data.PerfilFiscal)input).tipo = ((Tables.PerfilFiscal)bd).tipo.value;
                    ((Data.PerfilFiscal)input).icms = ((Tables.PerfilFiscal)bd).icms.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).icmsSt = ((Tables.PerfilFiscal)bd).icmsSt.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).ipi = ((Tables.PerfilFiscal)bd).ipi.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).icmsSIpi = ((Tables.PerfilFiscal)bd).icmsSIpi.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).redBcIcms = ((Tables.PerfilFiscal)bd).redBcIcms.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).redBCIcmsSt = ((Tables.PerfilFiscal)bd).redBCIcmsSt.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).icmsDiferido = ((Tables.PerfilFiscal)bd).icmsDiferido.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).fcpIcms = ((Tables.PerfilFiscal)bd).fcpIcms.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).fcpIcmsSt = ((Tables.PerfilFiscal)bd).fcpIcmsSt.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).aplicarAliquotaIcms = ((Tables.PerfilFiscal)bd).aplicarAliquotaIcms.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).aplicarAliquotaIcmsSt = ((Tables.PerfilFiscal)bd).aplicarAliquotaIcmsSt.value ? "s" : "n";
                    ((Data.PerfilFiscal)input).aliquotaIcms = ((Tables.PerfilFiscal)bd).aliquotaIcms.value;
                    ((Data.PerfilFiscal)input).aliquotaIcmsSt = ((Tables.PerfilFiscal)bd).aliquotaIcmsSt.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PerfilFiscal result = (Data.PerfilFiscal)parametros["Key"];

            try
            {
                result = (Data.PerfilFiscal)this.preencher
                (
                    new Data.PerfilFiscal(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PerfilFiscal),
                        new Object[]
                        {
                            result.idPerfilFiscal
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

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
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

            Data.PerfilFiscal _input = (Data.PerfilFiscal)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idPerfilFiscal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PerfilFiscal.idPerfilFiscal = @idPerfilFiscal");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPerfilFiscal", _input.idPerfilFiscal));
                    if (!sqlOrderBy.Contains("PerfilFiscal.idPerfilFiscal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PerfilFiscal.idPerfilFiscal");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PerfilFiscal.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("PerfilFiscal.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PerfilFiscal.idEmpresa");
                    else { }
                }
                else { }                

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PerfilFiscal.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("PerfilFiscal.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PerfilFiscal.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PerfilFiscal.* ") +
                    "from " +
                    (
                        "   PerfilFiscal PerfilFiscal \n" +
                        "   INNER JOIN empresa \n" +
                        "       ON empresa.idEmpresa = PerfilFiscal.idEmpresa \n"
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
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
            Data.PerfilFiscal input = (Data.PerfilFiscal)parametros["Key"];
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
                    typeof(Tables.PerfilFiscal),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PerfilFiscal _data in
                    (System.Collections.Generic.List<Tables.PerfilFiscal>)this.m_EntityManager.list
                    (
                        typeof(Tables.PerfilFiscal),
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
                    _base = (Data.Base)this.preencher(new Data.PerfilFiscal(), _data, level);

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
