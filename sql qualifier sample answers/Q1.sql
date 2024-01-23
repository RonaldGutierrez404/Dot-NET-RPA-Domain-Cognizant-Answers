-- 1.Write a query to display the details like the customer name, phone number, plan amount, and recharge date of all the customers whose plan expired in January, 2000.Sort the results based on the phone number in ascending order.

SELECT c.CUSTOMER_NAME, s.PHONE_NUMBER, s.PLAN_AMOUNT, s.RECHARGE_DATE 
FROM CUSTOMER c 
JOIN SUBSCRIPTION s ON c.PHONE_NUMBER = s.PHONE_NUMBER 
WHERE MONTH(s.EXPIRY_DATE) = 1 AND YEAR(s.EXPIRY_DATE) = 2000 
ORDER BY s.PHONE_NUMBER ASC;