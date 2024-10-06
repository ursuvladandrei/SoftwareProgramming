# easy, string
# https://www.geeksforgeeks.org/problems/equilibrium-point-1587115620/1?page=1&sortBy=submissions

# O(n)
def equilibriumPoint(arr):
    if len(arr) == 1:
        return -1
    
    directSum = sum(arr)
    reverseSum = 0
    index = len(arr) - 1
    
    while index >= 0:
        if (directSum - arr[index]) == reverseSum:
            return (index + 1)
        else:
            directSum -= arr[index]
            reverseSum += arr[index]
            index -= 1
    
    return -1


if __name__ == "__main__":
    pass
