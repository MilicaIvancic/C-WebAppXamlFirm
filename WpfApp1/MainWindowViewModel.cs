using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.KlasaZaPretplatu;
using WpfApp1.WindowViewModel;

namespace WpfApp1
{
    public class MainWindowViewModel:Pretplata<MainWindowViewModel>
    {
        HttpClient client = new HttpClient();

        public MainWindowViewModel()
        {
            this.client.BaseAddress = new Uri("http://localhost:3983/");
            this.DohvatiFirme();
            this.DohvatiProizvode();
        }

        private ObservableCollection<FirmaWindowViewModel> firme;
        public ObservableCollection<FirmaWindowViewModel> Firme
        {
            get
            {
                return this.firme;
            }
            set
            {
                PretplatiSenaPromenu(ref firme, value);
            }
        }

        public void DohvatiFirme()
        {
            HttpResponseMessage message = this.client.GetAsync("api/Firme").Result;
            var podaci = message.Content.ReadAsAsync<IEnumerable<FirmaWindowViewModel>>().Result;
            this.Firme = new ObservableCollection<FirmaWindowViewModel>(podaci);
        }

        private FirmaWindowViewModel izabranaFirma;
        public FirmaWindowViewModel IzabranaFirma
        {
            get
            {
                return this.izabranaFirma;
            }
            set
            {
                PretplatiSenaPromenu(ref izabranaFirma, value);
            }
        }

        private ObservableCollection<FirmaProizvodWindowViewModel> firmaProizvod;
        public ObservableCollection<FirmaProizvodWindowViewModel> FirmaProizvod
        {
            get
            {
                return this.firmaProizvod;
            }
            set
            {
                PretplatiSenaPromenu(ref firmaProizvod, value);
            }
        }
        public void DohvatiProizvodeFirme(Object obj, EventArgs e)
        {
            if (this.IzabranaFirma != null)
            {
                HttpResponseMessage message = this.client.GetAsync("api/ProizvodFirma/"+this.IzabranaFirma.IdFirma).Result;
                var podaci = message.Content.ReadAsAsync<IEnumerable<FirmaProizvodWindowViewModel>>().Result;
                this.FirmaProizvod = new ObservableCollection<FirmaProizvodWindowViewModel>(podaci);
            }
        }


        //////////////////  Proizvodii
        private ObservableCollection<ProizvodWindowViewModel> proizvodi;
        public ObservableCollection<ProizvodWindowViewModel> Proizvodi
        {
            get
            {
                return this.proizvodi;
            }
            set
            {
                PretplatiSenaPromenu(ref proizvodi, value);
            }
        }
        public void DohvatiProizvode()
        {
            
                HttpResponseMessage message = this.client.GetAsync("api/Proizvodi").Result;
                var podaci = message.Content.ReadAsAsync<IEnumerable<ProizvodWindowViewModel>>().Result;
                this.Proizvodi = new ObservableCollection<ProizvodWindowViewModel>(podaci);
            
        }

        private ProizvodWindowViewModel izabraniProizvod;
        public ProizvodWindowViewModel IzabraniProizvod
        {
            get
            {
                return this.izabraniProizvod;
            }
            set
            {
                PretplatiSenaPromenu(ref izabraniProizvod, value);
                if (this.izabraniProizvod != null)
                {
                    PoljeNaziv = izabraniProizvod.Naziv;
                }
            }
        }

        private string poljenaziv;
        public string PoljeNaziv
        {
            get
            {
                return this.poljenaziv;
            }
            set
            {
                this.poljenaziv = value;
                PretplatiSenaPromenu(ref poljenaziv, value);
            }

        }

        public void Insert(object obj, EventArgs e)
        {

            if (PoljeNaziv != "")
            {
                HttpResponseMessage message = this.client.PostAsJsonAsync("api/ProizvodInsert", new ProizvodWindowViewModel
                {
                    Naziv = PoljeNaziv
                }).Result;
                this.DohvatiProizvode();
            }
        }

        public void Update(object obj, EventArgs e)
        {

            if (this.PoljeNaziv != "" && this.IzabraniProizvod!=null)
            {
                HttpResponseMessage message = this.client.PutAsJsonAsync("api/ProizvodUpdate/" + this.IzabraniProizvod.IdProizvod, new ProizvodWindowViewModel
                {
                    Naziv = PoljeNaziv,
                    IdProizvod=IzabraniProizvod.IdProizvod
                }).Result;
                this.DohvatiProizvode();
            }
        }

        public void Delete(object obj, EventArgs e)
        {

            if (this.IzabraniProizvod != null)
            {
                HttpResponseMessage message = this.client.DeleteAsync("api/ProizvodDelete/" + this.IzabraniProizvod.IdProizvod).Result;
                this.DohvatiProizvode();
            }
        }
    }
}
