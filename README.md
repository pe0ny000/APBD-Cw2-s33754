Opis:
System pozwala dodawać użytkowników i sprzęt, wypożyczać go z walidacją dostępności, a także obsługiwać zwroty z automatycznym naliczaniem kary za opóźnienie w wysokości 1,5-krotności kosztu dziennego.
Dodatkwo można wyświetlać raport, listę całego (lub tylko dostępnego) sprzętu, aktywne wypożyczenia danego użytkownika, przeterminowane wypożyczenia.

SOLID:
Projekt stosuje zasady SOLID widoczne bezpośrednio w strukturze plików. Zasada pojedynczej odpowiedzialności (SRP) jest zachowana przez podział na osobne klasy:
DzialaniaNaSprzecie.cs, DzialaniaNaUzytkownikach.cs i DzialaniaWypozyczenia.cs, z których każda obsługuje interakcję konsolową wyłącznie swojej domeny. 
Zasada OCP jest widoczna w hierarchii sprzętu, dodanie nowego typu sprzętu wymaga jedynie stworzenia nowej klasy dziedziczącej po Sprzet.cs, bez modyfikacji istniejącego kodu. 
Zasada podstawienia Liskov (LSP) jest zachowana dzięki temu, że Laptop.cs, Camera.cs i Projektor.cs oraz Pracownik.cs i Student.cs mogą być używane wszędzie tam,
gdzie oczekiwane są ich klasy bazowe Sprzet i UzytkownikSprzetu. Zasada odwrócenia zależności (DIP) jest zrealizowana przez wstrzykiwanie list przez konstruktory klas w folderze ObslugaWypozyczen 
klasy nie tworzą własnych zależności, lecz otrzymują je z zewnątrz z Program.cs.
