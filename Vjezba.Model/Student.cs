using System;

namespace Vjezba.Model;

public class Student : Osoba
{
    private string _jmbag;
    public string JMBAG
    {
        get => _jmbag;
        set
        {
            if(value.length == 13 && !value.All(char.isDigit))
            {
                throw new InvalidOperationException()
            }
            _jmbag = value;
        }
    }

    public decimal Prosjek { get; set; }
    public int BrPolozeno { get; set; }
    public int ECTS { get; set; }
}
