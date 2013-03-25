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

        public FcaObject() { 
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

        public void addAttr(int attrId) {
            this.attributes[attrId] = 1;
        }

        public void deleteAttr(int attrId)
        {
            this.attributes[attrId] = 0;
        }
    }
}
