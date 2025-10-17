using System;

public record Task(string Title, bool IsCompleted, DateTimeOffset? DueDate);