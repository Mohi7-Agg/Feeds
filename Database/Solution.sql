-- 1) Select users whose id is either 3,2 or 4

SELECT * FROM  USERS WHERE ID IN(3,2,4)

 -- 2. Count how many basic and premium listings each active user has
 -- Please return at least: first_name, last_name, basic, premium

 SELECT U.first_name, U.last_name,filtered.status, filtered.count FROM USERS U, 
 ( SELECT L.user_id as Id, L.status as status, COUNT(L.status) as count FROM
 LISTINGS L
 GROUP BY L.user_id, L.status
 HAVING L.user_id IS NOT NULL
 ) filtered
 WHERE U.id = filtered.Id

 --  3. Show the same count as before but only if they have at least ONE premium listing
-- Please return at least: first_name, last_name, basic, premium

 SELECT U.first_name, U.last_name,filtered.status, filtered.count FROM USERS U, 
 ( SELECT L.user_id as Id, L.status as status, COUNT(L.status) as count FROM
 LISTINGS L
 GROUP BY L.user_id, L.status
HAVING L.user_id IS NOT NULL AND L.user_id IN (SELECT DISTINCT(user_id) FROM LISTINGS WHERE [status] = 3)
 ) filtered

 WHERE U.id = filtered.Id

 -- 4. How much revenue has each active vendor made in 2013
-- Please return at least: first_name, last_name, currency, revenue

SELECT U.first_name,U.last_name, filtered.revenue, filtered.currency FROM USERS U, (
SELECT  L.user_Id as user_id  ,SUM (C.price) as revenue, C.currency as currency from Listings L
JOIN CLICKS C
ON C.listing_id = L.id
WHERE YEAR(C.created) = 2013 AND 
L.user_Id IS NOT NULL  
GROUP BY L.user_id, C.currency
) filtered
WHERE U.id= filtered.user_id


 -- 5. Insert a new click for listing id 3, at $4.00
-- Find out the id of this new click. Please return at least: id

-- As Id column in Identity
INSERT INTO clicks VALUES (3,4.00,'USD',GETDATE())
SELECT SCOPE_IDENTITY() AS [id];


-- 6. Show listings that have not received a click in 2013
-- Please return at least: listing_name

SELECT DISTINCT(L.name) from Listings L
JOIN CLICKS C
ON C.listing_id = L.id
WHERE YEAR(C.created) <> 2013



--7. For each year show number of listings clicked and number of vendors who owned these listings
-- Please return at least: date, total_listings_clicked, total_vendors_affected


SELECT YEAR(C.created) as [Year] ,COUNT(Distinct(L.user_id)) as VendorsCount, Count(L.id) as ListingCount  from Listings L
JOIN CLICKS C
ON C.listing_id = L.id
WHERE L.User_id IS NOT NULL
GROUP BY YEAR(C.created)
ORDER By YEAR(C.created)


-- 8. Return a comma separated string of listing names for all active vendors
-- Please return at least: first_name, last_name, listing_names

 SELECT U.first_name, U.last_name, filtered.listing_names 
FROM USERS U, 
( SELECT  L.user_id as user_Id, listing_names = 
				STUFF((SELECT ', ' + L2.name
						   FROM Listings L2
						   WHERE L2.user_Id = L.user_Id
						  FOR XML PATH('')), 1, 2, '')
FROM Listings L
WHERE L.user_id IS NOT NULL
GROUP BY L.user_id) filtered
WHERE U.Id = filtered.user_Id

