namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {
        public int? Id { get; set; }
        public string? Historico { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }
    }
}