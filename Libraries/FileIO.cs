using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class FileIO
    {
        #region ===== Public Methods =====

        /// <summary>
        /// Reads all data in a text file as a single string.
        /// </summary>
        /// <param name="path">Path of file to read.</param>
        /// <returns>Text in file. Null if error.</returns>
        public static string ReadFile(string path)
        {
            try
            {
                StreamReader fileReader = new(path);
                return fileReader.ReadLine();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Reads all data in a text file and returns each line as a string.
        /// </summary>
        /// <param name="path">Path of file to read.</param>
        /// <returns>List of text lines in file. Null if error.</returns>
        public static List<string> ReadFileByLines(string path)
        {
            try
            {
                List<string> lines = new();

                foreach (string line in File.ReadAllLines(path))
                {
                    lines.Add(line);
                }

                return lines;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}