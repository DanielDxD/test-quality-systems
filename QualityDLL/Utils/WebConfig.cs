using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Utils
{
    public static class WebConfig
    {

        public static void fixWebConfig()
        {

        }

        public static void fixRelatoriosContasAPagar()
        {

            bool hasChanges = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/Web.config"));
            XmlNodeList nodes = doc.SelectNodes("/configuration/FieldAttributes");

            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].ChildNodes.Count; j++)
                {
                    if (nodes[i].ChildNodes[j].Name.Contains("ContasAPagar"))
                    {
                        XmlNode _nd = nodes[i].ChildNodes[j];
                        for (int k = 0; k < nodes[i].ChildNodes[j].ChildNodes.Count; k++)
                        {
                            if (nodes[i].ChildNodes[j].ChildNodes[k].Name.Contains("Fornecedor"))
                            {
                                for (int z = 0; z < nodes[i].ChildNodes[j].ChildNodes[k].Attributes.Count; z++)
                                {
                                    if (nodes[i].ChildNodes[j].ChildNodes[k].Attributes[z].Name == "label")
                                    {
                                        string value = nodes[i].ChildNodes[j].ChildNodes[k].Attributes[z].Value;
                                        if (value.Contains("Apelido/Nome Comercial") && value.Contains("Fornecedor"))
                                            nodes[i].ChildNodes[j].ChildNodes[k].Attributes[z].Value = "Apelido/Nome Comercial:m_IdEmpresaRelacionamento.m_IdPessoa.m_ApelidoNomeComercial";
                                        else if (value.Contains("Razão Social") && value.Contains("Fornecedor"))
                                            nodes[i].ChildNodes[j].ChildNodes[k].Attributes[z].Value = "Nome/Razão Social:m_IdEmpresaRelacionamento.m_IdPessoa.m_NomeRazaoSocial";
                                        else { }

                                        hasChanges = true;
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    else { }
                }
            }

            XmlNodeList stuffNodeList = doc.SelectNodes("//*[starts-with(name(), 'ContasAPagar')]");
            foreach (XmlNode stuffNode in stuffNodeList)
            {
                XmlNode contentNode = stuffNode.SelectSingleNode("m_IdFornecedor");
                if (contentNode != null)
                {
                    XmlNode newNode = doc.CreateElement("m_IdEmpresaRelacionamento");
                    for (int i = 0; i < contentNode.Attributes.Count; i++)
                        newNode.Attributes.Append(contentNode.Attributes[i]);

                    stuffNode.InsertBefore(newNode, contentNode);
                    stuffNode.RemoveChild(contentNode);
                    hasChanges = true;
                }
            }
            if (hasChanges)
                doc.Save(HttpContext.Current.Server.MapPath("~/Web.config"));
            else { }
        }

    }
}