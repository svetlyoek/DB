USE Geography;
CREATE VIEW v_HighestPeak
AS
     SELECT TOP (2) *
     FROM Peaks
     ORDER BY Elevation DESC;
SELECT *
FROM v_HighestPeak;