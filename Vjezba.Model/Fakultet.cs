using System;
using System.Collections;

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

    public IEnumerable<Profesor> DohvatiProfesore()
    {
        // Filter the profesors from the aray
        var profesori = Osobe.Where(Osoba => Osoba is Profesor).Cast<Profesor>();

        // Order by DatumIzbora
        profesori = profesori.OrderBy(profesori => profesori.DatumIzbora);

        return profesori;
    }
}
