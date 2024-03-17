using System;
using System.Linq;

namespace Vjezba.Model;

public class Osoba
{
    public string Ime { get; set; }
    public string Prezime { get; set; }

    private string _oib;
    public string OIB
    {
        get => _oib;
        set
        {
            if (value.Length != 11 || !value.All(char.IsDigit))
            {
                throw new InvalidOperationException();
            }

            _oib = value;
        }
    }

    private string _jmbg;
    public string JMBG
    {
        get => _jmbg;
        set
        {
            if (value.Length != 13 || !value.All(char.IsDigit));
        }
    }

    public DateTime DatumRodenja
    {
        get
        {
            var dan = JMBG.Substring(0, 2);
            var mjesec = JMBG.Substring(2, 2);
            var godina = JMBG.Substring(4, 3);

            return new(int.Parse(godina) + 1000, int.Parse(mjesec), int.Parse(dan));
        }
    }
}


