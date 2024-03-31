using System.IO;
using static Домашнее_задание__7.Class.ObservableFactory;

namespace Домашнее_задание__7.Class
{
    public class Log
    {
        private string _filePath;

        public Log(string filePath)
        {
            _filePath = filePath;
        }

        public void LogUserDataChanges(CollectionChangedEventArgs<User> args)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"Action: {args.Action}, Item: {args.Item}");
            }
        }
    }
}
