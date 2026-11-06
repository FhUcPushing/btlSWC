/* JavaScript riêng cho trang Quản lý thành viên - SweetCake */
(function () {
    "use strict";

    document.addEventListener("DOMContentLoaded", function () {
        var form = document.getElementById("form1");
        var oTimKiem = document.getElementById("txtTimThanhVien");
        var vungDanhSach = document.getElementById("divDanhSachNguoiDung");

        // 1. Tìm kiếm trực tiếp trên bảng khi người quản trị nhập từ khóa.
        // Server vẫn giữ chức năng lọc khi nhấn nút Tìm kiếm hoặc gửi form.
        if (oTimKiem && vungDanhSach) {
            var bang = vungDanhSach.querySelector(".admin-member-table");

            if (bang) {
                var cacDong = Array.prototype.slice.call(
                    bang.querySelectorAll("tbody tr")
                );

                var bangThongBao = document.createElement("p");
                bangThongBao.className = "admin-search-live-status";
                bangThongBao.setAttribute("role", "status");
                bangThongBao.setAttribute("aria-live", "polite");
                var khungTimKiem = oTimKiem.closest(".admin-search-panel");
                if (khungTimKiem) {
                    khungTimKiem.appendChild(bangThongBao);
                }

                function chuanHoaChuoi(giaTri) {
                    return (giaTri || "")
                        .toString()
                        .normalize("NFD")
                        .replace(/[\u0300-\u036f]/g, "")
                        .replace(/[đĐ]/g, "d")
                        .toLocaleLowerCase("vi")
                        .trim();
                }

                function locThanhVien() {
                    var tuKhoa = chuanHoaChuoi(oTimKiem.value);
                    var soDongHienThi = 0;

                    cacDong.forEach(function (dong) {
                        // Cột đầu tiên của bảng là Họ và tên.
                        var hoTen = dong.cells.length > 0
                            ? dong.cells[0].textContent
                            : "";
                        var coPhuHop = chuanHoaChuoi(hoTen).indexOf(tuKhoa) !== -1;

                        dong.hidden = !coPhuHop;
                        if (coPhuHop) {
                            soDongHienThi++;
                        }
                    });

                    if (tuKhoa === "") {
                        bangThongBao.textContent = "Đang hiển thị toàn bộ " +
                            cacDong.length + " thành viên trong danh sách hiện tại.";
                    } else if (soDongHienThi === 0) {
                        bangThongBao.textContent = "Không tìm thấy thành viên phù hợp trong danh sách hiện tại.";
                    } else {
                        bangThongBao.textContent = "Tìm thấy " + soDongHienThi +
                            " / " + cacDong.length + " thành viên trong danh sách hiện tại.";
                    }
                }

                oTimKiem.addEventListener("input", locThanhVien);
                locThanhVien();
            }
        }

        // 2. Xác nhận trước khi xóa. Dùng event delegation vì các nút được C# tạo động.
        document.addEventListener("click", function (suKien) {
            var nutXoa = suKien.target.closest("button[data-confirm-delete='true']");
            if (!nutXoa) {
                return;
            }

            var dong = nutXoa.closest("tr");
            var tenThanhVien = "thành viên này";
            if (dong && dong.cells.length > 0) {
                tenThanhVien = dong.cells[0].textContent.trim() || tenThanhVien;
            }

            var dongY = window.confirm(
                "Bạn có chắc chắn muốn xóa tài khoản của " + tenThanhVien +
                " không? Lịch sử đơn hàng cũ sẽ được giữ lại."
            );

            if (!dongY) {
                suKien.preventDefault();
                suKien.stopPropagation();
            }
        });

        // 3. Kiểm tra form sửa thành viên.
        // Thông báo được ghi vào các span ngay bên dưới ô nhập, giống trang Đăng ký/Đăng nhập.
        // C# vẫn kiểm tra lại dữ liệu khi nhận form.
        if (form) {
            var hoTen = document.getElementById("hoTenMoi");
            var tenDangNhap = document.getElementById("tenDangNhapMoi");
            var matKhau = document.getElementById("matKhauMoi");

            var loiHoTen = document.getElementById("loiHoTenMoi");
            var loiTenDangNhap = document.getElementById("loiTenDangNhapMoi");
            var loiMatKhau = document.getElementById("loiMatKhauMoi");

            if (hoTen && tenDangNhap && matKhau && loiHoTen && loiTenDangNhap && loiMatKhau) {
                function hienLoi(noiBaoLoi, noiDung) {
                    noiBaoLoi.textContent = noiDung;
                    return noiDung === "";
                }

                function kiemTraHoTen() {
                    var giaTri = hoTen.value.trim().replace(/\s+/g, " ");

                    if (giaTri.length < 2 || giaTri.length > 50 || /\d/.test(giaTri)) {
                        return hienLoi(
                            loiHoTen,
                            "Họ và tên phải từ 2 đến 50 ký tự và không chứa chữ số."
                        );
                    }

                    return hienLoi(loiHoTen, "");
                }

                function kiemTraTenDangNhap() {
                    var giaTri = tenDangNhap.value.trim();

                    if (!/^[A-Za-z0-9_]{4,20}$/.test(giaTri)) {
                        return hienLoi(
                            loiTenDangNhap,
                            "Tên đăng nhập phải có 4–20 ký tự, chỉ gồm chữ không dấu, số và dấu gạch dưới."
                        );
                    }

                    return hienLoi(loiTenDangNhap, "");
                }

                function kiemTraMatKhau() {
                    if (matKhau.value !== "" && matKhau.value.length < 8) {
                        return hienLoi(
                            loiMatKhau,
                            "Mật khẩu mới phải có ít nhất 8 ký tự."
                        );
                    }

                    return hienLoi(loiMatKhau, "");
                }

                hoTen.addEventListener("input", kiemTraHoTen);
                hoTen.addEventListener("blur", kiemTraHoTen);

                tenDangNhap.addEventListener("input", kiemTraTenDangNhap);
                tenDangNhap.addEventListener("blur", kiemTraTenDangNhap);

                matKhau.addEventListener("input", kiemTraMatKhau);
                matKhau.addEventListener("blur", kiemTraMatKhau);

                // Dùng kiểm tra riêng của mình để thông báo hiện đúng dưới từng ô nhập.
                form.noValidate = true;
                form.addEventListener("submit", function (suKien) {
                    var nutGui = suKien.submitter || document.activeElement;
                    var laNutLuu = nutGui && nutGui.name === "capNhatNguoiDung";
                    if (!laNutLuu) {
                        return;
                    }

                    var hoTenHopLe = kiemTraHoTen();
                    var tenDangNhapHopLe = kiemTraTenDangNhap();
                    var matKhauHopLe = kiemTraMatKhau();

                    if (!hoTenHopLe || !tenDangNhapHopLe || !matKhauHopLe) {
                        suKien.preventDefault();

                        if (!hoTenHopLe) {
                            hoTen.focus();
                        } else if (!tenDangNhapHopLe) {
                            tenDangNhap.focus();
                        } else {
                            matKhau.focus();
                        }
                    }
                });
            }
        }
    });
})();
