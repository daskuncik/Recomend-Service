using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace RecomedProject.Classes
{
    class Parcer
    {
        double[,] ArrayOfRelations;
        //size фиксированный?

        public void Func(string path)
        {
            StreamReader streamReader = new StreamReader(path);

            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\relations_in_genres.csv"))
            {
                int size = 10;//genres_items_origin.Count;
                ArrayOfRelations = new double[size, size];

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                int row = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (row != 0)
                    {
                        for (int col = 1; col <= row; col++)
                        {
                            if (fields[col] != "")
                            {
                                ArrayOfRelations[row - 1, col - 1] = Convert.ToDouble(fields[col]);
                                ArrayOfRelations[col - 1, row - 1] = Convert.ToDouble(fields[col]);
                            }
                        }
                    }
                    row++;
                }
            }
        }

        
    }
}
