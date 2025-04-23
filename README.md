# OTAssessment

This project simulates a load testing and data processing pipeline using various tools to test and manage database performance and message queuing. The architecture involves a series of workers interacting with each other to simulate a flood of data and its processing. Below is an explanation of the architecture and the purpose of each component.

## Architecture Overview

The system is designed to simulate a scenario where a penetration tester (or load tester) uses `nbomber` to flood the API. The flow works as follows:

1. **Tester (nbomber):**  
   The `nbomber` tool is used by the tester to generate a high volume of requests to the API, simulating a flood of interactions.

2. **API:**  
   The API receives the load from `nbomber` and processes the requests, sending events to the next component in the pipeline.

3. **Producer Worker:**  
   The producer worker listens for changes or events from the API and sends these events to a RabbitMQ queue.

4. **RabbitMQ:**  
   RabbitMQ is used as the message broker to decouple the producer and consumer workers. It ensures that messages are queued and processed asynchronously.

5. **Consumer Worker:**  
   The consumer worker listens to the RabbitMQ queue, processes the messages, and populates the database with the results or processed data.

6. **Database (DB):**  
   The database receives the processed data from the consumer worker and stores it.

## Project Setup

### Prerequisites

Make sure you have the following tools installed:

- **Docker:** For running containers and managing services.
- **RabbitMQ:** Used as the message broker in this system.
- **nbomber:** Tool for generating load and testing the system under high traffic.

### Running the Application

Follow these steps to set up and run the system:

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/thee1acer/OTAssessment.git
   cd OTAssessment
   ```

2. **Build and Run the Docker Containers:**

   The project uses Docker for containerization. To build and run the necessary containers, use the following commands:

   ```bash
   docker-compose up --build
   ```

   This command will set up the following services:
   - **API:** A containerized API that will receive requests from `nbomber`.
   - **Database:** A containerized database.
   - **RabbitMQ:** A containerized RabbitMQ service.
   - **Producer Worker:** A container that sends events from the API to the RabbitMQ queue.
   - **Consumer Worker:** A container that processes messages from the RabbitMQ queue and populates the database.

3. **Running the Load Test:**

   Once everything is set up, you can start the load test with `nbomber`. This will simulate a flood of requests to the API.

   ```bash
   nbomber run
   ```

4. **Monitor the System:**

   You can monitor the system's performance and messages using RabbitMQ's web management interface:
   
   - RabbitMQ UI: [http://localhost:15672](http://localhost:15672)
     - Username: `guest`
     - Password: `guest`

   The producer worker will send messages to the RabbitMQ queue, which will be consumed by the consumer worker and processed.

## Architecture Diagram

Here is an overview of the architecture flow:

```
[nbomber] ---> [API] ---> [Producer Worker] ---> [RabbitMQ] ---> [Consumer Worker] ---> [DB]
```

## Key Components

- **nbomber**: A load-testing tool that generates high traffic to the API.
- **API**: A containerized API that receives and processes the load from `nbomber`.
- **Producer Worker**: Responsible for sending events from the API to the RabbitMQ queue.
- **RabbitMQ**: A message broker that decouples the producer and consumer workers.
- **Consumer Worker**: Consumes messages from the RabbitMQ queue and processes them by interacting with the database.
- **Database**: A containerized database that stores the final processed data.

## Troubleshooting

- **Container Not Starting:** Ensure that Docker is running and that no other services are conflicting with the ports used by RabbitMQ, the API, or the database.
- **RabbitMQ Connection Issues:** Verify that the RabbitMQ service is up and running. You can access the RabbitMQ management UI at [http://localhost:15672](http://localhost:15672) for further debugging.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thanks to the creators of `nbomber`, RabbitMQ, and the various components that make this architecture possible.
