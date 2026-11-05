document.addEventListener('DOMContentLoaded', function () {
    var soLuong = document.getElementById('soLuongBanh');
    var tamTinh = document.getElementById('tamTinhGiaTri');
    var giaBanh = document.querySelector('.gia_banh');

    // Giá theo size đang chọn; bánh không có size thì lấy giá gốc
    function layGia() {
        var size = document.querySelector('input[name="size"]:checked');
        if (size) return parseInt(size.getAttribute('data-gia'), 10) || 0;
        return giaBanh ? parseInt(giaBanh.getAttribute('data-gia'), 10) || 0 : 0;
    }

    function dinhDang(n) {
        return n.toLocaleString('vi-VN') + 'đ';
    }

    function capNhat() {
        if (!soLuong || !tamTinh) return;
        var sl = Math.min(99, Math.max(1, parseInt(soLuong.value, 10) || 1));
        soLuong.value = sl;
        var gia = layGia();
        tamTinh.textContent = dinhDang(gia * sl);
        if (giaBanh) giaBanh.textContent = dinhDang(gia);
    }

    var giam = document.getElementById('giamSoLuong');
    var tang = document.getElementById('tangSoLuong');

    if (soLuong && giam) giam.addEventListener('click', function () {
        soLuong.value = (parseInt(soLuong.value, 10) || 1) - 1;
        capNhat();
    });
    if (soLuong && tang) tang.addEventListener('click', function () {
        soLuong.value = (parseInt(soLuong.value, 10) || 1) + 1;
        capNhat();
    });
    if (soLuong) soLuong.addEventListener('input', capNhat);

    document.querySelectorAll('input[name="size"]').forEach(function (r) {
        r.addEventListener('change', capNhat);
    });

    // Nút tim ở sản phẩm gợi ý (class .goi_y_tim trong .aspx; vẫn nhận .nut_yeu_thich nếu cậu dùng tên cũ)
    document.querySelectorAll('.goi_y_tim, .nut_yeu_thich').forEach(function (b) {
        b.addEventListener('click', function () {
            b.classList.toggle('da_thich');
        });
    });
    // Thông báo thêm giỏ hàng: tự ẩn sau 2 giây (giống trang chủ)
    document.querySelectorAll('.tu-an').forEach(function (t) {
        setTimeout(function () {
            t.classList.add('an-thong-bao');
        }, 2000);
    });
    capNhat();
});