# easy, sorting, hashing
# https://www.techiedelight.com/find-pair-with-given-sum-array/

# O(n^2)
'''
def findPair(nums, target):
    for i in range(0, len(nums)):
        for j in range(i + 1, len(nums)):
            if (nums[i] + nums[j]) == target:
                print("Pair found", (nums[i], nums[j]))
                return

    print("Pair not found")
'''

# O(n) with sorting
'''
def findPair(nums, target):
    (low, high) = (0, len(nums) - 1)
    nums.sort()

    while low < high:
        if (nums[low] + nums[high]) == target:
            print("Pair found", (nums[low], nums[high]))
            return 
        if (nums[low] + nums[high]) > target:
            high -= 1
        else:
            low += 1
    
    print("Pair not found")
'''

# O(n) with hashing
def findPair(nums, target):
    dict = {}
    for i in range(0, len(nums)):
        if (target - nums[i]) in dict:
            print("Pair found", (nums[i], target - nums[i]))
            return
        else:
            dict[nums[i]] = True

if __name__ == "__main__":
    nums = [8, 7, 2, 5, 3, 1]
    target = 10
    findPair(nums, target)