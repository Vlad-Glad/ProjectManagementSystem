using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TaskEvent
{
    [BsonElement("type")]
    public string Type { get; set; } = null!;

    [BsonElement("userId")]
    public int UserId { get; set; }

    [BsonElement("text")]
    public string? Text { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }
}

public class TaskActivity
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("taskId")]
    public int TaskId { get; set; }

    [BsonElement("events")]
    public List<TaskEvent> Events { get; set; } = new();
}
