using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Utils
{

    public static class Socio
    {

        public static string getFotoSocio(int idTituloSocio)
        {

            string
                foto = "";
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/fotosSocio/" + idTituloSocio + ".jpg")))
                foto = "~/data/dist/img/emptyProfile.jpg";
            else
                foto = "~/fotosSocio/" + idTituloSocio + ".jpg";

            return foto;


        }
        public static string getDiretorioFotosSocio()
        {

            string
                defaultPath = "C:\\QUALITY\\FotosGestao\\",
                diretorioReal = Update.getConfiguracoesGlobais("pastaFotos");

            if (String.IsNullOrEmpty(diretorioReal))
                diretorioReal = defaultPath;
            else { }

            if (!Directory.Exists(diretorioReal))

                try
                {
                    Directory.CreateDirectory(diretorioReal);
                }
                catch (Exception e)
                {
                    throw e;
                }

            else { }
            return diretorioReal + (!diretorioReal.EndsWith("\\") ? "\\" : null);
        }


    }

}
