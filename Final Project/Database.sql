---create database
Create database  Herifa_Web;
------------------------------
---create tables 
CREATE TABLE User (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(200),
    Address NVARCHAR(100),
    Password NVARCHAR(100),
    National_ID NVARCHAR(15),
    Personal_Image VARBINARY(MAX),
    NationalID_Image VARBINARY(MAX),
    Account_State NVARCHAR(50)
);
---------------------------------------
CREATE TABLE Role (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(50), --check constrain
    User_ID INT,
    FOREIGN KEY (User_ID) REFERENCES User(ID)
);
--------------------------------------------
CREATE TABLE Staff (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Salary DECIMAL(10, 2),
    Hire_Date DATE,
    Work_Hours INT,
	User_ID INT,
    FOREIGN KEY (User_ID) REFERENCES User(ID)
);
-----------------------------------------------
CREATE TABLE Client (
    ID INT PRIMARY KEY IDENTITY(1,1),
    History NVARCHAR(MAX),
    Review NVARCHAR(MAX),
	User_ID INT,
    FOREIGN KEY (User_ID) REFERENCES User(ID)
);
--------------------------------------------------
CREATE TABLE Herfiy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Zone NVARCHAR(100),
    History NVARCHAR(MAX),
    Speciality NVARCHAR(100),
	User_ID INT,
    FOREIGN KEY (User_ID) REFERENCES User(ID)
);
------------------------------------------------
CREATE TABLE Category (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(100)
);
--------------------------------------------------
CREATE TABLE Payment (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Date DATE,
    State NVARCHAR(50), -----ck
    Amount DECIMAL(10, 2),
    Payment_term NVARCHAR(50), ----ck
    Herify_ID INT,
    FOREIGN KEY (Herify_ID) REFERENCES Herfiy(ID)--?????????
);
-------------------------------------------------------
CREATE TABLE Herify_Category(   --pk
	Herify_ID INT,
	FOREIGN KEY (Herify_ID) REFERENCES Herfiy(ID),
	Category_ID INT,
	FOREIGN KEY (Herify_ID) REFERENCES Herfiy(ID)
);
----------------------------------------------------
CREATE TABLE Client_Herify (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Cost DECIMAL(10, 2),
    Date DATE,
    State NVARCHAR(50),
    Client_Review NVARCHAR(MAX),
    Herify_Review NVARCHAR(MAX),
    Client_ID INT,
	FOREIGN KEY (Client_ID) REFERENCES Client(ID),
    Herify_ID INT,
    FOREIGN KEY (Herify_ID) REFERENCES Herfiy(ID)
);
------------------------------------------------------------