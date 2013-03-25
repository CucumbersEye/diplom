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

        public void sortMatrix() {
		    int n = attributes.Count;
		    int m = objects.Count;
		    int[,] tempArray = new int[m,2];
		    int[] line;
		    int count;

		    for (int i = 0; i < m; i++) {
			    count = 0;
			    for (int j = 0; j < n; j++) {
				    if (this.matrix[i][j] == 1)
					    count++;
			    }
			    tempArray[i,0] = i;
			    tempArray[i,1] = count;
		    }
		
		    qSort(tempArray,0,m-1);
		
		    for(int i=0; i < m; i++){
			    count = tempArray[i,0];
                if (i < m / 2 + 1){
                    line = this.matrix[count];
                    this.matrix[count] = this.matrix[i];
                    this.matrix[i] = line;
                }
			    getElemById(i).setId(count);
			    getElemById(count).setId(i);
		    }
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

        public void setAttributes(List<FcaAttribute> attr)
        {
            this.attributes = attr;
        }

        public List<FcaAttribute> getAttributes()
        {
            return this.attributes;
        }

        public void addObject(FcaObject obj) {
            this.objects.Add(obj);
        }

        public void addAttribute(FcaAttribute attr) {
            this.attributes.Add(attr);
        }
    }
}
