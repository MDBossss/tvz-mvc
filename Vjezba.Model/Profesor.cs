using System;
using System.Collections.Generic;

namespace Vjezba.Model;

public class Profesor : Osoba
{
	public string Odjel {  get; set; }
	public Zvanje Zvanje { get; set; }
	public DateTime DatumIzbora { get; set; }

	public List<Predmet> Predmeti { get; set; }

	public int KolikoDoReizbora()
	{
		if(Zvanje == Zvanje.Asistent)
		{
			return DateTime.Now.Year - DatumIzbora.Year + 4;
		}
		else
		{
			return DateTime.Now.Year - DatumIzbora.Year + 5;
		}
	}

}
