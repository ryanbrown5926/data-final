using System;

RyAVL tree = new RyAVL();

tree.Add(1);
tree.Add(2);
tree.Add(3);
tree.Add(4);
tree.Add(5);
tree.Add(6);
tree.Add(7);
tree.Add(8);

tree.InOrderDisplay();
tree.PreOrderDisplay();
tree.PostOrderDisplay();


public class RyAVL
{
    Node _root { get; set; } //root property
    public int _count { get; private set; }
    private class Node //Nodes class 
    {
        public int _value { get; set; }
        public Node _left { get; set; }
        public Node _right { get; set; }


        public Node(int value)
        {
            this._value = value;
        }

    }

    public RyAVL() //set _root to null
    {
        _root = null;
    }

    public void Add(int data)
    {
        Node child = new Node(data);
        if (_root == null) _root = child;
        else _root = Insert(_root, child);
    }

    private Node Insert(Node curr, Node child)
    {
        if (curr == null)
        {
            curr = child;
            return curr;
        }
        else if (child._value < curr._value)
        {
            curr._left = Insert(curr._left, child) ;
            curr = balance_tree(curr);
        }
        else if (child._value > curr._value)
        {
            curr._right = Insert(curr._right, child);
            curr = balance_tree(curr);
        }
        return curr;
    }

    private Node balance_tree(Node curr)
    {
        int factor = balance(curr);
        int height = 0;
        if (curr != null)
        {
            int left = getHeight(curr._left);
            int right = getHeight(curr._right);
            int m = max(left, right);
            height = m + 1;
        }
        return height;
    }

    private int balance(Node curr)
    {
        int left = getHeight(curr._left);
        int right = getHeight(curr._right);
        int factor = left - right;
        return factor;
    }

    private Node RR(Node parent) //x rebalnanced with a simple rotation rot.left
    {
        Node pivot = parent._right;
        parent._right = pivot._left;
        pivot._left = parent;
        return pivot;
    }

    private Node LL(Node parent) //x rebalanced with a simple rotation rot.right
    {
        Node pivot = parent._left;
        parent._left = pivot._right;
        pivot._right = parent;
        return pivot;
    }

    private Node LR(Node parent) //x rebalanced with a simple rotation rot.leftright
    {
        Node pivot = parent._left;
        parent._left = RR(pivot);
        return LL(parent);
    }
    private Node RL(Node parent) //x rebalanced with a simple rotation rot.rightleft
    {
        Node pivot = parent._right;
        parent._right = LL(pivot);
        return RR(parent);
    }

    public void InOrderDisplay()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }
        InOrderDisplay(_root);
        Console.WriteLine();
    }
    public void PreOrderDisplay()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }
        PreOrderDisplay(_root);
        Console.WriteLine();
    }
    public void PostOrderDisplay()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }
        PostOrderDisplay(_root);
        Console.WriteLine();
    }

    private void InOrderDisplay(Node curr)
    {
        if (curr != null)
        {
            InOrderDisplay(curr._left);
            Console.WriteLine($"{curr._value} ");
            InOrderDisplay(curr._right);
        }
    }

    private void PreOrderDisplay(Node curr)
    {
        if (curr != null)
        {
            Console.WriteLine($"{curr._value} ");
            PreOrderDisplay(curr._left);
            PreOrderDisplay(curr._right);
        }
    }

    private void PostOrderDisplay(Node curr)
    {
        if (curr != null)
        {
            PostOrderDisplay(curr._left);
            PostOrderDisplay(curr._right);
            Console.WriteLine($"{curr._value} ");
        }
    }
}
    


