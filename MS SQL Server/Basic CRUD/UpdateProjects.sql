UPDATE Projects
  SET 
      EndDate = '2017-01-23'
WHERE EndDate IS NULL;
SELECT *
FROM Projects;