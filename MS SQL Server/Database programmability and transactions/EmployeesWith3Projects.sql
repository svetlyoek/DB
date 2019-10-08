create procedure usp_AssignProjects(@EmployeeID int,@ProjectID int)
as begin
declare @maxProjectsCount int=3
declare @projectCount int
set @projectCount=
(select count(*)
from EmployeesProjects as ep
where ep.EmployeeID=@EmployeeID)
if(@projectCount>=@maxProjectsCount)
begin
THROW 50001,'The employee has too many projects!', 1;
end
insert into EmployeesProjects(EmployeeID,ProjectID)values
(@EmployeeID,@ProjectID)

