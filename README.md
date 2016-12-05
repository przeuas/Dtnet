# Instrukcja do zadania

## Cel
Celem tego zadania jest zapoznanie się z pewnym sposobem projektowania aplikacji. 
Skupimy się na wykorzystaniu Entity Frameworka do komunikacji z bazą danych oraz 
zastosujemy Dependency Injection, które będzie używane w naszych repozytoriach, o czym słów kilka później.

## Wymagania wstępne
Aby zacząć wykonywać zadanie należy pobrać repozytorium na swój komputer.
Następnie należy otworzyć projekt i poczekać kilka chwil, aż Visual Studio pobierze wymagane pakiety z Nugeta.

## Opis projektu
W przygotowanym projekcie zostały skonfigurowane niezbędne moduły, z których będziemy korzystać. Jest to czasochłonne, dlatego taka decyzja.

### WebAPI
Projekt sam w sobie będzie dostawcą jedynie samego API. Oznacza to, że nie będziemy mieli interfejsu użytkownika. Jednak, aby ułatwić zadanie,
dołączony został dodatek, który będzie generował wszystkie publiczne wejścia do API. To, w jaki sposób z niego korzystać omówię bezpośrednio przy zadaniu.

### Entity Framework
W projekcie użyty został Entity Framework. Jest to jedna z najpopularniejszych bibliotek wspierająca aplikacje komunikające się z bazą danych.
Jest to biblioteka pozwalająca mapować obiekty bazodanowe na klasy po stronie C#. Ułatwia to niezwykle pracę i pozwala na utrzymanie jednolitej struktury, 
po stronie serwera bazy danych oraz po stronie aplikacji.

### Dependency Injection
Po polsku - wstrzykiwanie zależności - jest to wzorzec projektowy. Jego głównym zadaniem jest usunięcie bezpośrednich zależności w kodzie pomiędzy komponentami.
Zamiast tworzyć obiekty bezpośrednio (np. poprzez new) będziemy je wstrzykiwać do naszego kodu. Sprowadza się to do tego, że mamy w naszej
aplikacji pewien kontener (fabrykę), która dostarcza nam obiekty, które aktualnie potrzebujemy. W ten sposób, my mówimy co chcemy i to dostajemy.
Proces fizycznego tworzenia bytu odbywa się na zewnątrz (w fabryce). Dzięki temu, obiekt tworzony jest raz. Przy pierwszym odwołaniu. 
Przy kolejnych próbach będziemy dostawali już utworzony wcześniej obiekt.

Na potrzeby projektu skupimy się na wstrzykiwaniu jedynie kontekstu bazy danych oraz repozytoria.

### Repozytorium
Będziemy tak nazywać pewną klasę, która dostarczać będzie dane z bazy. Np. repozytorium o nazwie NewsRepository będzie dostarczało nam danych o newsach, które znajdują się fizycznie w tabelce News.

## Zadanie 1
Zadanie pierwsze polegać będzie na zapoznaniu się z projektem, WebAPI oraz uruchomieniem dokumentacji naszego API.

Zaczynamy!

Proszę uruchomić projekt w Visual Studio. Można to zrobić otwierając plik `ZadanieLaboratoryjneDotNet.sln`

> Aby uruchomić projekt należy przejść do menu:
> > Debug -> Start Debugging
  
Po pobraniu wszystkich pakietów, proszę przejść do kontrolera o nazwie News `src/Controllers/api/NewsController.cs`
  
Widzimy tutaj nasz pierwszy kontroler. Stworzyłem w nim dwie metody. Pierwsza z nich to metoda, która odpowiada na rządanie GET, które nie ma parametrów. Możemy założyć, że każda metoda naszego API będzie zwracała typ wyniku ActionResult a zwracać będziemy obiekt typu JsonResult. Do tego miejsca dostaniemy się wchodząc pod adres:
>/api/news

Dla nas ważnym elementem będzie atrybut znajdujący się nad metodą:
```csharp
[HttpGet]
```
Samo HttpGet oznacza, że metoda poniżej może być wywołana tylko rządaniem GET (bez parametrów). W przypadku, gdy chcemy dołożyć parametr dodatkowy, np. id (identyfikator), albo searcg (ciąg wyszukiwania) -> wtedy musimy skorzystać z nieco bardziej rozbudowanej wersji, którą widzimy w drugiej metodzie tego kontrolera.
```csharp
[HttpGet("{message}")]
public ActionResult MetodaParametryzowana(string message) {
  ...
}
```
W tym przypadku również akceptujemy tylko rządzanie GET, jednak wymagany jest parametr message. Parametr ten dodajemy w atrybucie HttpGet oraz jako parametr metody. Do takiej metody możemy się dostać z następującego adresu:
>/api/news/toJestNaszParametr

Analogicznie, w przypadku dwóch i więcej atrybutów:
```csharp
[HttpGet("{parametr1}/{parametr2}/{parametr3}")]
public ActionResult MetodaParametryzowana(string parametr1, string parametr2, int parametr3) {
  ...
}
```
Dostęp przez np.:
>/api/news/pierwszyParametr/drugiParametr/432

### Dostęp przez dokumentację
Dobrze, potrafimy już uruchomić nasze API ręcznie. Jednak - nie zawsze chcemy ręcznie tworzyć obiekty. Niekiedy jest to skomplikowane. 
Z pomocą przychodzą dodatki generujące dokumentację. W naszym projekcie użyłem Swagger UI. Aby go uruchomić należy uruchomić projekt a następnie przejść pod adres:
> /swagger/ui/index.html

Powinniśmy zobaczyć następujące okno:
![image](./instrukcja/swagger.png)

W tym miejscu możemy wybierać nasze kontrolery, a następnie przeglądać dostępne akcje (metody). Swagger podpowiada również jakie są dozwolone zapytania wejściowe i możemy je wykonać, co widać na zrzucie:
![image](./instrukcja/swagger-test-api.png)

W tym zadaniu zapoznaliśmy się z projektem, uruchomiliśmy nasze API i zrobiliśmy pierwsze rządanie. Teraz czas na bardziej praktyczną część...

## Zadanie 2
W tym zadaniu nauczymy się jak podpiąć nasze repozytorium do API w kontrolerze `NewsController`, aby pobierał dane z bazy.
