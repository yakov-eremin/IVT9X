import unittest
import math
from Calculator import Calculator

class TestCalculator(unittest.TestCase):

    def setUp(self):
        self.calculator = Calculator()

    def test_add_x2(self):
        self.assertEqual(self.calculator.add_x2(4,7), 11)

    def test_add_x3(self):
        self.assertEqual(self.calculator.add_x3(2,2,2), 6)

    def test_multiply_x2(self):
        self.assertEqual(self.calculator.multiply_x2(3,7), 21)

    def test_multiply_x3(self):
        self.assertEqual(self.calculator.multiply_x3(2,2,2), 8)

    def test_subtract_x2(self):
        self.assertEqual(self.calculator.subtract_x2(10,5), 5)

    def subtract_x3(self, x1, x2, x3):
        self.assertEqual(self.calculator.subtract_x3(10,5,5), 0)


    def test_divide(self):
        self.assertEqual(self.calculator.divide(10,2), 5)

    def test_degree(self):
        self.assertEqual(self.calculator.degree(3,4), 81)
    

    def test_area_circle(self):
        self.assertEqual(self.calculator.area_circle(1), (1**2) * math.pi)

    def test_area_square(self):
        self.assertEqual(self.calculator.area_circle(2), 4)

    def test_Sqrt(self):
        self.assertEqual(self.calculator.area_circle(4), 2)

if __name__ == "__main__":
  unittest.main()