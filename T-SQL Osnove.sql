/*=====================================================================================================
==================================Transact-SQL Osnove==================================================
=======================================================================================================*/
USE master; /*ulazimo u master*/
GO
CREATE DATABASE baza;/*pravimo bazu podataka*/
GO
USE baza; /*ulazimo u tu bazu*/
GO
CREATE TABLE tabela /*pravimo tabelu u toj bazi*/
{
    ID INT IDENTITY(1,1)NOT NULL,/*-------------NOT NULL ZNACI DA NE MOZE DA BUDE PRAZNO NEGO DA MORA DA SE POPUNI*/
    /*-------------IDENTITY(1,1) ZNACI DA CE SVAKI PODATAK IMATI RAZLITI ID koji krece od 1 pa se povecava za 1*/
    Ime CHAR(50)
}
GO

DROP TABLE tabela;/*brisemo tabelu*/

ALTER TABLE tabela/*menjamo tabelu*/
ADD Prezime CHAR(40);
GO
/*=======================================================================================================
------------------------------PRIMARY/FOREIGN KEY--------------------------------------------------------
=========================================================================================================*/
CREATE TABLE tabela1
{
    tabelajedanID INT NOT NULL PRIMARY KEY /*ovako definisemo primarni kljuc ako u tabeli postoji samo jedan primarni kljuc*/
};
GO
CREATE TABLE  tabela2
{
    tabeladvaID INT NOT NULL PRIMARY KEY
};
GO
CREATE TABLE tabela3
{
    tabelatriID INT NOT NULL,
    tabeladvaID INT NOT NULL,
    tabelajedanID INT NO NULL
    PRIMARY KEY(tabelatriID,tabeladvaID,tabelajedanID) /*ovako definisemo ako imamo vise primarnih kljuceva*/
    CONSTRAINT ime_spoja FOREIGN KEY(tabeladvaID) /*pravimo ogranicenje tako sto povezujemo strani kljuc iz ove tabele*/ 
    REFERENCES tabela2(tabeladvaID)/*sa primarnim kljucem iz glavne tabele*/
    CONSTRAINT ime_spoja2 FOREIGN KEY(tabelajedanID)/*pravimo ogranicenje tako sto povezujemo strani kljuc iz ove tabele*/ 
    REFERENCES tabela2(tabelajedanID)/*sa primarnim kljucem iz glavne tabele*/
};
GO
ALTER TABLE tabela3/*ili mozemo na ovaj nacin pomocu alter table-a*/
ADD CONSTRAINT tabelatri_tabeladva FOREIGN KEY(tabeladvaID)
REFERENCES tabela2(tabeladvaID);
GO
/*=======================================================================================================
------------------------------INSERT INTO,UPDATE,DELETE--------------------------------------------------
=========================================================================================================*/
CREATE DATABASE baza;
GO
USE baza;
CREATE TABLE clan
{
    Clan_ID INT IDENTITY(1,1) PRIMARY KEY,
    Prezime CHAR(30),
    Ime CHAR(30),
    Telefon CHAR(30) 
};
GO
INSERT INTO clan 
{podaci.....}/*ovako unosimo ako hocemo po redosledu kako smo definisali bazu ali posto imamo auto increment(IDENTITY(1,1)) 
to ne moze sada raditi zato sto on sam upisuje vrednost tako da mi ne bismo smeli*/
INSERT INTO clan(Prezime,Ime,Telefon) /*ovako unosimo ako hocemo mi da menjamo redosled kako cemo unositi podatke*/
VALUES ('Popovic','Marija','52343634643')
('Trifunovic','Dusan','636436363634');
GO

INSERT INTO clan(Ime) /*mozemo uneti npr. samo ime*/
VALUE('Marija');
GO
/*ako hocemo izmeniti neki podatak u tabeli to radimo pomocu UPDATE pa ime tabele*/
UPDATE clan
SET Prezime = 'Brankovic' WHERE Prezime = 'Popovic';/*stavi Prezime 'Brankovic' tamo gde je Prezime 'Popovic'*/
GO
UPDATE clan
SET Telefon = '252345353' WHERE Ime = 'Marija'; /*stavi Telefon 252345353 tamo gde je Ime 'Marija'*/
GO
/*=======================================================================================================
------------------------------SELECT---------------------------------------------------------------------
=========================================================================================================*/
/*SELECT sluzi kako bismo filtrirali podatke iz tabele i prikali ih*/
SELECT * FROM clan; /*ova zvezdica znaci da ce prikazati sve podatke iz tabele clan*/
SELECT * FROM baza2.dbo.nesto;/*ovako selektujemo zapise iz tabele clan koja je u drugoj bazi 'baza2'*/
SELECT * FROM clan ORDER BY godina_rodjenja;/*ovo ce selektovati podatke iz tabele clan i sortirati po godini rodjenja(od najstarijeg odnosno od najvece vrednosti)*/
SELECT Prezime,Ime FROM clan;/*ovo ce selektovati Prezime i Ime iz tabele clan*/

