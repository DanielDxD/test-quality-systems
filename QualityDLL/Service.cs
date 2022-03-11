using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;
using EJB.EntityManager;

public class Service
{
    private String connectionString = null;
    private long? idEmpresaCorrente = null;

    public Service(long? idEmpresa, String connectionString)
    {
        this.idEmpresaCorrente = idEmpresa;
        this.connectionString = connectionString;
    }

    public void setIdEmpresaCorrente(long? idEmpresa)
    {
        this.idEmpresaCorrente = idEmpresa;
    }
    public long getIdEmpresaCorrente()
    {
        return (long)this.idEmpresaCorrente;
    }

    #region ValidarUsuario
    public Data.Usuario validarUsuario
    (
        String usuario,
        String resposta,
        String key,
        EntityManager em = null
    )
    {
        Data.Usuario result = new Data.Usuario();

        try
        {
            //
            // Recuperando dados do Usuario
            //
            System.Collections.Hashtable parametros = new System.Collections.Hashtable();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Utils.Utils.getSqlConfigs());
            result.nomeUsuario = usuario;
            result.ativo = true;

            //String
            //        s1 = (new Utils.Base64()).encode((new Utils.MD5()).digest("cristina")),
            //        s2 = (new Utils.Base64()).encode((new Utils.MD5()).digest("hlc")),
            //        s3 = (new Utils.Base64()).encode((new Utils.MD5()).digest("12345678"));
            parametros.Add("Key", result);
            if (em == null)
                em = new EJB.EntityManager.EntityManager(this.connectionString);

            result = (Data.Usuario)(new WS.CRUD.Usuario(null, em)).consultar(parametros);

            if ((result != null) && result.ativo)
            {
                if (builder["Initial Catalog"].ToString().ToLower() != "qualityclientes")
                {
                    if (result.nomeUsuario == "quality")
                        result.senha = (new Utils.Base64()).encode((new Utils.MD5()).digest(Utils.Utils.gerarSenhaQualitySuporte().ToLower()));
                    else { }
                }
                if
                (
                    !(
                        (
                            key == (new Utils.Base64()).encode
                            (
                                (new Utils.RC6()).decrypt
                                (
                                    (new Utils.Base64()).decode
                                    (
                                        result.senha
                                    ),
                                    (new Utils.Base64()).decode
                                    (
                                        resposta
                                    )
                                )
                            )
                        )
                    )
                )
                {
                    result = null;
                    Utils.Utils.WriteLog("validarUsuario: " + usuario + " nao Autenticado(senha inválida)...");
                }
                else
                {
                    if (result.nomeUsuario == "quality")
                    {
                        bool achou = false;
                        for (int i = 0; i < result.perfils.Length; i++)
                        {
                            if (result.perfils[i].administrador)
                            {
                                achou = true;
                                break;
                            }
                        }

                        if (!achou)
                        {
                            if (result.perfils.Length > 0)
                            {
                                result.perfils[0].administrador = true;
                                result.perfils[0].descricao = "Administrador";
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
            }
            else
            {
                result = null;
                Utils.Utils.WriteLog("validarUsuario: " + usuario + " nao Autenticado(usuário inativo ou inexistente)...");
            }
        }
        catch (Exception e)
        {
            Utils.Utils.WriteLog(this.GetType().ToString() + ".validarUsuario " + usuario + " nao Autenticado -> " + e.ToString());
            result = null;
        }

        return result;
    }
    #endregion

    #region consultar
    public Data.Base consultar
    (
        Data.Base chave,
        EntityManager em = null
    )
    {
        Data.Base result = null;

        try
        {
            Object consultar = null;

            foreach (System.Type _class in System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                if (_class.FullName == "WS.CRUD." + chave.GetType().Name)
                {
                    consultar = _class.GetConstructor(new System.Type[] { typeof(long), typeof(EJB.EntityManager.EntityManager) }).Invoke(new Object[] { this.idEmpresaCorrente, null });
                    break;
                }
                else { }
            }

            if (consultar != null)
            {
                if (em == null)
                    em = new EJB.EntityManager.EntityManager(this.connectionString);

                ((WS.CRUD.Interface.CRUD)consultar).bancoDeDados(em);

                System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                parametros.Add("Key", chave);

                result = (Data.Base)((WS.CRUD.Interface.CRUD)consultar).consultar(parametros);
            }
            else { }
        }
        catch (Exception e)
        {
            Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
        }

        return result;
    }
    #endregion

    #region atualizar
    public Data.Base atualizar
    (
        Data.Base chave,
        bool commit = true,
        EntityManager em = null
    )
    {
        Data.Base result = null;

        try
        {
            Object atualizar = null;

            foreach (System.Type _class in System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                if (_class.FullName == "WS.CRUD." + chave.GetType().Name)
                {
                    atualizar = _class.GetConstructor(new System.Type[] { typeof(long), typeof(EJB.EntityManager.EntityManager) }).Invoke(new Object[] { this.idEmpresaCorrente, null });
                    break;
                }
                else { }
            }

            if (atualizar != null)
            {
                if (em == null)
                    em = new EJB.EntityManager.EntityManager(this.connectionString);

                try
                {
                    System.Collections.Hashtable parametros = new System.Collections.Hashtable();
                    parametros.Add("Key", chave);

                    if (commit)
                        em.beginTransaction();
                    ((WS.CRUD.Interface.CRUD)atualizar).bancoDeDados(em);
                    result = (Data.Base)((WS.CRUD.Interface.CRUD)atualizar).atualizar(parametros);
                    if (commit)
                        em.commitTransaction();

                    /*
                    bool
                        isTerminalPdv = false;
                    try
                    {
                        if (!Utils.Utils.IsWebServer())
                            throw new Exception();
                        isTerminalPdv = false;
                    }
                    catch
                    {
                        isTerminalPdv = true;
                    }*/

                    try
                    {

                        if (Utils.Utils.IsWebServer())
                        {
                            /* Rotina de LOG */
                            Type type = Utils.Utils.QualityDLL.GetType("Tables." + chave.GetType().Name);
                            Object obj = Activator.CreateInstance(type);
                            MethodInfo methodInfo = type.GetMethod("columns");
                            var colunas = methodInfo.Invoke(obj, new Object[] { true });

                            if (colunas != null)
                            {
                                EJB.Attributes.TColumn[] cl = (EJB.Attributes.TColumn[])colunas;
                                string primaryKey = String.Empty;
                                string valuePrimaryKey = String.Empty;
                                foreach (EJB.Attributes.TColumn c in cl)
                                    if (c.primaryKey)
                                        primaryKey = c.name;

                                if (!String.IsNullOrEmpty(primaryKey))
                                    if (chave.GetType().GetProperty(primaryKey) != null)
                                        valuePrimaryKey = chave.GetType().GetProperty(primaryKey).GetValue(chave, null).ToString();
                                    else
                                    {
                                        return result;
                                    }
                                else { }
                                string operacaoString, operacao, msg, complemento = String.Empty;
                                switch (chave.operacao)
                                {
                                    case ENum.eOperacao.ALTERAR:
                                        operacaoString = "alterou";
                                        operacao = "alterar";
                                        msg = "O Usuário " + operacaoString + " o " + chave.GetType().Name + ", " + primaryKey + ": " + valuePrimaryKey;
                                        break;
                                    case ENum.eOperacao.EXCLUIR:
                                        operacaoString = "removeu";
                                        operacao = "remover";
                                        msg = "O Usuário " + operacaoString + " o " + chave.GetType().Name + ", " + primaryKey + ": " + valuePrimaryKey;
                                        complemento = Utils.Utils.serializeClass(chave);
                                        break;
                                    case ENum.eOperacao.INCLUIR:
                                        operacaoString = "cadastrou";
                                        operacao = "cadastrar";
                                        msg = "O Usuário " + operacaoString + " um novo " + chave.GetType().Name + ", " + primaryKey + ": " + valuePrimaryKey;
                                        break;
                                    default:
                                        operacaoString = "removeu";
                                        operacao = "remover";
                                        msg = "O Usuário " + operacaoString + " o " + chave.GetType().Name + ", " + primaryKey + ": " + valuePrimaryKey;
                                        complemento = Utils.Utils.serializeClass(chave);
                                        break;
                                }

                                Utils.Utils.registerLog(operacao, msg, chave.GetType().Name, Utils.Utils.ToInt(valuePrimaryKey), complemento);
                            }
                            else { }
                        }
                    }
                    catch { }
                }
                catch (Exception eAtualizar)
                {
                    result = null;
                    em.rollbackTransaction();
                    throw eAtualizar;
                }
            }
            else { }
        }
        catch (Exception e)
        {
            Utils.Utils.WriteLog(this.GetType().ToString() + ".atualizar() -> " + e.ToString());

            if (e is Utils.BusinessRuleException)
                throw e;
            else { }
        }

        return result;
    }
    #endregion

    #region listar
    public Data.Base[] listar
    (
        Utils.NameValue[] parametros,
        EntityManager em = null
    )
    {
        Data.Base[] result = null;

        try
        {
            Object listar = null;
            Data.Base _key = null;

            foreach (Utils.NameValue nameValue in parametros)
            {
                if (nameValue.name == "Key")
                {
                    _key = (Data.Base)nameValue.value;
                    break;
                }
                else { }
            }

            foreach (System.Type _class in System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                if (_class.FullName == "WS.CRUD." + _key.GetType().Name)
                {
                    listar = _class.GetConstructor(new System.Type[] { typeof(long), typeof(EJB.EntityManager.EntityManager) }).Invoke(new Object[] { this.idEmpresaCorrente, null });
                    break;
                }
                else { }
            }

            if (listar != null)
            {
                if (em == null)
                    em = new EJB.EntityManager.EntityManager(this.connectionString);
                ((WS.CRUD.Interface.CRUD)listar).bancoDeDados(em);

                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                foreach (Utils.NameValue nameValue in parametros)
                    _parametros.Add(nameValue.name, nameValue.value);

                result = (Data.Base[])((WS.CRUD.Interface.CRUD)listar).listar(_parametros);
            }
            else { }
        }
        catch (Exception e)
        {
            Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
        }

        return result;
    }
    #endregion


    #region getCount
    public int getCount
    (
        Data.Base countBase,
        Utils.NameValue[] parametros,
        EntityManager em = null
    )
    {
        int result = 0;

        System.Data.SqlClient.SqlConnection _connection = null;

        try
        {
            Object count = null;
            Data.Base _key = null;

            foreach (Utils.NameValue nameValue in parametros)
            {
                if (nameValue.name == "Key")
                {
                    _key = (Data.Base)nameValue.value;
                    break;
                }
                else { }
            }

            System.Type[] _classes = System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes();

            count = _classes.FirstOrDefault(t => t.FullName == "WS.CRUD." + _key.GetType().Name).GetConstructor(new System.Type[] { typeof(long), typeof(EJB.EntityManager.EntityManager) }).Invoke(new Object[] { this.idEmpresaCorrente, null });

            if (count != null)
            {
                if (em == null)
                    em = new EJB.EntityManager.EntityManager(this.connectionString);
                ((WS.CRUD.Interface.CRUD)count).bancoDeDados(em);

                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();

                foreach (Utils.NameValue nameValue in parametros)
                    _parametros.Add(nameValue.name, nameValue.value);

                result = (int)((WS.CRUD.Interface.CRUD)count).contar(_parametros);
            }
            else { }
        }
        catch (Exception e)
        {
            Utils.Utils.WriteLog(this.GetType().ToString() + ".getCount() -> " + e.ToString());
        }
        finally
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            else { }

            _connection = null;
        }

        return result;
    }
    #endregion
}