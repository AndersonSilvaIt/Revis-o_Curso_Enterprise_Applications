using NSE.Core.Data;

namespace NSE.Pedido.Domain.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedidos>
    {
        Task<Pedidos> ObterPorId(Guid id);
        Task<IEnumerable<Pedidos>> ObterListaPorClienteId(Guid clienteId);
        void Adicionar(Pedidos pedido);
        void Atualizar(Pedidos pedido);

        /* Pedido Items */
        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
    }
}