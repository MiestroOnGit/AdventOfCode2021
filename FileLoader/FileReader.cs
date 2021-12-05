using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileLoader
{
    public class FileReader
    {
        public static IEnumerable<T> ReadFileToCollection<T>(string filePath) where T : class
        {
            var values = from line in File.ReadLines(filePath) select line as T;
            return values;
        } 
        
        public static IEnumerable<int> ReadFileToIntCollection(string filePath)
        {
            var values = from line in File.ReadLines(filePath) select int.Parse(line);
            return values;
        }
    }
}