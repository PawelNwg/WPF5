using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD5_WPF_NIEWEGLOWSKI
{
    class Uzytkownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        
        public Uzytkownik() { }
        public Uzytkownik(string imie, string nazwisko, string email)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {Email}";
        }

    }
}
