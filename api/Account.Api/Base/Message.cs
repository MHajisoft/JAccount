namespace Account.Api.Base;

public class Message(MessageType messageType, string title)
{
    public MessageType MessageType { get; } = messageType;

    public string Title { get; } = title;
}