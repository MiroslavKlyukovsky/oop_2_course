using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entites.BinTree
{
    public class Tree<T> : IEnumerable<T>, IEnumerator<Node<T>> where T : IComparable
    {
        public int Size = 0;
        private Node<T> _root;
        public Tree()
        {
            _root = null;
            Current = _root;
        }
        public void Insert(T data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root == null)
            {
                _root = new Node<T>(data);
                Size++;
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node<T>(data));
        }
        private void InsertRec(Node<T> root, Node<T> newNode)
        {
            if (root == null)
            {
                root = newNode;
            }

            if (newNode.Data.CompareTo(root.Data) < 0)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                    Size++;
                }
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                    Size++;
                }
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(Node<T> root) //INORDER
        {
            if (root == null) return;

            DisplayTree(root.Left);
            Console.WriteLine(root.Data.ToString());
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            DisplayTree(_root);
        }


        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Node<T>>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node == null)
                    continue;

                yield return node.Data;
                stack.Push(node.Right);
                stack.Push(node.Left);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private Node<T> _Current;
        public Node<T> Current { 
            get 
            {
                /*if (_Current == null)
                {
                    this.Reset();
                }*/
                return this._Current;
            }
            set 
            {
                this._Current = value;            
            } 
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose() { }
        public void Reset()
        {
            _Current = _root;
        }
        public bool MoveNext()
        {
             if (_Current == null)
             {
                 Reset();
                 return true;
             }
            
            bool foundCurrentElement = false;
            
            int flag = 0;
            foreach (var item in this)
            {
                 flag++;
                 if (foundCurrentElement)
                 {
                    _Current = new Node<T>(item);
                    return true;
                 }
                 if (item.CompareTo(_Current.Data) == 0)
                 {
                     foundCurrentElement = true;
                 }
                 if (_Current.Data.CompareTo(_root.Data) == 0)
                 {
                     Reset();
                 }
                if (flag == this.Size) {
                    Reset();
                }
                 
            }
            return false;
        }
    }
}
