using System;

namespace Vjezba.Model;

public class Fakultet
{
    public List<Osoba> Osobe { get; set; } = new();

    public int KolikoProfesora()
    {
        return Osobe.Count(osoba => osoba is Profesor);
    }

    public int KolikoStudenata()
    {
        return Osobe.Count(osoba => osoba is Student)
    }

    public Student DohvatiStudenta(string JMBAG)
    {
        Osobe.ofType<Student>().FirstOrDefault(student => student.JMBAG == JMBAG)
    }
}
