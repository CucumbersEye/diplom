﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    class Layers
    {
        List<FcaObjectSet> level;
    }

    class FcaTree
    {
        private List<FcaTree> descendants;
        private FcaTree parent;
        private FcaObjectSet mainSet;
        private int nextId;
        private List<FcaObjectSet> listOfSets;
        private List<FcaTree> listOfNodes;

        public FcaTree(){
            descendants = new List<FcaTree>();
            parent = null;
            mainSet = new FcaObjectSet();
            nextId = -1;
            listOfNodes = new List<FcaTree>();
            listOfSets = new List<FcaObjectSet>();
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
                            listOfSets.Add(q);
                            node.setNextId(q.maxObject().getId());
                            node.setParent(tree);
                            tree.addDescendant(node);
                            listOfNodes.Add(node);
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


        public FcaTree findInList(FcaObjectSet set)
        {
            FcaTree tr = new FcaTree();

            foreach (FcaTree t in listOfNodes)
            {
                if (t.getMainSet().Equals(set))
                {
                    tr = t;
                    break;
                }
            }
            //while ((tree.parent != null) && (!flag))
            //{
            //    foreach (FcaTree node in tree.descendants)
            //    {
            //        FcaObjectSet s = node.getMainSet();
            //        int l = set.count();
            //        int i;
            //        bool t = true;
            //        for (i = 0; (i < l) && (t); i++)
            //        {
            //            if (!node.getMainSet().getObjects().Contains(set.getObjects()[i]))
            //                t = false;
            //        }
            //        if ((i == l) && (t))
            //        {
            //            flag = true;
            //            tree = node;
            //        }
            //        //else
            //        //{
            //        //    tree = node;
            //        //    break;
            //        //}
            //    }
            //}
                
            return tr;
        }

        public List<FcaObjectSet> returnListOfSets(FcaTree tree)
        {
            return this.listOfSets;
        }

        //public FcaObjectSet find(FcaObjectSet set)
        //{
        //    FcaTree node = find(set, this, false);
        //    return node.getMainSet();
        //}

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
