SELECT COUNT(ctr.CountryCode) AS [CountryCode]
FROM Countries AS ctr
     LEFT JOIN MountainsCountries AS mc ON ctr.CountryCode = mc.CountryCode
     LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE m.Id IS NULL;