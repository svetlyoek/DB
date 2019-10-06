SELECT k.ContinentCode, 
       k.CurrencyCode, 
       k.CurrencyUsage
FROM
(
    SELECT ctr.ContinentCode, 
           ctr.CurrencyCode, 
           COUNT(ctr.CurrencyCode) AS [CurrencyUsage], 
           DENSE_RANK() OVER(PARTITION BY ctr.ContinentCode
           ORDER BY COUNT(ctr.CurrencyCode) DESC) AS [CurrencyRank]
    FROM Countries AS ctr
    GROUP BY ctr.ContinentCode, 
             ctr.CurrencyCode
    HAVING COUNT(ctr.CurrencyCode) > 1
) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode;