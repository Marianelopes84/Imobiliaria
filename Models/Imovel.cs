using System;
using System.ComponentModel.DataAnnotations;



namespace Imobiliaria.Models 
{
    public class Imovel
    {
        public int Id { get; set; }
        
        [StringLength(100, MinimumLength =1)]
        [Required]
        public string ?Tipo { get; set; } 
    
        [StringLength(100, MinimumLength =1)]
        [Required]
        public string ?Descricao { get; set; } 
    }
}
