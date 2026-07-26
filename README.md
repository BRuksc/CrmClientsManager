# CRM Clients Manager

Prosta aplikacja CRM do zarządzania klientami, kontraktami oraz zgłoszeniami serwisowymi dla firmy z branży energetycznej.

## Technologie

- C#
- .NET
- Windows Forms
- MSSQL
- ADO.NET
- xUnit
- Moq

## Architektura

Aplikacja została podzielona na warstwy:
UI, Application, Infrastructures i MSSQL (procedury).


### UI

Odpowiada za:
- formularze Windows Forms,
- obsługę interakcji użytkownika,
- prezentację danych.

### Application

Zawiera:
- logikę biznesową,
- walidację danych wejściowych,
- operacje wykonywane przez użytkownika.

### Infrastructure

Odpowiada za:
- dostęp do danych,
- implementację repozytoriów,
- komunikację z MSSQL,
- wykonywanie procedur składowanych.

## Funkcjonalności

## Customers

Obsługiwane funkcje:

- wyświetlanie klientów,
- dodawanie klientów,
- edycja klientów,
- usuwanie klientów,
- walidacja danych wejściowych.

Obsługiwane pola:

- nazwa,
- NIP,
- adres,
- email,
- telefon,
- typ klienta.

## Contracts

Obsługa kontraktów klientów:

- relacja klient -> wiele kontraktów,
- przechowywanie informacji o kontrakcie,
- walidacja konfliktów aktywnych kontraktów.

## Tickets

Obsługa zgłoszeń serwisowych:

- tworzenie zgłoszeń,
- wyświetlanie otwartych zgłoszeń,
- zamykanie zgłoszeń.

Dane zgłoszenia:

- temat,
- opis,
- priorytet,
- status,
- data utworzenia,
- data zamknięcia,
- komentarz rozwiązania.

## Dashboard

Dashboard prezentuje:

- liczbę aktywnych klientów,
- liczbę kontraktów wygasających w ciągu 30 dni,
- liczbę otwartych zgłoszeń według priorytetu.

## Dostęp do danych

Aplikacja wykorzystuje ADO.NET oraz procedury składowane MSSQL.

Repozytoria odpowiadają za komunikację z bazą danych.

Wykorzystywane operacje:

- pobieranie danych,
- dodawanie rekordów,
- aktualizacja danych,
- usuwanie danych,
- wykonywanie operacji biznesowych.

## Obsługa wyjątków

Zastosowano centralny mechanizm obsługi wyjątków poprzez klasę Executor.

Odpowiada on za:

- przechwytywanie wyjątków SQL,
- obsługę błędów infrastruktury,
- bezpieczne przekazywanie komunikatów do warstwy UI.

## Uruchamianie

Aby poprawnie uruchomić aplikację należy wykonać wszystkie skrypty z katalogu Database\Scripts.
Jako pierwszy powinien być wykonany skrypt do inicjalizacji bazy danych.

Wykonać skrypty znajdujące się w katalogu:
