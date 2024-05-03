using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imobiliaria.Models;

public class Cliente
{
    public int Id {get; set;}
    
    [StringLength(100, MinimumLength =3)]
    [Required]
    public string? Nome {get; set;}
    
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento {get; set;}
    
    public string? Endereco {get; set;}
    
    [DataType(DataType.Currency)]
    [Range(1000, 50000)]
    [Column(TypeName="decimal(18,2)")]
    public decimal Renda {get; set;}
   
   [StringLength(100, MinimumLength =3)]
    public string? Cargo {get; set;}
    
}