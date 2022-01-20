SET IDENTITY_INSERT Odsek ON;

INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (1,'Odsek za misterije', 1);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (2,'Odsek za sprovođenje magijskih zakona', 2);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (3,'Odsek za magijske nesreće i katastrofe ', 3);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (4,'Odsek za regulaciju i kontrolu magijskih stvorenja ', 4);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (5,'Odsek za međunarodnu magijsku saradnju', 5);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (6,'Odsek magijskog transporta', 6);
INSERT INTO Odsek (id, Ime, [Br. sprata]) VALUES (7,'Odsek za magijske igre i sportove', 7);

SET IDENTITY_INSERT Odsek OFF;


SET IDENTITY_INSERT Radnik ON;

INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (1, 'Hari', 'Poter', 'M', 1087432, 1980, 1)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (2, 'Ronald', 'Vizli', 'M', 2087432, 1980, 2)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (3, 'Hermiona', 'Grejndžer', 'Ž', 5074437, 1979, 5)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (4, 'Kornelijus', 'Fadž', 'M', 3083447, 1951, 3)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (5, 'Horacije', 'Pužorog', 'M', 7045722, 1955, 7)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (6, 'Salamander', 'Skamander', 'M', 4054786, 1967, 4)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (7, 'Lita', 'Lestrejndž', 'Ž', 4055547, 1969, 4)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (8, 'Luna', 'Lavgud', 'Ž', 5074395, 1982, 5)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (9, 'Barti', 'Čučanj', 'M', 6047896, 1954, 6)
INSERT INTO Radnik (id, Ime, Prezime, Pol, [Br. legitimacije], [Godina rođenja], Odsekid) VALUES (10, 'Dolores', 'Ambridž', 'Ž', 6057966, 1952, 6)

SET IDENTITY_INSERT Radnik OFF;


SET IDENTITY_INSERT Slučaj ON;

INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (1, 'Balkanska bara', 1, 'ograničen pristup', 9, 6, 'Teleportacioni ključ u Deliblatskoj peščari prebacuje ljude isključivo u Hrvatsku bez obzira na željenu destinaciju.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (2, 'Niš na vodi', 1, 'javno', 10, 3, 'Žuti most na Nišavi, ispod kog se nalazi tajna čarobnjačka krčma je pukao i oštetio veliki deo infrastrukture krčme.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (3, 'Rumunski plamen', 1, 'poverljivo', 3, 4, 'Mađarski šiljorep izazvao katastrofu u glavnom gradu Rumunije.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (4, 'Igra krišom', 1, 'poverljivo', 2, 7, 'U Bugarskoj organizovan nelegalni turnir u kvidiču. Pobednici reketirali navijače koji su došli.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (5, 'Nacistički poduhvat', 1, 'ograničen pristup', 8, 2, 'U Nemačkoj, grupa nacista organizuje čarobnjački rat na granici sa Francuskom.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (6, 'Izgubljeno proročanstvo', 1, 'poverljivo', 7, 1, 'Ukradeno proročanstvo iz Ministarstva pronađeno u selu u Sibiru.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (7, 'Pljačka štapića', 1, 'javno', 5, 2, 'U Londonu pokraden Olivanderov muzej.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (8, 'Sukob škola', 1, 'ograničen pristup', 5, 1, 'Francuska i balkanska škola, Bobatons i Durmstrang, u sukobu oko uvođenja bolonje.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (9, 'Prodaja igrača', 1, 'poverljivo', 7, 7, 'U Albaniji nelegalno prodavanja igrača državnog kvidičkog tima.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (10, 'Ratna opasnost', 1, 'poverljivo', 1, 5, 'Neslaganje čarobnjaka Kine i Koreje izaziva nemire na granicama. Sukobu prisustvovali Normalci.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (11, 'Ukradeni antikvitet', 1, 'javno', 8, 2, 'Ukradeno prvo izdanje autobiografije Rite Skiter.')
INSERT INTO Slučaj (id, [Kodno ime], Status, [Nivo poverljivosti], Radnikid, Odsekid, [Kratak opis]) VALUES (12, 'Opasnost iz mora', 1, 'javno', 6, 4, 'Čudovište na obalama Norveške izazivalo nemire kod Normalskih stanovnika.')


SET IDENTITY_INSERT Slučaj OFF;