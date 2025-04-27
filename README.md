# OTAssessment

In the dynamic world of online betting, capturing and analyzing data is paramount for business success. Every time a player initiates a spin in a casino game, it's essential to capture and store relevant data. This project aims to develop an API and service capable of receiving, storing, and retrieving player casino data.

This solution leverages dockers ability to containerize services and introduce a great seperation of concerns.

## Architecture Overview

The system is designed to simulate a scenario where we useing `nbomber` to flood the API. The flow works as follows:

1. **Tester (nbomber):**  
   The `nbomber` project is used to generate a high volume of requests to the API, simulating a flood of interactions.

2. **API:**  
   The API receives the load from `nbomber` and processes the requests, sending events to the next component in the flow -> the producer worker.

3. **Producer Worker:**  
   The producer worker listens for changes or events from the API and sends these events to a RabbitMQ queue.

4. **RabbitMQ:**  
   RabbitMQ is used as the message broker to decouple the producer and consumer workers. It ensures that messages are queued and processed asynchronously.

5. **Consumer Worker:**  
   The consumer worker listens to the RabbitMQ queue, processes the messages, and populates the database with the results.

6. **Database (DB):**  
   The database receives the processed data from the consumer worker and stores it.

## Project Setup

### Prerequisites

Make sure you have the following tools installed:

- **Docker:** For running containers and managing services.
- **RabbitMQ:** Used as the message broker in this system.
- **Visual Studio:** To run and test the application.

### Running the Application

Follow these steps to set up and run the system:

1. **Clone the Repository and Secrets:**
   Clone the repo

   ```bash
   git clone https://github.com/thee1acer/OTAssessment.git
   cd OTAssessment
   ```

   Add secrets file ```.env``` in your root folder with fields:
   ```bash
      REFERENCE_DB__SERVER="mssql-server"
      REFERENCE_DB__DATABASENAME="OTAssessment"
      REFERENCE_DB__USER="sa"
      REFERENCE_DB__PASSWORD="5tr0ngP@55w0rD"
      
      ASPNETCORE_ENVIRONMENT="Development"
      
      RABBITMQ_HOST = "rabbitmq"
      RABBITMQ_PORT = "5672"
      RABBITMQ_USERNAME = "default"
      RABBITMQ_PASSWORD = "5tr0ngP@55w0rD"
      
      REDIS_HOST="redis-tsl"
      REDIS_PORT="6379"
      REDIS_USERNAME="default"
      REDIS_PASSWORD="5tr0ngP@55w0rD"
   ```

3. **Build and Run the Docker Containers:**

   The project uses Docker for containerization. On mounting the solution ensure you Docker Application is running.

   ```bash
   Containers will be create on application launch and or create/ recreated on application start so no need to run any docker commands
   ```

   This command will set up the following services:
   - **API:** A containerized API that will receive requests from `nbomber`.
   - **Database:** A containerized database.
   - **RabbitMQ:** A containerized RabbitMQ service.
   - **Producer Worker:** A container that sends events from the API to the RabbitMQ queue.
   - **Consumer Worker:** A container that processes messages from the RabbitMQ queue and populates the database.

4. **Running the Load Test:**

   Once everything is set up, on application start the bomber will wait for the api to start before it can flood it with events.

5. **Monitor the System:**

   You can monitor the system's performance and messages using RabbitMQ's web management interface:
   
   - RabbitMQ UI: [http://localhost:15672](http://localhost:15672)
     - Username: `default`
     - Password: `5tr0ngP@55w0rD`

   The producer worker will send messages to the RabbitMQ queue, which will be consumed by the consumer worker and processed.

## Architecture Diagram

Here is an overview of the architecture flow:

```
[nbomber] ---> [API] ---> [Producer Worker] ---> [RabbitMQ] ---> [Consumer Worker] ---> [DB]
```

## Key Components

- **Tester**: A load-testing tool that generates high traffic to the API.
- **API**: A containerized API that receives and processes the load from `nbomber`.
- **Producer Worker**: Responsible for sending events from the API to the RabbitMQ queue.
- **RabbitMQ**: A message broker that decouples the producer and consumer workers.
- **Consumer Worker**: Consumes messages from the RabbitMQ queue and processes them by interacting with the database.
- **Database**: A containerized database that stores the final processed data.

## Troubleshooting

- **Container Not Starting:** Ensure that Docker is running and that no other services are conflicting with the ports used by RabbitMQ, the API, or the database.
- **RabbitMQ Connection Issues:** Verify that the RabbitMQ service is up and running. You can access the RabbitMQ management UI at [http://localhost:15672](http://localhost:15672) for further debugging.

## Acknowledgments

- Thanks to the creators of `nbomber`, RabbitMQ, and the various components that make this architecture possible.
