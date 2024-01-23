-- 4. Write a query to display the subscription information of all the customers who haven't subscribed. Give an alias name as "SUBSCRIPTION_INFO".
-- Sort the records based on the SUBSCRIPTION_INFO in ascending order.
-- Sample Data:
-- SUBSCRIPTION_INFO 
-- CUSTOMER_NAME hasn't subscribed yet
-- Sample Output:
-- SUBSCRIPTION_INFO  
-- James Jackson hasn't subscribed yet


SELECT CONCAT(c.CUSTOMER_NAME, " hasn't subscribed yet") AS SUBSCRIPTION_INFO
FROM CUSTOMER c
LEFT JOIN SUBSCRIPTION s ON c.PHONE_NUMBER = s.PHONE_NUMBER
WHERE s.PHONE_NUMBER IS NULL
ORDER BY SUBSCRIPTION_INFO ASC;
