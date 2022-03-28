# Soft_Dev_Exam
Software Development 2022 exam solution - C# Windows Forms - (hungarian)

I.:
Project short description - Rövid leírás:

Készítsen Windows Forms alapú alkalmazást Visual C# segítségével egy alapvető épület felújítási
karbantartó alkalmazást, mely építész cégeknek segít a különböző felújítandó épületek kezelésében.
---------------------------------------------------------------------------------------

II.:
Project specification - Részletes leírás:

Minden felújítandó épületről a következő információkat tudjuk:

---------------------------------------------------------------------------------------
Epulet
---------------------------------------------------------------------------------------
Cím	
-string		-nem módosítható	-{nem lehet üres}

Alapterület
-integer	-módosítható		-{minimum 20}		-Mértékegység: nm

Építésianyag
-enum		-nem módosítható	-{tégla,panel,fa}	

Munkakezdés kezdete
-date		-módosítható		-{legalább a mai dátum}

Munkavégzés vége
-date		-módosítható		-{legalább a munkakezdés dátuma}

---------------------------------------------------------------------------------------

A programban alapvetően két különböző épület típus szeretnénk kezelni:
	-Családiház
	-Tömbház

---------------------------------------------------------------------------------------
Csaladihaz
---------------------------------------------------------------------------------------
Ottélők száma
-integer	-módosítható		-{minimum 1}		-Mértékegység: fő

Van-e garázs
-boolean	-módosítható		-{-}

Tető típusa
-enum		-módosítható		-{cserép,zsindely,nád}

---------------------------------------------------------------------------------------
Tombhaz
---------------------------------------------------------------------------------------
Lakások száma
-integer	-nem módosítható	-{minimum 1}		-Mértékegység: db

Lakásfenntartás típusa
-enum		-módosítható		-{egyéni,szövetkezet,társasház}

Van-e lift
-boolean	-nem módosítható	-{-}

---------------------------------------------------------------------------------------

III.:
Object functionality - Objektum funkcionalitás:

Oldja meg, hogy minden felújítandó épület rendelkezzen egy árkalkulációs lehetőséggel,mely egy becsült árat határoz meg a munkára!
1.
A családiházak esetében a számítás a következő:
	▪ Alapterület * Ottélők száma * 10000
A társasházak esetében a számítás a következő:
	▪ Alapterület * Lakások száma * 8000 + amennyiben nincs lift, 100000
2.
	a. Oldja meg, hogy minden objektum menthető legyen CSV formátumban!
	b. Oldja meg, hogy minden objektum betölthető legyen az előzőleg mentett CSV formátumból!
---------------------------------------------------------------------------------------

IV.:
User interface and functionality - Felhasználói felület és funkcionalitás:

1. Oldja meg, hogy a program bezáródásakor mentse ki az összes a programban szereplő objektumot a program mellé az „epuletek.csv” fájlba.
	a. Oldja meg, hogy a program a bezáródáskor kérdezze meg a felhasználót, hogy biztosan be akarja-e zárni a programot.
2. Oldja meg, hogy a programban fel lehessen vinni családi és társasházat a listavezérlőbe.
	a. A felvitelt egy külön ablak segítségével oldja meg.
	b. Általános épületre vonatkozó munkálatot nem lehet létrehozni a programban.
3. Oldja meg, hogy a programban lehessen törölni családiházat és társasházat.
	a. A törlés előtt kérdezzen rá a program a felhasználóra, hogy biztosan ki akarja-e törölni az adott objektumot.
4. Oldja meg, hogy a programban lehessen családi és társasházat módosítani.
5. Oldja meg, hogy bármely objektumon kattintva a Form-on jelenjen meg az adott épület előzetes árkalkulációja.
6. Oldja meg, hogy bármelyik objektumon duplán kattintva egy felugró ablakban (MessageBox) jelenjen meg az adott objektum általános épületekre vonatkozó összes adata (Cím, Alapterület, Építésianyag, Munkakezdés kezdete, Munkavégzés vége).
7. Oldja meg, hogy minden olyan épület, amelynek a Munkavégzés vége tulajdonsága az adott napon esedékes, akkor egy másik listavezérlőben megjelenik az adott épület.
	a. A feladat megoldása során feltételezheti, hogy a programot minden nap elindítják és még éjfél előtt be is zárják.
	b. Oldja meg, hogy ezen a listavezérlőn bármelyik elemen duplán kattintva, ugyancsak jelenjen meg felugró ablakban (MessageBox) az adott objektum általános épületekre vonatkozó összes adata.
8. Oldja meg, hogy a programban legyen lehetőség külön ablakban rendezett adatmegjelenítésre.
	a. A külön ablakban az összes épület egy listavezérlőben az alapterületük alapján növekvő sorrendben jelenjen meg!
---------------------------------------------------------------------------------------


