﻿using NetDevPack.Domain;
using NSE.Pagamentos.NerdsPag;

namespace NSE.Pagamento.API.Models
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Pagamento()
        {
            Transacoes = new List<Transacao>();
        }

        public Guid PedidoId { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public decimal Valor { get; set; }

        public CartaoCredito CartaoCredito { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }

        public void AdicionarTransacao(Transacao transacao)
        {
            Transacoes.Add(transacao);
        }
    }
}
