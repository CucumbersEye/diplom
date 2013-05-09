using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class FcaObject
    {
        private string name;
        private int id;
        private int[] attributes;
        List<FcaAttribute> attribs;

        public FcaObject() 
        {
            attribs = new List<FcaAttribute>();
        }

        public void setName(string name) { 
            this.name = name;
        }

        public string getName(){
            return this.name;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getId(){
            return this.id;
        }

        public void setAttributes(int[] attr) {
            this.attributes = attr;
        }

        public int[] getAttributes(){
            return this.attributes;
        }

        public void addAttr(FcaAttribute attr) {
            bool contains = false;
            foreach(FcaAttribute o in attribs)
            {
                if (o.getName().Equals(attr.getName()))
                    contains = true;
            }

            if(!contains)
                attribs.Add(attr);
        }

        //public void deleteAttr(int attrId)
        //{
        //    this.attributes[attrId] = 0;
        //}

        public void forwmAttrVector(int len)
        {
            attributes = new int[len];

            foreach (FcaAttribute attr in attribs)
            {
                attributes[attr.getId()] = 1;
            }
        }
    }
}
