<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="baiTapLonBanh.SanPham" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/SanPham.css"
      rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
<header class="site-header">
            <div class="nav-container">

                <div class="mobile-left-controls">
    <button type="button"
            class="menu-toggle"
            aria-label="Mở menu"
            aria-expanded="false"
            onclick="toggleMobileMenu()">
        <i class="fa-solid fa-bars"></i>
    </button>
</div>


                <a href="TrangChu.aspx"
                   class="brand"
                   aria-label="SweetCake - Trang chủ">
                    <span class="brand-icon">
                        <i class="fa-solid fa-cake-candles"></i>
                    </span>
                    <span class="brand-name">SweetCake</span>
                </a>


                <nav class="main-nav" id="mainNav">

                    <div id="vungTaiKhoanNav" runat="server"></div>

                    <a href="TrangChu.aspx">
                        <i class="fa-solid fa-house"></i>
                        <span>Trang chủ</span>
                    </a>
                    <a href="SanPham.aspx">
                        <i class="fa-solid fa-cake-candles"></i>
                        <span>Sản phẩm</span>
                    </a>
                    <a href="GioiThieu.aspx">
                        <i class="fa-solid fa-store"></i>
                        <span>Giới thiệu</span>
                    </a>
                    <a href="TinTuc.aspx">
                        <i class="fa-regular fa-newspaper"></i>
                        <span>Tin tức</span>
                    </a>
                    <a href="TuVan.aspx">
                        <i class="fa-solid fa-headset"></i>
                        <span>Tư vấn</span>
                    </a>

                </nav>


                <div class="header-right">
                    <div class="header-search" id="headerSearch">
    <input type="search"
           id="txtTimKiem"
           placeholder="Tìm bánh..."
           autocomplete="off"
           enterkeyhint="search"
           aria-label="Tìm kiếm bánh" />

    <button type="button"
            onclick="xuLyTimKiem()"
            aria-label="Tìm kiếm">
        <i class="fa-solid fa-magnifying-glass"></i>
    </button>
</div>
                    <div class="header-account">
                        <a href="GioHang.aspx"
                           class="cart-link"
                           aria-label="Giỏ hàng"
                           title="Giỏ hàng">
                            <i class="fa-solid fa-bag-shopping"></i>
                        </a>

                        <div id="vungTaiKhoanHeader" runat="server" style="display: contents;"></div>
                    </div>
                </div>
            </div>
        </header>

        <main>
            <div class="container product-page">
        
        <section id="bannerSanPham" runat="server" class="product-hero">
            <img src="product-banner.png" alt="ảnh banner sản phẩm"/>
            <span class="product-kicker">BỘ SƯU TẬP SWEETCAKE</span>
            <h1>Sản phẩm</h1>
            <p>Khám phá các loại bánh của SweetCake</p>
        </section>


        <section class="product-category-section" id="khuLoaiBanh">
            <ul class="category-list">
                <li id="tat_ca_loai_banh" runat="server">
                    <a id="lnkTatCa" runat="server">
                        <span class="category-icon"><i class="fa-solid fa-table-cells-large"></i></span>
                        <span class="category-name">Tất cả</span>
                    </a>
                </li>
                <li id="banh_kem" runat="server">
                    <a id="lnkBanhKem" runat="server">
                        <span class="category-icon"><i class="fa-solid fa-cake-candles"></i></span>
                        <span class="category-name">Bánh kem</span>
                    </a>
                </li>
                <li id="banh_tuoi" runat="server">
                    <a id="lnkBanhTuoi" runat="server">
                        <span class="category-icon"><i class="fa-solid fa-cookie-bite"></i></span>
                        <span class="category-name">Bánh tươi</span>
                    </a>
                </li>
                <li id="banh_mi" runat="server">
                    <a id="lnkBanhMi" runat="server">
                        <span class="category-icon"><i class="fa-solid fa-bread-slice"></i></span>
                        <span class="category-name">Bánh mì</span>
                    </a>
                </li>
            </ul>
        </section>

        <section class="product-list-section" id="khuDanhSach">

            <div class="list-head">
                <div class="list-head-title">
                    <h2>Danh sách bánh</h2>
                    <span class="count-badge"><span id="tongSoBanh" runat="server"></span> sản phẩm</span>
                </div>

                <section class="product-toolbar">
                    <label for="soLuongHienThi">Xem</label>
                    <select id="soLuongHienThi" runat="server" ClientIDMode="Static">
                        <option value="1">1</option>
                        <option value="4">4</option>
                        <option value="8">8</option>
                        <option value="12">12</option>
                        <option value="all">Tất cả</option>
                    </select>

                    <label for="sapXepSanPham">Sắp xếp theo:</label>
                    <select id="sapXepSanPham" runat="server" ClientIDMode="Static">
                        <option value="newest">Mới nhất</option>
                        <option value="oldest">Cũ nhất</option>
                    </select>
                </section>
            </div>

            <div id="khuTuKhoa" runat="server"></div>

            <p id="thongBaoKhongCoBanh" runat="server" visible="false" class="khong-co-banh">Không tìm thấy bánh phù hợp.</p>

            <div id="danhSachBanh" runat="server"
                 ClientIDMode="Static" class="danh-sach-banh">

                <div id="rptDanhSachBanh" runat="server"></div>

            </div>
        </section>


        <section class="product-pagination-section">
            <div id="phanTrang" runat="server" class="phan_trang"></div>
        </section>


    <div id="thongBaoGioHang"
         class="thong-bao-gio-hang an-thong-bao"
         role="status"
         aria-live="polite"
         data-url='ThemGioHang.ashx'></div>
    </div>

<button type="button"
        id="btnLenDauTrang"
        class="btn-len-dau"
        title="Lên đầu trang"
        aria-label="Lên đầu trang">
    <i class="fa-solid fa-arrow-up"></i>
</button>
    <script src="JS/SanPham.js"></script>
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
    <p class="footer-brand">
        <i class="fa-solid fa-cake-candles"></i> SweetCake
    </p>
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
</body>
</html>
