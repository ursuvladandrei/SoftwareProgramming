
def collinearity(x1, y1, x2, y2):
    if x2 == 0 and y2 == 0:
        return True
    elif x2 == 0:
        return x1 == 0
    elif y2 == 0:
        return y1 == 0
    else:
        return x1 / x2 == y1 / y2

# simple solution: return x1 * y2 == x2 * y1

'''
from solution import collinearity
import codewars_test as test

@test.describe("Basic Tests")
def basic_tests():
    
    @test.it("the vectors are directed in one direction")
    def test_fixed():
        test.assert_equals(collinearity(1,1,1,1), True, f"Input: {1,1,1,1}")
        test.assert_equals(collinearity(1,2,2,4), True, f"Input: {1,2,2,4}")
    
    @test.it("the vectors are directed in opposite directions")
    def test_fixed():
        test.assert_equals(collinearity(1,1,6,1), False, f"Input: {1,1,6,1}")
        test.assert_equals(collinearity(1,2,-1,-2), True, f"Input: {1,2,-1,-2}")
        test.assert_equals(collinearity(1,2,1,-2), False, f"Input: {1,2,1,-2}")
    
    @test.it("the vectors contain zero")
    def test_fixed():
        test.assert_equals(collinearity(4,0,11,0), True, f"Input: {4,0,11,0}")
        test.assert_equals(collinearity(0,1,6,0), False, f"Input: {0,1,6,0}")
        test.assert_equals(collinearity(4,4,0,4), False, f"Input: {4,4,0,4}")
    
    @test.it("vector with coordinates x = 0 and y = 0")
    def test_fixed():
        test.assert_equals(collinearity(0,0,0,0), True, f"Input: {0,0,0,0}")
        test.assert_equals(collinearity(0,0,1,0), True, f"Input: {0,0,1,0}")
        test.assert_equals(collinearity(5,7,0,0), True, f"Input: {5,7,0,0}")
'''