using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithread
{
    internal class Searcher
    {
        public string[,] SearchString(string folderPath, string searchString)
        {
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            List<string[]> resultsList = new List<string[]>();

            foreach (var file in files)
            {
                ThreadRunner.Run(() =>
                {
                    var lines = File.ReadAllLines(file);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(searchString))
                        {
                            resultsList.Add(new string[] { file, (i + 1).ToString(), lines[i] });
                        }
                    }
                });
            }

            ThreadRunner.JoinAll();

            string[,] resultsArray = new string[resultsList.Count, 3];

            for (int i = 0; i < resultsList.Count; i++)
            {
                resultsArray[i, 0] = resultsList[i][0];
                resultsArray[i, 1] = resultsList[i][1];
                resultsArray[i, 2] = resultsList[i][2];
            }

            return resultsArray;
        }
    }
}
