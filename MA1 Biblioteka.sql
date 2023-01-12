CREATE DATABASE MA1;
GO
USE MA1;
GO
CREATE TABLE Autor
(
    AutorID INT PRIMARY KEY IDENTITY(1,1),
    Ime CHAR(30) NOT NULL,
    Prezime CHAR(30) NOT NULL,
    DatumRodjenja DATE  NOT NULL,
    Adresa CHAR(30) NOT NULL,
    Zvanje CHAR(30) NOT NULL
);
GO
CREATE TABLE Knjiga
(
    KnjigaID INT PRIMARY KEY IDENTITY(1,1),/*nema ovamo identity*/
    UDK CHAR(15) NOT NULL,
    ISBN CHAR(13) NOT NULL,
    Naziv CHAR(30) NOT NULL
);
GO
CREATE TABLE Napisali
(
    AutorID INT NOT NULL,
    KnjigaID INT NOT NULL
    PRIMARY KEY(AutorID, KnjigaID)
    CONSTRAINT napisali_autor FOREIGN KEY(AutorID) 
    REFERENCES Autor(AutorID),
    CONSTRAINT napisali_knjiga FOREIGN KEY(KnjigaID) 
    REFERENCES Knjiga(KnjigaID)
);
GO
CREATE TABLE Citalac
(
    CitalacID INT PRIMARY KEY IDENTITY(1,1),
    MaticniBroj CHAR(13) NOT NULL,
    Ime CHAR(30) NOT NULL,
    Prezime CHAR(30) NOT NULL,
    Mesto CHAR(30) NOT NULL,
    Adresa CHAR(30) NOT NULL,
    Telefon CHAR(15) NOT NULL
);
GO
CREATE TABLE Na_Citanju
(
    KnjigaID INT NOT NULL,
    CitalacID INT NOT NULL,
    DatumUzimanja DATE NOT NULL,
    DatumVracanja DATE,
    PRIMARY KEY(KnjigaID,CitalacID,DatumUzimanja),
    CONSTRAINT Na_Citanju_Knjiga FOREIGN KEY(KnjigaID) 
    REFERENCES Knjiga(KnjigaID),
    CONSTRAINT Na_Citanju_Citalac FOREIGN KEY(CitalacID) 
    REFERENCES Citalac(CitalacID)
);
GO
CREATE TABLE Izdavac
(
    IzdavacID INT PRIMARY KEY IDENTITY(1,1),/*nema ovamo identity*/
    NazivIzdavaca CHAR(30) NOT NULL,
    Adresa CHAR(30) NOT NULL
);
GO
CREATE TABLE Izdali
(
    IzdavacID INT NOT NULL,
    KnjigaID INT NOT NULL,
    Godina INT NOT NULL,
    PRIMARY KEY(IzdavacID,KnjigaID),
    CONSTRAINT Izdali_Izdavac FOREIGN KEY(IzdavacID) 
    REFERENCES Izdavac(IzdavacID),
    CONSTRAINT Izdali_Knjiga FOREIGN KEY(KnjigaID) 
    REFERENCES Knjiga(KnjigaID)
);
GO
INSERT INTO Autor(Ime,Prezime,DatumRodjenja,Adresa,Zvanje)
VALUES('Mirko','Markovic','1999-12-06','Neka tamo budjava 1','Pisac'),
('Aleksa','Jankovic','1989-01-12','Marka Petrovica 2','Pesnik'),
('Nemanja','Petrovic','2005-02-06','Kralja Petra 15','Pisac');
GO
INSERT INTO Knjiga(UDK,ISBN,Naziv)
VALUES('64363463','643634643264','Budjava Knjiga'),
('745754745','342942384092','Najjaca Knjiga'),
('346364643','7457457423','Dosadna Knjiga');
GO
INSERT INTO Napisali
VALUES(1,2),
(2,3),
(3,1);
GO
INSERT INTO Citalac(MaticniBroj,Ime,Prezime,Mesto,Adresa,Telefon)
VALUES('5352535232323','Marko','Petrovic','Smederevo','neka tamo 1','0616234234'),
('5352535232323','Milos','Jankovic','Beograd','neka tamo 2','0616234234'),
('5352535232323','Nikola','Simic','Pozarevac','neka tamo 3','0616234234');
GO
INSERT INTO Na_Citanju
VALUES(1,2,'2006-12-06','2022-05-03'),
(2,3,'2016-01-02','2022-05-03'),
(3,1,'2020-03-23','2022-06-07'),
(1,1,'2006-12-06',NULL);
GO
INSERT INTO Izdavac(NazivIzdavaca,Adresa)
VALUES('NekiTamoLik','fsafsfaf'),
('NekiTamoDrugiLik','hfdhdfhdfh'),
('NekiTamoTreciLik','asdaggsgesg');
GO
INSERT INTO Izdali
VALUES (1,2,2005),
(2,3,2016),
(3,1,2)
/*Prikazati Ime i Prezime Autor, Ukupan broj iznajmljivanja njegovih dela u poslednjih @G godina i za one autore ciji je ukupan broj iznajmljivanja najmanje@P*/
CREATE PROCEDURE prvi @g INT, @p INT
AS
BEGIN
	SELECT ime,prezime,(SELECT COUNT(*) FROM Na_Citanju AS N 
	LEFT JOIN Knjiga K ON N.KnjigaID = K.KnjigaID 
	LEFT JOIN Napisali NAP ON NAP.KnjigaID = K.KnjigaID 
	WHERE DATEPART(year,N.DatumUzimanja) >= @g AND NAP.AutorID = A.AutorID) 
	FROM Autor A 
	WHERE (SELECT COUNT(*) FROM Na_Citanju N 
	LEFT JOIN Knjiga K on N.KnjigaID = K.KnjigaID
	LEFT JOIN Napisali AS NAP ON NAP.KnjigaID = K.KnjigaID WHERE NAP.AutorID = A.AutorID) >= @P;
