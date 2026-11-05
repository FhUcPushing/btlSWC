using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    // Các phương thức tạo HTML thuần từ danh sách dữ liệu.
    // Dữ liệu động được encode trước khi đưa vào thuộc tính hoặc nội dung HTML.
    public static class HtmlRender
    {
        private static string E(object value)
        {
            return HttpUtility.HtmlEncode(Convert.ToString(value) ?? "");
        }

        private static string A(object value)
        {
            return HttpUtility.HtmlAttributeEncode(Convert.ToString(value) ?? "");
        }

        private static string U(string relativePath)
        {
            return VirtualPathUtility.ToAbsolute("~/" + (relativePath ?? "").TrimStart('/'));
        }

        private static string ProductDetailUrl(string ma)
        {
            return U("ChiTietSanPham.aspx") + "?id=" + HttpUtility.UrlEncode(ma ?? "");
        }

        public static string ProductCardsHome(IEnumerable<SanPhamBanh> products)
        {
            StringBuilder sb = new StringBuilder();
            if (products == null) return "";
            foreach (SanPhamBanh x in products)
            {
                sb.Append("<article class='product'>")
                  .Append("<div class='product-image'><a href='").Append(A(ProductDetailUrl(x.maBanh))).Append("'>")
                  .Append("<img src='").Append(A(U(x.anhBanh))).Append("' alt='").Append(A(x.tenBanh)).Append("' />")
                  .Append("</a><span class='product-heart'><i class='fa-solid fa-heart'></i></span></div>")
                  .Append("<div class='product-info'><h3><a class='ten-banh-link' href='").Append(A(ProductDetailUrl(x.maBanh))).Append("'>")
                  .Append(E(x.tenBanh)).Append("</a></h3><div class='product-bottom'><span class='price'>")
                  .Append(x.giaBanh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</span>")
                  .Append("<div class='product-actions'><a class='buy-now' href='")
                  .Append(A(U("DatHang.aspx") + "?maBanh=" + HttpUtility.UrlEncode(x.maBanh))).Append("'>Mua ngay</a>")
                  .Append("<button type='button' class='add-cart' data-ma-banh='").Append(A(x.maBanh))
                  .Append("' title='Thêm vào giỏ hàng' aria-label='Thêm vào giỏ hàng'><i class='fa-solid fa-cart-shopping'></i></button>")
                  .Append("</div></div></div></article>");
            }
            return sb.ToString();
        }

        public static string ProductCardsListing(IEnumerable<SanPhamBanh> products, Func<string, string> getClass)
        {
            StringBuilder sb = new StringBuilder();
            if (products == null) return "";
            foreach (SanPhamBanh x in products)
            {
                string detail = ProductDetailUrl(x.maBanh);
                sb.Append("<article class='the_san_pham ").Append(A(getClass == null ? "" : getClass(x.loaiBanh))).Append("'>")
                  .Append("<a class='lien-ket-anh' href='").Append(A(detail)).Append("'><img src='").Append(A(U(x.anhBanh)))
                  .Append("' alt='").Append(A(x.tenBanh)).Append("' onerror=\"this.closest('.the_san_pham').classList.add('khong-anh');\" /></a>")
                  .Append("<a class='lien-ket-ten' href='").Append(A(detail)).Append("'><span class='ten_banh'>").Append(E(x.tenBanh)).Append("</span></a>")
                  .Append("<p class='gia_banh'>").Append(x.giaBanh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</p>")
                  .Append("<div class='nhom-nut-mua'><a class='nut-mua-ngay' href='")
                  .Append(A(U("DatHang.aspx") + "?maBanh=" + HttpUtility.UrlEncode(x.maBanh))).Append("'><span>Mua ngay</span></a>")
                  .Append("<button type='button' class='nut-them-gio' data-ma-banh='").Append(A(x.maBanh))
                  .Append("' aria-label='Thêm vào giỏ hàng'><i class='fa-solid fa-cart-shopping'></i></button></div></article>");
            }
            return sb.ToString();
        }

        public static string SizeOptions(IEnumerable<SizeBanh> sizes, Func<object, string> formatPrice)
        {
            StringBuilder sb = new StringBuilder();
            if (sizes == null) return "";
            foreach (SizeBanh size in sizes)
            {
                sb.Append("<label class='size_item'><input type='radio' name='size' value='").Append(A(size.Ma))
                  .Append("' data-gia='").Append(size.Gia.ToString(CultureInfo.InvariantCulture)).Append("'")
                  .Append(size.DaChon ? " checked='checked'" : "").Append(" />")
                  .Append("<span class='size_noi_dung'><b>").Append(E(size.Ten)).Append("</b><small>")
                  .Append(E(size.SoNguoi)).Append("</small><em>").Append(E(formatPrice(size.Gia))).Append("</em></span></label>");
            }
            return sb.ToString();
        }

        public static string SuggestedProducts(IEnumerable<SanPhamBanh> products, Func<object, string> formatPrice)
        {
            StringBuilder sb = new StringBuilder();
            if (products == null) return "";
            foreach (SanPhamBanh x in products)
            {
                string detail = ProductDetailUrl(x.maBanh);
                sb.Append("<div class='the_san_pham'><a class='goi_y_anh' href='").Append(A(detail)).Append("'>")
                  .Append("<img src='").Append(A(U(x.anhBanh))).Append("' alt='").Append(A(x.tenBanh)).Append("' onerror=\"this.parentNode.classList.add('khong-anh');\" /></a>")
                  .Append("<button type='button' class='nut_yeu_thich' aria-label='Yêu thích'><i class='fa-solid fa-heart'></i></button>")
                  .Append("<div class='goi_y_noi_dung'><a class='goi_y_ten' href='").Append(A(detail)).Append("'>").Append(E(x.tenBanh)).Append("</a>")
                  .Append("<div class='goi_y_hang_duoi'><p class='goi_y_gia'>").Append(E(formatPrice(x.giaBanh))).Append("</p><div class='goi_y_hanh_dong'>")
                  .Append("<button type='submit' name='goiYAction' class='nut_mua_ngay' value='muaNgay|").Append(A(x.maBanh)).Append("'>Mua ngay</button>")
                  .Append("<button type='submit' name='goiYAction' class='nut_gio_hang' title='Thêm vào giỏ hàng' value='themGio|").Append(A(x.maBanh)).Append("'><i class='fa-solid fa-cart-shopping'></i></button>")
                  .Append("</div></div></div></div>");
            }
            return sb.ToString();
        }

        public static string CartRows(IEnumerable<SanPhamTrongGio> rows)
        {
            StringBuilder sb = new StringBuilder();
            if (rows == null) return "";
            foreach (SanPhamTrongGio x in rows)
            {
                sb.Append("<tr><td class='cot-san-pham'><div class='san-pham-o'><div class='anh-nho'><img src='")
                  .Append(A(U(x.anhBanh))).Append("' alt='").Append(A(x.tenBanh)).Append("' onerror=\"this.parentNode.classList.add('khong-anh');\" /></div>")
                  .Append("<span class='ten-banh-gio'>").Append(E(x.tenBanh)).Append("</span></div></td><td data-label='Đơn giá'>")
                  .Append(x.giaBanh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</td><td data-label='Số lượng'><div class='so-luong-gio'>")
                  .Append("<button type='submit' class='nut-sl' name='gioHangAction' value='giam|").Append(A(x.khoa)).Append("'>−</button>")
                  .Append("<span class='so-luong-so'>").Append(x.soLuong).Append("</span>")
                  .Append("<button type='submit' class='nut-sl' name='gioHangAction' value='tang|").Append(A(x.khoa)).Append("'>+</button></div></td>")
                  .Append("<td data-label='Thành tiền' class='cot-thanh-tien'>").Append(x.thanhTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</td>")
                  .Append("<td data-label='Thao tác'><button type='submit' class='nut-xoa' name='gioHangAction' value='xoa|").Append(A(x.khoa)).Append("'><i class='fa-solid fa-trash-can'></i> Xóa</button></td></tr>");
            }
            return sb.ToString();
        }

        public static string OrderSummaryRows(IEnumerable<DatHang.DongGioHang> rows)
        {
            StringBuilder sb = new StringBuilder();
            if (rows == null) return "";
            foreach (DatHang.DongGioHang x in rows)
            {
                sb.Append("<div class='tt-dong'><div class='tt-anh'><img src='").Append(A(U(x.anhBanh)))
                  .Append("' alt='").Append(A(x.tenBanh)).Append("' onerror=\"this.parentNode.classList.add('khong-anh');\" /></div>")
                  .Append("<div class='tt-ten'>").Append(E(x.tenBanh)).Append("<span>Số lượng: ").Append(x.soLuong).Append("</span></div>")
                  .Append("<div class='tt-gia'>").Append(x.thanhTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</div></div>");
            }
            return sb.ToString();
        }

        public static string AccountOrderRows(IEnumerable<TaiKhoan.DonHangTaiKhoanHienThi> rows)
        {
            StringBuilder sb = new StringBuilder();
            if (rows == null) return "";
            foreach (TaiKhoan.DonHangTaiKhoanHienThi x in rows)
            {
                sb.Append("<tr><td data-label='Mã đơn'><strong>").Append(E(x.MaDon)).Append("</strong></td>")
                  .Append("<td data-label='Ngày đặt'>").Append(E(x.NgayDat)).Append("</td><td data-label='Số bánh'>").Append(x.SoMon).Append("</td>")
                  .Append("<td data-label='Tổng tiền' class='tk-tien'>").Append(x.TongCong.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</td>")
                  .Append("<td data-label='Trạng thái'><span class='tk-trang-thai'>").Append(E(x.TrangThai)).Append("</span></td>")
                  .Append("<td class='tk-hanh-dong'><a class='tk-xem' href='ChiTietDonHang.aspx?ma=").Append(A(HttpUtility.UrlEncode(x.MaDon))).Append("'>Xem chi tiết</a></td></tr>");
            }
            return sb.ToString();
        }

        public static string OrderDetailRows(IEnumerable<ChiTietDon> rows)
        {
            StringBuilder sb = new StringBuilder();
            if (rows == null) return "";
            foreach (ChiTietDon x in rows)
            {
                sb.Append("<tr><td class='ct-o-ten'><div class='tk-sp'><span class='tk-anh'><img src='")
                  .Append(A(U(x.anhBanh))).Append("' alt='").Append(A(x.tenBanh)).Append("' onerror=\"this.parentNode.classList.add('khong-anh');\" /></span><strong>")
                  .Append(E(x.tenBanh)).Append("</strong></div></td><td data-label='Đơn giá'>")
                  .Append(x.donGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</td><td data-label='Số lượng'>")
                  .Append(x.soLuong).Append("</td><td data-label='Thành tiền' class='tk-tien'>")
                  .Append(x.thanhTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))).Append("đ</td></tr>");
            }
            return sb.ToString();
        }

        public static string RelatedNews(IEnumerable<BaiVietTinTuc> rows)
        {
            StringBuilder sb = new StringBuilder();
            if (rows == null) return "";
            foreach (BaiVietTinTuc x in rows)
            {
                string url = U("ChiTietTinTuc.aspx") + "?id=" + x.MaTinTuc.ToString(CultureInfo.InvariantCulture);
                sb.Append("<div class='the_bai_viet'><a class='bai_viet_anh' href='").Append(A(url)).Append("'><img src='")
                  .Append(A(U(x.AnhTinTuc))).Append("' alt='").Append(A(x.TieuDe)).Append("' onerror=\"this.parentNode.classList.add('khong-anh');\" /></a>")
                  .Append("<div class='bai_viet_noi_dung'><span class='bai_viet_loai'>").Append(E(x.LoaiTinTuc)).Append("</span>")
                  .Append("<a class='bai_viet_tieu_de' href='").Append(A(url)).Append("'>").Append(E(x.TieuDe)).Append("</a>")
                  .Append("<p class='bai_viet_mo_ta'>").Append(E(x.MoTa)).Append("</p><a class='nut_doc_them' href='").Append(A(url))
                  .Append("'>Đọc thêm <i class='fa-solid fa-arrow-right'></i></a></div></div>");
            }
            return sb.ToString();
        }
    }
}
