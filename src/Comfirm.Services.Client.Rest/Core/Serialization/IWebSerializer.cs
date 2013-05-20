namespace Comfirm.Services.Client.Rest.Core.Serialization
{
    /// <summary>
    /// Represents a serializer used in web context
    /// </summary>
    public interface IWebSerializer
    {
        /// <summary>
        /// Content type representing the serialized data
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Deserializes a string value into an object graph
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TObject Deserialize<TObject>(string source);

        /// <summary>
        /// Serializes an object graph
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        string Serialize<TObject>(TObject source);
    }
}
