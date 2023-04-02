BEGIN TRAN

SELECT name FROM videogames WHERE name like 'r%'

ROLLBACK