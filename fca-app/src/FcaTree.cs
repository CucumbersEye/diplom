using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class FcaTree
    {
        private List<FcaTree> descendants;
        private FcaTree parent;
        private FcaObjectSet mainSet;
        private int nextId;

        public FcaTree(){
            descendants = new List<FcaTree>();
            parent = null;
            mainSet = new FcaObjectSet();
            nextId = -1;
        }

        public void closureOneByOne(FcaMatrix matrix, FcaTree tree)
        {
            FcaObject nextObject = new FcaObject();
            FcaTree node;
            do
            {
                do
                {
                    nextObject = matrix.getElemById(tree.getNextId() + 1);
                    if (nextObject != null)
                    {
                        FcaObjectSet q = new FcaObjectSet();
                        q = tree.getMainSet().clone();
                        q.closure(nextObject, matrix);
                        FcaObjectSet dif =q.difference(tree.getMainSet()); 
                        if (dif.minObject() == nextObject)
                        {
                            node = new FcaTree();
                            node.setMainSet(q);
                            node.setNextId(q.maxObject().getId());
                            node.setParent(tree);
                            tree.addDescendant(node);
                            closureOneByOne(matrix, node);
                            tree.setNextId(nextObject.getId());
                        }
                        else
                        {
                            tree.setNextId(nextObject.getId());
                        }
                    }
                } while (nextObject != null);
                if (tree.getParent() != null)
                    tree = tree.getParent();
            } while ((tree.getParent() != null) && (nextObject != null));
        }



        public List<FcaTree> minimal()
        {
            List<FcaTree> minimalSets = new List<FcaTree>();
            int min = this.descendants[0].getMainSet().count();
            minimalSets.Add(this.descendants[0]);
            int len = this.descendants.Count;
            for (int i = 1; i < len; i++)
            {
                if (this.descendants[i].getMainSet().count() < min)
                {
                    min = this.descendants[i].getMainSet().count();
                    minimalSets.Clear();
                    minimalSets.Add(this.descendants[i]);
                }
                else if (this.descendants[i].getMainSet().count() == min)
                {
                    minimalSets.Add(this.descendants[i]);
                }
            }
            return minimalSets;
        }

        public FcaTree getParent()
        {
            return this.parent;
        }

        public void addDescendant(FcaTree node)
        {
            this.descendants.Add(node);
        }

        public void setParent(FcaTree tree)
        {
            this.parent = tree;
        }

        public void setNextId(int p)
        {
            this.nextId = p;
        }

        public void setMainSet(FcaObjectSet q)
        {
            this.mainSet = q;
        }

        public FcaObjectSet getMainSet()
        {
            return this.mainSet;
        }

        public int getNextId()
        {
            return this.nextId;
        }

        public List<FcaTree> getDescendants()
        {
            return this.descendants;
        }

        public List<FcaTree> subtraction(List<FcaTree> set)
        {
            List<FcaTree> resultSet = new List<FcaTree>();
            foreach (FcaTree node in this.getDescendants())
            {
                if (!set.Contains(node))
                {
                    resultSet.Add(node);
                }
            }
            return resultSet;
        }
    }
}
