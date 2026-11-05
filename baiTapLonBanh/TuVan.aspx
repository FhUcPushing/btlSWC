<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuVan.aspx.cs" Inherits="baiTapLonBanh.TuVan" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/TuVan.css"
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
            <div class="huong-dan">


    <div class="huong-dan-tieu-de">
        <h1>HƯỚNG DẪN MUA BÁNH</h1>
        <p>
            SweetCake hướng dẫn bạn cách đặt bánh
            nhanh chóng và dễ dàng.
        </p>
    </div>


    <div class="buoc">
        <div class="so-buoc">01</div>

        <div class="noi-dung-buoc">
            <h2>Chọn sản phẩm</h2>
            <p>
                Truy cập mục <strong>Sản phẩm</strong> trên thanh menu
                để xem các loại bánh hiện có tại SweetCake.
            </p>
            <p>
                Bạn có thể lựa chọn sản phẩm phù hợp
                với nhu cầu và sở thích của mình.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/SP_TV.png" alt="Chọn sản phẩm bánh" />
        </div>
    </div>

    <div class="buoc">
        <div class="so-buoc">02</div>

        <div class="noi-dung-buoc">
            <h2>Xem thông tin sản phẩm</h2>
            <p>
                Nhấn vào sản phẩm bạn muốn mua để xem
                hình ảnh, tên bánh, mô tả và giá bán.
            </p>
            <p>
                Kiểm tra kỹ thông tin sản phẩm trước khi
                tiến hành đặt bánh.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/thongtinSP_TV.png" alt="Xem thông tin sản phẩm" />
        </div>
    </div>


    <div class="buoc">
        <div class="so-buoc">03</div>

        <div class="noi-dung-buoc">
            <h2>Thêm sản phẩm vào giỏ hàng</h2>
            <p>
                Chọn số lượng bánh muốn mua và nhấn
                <strong>Thêm vào giỏ hàng</strong>.
            </p>
            <p>
                Sản phẩm sẽ được lưu vào giỏ hàng
                để bạn kiểm tra trước khi đặt.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/themSP_TV.png" alt="Thêm sản phẩm vào giỏ hàng" />
        </div>
    </div>


    <div class="buoc">
        <div class="so-buoc">04</div>

        <div class="noi-dung-buoc">
            <h2>Kiểm tra giỏ hàng</h2>
            <p>
                Nhấn vào biểu tượng <strong>Giỏ hàng</strong>
                trên thanh menu để kiểm tra các sản phẩm
                đã lựa chọn.
            </p>
            <p>
                Bạn có thể thay đổi số lượng hoặc xóa
                sản phẩm không muốn mua.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/gio_TV.png" alt="Kiểm tra giỏ hàng" />
        </div>
    </div>


    <div class="buoc">
        <div class="so-buoc">05</div>

        <div class="noi-dung-buoc">
            <h2>Điền thông tin đặt hàng</h2>
            <p>
                Nhập đầy đủ các thông tin cần thiết như
                họ tên, số điện thoại, địa chỉ nhận bánh
                và phương thức thanh toán.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/thongtin_TV.png" alt="Điền thông tin đặt hàng" />
        </div>
    </div>


    <div class="buoc">
        <div class="so-buoc">06</div>

        <div class="noi-dung-buoc">
            <h2>Xác nhận đơn hàng</h2>
            <p>
                Kiểm tra lại toàn bộ thông tin đơn hàng
                và nhấn <strong>Đặt hàng</strong> để hoàn tất.
            </p>
            <p>
                Sau khi đặt hàng thành công, SweetCake
                sẽ tiếp nhận và xử lý đơn hàng của bạn.
            </p>
        </div>

        <div class="anh-buoc">
            <img src="image/TuVan/xacnhan_TV.png" alt="Xác nhận đơn hàng" />
        </div>
    </div>


    <div class="luu-y">
        <h2>LƯU Ý KHI ĐẶT BÁNH</h2>

        <p>
            • Vui lòng kiểm tra kỹ thông tin sản phẩm
            trước khi đặt hàng.
        </p>

        <p>
            • Kiểm tra chính xác số điện thoại và địa chỉ
            nhận bánh.
        </p>

        <p>
            • Đối với các mẫu bánh yêu cầu riêng,
            khách hàng nên liên hệ SweetCake để được tư vấn.
        </p>
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
