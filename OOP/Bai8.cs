using System;
using System.Collections.Generic;
using System.Text;

class SinhVien
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string Lop { get; set; }
}

class TheMuon
{
    public string MaPhieuMuon { get; set; }
    public int NgayMuon { get; set; }
    public int HanTra { get; set; }
    public string SoHieuSach { get; set; }
    public SinhVien SinhVienMuon { get; set; }

    public TheMuon(
        string maPhieuMuon,
        int ngayMuon,
        int hanTra,
        string soHieuSach,
        SinhVien sinhVienMuon
    )
    {
        MaPhieuMuon = maPhieuMuon;
        NgayMuon = ngayMuon;
        HanTra = hanTra;
        SoHieuSach = soHieuSach;
        SinhVienMuon = sinhVienMuon;
    }
}

class ThuVien
{
    private List<TheMuon> danhSachTheMuon = new List<TheMuon>();

    public void ThemTheMuon(TheMuon theMuon)
    {
        danhSachTheMuon.Add(theMuon);
    }

    public void XoaTheMuon(string maPhieuMuon)
    {
        for (int i = 0; i < danhSachTheMuon.Count; i++)
        {
            if (danhSachTheMuon[i].MaPhieuMuon == maPhieuMuon)
            {
                danhSachTheMuon.RemoveAt(i);
                break;
            }
        }
    }

    public void HienThiDanhSachTheMuon()
    {
        foreach (TheMuon theMuon in danhSachTheMuon)
        {
            Console.WriteLine("Mã phiếu mượn: {0}", theMuon.MaPhieuMuon);
            Console.WriteLine("Ngày mượn: {0}", theMuon.NgayMuon);
            Console.WriteLine("Hạn trả: {0}", theMuon.HanTra);
            Console.WriteLine("Số hiệu sách: {0}", theMuon.SoHieuSach);
            Console.WriteLine(
                "Sinh viên mượn sách: {0} - {1} - {2}",
                theMuon.SinhVienMuon.HoTen,
                theMuon.SinhVienMuon.Tuoi,
                theMuon.SinhVienMuon.Lop
            );
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ThuVien thuVien = new ThuVien();

        SinhVien sinhVienMuon = new SinhVien
        {
            HoTen = "Nguyen Van A",
            Tuoi = 20,
            Lop = "K61-C-CLC2"
        };
        TheMuon theMuon1 = new TheMuon("PM001", 1, 15, "SHS001", sinhVienMuon);
        thuVien.ThemTheMuon(theMuon1);

        SinhVien sinhVienMuon2 = new SinhVien
        {
            HoTen = "Tran Thi B",
            Tuoi = 21,
            Lop = "K62-C-CLC1"
        };
        TheMuon theMuon2 = new TheMuon("PM002", 2, 16, "SHS002", sinhVienMuon2);
        thuVien.ThemTheMuon(theMuon2);

        thuVien.HienThiDanhSachTheMuon();
        Console.ReadLine();
    }
}
