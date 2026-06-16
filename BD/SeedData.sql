INSERT INTO Providers
(
    Nit,
    Name,
    Email,
    Website
)
VALUES
('900000001','Provider 1','provider1@test.com','https://provider1.com'),
('900000002','Provider 2','provider2@test.com','https://provider2.com'),
('900000003','Provider 3','provider3@test.com','https://provider3.com'),
('900000004','Provider 4','provider4@test.com','https://provider4.com'),
('900000005','Provider 5','provider5@test.com','https://provider5.com'),
('900000006','Provider 6','provider6@test.com','https://provider6.com'),
('900000007','Provider 7','provider7@test.com','https://provider7.com'),
('900000008','Provider 8','provider8@test.com','https://provider8.com'),
('900000009','Provider 9','provider9@test.com','https://provider9.com'),
('900000010','Provider 10','provider10@test.com','https://provider10.com');


INSERT INTO Services
(
    Name,
    HourlyRate,
    ProviderId
)
VALUES
('Backend Development',50,1),
('Frontend Development',45,2),
('Mobile Development',60,3),
('Cloud Architecture',90,4),
('DevOps',80,5),
('QA Automation',40,6),
('Power BI',55,7),
('Database Administration',70,8),
('Cybersecurity',100,9),
('Technical Support',35,10);
