CREATE TABLE SuppliersTb(
	Supplier_ID INT NOT NULL,
	Supplier_name VARCHAR(55) NOT NULL,
    Supplier_City VARCHAR(55),
	Supplier_email VARCHAR(55),
	Supplier_phone VARCHAR(55) NOT NULL,
    PRIMARY KEY (Supplier_ID)
    );

insert into SuppliersTb values(1,'SN1','City1','SN1@gmail.com','0321-6020450')
insert into SuppliersTb values(2,'SN2','City2','SN2@gmail.com','0322-6020450')
insert into SuppliersTb values(3,'SN3','City3','SN3@gmail.com','0323-6020450')
insert into SuppliersTb values(4,'SN4','City4','SN4@gmail.com','0324-6020450')
insert into SuppliersTb values(5,'SN5','City5','SN5@gmail.com','0325-6020450')
insert into SuppliersTb values(6,'SN6','City6','SN6@gmail.com','0326-6020450')
insert into SuppliersTb values(7,'SN7','City7','SN7@gmail.com','0327-6020450')
insert into SuppliersTb values(8,'SN8','City8','SN8@gmail.com','0328-6020450')
insert into SuppliersTb values(9,'SN9','City9','SN9@gmail.com','0329-6020450')
insert into SuppliersTb values(10,'SN0','City10','SN10@gmail.com','0330-6020450')
select * from SuppliersTb

drop table SuppliersTb

create table StockTb(
	StockID INT primary key,
	SupplierID INT foreign key references SuppliersTb(Supplier_ID),
	BookID varchar(50) unique not null,
	AuthorName varchar(50) not null,
	BookName varchar(50) not null,
	PublisherName varchar(50) not null,
	PublishedYear varchar(50) not null,
	Price int not null
);

drop table StockTb

INSERT INTO StockTb VALUES(1,1,'BOOK1','J.R.R Tolken','The Hobbit','Allen & Unwin','1937', 1100);
INSERT INTO StockTb VALUES(2,1,'BOOK2','Tanith Lee','The Castle of Dark','Macmilla','1930', 1200);
INSERT INTO StockTb VALUES(3,2,'BOOK3','Tanith Lee','The Winter Players','Macmilla','1977', 1300);
INSERT INTO StockTb VALUES(4,2,'BOOK4','Anne Rice','Tale of the Thief','Penguin','2016', 1400);
INSERT INTO StockTb VALUES(5,3,'BOOK5','J.R.R Tolken','The Lord of the Rings : Fellowship of the ring','Allen & Unwin','1937', 1500);
INSERT INTO StockTb VALUES(6,3,'BOOK6','Mark Stevenson','Prince and the Pauper','American Pushlishing Co','2011', 1600);
INSERT INTO StockTb VALUES(7,4,'BOOK7','Ribbly Scott','Alien','Morpheus','1996', 1700);
INSERT INTO StockTb VALUES(8,4,'BOOK8','James Clavell','Gone Girl','Paramount','2015', 1800);
INSERT INTO StockTb VALUES(9,5,'BOOK9','Megan Miranda','All the Missing Girls','H & R','2016', 1900);
INSERT INTO StockTb VALUES(10,6,'BOOK10','Sarah Mass','Empire of Storms','Pearson Plc','2006', 2000);

select * from StockTb

select AuthorName, COUNT(PublishedYear)
from StockTb
group by AuthorName 

CREATE TABLE Employees(
	Employee_ID INT PRIMARY KEY,
	Employee_Name VARCHAR(50),
	Employee_ContactNumber VARCHAR(50),
	Employee_Position VARCHAR(50),
	Employee_Salary MONEY CHECK(Employee_Salary>20000) NOT NULL,
	);

insert into Employees values (1,'Rizwan','012-4289087','Manager',30000);
insert into Employees values (2,'Aasd','013-4289087','Accountant',35000);
insert into Employees values (3,'Umar','014-4289087','Clerak',22000);
drop table Employees

