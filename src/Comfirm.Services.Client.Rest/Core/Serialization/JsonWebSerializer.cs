using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System;

namespace Comfirm.Services.Client.Rest.Core.Serialization
{
    public class JsonWebSerializer : IWebSerializer
    {
        public string ContentType { get { return "application/json"; } }
        public JavaScriptSerializer Serializer { get; private set; }

        public JsonWebSerializer()
        {
            this.Serializer = new JavaScriptSerializer();
        }

        public TObject Deserialize<TObject>(string source)
        {
            return this.Serializer.Deserialize<TObject>(source);
        }

        public string Serialize<TObject>(TObject source)
        {
            return this.Serializer.Serialize(source);
        }
    }
}
