# SunTechCodingChallenge

### Application Flow

![image](https://github.com/mkc-lomio/SunTechCodingChallenge/assets/78136159/c8b4254b-203b-4049-9e0e-92605aba5fd5)

STEP 1: Developer uses Postman to trigger the Event Sender Function App via an HTTP request.

STEP 2: Event Sender performs a data operation (e.g., insert or update) in Azure Cosmos DB.

STEP 3: Event Listener Function App is triggered by the change in Cosmos DB.

STEP 4: Event Listener detects the change (insert/update), creates an event, and publishes it to Azure Event Grid using the Event Grid API.

STEP 5: Event Grid processes the incoming event and routes it to the configured Event Grid Topic.

STEP 6: The Event Grid Topic can then forward this event to various downstream systems (e.g., Azure Storage Queue) based on configured subscriptions.

### Technical Exam Story Line

Context > I had to take skill assessment/technical exam before going to interview

<img width="530" height="530" alt="image" src="https://github.com/user-attachments/assets/965be0e2-602e-4787-acd1-90d74c4690bd" />

Requirements 


<img width="540" height="700" alt="image" src="https://github.com/user-attachments/assets/70ff7047-c265-47cb-87d1-287861828c83" />

<img width="528" height="334" alt="image" src="https://github.com/user-attachments/assets/405c9495-2e05-4992-954a-5213755d6c91" />

Result > I passed the technical exam then I had been proceed to the next step which is the technical interview.

<img width="673" height="260" alt="image" src="https://github.com/user-attachments/assets/260eb68c-25be-4a50-9745-7f1fd076db88" />
