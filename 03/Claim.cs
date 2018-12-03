using System;
namespace _03
{
    public class Claim
    {
        public Claim(int id, int inchesFromLeftEdge, int inchesFromTopEdge, int width, int height)
        {
            Id = id;
            InchesFromLeftEdge = inchesFromLeftEdge;
            InchesFromTopEdge = inchesFromTopEdge;
            Width = width;
            Height = height;
        }

        public int Id { get; set; }
        public int InchesFromLeftEdge { get; set; }
        public int InchesFromTopEdge { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
