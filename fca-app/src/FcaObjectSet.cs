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

        /// <summary>
        ///  Замыкание множества
        /// </summary>
        /// <param name="elem">добавляемый элемент</param>
        /// <param name="matrix">универсальное множество</param>
        public void closure(FcaObject elem, FcaMatrix matrix){
            addObject(elem);
            int i = elem.getId()+1;
            int len = matrix.count();
            int[] vect = new int[this.attributes.Length];
            while (i < len){
                vect = intersect(matrix.getElemById(i).getAttributes());
                if (attrEquals(vect)) {
                    addObject(matrix.getElemById(i));
                }
                i++;
            }
        }

        /// <summary>
        ///  Разность множеств.
        /// </summary>
        /// <param name="set">вычитаемое множество</param>
        /// <returns>результат вычитания</returns>
        public FcaObjectSet difference(FcaObjectSet set) {
            FcaObjectSet difSet = new FcaObjectSet();
            List<FcaObject> objs = set.getObjects();
            foreach (FcaObject elem in this.objects) {
                if (set.findElemById(elem.getId()) == -1)
                    difSet.addObject(elem);
            }
            return difSet;
        }

        /// <summary>
        ///  Клонирует множество.
        /// </summary>
        /// <returns>Клон исходного множества.</returns>
        public FcaObjectSet clone() {
            FcaObjectSet newSet = new FcaObjectSet();
            foreach(FcaObject elem in this.objects)
                    newSet.addObject(elem);
            return newSet;
        }

        public FcaObject minObject() {
            return this.objects[0];
        }

        public FcaObject maxObject() {
            int len = this.objects.Count;
            return this.objects[len - 1] ;
        }

        private bool attrEquals(int[] vect)
        {
            int i = 0;
            int len = this.attributes.Length;
            while ((i < len) && (vect[i] == this.attributes[i])) i++;
            if (i >= len)
                return true;
            else
                return false;
        }

        public List<FcaObject> getObjects()
        {
            return this.objects;
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
