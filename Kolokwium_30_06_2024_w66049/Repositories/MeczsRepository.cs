using Kolokwium_30_06_2024_w66049.Contracts;
using Kolokwium_30_06_2024_w66049.Data;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_30_06_2024_w66049.Repositories;

public class MeczsRepository : GenericRepository<Mecz>, IMeczsRepository
{
    private readonly KolokwiumDbContext _context;

    public MeczsRepository(KolokwiumDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mecz>> GetKonfliktoweMecze(int druzyna1Id, int druzyna2Id, DateTime dataMeczu,
        TimeOnly godzinaMeczuOd, TimeOnly godzinaMeczuDo)
    {
        return await _context.Meczs
            .Where(m => m.DataMeczu == dataMeczu &&
                        (m.Druzyna1Id == druzyna1Id || m.Druzyna2Id == druzyna1Id || m.Druzyna1Id == druzyna2Id ||
                         m.Druzyna2Id == druzyna2Id) &&
                        (m.GodzinaMeczuOd < godzinaMeczuDo && m.GodzinaMeczuDo > godzinaMeczuOd))
            .ToListAsync();
    }
}