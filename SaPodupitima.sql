USE Firma;
GO
SELECT * FROM Radnik;
SELECT * FROM Projekat;
SELECT * FROM Odeljenje;
SELECT * FROM Ucesce;
/*Sve radnike koji rade na dorcolu iz firme*/
SELECT r.ime, o.brod FROM Radnik AS r INNER JOIN Odeljenje AS o ON o.mesto='Dorcol' AND r.brod = o.brod;
SELECT ime,brod FROM Radnik r WHERE r.brod = (SELECT brod FROM Odeljenje WHERE mesto = 'Dorcol');
/*Trazimo ime i ukupna primanja radnika koji rade isti posao kao Mitar*/
SELECT r.ime,(ISNULL(r.premija,0) + r.plata) AS Ukupna_Primanja FROM Radnik AS r WHERE r.posao = (SELECT posao FROM radnik WHERE ime='Mitar');
/*ime,godina zaposlenja, plata onih radnika cija je plata manja od svih plata radnika u direkciji.*/
SELECT r.ime, DATEPART(YEAR,datzap), r.plata FROM Radnik AS r WHERE r.plata < (SELECT MIN(plata) FROM Radnik AS r INNER JOIN 
Odeljenje AS o ON r.brod = o.brod WHERE o.imeod = 'Direkcija');
/*Radnik koji radi najduze u firmi*/
SELECT r.ime, r.prezime FROM Radnik AS r WHERE r.datzap = (SELECT MIN(datzap) FROM Radnik);
SELECT o.imeod FROM Odeljenje AS o WHERE o.brod =(SELECT r.brod FROM Radnik AS r WHERE r.datzap = (SELECT MIN(datzap) FROM Radnik));
/*ime svih radnika koji su se zaposlili nakon svih radnika iz komercijale*/
SELECT R.ime FROM Radnik AS r WHERE r.datzap > ALL(SELECT r.datzap FROM Radnik AS r INNER JOIN Odeljenje AS o ON r.brod = o.brod WHERE o.imeod = 'Komercijala')
/*id radnik, ime, plata, kvalifikacija za radnike koji imaju istu platu kao i bilo koji zaposleni cija je kvalifikacija VSS*/
SELECT r.idbr, r.ime, r.plata, r.kvalif FROM Radnik AS r WHERE r.plata = ANY(SELECT plata FROM Radnik WHERE kvalif = 'VSS');
/*ALL od svih
ANY od bilo koje*/