-- Write a query to display the car name and total number of days the car was rented, if and only if the car was rented for the maximum number of days in the month of 'May'.
-- Give an alias name as 'No_of_Days' for the number of days the car was rented.

select 
    c.car_name,
    sum(DATEDIFF(r.return_date,r.pickup_date)) as "No_of_Days"
from cars c join rentals r
on c.car_id=r.car_id
where month(r.pickup_date)=5
group by c.car_id
order by No_of_Days desc
limit 1;