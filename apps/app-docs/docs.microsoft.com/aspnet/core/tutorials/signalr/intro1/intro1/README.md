### Run

$ dotnet watch run

### Add the SignalR client library
The SignalR server library is included in the Microsoft.AspNetCore.App metapackage. 
The JavaScript client library isn't automatically included in the project. 
For this tutorial, you use Library Manager (LibMan) to get the client library 
from unpkg. unpkg is a content delivery network (CDN)) that can deliver anything found in npm, 
the Node.js package manager.

### Create a SignalR hub (the central part, usually cylindrical)
A hub is a class that serves as a high-level pipeline that handles 
client-server communication.