CREATE TABLE Customer(
	Customer_ID INT NOT NULL, 
	Name VARCHAR(30) NOT NULL,
	CustomerAddress VARCHAR(max) NOT NULL,
	Phone VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Age INT NOT NULL CHECK(Age>10),
	PRIMARY KEY (Customer_ID)
);

	INSERT INTO Customer VALUES(1,'Nouman','Sialkot','0313-12345433','Customer1@gmail.com',18)
	INSERT INTO Customer VALUES(2,'Asad','Sialkot','0314-12145436','Customer2@gmail.com',17)
	INSERT INTO Customer VALUES(3,'Sarfaraz','Sialkot','0315-12145436','Customer3@gmail.com',22)
	INSERT INTO Customer VALUES(4,'Ali','Sialkot','0316-12145436','Customer4@gmail.com',23)
	INSERT INTO Customer VALUES(5,'Usman','Sialkot','0317-12145436','Customer5@gmail.com',24)
	INSERT INTO Customer VALUES(6,'Salman','Sialkot','0318-12145436','Customer6@gmail.com',25)
	INSERT INTO Customer VALUES(7,'Hassan','Sialkot','0319-12145436','Customer7@gmail.com',26)
	INSERT INTO Customer VALUES(8,'Daud','Sialkot','0320-12145436','Customer8@gmail.com',28)
	INSERT INTO Customer VALUES(9,'Nauman','Sialkot','0321-12145436','Customer9@gmail.com',30)
	INSERT INTO Customer VALUES(10,'Yaseen','Sialkot','0322-12145436','Customer10@gmail.com',33)
	drop table Customer

	CREATE TABLE Orders(
	Order_ID INT NOT NULL,
	Customer_ID INT FOREIGN KEY REFERENCES Customer(Customer_ID),
	Customer_Name VARCHAR(50),
	Employee_ID INT FOREIGN KEY REFERENCES Employees(Employee_ID),
	StockID	INT FOREIGN KEY REFERENCES StockTb(StockID),
	Qty_sold INT,
	Order_Date VARCHAR(55),
    PRIMARY KEY (Order_ID),
    );

	INSERT INTO Orders VALUES(1,1,'Nauman'  ,1,1,1,'2-2-2022')
	INSERT INTO Orders VALUES(2,2,'Asad'    ,1,2,2,'3-2-2022')
	INSERT INTO Orders VALUES(3,1,'Nauman'  ,1,1,1,'4-2-2022')
	INSERT INTO Orders VALUES(4,3,'Sarfaraz',1,3,2,'5-2-2022')
	INSERT INTO Orders VALUES(5,3,'Sarfaraz',1,4,1,'6-2-2022')
	
	Select * From Orders

	Select Customer_ID, Qty_sold From Orders
	group by Customer_ID, Qty_sold
	
	drop table Orders

	CREATE TABLE Bill_Generate(
	Bill_ID INT primary key,
	Order_ID INT FOREIGN KEY REFERENCES Orders(Order_ID),
	Customer_ID INT FOREIGN KEY REFERENCES Customer(Customer_ID),
	StockID	INT FOREIGN KEY REFERENCES StockTb(StockID),
	Bill_Date date,
	Total_Cost INT CHECK(Total_Cost>0) NOT NULL,
	);

	INSERT INTO Bill_Generate VALUES(1,1,1,1,'2-2-2022',1100)
	INSERT INTO Bill_Generate VALUES(2,2,2,2,'3-2-2022',1200)
	INSERT INTO Bill_Generate VALUES(3,3,1,1,'4-2-2022',1100)
	INSERT INTO Bill_Generate VALUES(4,4,3,3,'5-2-2022',1300)
	INSERT INTO Bill_Generate VALUES(5,5,3,4,'6-2-2022',1300)


	DROP TABLE Bill_Generate

	CREATE TABLE PAYMENTS(
	Payment_ID INT PRIMARY KEY,
	Bill_ID INT FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Customer_ID INT FOREIGN KEY REFERENCES Customer(Customer_ID),
	Credit_card_numb VARCHAR(55) NOT NULL,
	Credit_card_expiry varchar(55) NOT NULL,
	PaymentPaid INT CHECK(PaymentPaid>0) NOT NULL,
	);

	INSERT INTO PAYMENTS VALUES(1,1,1,'1717-22-233','11-17-2024',1100)
	INSERT INTO PAYMENTS VALUES(2,2,2,'1718-23-233','01-17-2025',1200)
	INSERT INTO PAYMENTS VALUES(3,3,1,'1719-24-233','03-17-2023',1100)
	INSERT INTO PAYMENTS VALUES(4,4,3,'1720-25-233','05-17-2030',1300)
	INSERT INTO PAYMENTS VALUES(5,5,3,'1721-26-233','07-17-2045',1300)

	drop table PAYMENTS

	CREATE TABLE Returns(
	Return_ID INT PRIMARY KEY,
	Bill_ID INT FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Payment_ID INT FOREIGN KEY REFERENCES PAYMENTS(Payment_ID),
	Order_ID INT FOREIGN KEY REFERENCES Orders(Order_ID),
    PayReturned int,
    )

    INSERT INTO Returns VALUES(1,1,1,1,1100)
	INSERT INTO Returns VALUES(2,5,5,5,1300)
	
	select * from Returns
	drop table Returns

	SELECT * FROM Orders
	WHERE Order_Date BETWEEN '2-2-2022'AND'5-2-2022';
	Select * From StockTb
	SELECT * from StockTb where PublishedYear = 2016
	--total sales group by customer id from payments
	select Sum(Total_Cost) from Payments
	select Sum(Total_Cost),Customer_ID
	from Payments
	Group by Customer_ID
	having Max(Total_Cost) > 2000

	--
	select Sum(Total_Cost) As 'Total Sale' From PAYMENTS;