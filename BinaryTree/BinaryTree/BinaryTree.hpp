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
#include <iostream>

using namespace std;

template <class T>
class BinaryTree {

private:
    Node<T> *root;
    
    void InsertNode(T, Node<T> *);
    bool SearchNode(T, Node<T> *);
    void DeleteNode(T, Node<T> *);
    void DestroyTree(Node<T> *);
    void PrintInOrder(Node<T> *);
    void PrintPostOrder(Node<T> *);
    void PrintPreOrder(Node<T> *);
    int GetMaximumDepth(Node<T> *);
    bool IsBinarySearchTree(Node<T> *, int , int);
    
public:
    void InsertNode(T);
    bool SearchNode(T);
    void DeleteNode();
    void DestroyTree();
    void PrintInOrder();
    void PrintPostOrder();
    void PrintPreOrder();
    int GetMaximumDepth();
    bool IsBinarySearchTree();
    
    BinaryTree();
    ~BinaryTree();
    BinaryTree(const BinaryTree<T>&);
    BinaryTree<T>& operator=(const BinaryTree<T>&);
};

template <typename T>
BinaryTree<T>::BinaryTree () {
    root = nullptr;
}

template <typename T>
BinaryTree<T>::~BinaryTree() {
    DestroyTree();
}

template <typename T>
BinaryTree<T>::BinaryTree(const BinaryTree<T> &b) {
    root = new Node<T>;
    *root = *(b->root);
}

template <typename T>
BinaryTree<T>& BinaryTree<T>::operator=(const BinaryTree<T> &b) {
    if (this != &b)
        *root = *(b->root);
    
    return *this;
}

template <typename T>
void BinaryTree<T>::InsertNode(T value) {
    if (root == nullptr) {
        root = new Node<T>;
        root->value = value;
        root->left = nullptr;
        root->right = nullptr;
    } else {
        InsertNode(value, root);
    }
}

template <typename T>
void BinaryTree<T>::InsertNode(T value, Node<T> *node) {
    if (value < node->value) {
        if (node->left == nullptr) {
            node->left = new Node<T>;
            node->left->value = value;
            node->left->left = nullptr;
            node->left->right = nullptr;
        } else {
            InsertNode(value, node->left);
        }
    } else {
        if (node->right == nullptr) {
            node->right = new Node<T>;
            node->right->value = value;
            node->right->left = nullptr;
            node->right->right = nullptr;
        } else {
            InsertNode(value, node->right);
        }
    }
}

template <typename T>
bool BinaryTree<T>::SearchNode(T target) {
    return SearchNode(target, root);
}

template <typename T>
bool BinaryTree<T>::SearchNode(T target, Node<T> *node) {
    if (node == nullptr)
        return false;
    else {
        if (node->value == target)
            return node;
        else if (target < node->value)
            return SearchNode(target, node->left);
        else
            return SearchNode(target, node->right);
    }
}

template <typename T>
void BinaryTree<T>::DestroyTree() {
    DestroyTree(root);
}

template <typename T>
void BinaryTree<T>::DestroyTree(Node<T> *node) {
    if (node != nullptr) {
        DestroyTree(node->left);
        DestroyTree(node->right);
        delete node;
    }
}

template <typename T>
void BinaryTree<T>::PrintInOrder() {
    PrintInOrder(root);
    cout << endl;
}

template <typename T>
void BinaryTree<T>::PrintInOrder(Node<T> *node) {
    if (node != nullptr) {
        PrintInOrder(node->left);
        cout << node->value << " ";
        PrintInOrder(node->right);
    }
}

template <typename T>
void BinaryTree<T>::PrintPreOrder() {
    PrintPreOrder(root);
    cout << endl;
}

template <typename T>
void BinaryTree<T>::PrintPreOrder(Node<T> *node) {
    if (node != nullptr) {
        cout << node->value << " ";
        PrintPreOrder(node->left);
        PrintPreOrder(node->right);
    }
}

template <typename T>
void BinaryTree<T>::PrintPostOrder() {
    PrintPostOrder(root);
    cout << endl;
}

template <typename T>
void BinaryTree<T>::PrintPostOrder(Node<T> *node) {
    if (node != nullptr) {
        PrintPostOrder(node->left);
        PrintPostOrder(node->right);
        cout << node->value << " ";
    }
}

template <typename T>
int BinaryTree<T>::GetMaximumDepth(Node<T> *node) {
    if (node == nullptr)
        return 0;
    else {
        int left = GetMaximumDepth(node->left);
        int right = GetMaximumDepth(node->right);
        
        if (left > right)
            return left + 1;
        else
            return right + 1;
    }
}

template <typename T>
bool BinaryTree<T>::IsBinarySearchTree() {
    return IsBinarySearchTree(root, INT_MIN, INT_MAX);
}

template <typename T>
bool BinaryTree<T>::IsBinarySearchTree(Node<T> *node, int min, int max) {
    if (node == nullptr)
        return true;
    else {
        if (node->value < min || node->value > max)
            return false;
        
        return (IsBinarySearchTree(node->left, min, node->value) && IsBinarySearchTree(node->right, node->value, max)); 
    }
}

#endif /* BinaryTree_hpp */
