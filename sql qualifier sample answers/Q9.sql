-- 9. Write a query to display the unique name and experience of all the sailors that rode the boats. Display the experience of the sailor with no decimal value.
-- Give an alias name for the experience of the sailor as EXPERIENCE. 
-- Sort the records based on the sailor's name in descending order.
-- (Hint: Use round().)

SELECT DISTINCT s.Sailor_name, ROUND(s.Experience) AS EXPERIENCE
FROM Sailor_Details s
JOIN Ride_Details r ON s.Sailor_id = r.Sailor_id
ORDER BY s.Sailor_name DESC;
