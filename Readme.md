#create docker network
docker network create --attachable -d bridge mydockernetwork

#step

1. run -> docker-compose up -d
2. run mongo -> docker run -it -d --name mongo-container -p 27017:27017 --network mydockernetwork --restart always -v mongodb_data_container:/data/db mongo:latest
3. run sqlserver -> docker run --name sql-container --network mydockernetwork --restart always -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=$tr0ngS@P@ssw0rd02' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

4. Generate launch.json -> ctl + p -> .Net Generate Asset for build and debug

5. The SQL script 'UseSocialMedia.sql' is used to create a new user.
6. To create and SQL Database for this project, follow these steps:
   1. Run the program "Post.Query.Api" using the old connectionstring that login with the user "SA"
   2. After completing the first step, the database will be created.
   3. Use the script "Use SocialMedia.sql" to create a new user for logging in.
   4. Once you have completed the first three steps, you will be able to run the "Post.Query.Api" program using the new connectionstring that login with the newly created user
