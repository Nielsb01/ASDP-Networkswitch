const express = require('express');
const app = express();
const server = app.listen(process.env.PORT | 3000);
const io = require('socket.io')(server,{
    cors: {
        origin: "*",
    }
});

io.on('connection', (socket) => {
    console.log("New connection with id:" + socket.id)
    socket.join('count');

    socket.onAny((eventName, msg) => {
        console.log(`Received event '${eventName}' with payload '${msg}'`);

        const roomName = socket.data.roomName;

        if (roomName != null) {
            socket.to(roomName).emit(eventName, msg);
        } else {
            console.log("Could not broadcast message because client is not in a room!");
        }
    })

    socket.on('join-room', (roomName) => {
        console.log(`Client: ${socket.id} will join ${roomName}`)
        socket.join(roomName)
        socket.data.roomName = roomName;
    })

    socket.on("disconnect", (reason) => {
        console.log(`Client disconnected with reason ${reason}`);
    });
});

// io.of("/").adapter.rooms.get('count')?.size
