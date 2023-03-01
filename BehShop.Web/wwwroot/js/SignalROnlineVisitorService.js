var connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();
connection.start();