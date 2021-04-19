# Protoype research and report

In this document

## Websocket libraries

A comparison of different c# websocket libraries.
Wim Beukers
15-04-2021

### WebSocketSharp

WebSocketSharp is a library that works on .net Framework 3.5 or later. It has a client and a server implementation. The basic case is very easy to implement but if you want to go deeper it doesn't give you a lot of documentation about the possibilities.

### WebSocketsSimple

WebSocketsSimple is a library useing .NET Standard. It has a client and a server implementation. It is not that hard to use and has extensive documentation.

### SignalR

SignalR is a library developed by microsoft itself. Because of that it will only run on specific windows servers and specifically in a ASP.Net environement.
It is an extensive library that not exlusively uses websockets but when websockets fail it for example wil use long polling.

### SuperSocket

SuperSocket is a broader library which also has a websocketServer. There is some documentation but it only gives you the basic implementation. 

### DFT for libraries use in prototypes

|								|WebSocketSharp	|WebSocketsSimple	|SignalR	|SuperSocket	|Own implementation	|
|---							|:---:			|:---:				|:---:		|:---:			|:---:				|
|Also has client side			|++				|++					|--			|--				|--					|
|Low overhead					|				|-					|--			|-				|++					|
|Easy to use					|++				|+					|+			|-				|--					|
|Can run on any server			|++				|++					|--			|++				|++					|
|Has extensive documentation	|-				|+					|++			|-				|--					|

Based on this Decision Forces Table the choice was made to build a prototype with WebSocketSharp and WebSocketsSimple. 
This choice was made because these libraries can be deployed on every kind of server in a standard console app.
These libraries both also have a client side in c# and seem easy to use.

## Prototypes

For both protypes a standar .net console project was created. 
The goal for a protoype is that you can make a websocket connection to the switch after wich every message sent to the switch gets relayed to every other client connected to the switch.
Initially the possibilities for dividing connections into groups also were explored but after contact with the semi-productowner it became clear that this was outside the scope of the project. 

### WebSocketSimple

In WebsocketSimple you create a WebsocketServer based on a ParamsWSServer object with the desired port and a string to send back when a connection is made. 
When you have a WebsocketServer you can add to the event functions with your own implementations. 
For the prototype every event writes to console that that event has been called.
The relay logic is implemented in the MessageEvent function, here is checked if it is a received message, if that is the case it will send the message to all connections except the connections from wich the message originated.
When exploring the possibilities for dividing connections into groups this library did not show support for adding fields to the object for a connection. 
Because of the expected performance loss when trying to implement this an other way this was not further attempted with this library.

### WebSocketSharp

In WebSocketSharp you create a WebSocketServer based on a adress and port given to the object as string. When you have a WebSocketServer you can add specific behaviors and specific paths to it.
For the relay functionality a class was created implementing WebSocketBehavior, in this class the functions OnOpen, OnMessage, OnClose and OnError are overridden. 
For the prototype every event writes to console that that event has been called. The relay logic is implemented in the OnMessage function, it will send the message to all connections except the connections from wich the message originated.
Using this library a WebSocketBehavior implementing class was also created to explore the possibilities for grouping connections into rooms. This has been implemented in the EchoRoom class. This behavior tracks for every connection the corresponding room and a reference to a list with all rooms.
In this class a couple of commands for room management are implemented. you can create a room, join a room and show all rooms.
A message sent while inside a room will be sent by the networkswitch to all connections in that room. 
A sidenote with working with WebSocketSharp is that the package throws a warning because it needs to be built with a earlier version of the .Net framework. 
This doesn't have to be a problem but it could present a problem when using specific .Net 5.0 functionalities, if the functionality of the switch stays the way it is right now this should be perfectly fine.


## Conclusion

When building a smarter networkswitch using rooms, WebSocketSimple proved to have insufficient adaptability to this project. WebSocketSharp did give the space to build this onto the library.
But because of the fact that these functionalities are outside the scope of the project this difference should not be taken in account when deciding on a solution.
