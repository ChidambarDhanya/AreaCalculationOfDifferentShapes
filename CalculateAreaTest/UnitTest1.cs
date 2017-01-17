using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculation;
using System.Reflection;

namespace CalculateAreaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForCircle()
        {

            Shape shape = ShapeFactory.GetShape(1);
            double result=shape.CalculateArea(10).Display(shape.Area);
           
            Assert.AreEqual(100*3.14,result,"error");
        }

        [TestMethod]
        public void TestForRectangle()
        {
            Shape shape = ShapeFactory.GetShape(2);
            var result = shape.CalculateArea(10, 20).Display(shape.Area);
            Assert.AreEqual(200, result, "error");
        }
        [TestMethod]
        public void TestForTriangle()
        {

            Shape shape = ShapeFactory.GetShape(3);
            var result = shape.CalculateArea(10, 20).Display(shape.Area);
            Assert.AreEqual(100, result, "error");
        }

        [TestMethod]
        public void TestForDefault()
        {
            Shape Shape = ShapeFactory.GetShape(4);
            Assert.AreEqual(Shape, null, "error");
        }
        [TestMethod]
        public void TestForInvalidParameterCircle()
        {
            Shape shape = ShapeFactory.GetShape(1);
            try
            {
                var result = shape.CalculateArea(10, 20).Display(shape.Area);

            }
            catch (Exception e)
            {
                Assert.AreEqual("invalid parameter length",e.Message, "error");
            }
        }
        public void TestForInvalidParameterRectangle()
        {
            Shape shape = ShapeFactory.GetShape(1);
            try
            {
                var result = shape.CalculateArea(10, 20,30).Display(shape.Area);

            }
            catch (Exception e)
            {
                Assert.AreEqual("invalid parameter length", e.Message, "error");
            }
        }

        public void TestForInvalidParameterTriangle()
        {
            Shape shape = ShapeFactory.GetShape(1);
            try
            {
                var result = shape.CalculateArea(10, 20,20).Display(shape.Area);

            }
            catch (Exception e)
            {
                Assert.AreEqual("invalid parameter length", e.Message, "error");
            }
        }

        [TestMethod]
        public void TestForCircleLowerLimit()
        {

            Shape shape = ShapeFactory.GetShape(1);
            
                try
                {
                    var result=shape.CalculateArea(0).Display(shape.Area);
                }
                catch(Exception e)
                {
                    Assert.AreEqual("Invalid Radius", e.Message, "error");

                }
        }

        [TestMethod]
        public void TestForRectangleLowerLimit()
        {

            Shape shape = ShapeFactory.GetShape(2);

            try
            {
                shape.CalculateArea(-10,20).Display(shape.Area);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Breadth can't be negative", e.Message, "error");

            }
        }
        

        
        [TestMethod]
        public void TestForTriangleLowerLimit()
        {

        Shape shape = ShapeFactory.GetShape(3);

        try
        {
            shape.CalculateArea(-10,20).Display(shape.Area);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Invalid base value", e.Message, "error");

        }
    }
        
       


    }
}
