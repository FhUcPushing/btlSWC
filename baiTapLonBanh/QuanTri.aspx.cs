using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class QuanTri : SweetCakePage
    {
        private static readonly string[] CacTrangThai =
        {
            "Chờ xác nhận", "Đã xác nhận", "Đang chuẩn bị",
            "Đang giao hàng", "Hoàn thành", "Đã hủy"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            NguoiDung taiKhoan = Session["TaiKhoan"] as NguoiDung;
            if (taiKhoan == null)
            {
                Response.Redirect(ResolveUrl("~/DangNhap.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
            if (taiKhoan.VaiTro != "Admin")
            {
                Response.Redirect(ResolveUrl("~/TrangChu.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (IsPostBack)
            {
                string maDon = Request.Form["capNhatTrangThai"];
                if (!string.IsNullOrWhiteSpace(maDon))
                {
                    CapNhatTrangThai(maDon, Request.Form["trangThai_" + maDon]);
                }
            }

            HienThiDonHang();
        }

        private void HienThiDonHang()
        {
            List<DonHang> dsDon = new List<DonHang>();
            Application.Lock();
            try
            {
                List<DonHang> danhSachGoc = Application["DanhSachDonHang"] as List<DonHang>;
                if (danhSachGoc != null)
                {
                    foreach (DonHang don in danhSachGoc) dsDon.Add(don);
                }
            }
            finally { Application.UnLock(); }

            for (int i = 0; i < dsDon.Count - 1; i++)
            {
                for (int j = i + 1; j < dsDon.Count; j++)
                {
                    if (dsDon[i].NgayDat < dsDon[j].NgayDat)
                    {
                        DonHang tam = dsDon[i];
                        dsDon[i] = dsDon[j];
                        dsDon[j] = tam;
                    }
                }
            }

            pnlKhongCoDon.Visible = dsDon.Count == 0;
            gvDonHang.Visible = dsDon.Count > 0;
            gvDonHang.InnerHtml = TaoBangDonHang(dsDon);
        }

        private string TaoBangDonHang(List<DonHang> dsDon)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='admin-order-table'><thead><tr>")
              .Append("<th>Mã đơn</th><th>Ngày đặt</th><th>Tài khoản khách</th><th>Người nhận</th>")
              .Append("<th>Số điện thoại</th><th>Tổng tiền</th><th>Chi tiết</th><th>Trạng thái</th><th>Thao tác</th>")
              .Append("</tr></thead><tbody>");

            foreach (DonHang don in dsDon)
            {
                sb.Append("<tr").Append(don.TrangThai == "Đã hủy" ? " class='don-da-huy'" : "").Append(">")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(don.MaDon)).Append("</td>")
                  .Append("<td>").Append(don.NgayDat.ToString("dd/MM/yyyy HH:mm")).Append("</td>")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(don.TenDangNhap)).Append("</td>")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(don.NguoiNhan)).Append("</td>")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(don.SoDienThoai)).Append("</td>")
                  .Append("<td>").Append(don.TongCong.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append(" đ</td>")
                  .Append("<td><a href='").Append(ResolveUrl("~/ChiTietDonHang.aspx?ma=" + HttpUtility.UrlEncode(don.MaDon)))
                  .Append("' class='admin-detail-link'>Xem</a></td><td>")
                  .Append("<select class='admin-select' name='trangThai_").Append(HttpUtility.HtmlAttributeEncode(don.MaDon)).Append("'>");

                foreach (string trangThai in CacTrangThai)
                {
                    sb.Append("<option value='").Append(HttpUtility.HtmlAttributeEncode(trangThai)).Append("'")
                      .Append(trangThai == don.TrangThai ? " selected='selected'" : "")
                      .Append(">").Append(HttpUtility.HtmlEncode(trangThai)).Append("</option>");
                }

                sb.Append("</select></td><td><button type='submit' class='admin-btn' name='capNhatTrangThai' value='")
                  .Append(HttpUtility.HtmlAttributeEncode(don.MaDon)).Append("'>Cập nhật</button></td></tr>");
            }

            sb.Append("</tbody></table>");
            return sb.ToString();
        }

        private void CapNhatTrangThai(string maDon, string trangThaiMoi)
        {
            NguoiDung taiKhoan = Session["TaiKhoan"] as NguoiDung;
            if (taiKhoan == null || taiKhoan.VaiTro != "Admin")
            {
                Response.Redirect(ResolveUrl("~/DangNhap.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            bool hopLe = false;
            foreach (string trangThai in CacTrangThai)
            {
                if (trangThai == trangThaiMoi) { hopLe = true; break; }
            }
            if (!hopLe)
            {
                lblThongBao.InnerText = "Trạng thái đơn hàng không hợp lệ.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
                return;
            }

            bool daCapNhat = false;
            Application.Lock();
            try
            {
                List<DonHang> dsDon = Application["DanhSachDonHang"] as List<DonHang>;
                if (dsDon != null)
                {
                    foreach (DonHang don in dsDon)
                    {
                        if (don.MaDon == maDon)
                        {
                            don.TrangThai = trangThaiMoi;
                            daCapNhat = true;
                            break;
                        }
                    }
                }
            }
            finally { Application.UnLock(); }

            if (daCapNhat)
            {
                lblThongBao.InnerText = "Cập nhật trạng thái đơn hàng thành công!";
                lblThongBao.Attributes["class"] = "admin-message thanh-cong";
            }
            else
            {
                lblThongBao.InnerText = "Không tìm thấy đơn hàng cần cập nhật.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
            }
        }
    }
}
