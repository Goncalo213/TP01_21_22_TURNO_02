namespace TP01_21_22_TURNO_02.Data
{
    public class DbInitializer
    {
        private readonly TP01_21_22_TURNO_02Context _context;
        public DbInitializer(TP01_21_22_TURNO_02Context context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Livro.Any())
            {
                return;
            }

            var livros = new Livro[]
            {
                new Livro{titulo="100Anos",autores="os",editora="Porto",ISBN="3535129287265",capa="dks.jpg",contracapa="dbw.jpeg" },
                new Livro{titulo="qddw",autores="adas",editora="Porto",ISBN="3537879287265",capa="dks.jpg",contracapa="dbw.jpeg" },
                new Livro{titulo="1sdaw1",autores="wdbsa",editora="Porto",ISBN="3987929287265",capa="dks.jpg",contracapa="dbw.jpeg" },
            };

            foreach (var c in livros)
            {
                _context.Livro.Add(c);
            };
            _context.SaveChanges();
        }
    }
}
