using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;



namespace file_sorter
{
    class FileSort
    {
        static string sourcePath = @"D:\Books\Romane\";
        string destPath = sourcePath + "log.txt";

        //private FileStream Fs {get} = File.Create(@"D:\Code\SortFiles2\Test\log.txt",);

        public void init()
        {
            
            Trace.WriteLine("File Sorting Program Version 0.1");
            var sb = new StringBuilder();

            sb.AppendLine(" File Sorting Program Version 0.1")
               .AppendLine("HelloWorld");

            



            
            //File.AppendAllText(destPath, "Hello World");            
            
            if (System.IO.Directory.Exists(sourcePath))
            {
                
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(s);
                    Trace.WriteLine(fileName);

                    if (fileName.IndexOf("-") > 0)
                    {

                        sb.Append(s + " ## ");
                        string autor = fileName.Split("-")[0];


                        if (autor.IndexOf(",") > 0)
                        {
                            sb.Append(autor);
                            string targetPath = (sourcePath + autor).Trim();
                            System.IO.Directory.CreateDirectory(targetPath);
                            sb.AppendLine(" ## " + targetPath);

                            try
                            {
                                //System.IO.File.Move(s, targetPath);
                                Trace.WriteLine(s);
                                Trace.WriteLine(targetPath + @"\" + fileName);
                                //System.IO.File.Move(sourcePath + "log.txt", sourcePath + @"log\log.txt");
                                System.IO.File.Move(s, targetPath + @"\" + fileName);




                            }
                            catch (Exception e)
                            {
                                Trace.WriteLine(e.ToString());
                            }

                        }
                        else
                        {
                            sb.AppendLine("INVALID");
                        }
                    }




                    

                    //destFile = System.IO.Path.Combine(targetPath, fileName);
                    //System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Trace.WriteLine("Source path does not exist!");
            }

            string text = sb.ToString();
            File.WriteAllText(destPath, text);

            //Fs.Close();
        }
        
    }
}
