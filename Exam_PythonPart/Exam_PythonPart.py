from functools import reduce

# Question 6a 

# Question 6b 
def groupByCount(count, alist):
    listofLists = []
    for x in range(len(alist[count/2])):
        listofLists.append(x)
        for i in range(len(alist[count/2])):
            list.extend(i)
    print(listofLists)

# Question 6c

drinkList = [['Tea', ('green','spicy chai','with fruit')],
             ['Juice', ('apple','orange','mixed')],
             ['Milk',('whole','low-fat','fat-free')],
             ['Coffee',('arabica','robusta')]
            ]

def extractCoffeeBeans(): 
    onlyCoffee = list(filter(lambda a: a[0] == 'Coffee', drinkList))
    val = onlyCoffee[0][1]
    return reduce(lambda a, b: a[2], onlyCoffee)

extractCoffeeBeans()
# it should work but it doesnt find anything

# Question 7a 
def FilterDividideBy5(intList):
    dividableBy5 = list(filter(lambda a: a%5 == 0, intList))
    return dividableBy5

FilterDividideBy5([13,4,18,20,25])
# [20, 25]

# Question 7b 
class Property():
    def __init__(self, sqrMeter, numBedrooms):
        self.sqrMeter = sqrMeter
        self.numBedrooms = numBedrooms
    def showDetail(self):
        print(self)

class House(Property):
    def __init__(self,garage, fenced, numFloors, sqrMeter, numBedrooms):
        self.garage = garage
        self.fenced = fenced 
        self.numFloors = numFloors
        super().__init__(sqrMeter, numBedrooms)
    def showDetail(self):
        print(self)

class Rental():
    def __init__(self,furnished, rent):
        self.furnished = furnished 
        self.rent = rent 
    def showDetail(self):
        print(self)
      
class HouseRental(House,Rental):
    pass
   
apartment_rental = HouseRental("yes", 5000,1, 50,3)







