using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearchTree
{
    class BinaryTree
    {
        public BinaryTree left { get; set; } //ссылка на левого потомка
        public BinaryTree right { get; set; } //ссылка на левого потомка
        public int? value { get; set; } //значение потомка
        public BinaryTree parrent { get; set; } //сылка на родителя


        public int? get_value(BinaryTree tree) // вернуть значение узла
        {
            return tree.value;

        }


        public List<int?> in_deep(BinaryTree tree, List<int?> res)
        {
            res.Add(get_value(tree));
            if (tree.left != null)
                in_deep(tree.left, res);
            if (tree.right != null)
                in_deep(tree.right, res);
            return res;
        }


        public void remove(BinaryTree node) //удаление узла
        {
            if (node.left == null && node.right == null) //узел лист
            {
                if (node.parrent.left == node)
                {
                    node.parrent.left = null;

                    return;
                }
                else
                {
                    node.parrent.right = null;
                    return;
                }

            }
            if (node.left != null && node.right == null) //узел имеет только левого потомка
            {
                if (node == node.parrent.left)
                {
                    node.parrent.left = node.left;
                }
                else
                {
                    node.parrent.right = node.left;
                }
                node.left.parrent = node.parrent;
                node = null;
                return;
            }
            if (node.right != null && node.left == null) // узел имеет толко правого потомка
            {
                if (node == node.parrent.left)
                {
                    node.parrent.left = node.right;
                }
                else
                {
                    node.parrent.right = node.right;
                }
                node.right.parrent = node.parrent;
                node = null;
                return;
            }
            if (node.right != null && node.left != null) // узел имеет обоих потомков
            {
                var el = most_left(node.right);
                node.value = el.value;
                el = null;

            }
        }

        public BinaryTree most_left(BinaryTree node) //поиск самого левого(минимального) узла в node
        {
            if (node.left == null)
            {
                BinaryTree el = node;
                remove(node);
                return el;
            }
            else
            {
                return most_left(node.left);

            }
        }
        public BinaryTree search(int? elem)//поиск узла по значению
        {
            if (this == null) return null;
            if (elem == value) { return this; }
            else
            {
                if (elem > value)
                {
                    return right.search(elem);
                }
                else
                {
                    return left.search(elem);
                }
            }

        }
        public void add(int? v)//добавление элемента с указанным значением
        {
            if (value == null)
            {
                value = v;
                return;

            }
            else
            {
                if (v >= value)
                {
                    if (right == null)
                    {
                        right = new BinaryTree();
                        right.parrent = this;
                        right.add(v);

                    }
                    else
                    {
                        right.add(v);
                    }
                }
                else
                {
                    if (left == null)
                    {
                        left = new BinaryTree();
                        left.parrent = this;
                        left.add(v);

                    }
                    else
                    {
                        left.add(v);
                    }
                }
            }
        }

    }
}

