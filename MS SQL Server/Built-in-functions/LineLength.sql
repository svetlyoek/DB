USE demo;
SELECT Id, 
       SQRT(SQUARE(x1 - x2) + SQUARE(y1 - y2)) AS [Length]
FROM Lines;