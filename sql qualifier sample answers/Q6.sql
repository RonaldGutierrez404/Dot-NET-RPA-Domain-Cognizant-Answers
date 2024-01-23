-- 6. Write a query that displays the id, name, source, and destination of all flights that are not booked by any passengers.
-- Sort the results in descending order based on the flight id.

SELECT Flight_id, Flight_name, Flight_source, Flight_destination 
FROM Flight_details 
WHERE Flight_id NOT IN (SELECT Flight_id FROM Booking) 
ORDER BY Flight_id DESC;