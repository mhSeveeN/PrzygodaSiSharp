internal class Program
{
    private static void Main(string[] args)
    {
        string[] Nazwa = { "Aston Martin DB9", "Aston Martin DB11", "Aston Martin Valour", "Alfa Romeo Giulia QV", "Alfa Romeo Giulia", "Mitsubishi Lancer Evo X", "BMW M3 F80"};
        int[] Ilosc = { 13, 2, 1, 5, 10, 1, 6 };
        double[] Cena = { 265000.89, 350000.65, 450000.13, 98000.99, 78999.99, 230000.59, 205999.99 };

        double Portfel = 0;

    MENU:
        Console.WriteLine("Witamy w magazynie samochodów!");
        Console.WriteLine("Oto dostępne samochody:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Nazwa samochodu\t\t\tIlość\t\t\tCena");
        Console.WriteLine("---------------------------------------------------");
        for (int i = 0; i < Nazwa.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Nazwa[i]}\t{Ilosc[i]}\t{Cena[i]:C}");
        }
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Co chcesz zrobić?");
        Console.WriteLine("1. Kup produkt");
        Console.WriteLine("2. Dodaj produkt do magazynu");
        Console.WriteLine("3. Wyświetl sumę zakupów (portfel)");
        Console.WriteLine("4. Wyjście");
        Console.WriteLine("--------------------------------------------------");
        string dzialanie = Console.ReadLine();

        if (!int.TryParse(dzialanie, out int wybor1))
        {
            Console.WriteLine("Nieprawidłowa opcja. Wybierz numer 1 do 4.");
            goto MENU;
        }

        switch (wybor1)
        {
            case 1:
            BUY_SELECT:
                Console.WriteLine("Wybierz numer samochodu, który chcesz kupić:");
                string wyborSamochodu = Console.ReadLine();
                if (!int.TryParse(wyborSamochodu, out int carChoice) || carChoice < 1 || carChoice > Nazwa.Length)
                {
                    Console.WriteLine("Nie ma w magazynie wybranego produktu!!");
                    goto BUY_SELECT;
                }

                int index = carChoice - 1;

            BUY_QTY:
                Console.WriteLine($"Ile sztuk {Nazwa[index]} chcesz kupić?");
                string iloscZakupu = Console.ReadLine();
                if (!int.TryParse(iloscZakupu, out int iloscZakupiona) || iloscZakupiona < 1)
                {
                    Console.WriteLine("Nieprawidłowa ilość! Podaj liczbę naturalną większą od zera.");
                    goto BUY_QTY;
                }

                if (iloscZakupiona <= Ilosc[index])
                {
                    double kosztZakupu = iloscZakupiona * Cena[index];
                    Portfel += kosztZakupu;
                    Ilosc[index] -= iloscZakupiona;
                    Console.WriteLine($"Kupiłeś {iloscZakupiona} sztuk {Nazwa[index]} za {kosztZakupu:C}. Pozostało w magazynie: {Ilosc[index]} sztuk.");
                }
                else
                {
                    Console.WriteLine("Nie ma wystarczającej ilości produktu w magazynie!");
                }

                goto MENU;

            case 2:
            ADD_PRODUCT:
                Console.WriteLine("Napisz markę i model samochodu, który chcesz dodać: ");
                string nowySamochod = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nowySamochod))
                {
                    Console.WriteLine("Nieprawidłowa nazwa produktu.");
                    goto ADD_PRODUCT;
                }

                Console.WriteLine("Podaj ilość samochodów do dodania: ");
                string iloscNowegoText = Console.ReadLine();
                if (!int.TryParse(iloscNowegoText, out int iloscNowego) || iloscNowego < 0)
                {
                    Console.WriteLine("Nieprawidłowa ilość (podaj liczbę całkowitą >= 0).");
                    goto ADD_PRODUCT;
                }

                Console.WriteLine("Podaj cenę samochodu: ");
                string cenaNowegoText = Console.ReadLine();
                if (!double.TryParse(cenaNowegoText, out double cenaNowego) || cenaNowego < 0)
                {
                    Console.WriteLine("Nieprawidłowa cena (podaj liczbę >= 0).");
                    goto ADD_PRODUCT;
                }

                Array.Resize(ref Nazwa, Nazwa.Length + 1);
                Nazwa[Nazwa.Length - 1] = nowySamochod;
                Array.Resize(ref Ilosc, Ilosc.Length + 1);
                Ilosc[Ilosc.Length - 1] = iloscNowego;
                Array.Resize(ref Cena, Cena.Length + 1);
                Cena[Cena.Length - 1] = cenaNowego;

                Console.WriteLine($"Dodano {nowySamochod}, w ilości: {iloscNowego}, po cenie: {cenaNowego:C}");
                goto MENU;

            case 3:
                Console.WriteLine($"Łączna wartość zakupów w portfelu: {Portfel:C}");
                goto MENU;

            case 4:
                Console.WriteLine("Do widzenia!");
                break;

            default:
                Console.WriteLine("Wybrano nieprawidłową opcję – wybierz 1 do 4.");
                goto MENU;
        }
    }
}