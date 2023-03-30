using System;
using System.Collections.Generic;
using System.Text;

public class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string TenNhaXuatBan { get; set; }
    public int SoBanPhatHanh { get; set; }
}

public class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }
}

public class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int ThangPhatHanh { get; set; }
}

public class Bao : TaiLieu
{
    public DateTime NgayPhatHanh { get; set; }
}

public class QuanLySach
{
    List<TaiLieu> danhSachTaiLieu;

    public QuanLySach()
    {
        danhSachTaiLieu = new List<TaiLieu>();
    }

    public void ThemTaiLieu(TaiLieu taiLieu)
    {
        danhSachTaiLieu.Add(taiLieu);
    }

    public void XoaTaiLieu(string maTaiLieu)
    {
        TaiLieu taiLieuCanXoa = danhSachTaiLieu.Find(x => x.MaTaiLieu == maTaiLieu);
        if (taiLieuCanXoa != null)
        {
            danhSachTaiLieu.Remove(taiLieuCanXoa);
        }
    }

    public void HienThiThongTin()
    {
        foreach (TaiLieu taiLieu in danhSachTaiLieu)
        {
            Console.WriteLine("Mã tài liệu: " + taiLieu.MaTaiLieu);
            Console.WriteLine("Tên nhà xuất bản: " + taiLieu.TenNhaXuatBan);
            Console.WriteLine("Số bản phát hành: " + taiLieu.SoBanPhatHanh);

            if (taiLieu is Sach)
            {
                Sach sach = (Sach)taiLieu;
                Console.WriteLine("Tên tác giả: " + sach.TenTacGia);
                Console.WriteLine("Số trang: " + sach.SoTrang);
            }
            else if (taiLieu is TapChi)
            {
                TapChi tapChi = (TapChi)taiLieu;
                Console.WriteLine("Số phát hành: " + tapChi.SoPhatHanh);
                Console.WriteLine("Tháng phát hành: " + tapChi.ThangPhatHanh);
            }
            else if (taiLieu is Bao)
            {
                Bao bao = (Bao)taiLieu;
                Console.WriteLine("Ngày phát hành: " + bao.NgayPhatHanh);
            }
        }
    }

    public List<TaiLieu> TimKiemTaiLieuTheoLoai(string loai)
    {
        List<TaiLieu> danhSachTaiLieuTheoLoai = new List<TaiLieu>();
        foreach (TaiLieu taiLieu in danhSachTaiLieu)
        {
            if (loai == "Sach" && taiLieu is Sach)
            {
                danhSachTaiLieuTheoLoai.Add(taiLieu);
            }
            else if (loai == "TapChi" && taiLieu is TapChi)
            {
                danhSachTaiLieuTheoLoai.Add(taiLieu);
            }
            else if (loai == "Bao" && taiLieu is Bao)
            {
                danhSachTaiLieuTheoLoai.Add(taiLieu);
            }
        }

        return danhSachTaiLieuTheoLoai;
    }
}

class Program
{
    static void Main(string[] args)
    {
        QuanLySach quanLySach = new QuanLySach();
        Sach sach = new Sach
        {
            MaTaiLieu = "S001",
            TenNhaXuatBan = "NXB Kim Đồng",
            SoBanPhatHanh = 1000,
            TenTacGia = "Nguyễn Nhật Ánh",
            SoTrang = 200
        };
        quanLySach.ThemTaiLieu(sach);

        TapChi tapChi = new TapChi
        {
            MaTaiLieu = "T001",
            TenNhaXuatBan = "NXB Thanh Niên",
            SoBanPhatHanh = 5000,
            SoPhatHanh = 1,
            ThangPhatHanh = 1
        };
        quanLySach.ThemTaiLieu(tapChi);

        Bao bao = new Bao
        {
            MaTaiLieu = "B001",
            TenNhaXuatBan = "Báo Tuổi Trẻ",
            SoBanPhatHanh = 20000,
            NgayPhatHanh = new DateTime(2022, 3, 28)
        };
        quanLySach.ThemTaiLieu(bao);

        // hiển thị thông tin về tài liệu
        quanLySach.HienThiThongTin();
        // xoá tài liệu theo mã tài liệu
       quanLySach.XoaTaiLieu("T001"); 

        // hiển thị thông tin về tài liệu sau khi xoá
        quanLySach.HienThiThongTin();

        Console.ReadLine();
    }
}
