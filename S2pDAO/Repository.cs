using S2pEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace S2pDAO
{
    public class Repository : IRepository
    {
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("Default").Value;
        }
         
        public List<ListTransaction> GetByIdentity(string identity)
        {
            List<ListTransaction> transactionLists = new List<ListTransaction>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                string QueryString = "select [transaction].[Id],[PaymentMethod].[Name] as FormaPagamento," +
                    "[TransactionStatus].[Name] as StatusPagamento, [transaction].[Amount]," +
                    "[transaction].[Reference], [transaction].[PaymentDate]," +
                    "[transaction].[CreatedDate], [transaction].[AntiFraudRecommendation]," +
                    "[transaction].[CallbackUrl],[Customer].[Name],[Customer].[Identity]," +
                    "[Customer].[Email], Merchant.[Identity] as DocumentoEmpresa,Merchant.[Id] as IdMerchant," +
                    "Merchant.[Name] as NomeEmpresa,Merchant.[FantasyName]" +
                    "from[transaction] INNER JOIN[Customer] ON[transaction].[Idcustomer] = [Customer].[id] INNER JOIN Merchant " +
                    "ON[transaction].[Idmerchant] = [Merchant].[id] INNER JOIN PaymentMethod " +
                    "ON[transaction].[IdPaymentMethod] = [PaymentMethod].[Id] INNER JOIN [TransactionStatus]" +
                    "ON[transaction].[IdTransactionStatus] = [TransactionStatus].[Id] " +
                    "where[Customer].[identity] = @identity order by[transaction].[CreatedDate] desc";

                using (SqlCommand command = new SqlCommand(QueryString, con))
                {
                    command.Parameters.AddWithValue("@identity", identity);
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                transactionLists.Add(new ListTransaction()
                                {
                                    Id = reader["Id"].ToString(),
                                    FormaPagamento = reader["FormaPagamento"].ToString(),
                                    StatusPagamento = reader["StatusPagamento"].ToString(),
                                    ValorVenda = reader["Amount"].ToString(),
                                    Referencia = reader["Reference"].ToString(),
                                    DataPagamento = reader["PaymentDate"].ToString(),
                                    DataDeSolicitacao = reader["CreatedDate"].ToString(),
                                    AntiFraudRecommendation = reader["AntiFraudRecommendation"].ToString(),
                                    CallbackUrl = reader["CallbackUrl"].ToString(),
                                    NomeCliente = reader["Name"].ToString(),
                                    DocumentoCliente = reader["Identity"].ToString(),
                                    EmailCliente = reader["Email"].ToString(),
                                    DocumentoEmpresa = reader["DocumentoEmpresa"].ToString(),
                                    IdMerchant = reader["IdMerchant"].ToString(),
                                    NomeEmpresa = reader["NomeEmpresa"].ToString(),
                                    NomeFantasia = reader["FantasyName"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
            return transactionLists;
        }
    }
}