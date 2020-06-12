Create TABLE Users (
UserID int not null,
UserName char(10) not null,
ClientID int not null,
PRIMARY KEY(UserID)
);

Create TABLE Orders(
OrderID int not null,
Total decimal(6,2) not null,
UserID int not null,
PRIMARY KEY(OrderID)
);

Insert into Users Values
(1,'Audis',5),
(2,'Balius',5),
(3,'Diena',6),
(4,'Eva',7);

Insert into Orders Values
(11,100.00,1),
(33,1000.00,2),
(55,100.00,7),
(77,100.0,4);