END
EXEC prvi 2006, 1
/*Prikazati Citalac ID, Ime, Prezime, Knjiga ID, Naziv Knjige, Datum Uzimanja, za knjige koje nije vratio pri cemu je Citalac ID parametar*/
CREATE PROCEDURE drugi @id INT
AS
BEGIN
	SELECT @id AS id_citaoca, ime, prezime, K.KnjigaID, K.Naziv, DatumUzimanja FROM Na_Citanju AS N 
	LEFT JOIN Citalac AS C ON C.CitalacID = @id 
	LEFT JOIN Knjiga K ON K.KnjigaID = N.KnjigaID
	WHERE DatumVracanja IS NULL AND C.CitalacID = n.CitalacID
END
EXEC drugi 1
/*Prikazati Citalac ID, Ime, Prezime, Broj nevracenih knjiga sortirano po broju nevracenih knjiga(opadajuce) za citaoce koji imaju vise od @P nevracenih knjiga*/
CREATE PROCEDURE treci @p INT
AS
BEGIN 
	SELECT C.CitalacID, ime ,prezime, COUNT(*) FROM Na_Citanju AS N 
	LEFT JOIN Citalac AS C ON C.CitalacID = N.CitalacID
	WHERE N.DatumVracanja IS NULL
	GROUP BY C.CitalacID, ime ,prezime HAVING COUNT(*) > @p
	ORDER BY COUNT(*)
END
EXECUTE treci 0
/*Prikazati podatke o citaocima koji su procitali sve knjige kojima raspolaze biblioteka od autora cije su ime i prezime parametri*/
CREATE PROCEDURE cetvrti @ime CHAR(30), @prezime CHAR(30)
AS
BEGIN
	SELECT * FROM Citalac C WHERE(SELECT COUNT(*) FROM Na_Citanju AS N WHERE N.CitalacID = c.CitalacID) = (SELECT COUNT(*) FROM KNJIGA) 
	AND C.Ime = @ime AND C.Prezime = @prezime
