using System;
using System.Linq;

namespace Vjezba.Model;

public class Student : Osoba
{
    private string _jmbag;
    public string JMBAG
    {
        get => _jmbag;
        set
        {
            if(value.Length != 10 || !value.All(char.IsDigit))
            {
                throw new InvalidOperationException();
            }
            _jmbag = value;
        }
    }

    public decimal Prosjek { get; set; }
    public int BrPolozeno { get; set; }
    public int ECTS { get; set; }
}
