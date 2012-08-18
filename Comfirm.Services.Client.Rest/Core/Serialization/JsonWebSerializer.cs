using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Comfirm.Services.Client.Rest.Core.Serialization
{
    public class JsonWebSerializer : IWebSerializer
    {
        public string ContentType { get { return "application/json"; } }

        public TObject Deserialize<TObject>(string source)
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(source));
            return (TObject)new DataContractJsonSerializer(typeof(TObject)).ReadObject(stream);
        }

        public string Serialize<TObject>(TObject source)
        {
            var stream = new MemoryStream();
            new DataContractJsonSerializer(typeof(TObject)).WriteObject(stream, source);
            stream.Position = 0;
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
