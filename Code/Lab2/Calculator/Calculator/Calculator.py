import math


class Calculator:
  #empty constructor
  def __init__(self):
    pass

  def add_x2(self, x1, x2):
    return x1 + x2

  def add_x3(self, x1, x2, x3):
    return x1 + x2 - x3

  def multiply_x2(self, x1, x2):
    return x1 * x2
  
  def multiply_x3(self, x1, x2, x3):
    return x1 * x2 + x3

  def subtract_x2(self, x1, x2):
    return x1 - x2

  def subtract_x3(self, x1, x2, x3):
    return x1 - x2 + x3


  def divide(self, x1, x2):
    if x2 != 0:
      return x1/x2

  def degree(self, x1, x2):
      return x1**x2

  def area_circle(self, r):
      return (r**2) * math.pi

  def area_square(self, s):
      return (s**2)

  def Sqrt(self, s):
      math.sqrt(s)