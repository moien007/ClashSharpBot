/*
 * Clash Sharp Bot Base
 * 
 * Author : Moien007
 * Desc : We use this to redirect console output to control like textbox
 */

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ClashSharpBot.Base
{
    public class ControlWriter : TextWriter
    {
        public Control Control { get; set; }

        public ControlWriter(Control control)
        {
            Control = control;
        }

        public override void Write(char value)
        {
            Control.Text += value;
        }

        public override void Write(string value)
        {
            Control.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}