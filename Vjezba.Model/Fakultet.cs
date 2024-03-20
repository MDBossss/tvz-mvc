using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


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
        return Osobe.Count(osoba => osoba is Student);
    }

    public Student DohvatiStudenta(string JMBAG)
    {
        return Osobe.OfType<Student>().FirstOrDefault(student => student.JMBAG == JMBAG);
    }

    public IEnumerable<Profesor> DohvatiProfesore()
    {
        // Filter the profesors from the array
        var profesori = Osobe.Where(Osoba => Osoba is Profesor).Cast<Profesor>();

        // Order by DatumIzbora
        profesori = profesori.OrderBy(profesori => profesori.DatumIzbora);

        return profesori;
    }

    public IEnumerable<Student> DohvatiStudente91()
    {
        // Filter the students from the array which are born after year 1991
        return Osobe.Where(Osoba => Osoba is Student).Cast<Student>().Where(student => student.DatumRodjenja.Year > 1991);
    }

    public IEnumerable<Student> DohvatiStudente91NoLinq()
    {
        // Empty list creation for filtered students
        var studenti = new List<Student>();

        //Filter students manually
        foreach (var osoba in Osobe)
        {
            if(osoba is Student && osoba.DatumRodjenja.Year > 1991)
            {
                studenti.Add(osoba as Student);
            }
        }

        return studenti;
    }

    public IEnumerable<Student> StudentiNeTvzD()
    {
        return Osobe.Where(osoba => osoba is Student).Cast<Student>().Where(student => !student.JMBAG.StartsWith("0246") && student.Prezime.StartsWith("D"));
    }

    public List<Student> DohvatiStudente91List()
    {
        return DohvatiStudente91().ToList<Student>();
    }

    public Student NajboljiProsjek(int god)
    {
        return Osobe.Where(osoba => osoba is Student && osoba.DatumRodjenja.Year == god).Cast<Student>().MaxBy(s => s.Prosjek);
    }

    public List<Student> StudentiGodinaOrdered(int god)
    {
        return Osobe.Where(osoba => osoba is Student && osoba.DatumRodjenja.Year == god).Cast<Student>().OrderByDescending(s => s.Prosjek).ToList();
    }

    public List<Profesor> SviProfesori(bool asc)
    {
        var profesori = Osobe.Where(osoba => osoba is Profesor).Cast<Profesor>().ToList();

        if (asc)
        {
            return profesori.OrderBy(p => p.Prezime).ThenBy(p => p.Ime).ToList();
        }
        else
        {
            return profesori.OrderByDescending(p => p.Prezime).ThenBy(p => p.Ime).ToList();
        }
    }

    public int KolikoProfesoraUZvanju(Zvanje zvanje)
    {
        return Osobe.Where(o => o is Profesor).Cast<Profesor>().Where(p => p.Zvanje == zvanje).Count();
    }

    public List<Profesor> NeaktivniProfesori(int x)
    {
        return Osobe.Where(o => o is Profesor).Cast<Profesor>().Where(p => (p.Zvanje == Zvanje.Predavac || p.Zvanje == Zvanje.VisiPredavac) && p.Predmeti.Count() < x).ToList();
    }

    public List<Profesor> AktivniAsistenti(int x, int minEcts)
    {
        return Osobe.Where(o => o is Profesor).Cast<Profesor>().Where(p => p.Zvanje == Zvanje.Asistent && p.Predmeti.Count() > x && p.Predmeti.Any(p => p.ECTS >= minEcts)).ToList();
    }

    public void IzmjeniProfesore(Action<Profesor> action)
    {
        foreach (var profesor in Osobe.OfType<Profesor>())
        {
            action(profesor);
        }
    }
}
