using System;
using System.Collections.Generic;
using ConsoleApplication1.DaneSprzetowe;
using ConsoleApplication1.ObslugaWypozyczen;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1
{
    internal class Program
    {
        static List<UzytkownikSprzetu> uzytkownicy = new List<UzytkownikSprzetu>();
        static List<Sprzet> sprzety = new List<Sprzet>();
        static ProcesWypozyczenia proces = new ProcesWypozyczenia();
        public static void Main(string[] args)
        {
            {
                bool dziala = true;
                while (dziala)
                {
                    Console.WriteLine("\n=== SYSTEM WYPOŻYCZALNI ===");
                    Console.WriteLine("1. Dodaj nowego użytkownika");
                    Console.WriteLine("2. Dodaj nowy sprzęt");
                    Console.WriteLine("3. Lista całego sprzętu");
                    Console.WriteLine("4. Lista dostępnego sprzętu");
                    Console.WriteLine("5. Wypożycz sprzęt");
                    Console.WriteLine("6. Zwróć sprzęt");
                    Console.WriteLine("7. Wypisz aktywne wypożyczenia użytkownika");
                    Console.WriteLine("8. Wypisz przeterminowane wypożyczenia");
                    Console.WriteLine("9. Napisz raport");
                    Console.WriteLine("0. Wyjście");
                    Console.Write("\nWybierz opcję: ");

                    switch (Console.ReadLine())
                    {
                        case "1": DzialaniaNaUzytkownikach.DodajUzytkownika(); break;
                        case "2": DzialaniaNaSprzecie.DodajSprzet(); break;
                        case "3": DzialaniaNaSprzecie.WyswietlCalySprzet(); break;
                        case "4": DzialaniaNaSprzecie.WyswietlDostepnySprzet(); break;
                        case "5": DzialaniaWypozyczenia.WypozyczSprzet() ; break;
                        case "6": DzialaniaWypozyczenia.ZwrocSprzet(); break;
                        case "7": DzialaniaWypozyczenia.AktywneWypozyczeniaUzytkownika(); break;
                        case "8": DzialaniaWypozyczenia.PrzeterminowaneWypozyczenia(); break;
                        case "9": ProcesWypozyczenia.WyswietlRaport(); break;
                        case "0": dziala = false; break;
                        default: Console.WriteLine("Nieprawidłowa opcja."); break;
                    }
                }
            }
            
        }
    }
}