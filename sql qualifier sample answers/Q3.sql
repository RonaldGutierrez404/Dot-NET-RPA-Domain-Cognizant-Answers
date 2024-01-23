-- 3.Write a query to display the policy details such as policy id, name, minimum premium amount and the new premium amount of all the policies. 
-- The new premium amount is calculated based on the following conditions:
-- If the bonus is less than 50 then increase 2000 to the minimum premium amount.
-- If the bonus is greater than or equal to 50 and less than 75 then increase 1000 to the minimum premium amount.
-- If the bonus is greater than or equal to 75 percent then increase 500 to the minimum premium amount.
-- Give an alias name for calculated amount as 'NEW_PREMIUM_AMOUNT'. 
-- Sort the result set based on policy name in descending order.

SELECT 
    POLICY_ID, 
    POLICY_NAME, 
    MINIMUM_PREMIUM_AMOUNT,
    CASE
        WHEN BONUS_PERCENTAGE < 50 THEN MINIMUM_PREMIUM_AMOUNT + 2000
        WHEN BONUS_PERCENTAGE >= 50 AND BONUS_PERCENTAGE < 75 THEN MINIMUM_PREMIUM_AMOUNT + 1000
        ELSE MINIMUM_PREMIUM_AMOUNT + 500
    END AS NEW_PREMIUM_AMOUNT
FROM POLICY 
ORDER BY POLICY_NAME DESC;