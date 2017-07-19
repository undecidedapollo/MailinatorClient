# MailinatorClient
A small C# client for the Mailinator API. 

# Setup

## Create a Client

To create a client, instantiate the StandardMailinatorClient class.

```csharp
var client = new StandardMailinatorClient("API_KEY");
```
# Inbox

## Get an Inbox's Contents

To get the contents of an inbox, use the GetInbox method. 

```csharp
var mail = await client.GetInbox("INBOX_NAME");
```

## Get a Private Inbox's Ccontents

To get the contents of a private inbox, use the GetInbox method with usePrivate set to True. 

```csharp
var mail = await client.GetInbox("INBOX_NAME", usePrivate: true);
```

# Messages

## Get Message Content

To get the contents of a message, call GetMessage.

```csharp
GetMessageResult message = await client.GetMessage("MESSAGE_ID");
```

Or pass in a message object.

```csharp
GetMessageResult message = await client.GetFullMessage(Message);
```

## Get a Private Messages' Content

To get the contents of a message, call GetMessage.

```csharp
GetMessageResult message = await client.GetMessage("MESSAGE_ID", usePrivate: true);
```

Or pass in a message object returned from a previous client request.

(There is no need to specify private when passing in a Message object from the client.)

```csharp
GetMessageResult message = await client.GetFullMessage(Message);
```
