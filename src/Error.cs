namespace ErrorOr;

/// <summary>
/// Represents an error.
/// </summary>
public readonly record struct Error
{
    /// <summary>
    /// Gets the unique error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the error type.
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Gets the error attributes.
    /// </summary>
    public Dictionary<string, string>? Attributes { get; }

    /// <summary>
    /// Gets the numeric value of the type.
    /// </summary>
    public int NumericType { get; }

    private Error(string code, string description, ErrorType type, Dictionary<string, string>? attributes)
    {
        Code = code;
        Description = description;
        Type = type;
        Attributes = attributes;
        NumericType = (int)type;
    }

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Failure"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.",
        Dictionary<string, string>? attributes = null) =>
        new (code, description, ErrorType.Failure, attributes);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Unexpected"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected error has occurred.",
        Dictionary<string, string>? attributes = null) =>
        new(code, description, ErrorType.Unexpected, attributes);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Validation"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error Validation(
        string code = "General.Validation",
        string description = "A validation error has occurred.",
        Dictionary<string, string>? attributes = null) =>
        new(code, description, ErrorType.Validation, attributes);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Conflict"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error Conflict(
        string code = "General.Conflict",
        string description = "A conflict error has occurred.",
        Dictionary<string, string>? attributes = null) =>
        new(code, description, ErrorType.Conflict, attributes);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.NotFound"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.",
        Dictionary<string, string>? attributes = null) =>
        new(code, description, ErrorType.NotFound, attributes);

    /// <summary>
    /// Creates an <see cref="Error"/> with the given numeric <paramref name="type"/>,
    /// <paramref name="code"/>, and <paramref name="description"/>.
    /// </summary>
    /// <param name="type">An integer value which represents the type of error that occurred.</param>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="attributes">Optional attributes.</param>
    public static Error Custom(
        int type,
        string code,
        string description,
        Dictionary<string, string>? attributes = null) =>
        new(code, description, (ErrorType)type, attributes);
}
