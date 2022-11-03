using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP01_21_22_TURNO_02;

namespace TP01_21_22_TURNO_02.Data
{
    public class TP01_21_22_TURNO_02Context : DbContext
    {
        public TP01_21_22_TURNO_02Context (DbContextOptions<TP01_21_22_TURNO_02Context> options)
            : base(options)
        {
        }

        public DbSet<TP01_21_22_TURNO_02.Livro> Livro { get; set; } = default!;
    }
}
