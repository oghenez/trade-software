using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXMLDemo
{
    public enum ContentTypes { TABLE, IMAGE, TEXT}
    public class MetaObject
    {
        ContentTypes contentType;

        public ContentTypes ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
