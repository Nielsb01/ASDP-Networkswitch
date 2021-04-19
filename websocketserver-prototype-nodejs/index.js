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
        // console.log(`Broadcasting received event '${eventName}' with payload '${msg}' from '${socket.id}'.`);
        socket.broadcast.emit(eventName, msg);
    });

    socket.on("disconnect", (reason) => {
        // console.log(`Client '${socket.id}' disconnected with reason ${reason}`);
    });
});