END
EXECUTE cetvrti 'Aleksa','Jankovic'
/*Prikazati podatke o citaocima koji nisu procitali nijednu knjigu kojima raspolaze biblioteka od autora cije su ime i prezime parametri*/



/*NAPISATI STORED PROCEDURE ZA SLEDECE UPITE*/
/*1. PRIKAZATI PODATKE O IZDAVACIMA(IZDAVACID I NAZIV IZDAVACA) za sve izdavace koji su izdali knjigu sa odgovarajucim naslovom koji se zadaje kao parametar*/
CREATE PROCEDURE O_IZDAVACIMA @Naslov CHAR(30)
AS
BEGIN
	SELECT I.IzdavacID, I.NazivIzdavaca FROM Izdavac AS I 
	LEFT JOIN Izdali AS Iz ON I.IzdavacID = Iz.IzdavacID 
	LEFT JOIN Knjiga AS K ON K.KnjigaID = Iz.KnjigaID WHERE Naziv = @Naslov
END
EXECUTE O_IZDAVACIMA 'Budjava Knjiga'
/*2. PRIKAZATI PODATKE O CITAOCIMA(IME, PREZIME I TELEFON) za one citaoce koji su procitali sva dela pisca cije su ime i prezime parametri*/
/*SELECT C.Ime,C.Prezime,C.Telefon FROM Citalac AS C WHERE C.CitalacID =
(SELECT C.CitalacID FROM Citalac AS C
LEFT JOIN Na_Citanju AS Na ON C.CitalacID = Na.CitalacID
LEFT JOIN Knjiga AS K ON Na.KnjigaID = K.KnjigaID 
LEFT JOIN Napisali AS NAP ON K.KnjigaID = NAP.KnjigaID 
LEFT JOIN Autor AS A ON NAP.AutorID = A.AutorID WHERE A.Ime = 'Mirko' AND A.Prezime = 'Markovic') AND
(SELECT CitalacID FROM Na_Citanju AS Na 
LEFT JOIN Knjiga AS K ON Na.KnjigaID = K.KnjigaID 
LEFT JOIN Napisali AS NAP ON K.KnjigaID = NAP.KnjigaID 
LEFT JOIN Autor AS A ON NAP.AutorID = A.AutorID WHERE A.Ime = 'Mirko' AND A.Prezime = 'Markovic') =
(SELECT COUNT(*) FROM Knjiga AS K 
LEFT JOIN Napisali AS NAP ON K.KnjigaID = NAP.KnjigaID 
LEFT JOIN Autor AS A ON NAP.AutorID = A.AutorID WHERE A.Ime = 'Mirko' AND A.Prezime = 'Markovic')*/
/*3. PRIKAZATI IME I PREZIME AUTORA, GODINU IZNAJMLJIVANJA KNJIGE, BROJ IZNAJMLJIVANJA KNJIGA TOG AUTORA U GODINI 
za poslednjih @n godina i za autore cije su knjige izdavane najmanje @x puta*/
CREATE PROCEDURE POSLEDNJIH_GODINA @g INT, @p INT
AS
BEGIN
	SELECT ime,prezime,(SELECT COUNT(*) FROM Na_Citanju AS N 
	LEFT JOIN Knjiga K ON N.KnjigaID = K.KnjigaID 
	LEFT JOIN Napisali NAP ON NAP.KnjigaID = K.KnjigaID 
	WHERE DATEPART(year,N.DatumUzimanja) >= @g AND NAP.AutorID = A.AutorID) 
	FROM Autor A 
	WHERE (SELECT COUNT(*) FROM Na_Citanju N 
	LEFT JOIN Knjiga K on N.KnjigaID = K.KnjigaID
	LEFT JOIN Napisali AS NAP ON NAP.KnjigaID = K.KnjigaID WHERE NAP.AutorID = A.AutorID) >= @P;
END