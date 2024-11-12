using NSE.Core.Data;
using NSE.Pedido.Domain.Vouchers;

namespace NSE.Pedido.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext pedidosContext)
        {
            _context = pedidosContext;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}