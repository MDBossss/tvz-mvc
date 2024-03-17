﻿using System;
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
        return Osobe.Where(Osoba => Osoba is Student).Cast<Student>().Where(student => student.DatumRodenja.Year > 1991);
    }

    public IEnumerable<Student> DohvatiStudente91NoLinq()
    {
        // Empty list creation for filtered students
        var studenti = new List<Student>();

        //Filter students manually
        foreach (var osoba in Osobe)
        {
            if(osoba is Student && osoba.DatumRodenja.Year > 1991)
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
        return Osobe.Where(osoba => osoba is Student && osoba.DatumRodenja.Year == god).Cast<Student>().OrderBy(s => s.Prosjek).FirstOrDefault();
    }
}
