using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebApplication.Helpers
{
    public class MyHelper
    {
        public static string Label(string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }
        
        public static string Note(string content)
        {
            return String.Format("<div><p style='color:#f00'><strong> Note:</strong>{0}</p></div> ", content);
        }

        public static HtmlString NoteHelper( string content)
        {
            return new HtmlString($"<div><p style='color:#f00'><strong> Note:</strong>{content}</p></div>");
        }
    }
}