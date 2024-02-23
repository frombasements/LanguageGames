using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Keywords
{

    /// <summary>
    /// Class to handle connections to data storage
    /// </summary>
    internal class DataHandler
    {

        /// <summary>
        /// Load translation words from file
        /// </summary>
        public static IEnumerable<Word> LoadJson()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Translations.json");
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Word>>(json);
                }
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Stores points into the file
        /// </summary>
        public static void StorePoints(IEnumerable<Word> words)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(words);
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Translations.json");
                writer = new StreamWriter(path);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
