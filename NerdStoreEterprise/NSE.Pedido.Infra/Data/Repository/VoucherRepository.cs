using Microsoft.EntityFrameworkCore;
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

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}