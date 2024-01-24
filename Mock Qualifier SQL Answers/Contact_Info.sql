-- Write a query to display the id, name, address, and fare amount of all the customers who use 'gmail' as their email. If the address is not available, then display the phone number. If the phone number is unavailable, display 'Not Available'. 
-- Give an alias name as 'Contact_Info' for the address.

-- Sort the details based on the customer name in ascending order.

-- (Note: Data is case-sensitive.)

select
    c.customer_id,c.customer_name,
    coalesce(c.address, cast (c.phone_no as char), 'Not Available') as "Contact_Info",
    r.fare_amount
from customers c join rentals r
on c.customer_id=r.customer_id
where c.email_id like '%@gmail%'
order by c.customer_name asc;
