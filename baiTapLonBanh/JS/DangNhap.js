document.addEventListener("DOMContentLoaded", function () {
    var tenDangNhap = document.getElementById("username");
    var matKhau = document.getElementById("password");

    var loiTenDangNhap = document.getElementById("loiUsername");
    var loiMatKhau = document.getElementById("loiPassword");

    var form = document.getElementById("form1");

    if (!tenDangNhap || !matKhau ||
        !loiTenDangNhap || !loiMatKhau || !form) {
        return;
    }
    function hienLoi(oNhap, noiBaoLoi, noiDung) {
        noiBaoLoi.textContent = noiDung;

        if (noiDung !== "") {
            oNhap.classList.add("input-error");
        } else {
            oNhap.classList.remove("input-error");
        }

        return noiDung === "";
    }
    function kiemTraTenDangNhap() {
        if (tenDangNhap.value.trim() === "") {
            return hienLoi(
                tenDangNhap,
                loiTenDangNhap,
                "Vui lòng nhập tên đăng nhập."
            );
        }

        return hienLoi(tenDangNhap, loiTenDangNhap, "");
    }
    function kiemTraMatKhau() {
        if (matKhau.value === "") {
            return hienLoi(
                matKhau,
                loiMatKhau,
                "Vui lòng nhập mật khẩu."
            );
        }

        return hienLoi(matKhau, loiMatKhau, "");
    }
    tenDangNhap.addEventListener("input", kiemTraTenDangNhap);
    tenDangNhap.addEventListener("blur", kiemTraTenDangNhap);

    matKhau.addEventListener("input", kiemTraMatKhau);
    matKhau.addEventListener("blur", kiemTraMatKhau);
    form.noValidate = true;
    form.addEventListener("submit", function (e) {
        var tenHopLe = kiemTraTenDangNhap();
        var matKhauHopLe = kiemTraMatKhau();

        if (!tenHopLe || !matKhauHopLe) {
            e.preventDefault();

            if (!tenHopLe) {
                tenDangNhap.focus();
            } else {
                matKhau.focus();
            }
        }
    });
});