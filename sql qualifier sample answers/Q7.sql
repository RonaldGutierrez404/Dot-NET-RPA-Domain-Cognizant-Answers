-- 7. Write a query to display the Customer's name and street of all the customers who have email. Give an alias name for the street as STREET. 

-- Sort the records based on the STREET in descending order.
-- Sample Data:
-- PHONE_NUMBER	CUSTOMER_NAME 	EMAIL_ID	ADDRESS
-- 9952882017	Will Smith	will002@gmail.com	Lombard Street,San Diego



-- Sample Output:
-- CUSTOMER_NAME	STREET
-- Will Smith	Lombard Street

SELECT CUSTOMER_NAME, ADDRESS AS STREET
FROM CUSTOMER
WHERE EMAIL_ID IS NOT NULL 
ORDER BY STREET DESC;
