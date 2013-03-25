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
                        if (q.difference(tree.getMainSet()).minObject() == nextObject)
                        {
                            node = new FcaTree();
                            node.setMainSet(q);
                            node.setNextId(q.maxObject().getId());
                            node.setParent(tree);
                            tree.addDescendant(node);
                            closureOneByOne(matrix, node);
                            tree.setNextId(q.maxObject().getId());
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

        private FcaTree getParent()
        {
            return this.parent;
        }

        private void addDescendant(FcaTree node)
        {
            this.descendants.Add(node);
        }

        private void setParent(FcaTree tree)
        {
            this.parent = tree;
        }

        private void setNextId(int p)
        {
            this.nextId = p;
        }

        private void setMainSet(FcaObjectSet q)
        {
            this.mainSet = q;
        }

        private FcaObjectSet getMainSet()
        {
            return this.mainSet;
        }

        private int getNextId()
        {
            return this.nextId;
        }
    }
}
