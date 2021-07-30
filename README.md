# RestoranAppExample
Angular/.Net web app example with tests demonstrating n-tier architecture and some SOLID principles

Screenshoot: https://i.imgur.com/EKsUpwM.png

##How to run?
1. You need to have Visual Studio (https://visualstudio.microsoft.com/downloads/) and NodeJs (https://nodejs.org/en/download/) installed. 
2. Open .sln file in Visual studio. You should get notification to build node modules automatically. Use it. Otherwize you can build them manually:
   a) Open command prompt and navigate to subfolder F4CIO.Restro.UIWeb\ClientApp
   b) Run command: npm install
   c) Your subfolder F4CIO.Restro.UIWeb\ClientApp\node_modules should be populated with files.
3. Run soultion in Visual studio.

##Architecture
Example is composed of two parts: front-end web app (angular) and backend api (.net).

N-tier architecture applied on backend part is shown in this diagram: https://i.imgur.com/ZURZJ9D.png
Each upper layer is depenable on first lower layer making replacement (like SQL with Oracle db) and extension (like adding mobileApp front-end or caching layer) simple.
Handlers represent functionality -horizontal separation. Example demonstrates two groups of functionalities:
1. resturant ordering -see OrderHandler.cs files in business logic and data layers.
2. chat rooms and messaging -see other ...Handler.cs files (this functionality is actually remaining of my another app which I didn't want to delete in order to demonstrate something below)

##Short theory on each layer:
톀estro.Entities: This layer provides a suite of objects (POCOs) that represent domain entities as well as data transfer objects.
톀estro.Common: This layer provides a suite of common reusable components and helpers that are meant to be used by most other layers.
텰lient-app: responsible for facilitating user interaction. This includes displaying information to the user and passing user inputs to the API layer for processing.
톀estro.UIWeb: The purpose of this layer is to expose the TS.BusinesLogic methods on a network. This layer performs no logic on its own.
톀estro.BusinessLogic: This layer is responsible for implementing the applications business rules. It is important that the Business Logic classes do not directly access data but instead for data IO they uses uniform way to access lower layer. In this layer developer will work most of time when implementing backend for new functionalities and not working on architecture. This layer should also encapsulate all methods with exception handling and logging blocks/mechanisms.
톀estro.Cache: Cashing of data neccessary for business layer could be done here. One implemetation is to copy all method signitures from data layer to make methods in this layer and whenever arguments values already exist in memory from previoues call use result from memory instead fetching from lower layer with some time expiration.
톀estro.Data: This layer provides methods for performing CRUD operations. One of the main purposes of this layer is to serve as an abstraction for the persistence framework in the persistence layer like SQL layer. This makes it easy to change persistence layers without affecting the tiers that consume their functionality. Nowdays, Entity Framework already provides this abstraction so its commands could be written here ommiting need for SQL layer.
톀estro.SQL: This layer is responsible for performing CRUD operations by directly communicating with the underlying database/data store like MS SQL DB. Not implemented in this example.

##Example demonstrates two implementations of testing and instantiating handlers in layers:
1. dependency injection approach -here we pass lower layer handler to constructors in current layer. Lower layer method is called like this: _dlHandlerForOrders.InsertOrder(m); When testing handlers from lower layers that return fake data are pre-created and passed to these constructors. See full tests at F4CIO.Restro.UIWeb.Test
2. classic singleton approach -here we instantiate handlers of lower layer as singletons by using Handlers.Factory.cs. This happens implicitly so programer has to call lower layer with one line for example from business logic can call:  F4CIO.Restro.Data.HandlersFactory.HandlerForRooms.GetRoomById(chatRoomId); When testing lower layer is pre-created with some fake data and set to singleton. See full tests in Carlabs.Restro.BusinessLogic.Test

A lot can be added to solution to make it enterprise level (exception handling, logging, etc)

##Front-end web app
Front-end web app, Angular implementation, is located in F4CIO.Restro.UIWeb\ClientApp. You can run it via command prompt buy navigating to that folder and issuing this command:
npm run ng server --open
and navigating your browser to suggested url. 
You must have backend running to serve api requests.