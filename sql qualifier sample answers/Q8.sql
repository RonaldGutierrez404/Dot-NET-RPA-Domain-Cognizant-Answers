-- 8. Write a query to display the cake id, cake name, cake type and price per kg of the cakes that are not ordered.
-- Sort the results based on the cake name in ascending order.

SELECT c.Cake_id, c.Cake_name, c.Cake_type, c.Price_per_kg 
FROM CAKES c 
LEFT JOIN ORDER_DETAILS od ON c.Cake_id = od.Cake_id 
WHERE od.Order_id IS NULL 
ORDER BY c.Cake_name ASC;
