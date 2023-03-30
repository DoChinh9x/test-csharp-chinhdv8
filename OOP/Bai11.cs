using System;
using System.Text;

class SoPhuc
{
    public double PhanThuc { get; set; }
    public double PhanAo { get; set; }

    public SoPhuc()
    {
        PhanThuc = 0;
        PhanAo = 0;
    }

    public SoPhuc(double phanThuc, double phanAo)
    {
        PhanThuc = phanThuc;
        PhanAo = phanAo;
    }

    public void NhapMotSoPhuc()
    {
        Console.Write("Nhập phần thực: ");
        PhanThuc = double.Parse(Console.ReadLine());
        Console.Write("Nhập phần ảo: ");
        PhanAo = double.Parse(Console.ReadLine());
    }

    public void HienThiSoPhuc()
    {
        Console.WriteLine("{0}+{1}i", PhanThuc, PhanAo);
    }

    public static SoPhuc operator +(SoPhuc a, SoPhuc b)
    {
        double thuc = a.PhanThuc + b.PhanThuc;
        double ao = a.PhanAo + b.PhanAo;
        return new SoPhuc(thuc, ao);
    }

    public static SoPhuc operator *(SoPhuc a, SoPhuc b) =>
        new SoPhuc(
            a.PhanThuc * b.PhanThuc - a.PhanAo * b.PhanAo,
            a.PhanThuc * b.PhanAo + a.PhanAo * b.PhanThuc
        );
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SoPhuc a = new SoPhuc();
        a.NhapMotSoPhuc();
        a.HienThiSoPhuc();

        SoPhuc b = new SoPhuc(2, 3);
        b.HienThiSoPhuc();

        SoPhuc c = a + b;
        c.HienThiSoPhuc();

        SoPhuc d = a * b;
        d.HienThiSoPhuc();

        Console.ReadLine();
    }
}
