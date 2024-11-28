DROP DATABASE IF EXISTS main;
CREATE DATABASE main;

USING main;

CREATE TABLE player(
    player_id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(45) NOT NULL,
    score INT NOT NULL,
    date_time DATETIME NOT NULL,
    PRIMARY KEY (player_id)
);

INSERT INTO player (player_id,username,score,date_time) VALUES (NULL, player1, 100, "20224-07-15-23:16:13");
INSERT INTO player (player_id,username,score,date_time) VALUES (NULL, player2, 120, "20224-07-15-23:16:13");
INSERT INTO player (player_id,username,score,date_time) VALUES (NULL, player3, 140, "20224-07-15-23:16:13");
INSERT INTO player (player_id,username,score,date_time) VALUES (NULL, player4, 160, "20224-07-15-23:16:13");
INSERT INTO player (player_id,username,score,date_time) VALUES (NULL, player5, 180, "20224-07-15-23:16:13");