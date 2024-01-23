-- Write a query to display the car name and the sum of the fare amount of all the cars that picked and returned  in the same month and has the sum of total fare amount less than 20000.

-- Give the alias name for the sum of the fare amount as Total_Fare.

 
-- Sort the records based on the Total_Fare in ascending order. 

select c.car_name, sum(r.fare_amount) as "Total_Fare" from cars c join rentals r
on c.car_id=r.car_id
where month(r.pickup_date)=month(r.return_date) group by c.car_name
having sum(r.fare_amount) <20000
order by Total_Fare asc;