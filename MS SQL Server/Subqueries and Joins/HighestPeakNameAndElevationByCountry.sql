SELECT TOP (5) r.Country, 
               r.[Highest Peak Name], 
               r.[Highest Peak Elevation], 
               r.Mountain
FROM
(
    SELECT ctr.CountryName AS [Country], 
           IIF(p.PeakName IS NULL, '(no highest peak)', p.Peakname) AS [Highest Peak Name], 
           IIF(p.Elevation IS NULL, 0, p.Elevation) AS [Highest Peak Elevation], 
           IIF(m.MountainRange IS NULL, '(no mountain)', m.MountainRange) AS [Mountain], 
           DENSE_RANK() OVER(PARTITION BY ctr.CountryName
           ORDER BY p.Elevation DESC) AS RankElevation
    FROM Countries AS ctr
         LEFT JOIN MountainsCountries AS mc ON ctr.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS r
WHERE r.RankElevation = 1
ORDER BY r.[Country], 
         r.[Highest Peak Name] DESC;