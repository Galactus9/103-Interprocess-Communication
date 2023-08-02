# C# Interprocess Communication - Named Pipes

This project demonstrates Interprocess Communication (IPC) in C# using Named Pipes. It consists of two console applications, a server, and a client, which communicate with each other through a named pipe.

## Overview

The project showcases how to establish a bidirectional communication channel between a server and a client using named pipes. Named pipes are a powerful way to enable communication between different processes on the same machine. The server creates a named pipe, and the client connects to it to exchange data.

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/your-username/named-pipe-demo.git
cd named-pipe-demo
```

2. Build the solution to ensure all the dependencies are resolved.

3. Run the server console application:

```bash
cd NamedPipeServerService
dotnet run
```

## How it works

1. The server application creates a named pipe with the name `"testPipe"`. It waits for the client to connect.

2. The client application attempts to connect to the named pipe created by the server.

3. Once the connection is established, the client sends a message to the server in the form of a byte array.

4. The server receives the message, processes it, and optionally sends a response back to the client.

5. The client reads the response from the server and can take further action based on the response.

## Customization

You can customize the project to add more complex functionality or use the named pipe communication as a basis for other IPC mechanisms.

## License

This project is licensed under the [MIT License](LICENSE).
