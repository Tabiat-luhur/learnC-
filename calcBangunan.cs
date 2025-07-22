using System;
public class Program{

    public class Room{
        public string Shape {get; set;}
        public double Length {get; set;}
        public double Wide {get; set;}
        public double Height {get; set;}
        public Room(string shape, double length,double wide, double height){
            Shape=shape;
            Length=length;
            Wide=wide;
            Height = height;
            Console.WriteLine("> Room Size: " + Size() +" m2.");
        }
        public double Size(){
            switch (Shape.ToLower())
            {
                case "persegi":
                    return Length * Length;
                case "persegi panjang":
                    return Length * Wide;
                case "segitiga":
                    return 0.5 * Length * Height;
                case "jajar genjang":
                    return Length * Height;
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
        Console.WriteLine("\n[ Tersedia ] \n- Persegi\n- Persegi Panjang\n- Segitiga\n- Jajar Genjang");
        double[] sumSize = new double[nRoom];
        for (int i = 0; i < nRoom; i++)
        {
            Console.WriteLine("\n# Room ke-" + (i + 1));
            Console.Write("- Shape: ");
            string shape = Console.ReadLine();
            Console.Write("- Length (m): ");
            double length = double.Parse(Console.ReadLine());
            double wide = 0;
            double height = 0;
            if (shape.ToLower() == "persegi panjang")
            {
                Console.Write("- Wide (m): ");
                wide = double.Parse(Console.ReadLine());
            }
            else if (shape.ToLower() == "segitiga" || shape.ToLower() == "jajar genjang")
            {
                Console.Write("- Height (m): ");
                height = double.Parse(Console.ReadLine());
            }
            Room subSize = new Room(shape: shape, length: length, wide: wide, height=height);
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
	