/*ORDER BY*/
SELECT Prezime,Ime FROM clan ORDER BY Ime;/*ovo ce selektovati Prezime i Ime iz tabele clan i sortirace ih po imenu odnosno od A do Z*/
SELECT Prezime,Ime FROM clan ORDER BY Ime DESC;/*ovo ce selektovati Prezime i Ime iz tabele clan i sortirace ih po imenu ali ovaj put obrnuto od Z do A*/

/*DISTINCT*/
SELECT DISTINCT Ime FROM clan; /*prikazace samo razlicata imena u tabeli, odnosno nece prikazati duplikate*/

/*TOP*/
SELECT TOP 5 * FROM clan; /*prikazace prvih 5 iz tabele clan*/
SELECT TOP 50 PERCENT * FROM clan; /*prikazace 50 posto tabele*/

/*Alias*/
SELECT Prezime + Ime AS Covek FROM clan ORDER BY Prezime; /*napravice novu kolonu u kojoj ce biti Prezime i Ime i sortirace po Prezimenu*/

/*WHERE*/
SELECT Ime, Prezime FROM clan WHERE Plata = 150000 /*prikazace Ime i Prezime clanova koji imaju platu 150000 */
SELECT Ime, Prezime FROM clan WHERE Plata != 150000 /*prikazace Ime i Prezime clanova koji nemaju platu 150000 */
SELECT Ime + Prezime AS BogatiLikovi WHERE Plata > 150000 /*prikazace novu kolonu BogatiLikovi gde ce biti Ime i Prezime clanova koji ima platu vecu od 150000*/

/*AND*/
SELECT Ime + Prezime AS BogatiLikovi WHERE Plata > 150000 AND godina_rodjenja < 2000
/*prikazace novu kolonu BogatiLikovi gde ce biti Ime i Prezime clanova koji ima platu vecu od 150000 i koji su stariji od 2000. godine*/

/*OVO JE BILO AKO SU TIPOVI PODATAKA CHAROVI TADA IH SAMO SPAJAMO DOK AKO SU INT*/
SELECT prodajna-nabavna from cene; /*prikazace nam razliku prodajne i nabavne cene iz neke tabele cene*/
SELECT bruto, bruto*10/100 AS porez FROM nekatamotabela; /*prikazace nam bruto i novu kolonu porez koja ima vrednost bruto*10/100*/

/*=======================================================================================================
------------------------------STRINGOVI------------------------------------------------------------------
=========================================================================================================*/
/*CONCAT - sluzi za povezivanje stringova*/
SELECT Clan_ID, CONCAT(Prezime,Ime) AS COVEK FROM clan; /*povezao je stringove odnosno Prezime i Ime u novu kolonu COVEK*/

/*Isto to smo mogli da napisemo na ovaj nacin*/
SELECT Clan_ID, Prezime + Ime AS COVEK FROM Clan; 

/*CONCAT ce INT-ove da pretvori u stringove*/
SELECT CONCAT(Prezime, 'i',Ime,'ima platu', 100000+20000) AS Covek FROM clan WHERE godina_rodjenja < 1990;

/*STR pretvara brojne vrednosti u string*/
SELECT STR(Clan_ID) FROM Clan;
SELECT STR(Clan_ID) + STR(Telefon) FROM clan;
SELECT CONCAT(STR(Clan_ID) + STR(Telefon)) FROM clan;

/*CHARINDEX trazi poziciju prvog pojavljivanja karaktera*/
/*CHAINDEX(karakter,gde pretrazujemo,od koje pozicije)*/
SELECT CHARINDEX('A',Ime) FROM clan; /*trazi poziciju karaktera 'A' u koloni Ime iz tabele clan*/
SELECT CHARINDEX('A',Ime,2) FROM clan; /*trazi poziciju karaktera 'A' u koloni Ime iz tabele clan ali pocinje od pozicije 2*/

/*LEN vraca broj karaktera u stringu/brojne vrednosti kao i ostale vrednosti koje nisu string pretvara u string i onda broji broj karaktera*/
SELECT LEN(Ime) FROM clan;

/*UPPER - pretvara string u string sa velikim slovima*/
SELECT UPPER(Ime) FROM clan;

/*LOWER - pretvara string u string sa malim slovima*/
SELECT LOWER(Ime) FROM clan;

/*STUFF- ubacuje string u string*/
/*STUFF(gde ubacujemo,od kog mesta pocinjemo, koliko karaktera brisemo, sta ubacujemo*/
SELECT STUFF(Ime,2,0,'-OVO SMO DODALI-')/*ako je ime Simic picanje 'S -OVO SMO DODALI-imic'*/

