using System.Xml;

namespace Domain.Primitives;

public class XML
{
    /// <summary>
    /// Метод, возвращающий краткое содержание свойства из XML-документации.
    /// </summary>
    /// <param name="typeFullName">Тип, которому принадлежит свойство.</param>
    /// <param name="propertyName">Название свойства, краткое содержание которого нужно получить.</param>
    /// <returns>Если у требуемого свойства есть краткое содержание, то возвращает это содержание.
    /// В противном случае возвращает null</returns>
    public static string? GetPropertySummary(Type typeFullName, string propertyName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Domain.xml");
        
        XmlNodeList members = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes;
        
        foreach (XmlNode node in members)
        {
            string nodeName = node.Attributes.GetNamedItem("name").Value;
            
            if (nodeName.Contains($"{typeFullName}.{propertyName}"))
            {
                return node.ChildNodes[0].InnerText.Trim();
            }
        }
        return null;
    }
}