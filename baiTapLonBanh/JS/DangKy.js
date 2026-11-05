document.addEventListener("DOMContentLoaded", function () {
    var hoTen = document.getElementById("fullname");
    var tenDangNhap = document.getElementById("username");
    var matKhau = document.getElementById("password");
    var xacNhanMatKhau = document.getElementById("confirm_password");

    var loiHoTen = document.getElementById("loiFullname");
    var loiTenDangNhap = document.getElementById("loiUsername");
    var loiMatKhau = document.getElementById("loiPassword");
    var loiXacNhan = document.getElementById("loiConfirmPassword");

    var form = document.querySelector("form");

    if (!hoTen || !tenDangNhap || !matKhau ||
        !xacNhanMatKhau || !loiHoTen ||
        !loiTenDangNhap || !loiMatKhau ||
        !loiXacNhan || !form) {
        return;
    }
    function hienLoi(oNhap, noiBaoLoi, noiDung) {
        noiBaoLoi.textContent = noiDung;

        if (noiDung !== "") {
            oNhap.classList.add("input-error");
            oNhap.setAttribute("aria-invalid", "true");
        } else {
            oNhap.classList.remove("input-error");
            oNhap.setAttribute("aria-invalid", "false");
        }

        return noiDung === "";
    }
    function kiemTraHoTen() {
        var giaTri = hoTen.value.trim();

        if (giaTri === "") {
            return hienLoi(hoTen, loiHoTen,
                "Vui lòng nhập họ và tên.");
        }

        if (giaTri.length < 2 || giaTri.length > 50) {
            return hienLoi(hoTen, loiHoTen,
                "Họ và tên phải có từ 2 đến 50 ký tự.");
        }

        return hienLoi(hoTen, loiHoTen, "");
    }
    function kiemTraTenDangNhap() {
        var giaTri = tenDangNhap.value.trim();
        var mau = /^[A-Za-z0-9_]{4,20}$/;

        if (giaTri === "") {
            return hienLoi(tenDangNhap, loiTenDangNhap,
                "Vui lòng nhập tên đăng nhập.");
        }

        if (!mau.test(giaTri)) {
            return hienLoi(tenDangNhap, loiTenDangNhap,
                "Tên đăng nhập phải có 4–20 ký tự, chỉ gồm chữ không dấu, số và dấu gạch dưới.");
        }

        return hienLoi(tenDangNhap, loiTenDangNhap, "");
    }
    function kiemTraMatKhau() {
        if (matKhau.value.length < 8) {
            return hienLoi(matKhau, loiMatKhau,
                "Mật khẩu phải có ít nhất 8 ký tự.");
        }

        return hienLoi(matKhau, loiMatKhau, "");
    }
    function kiemTraXacNhan() {
        if (xacNhanMatKhau.value === "") {
            return hienLoi(xacNhanMatKhau, loiXacNhan,
                "Vui lòng xác nhận mật khẩu.");
        }

        if (xacNhanMatKhau.value !== matKhau.value) {
            return hienLoi(xacNhanMatKhau, loiXacNhan,
                "Mật khẩu xác nhận không khớp.");
        }

        return hienLoi(xacNhanMatKhau, loiXacNhan, "");
    }
    hoTen.addEventListener("input", kiemTraHoTen);
    hoTen.addEventListener("blur", kiemTraHoTen);

    tenDangNhap.addEventListener("input", kiemTraTenDangNhap);
    tenDangNhap.addEventListener("blur", kiemTraTenDangNhap);

    matKhau.addEventListener("input", function () {
        kiemTraMatKhau();
        kiemTraXacNhan();
    });

    matKhau.addEventListener("blur", kiemTraMatKhau);

    xacNhanMatKhau.addEventListener("input", kiemTraXacNhan);
    xacNhanMatKhau.addEventListener("blur", kiemTraXacNhan);
    form.noValidate = true;

    form.addEventListener("submit", function (e) {
        var hopLe = true;

        if (!kiemTraHoTen()) hopLe = false;
        if (!kiemTraTenDangNhap()) hopLe = false;
        if (!kiemTraMatKhau()) hopLe = false;
        if (!kiemTraXacNhan()) hopLe = false;

        if (!hopLe) {
            e.preventDefault();

            var oLoiDauTien =
                form.querySelector('.input-error');

            if (oLoiDauTien) {
                oLoiDauTien.focus();
            }
        }
    });
});