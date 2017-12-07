//
//  Node.h
//  BinaryTree
//
//  Created by Ashwin V Prabhu on 12/6/17.
//  Copyright © 2017 Ashwin V Prabhu. All rights reserved.
//

#ifndef Node_h
#define Node_h

template <typename T>
struct Node {
    T value;
    Node<T> *left;
    Node<T> *right;
};

#endif /* Node_h */
