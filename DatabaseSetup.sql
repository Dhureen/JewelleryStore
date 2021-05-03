Create Database JewelleryStore
Go

Use JewelleryStore
Go

Create table UserProfile
(
	Id int primary key identity,
	Name nvarchar(255),
	Type int,
	DiscountPercentage float,
	Password nvarchar(255)
);
Go

Insert into UserProfile values('Normal', 1, 0, 'Normal'), ('Privileged', 2, 2, 'Privileged');
Go