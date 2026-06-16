SELECT
    S.Id,
    S.Name,
    S.HourlyRate,
    P.Name AS ProviderName
FROM Services S
INNER JOIN Providers P
    ON P.Id = S.ProviderId
WHERE P.Id = 1
ORDER BY S.Name;


SELECT
    (SELECT COUNT(*) FROM Providers) AS Providers,
    (SELECT COUNT(*) FROM Services) AS Services,
    (SELECT AVG(HourlyRate) FROM Services) AS AverageHourlyRate;

