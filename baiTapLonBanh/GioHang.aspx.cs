using System;
using System.Collections.Generic;
using System.Web.UI;
namespace baiTapLonBanh
{
    public class SanPhamTrongGio
    {
        public string khoa { get; set; }
        public string tenBanh { get; set; }
        public string anhBanh { get; set; }
        public decimal giaBanh { get; set; }
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
    }
    public partial class GioHang : SweetCakePage
    {
        protected string HtmlGioHangRows = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                XuLyThaoTacGioHang();
            }
            HienThiGioHang();
            tbodyGioHang.InnerHtml = HtmlGioHangRows;
        }

        private void HienThiGioHang()
        {
          
            List<SanPhamBanh> danhSachSanPham =
                new List<SanPhamBanh>();

            Application.Lock();

            try
            {
                List<SanPhamBanh> ds =
                    Application["DanhSachSanPham"] as List<SanPhamBanh>;

                if (ds != null)
                {
                    foreach (SanPhamBanh banh in ds)
                    {
                        danhSachSanPham.Add(banh);
                    }
                }
            }
            finally
            {
                Application.UnLock();
            }

          
            Dictionary<string, int> gioHang =
                Session["GioHang"] as Dictionary<string, int>;

            if (danhSachSanPham.Count == 0 ||
                gioHang == null ||
                gioHang.Count == 0)
            {
                panelGioHang.Visible = false;
                thongBaoRong.Visible = true;
                return;
            }

           
            List<SanPhamTrongGio> sanPhamTrongGio =
                new List<SanPhamTrongGio>();

            decimal tongTien = 0;

            foreach (KeyValuePair<string, int> item in gioHang)
            {
                // Tách mã bánh và size
                string maBanh;
                string maSize;

                GioHangKey.Tach(
                    item.Key, out maBanh, out maSize);

              
                SanPhamBanh banhTimThay = null;

                foreach (SanPhamBanh banh in danhSachSanPham)
                {
                    if (banh.maBanh == maBanh)
                    {
                        banhTimThay = banh;
                        break;
                    }
                }

        
                if (banhTimThay == null)
                {
                    continue;
                }

                
                string tenBanh = banhTimThay.tenBanh;

                if (!string.IsNullOrEmpty(maSize))
                {
                    tenBanh += " (" + GioHangKey.TenSize(maSize) + ")";
                }

              
                decimal giaBanh =
                    GioHangKey.DonGia(banhTimThay, maSize);

                decimal thanhTien = giaBanh * item.Value;

          
                SanPhamTrongGio dong = new SanPhamTrongGio();

                dong.khoa = item.Key;
                dong.tenBanh = tenBanh;
                dong.anhBanh = banhTimThay.anhBanh;
                dong.giaBanh = giaBanh;
                dong.soLuong = item.Value;
                dong.thanhTien = thanhTien;

                sanPhamTrongGio.Add(dong);

              
                tongTien += thanhTien;
            }

         
            if (sanPhamTrongGio.Count == 0)
            {
                panelGioHang.Visible = false;
                thongBaoRong.Visible = true;
                return;
            }

         
            HtmlGioHangRows = HtmlRender.CartRows(sanPhamTrongGio);

       
            litTongTien.InnerHtml = tongTien.ToString("N0") + "đ";

            panelGioHang.Visible = true;
            thongBaoRong.Visible = false;
        }

        private void XuLyThaoTacGioHang()
        {
            string lenh = Request.Form["gioHangAction"];
            if (string.IsNullOrEmpty(lenh)) return;

            string[] tach = lenh.Split(new char[] { '|' }, 2);
            if (tach.Length != 2) return;

            string hanhDong = tach[0];
            string khoa = tach[1];
            Dictionary<string, int> gioHang = Session["GioHang"] as Dictionary<string, int>;
            if (gioHang == null || !gioHang.ContainsKey(khoa)) return;

            if (hanhDong == "tang")
            {
                gioHang[khoa]++;
            }
            else if (hanhDong == "giam")
            {
                if (gioHang[khoa] > 1) gioHang[khoa]--;
            }
            else if (hanhDong == "xoa")
            {
                gioHang.Remove(khoa);
            }

            Session["GioHang"] = gioHang;
        }
    }
}