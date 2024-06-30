using System.ComponentModel.DataAnnotations;

namespace Kolokwium_30_06_2024_w66049.Models.DruzynaPilkarska;

public class DruzynaPilkarskaDto
{
    public int Id { get; set; }

    [Required] public string Nazwa { get; set; }

    [Required] public bool Aktywny { get; set; }
}