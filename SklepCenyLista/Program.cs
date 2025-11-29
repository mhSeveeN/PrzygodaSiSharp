using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] produkty = { "Chleb", "Mleko", "Ser", "Kawa" };
        int[] ceny = { 5, 4, 12, 25 };

        Console.WriteLine("Lista Produktów: ");
        for (int i = 0; i < produkty.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {produkty[i]} - {ceny[i]} PLN");
        }

        powrot:
        Console.WriteLine("\nPodaj indeks produktu, aby zobaczyć jego cenę: ");
        int indeks = int.Parse(Console.ReadLine());

        if (indeks >= 0 && indeks < produkty.Length)
        {
            Console.WriteLine($"Wybrałeś: {produkty[indeks]}, cena: {ceny[indeks]} zł");
        } else
        {
            Console.WriteLine("Niepoprawny Indeks!!");
            goto powrot;
        }

        Console.WriteLine("\nPodaj ilość wybranego produktu: ");
        int liczbaProdukt = int.Parse(Console.ReadLine());
        int cenaProdukt = ceny[indeks] * liczbaProdukt;
        Console.WriteLine($"Łączna cena za produkt {produkty[indeks]} wynosi: {cenaProdukt} zł");        
    }
}