# easy, array
# https://www.techiedelight.com/check-subarray-with-0-sum-exists-not/

# O(n^2)
'''
def hasZeroSumSublist(nums):
    
    for i in range(0, len(nums) - 1):
        sum = nums[i]
        for j in range(i + 1, len(nums)):
            sum += nums[j]
            if sum == 0:
                return True
    
    return False
'''

# O(n) with set
# [front part of the array] [sub array with zero sum] [back of the array]
def hasZeroSumSublist(nums):

    s = set()
    s.add(0)
    total = 0

    for i in range(0, len(nums)):
        total += nums[i]
        if total in s:
            return True
        s.add(total)

    return False

if __name__ == "__main__":

    nums = [4, -7, 3, -1, 4, 2, 7]
    # nums = [1, 7, 2, 5, 1, 2, -3]

    if hasZeroSumSublist(nums):
        print("Sublist exists")
    else:
        print("Sublist does not exist")