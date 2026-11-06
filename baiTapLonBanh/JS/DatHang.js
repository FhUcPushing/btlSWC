document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("form1");
    var hoTen = document.getElementById("txtHoTen");
    var soDienThoai = document.getElementById("txtSoDienThoai");
    var email = document.getElementById("txtEmail");
    var diaChi = document.getElementById("txtDiaChi");
    var ngayNhan = document.getElementById("ngayNhan");
    var khungGio = document.getElementById("ddlGio");
    var cacPhuongThuc = document.querySelectorAll('input[name="thanhToan"]');

    var loiHoTen = document.getElementById("loiHoTen");
    var loiSoDienThoai = document.getElementById("loiSoDienThoai");
    var loiEmail = document.getElementById("loiEmail");
    var loiDiaChi = document.getElementById("loiDiaChi");
    var loiNgayNhan = document.getElementById("loiNgayNhan");
    var loiKhungGio = document.getElementById("loiKhungGio");
    var loiThanhToan = document.getElementById("loiThanhToan");

    if (!form || !hoTen || !soDienThoai || !email || !diaChi ||
        !ngayNhan || !khungGio || !loiHoTen || !loiSoDienThoai ||
        !loiEmail || !loiDiaChi || !loiNgayNhan || !loiKhungGio ||
        !loiThanhToan) {
        return;
    }

    function hienLoi(noiBaoLoi, noiDung) {
        noiBaoLoi.textContent = noiDung;
        return noiDung === "";
    }

    function kiemTraHoTen() {
        var giaTri = hoTen.value.trim();
        if (giaTri.length < 2 || giaTri.length > 60) {
            return hienLoi(loiHoTen, "Họ và tên phải có từ 2 đến 60 ký tự.");
        }
        return hienLoi(loiHoTen, "");
    }

    function kiemTraSoDienThoai() {
        var giaTri = soDienThoai.value.trim().replace(/[\s.\-]/g, "");
        if (!/^0\d{9}$/.test(giaTri)) {
            return hienLoi(loiSoDienThoai,
                "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.");
        }
        return hienLoi(loiSoDienThoai, "");
    }

    function kiemTraEmail() {
        var giaTri = email.value.trim();
        var mauEmail = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
        if (giaTri.length > 100 || (giaTri !== "" && !mauEmail.test(giaTri))) {
            return hienLoi(loiEmail, "Email chưa đúng định dạng.");
        }
        return hienLoi(loiEmail, "");
    }

    function kiemTraDiaChi() {
        var giaTri = diaChi.value.trim();
        if (giaTri.length < 8 || giaTri.length > 200) {
            return hienLoi(loiDiaChi, "Địa chỉ phải có từ 8 đến 200 ký tự.");
        }
        return hienLoi(loiDiaChi, "");
    }

    function layNgayHomNay() {
        var homNay = new Date();
        var thang = "0" + (homNay.getMonth() + 1);
        var ngay = "0" + homNay.getDate();
        thang = thang.slice(-2);
        ngay = ngay.slice(-2);
        return homNay.getFullYear() + "-" + thang + "-" + ngay;
    }

    function kiemTraNgayNhan() {
        var giaTri = ngayNhan.value;
        if (giaTri === "") {
            return hienLoi(loiNgayNhan, "Vui lòng chọn ngày nhận hàng.");
        }
        if (giaTri < layNgayHomNay()) {
            return hienLoi(loiNgayNhan, "Ngày nhận hàng không được ở trong quá khứ.");
        }
        return hienLoi(loiNgayNhan, "");
    }

    function kiemTraKhungGio() {
        var giaTri = khungGio.value;
        var cacGioHopLe = ["8", "10", "12", "14", "16", "18"];
        if (giaTri === "" || cacGioHopLe.indexOf(giaTri) === -1) {
            return hienLoi(loiKhungGio, "Vui lòng chọn khung giờ nhận hàng.");
        }

        if (ngayNhan.value === layNgayHomNay() && Number(giaTri) <= new Date().getHours()) {
            return hienLoi(loiKhungGio,
                "Khung giờ nhận hàng đã qua, vui lòng chọn khung giờ khác.");
        }
        return hienLoi(loiKhungGio, "");
    }

    function kiemTraThanhToan() {
        var daChon = false;
        for (var i = 0; i < cacPhuongThuc.length; i++) {
            if (cacPhuongThuc[i].checked) {
                daChon = true;
                break;
            }
        }
        if (!daChon) {
            return hienLoi(loiThanhToan, "Vui lòng chọn phương thức thanh toán.");
        }
        return hienLoi(loiThanhToan, "");
    }

    hoTen.addEventListener("input", kiemTraHoTen);
    hoTen.addEventListener("blur", kiemTraHoTen);
    soDienThoai.addEventListener("input", kiemTraSoDienThoai);
    soDienThoai.addEventListener("blur", kiemTraSoDienThoai);
    email.addEventListener("input", kiemTraEmail);
    email.addEventListener("blur", kiemTraEmail);
    diaChi.addEventListener("input", kiemTraDiaChi);
    diaChi.addEventListener("blur", kiemTraDiaChi);
    ngayNhan.addEventListener("change", function () {
        kiemTraNgayNhan();
        kiemTraKhungGio();
    });
    ngayNhan.addEventListener("blur", kiemTraNgayNhan);
    khungGio.addEventListener("change", kiemTraKhungGio);
    khungGio.addEventListener("blur", kiemTraKhungGio);

    for (var j = 0; j < cacPhuongThuc.length; j++) {
        cacPhuongThuc[j].addEventListener("change", kiemTraThanhToan);
    }

    // Tat kiem tra mac dinh cua trinh duyet de thong bao duoc hien ngay duoi tung truong.
    form.noValidate = true;

    form.addEventListener("submit", function (suKien) {
        var hopLe = true;
        var cacPhepKiemTra = [
            { ham: kiemTraHoTen, phanTu: hoTen },
            { ham: kiemTraSoDienThoai, phanTu: soDienThoai },
            { ham: kiemTraEmail, phanTu: email },
            { ham: kiemTraDiaChi, phanTu: diaChi },
            { ham: kiemTraNgayNhan, phanTu: ngayNhan },
            { ham: kiemTraKhungGio, phanTu: khungGio },
            { ham: kiemTraThanhToan, phanTu: cacPhuongThuc.length ? cacPhuongThuc[0] : null }
        ];

        var phanTuLoiDauTien = null;
        for (var k = 0; k < cacPhepKiemTra.length; k++) {
            if (!cacPhepKiemTra[k].ham()) {
                hopLe = false;
                if (!phanTuLoiDauTien) {
                    phanTuLoiDauTien = cacPhepKiemTra[k].phanTu;
                }
            }
        }

        if (!hopLe) {
            suKien.preventDefault();
            if (phanTuLoiDauTien) {
                phanTuLoiDauTien.focus();
            }
        }
    });
});
