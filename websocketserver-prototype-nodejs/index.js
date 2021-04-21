/*
    AIM SD ASD 2020/2021 S2 project

    Project name: ASD-Project.

    This file is created by team: 5.

    Goal of this file: Node.js websocket server prototype.

*/

const express = require('express');
const app = express();
const server = app.listen(process.env.PORT | 3000);
const io = require('socket.io')(server,{
    cors: {
        origin: "*",
    }
});

io.on('connection', (socket) => {
    console.log("New client with id: " + socket.id)

    socket.onAny((eventName, msg) => {
        socket.broadcast.emit(eventName, msg);
    });

    socket.on("disconnect", (reason) => {
        console.log(`Client '${socket.id}' disconnected with reason ${reason}`);
    });
});
