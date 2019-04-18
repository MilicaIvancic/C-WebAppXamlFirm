using System;
using System.Collections.Generic;

namespace WebApplication2Firme.Models
{
    public partial class FirmaProizvod
    {
        public int IdFirmaProizvod { get; set; }
        public int IdProizvod { get; set; }
        public int IdFirma { get; set; }
        public string Datum { get; set; }
        public int Broj { get; set; }

        public Proizvod IdProizvod1 { get; set; }
        public Firma IdProizvodNavigation { get; set; }
    }
}
