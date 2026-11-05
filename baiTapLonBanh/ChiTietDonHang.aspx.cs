using System;
using System.Collections.Generic;
using System.Web;

namespace baiTapLonBanh
{
    public partial class ChiTietDonHang : SweetCakePage
    {
        protected string HtmlDongDonHangRows = "";

        private static string Tien(decimal so) { return so.ToString("N0") + "đ"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            NguoiDung nd = Session["TaiKhoan"] as NguoiDung;
            if (nd == null)
            {
                Response.Redirect("DangNhap.aspx");
                return;
            }
            bool laAdmin = nd.VaiTro == "Admin";
            string ma = Request.QueryString["ma"];
            DonHang don = null;

            List<DonHang> dsDon = Application["DanhSachDonHang"] as List<DonHang>;
            if (dsDon != null && !string.IsNullOrEmpty(ma))
            {
                Application.Lock();
                try
                {

                    foreach (DonHang d in dsDon)
                    {
                        if (d.MaDon == ma &&
                            (laAdmin || d.TenDangNhap == nd.TenDangNhap))
                        {
                            don = d;
                            break;
                        }
                    }
                    if (laAdmin)
                    {
                        lnkQuayLai.HRef = ResolveUrl("~/QuanTri.aspx");
                        litQuayLai.InnerHtml = "Quản lý đơn hàng";
                    }
                    else
                    {
                        lnkQuayLai.HRef =
                            ResolveUrl("~/TaiKhoan.aspx?tab=donhang");

                        litQuayLai.InnerHtml = "Đơn hàng của tôi";
                    }
                }
                finally { Application.UnLock(); }
            }

            if (don == null)
            {
                pnlChiTiet.Visible = false;
                pnlKhongTim.Visible = true;
                return;
            }

            litMaDon.InnerHtml = HttpUtility.HtmlEncode(don.MaDon);
            litTrangThai.InnerHtml = HttpUtility.HtmlEncode(don.TrangThai);
           
            btnHuyDon.Visible =
    !laAdmin &&
    don.TrangThai == "Chờ xác nhận";
            litNgayDat.InnerHtml = don.NgayDat.ToString("dd/MM/yyyy HH:mm");
            litNguoiNhan.InnerHtml = HttpUtility.HtmlEncode(don.NguoiNhan) + " - " + HttpUtility.HtmlEncode(don.SoDienThoai);
            litDiaChi.InnerHtml = HttpUtility.HtmlEncode(don.DiaChi);
            litThoiGian.InnerHtml = HttpUtility.HtmlEncode(don.ThoiGianNhan);
            litThanhToan.InnerHtml = HttpUtility.HtmlEncode(don.ThanhToan);
            litGhiChu.InnerHtml = string.IsNullOrWhiteSpace(don.GhiChu) ? "Không có" : HttpUtility.HtmlEncode(don.GhiChu);

            HtmlDongDonHangRows = HtmlRender.OrderDetailRows(don.Dong);
            tbodyChiTietDonHang.InnerHtml = HtmlDongDonHangRows;

            litTamTinh.InnerHtml = Tien(don.TamTinh);
            litPhiShip.InnerHtml = don.PhiShip == 0m ? "Miễn phí" : Tien(don.PhiShip);
            litGiamGia.InnerHtml = don.GiamGia > 0m ? "-" + Tien(don.GiamGia) : "0đ";
            litTongCong.InnerHtml = Tien(don.TongCong);
        }
        protected void btnHuyDon_Click(object sender, EventArgs e)
        {
           
            NguoiDung nd = Session["TaiKhoan"] as NguoiDung;

            if (nd == null)
            {
                Response.Redirect(
                    ResolveUrl("~/DangNhap.aspx"), false);

                Context.ApplicationInstance.CompleteRequest();
                return;
            }
           
            if (nd.VaiTro == "Admin")
            {
                btnHuyDon.Visible = false;

                lblThongBaoHuy.InnerText =
                    "Quản trị viên không sử dụng chức năng hủy đơn của khách hàng.";

                lblThongBaoHuy.Attributes["class"] =
                    "ct-thong-bao that-bai";

                return;
            }
            string ma = Request.QueryString["ma"];

            if (string.IsNullOrWhiteSpace(ma))
            {
                lblThongBaoHuy.InnerText =
                    "Không tìm thấy mã đơn hàng.";

                lblThongBaoHuy.Attributes["class"] =
                    "ct-thong-bao that-bai";

                return;
            }

            bool timThay = false;
            bool daHuy = false;
            bool saiTrangThai = false;

         
            Application.Lock();

            try
            {
                List<DonHang> dsDon =
                    Application["DanhSachDonHang"] as List<DonHang>;

                if (dsDon != null)
                {
                    foreach (DonHang don in dsDon)
                    {
                       
                        if (don.MaDon == ma &&
                            don.TenDangNhap == nd.TenDangNhap)
                        {
                            timThay = true;

                       
                            if (don.TrangThai == "Chờ xác nhận")
                            {
                                don.TrangThai = "Đã hủy";
                                daHuy = true;
                            }
                            else
                            {
                                saiTrangThai = true;
                            }

                            break;
                        }
                    }
                }
            }
            finally
            {
                Application.UnLock();
            }

            
            if (daHuy)
            {
                litTrangThai.InnerHtml = "Đã hủy";
                btnHuyDon.Visible = false;

                lblThongBaoHuy.InnerText =
                    "Đơn hàng đã được hủy thành công!";

                lblThongBaoHuy.Attributes["class"] =
                    "ct-thong-bao thanh-cong";
            }
            else if (timThay && saiTrangThai)
            {
                btnHuyDon.Visible = false;

                lblThongBaoHuy.InnerText =
                    "Không thể hủy vì đơn hàng không còn ở trạng thái Chờ xác nhận.";

                lblThongBaoHuy.Attributes["class"] =
                    "ct-thong-bao that-bai";
            }
            else
            {
                lblThongBaoHuy.InnerText =
                    "Không tìm thấy đơn hàng hoặc bạn không có quyền hủy đơn này.";

                lblThongBaoHuy.Attributes["class"] =
                    "ct-thong-bao that-bai";
            }
        }
    }
}