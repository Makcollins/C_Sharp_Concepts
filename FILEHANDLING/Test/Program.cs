using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AppendToCSV();
            ReadCSVFile();
        }

        static async Task AppendToCSV()
        {
            var newList = ListManager.GetContacts();
            foreach (var item in newList)
            {
                await File.AppendAllTextAsync("bin/Debug/contacts.csv",$"{item.Name},{item.Phone}\n");
            }
        }
        static void ReadCSVFile()
        {
            var lines = File.ReadAllLines("bin/Debug/contacts.csv");
            var contactList = new List<Contact>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 2)
                {
                    var contact = new Contact() { Name = values[0], Phone = values[1] };
                    contactList.Add(contact);
                }
            }
            contactList.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Phone}"));
        }
    }
}