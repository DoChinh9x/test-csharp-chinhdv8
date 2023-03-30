using System;
using System.Collections.Generic;
using System.Text;

class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string CMND { get; set; }
}

class KhachSan
{
    private Dictionary<string, Nguoi> danhSachKhach = new Dictionary<string, Nguoi>();
    private Dictionary<string, int> giaPhong = new Dictionary<string, int>()
    {
        { "A", 500 },
        { "B", 300 },
        { "C", 100 }
    };

    public void ThemKhach(Nguoi khach)
    {
        danhSachKhach.Add(khach.CMND, khach);
    }

    public void XoaKhach(string cmnd)
    {
        danhSachKhach.Remove(cmnd);
    }

    public int TinhTienThuePhong(string cmnd, string loaiPhong, int soNgayThue)
    {
        if (danhSachKhach.ContainsKey(cmnd))
        {
            int gia = giaPhong[loaiPhong];
            return soNgayThue * gia;
        }
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        KhachSan khachSan = new KhachSan();
        Nguoi khach1 = new Nguoi()
        {
            HoTen = "Nguyen Van A",
            Tuoi = 30,
            CMND = "123456789"
        };
        khachSan.ThemKhach(khach1);
        int tienThuePhong = khachSan.TinhTienThuePhong("123456789", "A", 5);
        Console.WriteLine(tienThuePhong);

        Console.ReadLine();
    }
}
