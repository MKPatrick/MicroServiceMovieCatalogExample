## Backend
Project is splitted up in 4 Major Projects
- Catalog => Movie Catalog with all movies
- Review => All reviews for each movie
- Stream => Stream for each movie
- Gateway => Handles requests to each service

### Technologies
- Use REST-API
- Use Fluent-Validation
- Use Microservices-Architecture
- Domain Driven Design ( Clean Architecture)
- Use Messaging AMQP(RabbitMQ)
- Use EF-Core
- Swagger Open-API
- USE CQRS in Streaming Project with Mediator Pattern (MediatR)
- Use API-Gateway(Ocelot)
- Use docker-compose for setting up environment
- MOQ & Fixture for Unit-Testing
- Use Polly for Retry Strategy
### Communication
All 3 Service-projects have RabbitMQ.Client implemented to give them the ability to send via AMQP.
Catalog gets also data from the review service synchronos with HTTP-Restfull.
Review & Stream gets with AMQP notified when a movie is deleted to clean up the database. (Message as fanout)


### Addiontal Information
For productive system, close the exposed ports in docker-compose. Communication is handled inside and should be only
reachable through API-Gateway(ocelot).
Currently Containers are configured with restart policy: "unless-stopped" => RabbitMQ needs startup time, this can be fixed in future with health check.


### Configuration (Connectionstring, RabbitMQ)
Can be configured with appsettings.json in each project or with Environment variable. (See docker-compose)


### Architecture Overview

![Backend Architecture](/imgs/backend.png)


### Endpoints
With the current ocelot configuration following endpoints are exposed:
- /api/m/{everything} => MovieCatalog

- /api/r/{everything} => MovieReviewA

- /api/s/{everything} => MovieStream

- /MovieImages/{everything} => Get movie images from MovieCatalog volume

- /Streams/{everything} => Get movie streams from MovieStreams volume
