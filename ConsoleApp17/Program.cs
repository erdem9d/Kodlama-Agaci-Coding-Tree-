using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Kaç sayı gireceksiniz? ");  // Kullanıcıya kaç sayı gireceğini soruyoruz
        int n = int.Parse(Console.ReadLine());  // Kullanıcının girdiği sayıyı alıyoruz

        Node root = null;  // Başlangıçta kök düğüm boş (null)

        // Kullanıcıdan n sayısı alıp ağaca ekliyoruz
        for (int i = 0; i < n; i++)
        {
            Console.Write("Bir sayı girin: ");  // Kullanıcıdan bir sayı girmesini istiyoruz
            int value = int.Parse(Console.ReadLine());  // Kullanıcıdan alınan sayıyı integer'a çeviriyoruz

            // Yeni sayıyı ağaca ekliyoruz
            if (root == null)  // Eğer ağaç boşsa, yeni bir düğüm oluşturuyoruz
                root = new Node(value);  // Kök düğümünü bu değere atıyoruz
            else
            {
                Node current = root;  // Kök düğümden başlıyoruz
                while (true)
                {
                    if (value < current.Value)  // Eğer yeni değer küçükse, sola git
                    {
                        if (current.Left == null)  // Eğer sol alt ağaç boşsa, yeni düğüm ekle
                        {
                            current.Left = new Node(value);
                            break;
                        }
                        else
                            current = current.Left;  // Sol alt ağaca geç
                    }
                    else  // Eğer yeni değer büyükse, sağa git
                    {
                        if (current.Right == null)  // Eğer sağ alt ağaç boşsa, yeni düğüm ekle
                        {
                            current.Right = new Node(value);
                            break;
                        }
                        else
                            current = current.Right;  // Sağ alt ağaca geç
                    }
                }
            }
        }

        // Ağacın sıralı şekilde yazdırılması (inorder traversal)
        Console.WriteLine("Ağaç sıralı şekilde:");
        Node node = root;
        Stack<Node> stack = new Stack<Node>();  // Ağacın sıralı gezilmesi için stack kullanıyoruz

        // Ağacı sıralı şekilde gezmek için stack kullanıyoruz
        while (node != null || stack.Count > 0)
        {
            while (node != null)  // Sol alt ağacı en sola kadar gez
            {
                stack.Push(node);  // Gezinilen düğümü stack'e ekle
                node = node.Left;  // Sol alt ağaca geç
            }

            // Stack'ten bir düğüm al ve yazdır
            node = stack.Pop();  // Stack'ten en son eklenen düğümü al
            Console.Write(node.Value + " ");  // Düğümün değerini yazdır

            node = node.Right;  // Sağ alt ağaca geç

        }
        Console.ReadLine();
    }
}

// Ağaç düğümünü temsil eden sınıf
class Node
{
    public int Value;  // Düğümün değeri
    public Node Left, Right;  // Sol ve sağ çocuklar

    // Yapıcı metot: Düğümün değeri ile birlikte sol ve sağ çocukları başlatır
    public Node(int value) => (Value, Left, Right) = (value, null, null);  // Değeri alıp sol ve sağ çocukları null olarak ayarlıyoruz
}
