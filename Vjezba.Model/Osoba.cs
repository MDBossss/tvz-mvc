using System;

namespace Vjezba.Model;

public class Osoba
{
    public string Ime { get; set; };
    public string Prezime { get; set; };

    public string Ime
    {
        get => _ime;
        set => _ime = value;
    }

    public string Prezime
    {
        get => _prezime;
        set => _prezime = value;
    }

    private string _oib;
    public string OIB
    {
        get => _oib;
        set
        {
            if (value.length != 11 || !value.All(char.isDigit))
            {
                throw new InvalidOperationException()
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
            if(value.length != 13 || !value.All(char.isDigit))
        }
    }

    public DateTime DatumRodenja
    {
        get
        {
            var dan = JMBG.Substring(0, 2);
            var mjesec = JMBG.Substring(2, 2);
            var godina = JMBG.Substring(4, 3);

            return new(int.parse(godina) + 1000, int.Parse(mjesec), int.Parse(dan));
        }
    }
}


