using System;
using System.Collections.Generic;
using System.IO;

namespace Proggs1._1
{
    public class BaseFileRepository
    {
        protected string fileName;
        public BaseFileRepository(string fileName)
        {
            this.fileName = fileName;
        }
        protected List<string> ReadAllLinesFromFile()
        {
            List<string> lines = new List<string>();
            if (!File.Exists(fileName))
            {
                return lines;
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }
        protected void WriteAllLinesToFile(List<string> lines)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
