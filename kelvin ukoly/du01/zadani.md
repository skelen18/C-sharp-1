# Zadání

Cílem je vytvořit konzolovou aplikaci v .NET 9, která bude načítat pole zaměstnanců z připraveného CSV souboru, nad tímto polem provede výpočty a filtrování definované dále v zadání a výsledek vypíše na standardní výstup (do konzole).

Cesta ke vstupnímu CSV souboru bude předána jako parametr při spuštění aplikace. Samotné načtení souboru proveďte pomocí tohoto kódu:

```csharp
string csv = File.ReadAllText(args[0]);
```

## Požadavky

- Vytvořte třídu `Employee`, která bude reprezentovat jednoho zaměstnance. Jednotlivé vlastnosti zaměstnance jsou následující:
  - **Jméno** – text.
  - **Věk** – celé číslo. Nemusí být vyplněn/uveden.
  - **Telefonní číslo** – struktura obsahující předčíslí země a národní číslo (viz níže v zadání). Nemusí být vyplněno/uvedeno.
  - **Příjem** – celé číslo.
  - **Zdali je aktivní** – logická hodnota. Nemusí být vyplněna/uvedena.
- Vytvořte metodu, které předáte obsah CSV souboru (text) a která bude vracet pole zaměstnanců. Uvnitř této metody implementujte parsování CSV a mapování jednotlivých řádků CSV na objekty. Parsování telefonního čísla proveďte pomocí metody z následujícího bodu zadání.
- Vytvořte metodu, které předáte telefonní číslo jako textový řetězec a která vám vrátí strukturu reprezentující telefonní číslo. Pokud se telefonní číslo nedá namapovat na strukturu (viz dále), vrátí tato metoda hodnotu `null`.

  Telefonní číslo může mít libovolnou délku a obsahovat pouze číslice a symbol `+`. Pokud bude číslo obsahovat jiné znaky, bude ignorováno, jako kdyby nebylo vyplněno. Struktura reprezentující telefonní číslo bude obsahovat předčíslí země (`string`), které odpovídá prvním čtyřem znakům telefonního čísla, ale pouze pokud telefonní číslo začíná symbolem `+`. Pokud nezačíná znaménkem plus, použijte předčíslí `+420`. Zbývající znaky čísla jsou národním číslem (druhá hodnota ve struktuře). Národní číslo bude uloženo jako `long`. Pokud telefonní číslo nezačíná symbolem `+`, je celé číslo národním číslem.
- Vytvořte metodu pro výpočet průměrného věku zaměstnanců. Této metodě bude předáno pole zaměstnanců a bude vracet jejich průměrný věk. Uvědomte si, že zaměstnanec nemusí mít uveden věk. V takovém případě jej ignorujte. Tato metoda bude zároveň vracet počet ignorovaných zaměstnanců jako výstupní parametr metody.
- Načtěte CSV, zavolejte metodu pro převod CSV na pole a pomocí připravené metody vypočtěte průměrný věk zaměstnanců. Následně do konzole vypište jejich průměrný věk a počet zaměstnanců s neznámým věkem.

  Na závěr vypište jméno a telefonní číslo zaměstnanců, kteří jsou aktivní, mají plat nad 30 000 a zároveň nemají předčíslí země telefonního čísla `+421`. Tuto podmínku splňují i zaměstnanci, kteří nemají uvedený telefon. Jméno a telefonní číslo budou odděleny symbolem `|`.
- V případě, že žádný zaměstnanec neodpovídá filtru, vypište hlášku:

  > Žádný zaměstnanec neodpovídá filtru.

## Užitečné metody

Pro vypracování se vám mohou hodit tyto metody:

- [`IndexOf`](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.indexof?view=net-9.0)
- [`Substring`](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.substring?view=net-9.0)
- [`IsNullOrEmpty`](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.isnullorempty?view=net-9.0)
- [`Split`](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.split?view=net-9.0)
- [`StartsWith`](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.startswith?view=net-9.0)
- [`TryParse`](https://learn.microsoft.com/cs-cz/dotnet/api/system.int64.tryparse?view=net-9.0)

## Testovací soubor

Pro otestování vaší implementace můžete použít tento [CSV soubor](https://csharp.janjanousek.cz/du/employees.csv).

Při čtení souboru si uvědomte, že existuje více možných oddělovačů řádků ([CRLF](https://developer.mozilla.org/en-US/docs/Glossary/CRLF)). CSV soubor může také končit prázdným řádkem, stále jde o validní CSV.

## Ukázkový výstup

```text
Průměrný věk: 42,833333333333336
Zaměstnanců s neznámým věkem: 2

Jan | +42012389725
Tomáš | +42072112312
Zuzana |
```

## Testy

### První test (`test0`)

Spuštění:

```sh
./main employees.csv
```

Vstupní soubor:

```text
Jméno;Věk;Telefon;Plat;Je aktivní
Jan;34;+42012389725;60000;ano
Tomáš;40;72112312;45000;ano
Lucie;;;24000;ano
Jiří;60;+421965245;85000;ne
Petra;;+4209875263;35000;
Zuzana;41;Samsung;66000;ano
Michal;28;+42086532471;100000;ne
Ondřej;54;+42198563611;36000;ano
```

Očekávaný výstup:

```text
Průměrný věk: 42.833333333333336
Zaměstnanců s neznámým věkem: 2

Jan | +42012389725
Tomáš | +42072112312
Zuzana |
```

### Druhý test (`test1`)

Vstupní soubor:

```text
Jméno;Věk;Telefon;Plat;Je aktivní
Michala;38;nemám;34000;ne
Lucie;;;24000;ano
Petra;;+4209875263;35000;
Tadeáš;21;+421965945;42000;ano
Michal;28;+42086532471;100000;ne
```

Očekávaný výstup:

```text
Průměrný věk: 29
Zaměstnanců s neznámým věkem: 2

Žádný zaměstnanec neodpovídá filtru.
```

### Třetí test (`test2`)

Vstupní soubor:

```text
Jméno;Věk;Telefon;Plat;Je aktivní
Jan;;+42012389725;60000;ano
Tomáš;;72112312;45000;ano
Lucie;;;24000;ano
Jiří;;+421965245;85000;ne
Petra;;+4209875263;35000;
Zuzana;;Samsung;66000;ano
Michal;;+42086532471;100000;ne
Ondřej;;+42198563611;36000;ano
```

Očekávaný výstup:

```text
Průměrný věk:
Zaměstnanců s neznámým věkem: 8

Jan | +42012389725
Tomáš | +42072112312
Zuzana |
```
