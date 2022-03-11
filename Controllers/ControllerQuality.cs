using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prova.Controllers
{
    public class ControllerQuality : ControllerBase
    {

        public bool GenerateGrid = true;
        public int maxRowsPerPage = 10;
        public int startRowIndex = 0;

        private Service m_Sr;
        public Service sr
        {
            get
            {
                return m_Sr;
            }
        }

        private string Body { get; set; }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get
            {
                try
                {
                    int localId = 0;
                    StringValues value = String.Empty;
                    Request.Headers.TryGetValue("idEmpresa", out value);
                    if (String.IsNullOrEmpty(value))
                    {
                        localId = this.GetQueryString<int>("idEmpresa");
                        if (localId == 0)
                        {
                            localId = this.GetParam<int>("idEmpresa");
                            if (localId == 0)
                                localId = getIdEmpresa();
                            else { }
                        }
                        else { }
                    }
                    else
                        localId = Convert.ToInt32(value);

                    if (localId > 0 && (m_IdEmpresa == 0 || (m_IdEmpresa > 0 && localId != m_IdEmpresa)))
                        m_IdEmpresa = localId;

                    this.m_Sr = Utils.Utils.sr(m_IdEmpresa);
                    return m_IdEmpresa;
                }
                catch { return 0; }
            }
        }

        private int getIdEmpresa()
        {
            try
            {
                Task<int> task = Task.Run(async () => (await this.GetBody<BaseModel>()).idEmpresa);
                return task.Result;
            }
            catch { return 0; }
        }

        public Data.Usuario GetUserLogged()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    string idUsuario = claims.Where(p => p.Type == ClaimTypes.PrimarySid).FirstOrDefault()?.Value;
                    Data.Usuario usuario = new Data.Usuario
                    {
                        idUsuario = Convert.ToInt32(idUsuario)
                    };
                    usuario = (Data.Usuario)Utils.Utils.sr(this.idEmpresa).consultar(usuario);
                    return usuario;

                }
            }
            return null;
        }

        public Data.Empresa GetCurrentBusiness()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    string idEmpresa = claims.Where(p => p.Type == ClaimTypes.PrimarySid).LastOrDefault()?.Value;
                    Data.Empresa empresa = new Data.Empresa
                    {
                        idEmpresa = Convert.ToInt32(idEmpresa)
                    };
                    empresa = (Data.Empresa)Utils.Utils.sr(this.idEmpresa).consultar(empresa);
                    return empresa;

                }
            }
            return null;
        }

        public async Task<string> GetBody()
        {
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
            }
            return body;
        }

        public async Task<T> GetBody<T>()
        {
            string body = "";

            if (!String.IsNullOrEmpty(Body))
                body = this.Body;
            else
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    body = await reader.ReadToEndAsync();
                }
                this.Body = body;
            }

            try
            {
                T obj = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                if (obj != null)
                    try
                    {

                        var prop = obj.GetType().GetProperty("idEmpresa");
                        if (prop != null)
                        {
                            this.m_IdEmpresa = (int)prop.GetValue(obj, null);
                            if (this.m_IdEmpresa > 0 && (this.m_Sr == null || (this.m_Sr != null && this.m_Sr.getIdEmpresaCorrente() != this.m_IdEmpresa)))
                                this.m_Sr = Utils.Utils.sr(this.m_IdEmpresa);
                            else { }
                        }
                        else { }
                    }
                    catch { }

                return obj;
            }
            catch
            {
                return default(T);
            }
        }

        public T GetQueryString<T>(string key)
        {
            try
            {
                string response = Request.QueryString.Value;
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs[key] != null)
                    return (T)Convert.ChangeType(qs[key].ToString(), typeof(T));
                else
                    return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public string GetQueryString(string key)
        {
            try
            {
                string response = Request.QueryString.Value;
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs[key] != null)
                    return qs[key].ToString();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public T GetParam<T>(string key)
        {
            try
            {
                Microsoft.AspNetCore.Http.HttpRequest hr = HttpContext.Request;
                if (hr.RouteValues[key] != null)
                    return (T)Convert.ChangeType(hr.RouteValues[key].ToString(), typeof(T));
                else
                    return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public string GetParam(string key)
        {
            try
            {
                Microsoft.AspNetCore.Http.HttpRequest hr = HttpContext.Request;
                if (hr.RouteValues[key] != null)
                    return (string)Convert.ChangeType(hr.RouteValues[key].ToString(), typeof(string));
                else
                    return default(string);
            }
            catch
            {
                return default(string);
            }
        }

        public T ParseObj<T>(string body)
        {
            try
            {
                T obj = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                return obj;
            }
            catch (Exception ex)
            {
                return default(T);
            }

        }
    }
}
