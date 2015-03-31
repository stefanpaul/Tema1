using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Entities
{
    public class Add
    {
        string id;
        string name;
        string description;
        Image image;
        public Add(string id, string name, string description, Image image )
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.image = image;
        }

        public string getID()
        {
            return id;
        }
        
        public string getDescription()
        {
            return description;
        }

        public string getName()
        {
            return name;
        }

        public Image getImage()
        {
            return image;
        }
    }
}
