//
//  BinaryTree.hpp
//  BinaryTree
//
//  Created by Ashwin V Prabhu on 12/6/17.
//  Copyright © 2017 Ashwin V Prabhu. All rights reserved.
//

#ifndef BinaryTree_hpp
#define BinaryTree_hpp

#include <stdio.h>
#include "Node.h"

template <class T>
class BinaryTree {
    
    Node<T> *root;
    
    void InsertNode(T key, Node<T> *leaf);
    Node<T> * SearchNode(T key, Node<T> *leaf);
    void DeleteNode(T key, Node<T> *leaf);
    void DestroyTree(Node<T> *leaf);
    void PrintInOrder(Node<T> *leaf);
    void PrintPostOrder(Node<T> *leaf);
    void PrintPreOrder(Node<T> *leaf);
    
public:
    void InsertNode(T key);
    Node<T> * SearchNode(T key);
    void DeleteNode(T key);
    void DestroyTree();
    void PrintInOrder();
    void PrintPostOrder();
    void PrintPreOrder();
};

#endif /* BinaryTree_hpp */
