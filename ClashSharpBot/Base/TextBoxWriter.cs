/*
 * Clash Sharp Bot Base
 * 
 * Source From : http://stackoverflow.com/questions/14802876/what-is-a-good-way-to-direct-console-output-to-text-box-in-windows-form
 * Desc : TextBoWriter enable to redirect console output to text box 
 */

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ClashSharpBot.Base
{
    public class TextBoxWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString());
        }

        public override Encoding Encoding
        {
            get { return null; /*System.Text.Encoding.UTF8;*/ }   //  Null for Write Any Char
        }
    }
}
