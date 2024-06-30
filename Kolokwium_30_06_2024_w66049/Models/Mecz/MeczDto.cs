using System.ComponentModel.DataAnnotations;

namespace Kolokwium_30_06_2024_w66049.Models.Mecz;

public class MeczDto
{
    public int Id { get; set; }

    [Required] public string NazwaRozgrywki { get; set; }

    [Required] public int Druzyna1Id { get; set; }

    [Required] public int Druzyna2Id { get; set; }

    [Required] public DateTime DataMeczu { get; set; }

    [Required] public TimeOnly GodzinaMeczuOd { get; set; }

    [Required] public TimeOnly GodzinaMeczuDo { get; set; }

    [Required] public bool AnulowanyMecz { get; set; }
}