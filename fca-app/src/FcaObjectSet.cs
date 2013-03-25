using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class FcaObjectSet
    {
        private List<FcaObject> objects;
        private int[] attributes;

        public FcaObjectSet() {
            objects = new List<FcaObject>();
        }

        public int[] intersect(int[] attr) {
            int len = this.attributes.Length;
            int[] vect = new int[len];
            for (int i = 0; i < len; i++) {
                vect[i] = this.attributes[i] * attr[i];
            }
            return vect;
        }

        /// <summary>
        ///  Добавление объекта в множество.
        /// </summary>
        /// <param name="obj">добавляемый объект</param>
        public void addObject(FcaObject obj){
            if (this.objects.Count != 0)
            {
                this.attributes = intersect(obj.getAttributes());
            }
            else {
                this.attributes = obj.getAttributes();
            }
            this.objects.Add(obj);

        }

        public void closure(FcaObject elem, FcaMatrix matrix){
            addObject(elem);
            int i = elem.getId();
            int len = matrix.count();
            while (i < len){
            }
        }

        public int findElem(FcaObject elem)
        {
            int i = 0;
            int len = this.objects.Count();
            while((i < len) && (this.objects[i].getName() != elem.getName())) 
                i++;
            if (i >= len)
                return -1;
            return i;
        }

        public int findElemById(int elemId)
        {
            int i = 0;
            int len = this.objects.Count();
            while ((i < len) && (this.objects[i].getId() != elemId))
                i++;
            if (i >= len)
                return -1;
            return i;
        }

        public void setAttributes(int[] attr)
        {
            this.attributes = attr;
        }

        public int[] getAttributes()
        {
            return this.attributes;
        }

        public void addAttr(int attrId)
        {
            this.attributes[attrId] = 1;
        }

        public void deleteAttr(int attrId)
        {
            this.attributes[attrId] = 0;
        }
    }
}
