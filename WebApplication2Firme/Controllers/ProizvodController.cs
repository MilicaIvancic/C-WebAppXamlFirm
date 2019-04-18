using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2Firme.Models;
using WebApplication2Firme.ViewModel;

namespace WebApplication2Firme.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        public readonly CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext conn;
        public ProizvodController(CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext x)
        {
            this.conn = x;
        }

        // GET: api/Proizvod
        [Route("api/Proizvodi")]
        [HttpGet]
        public IQueryable<ProizvodViewModel> Get()
        {
            IQueryable<ProizvodViewModel> ieproizvodi =
                from proizvod in this.conn.Proizvod
                select new ProizvodViewModel
                {
                    IdProizvod = proizvod.IdProizvod,
                    Naziv = proizvod.Naziv
                };
            return ieproizvodi;
        }

        // GET: api/Firma
        [Route("api/Firme")]
        [HttpGet]
        public IQueryable<FirmaViewModel> GetFirma()
        {
            var iefirma =
                from firma in this.conn.Firma
                select new FirmaViewModel
                {
                    IdFirma = firma.IdFirma,
                    Naziv = firma.Naziv
                };

            return iefirma;
        }

        // GET: api/Firma/5
        [Route("api/ProizvodFirma/{id}")]
        [HttpGet("{id}", Name = "Get")]
        public IQueryable<FirmaProizvodWievModel> Get(int id)
        {
            var firmaProizvod =
                from proizvod in this.conn.Proizvod
                join firmapr in this.conn.FirmaProizvod
                on proizvod.IdProizvod equals firmapr.IdProizvod
                where firmapr.IdFirma==id
                select new FirmaProizvodWievModel
                {
                    Naziv = proizvod.Naziv,
                    Datum = firmapr.Datum,
                    Broj = firmapr.Broj
                };

            return firmaProizvod;
        }

        // POST: api/Proizvod
        [Route("api/ProizvodInsert")]
        [HttpPost]
        public void Post([FromBody] ProizvodViewModel value)
        {
            Proizvod p = new Proizvod
            {
                Naziv = value.Naziv
            };
            this.conn.Proizvod.Add(p);
            this.conn.SaveChanges();
        }

        // PUT: api/Proizvod/5
        [Route("api/ProizvodUpdate/{id}")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProizvodViewModel value)
        {
            Proizvod p = new Proizvod
            {
                IdProizvod = id,
                Naziv = value.Naziv
            };
            this.conn.Proizvod.Update(p);
            this.conn.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [Route("api/ProizvodDelete/{id}")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Proizvod pro = this.conn.Proizvod.Find(id);
            if(pro != null)
            {
                this.conn.Proizvod.Remove(pro);
                this.conn.SaveChanges();
            }
        }
    }
}
