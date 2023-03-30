using System;
using System.Collections.Generic;
using System.Text;

class CanBo
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

    public CanBo(string hoTen, int tuoi, string gioiTinh, string diaChi)
    {
        this.HoTen = hoTen;
        this.Tuoi = tuoi;
        this.GioiTinh = gioiTinh;
        this.DiaChi = diaChi;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Tuổi: {Tuoi}");
        Console.WriteLine($"Giới tính: {GioiTinh}");
        Console.WriteLine($"Địa chỉ: {DiaChi}");
    }
}

class CongNhan : CanBo
{
    private readonly int bac;

    public CongNhan(string hoTen, int tuoi, string gioiTinh, string diaChi, int bac)
        : base(hoTen, tuoi, gioiTinh, diaChi)
    {
        this.bac = bac;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Bậc: {bac}");
    }
}

class KySu : CanBo
{
    private readonly string nganhDaoTao;

    public KySu(string hoTen, int tuoi, string gioiTinh, string diaChi, string nganhDaoTao)
        : base(hoTen, tuoi, gioiTinh, diaChi)
    {
        this.nganhDaoTao = nganhDaoTao;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngành đào tạo: {nganhDaoTao}");
    }
}

class NhanVien : CanBo
{
    private readonly string congViec;

    public NhanVien(string hoTen, int tuoi, string gioiTinh, string diaChi, string congViec)
        : base(hoTen, tuoi, gioiTinh, diaChi)
    {
        this.congViec = congViec;
    }

    // Override phương thức HienThiThongTin() để hiển thị thêm thông tin riêng của nhân viên
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công việc: {congViec}");
    }
}

class QLCB
{
    private readonly List<CanBo> danhSachCanBo;

    public QLCB()
    {
        danhSachCanBo = new List<CanBo>();
    }

    public void ThemMoiCanBo(CanBo canBo)
    {
        danhSachCanBo.Add(canBo);
    }

    public void TimKiemTheoHoTen(string hoTen)
    {
        bool timThay = false;

        foreach (CanBo canBo in danhSachCanBo)
        {
            if (canBo.HoTen.ToLower().Contains(hoTen.ToLower()))
            {
                canBo.HienThiThongTin();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy cán bộ nào có họ tên như vậy.");
        }
    }

    public void HienThiDanhSachCanBo()
    {
        foreach (CanBo canBo in danhSachCanBo)
        {
            canBo.HienThiThongTin();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        QLCB qlcb = new QLCB();
        CanBo cn1 = new CongNhan("Nguyen Van A", 30, "Nam", "Ha Noi", 5);
        qlcb.ThemMoiCanBo(cn1);
        CanBo cn2 = new CongNhan("Tran Thi B", 25, "Nu", "Ho Chi Minh", 2);
        qlcb.ThemMoiCanBo(cn2);
        CanBo ks1 = new KySu("Le Van C", 35, "Nam", "Ha Noi", "Khoa Hoc May Tinh");
        qlcb.ThemMoiCanBo(ks1);
        CanBo nv1 = new NhanVien("Nguyen Thi D", 40, "Nữ", "Ha Noi", "Nhan Vien Van Phong");
        qlcb.ThemMoiCanBo(nv1);

        qlcb.TimKiemTheoHoTen("Nguyen Van A");

        Console.ReadLine();
    }
}
