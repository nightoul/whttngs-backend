
MIGRACE
1. create migration folder and files:
dotnet ef migrations add InitialCreate

2. run migrations:
dotnet ef database update


connect to railway pro db via terminal:
/Applications/MAMP/Library/bin/mysql -hautorack.proxy.rlwy.net -uroot -pbysVuGledWvygfefHsNbIdETecnCrdFb --port 52891 --protocol=TCP railway

