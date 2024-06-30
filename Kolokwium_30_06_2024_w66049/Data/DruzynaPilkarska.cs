using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_30_06_2024_w66049.Data;

/*Encja:
 - Id, 
 - Nazwa, 
 - Aktywny. 
 ( np, Polska, Francja)
 */
[Table("DruzynyPilkarskie", Schema = "KolokwiumAPIDb")]
public class DruzynaPilkarska
{
    public int Id { get; set; }

    [MaxLength(256)] [Required] public string Nazwa { get; set; }

    [Required] public bool Aktywny { get; set; }
}