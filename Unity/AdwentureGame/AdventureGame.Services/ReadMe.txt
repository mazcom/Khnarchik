https://www.codeguru.com/csharp/csharp/cs_misc/designtechniques/understanding-onion-architecture.html
Services Layer
The Service layer holds interfaces with common operations, such as Add, Save, Edit, and Delete. 
Also, this layer is used to communicate between the UI layer and repository layer. 
The Service layer also could hold business logic for an entity. 
In this layer, service interfaces are kept separate from its implementation, 
keeping loose coupling and separation of concerns in mind.