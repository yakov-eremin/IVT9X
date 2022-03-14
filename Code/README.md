# Как запустить программу?

1. Необходимо скачать полностью данную папку. 
2. Установить на компьютер .NET 6.0. <a href = "https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime?cid=getdotnetcore" > Ссылка </a>
3. Установить на компьютер PostgresSQL. <a href = "https://www.postgresql.org/download/" > Ссылка</a>
3.1. С помощью Stack Builder установить pgAgen.
![alt text](./Screenshots_for_readme/Stack_builder.jpg)
4. Восстановить базу данных (С помощью pgAdmin4)<br>
4.1. Необходимо создать пустую базу данных <br>
4.2. Восстановить с помощью SQL скрипта (***Global_object.sql***) все глобальны объекты.<br>
4.3. С помощью графического интерфейса pgAdmin4 это делается вот так <br>1) Необходимо выбрать созданную базу данных<br>2) Нажать на кнопку для содание Query Editor<br>3) Открыть файл ***Global_object.sql*** <br>4) Запустить скрипт<br>![alt text](./Screenshots_for_readme/Vost_global_obj.jpg)![alt text](./Screenshots_for_readme/Vost_global_obj_1.jpg)<br>
    4.4. Восстановить базу данных <br>1) ПКМ по базе данных <br> 2) Восстановить (restore)<br>3) Выбрать файл ***backupDB.backup***<br>4) Нажать на кнопку Восстановить<br>![alt text](./Screenshots_for_readme/Restore_backup.jpg) <br>

5. Для восстановление базы данных с командной строки необходимо воспользоваться утилитой pg_restore.
6. Запустить **Education_organisation.exe**. 
