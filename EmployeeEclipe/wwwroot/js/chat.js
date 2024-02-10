"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").disabled = true;
function fetchUserMessages() {
    $.ajax({
        url: '/Chat/UserMessage', 
        method: 'GET',
        success: function (data) {
            var html = '';
            $.each(data, function (index, value) {
                if (value.role === 'User') {
                    html += `<div class="user-message">
                    <span class="message-span">${value.userMessage}</span>
                    <label for="">User</label>
                 </div>`;
                } else if (value.role === 'Admin') {
                    html += `<div class="bot-message">
                    <span class="message-span">${value.hrReplay}</span>
                    <label for="">Admin</label>
                 </div>`;
                }
            });
            $("#userMessage").html(html);
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
}

window.addEventListener('DOMContentLoaded', fetchUserMessages);
document.getElementById("sendButton").addEventListener("click", function (event) {
    var userId = document.getElementById("UserId").value;
    var messageInput = document.getElementById("messageInput");
    var message = messageInput.value;
    var HrId = document.getElementById("HRId").value;
    var Role = document.getElementById("Role").value;
    if (!message.trim()) {
        alert("Message cannot be empty.");
        return; 
    }
    connection.invoke("SendMessage", userId, message, HrId, Role).then(function () {
        fetchUserMessages();
        messageInput.value = null;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

fetchUserMessages();


setInterval(fetchUserMessages, 10000);