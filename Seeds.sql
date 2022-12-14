INSERT INTO Users(username, password, email, is_admin) VALUES ("Admin", SHA2("JusteDesAs", 256), "Admin@hotmail.com", true);
INSERT INTO Users(username, password, email, is_admin) VALUES ("Beyonce", SHA2("JusteDesBs", 256), "Beyonce@live.ca", false);
INSERT INTO Users(username, password, email, is_admin) VALUES ("Charlie", SHA2("JusteDesCs", 256), "Charlie@outlook.net", false);

INSERT INTO Users(id, username, password, email, is_admin) VALUES (97, "Shawn Mendes", SHA2("SomethingSomethingGirls", 256), "SMendes@star.co", false);
INSERT INTO Users(id, username, password, email, is_admin) VALUES (98, "Riles", SHA2("TimesRunningOut2211315", 256), "Riles@International.fr", false);
INSERT INTO Users(id, username, password, email, is_admin) VALUES (99, "Home", SHA2("IMakeLofi", 256), "knockknock@whosthere.com", false);

INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("Come Back Down", "Home", 4.53, "Lofi", 2017, "%TEMP%/dosomething", null, 99);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("TIME OUT", "Riles", 3.38, "Hip-Hop", 2022, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("BLESSINGS", "Riles", 3.28, "Hip-Hop", 2022, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("No Sleep", "Riles", 2.59, "Hip-Hop", 2017, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("Ultimatum", "Riles", 3.16, "Hip-Hop", 2019, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("After the Darkness", "Riles", 2.48, "Hip-Hop", 2017, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("Enjoy the ride", "Riles", 3.45, "Hip-Hop", 2017, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("Away", "Riles", 2.56, "Hip-Hop", 2017, "%TEMP%/dosomething", null, 98);
INSERT INTO Tunes(title, artist, length, genre, year, filepath, id_album, id_user) VALUES ("In My Blood", "Shawn Mendes", 3.31, "Pop", 2018, "%TEMP%/dosomething", null, 97);

INSERT INTO Playlists(artist, genre, title, year, is_public, id_user, album_cover)
VALUES (null, null, "Riles Playlist", null, false, 1, null);

INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 3);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 4);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 5);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 6);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 7);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 8);
INSERT INTO Playlists_tunes(id_playlist, id_tune) VALUES(1, 9);