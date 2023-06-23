-- CREATE TABLES

CREATE TABLE Students (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(255) NOT NULL,
    StartYear INT NOT NULL,
    CurrentGrade INT NOT NULL,
    Age INT NOT NULL
);

CREATE TABLE Classes (
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    ClassName VARCHAR(255) NOT NULL
);

CREATE TABLE ClassGrades (
    StudentId INT FOREIGN KEY REFERENCES Students(Id),
    ClassId INT FOREIGN KEY REFERENCES Classes(Id),
    Grade INT,
    PRIMARY KEY (StudentId, ClassId)
);

-- INSERT DATA

INSERT INTO
    Classes(ClassName)
VALUES
    ('English'),
    ('Math'),
    ('Science'),
    ('History'),
    ('Music'),
    ('Biology'),
    ('IT'),
    ('Physics');

INSERT INTO
    Students(StudentName, StartYear, CurrentGrade, Age)
VALUES
    ('Santana David Kirch', 2023, 1, 22),
    ('Elisa Hoover', 2022, 3, 29),
    ('Cairistiona Guto Schroder', 2023, 1, 23),
    ('Tori Austin', 2022, 3, 20),
    ('Zaina Gilmore', 2023, 2, 28),
    ('Sebastian Leonor Apeldoorn', 2023, 1, 22),
    ('Crystal Burke', 2023, 1, 21),
    ('Sudarshan Chandana Jones', 2023, 3, 22),
    ('Okropir Fiorenza Peusen', 2020, 2, 27),
    ('Edmund Strong', 2022, 2, 19),
    ('Anthony Mccarthy', 2021, 2, 22),
    ('Umair Bond', 2020, 3, 23),
    ('Arjan Ibarra', 2020, 1, 26),
    ('Elijah Wu', 2022, 1, 26),
    ('Farrokh Amvrosiy Cipriani', 2020, 3, 24),
    ('Teresa Bloggs', 2020, 2, 27),
    ('Amna Ferguson', 2019, 3, 23),
    ('Gino Rahman Wyrzyk', 2019, 3, 29),
    ('Phyllis Vincent', 2022, 3, 24),
    ('Ghada Pastor Giese', 2019, 2, 23);

INSERT INTO
    ClassGrades(StudentId, ClassId, Grade)
VALUES
    (1, 2, 3),
    (1, 3, 2),
    (1, 7, 3),
    (1, 8, 3),
    (2, 8, 5),
    (2, 7, 1),
    (2, 2, 3),
    (2, 5, 5),
    (3, 5, 6),
    (3, 4, 1),
    (3, 3, 5),
    (3, 1, 5),
    (3, 2, 6),
    (4, 7, 4),
    (4, 4, 6),
    (5, 2, 2),
    (5, 4, 3),
    (5, 7, 4),
    (5, 5, 4),
    (6, 1, 4),
    (7, 1, 3),
    (7, 6, 3),
    (7, 8, 6),
    (7, 7, 4),
    (8, 8, 3),
    (8, 5, 3),
    (8, 4, 6),
    (8, 7, 5),
    (8, 1, 4),
    (9, 4, 2),
    (9, 5, 5),
    (9, 7, 4),
    (10, 8, 2),
    (12, 6, 1),
    (12, 2, 3),
    (13, 1, 6),
    (13, 8, 6),
    (13, 3, 6),
    (13, 6, 1),
    (13, 4, 6),
    (13, 2, 6),
    (13, 7, 6),
    (14, 5, 2),
    (14, 2, 3),
    (14, 8, 2),
    (14, 7, 1),
    (14, 4, 5),
    (16, 4, 4),
    (16, 5, 2),
    (16, 3, 2),
    (16, 1, 3),
    (16, 2, 3),
    (16, 7, 2),
    (17, 2, 2),
    (17, 1, 1),
    (20, 6, 5),
    (20, 3, 6);
    