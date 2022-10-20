using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entites.BinTree
{
    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node()
        {

        }
        public Node(T data)
        {
            this.Data = data;

        }
        public Node(Node<T> data)
        {
            this.Data = data.Data;

        }
        /* public IEnumerator<T> GetEnumerator()
         {
             if (Left != null)
             {
                 foreach (var v in Left)
                 {
                     yield return v;
                 }
             }
             if (Right != null)
             {
                 foreach (var v in Right)
                 {
                     yield return v;
                 }
             }
             yield return Data;
         }
         IEnumerator IEnumerable.GetEnumerator()
         {
             return this.GetEnumerator();
         }
        */
    }
}
