
--Drop Table Student
--Drop Table TechElevator
--Drop Table Hogwarts
Use master
Go


Drop Database If Exists HarryPotter

Create Database HarryPotter
Go

Use HarryPotter
Go

CREATE TABLE Hogwarts (
	houseid integer identity Primary Key,
	housename varchar(20) UNIQUE NOT NULL
);

CREATE TABLE TechElevator (
	classid integer identity Primary Key,
	classname varchar(10) UNIQUE NOT NULL
);

CREATE TABLE Student (
	studentid integer identity Primary Key,
	firstname varchar(15) NOT NULL,
	lastname varchar(20) NOT NULL,
	gender char(1) NOT NULL,
	hogwartshouse int NULL,
	teclass int Not NULL,
	CONSTRAINT ck_gender CHECK (gender IN ('M', 'F', 'O'))
);

ALTER TABLE Student ADD CONSTRAINT fk_Student_Hogwarts FOREIGN KEY (hogwartshouse) REFERENCES Hogwarts(houseid);
ALTER TABLE Student ADD CONSTRAINT fk_Student_TechElevator FOREIGN KEY (teclass) REFERENCES TechElevator(classid);

Insert Hogwarts (HouseName)
	Values ('Gryffindor'), ('Slytherin'), ('Ravenclaw'), ('Hufflepuff')

Insert TechElevator (ClassName)
	Values ('.NET'), ('Java'), ('Other')

Insert Student (firstname, lastname, gender, hogwartshouse, teclass)	
	Values ('Alicia', 'Barnhart', 'F',  2,  1)


	