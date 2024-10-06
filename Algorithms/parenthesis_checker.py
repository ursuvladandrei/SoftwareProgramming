# easy, string
# https://www.geeksforgeeks.org/problems/parenthesis-checker2744

# O(n)
def parenthesisChecker(x):
    # code here
    stack = []
    mapping = { '{':'}', '[':']', '(':')' }
    for i in range(len(x)):
        if x[i] in ['{', '[', '(']:
            stack.append(x[i])
        else:
            if len(stack) == 0:
                return False
            elem = stack.pop()
            if (x[i] == mapping[elem]):
                continue
            else:
                return False
                
    if len(stack) == 0:
        return True
    else:
        return False


if __name__ == "__main__":
    string = "{[()]}"
    print(parenthesisChecker(string))
