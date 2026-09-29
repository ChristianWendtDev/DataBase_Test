-- opgave 1 Find all hotels
SelecT * FROM Hotel

-- opgave 2 Find name of all customers

SELECT Name From Customer

-- opgave 3 Finde alle hoteller i Odense

SELECT * FROM Hotel
Where Address LIKE '%Odense%'

-- opgave 4 Finde de billige Værelse

SELECT price From Room
Where price =(SELECT MIN (price) FROM Room)

-- opgave 5 Finde værelse med højeste antal sengepladser

SELECT Capacity FROM Room
Where Capacity =(SELECT MAX (Capacity) FROM Room)

-- opgave 6 Finde alle værelser sorteret efter pris (lav-høj)

SELECT price FROM Room
ORDER BY price ASC

-- opgave 7 Finde alle værelser sorteret efter pris (høj-lav)

SELECT price FROM Room
ORDER BY price DESC

-- opgave 8  Finde alle hoteller med tilhørende værelser

SELECT * FROM Hotel h
JOIN Room r on h.Id = r.HotelID

-- opgave 9  Finde alle hoteller med værelser der er booket

SELECT * FROM Hotel h
JOIN Booking b on h.Id = b.HotelID 

-- 10 Finde alle hoteller rangordnet efter gennemsnits priser på værelser

SELECT h.Id, h.Name, AVG(r.Price) as AveragePrice FROM Hotel h
JOIN Room r on h.Id = r.HotelID
GROUP BY h.Id, h.Name
ORDER BY AveragePrice ASC

-- opgave 11 Finde navnet, værelses nummer og kunde navn på alle bookinger

SELECT h.Name, r.Number, c.Name FROM Booking b
JOIN Hotel h on b.HotelId = h.Id
JOIN Room r on b.RoomNumber = r.Number AND b.HotelId = r.HotelId
Join Customer c on b.CustomerId = c.Id

-- opgave 12 Finde alle værelser (+hoteller) der har en booking i efterårsferien

SELECT r.Number, h.Name, b.CheckInDate, b.CheckOutDate FROM Hotel h
JOIN Room r on h.Id = r.HotelId
JOIN Booking b on h.Id = b.HotelId and r.Number = b.RoomNumber
WHERE b.CheckInDate BETWEEN '2026-10-12' AND '2026-10-18'
OR b.CheckOutDate BETWEEN '2026-10-12' AND '2026-10-18'
GROUP BY r.Number, h.Name, b.CheckInDate, b.CheckOutDate

-- opgave 13  For hvert hotel find hvor mange penge de får ind på værelser der er udlejet i efterårsferien

SELECT 
SUM(DATEDIFF(day,b.CheckInDate,b.CheckOutDate) * r.price) as TotalRevenue,
h.Name 
FROM Hotel h
Join Room r on h.Id = r.HotelId
Join Booking b on h.Id = b.HotelId and r.Number = b.RoomNumber
WHERE b.CheckInDate BETWEEN '2026-10-12' AND '2026-10-18'
or b.CheckOutDate BETWEEN '2026-10-12' AND '2026-10-18'
GROUP BY h.Name
ORDER BY TotalRevenue DESC






