using System;
public class Program{

    public class Car{
        public string Brand {get; set;}
        public string Color {get; set;}
        public int Speed {get; set;}
        public double Length {get; set;}
        public double Wide {get; set;}
        public Car(string brand, string color, int speed, double length,double wide){
            Brand=brand;
            Color=color;
            Speed=speed;
            Length=length;
            Wide=wide;
            Console.WriteLine("Mobil " + Brand + " berwarna " + Color + " memiliki kecepatan maksimal " + Speed + " km/jam, memiliki luas "+Size()+" m2.");
        }
        public double Size(){
            return Length*Wide;
        }
    }

	static void Main(string[] args){
		Car MyCar= new Car("Toyota","Black",250,5.5,2.5);
	}
}
	