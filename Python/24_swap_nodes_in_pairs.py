# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution(object):
    def swapPairs(self, head):
        currNode = head
        newHead = head.next

        while currNode is not None and currNode.next is not None:
            temp = currNode.next
            currNode.next = currNode.next.next
            temp.next = currNode
            currNode = currNode.next
            if currNode is not None and currNode.next is not None:
                temp.next.next = currNode.next

        return newHead

    def printList(self, l):
        current = l
        while current is not None:
            print(current.val)
            current = current.next
        print()

if __name__ == "__main__":
    sol = Solution()
    l1 = ListNode(1, ListNode(2, ListNode(3, ListNode(4, None))))
    sol.printList(l1)
    result = sol.swapPairs(l1)
    sol.printList(result)