using System;
using System.Collections.Generic;
using System.Xml;

public class LogParser
{
    public static IEnumerable<long> GetTimestampsByDescription(string xml, string description)
    {
        var timestamps = new List<long>();
        var doc = new XmlDocument();
        doc.LoadXml(xml);

        foreach (XmlNode node in doc.SelectNodes("//event[description='" + description + "']"))
        {
            timestamps.Add(long.Parse(node.Attributes["timestamp"].Value));
        }

        return timestamps;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"
            + "<log>\n"
            + "    <event timestamp=\"1614285589\">\n"
            + "        <description>Intrusion detected</description>\n"
            + "    </event>\n"
            + "    <event timestamp=\"1614286432\">\n"
            + "        <description>Intrusion ended</description>\n"
            + "    </event>\n"
            + "</log>";

        foreach (long timestamp in LogParser.GetTimestampsByDescription(xml, "Intrusion ended"))
            Console.WriteLine(timestamp);
    }
}
