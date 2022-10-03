--BOOKSHOP MANAGEMENT SYSTEM

CREATE TABLE SuppliersTb(
		Supplier_ID VARCHAR (55)NOT NULL,
		Supplier_name VARCHAR(55) NOT NULL,
		Supplier_City VARCHAR(55),
		Supplier_email VARCHAR(55),
		Supplier_phone VARCHAR(55) NOT NULL,
		PRIMARY KEY (Supplier_ID)
		);

	INSERT INTO SuppliersTb VALUES('SUP1','SN1','City1','SN1@gmail.com','0321-6020450')
	INSERT INTO SuppliersTb VALUES('SUP2','SN2','City2','SN2@gmail.com','0322-6020450')
	INSERT INTO SuppliersTb VALUES('SUP3','SN3','City3','SN3@gmail.com','0323-6020450')
	INSERT INTO SuppliersTb VALUES('SUP4','SN4','City4','SN4@gmail.com','0324-6020450')
	INSERT INTO SuppliersTb VALUES('SUP5','SN5','City5','SN5@gmail.com','0325-6020450')
	INSERT INTO SuppliersTb VALUES('SUP6','SN6','City6','SN6@gmail.com','0326-6020450')
	INSERT INTO SuppliersTb VALUES('SUP7','SN7','City7','SN7@gmail.com','0327-6020450')
	INSERT INTO SuppliersTb VALUES('SUP8','SN8','City8','SN8@gmail.com','0328-6020450')
	INSERT INTO SuppliersTb VALUES('SUP9','SN9','City9','SN9@gmail.com','0329-6020450')
	INSERT INTO SuppliersTb VALUES('SUP10','SN0','City10','SN10@gmail.com','0330-6020450')
	SELECT * FROM SuppliersTb

	--1
	SELECT Supplier_name, Supplier_phone FROM SuppliersTb 
	--2
	update SuppliersTb SET Supplier_name = 'fahad' WHERE Supplier_ID = 'SUP10';
	--3
	delete FROM SuppliersTb WHERE Supplier_ID = 'SUP10';

	create table StockTb(
		StockID VARCHAR(50) PRIMARY KEY,
		SupplierID VARCHAR(55) FOREIGN KEY REFERENCES SuppliersTb(Supplier_ID),
		BookID VARCHAR(50) NOT NULL,
		AuthorName VARCHAR(50) NOT NULL,
		BookName VARCHAR(50) NOT NULL,
		PublisherName VARCHAR(50) NOT NULL,
		PublishedYear VARCHAR(50) NOT NULL,
		Price int NOT NULL
	);

	INSERT INTO StockTb VALUES('STK1','SUP1','BOOK1','J.R.R Tolken','The Hobbit','Allen & Unwin','1937', 1100);
	INSERT INTO StockTb VALUES('STK2','SUP1','BOOK2','Tanith Lee','The Castle of Dark','Macmilla','1930', 1200);
	INSERT INTO StockTb VALUES('STK3','SUP2','BOOK3','Tanith Lee','The Winter Players','Macmilla','1977', 1300);
	INSERT INTO StockTb VALUES('STK4','SUP2','BOOK4','Anne Rice','Tale of the Thief','Penguin','2016', 1400);
	INSERT INTO StockTb VALUES('STK5','SUP3','BOOK5','J.R.R Tolken','The Lord of the Rings : Fellowship of the ring','Allen & Unwin','1937', 1500);
	INSERT INTO StockTb VALUES('STK6','SUP3','BOOK6','Mark Stevenson','Prince and the Pauper','American Pushlishing Co','2011', 1600);
	INSERT INTO StockTb VALUES('STK7','SUP4','BOOK7','Ribbly Scott','Alien','Morpheus','1996', 1700);
	INSERT INTO StockTb VALUES('STK8','SUP4','BOOK8','James Clavell','Gone Girl','Paramount','2015', 1800);
	INSERT INTO StockTb VALUES('STK9','SUP5','BOOK9','Megan Miranda','All the Missing Girls','H & R','2016', 1900);
	INSERT INTO StockTb VALUES('STK10','SUP6','BOOK10','Sarah Mass','Empire of Storms','Pearson Plc','2006', 2000);
	SELECT * FROM StockTb

	--1
	alter table StockTb
	add Price int check(Price>=1000);
	--2
	SELECT * FROM StockTb WHERE PublishedYear = 2016
	--3
	SELECT AuthorName, COUNT(PublishedYear)
	FROM StockTb
	GROUP BY AuthorName 
	
	CREATE TABLE Employees(
		Employee_ID VARCHAR(55) PRIMARY KEY,
		Employee_Name VARCHAR(50),
		Employee_ContactNumber VARCHAR(50),
		Employee_Position VARCHAR(50),
		Employee_Salary MONEY CHECK(Employee_Salary>20000) NOT NULL,
		);

	INSERT INTO Employees VALUES ('EM1','Rizwan','012-4289087','Manager',30000);
	INSERT INTO Employees VALUES ('EM2','Aasd','013-4289087','Accountant',35000);
	INSERT INTO Employees VALUES ('EM3','Umar','014-4289087','Clerak',22000);
	INSERT INTO Employees VALUES ('EM4','Yaseen','015-4289087','Accountant',35000);
	INSERT INTO Employees VALUES ('EM5','Hassan','018-4289087','Clerak',22000);
	INSERT INTO Employees VALUES ('EM6','Daud','015-4289087','Clerak',22000);
	SELECT * FROM Employees
	
	--1
	update Employees SET Employee_Salary = 30000 WHERE Employee_ID = 'EMP3';
	delete FROM Employees WHERE Employee_ID = 'EMP6';
	--2
	SELECT Employee_Position, SUM(Employee_Salary)
	FROM Employees
	GROUP BY Employee_Position

	CREATE TABLE Customer(
		Customer_ID VARCHAR(50) NOT NULL, 
		Name VARCHAR(30) NOT NULL,
		CustomerAddress VARCHAR(max) NOT NULL,
		Phone VARCHAR(50) NOT NULL,
		Email VARCHAR(50) NOT NULL,
		Age INT NOT NULL CHECK(Age>10),
		PRIMARY KEY (Customer_ID)
	);

	INSERT INTO Customer VALUES('CUS1','Nouman','Sialkot','0313-12345433','Customer1@gmail.com',18)
	INSERT INTO Customer VALUES('CUS2','Asad','Sialkot','0314-12145436','Customer2@gmail.com',17)
	INSERT INTO Customer VALUES('CUS3','Sarfaraz','Sialkot','0315-12145436','Customer3@gmail.com',22)
	INSERT INTO Customer VALUES('CUS4','Ali','Sialkot','0316-12145436','Customer4@gmail.com',23)
	INSERT INTO Customer VALUES('CUS5','Usman','Sialkot','0317-12145436','Customer5@gmail.com',24)
	INSERT INTO Customer VALUES('CUS6','Salman','Sialkot','0318-12145436','Customer6@gmail.com',25)
	INSERT INTO Customer VALUES('CUS7','Hassan','Sialkot','0319-12145436','Customer7@gmail.com',26)
	INSERT INTO Customer VALUES('CUS8','Daud','Sialkot','0320-12145436','Customer8@gmail.com',28)
	INSERT INTO Customer VALUES('CUS9','Nauman','Sialkot','0321-12145436','Customer9@gmail.com',30)
	INSERT INTO Customer VALUES('CUS10','Yaseen','Sialkot','0322-12145436','Customer10@gmail.com',33)
	SELECT * FROM Customer

	--1
	delete FROM Customer WHERE Customer_ID = 'CUS10';
	delete FROM Customer WHERE Customer_ID = 'CUS9';
	delete FROM Customer WHERE Customer_ID = 'CUS8';
	--2
	SELECT * FROM Customer
	WHERE Age BETWEEN 20 AND 25;

	CREATE TABLE Orders(
	Order_ID VARCHAR(55) NOT NULL,
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	Employee_ID VARCHAR(55) FOREIGN KEY REFERENCES Employees(Employee_ID),
	StockID	VARCHAR(50) FOREIGN KEY REFERENCES StockTb(StockID),
	Qty_sold INT,
	Order_Date VARCHAR(55),
    PRIMARY KEY (Order_ID),
    );
	INSERT INTO Orders VALUES('ORD1','CUS1','EM1','STK1',1,'2-2-2022')
	INSERT INTO Orders VALUES('ORD2','CUS2','EM1','STK2',2,'3-2-2022')
	INSERT INTO Orders VALUES('ORD3','CUS1','EM1','STK1',1,'4-2-2022')
	INSERT INTO Orders VALUES('ORD4','CUS3','EM1','STK3',2,'5-2-2022')
	INSERT INTO Orders VALUES('ORD5','CUS3','EM1','STK4',1,'6-2-2022')
	INSERT INTO Orders VALUES('ORD6','CUS4','EM1','STK6',5,'7-2-2022')
	INSERT INTO Orders VALUES('ORD7','CUS5','EM1','STK5',8,'8-2-2022')
	SELECT * FROM Orders

	--1
	Update Orders SET Qty_sold = 3 WHERE Order_ID = 'ORD1';
	SELECT * FROM Orders Order By Qty_sold Desc; 
	--2
	SELECT Customer_ID, Qty_sold FROM Orders
	GROUP BY Customer_ID, Qty_sold
	--3
	SELECT * FROM Orders
	WHERE Order_Date BETWEEN '2-2-2022'AND'5-2-2022';
	
	CREATE TABLE Bill_Generate(
	Bill_ID VARCHAR(50) PRIMARY KEY,
	Order_ID VARCHAR(55) FOREIGN KEY REFERENCES Orders(Order_ID),
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	BookID VARCHAR(50) NOT NULL,
	Bill_Date date,
	Total_Cost INT CHECK(Total_Cost>0) NOT NULL,
	);
	INSERT INTO Bill_Generate VALUES('BILL1','ORD1','CUS1','BOOK1','6-2-2022',1100)
	INSERT INTO Bill_Generate VALUES('BILL2','ORD2','CUS2','BOOK2','7-2-2022',1200)
	INSERT INTO Bill_Generate VALUES('BILL3','ORD3','CUS1','BOOK1','8-2-2022',1100)
	INSERT INTO Bill_Generate VALUES('BILL4','ORD4','CUS3','BOOK3','9-2-2022',1300)
	INSERT INTO Bill_Generate VALUES('BILL5','ORD5','CUS3','BOOK4','10-2-2022',1300)
	SELECT * FROM Bill_Generate

	--1
	SELECT Customer_ID, BooKID FROM Bill_Generate
	GROUP BY Customer_ID, BookID
	--2
	SELECT Customer_ID, COUNT(BookID)
	FROM Bill_Generate
	GROUP BY Customer_ID

	CREATE TABLE PAYMENTS(
	Payment_ID VARCHAR(50) PRIMARY KEY,
	Bill_ID VARCHAR(50) FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	Credit_card_numb VARCHAR(55) NOT NULL,
	Credit_card_expiry VARCHAR(55) NOT NULL,
	Total_Cost INT CHECK(Total_Cost>0) NOT NULL,
	);

	INSERT INTO PAYMENTS VALUES('PAY1','BILL1','CUS1','1717-22-233','11-17-2024',1100)
	INSERT INTO PAYMENTS VALUES('PAY2','BILL2','CUS2','1718-23-233','01-17-2025',1200)
	INSERT INTO PAYMENTS VALUES('PAY3','BILL3','CUS1','1719-24-233','03-17-2023',1100)
	INSERT INTO PAYMENTS VALUES('PAY4','BILL4','CUS3','1720-25-233','05-17-2030',1300)
	INSERT INTO PAYMENTS VALUES('PAY5','BILL5','CUS3','1721-26-233','07-17-2045',1300)
	SELECT * FROM PAYMENTS;
	--1
	SELECT Sum(Total_Cost) As 'Total Sale' FROM PAYMENTS;
	--2
	SELECT Customer_ID, Sum(Total_Cost)
	FROM Payments
	GROUP BY Customer_ID
	having Sum(Total_Cost) >= 2200

	CREATE TABLE Returns(
	Return_ID VARCHAR(55) PRIMARY KEY,
	Bill_ID VARCHAR(50) FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Payment_ID VARCHAR(50) FOREIGN KEY REFERENCES PAYMENTS(Payment_ID),
	Order_ID VARCHAR(55) FOREIGN KEY REFERENCES Orders(Order_ID),
    PayReturned int,
    );
    INSERT INTO Returns VALUES('RT1','BILL1','PAY1','ORD1',1100)
	INSERT INTO Returns VALUES('RT2','BILL5','PAY5','ORD5',1300)
	SELECT * FROM Returns
	--1
	SELECT Sum(PayReturned) As 'Total Returned Sales ' FROM Returns;

	--SQL JOINTS

	--INNER JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Orders	
	INNER JOIN Customer ON Orders.Customer_ID=Customer.Customer_ID;

	--LEFT JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Customer	
	LEFT JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;

	--RIGHT JOIN
	SELECT  Customer.Name, Orders.Order_ID
	FROM Customer	
	RIGHT JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;

	--FULL JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Customer	
	FULL JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;