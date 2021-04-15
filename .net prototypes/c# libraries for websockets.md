# Websocket libraries

A comparison of different c# websocket libraries.
Wim Beukers
15-04-2021

## WebSocketSharp

WebSocketSharp is a library that works on .net Framework 3.5 or later. It has a client and a server implementation. The basic case is very easy to implement but if you want to go deeper it doesn't give you a lot of documentation about the possibilities.

## WebSocketsSimple

WebSocketSimple is a library useing .NET Standard. It has a client and a server implementation. It is not that hard to use and has extensive documentation.

## SignalR

SignalR is a library developed by microsoft itself. Because of that it will only run on specific windows servers and specifically in a ASP.Net environement.
It is an extensive library that not exlusively uses websockets but when websockets fail it for example wil use long polling.

## SuperSocket

SuperSocket is a broader library which also has a websocketServer. There is some documentation but it only gives you the basic implementation. 

|								|WebSocketSharp	|WebSocketsSimple	|SignalR	|SuperSocket	|Own implementation	|
|---							|:---:			|:---:				|:---:		|:---:			|:---:				|
|Also has client side			|++				|++					|--			|--				|--					|
|Low overhead					|				|-					|--			|-				|++					|
|Easy to use					|++				|+					|+			|-				|--					|
|Can run on any server			|++				|++					|--			|++				|++					|
|Has extensive documentation	|-				|+					|++			|-				|--					|