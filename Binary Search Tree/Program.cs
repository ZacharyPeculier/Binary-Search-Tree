using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree bst = new Tree();
            Console.WriteLine("Binary Search Tree Enabled!");
            Console.WriteLine("When you are done adding integers, type done");
            string s;
            int v;
            bool userDone = false;
            bool quit = false;
            while (userDone != true)
            {
                s = bst.acceptNode();
                if (s.ToLower() == "done")
                {
                    userDone = true;
                    bst.print();
                }
                else
                {
                    if (int.TryParse(s, out v))
                    { bst.insert(v); }
                    else { Console.WriteLine("Please enter an integer"); }
                }
            }

            while (!quit)
            {
                Console.WriteLine("Would you like to insert, remove, or quit? (i/r/q)");
                s = Console.ReadLine();
                if (s == "i")
                {
                    userDone = false;
                    while (userDone != true)
                    {
                        s = bst.acceptNode();
                        if (s.ToLower() == "done")
                        {
                            userDone = true;
                            bst.print();
                        }
                        else
                        {
                            if (int.TryParse(s, out v))
                            { bst.insert(v); }
                            else
                            {
                                if (int.TryParse(s, out v))
                                { bst.insert(v); }
                                else { Console.WriteLine("Please enter an integer"); }
                            }
                        }
                    }
                }
                else if (s == "r")
                {
                    int del;
                    do
                    {
                        Console.WriteLine("Which node would you like to remove?");
                        s = Console.ReadLine();
                    }
                    while (!int.TryParse(s, out del));
                    bst.remove(del);
                    bst.print();
                }
                else if (s == "q")
                {
                    Console.WriteLine("Binary Search Tree Disabled!");
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Not an option");
                }
            }
        }
    }
    class Node
    {
        public int currentValue;
        public Node left;
        public Node right;

        public Node(int value)
        {
            currentValue = value;
            left = null;
            right = null;
        }
    }
    class Tree
    {
        private Node root;
        public void insert(int value)
        {
            Node newNode = new Node(value);
            if (root != null)
            {
                Node pointer = root;
                Node parent;
                while (true)
                {
                    parent = pointer;
                    if (value > pointer.currentValue)
                    {
                        pointer = pointer.right;
                        if (pointer == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                    else
                    {
                        pointer = pointer.left;
                        if (pointer == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                }
            }
            else
            {
                root = newNode;
            }
        }
        public void remove(int value)
        {
            delete(ref root, value);
        }
        public Node delete(ref Node node, int value)
        {
            if (node != null)
            {
                if (value < node.currentValue)
                {
                    delete(ref node.left, value);
                }
                else if (value > node.currentValue)
                {
                    delete(ref node.right, value);
                }
                else
                {
                    if (node.left == null && node.right == null)
                    {
                        node = null;
                        return node;
                    }
                    else if (node.left == null)
                    {
                        Node temp = node;
                        node = node.right;
                        temp = null;
                        return node;
                    }
                    else if (root.right == null)
                    {
                        Node temp = node;
                        node = node.left;
                        temp = null;
                        return node;
                    }
                    else
                    {
                        Node temp = findMin(node);
                        node.currentValue = temp.currentValue;
                        node.right = delete(ref node.right, temp.currentValue);

                    }
                }
            }
            else
            {
                return node;
            }
            return node;
        }
        public Node findMin(Node node)
        {
            while (node.right != null)
            {
                node = node.left;
            }
            return node;
        }
        public void print()
        {
            Console.Write("Inorder Traverlsal:");
            inOrder(root);
            Console.WriteLine();
        }
        public void inOrder(Node node)
        {
            if (node != null)
            {
                inOrder(node.left);
                Console.Write(" " + node.currentValue);
                inOrder(node.right);
            }
            else
            {
                return;
            }
        }
        public string acceptNode()
        {
            string s;
            Console.Write("Next value: ");
            s = Console.ReadLine();
            return s;
        }
    }
}