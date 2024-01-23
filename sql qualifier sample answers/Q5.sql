-- 5. Write a query to display the name and number of tickets booked by the users whose phone number is unavailable. Give an alias name as 'No_Of_Tickets' for the number of tickets booked by the user.
-- Sort the results based on the user name in descending order.


SELECT u.NAME, COUNT(t.TICKET_ID) as No_Of_Tickets 
FROM USERS u
LEFT JOIN TICKETS t ON u.USER_ID = t.USER_ID 
WHERE u.PHNO IS NULL 
GROUP BY u.NAME 
ORDER BY u.NAME DESC;