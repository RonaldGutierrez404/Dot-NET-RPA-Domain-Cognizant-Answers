-- Write a query to display the customer id, name, address and pass_code for all the customers who have 'gmail' account.
-- Pass code is generated by concatenating the first 3 characters of the customer id and the first 3 characters of the email id and give alias name as 'pass_code'.
-- Sort the records based on the customer id in descending order.

select
    c.customer_id,
    c.customer_name,
    c.address,
    concat(substring(c.customer_id,1,3), substring(c.email_id,1,3)) as "pass_code"
from customers c
where c.email_id like '%gamil%'
order by c.customer id desc;