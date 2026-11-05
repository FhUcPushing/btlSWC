using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace baiTapLonBanh
{
    // Trang co header tai khoan dung chung, nhung moi trang van co HTML rieng.
    public class SweetCakePage : Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            HienThiKhuVucTaiKhoan();
        }

        private void HienThiKhuVucTaiKhoan()
        {
            string tenNguoiDung = Session["TenHienThi"] as string;
            bool daDangNhap = !string.IsNullOrEmpty(tenNguoiDung);
            string tenAnToan = daDangNhap ? HttpUtility.HtmlEncode(tenNguoiDung) : "";
            string tenThuocTinh = daDangNhap ? HttpUtility.HtmlAttributeEncode(tenNguoiDung) : "";

            HtmlGenericControl nav = TimHtmlControl(this, "vungTaiKhoanNav");
            HtmlGenericControl header = TimHtmlControl(this, "vungTaiKhoanHeader");

            if (nav != null)
            {
                if (daDangNhap)
                {
                    nav.InnerHtml = "<div class='nav-account'>"
                        + "<a href='TaiKhoan.aspx' class='nav-greeting'><i class='fa-solid fa-circle-user'></i>"
                        + "<span class='ten'>Xin chào, " + tenAnToan + "</span></a>"
                        + "<a href='DangNhap.aspx?dangxuat=1' class='nav-logout' title='Đăng xuất' aria-label='Đăng xuất'>"
                        + "<i class='fa-solid fa-right-from-bracket'></i></a></div>";
                }
                else
                {
                    nav.InnerHtml = "<div class='nav-account'>"
                        + "<a href='DangNhap.aspx'><i class='fa-solid fa-user'></i> Đăng nhập</a>"
                        + "<span>/</span><a href='DangKy.aspx'><i class='fa-solid fa-user-plus'></i> Đăng ký</a></div>";
                }
            }

            if (header != null)
            {
                if (daDangNhap)
                {
                    header.InnerHtml = "<a href='TaiKhoan.aspx' class='user-greeting' title='Tài khoản của " + tenThuocTinh + "'>"
                        + "<i class='fa-solid fa-circle-user'></i><span class='ten'>Xin chào, " + tenAnToan + "</span></a>"
                        + "<a href='DangNhap.aspx?dangxuat=1' class='logout-link' title='Đăng xuất' aria-label='Đăng xuất'>"
                        + "<i class='fa-solid fa-right-from-bracket'></i></a>";
                }
                else
                {
                    header.InnerHtml = "<a href='DangNhap.aspx' class='login-link'><i class='fa-solid fa-user'></i> Đăng nhập</a>"
                        + "<span class='account-separator'>/</span>"
                        + "<a href='DangKy.aspx' class='register-link'><i class='fa-solid fa-user-plus'></i> Đăng ký</a>";
                }
            }
        }

        private HtmlGenericControl TimHtmlControl(Control goc, string id)
        {
            foreach (Control con in goc.Controls)
            {
                if (con.ID == id)
                {
                    return con as HtmlGenericControl;
                }

                HtmlGenericControl timThay = TimHtmlControl(con, id);
                if (timThay != null)
                {
                    return timThay;
                }
            }

            return null;
        }
    }
}
