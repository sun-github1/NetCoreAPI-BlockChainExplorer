BlockChain Explorer 
----------------------------------------------------------
This is a .NET Core Web API Application that fetches and stores available ETH, Dash, BTC blockchains using BlockCypher API. 

This is a data driven web api built using clean architecture pattern.  
It connects to a dokerized SQL server Database using Entity Framework Core.  
It follows Repository and Unit Of Work Patterns and Dependency Injection.  
it uses Mediatr CQRS pattern  
Serilog is used for logging purpose  
Unit tests are included for Application Project  



To Configure For Local Use
---------------------------
Clone Repository To Local Computer  
Open solution in Visual Studio  
Edit "DefaultConnection" to point to preferred database   
Open Package Console Manager and run the command "Update-Database"  
When completed, set BlockchainExplorer.API as start up project and run.  
Postman collection is included (ths collection along with environment can be imported directly in postman and tested)  
Endpoints are:   
https://localhost:7023/api/coins/cointype/btc  
https://localhost:7023/api/coins/cointype/eth  
https://localhost:7023/api/coins/cointype/dash  
https://localhost:7023/api/coins/hash/{{hashid}}  
