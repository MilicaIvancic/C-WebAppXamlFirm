using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.KlasaZaPretplatu
{
    public class Pretplata<T> : INotifyPropertyChanged
    {
        public void PretplatiSenaPromenu<T>(ref T polje, T value, [CallerMemberName] string poljeNaziv = "")
        {
            polje = value;
            this.PropertyChanged(this, new PropertyChangedEventArgs(poljeNaziv));
        }
        public event PropertyChangedEventHandler PropertyChanged= delegate { };
    }
}
