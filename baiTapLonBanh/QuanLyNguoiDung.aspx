<%@ Page Title="Quản lý thành viên"
    Language="C#"
    AutoEventWireup="true"
    ResponseEncoding="utf-8"
    CodeBehind="QuanLyNguoiDung.aspx.cs"
    Inherits="baiTapLonBanh.QuanLyNguoiDung" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Quản lý thành viên - SweetCake</title>
    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/QuanTri.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="site-header">
            <div class="nav-container">
                <div class="mobile-left-controls">
                    <button type="button" class="menu-toggle" aria-label="Mở menu" aria-expanded="false" onclick="toggleMobileMenu()">
                        <i class="fa-solid fa-bars"></i>
                    </button>
                </div>

                <a href="TrangChu.aspx" class="brand" aria-label="SweetCake - Trang chủ">
                    <span class="brand-icon"><i class="fa-solid fa-cake-candles"></i></span>
                    <span class="brand-name">SweetCake</span>
                </a>

                <nav class="main-nav" id="mainNav">
                    <div id="vungTaiKhoanNav" runat="server"></div>
                    <a href="TrangChu.aspx"><i class="fa-solid fa-house"></i><span>Trang chủ</span></a>
                    <a href="SanPham.aspx"><i class="fa-solid fa-cake-candles"></i><span>Sản phẩm</span></a>
                    <a href="GioiThieu.aspx"><i class="fa-solid fa-store"></i><span>Giới thiệu</span></a>
                    <a href="TinTuc.aspx"><i class="fa-regular fa-newspaper"></i><span>Tin tức</span></a>
                    <a href="TuVan.aspx"><i class="fa-solid fa-headset"></i><span>Tư vấn</span></a>
                </nav>

                <div class="header-right">
                    <div class="header-search" id="headerSearch">
                        <input type="search" id="txtTimKiem" placeholder="Tìm bánh..." autocomplete="off" enterkeyhint="search" aria-label="Tìm kiếm bánh" />
                        <button type="button" onclick="xuLyTimKiem()" aria-label="Tìm kiếm"><i class="fa-solid fa-magnifying-glass"></i></button>
                    </div>
                    <div class="header-account">
                        <a href="GioHang.aspx" class="cart-link" aria-label="Giỏ hàng" title="Giỏ hàng"><i class="fa-solid fa-bag-shopping"></i></a>
                        <div id="vungTaiKhoanHeader" runat="server" style="display: contents;"></div>
                    </div>
                </div>
            </div>
        </header>

        <main>
            <div class="container admin-orders admin-members">
                <div class="admin-members-heading">
                    <div>
                        <h1>Quản lý thành viên</h1>
                        <p>Xem thông tin, cập nhật tài khoản và xóa thành viên khách hàng.</p>
                    </div>
                    <a href="TaiKhoan.aspx" class="admin-detail-link"><i class="fa-solid fa-arrow-left"></i> Về tài khoản</a>
                </div>

                <div id="divThongBao" runat="server" class="admin-message"></div>
                <div id="divChiTietNguoiDung" runat="server" visible="false" class="admin-member-detail"></div>

                <section class="admin-member-list">
                    <div class="admin-member-list-heading">
                        <h2>Danh sách thành viên</h2>
                        <span id="soLuongThanhVien" runat="server" class="admin-member-count"></span>
                    </div>

                    <div class="admin-search-panel admin-member-search">
                        <label for="txtTimThanhVien">Tìm thành viên theo họ và tên</label>
                        <div class="admin-search-row">
                            <input type="text" id="txtTimThanhVien" runat="server"
                                   placeholder="Nhập họ và tên thành viên..."
                                   aria-label="Tìm thành viên theo họ và tên" />
                            <button type="submit" class="admin-btn">
                                <i class="fa-solid fa-magnifying-glass"></i> Tìm kiếm
                            </button>
                            <a href="QuanLyNguoiDung.aspx" class="admin-detail-link">Đặt lại</a>
                        </div>
                        <small class="admin-search-note">Có thể nhập một phần họ hoặc tên.</small>
                    </div>

                    <div id="divDanhSachNguoiDung" runat="server" class="admin-table-wrap"></div>
                </section>

                <div class="admin-actions">
                    <a href="QuanTri.aspx" class="admin-detail-link"><i class="fa-solid fa-clipboard-list"></i> Quản lý đơn hàng</a>
                    <a href="QuanLySanPham.aspx" class="admin-detail-link"><i class="fa-solid fa-cake-candles"></i> Quản lý sản phẩm</a>
                </div>
            </div>
        </main>

        <footer class="footer">
            <div class="container footer-ba-cot">
                <div class="fc fc-trai">
                    <h4>Thông tin liên hệ</h4>
                    <p>Hotline tư vấn: 0901 234 567</p>
                    <p>Địa chỉ: 123 Đường ABC, Bắc Ninh</p>
                    <p>Email: hello@sweetcake.vn</p>
                    <p>Giờ mở cửa: 8:00 – 21:00 mỗi ngày</p>
                </div>
                <div class="fc fc-giua">
                    <p class="footer-brand"><i class="fa-solid fa-cake-candles"></i> SweetCake</p>
                    <p class="footer-khau-hieu">Ngọt ngào trong từng chiếc bánh.</p>
                </div>
                <div class="fc fc-phai">
                    <h4>Liên kết</h4>
                    <div class="footer-mxh">
                        <a href="#" aria-label="Facebook"><i class="fa-brands fa-facebook"></i></a>
                        <a href="#" aria-label="Instagram"><i class="fa-brands fa-instagram"></i></a>
                        <a href="#" aria-label="TikTok"><i class="fa-brands fa-tiktok"></i></a>
                    </div>
                    <div class="footer-menu">
                        <a href="SanPham.aspx">Sản phẩm</a>
                        <a href="TinTuc.aspx">Tin tức</a>
                        <a href="TuVan.aspx">Tư vấn</a>
                    </div>
                </div>
            </div>
            <div class="footer-ban-quyen">© 2026 SweetCake. Bảo lưu mọi quyền.</div>
        </footer>
    </form>
    <script src="JS/Site.js"></script>
    <script src="JS/QuanLyNguoiDung.js"></script>
</body>
</html>
