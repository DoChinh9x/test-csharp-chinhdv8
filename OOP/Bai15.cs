using System;
using System.Collections.Generic;
using System.Linq;

public class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public int NamVaoHoc { get; set; }
    public double DiemDauVao { get; set; }

    public List<KetQuaHocTap> DsKetQuaHocTap { get; set; }

    public SinhVien() { }

    public SinhVien(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao)
    {
        MaSV = maSV;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        NamVaoHoc = namVaoHoc;
        DiemDauVao = diemDauVao;
        DsKetQuaHocTap = new List<KetQuaHocTap>();
    }

    public SinhVien(SinhVien sinhVien)
    {
        MaSV = sinhVien.MaSV;
        HoTen = sinhVien.HoTen;
        NgaySinh = sinhVien.NgaySinh;
        NamVaoHoc = sinhVien.NamVaoHoc;
        DiemDauVao = sinhVien.DiemDauVao;
        DsKetQuaHocTap = new List<KetQuaHocTap>(sinhVien.DsKetQuaHocTap);
    }

    public void NhapThongTin()
    {
        Console.WriteLine("Nhap ma SV: ");
        MaSV = Console.ReadLine();
        Console.WriteLine("Nhap ho ten SV: ");
        HoTen = Console.ReadLine();
        Console.WriteLine("Nhap ngay sinh cua SV: ");
        NgaySinh = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Nhap nam vao hoc: ");
        NamVaoHoc = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhap diem dau vao: ");
    }

    public void XuatThongTin()
    {
        Console.WriteLine("Ma SV: " + MaSV);
        Console.WriteLine("Ho ten SV: " + HoTen);
        Console.WriteLine("Ngay sinh: " + NgaySinh);
        Console.WriteLine("Nam vao hoc: " + NamVaoHoc);
        Console.WriteLine("Diem dau vao: " + DiemDauVao);
        Console.WriteLine("Ds ket qua hoc tap: ");
        foreach (KetQuaHocTap kq in DsKetQuaHocTap)
        {
            kq.ShowInfo();
        }
        Console.WriteLine();
    }

    public void LayDiemTrungBinhMonDuaVaoKy(string tenky)
    {
        SinhVien sv = new SinhVien();
        foreach (KetQuaHocTap kqht in sv.DsKetQuaHocTap)
        {
            if (kqht.TenHocKy == tenky)
            {
                Console.WriteLine(
                    "Diem Tb hoc ky {0} cua sinh vien {1} la: {2}",
                    tenky,
                    sv.HoTen,
                    kqht.DiemTrungBinh
                );
            }
        }
    }

    public double DiemTrungBinhHocKyMax()
    {
        SinhVien sv = new SinhVien();
        double DiemTrungBinhHocKyMax = 0;
        foreach (KetQuaHocTap kqht in sv.DsKetQuaHocTap)
        {
            if (kqht.DiemTrungBinh >= DiemTrungBinhHocKyMax)
            {
                DiemTrungBinhHocKyMax = kqht.DiemTrungBinh;
            }
        }
        return DiemTrungBinhHocKyMax;
    }
}

public class SinhVienChinhQuy : SinhVien
{
    public SinhVienChinhQuy() { }
}

class SinhVienTaiChuc : SinhVien
{
    public string NoiLienKetDaoTao { get; set; }
}

class Khoa
{
    public string TenKhoa { get; set; }
    public List<SinhVien> DanhSachSinhVien { get; set; }

    public Khoa()
    {
        DanhSachSinhVien = new List<SinhVien>();
    }

    public List<SinhVien> GetSinhVienTaiChuc(string noiLienKet)
    {
        List<SinhVien> dsSinhVienTaiChuc = new List<SinhVien>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv is SinhVienTaiChuc && ((SinhVienTaiChuc)sv).NoiLienKetDaoTao == noiLienKet)
            {
                dsSinhVienTaiChuc.Add(sv);
            }
        }
        return dsSinhVienTaiChuc;
    }

    public List<SinhVien> GetSinhVienCoDiemTBLonHon8()
    {
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            List<KetQuaHocTap> dsKetQuaHocTap = sv.DsKetQuaHocTap;
            if (dsKetQuaHocTap.Count > 0 && dsKetQuaHocTap.Last().DiemTrungBinh >= 8.0)
            {
                dsSinhVien.Add(sv);
            }
        }
        return dsSinhVien;
    }

    public SinhVien GetSinhVienCoDiemTBCaoNhat()
    {
        SinhVien svMax = null;
        double diemMax = 0;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            double diemTBHKMax = sv.DiemTrungBinhHocKyMax();
            if (diemTBHKMax > diemMax)
            {
                diemMax = diemTBHKMax;
                svMax = sv;
            }
        }
        return svMax;
    }

    public void SapXepDanhSachSinhVienTheoLoaiVaNamVaoHoc()
    {
        DanhSachSinhVien.Sort(new SortByTypeAndYearDescending());

        Console.WriteLine("\nDanh sách sinh viên sau khi sắp xếp theo loại và năm vào học:");
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            Console.WriteLine(sv.ToString());
        }
    }

    public void DisplayStudentsByYearCount()
    {
        Dictionary<int, int> yearCount = new Dictionary<int, int>();

        foreach (var sinhvien in DanhSachSinhVien)
        {
            int year = sinhvien.NamVaoHoc;
            if (yearCount.ContainsKey(year))
            {
                yearCount[year]++;
            }
            else
            {
                yearCount[year] = 1;
            }
        }

        Console.WriteLine("Tong sinh vien theo nam:");
        foreach (var pair in yearCount)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
}

public class SortByTypeAndYearDescending : IComparer<SinhVien>
{
    public int Compare(SinhVien x, SinhVien y)
    {
        // So sánh loại sinh viên
        if (x is SinhVienChinhQuy && y is SinhVienTaiChuc)
            return -1;
        if (x is SinhVienTaiChuc && y is SinhVienChinhQuy)
            return 1;

        // So sánh năm vào học
        if (x.NamVaoHoc > y.NamVaoHoc)
            return -1;
        if (x.NamVaoHoc < y.NamVaoHoc)
            return 1;

        return 0;
    }
}

public class KetQuaHocTap
{
    public string TenHocKy { get; set; }
    public double DiemTrungBinh { get; set; }

    public KetQuaHocTap() { }

    public KetQuaHocTap(string tenHocky, double diemTB)
    {
        TenHocKy = tenHocky;
        DiemTrungBinh = diemTB;
    }

    public void ShowInfo()
    {
        Console.WriteLine("Ten hoc Ky:" + TenHocKy);
        Console.WriteLine("Diem trung binh: " + DiemTrungBinh);
        Console.WriteLine();
    }
}

public class InvalidNameException : Exception
{
    public InvalidNameException(string message)
        : base(message) { }
}

public class InValidDOBException : Exception
{
    public InValidDOBException(string message)
        : base(message) { }
}
