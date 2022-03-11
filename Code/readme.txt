Для того, чтобы собрать проект необходима предварительная установка DotNet 5.0 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
Далее открыть терминал в папке с проектом и воспользоваться командой dotnet build для DEBUG сборки или dotnet build --configuration Release для Release сборки
Теперь нужно восстановить БД в MS SQL Server 2019 (https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads).
Для этого нужно скачать .bak файл из репозитория и выполнить следующий T-SQL скрипт:
USE [master]
RESTORE DATABASE [leasing_cars_db] 
FROM DISK = N'.bak_file_path' WITH  FILE = 1,  NOUNLOAD,  STATS = 5
GO
.bak_file_path - путь к скачанному файлу .bak.