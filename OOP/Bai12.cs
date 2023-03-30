using System;
using System.Collections.Generic;

class PhuongTienGiaoThong
{
    public string ID { get; set; }
    public string HangSanXuat { get; set; }
    public int NamSanXuat { get; set; }
    public double GiaBan { get; set; }
    public string MauXe { get; set; }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Hãng sản xuất: " + HangSanXuat);
        Console.WriteLine("Năm sản xuất: " + NamSanXuat);
        Console.WriteLine("Màu xe: " + MauXe);
    }
}

class OTo : PhuongTienGiaoThong
{
    public int SoChoNgoi { get; set; }
    public string KieuDongCo { get; set; }

    public override void HienThiThongTin()
    {
        HienThiThongTin();
        Console.WriteLine("Số chỗ ngồi: " + SoChoNgoi);
        Console.WriteLine("Kiểu động cơ: " + KieuDongCo);
        Console.WriteLine();
    }
}

class XeMay : PhuongTienGiaoThong
{
    public int CongXuat { get; set; }

    public XeMay(int congXuat)
    {
        CongXuat = congXuat;
    }

    public override void HienThiThongTin()
    {
        HienThiThongTin();
        Console.WriteLine("Công suất: {0} mã lực", CongXuat);
    }
}

class XeTai : PhuongTienGiaoThong
{
    public int TrongTai { get; set; }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine("Trọng tải: {0} tấn", TrongTai);
    }
}

class QLPTGT
{
    private readonly List<OTo> dsOto;
    private readonly List<XeMay> dsXeMay;
    private readonly List<XeTai> dsXeTai;

    public QLPTGT()
    {
        dsOto = new List<OTo>();
        dsXeMay = new List<XeMay>();
        dsXeTai = new List<XeTai>();
    }

    public void ThemOto(OTo oto)
    {
        dsOto.Add(oto);
    }

    public void ThemXeMay(XeMay xeMay)
    {
        dsXeMay.Add(xeMay);
    }

    public void ThemXeTai(XeTai xeTai)
    {
        dsXeTai.Add(xeTai);
    }

    public void XoaOto(string id)
    {
        bool timThay = false;
        for (int i = 0; i < dsOto.Count; i++)
        {
            if (dsOto[i].ID == id)
            {
                timThay = true;
                dsOto.RemoveAt(i);
                break;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Xe đã xoá!");
            Console.WriteLine();
        }
    }

    public void XoaXeMay(string id)
    {
        bool timThay = false;
        for (int i = 0; i < dsXeMay.Count; i++)
        {
            if (dsXeMay[i].ID == id)
            {
                timThay = true;
                dsXeMay.RemoveAt(i);
                break;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Xe đã xoá!");
            Console.WriteLine();
        }
    }

    public void XoaXeTai(string id)
    {
        bool timThay = false;
        for (int i = 0; i < dsXeTai.Count; i++)
        {
            if (dsXeTai[i].ID == id)
            {
                timThay = true;
                dsXeTai.RemoveAt(i);
                break;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Xe đã xoá!");
            Console.WriteLine();
        }
    }

    public void TimTheoHangSanXuat(string hangSanXuat)
    {
        bool timThay = false;
        Console.WriteLine("Danh sach cac phuong tien tim duoc:");
        foreach (OTo oto in dsOto)
        {
            if (oto.HangSanXuat.ToLower() == hangSanXuat.ToLower())
            {
                Console.WriteLine(oto.ToString());
                timThay = true;
            }
        }
        foreach (XeMay xeMay in dsXeMay)
        {
            if (xeMay.HangSanXuat.ToLower() == hangSanXuat.ToLower())
            {
                Console.WriteLine(xeMay.ToString());
                timThay = true;
            }
        }
        foreach (XeTai xeTai in dsXeTai)
        {
            if (xeTai.HangSanXuat.ToLower() == hangSanXuat.ToLower())
            {
                Console.WriteLine(xeTai.ToString());
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có");
        }
        Console.WriteLine();
    }

    public void TimTheoMauXe(string mauXe)
    {
        bool timThay = false;
        Console.WriteLine("Danh sách các phương tiện tìm được theo màu {0}:", mauXe);
        foreach (OTo oto in dsOto)
        {
            if (oto.MauXe.ToLower() == mauXe.ToLower())
            {
                Console.WriteLine(oto.ToString());
                timThay = true;
            }
        }
        foreach (XeMay xeMay in dsXeMay)
        {
            if (xeMay.MauXe.ToLower() == mauXe.ToLower())
            {
                Console.WriteLine(xeMay.ToString());
                timThay = true;
            }
        }
        foreach (XeTai xeTai in dsXeTai)
        {
            if (xeTai.MauXe.ToLower() == mauXe.ToLower())
            {
                Console.WriteLine(xeTai.ToString());
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có");
        }
        Console.WriteLine();
    }
}
