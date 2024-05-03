using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Models;

namespace Imobiliaria.Data
{
        public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext(DbContextOptions<ImobiliariaContext> options) : base(options)
        {
        }

        public DbSet<Imovel> Imovel { get; set; } // Esta propriedade representa a entidade Imovel no contexto
        public DbSet<Cliente> Cliente { get; set; } // Outras entidades podem ser adicionadas aqui

        // Outros métodos e configurações do contexto podem estar presentes aqui
    }
}