
-- 1. Create the database named "TechShop"
CREATE DATABASE TechShop
use TechShop

--2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables based on the provided schema.

-- Customer Table
CREATE TABLE Customers(
	CustomerId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Email VARCHAR(40) UNIQUE,
	Phone VARCHAR(20),
	Address TEXT 
)

-- Products Table
CREATE TABLE Products(
	ProductId INT IDENTITY PRIMARY KEY,
	ProductName VARCHAR(20) NOT NULL,
	Description TEXT ,
	Price INT NOT NULL,
	Category VARCHAR(20)
)

-- Orders Table
CREATE TABLE Orders(
	OrderId INT IDENTITY PRIMARY KEY,
	CustomerId INT NOT NULL,
	OrderDate DATE NOT NULL,
	TotalAmount INT NOT NULL
	FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE
)

-- OrderDetails Table
CREATE TABLE OrderDetails(
	OrderDetailId INT IDENTITY PRIMARY KEY,
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	FOREIGN KEY(OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
	FOREIGN KEY(ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE
)

-- Inventory Table
CREATE TABLE Inventory(
	InventoryId INT IDENTITY PRIMARY KEY,
	ProductId INT NOT NULL,
	QuantityInStock INT DEFAULT 0, 
	LastStockUpdate DATE NOT NULL,
	FOREIGN KEY(ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE
)

--Insert at least 10 sample records into each of the following tables.

INSERT INTO Customers VALUES
	('Sneha','Dave','a@gmail.com','+123747798','kolar'),
	('Prashant','Pandey','ab@gmail.com','+123757798','awadhpuri'),
	('Veer','Singh','abc@gmail.com','+123737798','bhel'),
	('Vikram','Singh','abcd@gmail.com','+128757798','lalghati'),
	('Shreya','Jain','b@gmail.com','+123757398','karond'),
	('Shree','Bajaj','bc@gmail.com','+128757798','New-Market'),
	('Neena','Dubey','bcd@gmail.com','+123747798','MP-Nagar'),
	('Ankush','Tiwari','c@gmail.com','+123787798','Danish Nagar'),
	('Neha','Mahajan','cb@gmail.com','+123757788',null),
	('Rahul','Singh','cbd@gmail.com','+125757798',null)


INSERT INTO Products VALUES
	('CPU','CPU Description',1000,'Computer'),
	('TV','TV Description',2000,'HomeAppliance'),
	('Laptop','Laptop Description',3000,'Computer'),
	('Earpods','Earpods Description',4000,'Accessory'),
	('Watch','Watch Description',5000,'Accessory'),
	('Computer','Computer Description',6000,'Computer'),
	('KeyBoard','CPU Description',500,'Accessory'),
	('Mouse','Mouse Description',500,'Accessory'),
	('Speaker','Speaker Description',1000,'SoundDevice'),
	('HeadPhone','HeadPhone Description',1500,'SoundDevice')

INSERT INTO Orders VALUES
	(1,'2012-01-15',2000),
	(2,'2012-07-16',3000),
	(3,'2012-05-17',4000),
	(3,'2012-03-18',5000),
	(4,'2012-07-19',6000),
	(5,'2012-02-01',7000),
	(3,'2012-08-02',8000),
	(8,'2012-01-03',9000),
	(9,'2012-09-04',7890),
	(1,'2012-07-05',7777)

INSERT INTO OrderDetails VALUES
	(1,1,1),
	(2,1,2),
	(3,2,4),
	(4,3,1),
	(5,5,2),
	(6,5,3),
	(7,5,4),
	(8,2,1),
	(9,8,2),
	(10,10,4) 

INSERT INTO Inventory VALUES
	(1,100,GETDATE()),
	(2,200,GETDATE()),
	(3,300,GETDATE()),
	(4,400,GETDATE()),
	(5,500,GETDATE()),
	(6,600,GETDATE()),
	(7,700,GETDATE()),
	(8,800,GETDATE()),
	(9,900,GETDATE()),
	(10,100,GETDATE())




--Tasks 2: Select, Where, Between, AND, LIKE:

-- 1. Write an SQL query to retrieve the names and emails of all customers.

SELECT
	CONCAT(FirstName, ' ', LastName) AS Name,
	Email
FROM
	Customers 

--2. Write an SQL query to list all orders with their order dates and corresponding customer names.

SELECT 
	O.OrderId, O.OrderDate, CONCAT(C.FirstName, ' ', C.LastName) AS CustomerName
FROM 
	Orders as O, Customers as C
	WHERE O.CustomerId = C.CustomerId


--3. Write an SQL query to insert a new customer record into the "Customers" table. Include
--customer information such as name, email, and address.

INSERT INTO Customers (FirstName, LastName, Email, Address)
	VALUES('Shreya','Singh','q123@gmail.com','12 at new market')

--4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.

UPDATE  Products
	SET Price=Price*1.1

--5. Write an SQL query to delete a specific order and its associated order details from
--the "Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.

declare @value int
	set @value=10

DELETE FROM Orders
	WHERE orderId = @value

	
--6. Write an SQL query to insert a new order into the "Orders"
--table. Include the customer ID, order date, and any other necessary information.

begin transaction
	insert into orders values(6,GETDATE(),12500)
	insert into orderDetails values(11,5,5)
commit transaction

--7. Write an SQL query to update the contact information (e.g., email and address) of a specific
--customer in the "Customers" table. Allow users to input the customer ID and new contact information

declare @value int
	set @value=9

update Customers
	set email='ab1@gmail.com',address='bhel at 123'
	where CustomerId=@value

--8. Write an SQL query to recalculate and update the total cost of each order in the "Orders"
--table based on the prices and quantities in the "OrderDetails" table.

update orders 
	set orders.TotalAmount= Price*Quantity
	FROM Products as P, OrderDetails as O , orders
	where P.ProductId=O.ProductId and o.Orderid=orders.OrderId
select * from orders

-- 9. Write an SQL query to delete all orders and their associated order details for a specific
--customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID
--as a parameter.

declare @value int
set @value=2

delete orders
	where CustomerId=@value


--10. Write an SQL query to insert a new electronic gadget product into the "Products" table,
--including product name, category, price, and any other relevant details.

insert into products values
('Mobile','Mobile Description',50000,'Accessory')

--11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from
--"Pending" to "Shipped"). Allow users to input the order ID and the new status.
alter table orders
	add OrderStatus varchar(20)

update orders
	set orderstatus='pending'
	where customerid in( 1,3,4)

UPDATE Orders
	SET OrderStatus = 'Shipped'
	WHERE customerId IN (1,5,6,8,9);

declare @value int,@stat varchar(20)
	set @value= 4
	set @stat='NEW'
update  orders
	set orderStatus= @stat
	where orderId=@value

--12. Write an SQL query to calculate and update the number of orders placed by each customer
--in the "Customers" table based on the data in the "Orders" table.

select O.CustomerId, count(O.customerId) as NoOfOrdersPlaced
	from customers as C join orders as O on C.customerId=O.customerId
	group by O.customerid



--Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:

--1. Write an SQL query to retrieve a list of all orders along with customer information (e.g.,
--customer name) for each order.

select OrderId, Concat_ws(' ',FirstName,LastName) as CustomerName, email as CustomerEmail,Phone as CustomerPhone
	from Orders as O
	join Customers as C
	on O.CustomerId=C.CustomerId -- only join because we have a not null constraint on custid

--2.Write an SQL query to find the total revenue generated by each electronic gadget product.
--Include the product name and the total revenue.

select ProductName,
	Revenue=case
			when SUM(Price*Quantity) is null then 0
			else SUM(Price*Quantity)
			end
	from OrderDetails as O
	Right join Products as P
	on O.ProductId=P.ProductId
	group by ProductName -- did right join to get thoes product also that has not been ordered

--3. Write an SQL query to list all customers who have made at least one purchase. Include their
--names and contact information

select  distinct concat_ws(' ',FirstName,LastName) as Name, Phone
	from Orders as O
	join Customers as C
	on O.CustomerId=C.CustomerId
	
--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest
--total quantity ordered. Include the product name and the total quantity ordered.

select top 1 ProductName,sum(Quantity) as TotalQuantity
	from OrderDetails as O
	join Products as P on
	O.ProductId=P.ProductId 
	group by ProductName 
	order by TotalQuantity desc 

--5. Write an SQL query to retrieve a list of electronic gadgets
--along with their corresponding categories.

select  ProductName,Category as ProductCategory
	from Products 
	order by Category

--6. Write an SQL query to calculate the average order value for each customer. Include the
--customer's name and their average order value.

select CONCAT_WS(' ',FirstName,LastName) as Name, avg(totalAmount) as AverageOrderValue
	from Customers as C
	Left join orders as O on C.CustomerId=O.CustomerId
	left join OrderDetails as OD on O.OrderId=OD.OrderId
	group by FirstName,LastName

--7. Write an SQL query to find the order with the highest total revenue. Include the order ID,
--customer information, and the total revenue.

select  top 1 O.OrderId, CONCAT(C.firstName,' ', C.LastName) as Name,c.Email,ProductName, (Price*Quantity) as Revenue
	from Orders as O 
	join OrderDetails as OD on O.OrderId=OD.OrderId
	join Products as P on OD.ProductId=P.ProductId
	join Customers as C on C.CustomerId=O.CustomerId 
	ORDER BY Revenue DESC


--8. Write an SQL query to list electronic gadgets and the number of times each product has been ordered.

select ProductName,sum(Quantity) as TotalQuantity, count(O.productId) as NoOfTimesOrdered
	from Products as P
	left join OrderDetails as O 
	on P.ProductId=O.ProductId
	group by P.ProductName

--9. Write an SQL query to find customers who have purchased a specific electronic gadget product.
--Allow users to input the product name as a parameter.

declare @value varchar(10)
	set @value='Watch'
select concat_ws(' ',firstName,LastName) as Name,P.ProductName
	from Orders as O
	join OrderDetails as OD 
	on O.orderId=OD.OrderId
	join products as P on p.productId=OD.productId
	join customers as C on C.customerId=O.CustomerId 
	where lower(P.productName) like lower(@value)

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a
--specific time period. Allow users to input the start and end dates as parameters

declare @start date
	set @start='2012-01-15'
declare @end date
	set @end='2012-07-15'

select Sum(TotalAmount)
	from orders where OrderDate between @start and @end


--Task 4. Subquery and its type:
--1. Write an SQL query to find out which customers have not placed any orders.

select concat_ws(' ',FirstName,LastName) as Name
	from Customers as C 
	where 
	Not exists (select orderId
				from Orders as O
				where o.CustomerId=C.customerId)

--2. Write an SQL query to find the total number of products available for sale.

select productName
from products,
	(select productid,count(productid) as count
	from Inventory
	where QuantityInStock>500
	group by ProductId) sub
WHERE Products.ProductId=SUB.ProductId


--3. Write an SQL query to calculate the total revenue generated by TechShop.

select sum(totalAmount) as TotalRevenue
	from orders where OrderStatus='Shipped'

--4. Write an SQL query to calculate the average quantity ordered for products in a specific category. Allow users to input the category name as a parameter.

declare @value varchar(20)
set @value='HomeAppliance'

select avg(quantity) as AvgQuantity
	from orderdetails as o where o.productId
	in(select p.ProductId
		from products as p
		where Category=@value
	  )

--5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users to input the customer ID as a parameter.

declare @custId int
	set @custId=3
select sum(TotalAmount) as TotalRevenue
	from Orders where OrderId 
	in (select orderId  
		from orders as o where o.CustomerId=@custId
		)
--6. Write an SQL query to find the customers who have placed the most orders. List their names and the number of orders they've placed.

select top 3 concat(firstname,' ',lastname) as CustName,sub.NoOfOrdersPlaced
	from customers as c,
		(select customerid,count(customerid) as NoOfOrdersPlaced
		from orders as o
		group by customerid) as sub
	where c.CustomerId=sub.CustomerId
	order by sub.NoOfOrdersPlaced desc


--7. Write an SQL query to find the most popular product category, which is the one with the highest total quantity ordered across all orders.

select top 1 Category
from products as p,
	(select productid,sum(quantity) as TotalQuantity
	from OrderDetails as od
	group by productid) as sub
where p.productid=sub.productid
group by category
order by sum(sub.TotalQuantity)  desc



--8. Write an SQL query to find the customer who has spent the most money (highest total revenue) on electronic gadgets. List their name and total spending.

select top 1 concat(firstName,' ',lastName) as CustName,sub.TotalRevenue
	from customers c,
		(select customerId, sum(totalAmount) as TotalRevenue
		from orders o
		group by customerId) as sub
	where c.CustomerId=sub.customerid
	order by sub.TotalRevenue desc

--9. Write an SQL query to calculate the average order value (total revenue divided by the number of orders) for all customers.

select concat(firstName,' ',lastName) as Name, sub.AOV 
	from customers as c,
		(select customerid,sum(totalamount)/count(customerId) as AOV
		from orders as o
		group by customerId) as sub
	where c.CustomerId=sub.customerId

--10. Write an SQL query to find the total number of orders placed by each customer and list their names along with the order count

select CONCAT(firstname,' ',LastName) as CustName,sub.NOOfOrdersPlaced
	from customers as c,
		(select customerId, count(CustomerId) as NOOfOrdersPlaced
		from Orders as o
		group by o.customerId) as sub
	where c.CustomerId=sub.customerId

