namespace NFe.Danfe.Html.New.Services
{
    public interface IDanfeService
    {
        /// <summary>
        /// Consulta o banco de dados usando o código da NFe e o CNPJ do cliente.
        /// </summary>
        /// <param name="codigoNFe">Código da NFe.</param>
        /// <param name="cnpj">CNPJ do cliente.</param>
        /// <returns>O conteúdo do XML da NFe.</returns>
        string ConsultarXml(string codigoNFe, string cnpj);
    }
}
