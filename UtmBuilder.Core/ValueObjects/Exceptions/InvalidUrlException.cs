using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid URL";
    private const string UrlRegexPattern =
        @"^(https|http):(\/\/www\.|\/\/www\.|\/\/|\/\/)([a-zA-Z0-9]+)(\.[a-zA-Z0-9]+)([\/a-zA-Z0-9]+)?(\?([a-zA-Z0-9]+=[a-zA-Z0-9]+)(&[a-zA-Z0-9]+=[a-zA-Z0-9]+)*)?$";
    public InvalidUrlException(string message = DefaultErrorMessage)
        : base(message)
    {
    }

    public static void ThrowIfInvalidUrl(
        string address,
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);
        
        if (!Regex.IsMatch(address, UrlRegexPattern))
            throw new InvalidUrlException();
    }
}