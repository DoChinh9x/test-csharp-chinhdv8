using System;
using System.Collections.Generic;
using System.Text;

class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string QueQuan { get; set; }
    public string MaSoGV { get; set; }

    public Nguoi(string hoTen, int tuoi, string queQuan, string maSoGV)
    {
        HoTen = hoTen;
        Tuoi = tuoi;
        QueQuan = queQuan;
        MaSoGV = maSoGV;
    }
}

class CBGV
{
    public string MaSoGV { get; set; }
    public double LuongCung { get; set; }
    public double LuongThuong { get; set; }
    public double TienPhat { get; set; }
    public double LuongThucLinh { get; set; }

    public CBGV(string maSoGV, double luongCung, double luongThuong, double tienPhat)
    {
        MaSoGV = maSoGV;
        LuongCung = luongCung;
        LuongThuong = luongThuong;
        TienPhat = tienPhat;
        LuongThucLinh = luongCung + luongThuong - tienPhat;
    }
}

class KhoaCNTT
{
    private readonly List<CBGV> danhSachCBGV;

    public KhoaCNTT()
    {
        danhSachCBGV = new List<CBGV>();
    }

    public void ThemCBGV(CBGV cbgv)
    {
        danhSachCBGV.Add(cbgv);
    }

    public void XoaCBGV(string maSoGV)
    {
        for (int i = 0; i < danhSachCBGV.Count; i++)
        {
            if (danhSachCBGV[i].MaSoGV == maSoGV)
            {
                danhSachCBGV.RemoveAt(i);
                break;
            }
            else
            {
                Console.WriteLine("Giáo viên không có trong danh sách!");
            }
        }
    }

    public void TinhLuongThucLinh(string maSoGV)
    {
        for (int i = 0; i < danhSachCBGV.Count; i++)
        {
            if (danhSachCBGV[i].MaSoGV == maSoGV)
            {
                danhSachCBGV[i].LuongThucLinh =
                    danhSachCBGV[i].LuongCung
                    + danhSachCBGV[i].LuongThuong
                    - danhSachCBGV[i].TienPhat;
                Console.WriteLine(
                    "Lương thực lĩnh của giáo viên {0} là {1}",
                    danhSachCBGV[i].MaSoGV,
                    danhSachCBGV[i].LuongThucLinh
                );
                break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        KhoaCNTT khoaCNTT = new KhoaCNTT();

        CBGV cbgv1 = new CBGV("GV001", 10000000, 2000000, 500000);
        khoaCNTT.ThemCBGV(cbgv1);

        khoaCNTT.TinhLuongThucLinh("GV001");
        Console.ReadLine();
    }
}
