using System;
using NFe.Danfe.Html.CrossCutting;
using NFe.Danfe.Html.Dominio;
using NFe.Danfe.Html.Interfaces;

namespace NFe.Danfe.Html.New
{
    public class DanfeViewHTML
    {
        public string ObterDanfeNfe(string xmlString)
        {
            try
            {

                var nfe = CrossCutting.Utils.XmlStringParaClasse<Classes.NFe>(xmlString);

                if (nfe == null)
                {
                    throw new Exception("Falha ao transformar o XML em um objeto da Nfe");
                }

                // Gerando o DANFE HTML a partir da instância da NFe
                var danfe = new DanfeNFe(nfe, Status.Autorizada, "", "");

                IDanfeHtml2 d1 = new DanfeNfeHtml2(danfe);
                var doc = d1.ObterDocHtmlAsync().Result;

                return doc.Html;

            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
