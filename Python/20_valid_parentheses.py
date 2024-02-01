from collections import deque

class Solution:
    def matches(self, left: str, right: str) -> bool:
        leftParentheses = "([{"
        rightParentheses = ")]}"
        return leftParentheses.index(left) == rightParentheses.index(right)

    def isValid(self, s: str) -> bool:
        stack = deque()
        for c in s:
            if c in "([{":
                stack.append(c)
            else:
                if len(stack) == 0:
                    return False
                left = stack.pop()
                if not self.matches(left, c):
                    return False
        
        if len(stack) > 0:
            return False
        else:
            return True

if __name__ == "__main__":
    sol = Solution()
    expression = "()[]{}"
    print("The %s expression has valid parentheses: %s" % (expression, sol.isValid(expression)))

    expression = "([{}])"
    print("The %s expression has valid parentheses: %s" % (expression, sol.isValid(expression)))

    expression = "()[]{}("
    print("The %s expression has valid parentheses: %s" % (expression, sol.isValid(expression)))