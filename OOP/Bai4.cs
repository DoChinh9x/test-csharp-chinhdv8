using System;
using System.Collections.Generic;
using System.Text;

class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string NgheNghiep { get; set; }
    public string CMND { get; set; }
}

class HoGiaDinh
{
    public int SoThanhVien { get; set; }
    public string SoNha { get; set; }
    public List<Nguoi> DanhSachNguoi { get; set; }

    public HoGiaDinh()
    {
        DanhSachNguoi = new List<Nguoi>();
    }
}

class KhuPho
{
    public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }

    public KhuPho()
    {
        DanhSachHoGiaDinh = new List<HoGiaDinh>();
    }

    public void NhapThongTin(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhap thong tin ho gia dinh thu " + (i + 1));
            Console.Write("So thanh vien: ");
            int soThanhVien = int.Parse(Console.ReadLine());

            Console.Write("So nha: ");
            string soNha = Console.ReadLine();

            HoGiaDinh hoGiaDinh = new HoGiaDinh();
            hoGiaDinh.SoThanhVien = soThanhVien;
            hoGiaDinh.SoNha = soNha;

            for (int j = 0; j < soThanhVien; j++)
            {
                Console.WriteLine("Nhap thong tin nguoi thu " + (j + 1));
                Console.Write("Ho ten: ");
                string hoTen = Console.ReadLine();

                Console.Write("Tuoi: ");
                int tuoi = int.Parse(Console.ReadLine());

                Console.Write("Nghe nghiep: ");
                string ngheNghiep = Console.ReadLine();

                Console.Write("CMND: ");
                string cmnd = Console.ReadLine();

                Nguoi nguoi = new Nguoi();
                nguoi.HoTen = hoTen;
                nguoi.Tuoi = tuoi;
                nguoi.NgheNghiep = ngheNghiep;
                nguoi.CMND = cmnd;

                hoGiaDinh.DanhSachNguoi.Add(nguoi);
            }

            DanhSachHoGiaDinh.Add(hoGiaDinh);
        }
    }

    public void HienThiThongTin()
    {
        Console.WriteLine("Danh sach ho gia dinh:");
        foreach (HoGiaDinh hoGiaDinh in DanhSachHoGiaDinh)
        {
            Console.WriteLine("- So nha: " + hoGiaDinh.SoNha);
            Console.WriteLine("  So thanh vien: " + hoGiaDinh.SoThanhVien);
            Console.WriteLine("  Danh sach nguoi:");
            foreach (Nguoi nguoi in hoGiaDinh.DanhSachNguoi)
            {
                Console.WriteLine("  - Ho ten: " + nguoi.HoTen);
                Console.WriteLine("    Tuoi: " + nguoi.Tuoi);
                Console.WriteLine("    Nghe nghiep: " + nguoi.NgheNghiep);
                Console.WriteLine("    CMND: " + nguoi.CMND);
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhap so ho gia dinh: ");
        int n = int.Parse(Console.ReadLine());
        KhuPho khuPho = new KhuPho();
        khuPho.NhapThongTin(n);
        khuPho.HienThiThongTin();

        Console.ReadLine();
    }
}
