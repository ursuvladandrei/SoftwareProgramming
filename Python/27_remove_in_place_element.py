from typing import List

class Solution:
    def removeElement(self, nums: List[int], val: int) -> int:
        non_equal_index = 0
        current_index = 0
        size: int = len(nums)
        while current_index < size:
            if nums[current_index] != val:
                nums[non_equal_index] = nums[current_index]
                non_equal_index += 1
                current_index += 1
            else:
                current_index += 1
        return non_equal_index

if __name__ == "__main__":
    sol = Solution()
    result: int = sol.removeElement(nums=[3,2,2,3], val=2)
    print("Result is %d" % result)

    result: int = sol.removeElement(nums=[0,1,2,2,3,0,4,2], val=2)
    print("Result is %d" % result)