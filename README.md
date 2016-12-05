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

