/*
 * ClashSharpBot Project
 * 
 *  From http://www.codeproject.com/Articles/1966/An-INI-file-handling-class-using-C 
 */

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace ClashSharpBot.Base
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// Create New Instance of IniReader
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;

            // Create INI File If Does Not Exist
            if (!File.Exists(INIPath))
            {
                // Create Unicode Text File
                File.CreateText(INIPath);
            }
        }

        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void Write(string Section, string Key, object Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string Read(string Section, string Key, object DefaultValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefaultValue.ToString(), temp,
                                            255, this.path);
            return temp.ToString();
        }

        /// <summary>
        /// Read or Write 
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string ReadWrite(string Section, string Key, object DefaultValue)
        {
            // Im Use This Method\Function for Generation Default Ini
            // It's Good for Alone Developers Like Me
           
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefaultValue.ToString(), temp,
                                            255, this.path);

            string result = temp.ToString();

            if(DefaultValue.ToString() == result)
            {
                Write(Section, Key, DefaultValue);
            }

            return temp.ToString();
        }


    }
}
