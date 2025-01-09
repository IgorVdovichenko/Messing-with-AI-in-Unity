using System.IO;

namespace ScriptedDT.Parsing
{
    public class FileTextReader: IJsonReader
    {
        private readonly string _filePath;

        public FileTextReader(string filePath)
        {
            _filePath = filePath;
        }
        
        public string Read()
        {
            return File.ReadAllText(_filePath);
        }
    }
}