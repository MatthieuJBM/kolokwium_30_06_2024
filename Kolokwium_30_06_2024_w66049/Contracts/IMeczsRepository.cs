using Kolokwium_30_06_2024_w66049.Data;

namespace Kolokwium_30_06_2024_w66049.Contracts;

public interface IMeczsRepository : IGenericRepository<Mecz>
{
    Task<IEnumerable<Mecz>> GetKonfliktoweMecze(int druzyna1Id, int druzyna2Id, DateTime dataMeczu,
        TimeOnly godzinaMeczuOd, TimeOnly godzinaMeczuDo);
}