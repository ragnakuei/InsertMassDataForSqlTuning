# InsertMassDataForSqlTuning

CTE 遞迴練習

<pre><code>
select d.Id, d.Code as DeptCode, d.ParentId , dl.Code as DeptLevelCode , dl.[Index] as DeptLevelIndex
INTO #DeptInfo
from dbo.Dept d
join dbo.DeptLevel dl on dl.Id = d.DeptLevelId

select *
from #DeptInfo

;with deptTree as (
	select id, DeptCode, ParentId, DeptLevelCode, DeptLevelIndex,
            CAST('' AS NVARCHAR(200)) as Level0UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level1UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level2UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level3UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level4UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level5UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level6UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level7UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level8UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level9UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level10UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level11UpperDeptCode,
            CAST('' AS NVARCHAR(200)) as Level12UpperDeptCode
	from #DeptInfo
	where ParentId is NULL
	union all
	select d.id, d.DeptCode, d.ParentId, d.DeptLevelCode, d.DeptLevelIndex,
        CASE tree.DeptLevelIndex WHEN 0 THEN tree.DeptCode ELSE tree.Level0UpperDeptCode END as Level0UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 1 THEN tree.DeptCode ELSE tree.Level1UpperDeptCode END as Level1UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 2 THEN tree.DeptCode ELSE tree.Level2UpperDeptCode END as Level2UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 3 THEN tree.DeptCode ELSE tree.Level3UpperDeptCode END as Level3UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 4 THEN tree.DeptCode ELSE tree.Level4UpperDeptCode END as Level4UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 5 THEN tree.DeptCode ELSE tree.Level5UpperDeptCode END as Level5UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 6 THEN tree.DeptCode ELSE tree.Level6UpperDeptCode END as Level6UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 7 THEN tree.DeptCode ELSE tree.Level7UpperDeptCode END as Level7UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 8 THEN tree.DeptCode ELSE tree.Level8UpperDeptCode END as Level8UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 9 THEN tree.DeptCode ELSE tree.Level9UpperDeptCode END as Level9UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 10 THEN tree.DeptCode ELSE tree.Level10UpperDeptCode END as Level10UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 11 THEN tree.DeptCode ELSE tree.Level11UpperDeptCode END as Level11UpperDeptCode,
        CASE tree.DeptLevelIndex WHEN 12 THEN tree.DeptCode ELSE tree.Level12UpperDeptCode END as Level12UpperDeptCode
	from #DeptInfo d
	join deptTree tree on tree.id = d.parentid
)

SELECT *
from deptTree

drop table #DeptInfo
</code></pre>

