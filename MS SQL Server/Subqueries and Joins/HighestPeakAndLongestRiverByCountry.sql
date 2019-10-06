SELECT TOP (5) ctr.CountryName, 
               MAX(p.Elevation) AS [HighestPeakElevation], 
               MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS ctr
     FULL JOIN MountainsCountries AS mc ON ctr.CountryCode = mc.CountryCode
     FULL JOIN Mountains AS m ON mc.MountainId = m.Id
     FULL JOIN Peaks AS p ON m.Id = p.MountainId
     FULL JOIN CountriesRivers AS cr ON mc.CountryCode = cr.CountryCode
     FULL JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY ctr.CountryName
ORDER BY MAX(p.Elevation) DESC, 
         MAX(r.Length) DESC, 
         ctr.CountryName ASC;