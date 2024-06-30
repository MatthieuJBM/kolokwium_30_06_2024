Gr 1

Zaimplementuj API w NET CORE. Metody do zaimplementowania GET, GET By Id, POST, PUT, DELETE

1 Controller Drużyna Piłkarska: metody (GET, GET by id, POST, PUT, DELETE)

Encja: Id, Nazwa, Aktywny. ( np, Polska, Francja)

2 Controller Mecz: metody (GET, GET by id, POST, PUT, DELETE)

Encja Mecz:

Id, Nazwa rozgrywki,DruzynaId, Druzyna2Id, Data meczu, Godzina meczu od, Godzina meczu do,  Anulowany meczy (wartośći 0 lub 1)

- Każdy mecz można usunąć  jezeli data meczu jest większa niz aktualna .

- Dodanie nowego meczu walidacja:

  Godzina od nie może być większa od Godziny do.

Nie mozna dodac meczu , gdzie jedna z drużym ma mecz już dodany  miedzy datą i godziną od/do.