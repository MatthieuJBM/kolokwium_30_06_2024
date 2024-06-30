using Kolokwium_30_06_2024_w66049.Contracts;
using Kolokwium_30_06_2024_w66049.Data;

namespace Kolokwium_30_06_2024_w66049.Repositories;

public class MeczsRepository : GenericRepository<Mecz>, IMeczsRepository
{
    public MeczsRepository(KolokwiumDbContext context) : base(context)
    {
    }
}