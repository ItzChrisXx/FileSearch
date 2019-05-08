﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SearchLib
{
    public class DirectorySearch
    {

        private string path;
        private string filter;
        private List<string> findings;


        public string Path { get => path; set => path = value; }
        public string Filter { get => filter; set => filter = value; }
        public string[] Findings { get => findings.ToArray(); }

        public DirectorySearch(string path, string filter)
        {
            Path = path;
            Filter = filter;
        }

        public int FindFiles()
        {
            if (Directory.Exists(path) && filter != "")
            {
                string[] filePaths = FindFilePaths(this.Path);
                List<string> filterInName = FilterNames(filePaths, this.Filter);
                this.findings = filterInName;
                
                Task<bool>[] tasks = new Task<bool>[filePaths.Length];
                for (int i = 0; i < filePaths.Length; i++)
                {
                    int j = i;
                    Task<bool> task = Task<bool>.Factory.StartNew(() => {
                        return FilterData(filePaths[j]);
                    });
                    tasks[j] = task;
                }
                Task.WaitAll(tasks);
                for (int i = 0; i < tasks.Length; i++)
                {
                    if (tasks[i].Result)
                    {
                        if (!findings.Contains(filePaths[i]))
                        {
                            findings.Add(filePaths[i]);
                        }
                    }
                }
                return 0;
            }
            else if (Directory.Exists(path))
            {
                return 1; //no filter
            }
            else
            {
                return 2; //wrong path
            }
        }

        private bool FilterData(string path)
        {
            /*
             * Searches the actual file for the filterword
             */
            
            StreamReader streamReader = new StreamReader(path);
            bool contains = false;
            char[] buffer = new char[512];
            char[] prev = new char[filter.Length];
            while (streamReader.Peek() > -1)
            {
                streamReader.Read(buffer, 0, 512);
                string b = new string(prev);
                b += new string(buffer);
                if (b.Contains(filter))
                {
                    contains = true;
                    break;
                }
                prev = buffer.Skip(buffer.Length-prev.Length).Take(prev.Length).ToArray();
            }
            streamReader.Close();
            return contains;
            
        }

        private List<string> FilterNames(string[] filePaths, string filter)
        {
            /*
             * Out of a set of paths, returns those with the filter string
             * as a substring within the naming part of the path
             */
            var relevantPaths = new List<string>();
            string currentName = "";
            for (int i = 0; i < filePaths.Length; i++)
            {
                currentName = Suffix(filePaths[i]);
                if (currentName.Contains(filter))
                {
                    relevantPaths.Add(filePaths[i]);
                }
            }

            return relevantPaths;
        }

        private string Suffix(string path)
        {
            /* 
             * Cuts the FilePath by the last backslash and returns the suffix
             */
            string suffix = "";
            for (int i = path.Length-1; i >= 0; i--)
            {
                if (path[i] == '\u005c') // Backslash
                {
                    break;
                }
                else
                {
                    suffix = path[i] + suffix;
                }
            }

            return suffix;
        }

        private string[] FindFilePaths(string path)
        {
            /*
             * returns all full filenames within the folder, such as the subfolders 
             */
            var allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            
            return allFiles;
        }


    }
}
