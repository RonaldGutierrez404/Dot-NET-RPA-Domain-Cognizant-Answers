-- Write a query to display the patient id, first name, city and contact number of the patients who took more than a day to pay their bill.
-- Sort the results based on the bill number in descending order.
-- (Hint: Use bill date, pay date.)
-- Sample Data
-- Patient_id                 p_first_name              city                 bill_date              pay_date
-- P1                              David                           Miami            12-10-2022         12-10-2022
-- P2                              Peter                            Boston          08-11-2022         09-11-2022
-- P3                              Michael                       Washington  21-12-2022         25-10-2022

-- Sample Output:
-- Patient_id                 p_first_name              city
-- P3                              Michael                        Washington


SELECT p.Patient_id, p.p_first_name, p.city, p.Contact_number 
FROM PATIENT p 
JOIN APPOINTMENT a ON p.Patient_id = a.Patient_id 
JOIN BILL b ON a.App_number = b.App_number 
JOIN PAYMENT pay ON b.Bill_number = pay.Bill_number 
WHERE DATEDIFF(pay.pay_date, b.bill_date) > 1 
ORDER BY b.Bill_number DESC;