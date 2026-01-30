using System.IO;
using System.Xml.Serialization;

namespace ProjectPP.Utils;

public static class XmlUtils
{
    public static string SerializeToXml<T>(T obj)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, obj);
        return stringWriter.ToString();
    }
}
