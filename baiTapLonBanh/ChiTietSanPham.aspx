<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="baiTapLonBanh.ChiTietSanPham" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/ChiTietSanPham.css" rel="stylesheet" type="text/css" />
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
            <div class="product-page">

        <section id="thongTinBanh" runat="server" visible="false" class="chi_tiet_san_pham">

            <div class="khung_anh_banh">
                <img id="anhBanh"
                     runat="server"
                     class="anh_banh_chinh"
                     src="image/SanPham/banh3_SP.jpg"
                     alt="Ảnh sản phẩm"
                     onerror="this.parentNode.classList.add('khong-anh');" />
            </div>

            <div class="noi_dung_banh">
                <p id="loaiBanh" runat="server" class="loai_banh"></p>

                <h1 id="tenBanh" runat="server" class="ten_banh_chi_tiet"></h1>

                <p id="giaBanh" runat="server" class="gia_banh"></p>

                <p id="moTa" runat="server" class="mo_ta_banh"></p>

                <ul id="thongTinChiTiet" runat="server" class="thong_tin_chi_tiet"></ul>


                <div id="khuVucSize" runat="server" visible="false" class="chon_size">
                    <p class="nhan_nho">Chọn size bánh</p>

                    <div class="danh_sach_size">
                        <div id="rptSize" runat="server"></div>
                    </div>

                    <p class="ghi_chu_tang">
                        <i class="fa-solid fa-utensils"></i> Đã tặng kèm dao, dĩa cắt bánh
                    </p>
                </div>

                <div class="chon_so_luong">
                    <label for="soLuongBanh">Số lượng:</label>

                    <button type="button" id="giamSoLuong" aria-label="Giảm số lượng">−</button>

                    <input type="number"
                           id="soLuongBanh"
                           runat="server"
                           ClientIDMode="Static"
                           value="1"
                           min="1"
                           max="99" />

                    <button type="button" id="tangSoLuong" aria-label="Tăng số lượng">+</button>
                </div>

                <p class="tam_tinh">Tạm tính: <strong id="tamTinhGiaTri"></strong></p>

                <div class="hanh_dong_mua_hang">
                    <button id="btnMuaNgay"
                            runat="server"
                            type="submit"
                            onserverclick="btnMuaNgay_ServerClick">
                        <i class="fa-solid fa-bag-shopping"></i> Mua ngay
                    </button>
                    <button id="btnThemVaoGio"
                            runat="server"
                            type="submit"
                            class="nut_phu"
                            onserverclick="btnThemVaoGio_ServerClick">
                        <i class="fa-solid fa-cart-plus"></i> Thêm vào giỏ hàng
                    </button>
                </div>

                <p id="thongBaoGioHang" runat="server" visible="false" class="thong_bao_gio_hang"></p>
            </div>

        </section>

        <p id="thongBaoLoi" runat="server" visible="false" class="thong_bao_loi">
            Không tìm thấy sản phẩm
        </p>

        <section id="khuVucGoiY" runat="server" class="goi-y-san-pham">

            <div class="goi-y-header">
                <h2>CÓ LẼ BẠN CŨNG SẼ THÍCH</h2>
                <a href="SanPham.aspx" class="nut-xem-them">Xem thêm <i class="fa-solid fa-arrow-right"></i>
                </a>
            </div>

            <p id="thongBaoGoiY" runat="server" visible="false" class="thong_bao_gio_hang"></p>

            <div class="danh-sach-goi-y">
                <div id="rptDanhSachGoiY" runat="server"></div>
            </div>

        </section>
    </div>
    <script src="JS/ChiTietSanPham.js?v=3"></script>
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
