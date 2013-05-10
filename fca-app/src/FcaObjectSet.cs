using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class FcaObjectSet
    {
        private  List<FcaObject> objects;
        private  int[] attributes;
        public   List<FcaObjectSet> ASupr;
        public   List<FcaObjectSet> AInf;
        private  List<FcaObjectSet> Visited;
        public  List<FcaObjectSet> AllSets; // все когда-либо полученные понятия
        public  FcaObjectSet head;
        private  FcaObjectSet tail;
        public   String Name;
        public bool visited;

        public FcaObjectSet() 
        {
            objects = new List<FcaObject>();
            AllSets = new List<FcaObjectSet>();
            AInf = new List<FcaObjectSet>();
            ASupr = new List<FcaObjectSet>();
            Visited  =  new List<FcaObjectSet>();
        }

        /// <summary>
        ///  Пересечение множеств
        /// </summary>
        /// <param name="attr"> атрибуты множества </param>
        /// <returns></returns>
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
            if (!this.objects.Contains(obj))
                        this.objects.Add(obj);
            this.objects.Sort(compareObjects);
        }

        /// <summary>
        ///  Замыкание множества
        /// </summary>
        /// <param name="elem">добавляемый элемент</param>
        /// <param name="matrix">универсальное множество</param>
        public void closure(FcaObject elem, FcaMatrix matrix){
            addObject(elem);
            int i = 0;
            int len = matrix.count();
            int[] vect = new int[this.attributes.Length];
            while (i < len){
                vect = intersect(matrix.getElemById(i).getAttributes());
                if (attrEquals(vect)&&(i!=elem.getId())) {
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
        public FcaObjectSet clone() 
        {
            FcaObjectSet newSet = new FcaObjectSet();
            foreach(FcaObject elem in this.objects)
                    newSet.addObject(elem);
            return newSet;
        }

        /// <summary>
        ///     Поиск минимального объекта
        /// </summary>
        /// <returns>Минимальный объект</returns>
        public FcaObject minObject() 
        {
            return this.objects[0];
        }


        /// <summary>
        /// Поиск максимального объекта
        /// </summary>
        /// <returns>Максимальный объект</returns>
        public FcaObject maxObject() 
        {
            int len = this.objects.Count;
            return this.objects[len - 1] ;
        }

        /// <summary>
        ///     Сравнение векторов-атрибутов
        /// </summary>
        /// <param name="vect">Сравниваемый атрибут</param>
        /// <returns>true - равно; false - неравно</returns>
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

        /// <summary>
        ///     Поиск элемента по имени
        /// </summary>
        /// <param name="elem">Имя элемента</param>
        /// <returns>его порядковый номер</returns>
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

        /// <summary>
        /// Поиск элемента по id
        /// </summary>
        /// <param name="elemId">id элемента</param>
        /// <returns>Порядковый номер элемента</returns>
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

        public string toString()
        {
            string s = "";
            foreach(FcaObject e in this.getObjects())
            {
                s += e.getName() + " ";
            }
            return s;
        }

        private int compareObjects(FcaObject x, FcaObject y)
        {
            if (x.getId() > y.getId())
            {
                return 1;
            }
            else if (x.getId() < y.getId())
            {
                return -1;
            }
            else
                return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns>Количество объектов в множестве</returns>
        public int count()
        {
            return this.objects.Count;
        }

        /// <summary>
        ///     Список соседей в решетке
        /// </summary>
        /// <param name="A"> узел решетки</param>
        /// <param name="G"> универсальное множество, в котором содержается все понятия</param>
        /// <returns></returns>
        private List<FcaObjectSet> minimal(FcaObjectSet A, FcaObjectSet G, FcaMatrix matrix)
        {
            List<FcaObjectSet> resultSet = new List<FcaObjectSet>();
            FcaObjectSet subtr = G.difference(A);   // находим разниу между множествами

            List<FcaObject> iterableSet = subtr.getObjects();
            foreach (FcaObject obj in iterableSet)
            {
                FcaObjectSet B = new FcaObjectSet();
                B = A.clone();
                B.closure(obj, matrix);
                resultSet.Add(B);
            }

            // найдем минимальные из порожденных множеств
            List<FcaObjectSet> minSet = new List<FcaObjectSet>();
            if (resultSet.Count != 0)
            {
                int minCount = resultSet[0].count();

                foreach (FcaObjectSet obj in resultSet)
                {
                    if (obj.count() < minCount)
                    {
                        minSet.Clear();
                        minCount = obj.count();
                        minSet.Add(obj);
                    }
                    else if (obj.count() == minCount)
                    {
                        minSet.Add(obj);
                    }
                }

                //foreach (FcaObjectSet obj in minSet)
                //{
                //    if ((AllSets == null) || (!AllSets.Contains(obj)))
                //        AllSets.Add(obj);
                //}
            }
            return minSet;
        }

        private void addVisited(FcaObjectSet obj)
        { 
            if (VisitedContains(obj) == -1)
                Visited.Add(obj);
        }

        private void addAllSets(FcaObjectSet obj)
        {
            if (!AllSets.Contains(obj))
                AllSets.Add(obj);
        }

        private void addAInf(FcaObjectSet obj)
        {
            int i = -1;
            int l = AInf.Count;
            for (int j = 0; j < l; j++)
            {
                if (AInf[j].Equals(obj))
                {
                    i = j;
                    break;
                }
            }

            if (i == -1)
                AInf.Add(obj);
        }

        private void addASupr(FcaObjectSet obj)
        {
            int i = -1;
            int l = ASupr.Count;
            for (int j = 0; j < l; j++)
            {
                if (ASupr[j].Equals(obj))
                {
                    i = j;
                    break;
                }
            }

            if (i == -1)
                ASupr.Add(obj);
        }

        private int AllSetsContains(FcaObjectSet obj)
        {
            int i;
            int l = AllSets.Count;
            for (i = 0; i < l; i++)
            {
                if (AllSets[i].Equals(obj))
                    return i;
            }
            return -1;
        }

        private int VisitedContains(FcaObjectSet obj)
        {
            int i;
            int l = Visited.Count;
            for (i = 0; i < l; i++)
            {
                if (Visited[i].Equals(obj))
                    return i;
            }
            return -1;
        }

        public FcaObjectSet first(List<FcaObjectSet> fSet, List<FcaObjectSet> sSet)
        {
            List<FcaObjectSet> resultSet = new List<FcaObjectSet>();

            foreach (FcaObjectSet set in fSet)
            {
                if (!sSet.Contains(set))
                {
                    resultSet.Add(set);
                }
            }

            if (resultSet.Count == 0)
                return null;
            else
                return resultSet[0];
        }

        public void buildLattice(FcaTree tree, FcaMatrix matrix)
        {
            FcaObjectSet A = new FcaObjectSet();
            FcaObjectSet G = matrix.UltimateSet();
            List<FcaObjectSet> sup = minimal(A, G, matrix); // множесво всех возможных соседей в решетке
            head = A;
            AllSets = tree.returnListOfSets(tree);
            int i = AllSetsContains(G);
            if (i == -1)
            {
                addAllSets(G);
                i = AllSetsContains(G);
            }
            tail = AllSets[i];

            foreach (FcaObjectSet obj in sup)
            {
                i = AllSetsContains(obj);
                FcaObjectSet existObject = AllSets[i];
                A.addASupr(existObject);
                existObject.addAInf(A);
                addVisited(existObject);
            }

            // найти связь между  1 и 123.
            while (Visited.Count != 0)
            {
                List<FcaObjectSet> list = Visited.ToList<FcaObjectSet>();
                foreach (FcaObjectSet s in list)
                {
                    sup = minimal(s, G, matrix); // множесво всех возможных соседей в решетке
                    Visited.Remove(s);

                    foreach (FcaObjectSet obj in sup)
                    {
                        i = AllSetsContains(obj);
                        if (i == -1)
                        {
                            addAllSets(obj);
                            i = AllSetsContains(obj);
                        }
                        FcaObjectSet existObject = AllSets[i];
                        s.addASupr(existObject);
                        existObject.addAInf(s);
                        addVisited(existObject);
                    }
                }
            }

            foreach (FcaObjectSet set in AllSets)
            {
                FcaObjectSet check = new FcaObjectSet();
                foreach (FcaObjectSet l in set.AInf)
                {
                    foreach (FcaObject o in l.getObjects())
                    {
                        check.addObject(o);
                    }
                }

                if (!set.Equals(check))
                {
                    i = AllSetsContains(set);
                    set.addAInf(tree.findInList(set).getParent().getMainSet());
                }
            }
        }


        public bool equalLists(List<FcaObject> fSet, List<FcaObject> sSet)
        {
            bool flag = true;
            if (fSet.Count == sSet.Count)
            {
                int i;
                int l = sSet.Count;
                for (i = 0; (i < l) && (flag); i++)
                {
                    if(!sSet.Contains(fSet[i]))
                        flag = false;
                }

                if (i >= l)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public void Remove(FcaObjectSet obj)
        {
            List<FcaObjectSet> list = AllSets.ToList<FcaObjectSet>();
            foreach (FcaObjectSet s in list)
            {
                if (this.equalLists(s.getObjects(), obj.getObjects()))
                {
                    AllSets.Remove(s);
                }
            }
        }


        public bool Equals(FcaObjectSet set)
        {
            List<FcaObject> list1 = set.getObjects();
            List<FcaObject> listMain = this.getObjects();
            bool flag = true;
            int len = listMain.Count;
            if (len == list1.Count)
            {
                int i;
                for (i = 0; (i < len) && flag; i++)
                {
                    if (!listMain.Contains(list1[i]))
                        flag = false;
                }

                //if ((i >= len) && flag)
                //    flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public FcaObjectSet getTail()
        {
            return this.tail;
        }
    }
}
