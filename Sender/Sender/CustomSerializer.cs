using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sender
{
    public class CustomSerializer : RawRabbit.Serialization.JsonMessageSerializer
    {
        public CustomSerializer() : base(new Newtonsoft.Json.JsonSerializer
        {
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Formatting = Formatting.None,
            CheckAdditionalContent = true,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ObjectCreationHandling = ObjectCreationHandling.Auto,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            NullValueHandling = NullValueHandling.Ignore
        })
        { }
    }
}
