using System.Text.Json.Serialization;

namespace Abhishek.Model.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Student,
        Employee,
        
    }
}
