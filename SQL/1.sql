SELECT 
  ISNULL(CAST(Users.ClientID AS char(3)), 'n/a') AS ClientID, 
  ISNULL(Sum(Orders.Total), 0.00) AS Total 
FROM Users 
FULL OUTER JOIN Orders ON Users.UserID = Orders.UserID 
GROUP BY (Users.ClientID);