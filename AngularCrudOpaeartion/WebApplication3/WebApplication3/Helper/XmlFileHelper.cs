using System.Xml.Serialization;
using WebApplication3.Model;
namespace WebApplication3.Helper
{
    public class XmlFileHelper
    {
        private static readonly string filePath = @"D:\Completed File\NamedInsuredEngageNamedInsured.txt";

        public static List<Employee> ReadEmployees()
        {
            if (!File.Exists(filePath))
                return new List<Employee>();

            using var stream = File.OpenRead(filePath);
            var serializer = new XmlSerializer(typeof(List<Employee>));
            return (List<Employee>)serializer.Deserialize(stream)!;
        }

        public static void WriteEmployees(List<Employee>? employees)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            using var stream = File.OpenWrite(filePath);
            var serializer = new XmlSerializer(typeof(List<Employee>));
            serializer.Serialize(stream, employees);
        }
    }
}
