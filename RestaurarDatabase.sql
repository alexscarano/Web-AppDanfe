-- Listar nomes lógicos  
/*RESTORE FILELISTONLY
FROM DISK = '/var/opt/mssql/backup/Eproc_121_07_11_2024.bak';*/




RESTORE DATABASE Eproc_121
FROM DISK = '/var/opt/mssql/backup/Eproc_121_07_11_2024.bak'
WITH REPLACE,
     MOVE 'eProc_Data' TO '/var/opt/mssql/data/Eproc_121.mdf',
     MOVE 'eProc_Log' TO '/var/opt/mssql/log/Eproc_121.ldf';
