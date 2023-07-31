"use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

    connection.on("ReceiveNotification", function (message) {
        // do whatever you want to do with `message`

        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        li.textContent = `${user} says ${message}`;
    });

connection.start().catch(function (err) {
    return console.error(err.toString());
});
