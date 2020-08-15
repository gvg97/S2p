namespace S2pEntities
{
    public class ListTransaction
    {
        public string Id { get; set; }
        public string FormaPagamento { get; set; }
        public string StatusPagamento { get; set; }
        public string ValorVenda { get; set; }
        public string Referencia { get; set; }
        public string DataPagamento { get; set; }
        public string DataDeSolicitacao { get; set; }
        public string AntiFraudRecommendation { get; set; }
        public string CallbackUrl { get; set; }
        public string NomeCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string EmailCliente { get; set; }
        public string DocumentoEmpresa { get; set; }
        public string IdMerchant { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
    }
}
