class HashEntry:
    # HashEntry object will hold the (key, value) pair in the hash table
    # A next variable is also present to prevent collision. If two values
    # have same hash value, then that value will be appended at the hash
    # position, hence creating a linked list. The next variable will hold
    # the link to the appended value
    def __init__(self, key, value):
        self.key = key
        self.value = value
        self.next = None

class HashTable:
    # Hashtable defines the capacity of the hash table, the load value which
    # it can take beyond which the hash table need to be resized, the current_capacity
    # of the hash table, and slots which hold all the inserted values
    def __init__(self, capacity, load):
        self.capacity = capacity
        self.load = load
        self.current_capacity = 0
        self.slots = [None] * self.capacity

    # Will retrieve the values from the hash table given its key
    def get(self, key):
        key_hash = hash(key)
        slot = key_hash % self.capacity

        if self.slots[slot] is not None:
            cur_node = self.slots[slot]
            while cur_node is not None:
                if cur_node.key == key:
                    return cur_node.value
                cur_node = cur_node.next
            return None

    # In case of collision, this private method is used to implement a linked
    # list and append the collision value into the hash table
    def _set_linked_list(self, key, value, slots, slot):
        cur_node = slots[slot]
        while cur_node is not None:
            if cur_node.key == key:
                cur_node.value = value
                cur_node = None
            elif cur_node.next is None:
                cur_node.next = HashEntry(key, value)
                cur_node = None
            else:
                cur_node = cur_node.next

    # Inserts the value at the hash table. Updates the current capacity
    # This method will check for load of the hash table at the beginning
    # and will resize if needed
    def set(self, key, value):
        if self.current_capacity / self.capacity > self.load:
            self.resize()

        key_hash = hash(key)
        slot = key_hash % self.capacity

        if self.slots[slot] is None:
            self.slots[slot] = HashEntry(key, value)
        else:
            self._set_linked_list(key, value, self.slots, slot)

        self.current_capacity = self.current_capacity + 1

    # This method will double the size of the hash table, generate new slots
    # and copy all the value from the old slots to the new slots
    def resize(self):
        new_capacity = self.capacity * 2
        new_slots = [None] * new_capacity

        for i in range(0, len(self.slots)):
            cur_node = self.slots[i]
            while cur_node is not None:
                key_hash = hash(cur_node.key)
                new_slot = key_hash % new_capacity

                if new_slots[new_slot] is None:
                    new_slots[new_slot] = HashEntry(cur_node.key, cur_node.value)
                else:
                    new_slots[new_slot] = self._set_linked_list(cur_node.key, cur_node.value, new_slots, new_slot)

                cur_node = cur_node.next

        self.slots = new_slots
        self.capacity = new_capacity


if __name__ == '__main__':
    values = [54, 98, 22, 37, 99, 102, 675, 21, 32, 77, 83, 123, 35, 27, 98, 255, 232, 47, 801, 23, 355]
    ht = HashTable(10, 0.95)
    for value in values:
        ht.set(value, value)
