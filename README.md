# BibleGenerator (BibleParaphraser)

**BibleGenerator** je nástroj vytvořený jako bakalářská práce na MFF UK, který slouží k modernizaci biblického textu pomocí metod z oblasti zpracování přirozeného jazyka (NLP). Projekt využívá model **Word2Vec** k hledání významově blízkých slov a **MorphoDiTa** k morfologické analýze. Aplikace má grafické rozhraní ve Windows Forms.



## Funkce programu

1. **Načtení Word2Vec modelu**  
   Možnost načíst předtrénovaný model nebo spustit vlastní trénink (`TrainNewModel`).

2. **Zpracování biblického textu**  
   Načítá vstupní text (formát `.txt`), například ve starobylém jazyce.

3. **Morfologická analýza (MorphoDiTa)**  
   Zjišťuje základní tvary a gramatické vlastnosti slov.

4. **Hledání významově podobných slov (Word2Vec)**  
   Pro každé slovo hledá moderní ekvivalenty zachovávající význam.

5. **Parafrázování textu**  
   Nahrazuje archaická nebo nesrozumitelná slova jejich moderními protějšky.

6. **Grafické rozhraní (WinForms)**  
   Umožňuje interaktivní zpracování textu a práci s modelem.



## Projektová struktura

### Řešení

- `BiblickyGenerator.sln` – hlavní Visual Studio řešení.

### Hlavní projekt: `BiblickyGenerator`

#### UI komponenty (`*.Designer.cs`, `*.resx`)

- `Inline_paraphrasing`  
- `Menu`  
- `TrainNewModel`  
- `ReadCount`  
- `Word2VecModelCreate`  

-> Zajišťují interaktivní práci s aplikací (načítání modelů, výběr textů, trénink).

#### Jádro aplikace

| Soubor | Popis |
|--------|-------|
| `Program.cs` | Vstupní bod aplikace |
| `Word2Vec.cs` | Obsluha Word2Vec modelu (využívá `Word2Vec.Net.dll`) |
| `TransformTXTFile.cs` | Transformace biblického textu |
| `MorphoDiTa.cs` | Napojení na knihovnu MorphoDiTa (morfologická analýza) |
| `ParaphraseText.cs` | Logika pro nahrazování slov na základě Word2Vec |
| `DirectoryManager.cs` | Správa vstupních/výstupních souborů a adresářů |
| `Window.cs` | Hlavní okno aplikace nebo řídící logika |



## Požadavky

- .NET Framework (verze dle projektu)
- Word2Vec.Net knihovna
- (Volitelně) MorphoDiTa knihovna od ÚFALu



## Licence

Tento projekt je určen pro studijní účely. Případné další použití konzultujte s autorem.



## Autor

Ondřej Michálek  
[Tricerator on GitHub](https://github.com/Tricerator)
