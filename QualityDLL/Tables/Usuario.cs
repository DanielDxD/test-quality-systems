using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("Usuario")]
    public class Usuario : TTableBase
    {
        [TColumn("idUsuario", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idUsuario = new TFieldInteger();
        public TFieldInteger idUsuario
        {
            get { return this.m_idUsuario; }
        }

        [TColumn("usuario", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_usuario = new TFieldString();
        public TFieldString usuario
        {
            get { return this.m_usuario; }
        }

        [TColumn("senhaDinamica", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_senhaDinamica = new TFieldBoolean();
        public TFieldBoolean senhaDinamica
        {
            get { return this.m_senhaDinamica; }
        }

        [TColumn("senha", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_senha = new TFieldString();
        public TFieldString senha
        {
            get { return this.m_senha; }
        }

        [TColumn("ativo", System.Data.SqlDbType.Bit, false, false)]
        private TFieldBoolean m_ativo = new TFieldBoolean();
        public TFieldBoolean ativo
        {
            get { return this.m_ativo; }
        }

        [TColumn("nomeCSS", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_nomeCSS = new TFieldString();
        public TFieldString nomeCSS
        {
            get { return this.m_nomeCSS; }
        }

        [TColumn("assinatura", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_assinatura = new TFieldString();
        public TFieldString assinatura
        {
            get { return this.m_assinatura; }
        }

        [
            TColumn("idPessoa", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idPessoa->idPessoaFisica" })
        ]
        private PessoaFisica m_idPessoa = null;
        public PessoaFisica pessoa
        {
            get
            {
                if (this.m_idPessoa == null)
                {
                    this.m_idPessoa = new PessoaFisica();

                    foreach (TJoin attribute in this.m_idPessoa.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idPessoa.connectionString = this.connectionString;
                            this.m_idPessoa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idPessoa.selfFill();

                return this.m_idPessoa;
            }
        }

        [
            TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idFuncionario->idFuncionario" })
        ]
        private Funcionario m_idFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_idFuncionario == null)
                {
                    this.m_idFuncionario = new Funcionario();

                    foreach (TJoin attribute in this.m_idFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

                        bool existNullKey = false;

                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }

                        if (!existNullKey)
                        {
                            this.m_idFuncionario.connectionString = this.connectionString;
                            this.m_idFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idFuncionario.selfFill();

                return this.m_idFuncionario;
            }
        }
        [
            TList(typeof(UsuarioEmpresa)),
            TJoin(new String[] { "idUsuario->idUsuario" })
        ]
        private Object m_UsuarioEmpresas = null;
        public System.Collections.Generic.List<UsuarioEmpresa> usuarioEmpresas
        {
            get
            {
                if (this.m_UsuarioEmpresas != null)
                {
                    if
                    (
                        !typeof(System.Collections.Generic.List<>).MakeGenericType
                        (
                            new Type[] { typeof(UsuarioEmpresa) }
                        ).IsInstanceOfType(this.m_UsuarioEmpresas)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_UsuarioEmpresas)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_UsuarioEmpresas).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_UsuarioEmpresas).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_UsuarioEmpresas)[i]);

                        this.m_UsuarioEmpresas = em.list(typeof(UsuarioEmpresa), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<UsuarioEmpresa>)this.m_UsuarioEmpresas;
            }
        }
    }
}