/*REPLACE - menja string*/
/*REPLACE(gde menjamo, sta menjamo, cime menjamo)*/
SELECT REPLACE(Ime,'Goran','Zoran') /*Tamo gde je Goran stavice Zoran*/
/*=======================================================================================================
------------------------------Numericke funckije---------------------------------------------------------
=========================================================================================================*/
/*ABS - vraca apsolutnu vrednost*/
SELECT ABS(-35.2) /*vraca broj 35.2*/
SELECT ABS(315 - 82*8)/*jednako -341 ali vratice nam 341*/

/*CEILING - zaokruzuje na vecu celobrojnu vrednost*/
SELECT CEILING(32.08) /*vraca broj 33*/

/*FLOOR - zaokruzuje na manju celobrojnu vrednost*/
SELECT FLOOR(32.08) /*vraca broj 32*/

/*POWER - vraca broj na neki stepen*/
/*POWER(broj,stepen)*/
/*
    Tipovi podatak na ulazu ---------------> sta vraca
    --------------------------------------------------
    float,real                               float
    decimal(p,s)                             decimal(38,s)
    int,smallint,tinyint                     int
    bigint                                   bigint
    money,smallmoney                         money
    bit, char, nchar, varchar, nvarchar      float
*/
SELECT POWER(2,3)/*int,int*/  /* vraca broj 8(int)*/
SELECT POWER(2,3.6)/*int,float*/ /*vraca 12(int)*/
SELECT POWER(2.00,3.6)/*float,float*/ /*vraca 12.13(float)*/

/*SQUARE - vraca kvadrat nekog broja*/
SELECT SQUARE(8) /*vraca broj 64*/
SELECT SQUARE(8.52) /*vraca broj 72.5904*/

/*SQRT - vraca kvadratni koren*/
SELECT SQRT(64) /*vraca 8*/
SELECT SQRT(72.5904) /*vraca 8.52*/

/*RAND - nasumicna vrednost*/
/*RAND(seed)*//*seed je celobrojni izraz koji daje neku vrednost, a ako on nije naveden SQL Server Database Engine ce da mu nasumicno dodeli vrednost,te je vraceni rezultat uvek isti*/
SELECT RAND()/*vraca nasumicnu vrednost od 0 do 1*/
SELECT RAND(1)/*vraca vrednost seed-a 1 i to 0,713591993212924*/
SELECT RAND(3)/*vraca vrednost seed-a 3 i to 0,71362925915544*/
SELECT RAND() * 100 /*vraca nasumicnu vrednost od 0 do 100*/

/*ROUND - zaokruzuje vrednost*/
/*ROUND(broj,duzina) ili ROUND(broj,duzina,funkcija) ili ROUND(broj,duzina[,funkcija])*/
/*ako je duzina > 0 gleda desno od decimalne tacke, a ako je duzina < 0 gleda levo od decimalne tacke*/
SELECT ROUND(325.768, 1)/*zaokruzuje na jednu decimalu tako da vraca 325.800*/
SELECT ROUND(325.768, 2)/*zaokruzuje na dve decimale tako da vraca 325.770*/
SELECT ROUND(325.768, 1, 1)/*odsece, da ostane 1 decimala tako da vraca 325.700*/
SELECT ROUND(325.768, 2, 1)/*odsece, da ostanu dve decimale tako da vraca 325.760*/
SELECT ROUND(325.768, -1) /*zaokruzuje jedno mesto ulevo od decimalne tacke tako da vraca 330.000*/
SELECT ROUND(325.768, -1) /*zaokruzuje dva mesta ulevo od decimalne tacke tako da vraca 300.000*/
/*=======================================================================================================
------------------------------Datumske funckije----------------------------------------------------------
=========================================================================================================*/
SELECT GETDATE() /*vraca trenutno vreme ali kao vrednost tipa DATETIME*/
SELECT SYSDATETIME() /*vraca trenutno vreme ali kao vrednost tipa DATETIME2*/
/*DATEDIFF - vraca razliku uzmedju 2 datuma u datom intervalu(day,month,year...)*/
/*DATEDIFF(interval, prvi datum, drugi datum*/
SELECT DATEDIFF(day,'2021-09-15','2021-11-24') /*vraca razliku u danima odnosno u ovom slucaju 70*/
SELECT DATEDIFF(month,'2021-09-15','2021-11-24') /*vraca razliku u mesecima odnosno u ovom slucaju 2*/
SELECT DATEDIFF(year,'2021-09-15','2021-11-24') /*vraca razliku u godinama odnosno u ovom slucaju 0*/
/*DATEPART - vraca deo datuma koji oznacavamo prvim argumentom*/
/*DATEPART(interval,datum)*/
SELECT DATEPART(day, '2021-09-15') /*vraca dan odnosno u ovom slucaju 15*/
SELECT DATEPART(month, '2021-09-15') /*vraca mesec odnosno u ovom slucaju 9*/
SELECT DATEPART(year, '2021-09-15') /*vraca godinu odnosno u ovom slucaju 2021*/
/*=======================================================================================================
------------------------------Agregatne funckije----------------------------------------------------------
=========================================================================================================*/
/*
COMING SOON....
*/