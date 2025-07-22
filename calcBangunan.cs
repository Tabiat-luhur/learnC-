using System;
public class Program{

    public class Room{
        public string Shape {get; set;}
        public double Length {get; set;}
        public double Wide {get; set;}
        public Room(string shape, double length,double wide){
            Shape=shape;
            Length=length;
            Wide=wide;
            Console.WriteLine("Size Room: " + Size() +" m2.");
        }
        public double Size(){
            switch (Shape.ToLower())
            {
                case "persegi":
                    return Length * Wide;
                case "persegi panjang":
                    return Length * Wide;
                default:
                    return 0;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("[ >> Kalkulator Luas Bangunan << ]");
        Console.Write("> Berapa ruangan: ");
        int nRoom = int.Parse(Console.ReadLine());
        Console.WriteLine("\n[ Tersedia: Persegi, Persegi Panjang ]");
        double[] sumSize = new double[nRoom];
        for (int i = 0; i < nRoom; i++)
        {
            Console.WriteLine("\n# Room ke-" + (i + 1));
            Console.Write("- Shape: ");
            string shape = Console.ReadLine();
            Console.Write("- Length (m): ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("- Wide (m): ");
            double wide = double.Parse(Console.ReadLine());
            Room subSize = new Room(shape: shape, length: length, wide: wide);
            sumSize[i] = subSize.Size();
        }
        double totalSumSize=0;
        for (int i=0; i<nRoom; i++)
        {
            totalSumSize += sumSize[i];
        }
        Console.WriteLine("\n\t> Total Luas Bangunan: "+totalSumSize+ " m2.");
	}
}
	