using Microsoft.Data.SqlClient;

namespace NFe.Danfe.Html.New.Services
{
    public class DanfeService : IDanfeService
    {
        private readonly string _connectionString;

        public DanfeService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ConsultarXml(string codigoNFe, string cnpj)
        {
            string xmlResult = string.Empty;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var query = @"SELECT Nfe.nfe 
                                FROM dbo.NotaFiscalEletronica Nfe
                                WHERE Nfe.cnpjEmitente = @Cnpj
                                AND Nfe.numeroNFe = @CodigoNFe";


                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoNFe", codigoNFe);
                        command.Parameters.AddWithValue("@Cnpj", cnpj);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            xmlResult = result.ToString();
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return xmlResult;
        }
    }
}
