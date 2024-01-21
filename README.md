# Hangfire Sample

This repository contains a minimal Hangfire project which shows how to integrate Hangfire with ASP.NET Core and PostgreSQL.

There is a docker compose file in the solution which has all required dependecies. You can run the sample on your enviroment running command `docker-compose up -d` in the root folder of the solution or using Visual Studio.

The project has two simple jobs. The background one will run in 10 seconds after the application starts. The recurring one runs every one minute. You can use Docker's or Visual Studio's log console to see that they works.
