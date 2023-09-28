namespace Lab4
{
    public delegate void SampleDelegate(int a, int b);
     class MathOperations
    {
        public void Add(int a, int b){ Console.WriteLine("Add Result: {0}", a + b);}
        public void Sub(int x, int y) { Console.WriteLine("Suntract Result: {0}", x - y); }
        public void Mul(int x, int y) { Console.WriteLine("Multiply Result: {0}", x*y); }
        public void Div(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine("Division by zero is not allowed.");
            }
            else
            {
                double result = (double)x / y;
                Console.WriteLine("Division Result: {0}", result);
            }
        }





        static void Main(string[] args)
        {
            Console.WriteLine("________Delegate Example___________");
            MathOperations m = new MathOperations();
            SampleDelegate dlgt = m.Add;
            dlgt += m.Sub;
            dlgt += m.Mul;
            dlgt += m.Div;
            dlgt(10, 90);
            Console.ReadLine();
        }
    }
}