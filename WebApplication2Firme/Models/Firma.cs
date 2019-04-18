using System;
using System.Collections.Generic;

namespace WebApplication2Firme.Models
{
    public partial class Firma
    {
        public Firma()
        {
            FirmaProizvod = new HashSet<FirmaProizvod>();
        }

        public int IdFirma { get; set; }
        public string Naziv { get; set; }

        public ICollection<FirmaProizvod> FirmaProizvod { get; set; }
    }
}
