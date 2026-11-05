<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DatHang.aspx.cs" Inherits="baiTapLonBanh.DatHang" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/DatHang.css?v=1" rel="stylesheet" type="text/css" />
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
            <div class="container product-page dat-hang-page">

        <h1>Đặt hàng</h1>


        <div ID="pnlDatHang" runat="server">

            <div id="khungLoi" runat="server" visible="false" class="dat-hang-loi"></div>

            <div class="dat-hang-luoi">


                <div class="dat-hang-trai">


                    <section class="khoi-dat-hang">
                        <h2><span class="so-buoc">1</span> Thông tin người nhận</h2>

                        <div class="hai-cot">
                            <div class="o-truong">
                                <label class="nhan-o" for="txtHoTen">Họ và tên <span class="bat-buoc">*</span></label>
                                <input ID="txtHoTen" runat="server" class="o-nhap" maxlength="60" placeholder="Nguyễn Văn A"  type="text" ClientIDMode="Static" />
                            </div>
                            <div class="o-truong">
                                <label class="nhan-o" for="txtSoDienThoai">Số điện thoại <span class="bat-buoc">*</span></label>
                                <input ID="txtSoDienThoai" runat="server" class="o-nhap" maxlength="15" placeholder="0901 234 567"  type="text" ClientIDMode="Static" />
                            </div>
                        </div>

                        <div class="o-truong">
                            <label class="nhan-o" for="txtEmail">Email (không bắt buộc)</label>
                            <input ID="txtEmail" runat="server" class="o-nhap" maxlength="100" placeholder="email@example.com"  type="text" ClientIDMode="Static" />
                        </div>

                        <div class="o-truong">
                            <label class="nhan-o" for="txtDiaChi">Địa chỉ nhận hàng <span class="bat-buoc">*</span></label>
                            <input ID="txtDiaChi" runat="server" class="o-nhap" maxlength="200" placeholder="Số nhà, đường, phường/xã, quận/huyện, tỉnh/thành phố"  type="text" ClientIDMode="Static" />
                        </div>
                    </section>


                    <section class="khoi-dat-hang">
                        <h2><span class="so-buoc">2</span> Thời gian nhận hàng</h2>

                        <div class="hai-cot">
                            <div class="o-truong">
                                <label class="nhan-o" for="ngayNhan">Ngày nhận <span class="bat-buoc">*</span></label>
                                <input type="date" id="ngayNhan" runat="server" class="o-nhap" ClientIDMode="Static" />
                            </div>
                            <div class="o-truong">
                                <label class="nhan-o" for="ddlGio">Khung giờ <span class="bat-buoc">*</span></label>
                                <select ID="ddlGio" runat="server" class="o-nhap" ClientIDMode="Static">
                                    <option value="">-- Chọn khung giờ --</option>
                                    <option value="8">08:00 - 10:00</option>
                                    <option value="10">10:00 - 12:00</option>
                                    <option value="12">12:00 - 14:00</option>
                                    <option value="14">14:00 - 16:00</option>
                                    <option value="16">16:00 - 18:00</option>
                                    <option value="18">18:00 - 20:00</option>
                                </select>
                            </div>
                        </div>
                    </section>


                    <section class="khoi-dat-hang">
                        <h2><span class="so-buoc">3</span> Lưu ý về đơn hàng</h2>

                        <div class="o-truong">
                            <textarea ID="txtGhiChu" runat="server" Rows="4" maxlength="300" class="o-nhap" placeholder="Ví dụ: ghi chữ lên bánh, không lấy nến, gọi trước khi giao..." ></textarea>
                        </div>
                    </section>


                    <section class="khoi-dat-hang">
                        <h2><span class="so-buoc">4</span> Phương thức thanh toán</h2>

                        <div id="khuThanhToan" runat="server" class="danh-sach-thanh-toan"></div>
                    </section>

                </div>


                <aside class="dat-hang-phai">
                    <div class="tom-tat">
                        <h2>Đơn hàng của bạn</h2>

                        <div class="tt-danh-sach">
                            <div id="rptTomTat" runat="server"></div>
                        </div>


                        <div ID="pnlMaGiamGia" runat="server" class="khung-ma">
                            <label class="nhan-o" for="txtMaGiamGia">Mã giảm giá</label>
                            <div class="hang-ma">
                                <input ID="txtMaGiamGia" runat="server" class="o-nhap" maxlength="20" placeholder="Nhập mã giảm giá"  type="text" ClientIDMode="Static" />
                                <button ID="btnApDungMa" runat="server" class="nut-ap-dung" onserverclick="btnApDungMa_Click" >Áp dụng</button>
                            </div>
                            <p id="thongBaoMa" runat="server" visible="false"></p>
                        </div>


                        <div class="tt-hang">
                            <span>Tạm tính</span>
                            <span><span ID="litTamTinh" runat="server"></span></span>
                        </div>
                        <div class="tt-hang">
                            <span>Phí vận chuyển</span>
                            <span><span ID="litPhiShip" runat="server"></span></span>
                        </div>
                        <p id="ghiChuShip" runat="server" class="ghi-chu-ship"></p>
                        <div class="tt-hang tt-giam">
                            <span>Giảm giá</span>
                            <span><span ID="litGiamGia" runat="server"></span></span>
                        </div>
                        <div class="tt-hang tt-tong">
                            <span>Tổng cộng</span>
                            <span><span ID="litTongCong" runat="server"></span></span>
                        </div>

                        <button type="submit" ID="btnXacNhanDatHang" runat="server" class="nut-hong nut-day" onserverclick="btnXacNhanDatHang_Click">
                            <i class="fa-solid fa-circle-check"></i> Xác nhận đặt hàng
                        </button>

                        <a href="GioHang.aspx" class="quay-lai-gio">
                            <i class="fa-solid fa-arrow-left"></i> Quay lại giỏ hàng
                        </a>
                    </div>
                </aside>

            </div>
        </div>


        <div ID="pnlThanhCong" runat="server" Visible="false" class="dat-hang-thanh-cong">
            <div class="tc-icon"><i class="fa-solid fa-circle-check"></i></div>
            <h2>Đặt hàng thành công!</h2>
            <p class="tc-loi-cam-on">
                Cảm ơn bạn đã tin tưởng SweetCake. Mã đơn hàng của bạn là
                <strong><span ID="litMaDon" runat="server"></span></strong>
            </p>

            <dl class="tc-chi-tiet">
                <div><dt>Người nhận</dt><dd><span ID="litNguoiNhan" runat="server"></span></dd></div>
                <div><dt>Địa chỉ</dt><dd><span ID="litDiaChi" runat="server"></span></dd></div>
                <div><dt>Thời gian nhận</dt><dd><span ID="litThoiGian" runat="server"></span></dd></div>
                <div><dt>Thanh toán</dt><dd><span ID="litThanhToan" runat="server"></span></dd></div>
                <div class="tc-tong"><dt>Tổng thanh toán</dt><dd><span ID="litTongThanhToan" runat="server"></span></dd></div>
            </dl>

            <a href="SanPham.aspx" class="nut-hong">
                <i class="fa-solid fa-cake-candles"></i> Tiếp tục mua sắm
            </a>
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
