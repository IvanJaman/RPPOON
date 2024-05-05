using System.Reflection.Metadata;

abstract class Osoba{
    protected string Ime { get; set; }
    protected string Prezime { get; set; }
    protected DateTime DatumRodenja { get; set; }
    protected int Stanje;
    public virtual void Uplati(int iznos){}
    public virtual void Isplati(int iznos){}
}

interface ITransakcija{
    protected abstract void IzvrsiTransakciju(int iznos);
}

class Korisnik : Osoba{

    private string Ime { get; set; }
    private string Prezime { get; set; }
    private DateTime DatumRodenja { get; set; }
    private int Stanje;
    private Korisnik(string ime, string prezime, DateTime datumrodenja, int stanje){
        Ime = ime;
        Prezime = prezime;
        DatumRodenja = datumrodenja;
        Stanje = stanje;
    }

    public override void Uplati(int iznos)
    {
        Stanje = Stanje + iznos;
    }
    public override void Isplati(int iznos)
    {
        Stanje = Stanje - iznos;
    }
}

class Uplata : ITransakcija{
    private int Iznos;
    private Korisnik Korisnik;

    protected Uplata(int iznos, Korisnik korisnik){
        Iznos = iznos;
        Korisnik = korisnik;
    }

    public void IzvrsiTransakciju(int iznos){
        Korisnik.Uplati(iznos);
    }
}

class Isplata : ITransakcija{
    private int Iznos;
    private Korisnik Korisnik;

    public Isplata(int iznos){
        Iznos = iznos;
    }

    public void IzvrsiTransakciju(int iznos){
        Korisnik.Isplati(iznos);
    }
}

class Banka{
    int BrojKorisnika;

    List<Korisnik> Korisnici;
    public Banka(int brojKorisnika, List<Korisnik> korisnici){
        BrojKorisnika = brojKorisnika;
        Korisnici = korisnici;
    }
}

