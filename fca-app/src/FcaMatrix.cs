using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class FcaMatrix
    {
        private int[][] matrix;
        List<FcaObject> objects;
        List<FcaAttribute> attributes;

        public FcaMatrix()
        {
            objects = new List<FcaObject>();
            attributes = new List<FcaAttribute>();
        }

        public void setMatrix(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public void sortMatrix() 
        {
		    int n = attributes.Count;
		    int m = objects.Count;
		    int[,] tempArray = new int[m,2];
		    int[] line;
		    int count;

		    for (int i = 0; i < m; i++) 
            {
			    count = 0;
			    for (int j = 0; j < n; j++) 
                {
				    if (this.matrix[i][j] == 1)
					    count++;
			    }
			    tempArray[i,0] = i;
			    tempArray[i,1] = count;
		    }
		
		    qSort(tempArray,0,m-1);

            int[][] nMatr = new int[objects.Count][];

		    for(int i=0; i < m; i++)
            {
			    count = tempArray[i,0];
                nMatr[i] = new int[attributes.Count];
                nMatr[i] = matrix[count];
			    getElemById(i).setId(count);
			    getElemById(count).setId(i);
		    }

            matrix = nMatr;
	    }

        public FcaObject getElemById(int elemId)
        {
            int i = 0;
            int len = this.objects.Count();
            while ((i < len) && (this.objects[i].getId() != elemId))
                i++;
            if (i >= len)
                return null;
            return this.objects[i];
        }

        public FcaAttribute getAttrById(int attrId)
        {
            int i = 0;
            int len = this.attributes.Count();
            while ((i < len) && (this.attributes[i].getId() != attrId))
                i++;
            if (i >= len)
                return null;
            return this.attributes[i];
        }

        public static void qSort(int[,] A, int low, int high)
        {
            int i = low;
            int j = high;
            int x = A[(low + high) / 2,1];

            do
            {
                while (A[i,1] < x)
                    ++i; 
                while (A[j,1] > x)
                    --j; 
                if (i <= j)
                {
                    int temp0 = A[i,0];
                    int temp1 = A[i, 1];
                    A[i,0] = A[j,0];
                    A[i, 1] = A[j, 1];
                    A[j,0] = temp0;
                    A[j, 1] = temp1;
                    i++;
                    j--;
                }
            } while (i < j);
            if (low < j)
                qSort(A, low, j);
            if (i < high)
                qSort(A, i, high);
        }

        public int count() {
            return this.objects.Count;
        }

        public List<FcaObject> getObjects() {
            return this.objects;
        }

        public void setAttributes(List<FcaAttribute> attr)
        {
            this.attributes = attr;
        }

        public List<FcaAttribute> getAttributes()
        {
            return this.attributes;
        }

        public void addObject(FcaObject obj) 
        {
            bool contains = false;
            foreach (FcaObject o in objects)
            {
                if (o.getName().Equals(obj.getName()))
                    contains = true;
            }

            if (!contains)
            {
                obj.setId(objects.Count);
                objects.Add(obj);
            }
        }

        public void addAttribute(FcaAttribute attr, FcaObject obj) 
        {
            bool contains = false;
            foreach (FcaAttribute at in attributes)
            {
                if (at.getName().Equals(attr.getName()))
                {
                    getObjByName(obj.getName()).addAttr(at);
                    contains = true;
                }
            }

            if (!contains)
            {
                attr.setId(attributes.Count);
                getObjByName(obj.getName()).addAttr(attr);
                attributes.Add(attr);
            }
        }

        private FcaObject getObjByName(String name)
        {
            FcaObject obj = new FcaObject();
            foreach (FcaObject o in objects)
            {
                if (o.getName().Equals(name))
                {
                    obj = o;
                    break;
                }
            }

            return obj;
        }



        public FcaObjectSet UltimateSet()
        {
            FcaObjectSet set = new FcaObjectSet();
            foreach (FcaObject obj in objects)
            {
                set.addObject(obj);
            }
            return set;
        }
    }
}
