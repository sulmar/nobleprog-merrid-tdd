# Ćwiczenie TDD - Pompa paliwowa

## Wprowadzenie
W folderze _src/TestApp/Fundamentals_ znajduje się plik _Pump.cs_ z implementacją pompy paliwowej.

## Zadanie
Napisz testy jednostkowe dla funkcji _Start_, _Stop_ i _CalculateRefuelTime_. 
Upewnij się dzięki nim czy implementacja jest prawidłowa. 

## Wymagania
1. Metoda _Start_ powinna uruchamiać pompę tylko jeśli jest uziemiona. W innym przypadku powinna rzucać wyjątkiem _InvalidOperationException_.
2. Metoda _Stop_ powinna zatrzymać pompę bezwarunkowo.
3. Metoda _CalculateRefuelTime_ powinna obliczać tankowania na podstawie prędkości przepływu i wielkości tankowania.
4. Metoda _CalculateRefuelTime_ do obliczania czasu tankowania powinna rzucić wyjątkiem _OutOfRangeException_ jeśli ilość paliwa jest ujemna.

