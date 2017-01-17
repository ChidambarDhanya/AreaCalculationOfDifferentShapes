using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AreaCalculation
{

    public abstract class Shape
    {
        public abstract Shape CalculateArea(params double[] sides);
        public double Display(double Area)
        {
            Console.WriteLine("The area is "+Area);
            return Area;
        }
        public double Area;
    }

    public abstract class ShapeFactory:Shape
    {
        public static ShapeFactory GetShape(int choice)
        {
            switch(choice)
            {
                case 1:
                    //Console.WriteLine("enter the radius");
                    //    try
                    //    {
                    //        double Radius = Convert.ToDouble(Console.ReadLine());
                    //        if (Radius <= 0)
                    //            throw new Exception("Radius can't be zero or negative");

                    //        return new Circle(Radius);

                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message);
                    //    }
                    return new Circle();

            //        break;

                case 2:
                    //try
                    //{
                    //    Console.WriteLine("Enter the length");
                    //    double Length = Convert.ToDouble(Console.ReadLine());
                    //    if (Length <= 0)
                    //        throw new Exception("Length can't be zero or negative");
                    //    Console.WriteLine("Enter the breadth");
                    //    double Breadth = Convert.ToDouble(Console.ReadLine());
                    //    if (Breadth <= 0)
                    //        throw new Exception("Breadth can't be zero or negative");
                    //    return new Rectangle(Length, Breadth);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.Message);
                    //}
                    //break;
                    return new Rectangle();


                case 3:
                    //try
                    //{
                    //    Console.WriteLine("Enter the base");
                    //    double Base = Convert.ToDouble(Console.ReadLine());
                    //    if (Base <= 0)
                    //        throw new Exception("Base can't be zero or negative");
                    //    Console.WriteLine("Enter the height");
                    //    double Height = Convert.ToDouble(Console.ReadLine());
                    //    if (Height <= 0)
                    //        throw new Exception("Height can't be zero or negative");
                    //    return new Triangle(Base, Height);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.Message);
                    //}
                    //break;
                    return new Triangle();

                default: return null;
                
            }
           
        }
        
    }

    public class Circle:ShapeFactory
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public Circle(double x)
        {
            Radius = x;
        }
        public Circle()
        {

        }

        public override Shape CalculateArea(params double[] radius)
        {
            //throw new NotImplementedException();
            if (radius.Length != 1)
                throw new Exception("invalid parameter length");
            if (radius[0] < 0)
            {
                throw new Exception("Invalid Radius");
            }
            else if (radius[0] >= Double.MaxValue)
                throw new Exception("Radius limit reached");

            Area =3.14 * radius[0] * radius[0];
            
            return this;
        }

    }

    public class Rectangle : ShapeFactory
    {
        private double _length;

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private double _breadth;

        public double Breadth
        {
            get { return _breadth; }
            set { _breadth = value; }
        }
            public Rectangle()
        {

        }
        public Rectangle(double lenght,double breadth)
        {
            Breadth = breadth;
            Length = lenght;
        }
        public override Shape CalculateArea(params double[] sides)
        {
            //   throw new NotImplementedException();
            if (sides.Length != 2)
                throw new Exception("invalid parameter length");
            double breadth = sides[0];
           double length = sides[1];
            if (breadth < 0)
                throw new Exception("Breadth can't be negative");
            else if(breadth > Double.MaxValue)
                throw new Exception("Breadth limit reached");

            if (length < 0)
                throw new Exception("Length can't be negative");
            else if(length > Double.MaxValue)
                throw new Exception("Length limit reached");


            Area = breadth * length;
            return this;
        }
    }

    public class Triangle: ShapeFactory
    {
        private double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Triangle()
        {

        }
        public Triangle(double Base,double height)
        {
            this.Base = Base;
            Height = height;
        }
        


        public override Shape CalculateArea(params double[] sides)
        {
                if (sides.Length != 2)
                    throw new Exception("invalid parameter length");
            double baseOfTriangle = sides[0];
            double height = sides[1];
            //throw new NotImplementedException();
            if (baseOfTriangle < 0)
                throw new Exception("Invalid base value");
            else if(baseOfTriangle > Double.MaxValue)
                throw new Exception("Base limit reached");

            if (height < 0)
                throw new Exception("Invalid height value");
            else if(height>Double.MaxValue)
                throw new Exception("Height limit reached");

            Area = 0.5 * baseOfTriangle * height;
            return this
                ;
        }
    }
    class AreaMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the choice\n1.Circle\n2.Rectangle\n3.Triangle");
            int ch = Convert.ToInt32(Console.ReadLine());
            Shape shape = ShapeFactory.GetShape(ch);
            var t = shape.GetType();
            switch (t.ToString())
            {
                case "AreaCalculation.Circle": Console.WriteLine("Enter the radius");
                    try
                    {
                        shape.CalculateArea(Convert.ToDouble(Console.ReadLine())).Display(shape.Area);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                     break;
                case "AreaCalculation.Rectangle": Console.WriteLine("Enter the length");
                    try { 
                    double length =Convert.ToDouble( Console.ReadLine());
                    Console.WriteLine("Enter the breadth");
                    double breadth = Convert.ToDouble(Console.ReadLine());
                    
                        shape.CalculateArea(length, breadth).Display(shape.Area);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "AreaCalculation.Triangle":Console.WriteLine("Enter the base");
                    try
                    {
                        double baseValue = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the base");
                    double height= Convert.ToDouble(Console.ReadLine());
                   
                        shape.CalculateArea(baseValue, height).Display(shape.Area);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:break;
            }
            Console.ReadKey();
        }
    }
}
