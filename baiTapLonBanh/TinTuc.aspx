<%@ Page Title="Tin tức"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TinTuc.aspx.cs"
    Inherits="baiTapLonBanh.TinTuc" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/TinTuc.css"
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
            <section class="news-banner">
        <div class="news-banner-content">
            <span class="news-subtitle">GÓC NHÀ SWEETCAKE</span>
            <h1>TIN TỨC &amp; SỰ KIỆN</h1>
            <p>
                Cùng SweetCake khám phá thế giới bánh ngọt,
                những câu chuyện thú vị và bí quyết làm bánh mỗi ngày.
            </p>
        </div>
    </section>

    <section class="news-page">

        <div class="news-heading">

            <span class="news-heading-line"></span>
        </div>


        <div class="news-grid">


            <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=1" class="news-image">
        <img src="image/TinTuc/banh1_TT.jpg"
             alt="Bánh kem sinh nhật" />
        <span class="news-category">BÍ QUYẾT</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 10/10/2026</span>
            <span><i class="fa-regular fa-clock"></i> 5 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=1">
                Bí quyết chọn bánh kem hoàn hảo cho ngày sinh nhật
            </a>
        </h3>

        <p>
            Một chiếc bánh kem đẹp không chỉ làm bữa tiệc thêm
            ý nghĩa mà còn thể hiện tình cảm dành cho người thân.
            Cùng khám phá cách chọn bánh phù hợp nhé!
        </p>

        <a href="ChiTietTinTuc.aspx?id=1" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>


            <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=2" class="news-image">
        <img src="image/TinTuc/banh11_TT.jpg"
             alt="Bánh ngọt trang trí đẹp" />
        <span class="news-category">KIẾN THỨC</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 08/10/2026</span>
            <span><i class="fa-regular fa-clock"></i> 4 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=2">
                Cách bảo quản bánh kem luôn tươi ngon tại nhà
            </a>
        </h3>

        <p>
            Bảo quản đúng cách giúp bánh giữ được hương vị,
            kết cấu mềm mịn và lớp kem hấp dẫn.
            Tìm hiểu những lưu ý quan trọng khi bảo quản bánh.
        </p>

        <a href="ChiTietTinTuc.aspx?id=2" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>


            <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=3" class="news-image">
        <img src="image/TinTuc/banh7_TT.jpg"
             alt="Cupcake nhiều màu sắc" />
        <span class="news-category">CẢM HỨNG</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 05/10/2026</span>
            <span><i class="fa-regular fa-clock"></i> 3 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=3">
                Cupcake nhỏ xinh – Món quà ngọt ngào cho mọi dịp
            </a>
        </h3>

        <p>
            Những chiếc cupcake xinh xắn với màu sắc đáng yêu
            sẽ là lựa chọn tuyệt vời cho tiệc sinh nhật,
            buổi hẹn hò hay những dịp đặc biệt.
        </p>

        <a href="ChiTietTinTuc.aspx?id=3" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>


           <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=4" class="news-image">
        <img src="image/TinTuc/banh9_TT.jpg"
             alt="Bánh chocolate" />
        <span class="news-category">BÍ QUYẾT</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 02/10/2026</span>
            <span><i class="fa-regular fa-clock"></i> 5 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=4">
                Chocolate và bánh ngọt: Sự kết hợp không thể bỏ lỡ
            </a>
        </h3>

        <p>
            Từ vị đắng nhẹ của chocolate đen đến vị ngọt
            béo của chocolate sữa, mỗi sự kết hợp đều
            mang lại một trải nghiệm riêng biệt.
        </p>

        <a href="ChiTietTinTuc.aspx?id=4" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>


           <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=5" class="news-image">
        <img src="image/TinTuc/banh3_TT.jpg"
             alt="Bánh ngọt trang trí" />
        <span class="news-category">SỰ KIỆN</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 28/09/2026</span>
            <span><i class="fa-regular fa-clock"></i> 4 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=5">
                Gợi ý những mẫu bánh ngọt dành tặng người thương
            </a>
        </h3>

        <p>
            Một chiếc bánh được lựa chọn cẩn thận sẽ giúp
            bạn gửi gắm lời yêu thương trong ngày kỷ niệm,
            ngày sinh nhật hoặc những dịp đáng nhớ.
        </p>

        <a href="ChiTietTinTuc.aspx?id=5" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>

            <article class="news-card">
    <a href="ChiTietTinTuc.aspx?id=6" class="news-image">
        <img src="image/TinTuc/banh8_TT.jpg"
             alt="Bánh mì mới nướng" />
        <span class="news-category">GÓC BẾP</span>
    </a>

    <div class="news-info">
        <div class="news-meta">
            <span><i class="fa-regular fa-calendar"></i> 25/09/2026</span>
            <span><i class="fa-regular fa-clock"></i> 6 phút đọc</span>
        </div>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=6">
                Khám phá những nguyên liệu tạo nên chiếc bánh thơm ngon
            </a>
        </h3>

        <p>
            Chất lượng nguyên liệu góp phần tạo nên hương vị
            đặc trưng của mỗi chiếc bánh. Cùng tìm hiểu
            những thành phần quen thuộc trong nghệ thuật làm bánh.
        </p>

        <a href="ChiTietTinTuc.aspx?id=6" class="news-read-more">
            Xem thêm <i class="fa-solid fa-arrow-right"></i>
        </a>
    </div>
</article>
        </div>

    </section>


    <section class="news-cta-wrap">
        <div class="news-cta">
            <div class="news-cta-icon">
                <i class="fa-solid fa-heart"></i>
            </div>

            <div class="news-cta-copy">
                <h2>Trao ngọt ngào, gửi yêu thương</h2>
                <p>
                    Khám phá bộ sưu tập bánh thơm ngon và tìm chiếc bánh
                    hoàn hảo cho những khoảnh khắc đặc biệt của bạn.
                </p>
            </div>

            <a href="SanPham.aspx" class="news-cta-button">
                Khám phá sản phẩm <i class="fa-solid fa-arrow-right"></i>
            </a>
        </div>
    </section>
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
