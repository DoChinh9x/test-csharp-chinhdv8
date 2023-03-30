using System;
using System.Collections.Generic;
using System.Text;

class HocSinh
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string QueQuan { get; set; }
    public string Lop { get; set; }

    public void HienThiThongTin()
    {
        Console.WriteLine("Họ tên: " + HoTen);
        Console.WriteLine("Tuổi: " + Tuoi);
        Console.WriteLine("Quê quán: " + QueQuan);
        Console.WriteLine("Lớp: " + Lop);
    }
}

// Lớp TruongHoc để quản lý thông tin của một trường học
class TruongHoc
{
    public string TenTruong { get; set; }
    public List<HocSinh> DanhSachHocSinh { get; set; }

    public TruongHoc(string tenTruong)
    {
        TenTruong = tenTruong;
        DanhSachHocSinh = new List<HocSinh>();
    }

    public void ThemHocSinh(HocSinh hocSinh)
    {
        DanhSachHocSinh.Add(hocSinh);
    }

    public void HienThiDanhSachHocSinh()
    {
        Console.WriteLine("Danh sách học sinh:");
        foreach (HocSinh hocSinh in DanhSachHocSinh)
        {
            hocSinh.HienThiThongTin();
            Console.WriteLine();
        }
    }

    public void HienThiDanhSachHocSinh20Tuoi()
    {
        Console.WriteLine("Danh sách học sinh 20 tuổi:");
        foreach (HocSinh hocSinh in DanhSachHocSinh)
        {
            if (hocSinh.Tuoi == 20)
            {
                hocSinh.HienThiThongTin();
            }
            else
            {
                Console.WriteLine("Không có học sinh nào 20 tuổi!");
            }
        }
        Console.WriteLine();
    }

    public int DemHocSinh23TuoiQueDN()
    {
        int count = 0;
        foreach (HocSinh hocSinh in DanhSachHocSinh)
        {
            if (hocSinh.Tuoi == 23 && hocSinh.QueQuan == "DN")
            {
                count++;
            }
        }
        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        TruongHoc qlhs = new TruongHoc("Nguyễn Du");

        while (true)
        {
            Console.WriteLine("Vui lòng chọn chức năng:");
            Console.WriteLine("1. Thêm học sinh mới");
            Console.WriteLine("2. Hiển thị các học sinh 20 tuổi");
            Console.WriteLine("3. Cho biết số lượng các học sinh có tuổi là 23 và quê ở Đà Nẵng");
            Console.WriteLine("4. Thoát chương trình");

            int chon;
            while (!int.TryParse(Console.ReadLine(), out chon))
            {
                Console.WriteLine("Vui lòng nhập lại số đúng!");
            }

            switch (chon)
            {
                case 1:
                    HocSinh hs = new HocSinh();
                    Console.Write("Vui lòng nhập họ tên: ");
                    hs.HoTen = Console.ReadLine();

                    Console.Write("Vui lòng nhập tuổi: ");
                    hs.Tuoi = int.Parse(Console.ReadLine());

                    Console.Write("Vui lòng nhập quê quán: ");
                    hs.QueQuan = Console.ReadLine();

                    Console.Write("Vui lòng nhập lớp: ");
                    hs.Lop = Console.ReadLine();

                    qlhs.ThemHocSinh(hs);

                    Console.WriteLine("Thêm mới thí sinh thành công!");
                    break;
                case 2:
                    qlhs.HienThiDanhSachHocSinh20Tuoi();
                    break;
                case 3:
                    int hocSinh = qlhs.DemHocSinh23TuoiQueDN();
                    Console.WriteLine("Số học sinh trên 23 tuổi và quê ở DN là: " + hocSinh);
                    break;
                case 4:
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                    return;
                default:
                    Console.WriteLine("Vui lòng chọn chức năng đúng!");
                    break;
            }
        }
    }
}
