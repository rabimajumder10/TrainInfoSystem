INSERT INTO Trains (TrainName, TrainNumber)
VALUES 
    ('Rajdhani Express', '12345'),
    ('Shatabdi Express', '67890'),
    ('Duronto Express', '11223'),
    ('Rajkot Express', '33445'),
    ('Mumbai Local', '99888');



INSERT INTO Classes (ClassName)
VALUES 
    ('Sleeper'),
    ('AC First Class'),
    ('AC Second Class'),
    ('AC Third Class'),
    ('Executive Class'),
    ('General Class');



INSERT INTO Fares (TrainId, ClassId, FareAmount)
VALUES 
    -- Rajdhani Express
    (1, 1, 300),  -- Sleeper Class
    (1, 2, 1500), -- AC First Class
    (1, 3, 800),  -- AC Second Class
    (1, 4, 1200), -- AC Third Class
    (1, 5, 2000), -- Executive Class
    (1, 6, 200),  -- General Class

    -- Shatabdi Express
    (2, 1, 250),  -- Sleeper Class
    (2, 2, 1000), -- AC First Class
    (2, 3, 500),  -- AC Second Class
    (2, 4, 800),  -- AC Third Class
    (2, 5, 1500), -- Executive Class
    (2, 6, 150),  -- General Class

    -- Duronto Express
    (3, 1, 350),  -- Sleeper Class
    (3, 2, 1800), -- AC First Class
    (3, 3, 900),  -- AC Second Class
    (3, 4, 1300), -- AC Third Class
    (3, 5, 2200), -- Executive Class
    (3, 6, 250);  -- General Class




	INSERT INTO TrainClasses (TrainId, ClassId)
VALUES 
    -- Rajdhani Express
    (1, 1),  -- Rajdhani Express, Sleeper Class
    (1, 2),  -- Rajdhani Express, AC First Class
    (1, 3),  -- Rajdhani Express, AC Second Class
    (1, 4),  -- Rajdhani Express, AC Third Class
    (1, 5),  -- Rajdhani Express, Executive Class
    (1, 6),  -- Rajdhani Express, General Class

    -- Shatabdi Express
    (2, 1),  -- Shatabdi Express, Sleeper Class
    (2, 2),  -- Shatabdi Express, AC First Class
    (2, 3),  -- Shatabdi Express, AC Second Class
    (2, 4),  -- Shatabdi Express, AC Third Class
    (2, 5),  -- Shatabdi Express, Executive Class
    (2, 6),  -- Shatabdi Express, General Class

    -- Duronto Express
    (3, 1),  -- Duronto Express, Sleeper Class
    (3, 2),  -- Duronto Express, AC First Class
    (3, 3),  -- Duronto Express, AC Second Class
    (3, 4),  -- Duronto Express, AC Third Class
    (3, 5),  -- Duronto Express, Executive Class
    (3, 6);  -- Duronto Express, General Class



	INSERT INTO Bookings (PassengerName, TrainId, ClassId, JourneyDate)
VALUES
    ('John Doe', 1, 1, '2025-06-15'),
    ('Jane Smith', 2, 3, '2025-06-18'),
    ('Amit Kumar', 3, 2, '2025-07-01'),
    ('Raj Patel', 1, 4, '2025-06-20'),
    ('Priya Verma', 2, 5, '2025-06-25'),
    ('Sandeep Singh', 3, 6, '2025-07-05');


	INSERT INTO PNRs (PNRNumber, Coach, BerthNumber, Status, BookingId)
VALUES
    ('PNR0001', 'A1', '12', 'Confirmed', 1),
    ('PNR0002', 'B2', '05', 'Confirmed', 2),
    ('PNR0003', 'C1', '18', 'Confirmed', 3),
    ('PNR0004', 'D2', '07', 'Confirmed', 4),
    ('PNR0005', 'A1', '03', 'Confirmed', 5),
    ('PNR0006', 'B3', '21', 'Confirmed', 6);


SELECT * FROM Trains;
SELECT * FROM Classes;
SELECT * FROM Fares;
SELECT * FROM TrainClasses;
SELECT * FROM Bookings;
SELECT * FROM PNRs;

delete from Bookings where BookingId in(7,8,9,10,11);
delete from Trains where TrainId in (4,5,6);