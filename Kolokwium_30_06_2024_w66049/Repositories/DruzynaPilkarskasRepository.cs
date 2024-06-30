using Kolokwium_30_06_2024_w66049.Contracts;
using Kolokwium_30_06_2024_w66049.Data;

namespace Kolokwium_30_06_2024_w66049.Repositories;

public class DruzynaPilkarskasRepository : GenericRepository<DruzynaPilkarska>, IDruzynaPilkarskasRepository
{
    public DruzynaPilkarskasRepository(KolokwiumDbContext context) : base(context)
    {
    }
}