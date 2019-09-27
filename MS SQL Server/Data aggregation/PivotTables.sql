SELECT *
FROM DailyIncome PIVOT(AVG(IncomeAmount) FOR IncomeDay IN([MON], 
                                                          [TUE], 
                                                          [WED], 
                                                          [THU], 
                                                          [FRI], 
                                                          [SAT], 
                                                          [SUN])) AS AvgIncomePerDay;