using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils
{
    public class StringUtils
    {

        /// <summary>
        /// Works for both paths with \ and /
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String array of size 2 where 0 is the path and 1 is the filename</returns>
        public static string[] splitPath(string path)
        {
            string[] splitpath = new string[2];
            char splitchar = '\\';
            if (path.Contains('/'))
            {
                splitchar = '/';
            }
            string[] temp = path.Split(splitchar);
            splitpath[1] = temp[temp.Length - 1];
            splitpath[0] = "";
            for (int i = 0; i < temp.Length - 1; i++)
            {
                splitpath[0] += temp[i] + splitchar;
            }
            return splitpath;
        }


        /// <summary>
        /// The file can have many dots in the filename but it must have an extension or this is redundunt
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>The extension of the file with . (.sql)</returns>
        public static string getExtension(string filename)
        {
            string[] temp = filename.Split('.');
            return "." + temp[temp.Length - 1];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <returns> 
        /// returns the last / name
        /// eg.in /home/staff/folderOrFile
        /// out  folder
        /// </returns>
        public static string getLastPathName(string path)
        {
            char splitchar = '\\';
            if (path.Contains('/'))
            {
                splitchar = '/';
            }
            return path.Substring(path.LastIndexOf(splitchar));
        }


        /// <summary>
        /// example input path = /home/stuff/folderOrFile
        /// return = /home/stuff
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string getPathExceptLast(string path)
        {
            char splitchar = '\\';
            if (path.Contains('/'))
            {
                splitchar = '/';
            }

            if (path.Split(splitchar).Length > 2)
            {
                return path.Substring(0, path.LastIndexOf(splitchar));
            }

            return "/";
        }

    }
}
