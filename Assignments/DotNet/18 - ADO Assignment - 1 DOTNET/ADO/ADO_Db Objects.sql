/*
Consider a table called Product_Details having a columns of Product id, Product Name, Supplier id. 
Also consider a table called Supplier_Info with columns of Supplier Id,Supplier Name, Address,City,Contact No,Email.


Create schema ADO

Drop table [ADO].[Supplier_Info]
Drop table [ADO].[Product_Details]
*/

Create table [ADO].[Supplier_Info]
(
	[SupplierId]   INT IDENTITY(100,1),
	[SupplierName] VARCHAR(50),
	[Address]      NVARCHAR(Max),
	[City]		   VARCHAR(30),
	[ContactNo]    NVARCHAR(20),
	[Email]		   NVARCHAR(50)
	Primary Key ([SupplierId]),
);


Create table [ADO].[Product_Details]
(
	[ProductId] int IDENTITY(300,1) ,
	[ProductName] varchar(50) Not null,
	[SupplierId] INT not null,
	Primary Key ([ProductId]),
	CONSTRAINT FK_SupplierProduct_Key FOREIGN KEY ([SupplierId]) REFERENCES [ADO].[Supplier_Info] ([SupplierId]),
	
);