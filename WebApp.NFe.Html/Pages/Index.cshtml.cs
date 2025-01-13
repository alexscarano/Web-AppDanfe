using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NFe.Danfe.Html.New;
using NFe.Danfe.Html.New.Services;

namespace WebApp.NFe.Html.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDanfeService _danfeService;

        [BindProperty]
        public string CodigoNFe { get; set; }

        [BindProperty]
        public string Cnpj { get; set; }

        public string HtmlContent { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDanfeService danfeService)
        {
            _logger = logger;
            _danfeService = danfeService;
        }

        // Endpoint POST
        public IActionResult OnPost()
        {
            // Verifica se os parâmetros foram fornecidos
            if (string.IsNullOrEmpty(CodigoNFe) || string.IsNullOrEmpty(Cnpj))
            {
                HtmlContent = "Código NFe e CNPJ são obrigatórios.";
                return Page(); // Retorna para a mesma página com a mensagem
            }

            // Chama o serviço para obter o XML da NFe
            string xmlString = _danfeService.ConsultarXml(CodigoNFe, Cnpj);

            // Verifica se o XML foi encontrado
            if (string.IsNullOrEmpty(xmlString))
            {
                HtmlContent = "XML não encontrado.";
                return Page(); // Retorna para a mesma página com a mensagem
            }

            // Instancia o objeto DanfeViewHTML e gera o DANFE em HTML
            DanfeViewHTML danfeViewHTML = new DanfeViewHTML();
            HtmlContent = danfeViewHTML.ObterDanfeNfe(xmlString);

            return Page(); // Retorna para a mesma página com o conteúdo gerado
        }
    }
}
