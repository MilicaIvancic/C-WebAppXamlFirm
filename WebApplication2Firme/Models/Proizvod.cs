using System;
using System.Collections.Generic;

namespace WebApplication2Firme.Models
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            FirmaProizvod = new HashSet<FirmaProizvod>();
        }

        public int IdProizvod { get; set; }
        public string Naziv { get; set; }

        public ICollection<FirmaProizvod> FirmaProizvod { get; set; }
    }
}
