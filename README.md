Program:

1. Načte předtrénovaný Word2Vec model, případně umožní jeho trénink (TrainNewModel).
2. Načte vstupní biblický text (pravděpodobně ve formátu .txt).
3. Pomocí morfologické analýzy (MorphoDiTa) zjistí základní tvary slov a jejich gramatické kategorie.
4. Najde významově blízká slova pomocí Word2Vec.
5. Parafrázuje (nahrazuje) starší, archaická nebo neobvyklá slova modernějšími ekvivalenty.
6. Umožní uživateli interaktivní práci s textem přes grafické rozhraní (WinForms).

Řešení (BiblickyGenerator.sln): Hlavní soubor řešení pro Visual Studio.

Hlavní projekt (BiblickyGenerator):
  
  UI komponenty (*.Designer.cs, *.resx):
    
    *Inline_paraphrasing*, *Menu*, *TrainNewModel*, *ReadCount*, *Word2VecModelCreate* 
    
                – okna, která zajišťují interaktivní práci s aplikací (např. načítání modelu, výběr textů).

  Jádro aplikace:
    *Program.cs*: vstupní bod aplikace.
    
    *Word2Vec.cs*: obsluha Word2Vec modelu (pravděpodobně zabaleno přes .dll knihovnu Word2Vec.Net.dll).
    
    *TransformTXTFile.cs*: transformace textu – zde se pravděpodobně odehrává hlavní modernizace textu.
    
    *MorphoDiTa.cs*: napovídá použití knihovny MorphoDiTa od ÚFALu pro morfologickou analýzu (např. lemmatizaci).
    
    *ParaphraseText.cs*: soubor odpovídající za samotné parafrázování (pravděpodobně nahrazuje stará slova novými pomocí Word2Vec).
    
    *DirectoryManager.cs*: práce se souborovým systémem (načítání/schovávání textů, modelů apod.).
    
    *Window.cs*: možná hlavní řídící logika nebo centrální formulář aplikace.
