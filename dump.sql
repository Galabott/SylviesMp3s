DROP TABLE IF EXISTS Musics, Users;

CREATE TABLE Users (
	id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
	email VARCHAR(60) NOT NULL,
	password VARCHAR(32) NOT NULL
);
INSERT INTO Users VALUES 
(
	DEFAULT,
	'admin@admin.co',
	SHA2('toor', 256)
),
(
	DEFAULT,
	'sylvieSQL@gmail.com',
	SHA2('IL0veMusic', 256)
);

CREATE TABLE Musics (
	id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
	folder_path VARCHAR(200) NOT NULL,
	title VARCHAR(50),
	author VARCHAR(50),
	user_id INT UNSIGNED NOT NULL,
	created_at DATETIME NOT NULL DEFAULT Now(),
	edited_at DATETIME DEFAULT NULL,
	deleted_at DATETIME DEFAULT NULL,
	
	FOREIGN KEY(user_id) REFERENCES Users(id)
);
