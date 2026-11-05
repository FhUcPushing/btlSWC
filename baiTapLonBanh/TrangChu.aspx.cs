using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class TrangChu : SweetCakePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<SanPhamBanh> danhSach = Application["DanhSachSanPham"] as List<SanPhamBanh>;
                if (danhSach == null) danhSach = new List<SanPhamBanh>();
                List<SanPhamBanh> sanPhamNoiBat = new List<SanPhamBanh>();
                foreach (SanPhamBanh x in danhSach)
                {
                    if (sanPhamNoiBat.Count < 4 && (x.loaiBanh == "Bánh Mousse" || x.loaiBanh == "Bánh Kem" || x.loaiBanh == "Bánh Sinh Nhật"))
                    {
                        sanPhamNoiBat.Add(x);
                    }
                }
                rptSanPhamNoiBat.InnerHtml = HtmlRender.ProductCardsHome(sanPhamNoiBat);

                List<SanPhamBanh> danhSachBanhTuoi = new List<SanPhamBanh>();
                foreach (SanPhamBanh x in danhSach)
                {
                    if (danhSachBanhTuoi.Count < 4 && x.loaiBanh == "Bánh Tươi")
                    {
                        danhSachBanhTuoi.Add(x);
                    }
                }
                rptBanhTuoi.InnerHtml = HtmlRender.ProductCardsHome(danhSachBanhTuoi);
            }
        }

        
    }
}