//
//  main.cpp
//  BinaryTree
//
//  Created by Ashwin V Prabhu on 12/6/17.
//  Copyright © 2017 Ashwin V Prabhu. All rights reserved.
//

#include <iostream>
#include "BinaryTree.hpp"

using namespace std;

int main(int argc, const char * argv[]) {
    
    BinaryTree<int> *bTree = new BinaryTree<int>();
    
    bTree->InsertNode(5);
    bTree->InsertNode(3);
    bTree->InsertNode(7);
    bTree->InsertNode(2);
    bTree->InsertNode(4);
    bTree->InsertNode(6);
    bTree->InsertNode(8);
    
    bTree->PrintInOrder();
    bTree->PrintPreOrder();
    bTree->PrintPostOrder();
    
    bool flag = bTree->IsBinarySearchTree();
    if (flag) cout << "yes";
    else cout << "no";
    
    bTree->DestroyTree();
    
    return 0;
}
