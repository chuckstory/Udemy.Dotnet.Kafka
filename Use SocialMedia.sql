-- Description: Creates the SMUser login and user.

Use SocialMedia
Go

IF NOT EXISTS(SELECT *
FROM sys.server_principals
where name = 'SMUser')
BEGIN
    CREATE LOGIN [SMUser] WITH PASSWORD=N'SmPA$$06500', DEFAULT_DATABASE=SocialMedia
END


IF NOT EXISTS(SELECT *
FROM sys.database_principals
where name = 'SMUser')
BEGIN
    EXEC sp_adduser 'SMUser', 'SMUser', 'db_owner'
END
