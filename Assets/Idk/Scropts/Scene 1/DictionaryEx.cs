using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryEx
{
    public class DictionaryUse
    {
        private BinaryTree tree = new BinaryTree();
        private WordNode sort = null;

        public DictionaryUse()
        {
            //file into array
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\arroy\Documents\Unity\words_alpha.txt");
            foreach (string line in lines) //Idk how ok this is gotta check later
                count++;
            //array into binary tree
            sort = tree.balancingBT(lines, 0, count - 1);  //balancingBT must be internal?
        }

        public bool check(string s)
        {//Checking to see if Word used exists
            string key = s;
            string wordCheck = tree.find(key, sort);
            if (wordCheck != null && wordCheck.Equals(key))
            {
                tree.delete(key, sort);
                return true;
            }
            return false;
        }

        public string randomWord(char c, int difficultyValue)
        { //bots random word chosen here

            string s = "" + c;
            WordNode bTClone = tree.cloneTree(sort);
            string word = tree.findCWords(s, bTClone);
            List<string> list = new List<string>();

            switch (difficultyValue)
            { //switch statement to decide what length of words go into list
                case 0: //length 0-4
                    do
                    {
                        if (word.Length > 4)
                        {
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                        else
                        {
                            list.Add(word);
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                    } while (word != null && c == word[0]);
                    break;

                case 1: //length 5-7
                    do
                    {
                        if (word.Length > 7 || word.Length < 4)
                        {
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                        else
                        {
                            list.Add(word);
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                    } while (word != null && c == word[0]);
                    break;

                case 2: //length 8:end
                    do
                    {
                        if (word.Length < 7)
                        {
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                        else
                        {
                            list.Add(word);
                            tree.delete(word, bTClone);
                            word = tree.findCWords(s, bTClone);
                        }
                    } while (word != null && c == word[0]);
                    break;

                default: //all words
                    do
                    {
                        list.Add(word);
                        tree.delete(word, bTClone);
                        word = tree.findCWords(s, bTClone);
                    } while (word != null && c == word[0]);
                    break;
            }

            if (list.Count != 0)
            {
                int size = list.Count; //list.size();
                //Console.WriteLine("List size is " + size);
                System.Random rand = new System.Random();
                int chooseRand = rand.Next(size);
                //Console.WriteLine("random int " + chooseRand);
                string choosenWord = list[chooseRand];
                //Console.WriteLine("random word " + choosenWord);
                list.Remove(choosenWord); //Unnecessary?
                tree.delete(choosenWord, sort);
                return choosenWord;
            }
            else
                return "I_quit";
        }

        //Binary Tree Start
        class WordNode
        {
            public string text;
            public WordNode rightPtr;
            public WordNode leftPtr;
            public WordNode(string s)
            {
                text = s;
            }
            public override string ToString()
            {
                return text;
            }
        }

        class BinaryTree
        {
            internal WordNode balancingBT(string[] words, int start, int end)
            {
                if (start > end)
                    return null;

                // Get the middle element and make it root
                int mid = start + (end - start) / 2;
                WordNode node = new WordNode(words[mid]);

                //Recursively construct the left subtree and make it left child of root 
                node.leftPtr = balancingBT(words, start, mid - 1);

                // Recursively construct the right subtree and make it right child of root
                node.rightPtr = balancingBT(words, mid + 1, end);

                return node;
            }

            public string find(string key, WordNode localroot) // find node with given key
            { // (assumes non-empty tree)
                WordNode current = localroot; // start at root

                while (!current.text.Equals(key)) // while no match,
                {
                    if (string.Compare(key, current.text, true) <= -1)                            // go left?
                        current = current.leftPtr;
                    else if (string.Compare(key, current.text, true) >= 1)                        // or go right?
                        current = current.rightPtr;
                    if (current == null)
                    {   // if no child,
                        return null; // didn't find it   
                    }
                }
                return current.text; // found it
            }  // end find()

            public string findCWords(string key, WordNode localroot) // finding words based on the starting Char
            {// (assumes non-empty tree)
                WordNode current = localroot; // start at root

                while (!(current.text[0] == key[0])) // while no match,
                {
                    if (key[0] < current.text[0])
                        current = current.leftPtr;
                    else if (key[0] > current.text[0])
                        current = current.rightPtr;
                    if (current == null) // if no child, 
                        return null; // didn't find it
                }
                return current.text; // found it
            }  // end find()

            public bool delete(string key, WordNode localroot)
            {
                WordNode current = localroot;
                WordNode parent = localroot;
                bool isLeftChild = true;

                while (!current.text.Equals(key))
                { // search for node

                    parent = current;

                    if (string.Compare(key, current.text, true) <= -1)
                    {  // go left?			
                        isLeftChild = true;
                        current = current.leftPtr;
                    }
                    else
                    {      // or go right?	
                        isLeftChild = false;
                        current = current.rightPtr;
                    }
                    if (current == null)             // end of the line,
                        return false;                // didn't find it
                }  // end while

                // found node to delete
                // if no children, simply delete it
                if (current.leftPtr == null && current.rightPtr == null)
                {
                    //check if what you are deleting is the root - only one node in the tree.
                    if (current == parent)
                        localroot = null;
                    if (isLeftChild)
                        parent.leftPtr = null;
                    else
                        parent.rightPtr = null;
                }
                // if no right child, replace with left subtree
                else if (current.rightPtr == null && current.leftPtr != null)
                {
                    if (current == parent)
                        localroot = current.leftPtr;
                    if (isLeftChild)
                        parent.leftPtr = current.leftPtr;
                    else
                        parent.rightPtr = current.leftPtr;
                }
                // if no left child, replace with right subtree
                else if (current.rightPtr != null && current.leftPtr == null)
                {
                    if (current == parent)
                        localroot = current.rightPtr;
                    if (isLeftChild)
                        parent.leftPtr = current.rightPtr;
                    else
                        parent.rightPtr = current.rightPtr;
                }
                // two children, so replace with in order successor
                else
                {
                    WordNode successor = getSuccessor(current);
                    if (current == parent)
                    {
                        successor.leftPtr = current.leftPtr;
                        localroot = successor;
                        return true;
                    }
                    // parent point to successor
                    if (isLeftChild)
                        parent.leftPtr = successor;
                    else
                        parent.rightPtr = successor;
                    // successor point to current children
                    successor.leftPtr = current.leftPtr;
                }
                // (successor cannot have a left child)
                return true;
            }//end delete
             // -------------------------------------------------------------
             // returns node with next-highest value after delNode
             // goes to right child, then right child's left descendants
            private WordNode getSuccessor(WordNode delNode)
            {
                WordNode successorParent = delNode;
                WordNode successor = delNode;
                WordNode current = delNode.rightPtr;   // go to right child
                while (current != null)               // until no more
                {                                 // left children,
                    successorParent = successor;
                    successor = current;
                    current = current.leftPtr;      // go to left child
                }
                // if successor not
                if (successor != delNode.rightPtr)  // right child,
                {                                 // make connections
                    successorParent.leftPtr = successor.rightPtr;
                    successor.rightPtr = delNode.rightPtr;
                }
                return successor;
            }

            public WordNode cloneTree(WordNode cloneRoot)
            {
                if (cloneRoot == null)
                    return null;
                WordNode cloneNode = new WordNode(cloneRoot.text);
                cloneNode.leftPtr = cloneTree(cloneRoot.leftPtr);
                cloneNode.rightPtr = cloneTree(cloneRoot.rightPtr);
                return cloneNode;
            }
        }
    }
}
