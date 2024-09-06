const express = require('express'); 
const os = require("os"); 
const app = express(); 

 

app.get("/", function(request, response) { 
    response.send(` 
        <html><body> 
        <h1>Hey there!</h1> 
        <h3>My name is: ${os.hostname()}</h3> 
        <h3>Time is: ${new Date().toISOString()}</h3> 
        </body></html> 
    `); 
}); 

 

app.listen(8080, function() { 
    console.log('Started listening on port 8080'); 
}); 