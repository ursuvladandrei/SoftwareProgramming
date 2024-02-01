# https://math.stackexchange.com/questions/208577/find-if-three-points-in-3-dimensional-space-are-collinear

def are_collinear(points: List[Point3d]) -> bool:
    # we can expect at least 3 points from the description of the problem
    (p1, p2) = (points[0], points[1])
    
    for p in points[2:]:
        p3 = p
        if not check_collinearity(p1, p2, p3):
            return False
        (p1, p2) = (p2, p3)
    
    return True
    
def check_collinearity(p1, p2, p3):
    (x1, y1, z1) = p1
    (x2, y2, z2) = p2
    (x3, y3, z3) = p3
    
    (abx, aby, abz) = (x2 - x1, y2 - y1, z2 - z1)
    (acx, acy, acz) = (x3 - x1, y3 - y1, z3 - z1)
    
    
    abcxy = abx * acy - aby * acx
    abcxz = abx * acz - abz * acx
    abcyz = aby * acz - abz * acy
    
    return abcxy == 0 and abcxz == 0 and abcyz == 0

'''
import codewars_test as test
from preloaded import Point3d
from solution import are_collinear


test.describe("Example Test Cases")

test.it("Basic tests")
test.assert_equals(are_collinear([
    (8, -8, 1),
    (4, -12, 5),
    (-10, -26, 19),
    (9, -7, 0)
]), True)
test.assert_equals(are_collinear([
    (-4.5, -62, 5),
    (9, -50, 8),
    (-27, -82, 0)
]), True)
test.assert_equals(are_collinear([
    (-4.5, -62, 3),
    (9, -52, 8),
    (-27, -82, 0)
]), False)

'''