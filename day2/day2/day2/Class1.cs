using System;

public class Program
{
    static void CariBuku()
    {
        string[,] buku = { { "Ninja Pura-Pura", "11" }, { "Apa Kata Pak eko", "12" }, { "Sejarah Indonesia", "13" } };
        bool ada = false;
        Console.WriteLine("> Inputkan judul buku: ");
        string cari = Console.ReadLine();
        for (int i = 0; i < buku.GetLength(0); i++)
        {
            if (cari.ToLower() == buku[i, 0].ToLower())
            {
                Console.WriteLine("\n\t> Buku: " + buku[i, 0] + ", tersedia: " + buku[i, 1] + " item.");
                ada = true;
            }
        }
        if (ada == false)
        {
            Console.WriteLine("\t> Buku tidak tersedia");
        }
    }
    static void Menu()
    {
    menuList:
        Console.WriteLine("\n\t>>> Menu <<<\n");
        Console.WriteLine("\t[1] Cari buku");
        Console.WriteLine("\t[2] Pinjam buku [Belum tersedia]");
        Console.WriteLine("\t[3] Kembalikan buku [Belum tersedia]");
        Console.WriteLine("\t[4] History [Belum tersedia]");
        Console.WriteLine("\n> Pilihan anda:");
        int select = int.Parse(Console.ReadLine());
        if (select > 0 && select < 5)
        {
            switch (select)
            {
                case 1:
                    CariBuku();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        else
        {
            Console.WriteLine("\n> Pilihan anda tidak tersedia.");
            goto menuList;
        }
    }
    public static void Main()
    {
        string[,] user = { { "farhan.it", "123farhan" }, { "sinu.edp", "123sinu" }, { "okta.edp", "123okta" } };
        string[] userDisplay = { "FARHAN PURNAMA PUTRA", "SITI NURROHMAH", "OKTAVIANTI" };
        string display;
        bool check = false;
    usernameInput:
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();
        if (username is null){
            Console.WriteLine("\n>>> Type your username first! <<<\n");
            goto usernameInput;
        } else{
            for (int i = 0; i < user.GetLength(0); i++)
            {
                if (username == user[i, 0])
                {
                    display = userDisplay[i];
                    check = true;
                    bool checkPassword = false;
                passwordInput:
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    for (int j = 0; j < user.GetLength(0); j++)
                    {
                        if (password is null){
                Console.WriteLine("\n>>> Type your password first! <<<\n");
                goto passwordInput;
            }else if (password == user[j, 1])
            {
                Console.WriteLine("\nHallo " + display + ", Selamat Datang!");
                checkPassword = true;
                Menu();
                break;
            }
        }
        if (checkPassword == false)
        {
            Console.WriteLine("\n>>> Password Invalid! <<<\n");
            goto passwordInput;
        }
    }
}
        }
        if(check==false){
            Console.WriteLine("\n>>>>> User not exist! <<<<<\n");
            goto usernameInput;
        }
	}
}