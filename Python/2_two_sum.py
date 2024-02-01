# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution(object):
    def addTwoNumbers(self, l1, l2):
        return self.addTwoNumbersAux(l1, l2, 0)

    def addTwoNumbersAux(self, l1, l2, count):
        if l1 and l2:
            return ListNode((l1.val + l2.val + count) % 10, self.addTwoNumbersAux(l1.next, l2.next, (int) ((l1.val + l2.val + count) / 10)))
        elif l1:
            return ListNode((l1.val + count) % 10, self.addTwoNumbersAux(l1.next, l2, (int) ((l1.val + count) / 10)))
        elif l2:
            return ListNode((l2.val + count) % 10, self.addTwoNumbersAux(l1, l2.next, (int) ((l2.val + count) / 10)))
        elif count > 0:
            return ListNode(count, None)
        else:
            return None

    def printList(self, l):
        current = l
        while current is not None:
            print(current.val)
            current = current.next
        print()

if __name__ == "__main__":
    sol = Solution()
    l1 = ListNode(2, ListNode(4, ListNode(3, None)))
    l2 = ListNode(5, ListNode(6, ListNode(4, None)))
    sol.printList(l1)
    sol.printList(l2)
    result = sol.addTwoNumbers(l1, l2)
    sol.printList(result)