using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_30_06_2024_w66049.Data;

/*
 * Encja Mecz:
  - Id,
  - Nazwa rozgrywki,
  - DruzynaId,
  - Druzyna2Id,
  - Data meczu,
  - Godzina meczu od,
  - Godzina meczu do,
  - Anulowany mecz (wartośći 0 lub 1)
 *
 */

[Table("Mecze", Schema = "KolokwiumAPIDb")]
public class Mecz
{
    public int Id { get; set; }

    [MaxLength(256)] [Required] public string NazwaRozgrywki { get; set; }

    [ForeignKey(nameof(Druzyna1Id))] public int Druzyna1Id { get; set; }
    public DruzynaPilkarska DruzynaPilkarska1 { get; set; }

    [ForeignKey(nameof(Druzyna2Id))] public int Druzyna2Id { get; set; }
    public DruzynaPilkarska DruzynaPilkarska2 { get; set; }

    [Required] public DateTime DataMeczu { get; set; }

    [Required] public TimeOnly GodzinaMeczuOd { get; set; }

    [Required] public TimeOnly GodzinaMeczuDo { get; set; }

    [Required] public bool AnulowanyMecz { get; set; }
}