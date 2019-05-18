using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodIDeer.Model
{
    public class Rectangle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Parent3
    {
        public string @object { get; set; }
        public double confidence { get; set; }
    }

    public class Parent2
    {
        public string @object { get; set; }
        public double confidence { get; set; }
        public Parent3 parent { get; set; }
    }

    public class Parent
    {
        public string @object { get; set; }
        public double confidence { get; set; }
        public Parent2 parent { get; set; }
    }

    public class Object
    {
        public Rectangle rectangle { get; set; }
        public string @object { get; set; }
        public double confidence { get; set; }
        public Parent parent { get; set; }
    }

    public class Metadata
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
    }

    public class RootObject
    {
        public List<Object> objects { get; set; }
        public string requestId { get; set; }
        public Metadata metadata { get; set; }
    }
}