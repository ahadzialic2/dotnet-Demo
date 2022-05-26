using System.Text.Json.Serialization;

namespace dotnet_Demo.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] //ovo smo dodali da bi se prikazali enum stringovi umjesto integera
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric
    }
}