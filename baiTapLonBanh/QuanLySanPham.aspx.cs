using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class QuanLySanPham : SweetCakePage
    {
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
                string maBanh = Request.Form["xoaSanPham"];
                if (!string.IsNullOrWhiteSpace(maBanh)) XoaSanPham(maBanh);
            }
            else
            {
                if (Request.QueryString["them"] == "thanhcong")
                {
                    lblThongBao.InnerText = "Thêm sản phẩm thành công!";
                    lblThongBao.Attributes["class"] = "admin-message thanh-cong";
                }
                else if (Request.QueryString["sua"] == "thanhcong")
                {
                    lblThongBao.InnerText = "Cập nhật sản phẩm thành công!";
                    lblThongBao.Attributes["class"] = "admin-message thanh-cong";
                }
            }

            // Giá trị trong ô tìm kiếm được giữ lại sau khi gửi form hoặc xóa sản phẩm.
            HienThiSanPham((txtTimSanPham.Value ?? "").Trim());
        }

        private void HienThiSanPham(string tuKhoa)
        {
            List<SanPhamBanh> dsBanh = new List<SanPhamBanh>();
            Application.Lock();
            try
            {
                List<SanPhamBanh> danhSachGoc = Application["DanhSachSanPham"] as List<SanPhamBanh>;
                if (danhSachGoc != null) dsBanh = new List<SanPhamBanh>(danhSachGoc);
            }
            finally { Application.UnLock(); }

            // Lọc bản sao danh sách theo tên bánh hoặc loại bánh, không thay đổi dữ liệu gốc.
            List<SanPhamBanh> dsBanhLoc = new List<SanPhamBanh>();
            foreach (SanPhamBanh banh in dsBanh)
            {
                bool phuHop = string.IsNullOrWhiteSpace(tuKhoa) ||
                    (banh.tenBanh ?? "").IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    (banh.loaiBanh ?? "").IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0;

                if (phuHop) dsBanhLoc.Add(banh);
            }

            soLuongSanPham.InnerText = dsBanhLoc.Count + " sản phẩm";
            pnlKhongCoBanh.Visible = dsBanhLoc.Count == 0;
            gvSanPham.Visible = dsBanhLoc.Count > 0;

            if (dsBanhLoc.Count == 0)
            {
                pnlKhongCoBanh.InnerHtml = dsBanh.Count == 0
                    ? "<p>Hiện chưa có sản phẩm nào.</p>"
                    : "<p>Không tìm thấy sản phẩm phù hợp với từ khóa <strong>" + HttpUtility.HtmlEncode(tuKhoa) + "</strong>.</p>";
                gvSanPham.InnerHtml = "";
            }
            else
            {
                gvSanPham.InnerHtml = TaoBangSanPham(dsBanhLoc);
            }
        }

        private string TaoBangSanPham(List<SanPhamBanh> dsBanh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='admin-order-table'><thead><tr>")
              .Append("<th>Mã bánh</th><th>Ảnh</th><th>Tên bánh</th><th>Loại bánh</th><th>Giá</th><th>Ngày tạo</th><th>Thao tác</th>")
              .Append("</tr></thead><tbody>");

            foreach (SanPhamBanh banh in dsBanh)
            {
                sb.Append("<tr><td>").Append(HttpUtility.HtmlEncode(banh.maBanh)).Append("</td><td><img class='anh-san-pham-admin' src='")
                  .Append(ResolveUrl("~/" + (banh.anhBanh ?? ""))).Append("' alt='").Append(HttpUtility.HtmlAttributeEncode(banh.tenBanh)).Append("' /></td>")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(banh.tenBanh)).Append("</td><td>").Append(HttpUtility.HtmlEncode(banh.loaiBanh)).Append("</td>")
                  .Append("<td>").Append(banh.giaBanh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append(" đ</td><td>")
                  .Append(banh.ngayTao.ToString("dd/MM/yyyy")).Append("</td><td>")
                  .Append("<a class='admin-detail-link' href='").Append(ResolveUrl("~/SuaSanPham.aspx?id=" + HttpUtility.UrlEncode(banh.maBanh))).Append("'>Sửa</a>")
                  .Append(" <button type='submit' class='admin-delete-btn' name='xoaSanPham' value='").Append(HttpUtility.HtmlAttributeEncode(banh.maBanh))
                  .Append("' onclick=\"return confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?');\">Xóa</button></td></tr>");
            }
            sb.Append("</tbody></table>");
            return sb.ToString();
        }

        private void XoaSanPham(string maBanh)
        {
            NguoiDung taiKhoan = Session["TaiKhoan"] as NguoiDung;
            if (taiKhoan == null || taiKhoan.VaiTro != "Admin")
            {
                Response.Redirect(ResolveUrl("~/DangNhap.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (string.IsNullOrWhiteSpace(maBanh))
            {
                lblThongBao.InnerText = "Mã sản phẩm không hợp lệ.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
                return;
            }

            bool timThay = false;
            bool daDuocDat = false;
            bool daXoa = false;

            Application.Lock();
            try
            {
                List<SanPhamBanh> dsBanh = Application["DanhSachSanPham"] as List<SanPhamBanh>;
                List<DonHang> dsDonHang = Application["DanhSachDonHang"] as List<DonHang>;
                if (dsBanh != null)
                {
                    SanPhamBanh banhCanXoa = null;
                    foreach (SanPhamBanh banh in dsBanh)
                    {
                        if (banh.maBanh == maBanh) { banhCanXoa = banh; break; }
                    }
                    if (banhCanXoa != null)
                    {
                        timThay = true;
                        if (dsDonHang != null)
                        {
                            foreach (DonHang don in dsDonHang)
                            {
                                if (don.Dong != null)
                                {
                                    foreach (ChiTietDon chiTiet in don.Dong)
                                    {
                                        string maBanhTrongDon;
                                        string maSize;
                                        GioHangKey.Tach(chiTiet.maBanh ?? "", out maBanhTrongDon, out maSize);
                                        if (maBanhTrongDon == maBanh) { daDuocDat = true; break; }
                                    }
                                }
                                if (daDuocDat) break;
                            }
                        }
                        if (!daDuocDat)
                        {
                            dsBanh.Remove(banhCanXoa);
                            Application["DanhSachSanPham"] = dsBanh;
                            daXoa = true;
                        }
                    }
                }
            }
            finally { Application.UnLock(); }

            if (daXoa)
            {
                lblThongBao.InnerText = "Xóa sản phẩm thành công!";
                lblThongBao.Attributes["class"] = "admin-message thanh-cong";
            }
            else if (daDuocDat)
            {
                lblThongBao.InnerText = "Không thể xóa sản phẩm vì sản phẩm đã xuất hiện trong lịch sử đơn hàng.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
            }
            else if (!timThay)
            {
                lblThongBao.InnerText = "Không tìm thấy sản phẩm cần xóa.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
            }
        }
    }
}
