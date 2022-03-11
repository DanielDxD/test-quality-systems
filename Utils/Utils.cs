using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.UtilsGestao
{
    public class UtilsApi
    {

        public static string Retorno(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Culture = new System.Globalization.CultureInfo("pt-BR") };
            string Serialized = JsonConvert.SerializeObject(obj, settings);
            var retorno = JsonConvert.DeserializeObject(Serialized, settings);
            return JsonConvert.SerializeObject(retorno);
        }

        public static object CatchError(Exception ex)
        {
            var obj = new
            {
                status = "error",
                message = String.Format("Houve um erro. {0}", ex.Message)
            };

            return obj;
        }

        public static object CatchPermissionDeniedError(Exception ex)
        {
            var obj = new
            {
                status = "error",
                message = "Seu usuário não possui permissão para esta função do sistema!"
            };
            return obj;
        }

        public static T Unserialize<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj, new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("pt-BR")  //Replace tr-TR by your own culture
            });
        }


        public static string Print(string endpoint, object parameters, string method = "POST")
        {
            try
            {
                int porta = 1567;
                if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"config.qlt"))
                {
                    string encoded = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"config.qlt");
                    string decoded = Utils.Security.DecryptRijndael(Utils.Security.Base64Decode(encoded), Utils.Security.getInputKey());
                    
                    try
                    {
                        porta = Utils.Utils.ToInt(decoded.Split(';')[4]);
                    }
                    catch
                    {
                        porta = 1567;
                    }
                }
                else { }
                porta += 1;
                string url = String.Format("http://localhost:{0}/{1}", porta, endpoint);
                string response = Utils.Update.sendRequest(url, JsonConvert.SerializeObject(parameters), method, null, 20000, "application/json", true);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
    }
}
