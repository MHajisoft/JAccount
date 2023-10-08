namespace Account.Api.Base;

public class Message
{
    public Message(MessageType messageType, string title)
    {
        MessageType = messageType;
        Title = title;
    }

    public MessageType MessageType { get; }

    public string Title { get; }
}