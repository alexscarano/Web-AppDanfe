using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;
using NFe.Danfe.Html.New;
using NFe.Danfe.Html.New.Services;

namespace WebApp.NFe.Html.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DanfeController : ControllerBase
    {
        private readonly IDanfeService _danfeService; //Consulta o xml no banco de dados
        private readonly DanfeViewHTML _danfeViewHTML; // Gera o html com base no xml

        // Construtor para injeção de dependência
        public DanfeController(IDanfeService danfeService, DanfeViewHTML danfeViewHTML)
        {
            _danfeService = danfeService;
            _danfeViewHTML = danfeViewHTML;
        }

        private string RetirarCaracteresEspeciaisXml(string aTexto)
        {
            string lTextoResp = "";

            for (int i = 0; i < aTexto.Length; i++)
            {
                // Mapeando os caracteres especiais para seus substitutos
                if (aTexto[i].ToString() == "ã") lTextoResp += "a";
                else if (aTexto[i].ToString() == "á") lTextoResp += "a";
                else if (aTexto[i].ToString() == "à") lTextoResp += "a";
                else if (aTexto[i].ToString() == "â") lTextoResp += "a";
                else if (aTexto[i].ToString() == "ä") lTextoResp += "a";
                else if (aTexto[i].ToString() == "é") lTextoResp += "e";
                else if (aTexto[i].ToString() == "è") lTextoResp += "e";
                else if (aTexto[i].ToString() == "ê") lTextoResp += "e";
                else if (aTexto[i].ToString() == "ë") lTextoResp += "e";
                else if (aTexto[i].ToString() == "í") lTextoResp += "i";
                else if (aTexto[i].ToString() == "ì") lTextoResp += "i";
                else if (aTexto[i].ToString() == "ï") lTextoResp += "i";
                else if (aTexto[i].ToString() == "î") lTextoResp += "i";
                else if (aTexto[i].ToString() == "õ") lTextoResp += "o";
                else if (aTexto[i].ToString() == "ó") lTextoResp += "o";
                else if (aTexto[i].ToString() == "ò") lTextoResp += "o";
                else if (aTexto[i].ToString() == "ö") lTextoResp += "o";
                else if (aTexto[i].ToString() == "ô") lTextoResp += "o";
                else if (aTexto[i].ToString() == "ú") lTextoResp += "u";
                else if (aTexto[i].ToString() == "ù") lTextoResp += "u";
                else if (aTexto[i].ToString() == "ü") lTextoResp += "u";
                else if (aTexto[i].ToString() == "û") lTextoResp += "u";
                else if (aTexto[i].ToString() == "ç") lTextoResp += "c";
                else if (aTexto[i].ToString() == "Ã") lTextoResp += "A";
                else if (aTexto[i].ToString() == "Á") lTextoResp += "A";
                else if (aTexto[i].ToString() == "À") lTextoResp += "A";
                else if (aTexto[i].ToString() == "Â") lTextoResp += "A";
                else if (aTexto[i].ToString() == "Ä") lTextoResp += "A";
                else if (aTexto[i].ToString() == "É") lTextoResp += "E";
                else if (aTexto[i].ToString() == "È") lTextoResp += "E";
                else if (aTexto[i].ToString() == "Ê") lTextoResp += "E";
                else if (aTexto[i].ToString() == "Ë") lTextoResp += "E";
                else if (aTexto[i].ToString() == "Í") lTextoResp += "I";
                else if (aTexto[i].ToString() == "Ì") lTextoResp += "I";
                else if (aTexto[i].ToString() == "Ï") lTextoResp += "I";
                else if (aTexto[i].ToString() == "Î") lTextoResp += "I";
                else if (aTexto[i].ToString() == "Õ") lTextoResp += "O";
                else if (aTexto[i].ToString() == "Ó") lTextoResp += "O";
                else if (aTexto[i].ToString() == "Ò") lTextoResp += "O";
                else if (aTexto[i].ToString() == "Ö") lTextoResp += "O";
                else if (aTexto[i].ToString() == "Ô") lTextoResp += "O";
                else if (aTexto[i].ToString() == "Ú") lTextoResp += "U";
                else if (aTexto[i].ToString() == "Ù") lTextoResp += "U";
                else if (aTexto[i].ToString() == "Ü") lTextoResp += "U";
                else if (aTexto[i].ToString() == "Û") lTextoResp += "U";
                else if (aTexto[i].ToString() == "~") lTextoResp += "";
                else if (aTexto[i].ToString() == "^") lTextoResp += "";
                else if (aTexto[i].ToString() == "´") lTextoResp += "";
                else if (aTexto[i].ToString() == "`") lTextoResp += "";
                else if (aTexto[i].ToString() == "|") lTextoResp += "";
                else if (aTexto[i].ToString() == "°") lTextoResp += "";
                else if (aTexto[i].ToString() == "£") lTextoResp += "";
                else if (aTexto[i].ToString() == "¢") lTextoResp += "";
                else if (aTexto[i].ToString() == "§") lTextoResp += "";
                else if (aTexto[i].ToString() == "#") lTextoResp += "";
                else if (aTexto[i].ToString() == "¨") lTextoResp += "";
                else if (aTexto[i].ToString() == "&") lTextoResp += "";
                else if (aTexto[i].ToString() == "*") lTextoResp += "";
                else if (aTexto[i].ToString() == "º") lTextoResp += "";
                else if (aTexto[i].ToString() == "ª") lTextoResp += "";
                else lTextoResp += aTexto[i];
            }

            return lTextoResp;
        }

        // Método para extrair somente a tag <Nfe> e seus filhos
        private static string ExtrairConteudoNFe(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

            XElement nfeElement = doc.Descendants(ns + "NFe").FirstOrDefault();

            return nfeElement != null ? nfeElement.ToString() : "Tag <NFe> não encontrada.";
        }


        // Endpoint POST: /danfe
        [HttpPost]
        public IActionResult GetDanfe([FromBody] DanfeRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.CodigoNFe) || string.IsNullOrEmpty(request.Cnpj))
            {
                return BadRequest("Os campos 'CodigoNFe' e 'Cnpj' são obrigatórios.");
            }

            try
            {
                var xml = _danfeService.ConsultarXml(request.CodigoNFe, request.Cnpj);

                if (string.IsNullOrEmpty(xml))
                {
                    return NotFound("Nenhum XML encontrado para os parâmetros fornecidos.");
                }

                try
                { 
                    xml = RetirarCaracteresEspeciaisXml(xml);

                    xml = ExtrairConteudoNFe(xml);

                    string danfeHtml = _danfeViewHTML.ObterDanfeNfe(xml);

                    if (string.IsNullOrEmpty(danfeHtml))
                    {
                        return StatusCode(500, "Erro ao gerar o HTML do DANFE.");
                    }
                    return Content(danfeHtml, "text/html");
                }
                catch (XmlException ex)
                {
                    return BadRequest($"XML inválido: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }

    public class DanfeRequest
    {
        public string CodigoNFe { get; set; }
        public string Cnpj { get; set; }
    }
}
