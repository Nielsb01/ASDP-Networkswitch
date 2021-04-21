const express = require('express');
const app = express();
const port = process.env.PORT | 8080;

app.get('/', (req, res) => {
    res.send('Hello World');
});

const server = app.listen(port);
console.log(`Running on http://0.0.0.0:${port}`);
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
        console.log(`Client '${socket.id}' disconnected with reason ${reason}.`);
    });
});

