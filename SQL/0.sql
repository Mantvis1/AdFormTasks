CREATE TABLE Users (
  UserID int NOT NULL, 
  UserName char(10) NOT NULL, 
  ClientID int NOT NULL, 
  PRIMARY KEY(UserID)
);

CREATE TABLE Orders(
  OrderID int NOT NULL, 
  Total decimal(6, 2) NOT NULL, 
  UserID int NOT NULL, 
  PRIMARY KEY(OrderID)
);

INSERT INTO Users 
VALUES 
  (1, 'Audis', 5), 
  (2, 'Balius', 5), 
  (3, 'Diena', 6), 
  (4, 'Eva', 7);

INSERT INTO Orders 
VALUES 
  (11, 100.00, 1), 
  (33, 1000.00, 2), 
  (55, 100.00, 7), 
  (77, 100.0, 4);
