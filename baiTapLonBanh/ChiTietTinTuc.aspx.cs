
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class ChiTietTinTuc : SweetCakePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiTinTuc();
            }
        }

        
        private void HienThiTinTuc()
        {
            int id = 1;

            if (Request.QueryString["id"] != null)
            {
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    thongTinTinTuc.Visible = false;
                    thongBaoLoi.Visible = true;
                    khuVucBaiVietLienQuan.Visible = false;
                    return;
                }
            }

            List<BaiVietTinTuc> danhSach = LayDanhSachTinTuc();

            BaiVietTinTuc baiViet = null;

            foreach (BaiVietTinTuc item in danhSach)
            {
                if (item.MaTinTuc == id)
                {
                    baiViet = item;
                    break;
                }
            }

            
            if (baiViet == null)
            {
                thongTinTinTuc.Visible = false;
                thongBaoLoi.Visible = true;
                khuVucBaiVietLienQuan.Visible = false;
                return;
            }

            
            thongTinTinTuc.Visible = true;
            thongBaoLoi.Visible = false;

            anhTinTuc.Src = ResolveUrl("~/" + baiViet.AnhTinTuc);
            anhTinTuc.Alt = baiViet.TieuDe;

            loaiTinTuc.InnerText = baiViet.LoaiTinTuc;
            tieuDeTinTuc.InnerText = baiViet.TieuDe;
            ngayDang.InnerText = baiViet.NgayDang;
            thoiGianDoc.InnerText = baiViet.ThoiGianDoc;
            moTaTinTuc.InnerText = baiViet.MoTa;

            
            noiDungTinTuc.InnerHtml = baiViet.NoiDung;

            Page.Title = baiViet.TieuDe + " - SweetCake";

            
            List<BaiVietTinTuc> baiVietLienQuan = new List<BaiVietTinTuc>();

            foreach (BaiVietTinTuc item in danhSach)
            {
                if (item.MaTinTuc >= 6 && item.MaTinTuc <= 10 && item.MaTinTuc != id)
                {
                    baiVietLienQuan.Add(item);
                }
            }

            rptBaiVietLienQuan.InnerHtml = HtmlRender.RelatedNews(baiVietLienQuan);

            if (baiVietLienQuan.Count == 0)
            {
                thongBaoBaiViet.Visible = true;
                thongBaoBaiViet.InnerText = "Chưa có bài viết liên quan.";
            }
            else
            {
                thongBaoBaiViet.Visible = false;
            }
        }

    

        private List<BaiVietTinTuc> LayDanhSachTinTuc()
        {
            List<BaiVietTinTuc> danhSach = new List<BaiVietTinTuc>();

            // ================= BÀI VIẾT 1 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 1,
                LoaiTinTuc = "BÍ QUYẾT",
                TieuDe = "Bí quyết chọn bánh kem hoàn hảo cho ngày sinh nhật",
                NgayDang = "10/10/2026",
                ThoiGianDoc = "5 phút đọc",
                AnhTinTuc = "image/TinTuc/banh1_TT.jpg",
                MoTa = "Một chiếc bánh kem đẹp không chỉ làm bữa tiệc thêm ý nghĩa mà còn thể hiện tình cảm dành cho người thân. Cùng khám phá cách chọn bánh phù hợp nhé!",
                NoiDung =
    "<h2>Bí quyết chọn bánh kem hoàn hảo cho ngày sinh nhật</h2>" +

    "<p>Sinh nhật là dịp đặc biệt để mỗi người cùng gia đình, bạn bè và những người thân yêu tạo nên những kỷ niệm đáng nhớ. Trong ngày này, chiếc bánh kem không chỉ là món tráng miệng mà còn là điểm nhấn quan trọng của buổi tiệc. Một chiếc bánh đẹp mắt, thơm ngon và phù hợp với sở thích của người nhận sẽ giúp ngày sinh nhật trở nên trọn vẹn hơn.</p>" +

    "<p>Tuy nhiên, giữa rất nhiều mẫu bánh, hương vị và kích thước khác nhau, việc lựa chọn một chiếc bánh phù hợp đôi khi không hề đơn giản. Dưới đây là một số bí quyết giúp bạn dễ dàng chọn được chiếc bánh sinh nhật ưng ý.</p>" +

    "<h3>1. Lựa chọn kích thước bánh phù hợp</h3>" +

    "<p>Kích thước bánh là yếu tố đầu tiên bạn nên cân nhắc. Nếu tổ chức sinh nhật trong phạm vi gia đình với số lượng người tham dự ít, một chiếc bánh có kích thước nhỏ sẽ là lựa chọn hợp lý. Ngược lại, với những buổi tiệc đông người, bạn nên chọn bánh lớn hơn để đảm bảo mọi người đều có phần thưởng thức.</p>" +

    "<p>Ngoài ra, bạn cũng có thể lựa chọn bánh nhiều tầng nếu muốn tạo điểm nhấn nổi bật cho không gian buổi tiệc. Việc chọn đúng kích thước không chỉ giúp chiếc bánh cân đối mà còn tránh gây lãng phí.</p>" +
    "<img src='image/CTTT/banh12_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>2. Lựa chọn hương vị yêu thích</h3>" +

    "<p>Hương vị là yếu tố quyết định trải nghiệm thưởng thức bánh. Chocolate phù hợp với những người yêu thích vị ngọt đậm đà, trong khi vani mang đến cảm giác nhẹ nhàng và dễ ăn. Nếu yêu thích sự tươi mát, bạn có thể chọn bánh kem dâu tây hoặc các loại bánh kết hợp trái cây.</p>" +

    "<p>Bên cạnh đó, mousse cũng là một lựa chọn được nhiều người yêu thích nhờ kết cấu mềm mịn, nhẹ nhàng và không quá ngọt. Bạn nên cân nhắc sở thích của người nhận để lựa chọn hương vị phù hợp nhất.</p>" +

    "<h3>3. Chọn kiểu trang trí phù hợp</h3>" +

    "<p>Một chiếc bánh sinh nhật đẹp cần có cách trang trí phù hợp với chủ đề buổi tiệc. Đối với trẻ em, những mẫu bánh có màu sắc tươi sáng, hình nhân vật hoạt hình hoặc họa tiết dễ thương thường rất được yêu thích.</p>" +

    "<p>Đối với người trưởng thành, bạn có thể lựa chọn những mẫu bánh có phong cách tối giản, thanh lịch với các gam màu nhẹ nhàng. Ngoài ra, việc thêm tên, lời chúc hoặc thông điệp riêng cũng giúp chiếc bánh trở nên đặc biệt hơn.</p>" +

    "<h3>4. Quan tâm đến chất lượng và nguyên liệu</h3>" +

    "<p>Ngoài hình thức bên ngoài, chất lượng bánh cũng là điều không thể bỏ qua. Bạn nên ưu tiên những chiếc bánh được làm từ nguyên liệu có nguồn gốc rõ ràng, lớp kem mềm mịn và cốt bánh có độ xốp vừa phải.</p>" +

    "<p>Một chiếc bánh ngon cần có sự cân bằng giữa vị ngọt, vị béo và hương thơm của các nguyên liệu. Điều này giúp người thưởng thức cảm thấy ngon miệng mà không bị ngấy.</p>" +

    "<h3>5. Đặt bánh trước ngày sinh nhật</h3>" +

    "<p>Nếu muốn đặt bánh theo mẫu riêng hoặc yêu cầu trang trí đặc biệt, bạn nên liên hệ cửa hàng trước ngày tổ chức. Điều này giúp cửa hàng có đủ thời gian chuẩn bị nguyên liệu, hoàn thiện sản phẩm và đảm bảo chiếc bánh được giao đúng thời gian mong muốn.</p>" +

    "<h3>6. Lựa chọn địa chỉ mua bánh uy tín</h3>" +

    "<p>Một địa chỉ bán bánh uy tín sẽ giúp bạn yên tâm hơn về chất lượng sản phẩm, hương vị và dịch vụ. Bạn có thể tham khảo hình ảnh sản phẩm, đánh giá của khách hàng và các thông tin tư vấn trước khi quyết định đặt mua.</p>" +

    "<p>Tại SweetCake, chúng tôi mong muốn mang đến những chiếc bánh thơm ngon, đẹp mắt và phù hợp với nhiều dịp đặc biệt khác nhau.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Chọn bánh sinh nhật không chỉ đơn giản là chọn một món ăn mà còn là cách thể hiện sự quan tâm và tình cảm dành cho người nhận. Hy vọng những bí quyết trên sẽ giúp bạn dễ dàng tìm được chiếc bánh phù hợp, góp phần tạo nên một ngày sinh nhật thật vui vẻ, ấm áp và đáng nhớ.</p>"
            }
            );

            // ================= BÀI VIẾT 2 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 2,
                LoaiTinTuc = "KIẾN THỨC",
                TieuDe = "Cách bảo quản bánh kem luôn tươi ngon tại nhà",
                NgayDang = "08/10/2026",
                ThoiGianDoc = "4 phút đọc",
                AnhTinTuc = "image/TinTuc/banh11_TT.jpg",
                MoTa = "Bảo quản đúng cách giúp bánh giữ được hương vị, kết cấu mềm mịn và lớp kem hấp dẫn. Tìm hiểu những lưu ý quan trọng khi bảo quản bánh.",
                NoiDung =
    "<h2>Cách bảo quản bánh kem luôn tươi ngon tại nhà</h2>" +

    "<p>Bánh kem là món tráng miệng được yêu thích trong các dịp sinh nhật, lễ kỷ niệm và những buổi tiệc đặc biệt. Tuy nhiên, bánh kem thường có lớp kem tươi, sữa và nhiều nguyên liệu dễ bị ảnh hưởng bởi nhiệt độ. Vì vậy, nếu không được bảo quản đúng cách, bánh có thể bị chảy kem, mất đi hương vị thơm ngon và ảnh hưởng đến chất lượng.</p>" +

    "<img src='image/CTTT/banh4_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>1. Bảo quản bánh trong ngăn mát tủ lạnh</h3>" +

    "<p>Sau khi mua bánh, bạn nên đặt bánh vào ngăn mát tủ lạnh càng sớm càng tốt. Nhiệt độ mát giúp lớp kem giữ được độ ổn định, hạn chế tình trạng tan chảy và giúp bánh duy trì hương vị ban đầu.</p>" +

    "<p>Bạn nên đặt bánh ở vị trí bằng phẳng, tránh để các thực phẩm khác đè lên bánh. Ngoài ra, không nên đặt bánh gần những thực phẩm có mùi mạnh vì bánh kem rất dễ hấp thụ mùi từ môi trường xung quanh.</p>" +

    "<img src='image/CTTT/banh3_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>2. Sử dụng hộp đựng bánh phù hợp</h3>" +

    "<p>Hộp đựng bánh là vật dụng cần thiết giúp bảo vệ bánh khỏi bụi bẩn, vi khuẩn và những tác động bên ngoài. Bạn nên sử dụng hộp có kích thước phù hợp với bánh, có nắp đậy kín để hạn chế bánh bị khô và tránh hấp thụ mùi từ các thực phẩm khác trong tủ lạnh.</p>" +

    "<p>Nếu bánh đã được cắt thành từng miếng nhỏ, bạn có thể sử dụng hộp thực phẩm có nắp kín để bảo quản phần bánh còn lại. Điều này giúp giữ được độ mềm của cốt bánh và độ thơm ngon của lớp kem.</p>" +

    "<h3>3. Không để bánh ở nhiệt độ phòng quá lâu</h3>" +

    "<p>Đặc biệt trong những ngày thời tiết nóng, bạn không nên để bánh kem bên ngoài quá lâu. Nhiệt độ cao có thể khiến lớp kem nhanh chóng bị mềm, chảy và làm giảm chất lượng của bánh.</p>" +

    "<img src='image/CTTT/banh2_CTTT.jpg' class='anh-trong-bai' />" +

    "<p>Khi cần sử dụng bánh, bạn chỉ nên lấy bánh ra khỏi tủ lạnh trước thời điểm thưởng thức một khoảng thời gian ngắn. Sau khi dùng xong, hãy nhanh chóng cho phần bánh còn lại vào hộp và đặt lại trong ngăn mát.</p>" +

    "<h3>4. Chú ý thời gian sử dụng bánh</h3>" +

    "<p>Bánh kem có thành phần kem tươi và các nguyên liệu dễ hỏng nên tốt nhất bạn nên thưởng thức bánh khi còn tươi mới. Không nên sử dụng bánh nếu bánh có dấu hiệu bất thường như mùi lạ, lớp kem bị biến đổi hoặc xuất hiện dấu hiệu hư hỏng.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Bảo quản bánh kem đúng cách không chỉ giúp bánh giữ được hình dáng đẹp mắt mà còn duy trì hương vị thơm ngon. Chỉ cần chú ý đến nhiệt độ, hộp đựng và thời gian sử dụng, bạn đã có thể thưởng thức những chiếc bánh kem hấp dẫn cùng gia đình và bạn bè.</p>"
            });

            // ================= BÀI VIẾT 3 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 3,
                LoaiTinTuc = "CẢM HỨNG",
                TieuDe = "Cupcake nhỏ xinh – Món quà ngọt ngào cho mọi dịp",
                NgayDang = "05/10/2026",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TinTuc/banh7_TT.jpg",
                MoTa = "Những chiếc cupcake xinh xắn với màu sắc đáng yêu sẽ là lựa chọn tuyệt vời cho tiệc sinh nhật, buổi hẹn hò hay những dịp đặc biệt.",
                NoiDung =
    "<h2>Cupcake nhỏ xinh – Món quà ngọt ngào</h2>" +

    "<p>Cupcake là loại bánh có kích thước nhỏ gọn, thường được trang trí bằng lớp kem tươi nhiều màu sắc. Không chỉ hấp dẫn bởi vẻ ngoài xinh xắn, cupcake còn chinh phục thực khách nhờ hương vị thơm ngon và sự đa dạng trong cách chế biến. Mỗi chiếc bánh nhỏ đều mang một nét đẹp riêng, phù hợp với nhiều sở thích khác nhau.</p>" +

    "<img src='/image/CTTT/banh5_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>1. Vẻ đẹp của những chiếc cupcake</h3>" +

    "<p>Điểm đặc biệt của cupcake nằm ở cách trang trí vô cùng sáng tạo. Phần kem phía trên có thể được tạo hình thành những bông hoa nhỏ, trái tim hoặc các họa tiết đáng yêu. Kết hợp cùng những màu sắc nhẹ nhàng và phụ kiện trang trí như cốm màu, chocolate hay trái cây, mỗi chiếc cupcake đều trở nên bắt mắt và hấp dẫn.</p>" +

    "<p>Nhờ sự đa dạng trong thiết kế, cupcake có thể mang nhiều phong cách khác nhau, từ dễ thương, trẻ trung đến thanh lịch và sang trọng. Đây cũng là lý do loại bánh này luôn được yêu thích trong các buổi tiệc và sự kiện.</p>" +

    "<img src='/image/CTTT/banh6_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>2. Hương vị đa dạng, phù hợp với nhiều sở thích</h3>" +

    "<p>Cupcake có nhiều hương vị khác nhau như chocolate, vani, dâu tây, trà xanh và phô mai. Phần cốt bánh thường mềm xốp, kết hợp với lớp kem béo ngậy tạo nên hương vị hài hòa. Người thưởng thức có thể dễ dàng lựa chọn loại bánh phù hợp với khẩu vị của mình.</p>" +

    "<p>Ngoài những hương vị truyền thống, cupcake còn được biến tấu với nhiều nguyên liệu mới lạ. Sự kết hợp giữa trái cây tươi, chocolate và các loại kem đặc biệt giúp món bánh trở nên phong phú hơn.</p>" +

    "<h3>3. Món quà ngọt ngào dành cho mọi dịp</h3>" +

    "<p>Với hình dáng nhỏ xinh và cách trang trí đẹp mắt, cupcake là lựa chọn phù hợp cho nhiều dịp như sinh nhật, lễ kỷ niệm, tiệc trà, buổi hẹn hò hoặc những buổi gặp mặt bạn bè. Bạn cũng có thể lựa chọn một hộp cupcake được trang trí đẹp để dành tặng người thân, bạn bè và đồng nghiệp.</p>" +

    "<img src='/image/CTTT/banh7_CTTT.jpg' class='anh-trong-bai' />" +

    "<p>Không cần một món quà quá cầu kỳ, đôi khi chỉ một hộp cupcake nhỏ xinh cũng đủ thể hiện sự quan tâm và tình cảm chân thành dành cho người nhận.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Cupcake không chỉ là món bánh thơm ngon mà còn là món quà mang ý nghĩa tinh thần đặc biệt. Với vẻ ngoài đáng yêu, hương vị đa dạng và sự tiện lợi, những chiếc cupcake nhỏ xinh chắc chắn sẽ góp phần tạo nên những khoảnh khắc ngọt ngào và đáng nhớ.</p>"
            });

            // ================= BÀI VIẾT 4 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 4,
                LoaiTinTuc = "BÍ QUYẾT",
                TieuDe = "Chocolate và bánh ngọt: Sự kết hợp không thể bỏ lỡ",
                NgayDang = "02/10/2026",
                ThoiGianDoc = "5 phút đọc",
                AnhTinTuc = "image/TinTuc/banh9_TT.jpg",
                MoTa = "Từ vị đắng nhẹ của chocolate đen đến vị ngọt béo của chocolate sữa, mỗi sự kết hợp đều mang lại một trải nghiệm riêng biệt.",
                NoiDung =
    "<h2>Chocolate và bánh ngọt: Sự kết hợp hấp dẫn</h2>" +

    "<p>Chocolate là một trong những nguyên liệu được yêu thích trong nghệ thuật làm bánh nhờ hương vị đặc trưng và khả năng kết hợp linh hoạt với nhiều loại thực phẩm khác nhau. Từ những chiếc bánh kem mềm mịn đến bánh mousse thơm béo, chocolate luôn tạo nên sức hấp dẫn riêng biệt. Vị ngọt, đắng nhẹ và hương thơm đặc trưng của chocolate giúp các món bánh trở nên đậm đà và hấp dẫn hơn.</p>" +

    "<img src='/image/CTTT/banh10_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>1. Chocolate đen – Hương vị đậm đà</h3>" +

    "<p>Chocolate đen nổi bật với vị đắng nhẹ, hương thơm đặc trưng và màu sắc nâu sẫm hấp dẫn. Đây là lựa chọn phù hợp với những người yêu thích hương vị đậm đà và không quá ngọt. Trong làm bánh, chocolate đen thường được sử dụng để làm bánh brownie, bánh mousse chocolate và lớp phủ ganache.</p>" +

    "<p>Khi kết hợp với cốt bánh mềm xốp hoặc kem tươi, chocolate đen tạo nên sự cân bằng giữa vị đắng nhẹ và vị béo ngọt, giúp món bánh không bị ngấy.</p>" +

    "<h3>2. Chocolate sữa – Ngọt ngào và béo ngậy</h3>" +

    "<p>Chocolate sữa có hương vị ngọt dịu, béo nhẹ và dễ thưởng thức. Nhờ đặc điểm này, chocolate sữa thường được sử dụng trong bánh kem, bánh cupcake, bánh quy và nhiều món tráng miệng khác.</p>" +

    "<p>Lớp chocolate sữa tan mềm trong miệng, kết hợp cùng phần cốt bánh bông lan hoặc kem tươi tạo nên hương vị hài hòa. Đây cũng là loại chocolate được nhiều trẻ em và những người yêu thích vị ngọt lựa chọn.</p>" +

    "<h3>3. Kết hợp chocolate cùng các nguyên liệu khác</h3>" +

    "<p>Chocolate có thể kết hợp với nhiều nguyên liệu để tạo nên những hương vị phong phú. Dâu tây mang đến vị chua ngọt tự nhiên, hạt hạnh nhân tạo độ giòn bùi, trong khi kem tươi giúp món bánh có kết cấu mềm mịn và béo ngậy.</p>" +

    "<p>Ngoài ra, chocolate còn có thể kết hợp với chuối, caramel, cà phê hoặc trà xanh. Mỗi sự kết hợp đều mang đến một trải nghiệm khác nhau, giúp người làm bánh thỏa sức sáng tạo và tạo ra những món bánh độc đáo.</p>" +

    "<h3>4. Những loại bánh chocolate được yêu thích</h3>" +

    "<p>Một số loại bánh chocolate phổ biến có thể kể đến như bánh mousse chocolate với lớp kem mềm mịn, bánh brownie có kết cấu đặc và ẩm, bánh cupcake chocolate nhỏ xinh hay bánh kem chocolate phù hợp cho các dịp sinh nhật và kỷ niệm.</p>" +

    "<p>Mỗi loại bánh đều có cách chế biến và hương vị riêng, nhưng điểm chung là đều mang đến sức hấp dẫn khó cưỡng từ chocolate.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Chocolate không chỉ là nguyên liệu làm bánh quen thuộc mà còn là yếu tố tạo nên sự đặc biệt cho nhiều món tráng miệng. Sự kết hợp giữa chocolate và các nguyên liệu khác giúp bánh có hương vị phong phú, hình thức đẹp mắt và phù hợp với nhiều sở thích. Nếu yêu thích những món bánh ngọt, bạn đừng bỏ qua những chiếc bánh chocolate thơm ngon tại SweetCake nhé!</p>"
            });

            // ================= BÀI VIẾT 5 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 5,
                LoaiTinTuc = "SỰ KIỆN",
                TieuDe = "Gợi ý những mẫu bánh ngọt dành tặng người thương",
                NgayDang = "28/09/2026",
                ThoiGianDoc = "4 phút đọc",
                AnhTinTuc = "image/TinTuc/banh3_TT.jpg",
                MoTa = "Một chiếc bánh được lựa chọn cẩn thận sẽ giúp bạn gửi gắm lời yêu thương trong ngày kỷ niệm, ngày sinh nhật hoặc những dịp đáng nhớ.",
                NoiDung =
    "<h2>Gợi ý những mẫu bánh ngọt dành tặng người thương</h2>" +

    "<p>Bánh ngọt không chỉ là món ăn hấp dẫn mà còn là món quà mang ý nghĩa tinh thần đặc biệt. Một chiếc bánh được lựa chọn cẩn thận có thể thay lời muốn nói, thể hiện sự quan tâm và tình cảm dành cho những người thân yêu. Dù là sinh nhật, ngày kỷ niệm, Valentine hay đơn giản chỉ là một ngày bình thường, bánh ngọt luôn là món quà ngọt ngào giúp tạo nên những khoảnh khắc đáng nhớ.</p>" +

    "<h3>1. Bánh kem dâu tây – Ngọt ngào và lãng mạn</h3>" +

    "<p>Bánh kem dâu tây là lựa chọn phù hợp dành cho những người yêu thích sự nhẹ nhàng và tinh tế. Những quả dâu tây đỏ tươi được trang trí trên lớp kem trắng tạo nên vẻ ngoài nổi bật, đẹp mắt và đầy cuốn hút.</p>" +

    "<p>Phần cốt bánh mềm xốp kết hợp với lớp kem béo nhẹ và vị chua ngọt tự nhiên của dâu tây tạo nên hương vị hài hòa. Đây là mẫu bánh thích hợp dành tặng người yêu trong ngày kỷ niệm, sinh nhật hoặc những dịp đặc biệt.</p>" +

    "<img src='/image/CTTT/banh11_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>2. Bánh mousse – Mềm mịn và tinh tế</h3>" +

    "<p>Bánh mousse nổi bật với kết cấu mềm mịn, nhẹ nhàng và tan trong miệng. Loại bánh này thường có nhiều hương vị như dâu tây, xoài, chanh dây, chocolate và trà xanh, mang đến nhiều lựa chọn phù hợp với sở thích của người nhận.</p>" +

    "<p>Với hình thức trang trí đơn giản nhưng sang trọng, bánh mousse là món quà thích hợp dành cho những người yêu thích sự tinh tế. Bạn có thể lựa chọn bánh mousse có kích thước nhỏ để tạo nên một món quà xinh xắn và ý nghĩa.</p>" +

    "<h3>3. Bánh chocolate – Đậm đà và cuốn hút</h3>" +

    "<p>Đối với những người yêu thích vị ngọt đậm đà, bánh chocolate chắc chắn là một lựa chọn không thể bỏ qua. Hương thơm đặc trưng của chocolate kết hợp với cốt bánh mềm ẩm và lớp kem béo ngậy tạo nên sức hấp dẫn khó cưỡng.</p>" +

    "<p>Bạn có thể lựa chọn bánh chocolate phủ ganache, bánh mousse chocolate hoặc bánh kem chocolate được trang trí bằng trái cây và những viên chocolate nhỏ. Đây là món quà phù hợp cho những dịp sinh nhật, lễ kỷ niệm hoặc những buổi hẹn hò lãng mạn.</p>" +

    "<h3>4. Lựa chọn bánh phù hợp với sở thích người nhận</h3>" +

    "<p>Để món quà trở nên ý nghĩa hơn, bạn nên tìm hiểu sở thích và khẩu vị của người nhận trước khi lựa chọn bánh. Nếu người nhận thích vị thanh nhẹ, bánh mousse hoặc bánh kem trái cây sẽ là lựa chọn phù hợp. Nếu yêu thích hương vị đậm đà, bạn có thể chọn bánh chocolate hoặc bánh kem nhiều lớp.</p>" +

    "<p>Ngoài hương vị, bạn cũng nên chú ý đến kích thước, màu sắc và cách trang trí bánh. Một chiếc bánh được thiết kế riêng với lời chúc ngắn gọn sẽ giúp món quà trở nên đặc biệt và đáng nhớ hơn.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Một chiếc bánh ngọt tuy nhỏ bé nhưng có thể chứa đựng rất nhiều tình cảm. Hy vọng những gợi ý trên sẽ giúp bạn lựa chọn được mẫu bánh phù hợp để dành tặng người thương. Hãy để SweetCake đồng hành cùng bạn tạo nên những khoảnh khắc ngọt ngào và những kỷ niệm đáng nhớ bên những người thân yêu!</p>"
            });

            // ================= BÀI VIẾT 6 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 6,
                LoaiTinTuc = "GÓC BẾP",
                TieuDe = "Khám phá những nguyên liệu tạo nên chiếc bánh thơm ngon",
                NgayDang = "25/09/2026",
                ThoiGianDoc = "6 phút đọc",
                AnhTinTuc = "image/TinTuc/banh8_TT.jpg",
                MoTa = "Chất lượng nguyên liệu góp phần tạo nên hương vị đặc trưng của mỗi chiếc bánh. Cùng tìm hiểu những thành phần quen thuộc trong nghệ thuật làm bánh.",
                NoiDung =
    "<h2>Những nguyên liệu tạo nên chiếc bánh thơm ngon</h2>" +

    "<p>Mỗi chiếc bánh ngon đều được tạo nên từ những nguyên liệu quen thuộc nhưng cần được lựa chọn và kết hợp đúng cách. Từ bột mì, trứng, đường đến sữa và bơ, mỗi nguyên liệu đều giữ một vai trò riêng trong quá trình làm bánh. Sự kết hợp hài hòa giữa các thành phần không chỉ quyết định hương vị mà còn ảnh hưởng đến độ mềm, độ xốp và hình thức của thành phẩm.</p>" +

    "<h3>1. Bột mì – Nguyên liệu tạo nên kết cấu bánh</h3>" +

    "<p>Bột mì là một trong những nguyên liệu cơ bản và quan trọng nhất trong quá trình làm bánh. Bột mì cung cấp cấu trúc cho bánh, giúp các thành phần liên kết với nhau và tạo nên hình dáng của thành phẩm.</p>" +

    "<p>Tùy vào từng loại bánh, người làm bánh có thể lựa chọn loại bột phù hợp. Bột mì số 8 thường được sử dụng để làm bánh bông lan, cupcake nhờ đặc tính nhẹ và hàm lượng protein thấp. Trong khi đó, các loại bánh cần kết cấu chắc hơn có thể sử dụng những loại bột có hàm lượng protein cao hơn.</p>" +

    "<h3>2. Trứng – Bí quyết tạo độ mềm và xốp</h3>" +

    "<p>Trứng đóng vai trò quan trọng trong việc tạo độ mềm, độ xốp và màu sắc hấp dẫn cho bánh. Lòng trắng trứng có thể được đánh bông để tạo độ phồng, trong khi lòng đỏ giúp tăng độ béo và tạo màu vàng đẹp mắt cho cốt bánh.</p>" +

    "<img src='/image/CTTT/anh1_CTTT.jpg' class='anh-trong-bai' />" +

    "<p>Ngoài ra, trứng còn giúp liên kết các nguyên liệu với nhau, góp phần tạo nên kết cấu đồng đều. Việc sử dụng trứng ở nhiệt độ phù hợp và đánh trứng đúng kỹ thuật sẽ giúp bánh đạt được độ nở và độ mềm mong muốn.</p>" +

    "<h3>3. Đường và sữa – Tạo vị ngọt và độ thơm béo</h3>" +

    "<p>Đường không chỉ tạo vị ngọt mà còn góp phần giúp bánh có màu sắc đẹp khi nướng. Lượng đường cần được điều chỉnh phù hợp với từng công thức để bánh không quá ngọt và vẫn giữ được hương vị tự nhiên của các nguyên liệu khác.</p>" +

    "<p>Sữa giúp tăng độ ẩm, tạo hương thơm và làm cho bánh có vị béo nhẹ. Tùy theo công thức, người làm bánh có thể sử dụng sữa tươi, sữa đặc hoặc các sản phẩm từ sữa để tạo nên những hương vị khác nhau.</p>" +

    "<h3>4. Bơ – Tạo hương thơm đặc trưng</h3>" +

    "<p>Bơ là nguyên liệu quen thuộc trong nhiều công thức làm bánh, đặc biệt là bánh quy, bánh bông lan và các loại bánh ngọt. Bơ giúp bánh có hương thơm hấp dẫn, tăng độ béo và tạo cảm giác mềm mịn khi thưởng thức.</p>" +

    "<p>Ngoài bơ, một số công thức còn sử dụng dầu thực vật để giúp bánh giữ được độ ẩm. Việc lựa chọn loại chất béo phù hợp sẽ ảnh hưởng đáng kể đến kết cấu và hương vị của thành phẩm.</p>" +

    "<h3>5. Lựa chọn nguyên liệu chất lượng</h3>" +

    "<p>Để tạo ra những chiếc bánh thơm ngon, việc lựa chọn nguyên liệu có nguồn gốc rõ ràng và còn hạn sử dụng là điều rất quan trọng. Các nguyên liệu cần được bảo quản đúng cách, tránh ẩm mốc hoặc biến đổi chất lượng trước khi sử dụng.</p>" +

    "<p>Bên cạnh đó, người làm bánh nên cân đong nguyên liệu chính xác theo công thức. Chỉ một sự thay đổi nhỏ về tỷ lệ bột, đường, trứng hoặc chất lỏng cũng có thể ảnh hưởng đến kết quả cuối cùng.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Một chiếc bánh thơm ngon không chỉ cần công thức phù hợp mà còn phụ thuộc rất nhiều vào chất lượng nguyên liệu. Khi hiểu rõ vai trò của từng thành phần và biết cách kết hợp chúng, bạn có thể tạo nên những chiếc bánh mềm xốp, thơm béo và hấp dẫn. Tại SweetCake, mỗi chiếc bánh đều được chú trọng từ khâu lựa chọn nguyên liệu đến quá trình chế biến để mang đến trải nghiệm ngọt ngào cho khách hàng.</p>"
            });



            // ================= BÀI VIẾT 7 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 7,
                LoaiTinTuc = "CÂU CHUYỆN NGỌT NGÀO",
                TieuDe = "NGỌT NGÀO GỬI TRAO BÁNH KEM CHO NGÀY ĐẶC BIỆT",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TrangChu/baiviet4_TC.jpg",
                MoTa = "Một chiếc bánh kem có thể trở thành món quà yêu thương dành cho những người thân yêu.",
                NoiDung =
    "<h2>Ngọt ngào gửi trao bánh kem cho ngày đặc biệt</h2>" +

    "<p>Mỗi dịp sinh nhật, kỷ niệm hay ngày lễ đặc biệt đều là cơ hội để chúng ta thể hiện tình cảm với những người thân yêu. Bên cạnh những lời chúc ý nghĩa và những món quà xinh xắn, một chiếc bánh kem cũng là lựa chọn mang nhiều giá trị tinh thần. Không chỉ đơn thuần là món tráng miệng, bánh kem còn góp phần tạo nên không khí vui vẻ và lưu giữ những khoảnh khắc đáng nhớ trong cuộc sống.</p>" +
    "<h3>1. Bánh kem – Món quà của yêu thương</h3>" +

    "<p>Một chiếc bánh được lựa chọn cẩn thận có thể thay bạn gửi gắm sự quan tâm và những lời chúc tốt đẹp đến người nhận. Từ kiểu dáng trang trí, màu sắc cho đến hương vị bên trong đều có thể được lựa chọn theo sở thích của từng người.</p>" +

    "<p>Đối với ngày sinh nhật, một chiếc bánh có tên và tuổi của người nhận sẽ giúp buổi tiệc thêm phần ý nghĩa. Trong những dịp kỷ niệm, bánh kem được trang trí bằng hoa tươi, trái tim hoặc những lời chúc ngọt ngào sẽ tạo nên bất ngờ thú vị.</p>" +

    "<h3>2. Lựa chọn hương vị bánh phù hợp</h3>" +

    "<p>Hương vị là yếu tố quan trọng khi lựa chọn bánh kem. Nếu người nhận yêu thích sự nhẹ nhàng, bạn có thể chọn bánh kem trái cây với vị chua ngọt tự nhiên. Nếu yêu thích vị béo ngậy và đậm đà, bánh chocolate hoặc bánh kem phô mai sẽ là những gợi ý hấp dẫn.</p>" +

    "<p>Ngoài ra, bánh mousse cũng là lựa chọn được nhiều người yêu thích nhờ kết cấu mềm mịn và hương vị đa dạng. Việc tìm hiểu khẩu vị của người nhận sẽ giúp bạn chọn được chiếc bánh phù hợp và khiến món quà trở nên đặc biệt hơn.</p>" +

    "<h3>3. Kiểu dáng và cách trang trí bánh</h3>" +

    "<p>Mỗi chiếc bánh kem có thể mang một phong cách trang trí khác nhau. Những mẫu bánh đơn giản với gam màu pastel phù hợp với người yêu thích sự nhẹ nhàng, tinh tế. Trong khi đó, bánh được trang trí bằng nhiều màu sắc, hoa kem hoặc các hình nhân vật đáng yêu sẽ phù hợp với những buổi tiệc sinh nhật vui nhộn.</p>" +

    "<p>Bạn cũng có thể lựa chọn bánh kem theo chủ đề của buổi tiệc, chẳng hạn như phong cách lãng mạn, dễ thương hoặc sang trọng. Một chiếc bánh được thiết kế riêng sẽ giúp không gian buổi tiệc trở nên nổi bật và ấn tượng hơn.</p>" +

    "<img src='image/CTTT/banh8_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>4. Những dịp thích hợp để tặng bánh kem</h3>" +

    "<p>Bánh kem có thể xuất hiện trong rất nhiều dịp đặc biệt như sinh nhật, ngày lễ tình nhân, ngày kỷ niệm yêu nhau, lễ tốt nghiệp hoặc những buổi gặp mặt gia đình. Mỗi dịp đều có thể lựa chọn một mẫu bánh với kiểu dáng và thông điệp riêng.</p>" +

    "<p>Đôi khi, bạn không cần chờ đến một ngày lễ đặc biệt mới có thể tặng bánh cho người thân. Một chiếc bánh nhỏ bất ngờ vào ngày bình thường cũng đủ mang đến niềm vui và thể hiện sự quan tâm chân thành.</p>" +

    "<h3>5. Lưu giữ những khoảnh khắc đáng nhớ</h3>" +

    "<p>Khoảnh khắc cùng nhau thổi nến, cắt bánh và gửi những lời chúc tốt đẹp luôn là một phần đáng nhớ trong mỗi buổi tiệc. Những chiếc bánh kem đẹp mắt không chỉ làm cho bàn tiệc thêm hấp dẫn mà còn trở thành điểm nhấn trong những bức ảnh kỷ niệm.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Một chiếc bánh kem tuy không phải món quà quá lớn nhưng lại chứa đựng nhiều tình cảm và sự quan tâm. Hy vọng bạn sẽ lựa chọn được chiếc bánh phù hợp để gửi trao yêu thương đến những người quan trọng. SweetCake mong muốn mỗi chiếc bánh được trao đi đều góp phần tạo nên những khoảnh khắc đáng nhớ, ấm áp và ngọt ngào trong cuộc sống.</p>"
            });

            // ================= BÀI VIẾT 8 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 8,
                LoaiTinTuc = "ƯU ĐÃI",
                TieuDe = "MUA 1 TẶNG 1 BÁNH TRUNG THU SWEETCAKE",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TrangChu/banhtrungthu_TC.jpg",
                MoTa = "Chương trình từ 25/09 đến 10/10/2026 theo nội dung ưu đãi của cửa hàng.",
                NoiDung =
                    "<h2>Mua 1 tặng 1 bánh Trung thu SweetCake</h2>" +
                    "<p>Mùa Trung thu là dịp đoàn viên, khi mọi người cùng sum họp bên gia đình và trao nhau những món quà ý nghĩa. Nhân dịp này, SweetCake mang đến chương trình ưu đãi mua 1 tặng 1 bánh Trung thu dành cho khách hàng.</p>" +
                    "<h3>Thời gian áp dụng</h3>" +
                    "<p>Chương trình diễn ra từ ngày 25/09 đến ngày 10/10/2026 theo nội dung ưu đãi của cửa hàng.</p>" +
                    "<h3>Ưu đãi dành cho bạn</h3>" +
                    "<img src='image/CTTT/14_CTTT.jpg' class='anh-trong-bai' />" +

                    "<p>Với chương trình mua 1 tặng 1, khách hàng có thêm cơ hội thưởng thức bánh Trung thu và lựa chọn những phần quà dành tặng người thân, bạn bè.</p>" +
                    "<h3>Trao gửi món quà đoàn viên</h3>" +
                    "<p>Một hộp bánh Trung thu không chỉ mang hương vị thơm ngon mà còn gửi gắm lời chúc đoàn viên và sự quan tâm đến những người thân yêu.</p>" +
                    "<p>Hãy khám phá các sản phẩm Trung thu tại SweetCake để lựa chọn món quà phù hợp.</p>"
            });

            // ================= BÀI VIẾT 9 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 9,
                LoaiTinTuc = "KHUYẾN MÃI",
                TieuDe = "BÁNH TRUNG THU SWEETCAKE 2026 - ƯU ĐÃI 15%",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TrangChu/banhtrungthu2_TC.jpg",
                MoTa = "Khám phá bộ sưu tập bánh Trung Thu với chương trình ưu đãi đặc biệt.",
                NoiDung =
    "<h2>Bánh Trung thu SweetCake 2026 - Ưu đãi 15%</h2>" +

    "<p>Mỗi khi mùa Trung thu đến, những chiếc bánh Trung thu lại trở thành món quà quen thuộc mang ý nghĩa đoàn viên và sum họp. Đây không chỉ là món bánh truyền thống được yêu thích mà còn là cách mọi người gửi gắm tình cảm, sự quan tâm đến gia đình, bạn bè và những người thân yêu.</p>" +

    "<p>Chào đón mùa Trung thu 2026, SweetCake giới thiệu bộ sưu tập bánh Trung thu với nhiều mẫu mã và hương vị hấp dẫn. Các sản phẩm được lựa chọn và chuẩn bị chỉn chu, phù hợp để thưởng thức cùng gia đình hoặc dành tặng trong những dịp đặc biệt.</p>" +

    "<img src='image/CTTT/13_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>1. Ưu đãi đặc biệt giảm 15%</h3>" +

    "<p>Nhằm mang đến trải nghiệm mua sắm thú vị cho khách hàng, SweetCake triển khai chương trình ưu đãi giảm giá 15% đối với các sản phẩm bánh Trung thu theo nội dung khuyến mãi của cửa hàng.</p>" +

    "<p>Đây là cơ hội để khách hàng lựa chọn những hộp bánh thơm ngon với mức giá ưu đãi hơn. Bạn có thể mua bánh để thưởng thức cùng gia đình hoặc chuẩn bị những món quà ý nghĩa dành tặng người thân, bạn bè và đồng nghiệp.</p>" +

    "<h3>2. Đa dạng hương vị bánh Trung thu</h3>" +

    "<p>Bộ sưu tập bánh Trung thu SweetCake mang đến nhiều lựa chọn hương vị khác nhau, từ những loại nhân truyền thống đến các hương vị hiện đại. Mỗi loại bánh đều có nét hấp dẫn riêng, phù hợp với sở thích của nhiều khách hàng.</p>" +

    "<p>Bánh nhân thập cẩm mang hương vị quen thuộc, kết hợp nhiều nguyên liệu tạo nên vị đậm đà. Bánh nhân đậu xanh có vị ngọt dịu, mềm mịn, trong khi bánh nhân chocolate phù hợp với những người yêu thích sự mới lạ.</p>" +

    "<img src='image/CTTT/14_CTTT.jpg' class='anh-trong-bai' />" +

    "<h3>3. Thiết kế hộp quà sang trọng</h3>" +

    "<p>Bên cạnh chất lượng bánh, hình thức đóng gói cũng là yếu tố được SweetCake chú trọng. Những hộp bánh được thiết kế đẹp mắt, màu sắc hài hòa và phù hợp với không khí ấm áp của mùa Trung thu.</p>" +

    "<p>Một hộp bánh được chuẩn bị cẩn thận không chỉ thể hiện sự tinh tế mà còn giúp người tặng gửi đi những lời chúc tốt đẹp. Đây là lựa chọn phù hợp dành cho gia đình, bạn bè, khách hàng hoặc đối tác.</p>" +

    "<h3>4. Món quà ý nghĩa dành cho mùa đoàn viên</h3>" +

    "<p>Trung thu là dịp để mọi người cùng trở về bên gia đình, thưởng thức bánh, uống trà và chia sẻ những câu chuyện trong cuộc sống. Vì vậy, một hộp bánh Trung thu không chỉ mang giá trị vật chất mà còn chứa đựng tình cảm và ý nghĩa tinh thần.</p>" +

    "<p>Bạn có thể lựa chọn những hộp bánh có hương vị phù hợp với sở thích của người nhận để món quà trở nên thiết thực và ý nghĩa hơn. Dù dành tặng ông bà, cha mẹ, bạn bè hay đồng nghiệp, bánh Trung thu vẫn luôn là món quà mang thông điệp đoàn viên.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Với bộ sưu tập bánh Trung thu 2026 cùng chương trình ưu đãi giảm 15%, SweetCake hy vọng mang đến cho khách hàng nhiều lựa chọn hấp dẫn trong mùa trăng năm nay. Hãy cùng SweetCake lựa chọn những chiếc bánh thơm ngon để thưởng thức và gửi trao những món quà ý nghĩa đến những người thân yêu.</p>"
            });

            // ================= BÀI VIẾT 10 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 10,
                LoaiTinTuc = "QUÀ TẶNG",
                TieuDe = "ƯU ĐÃI 20% HỘP QUÀ TRUNG THU",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TrangChu/hop_TC.jpg",
                MoTa = "Hộp quà đẹp mắt và sang trọng để gửi trao lời chúc đến gia đình, bạn bè.",
                NoiDung =
    "<h2>Ưu đãi 20% hộp quà Trung thu</h2>" +

    "<p>Trung thu là dịp đặc biệt để mọi người cùng sum họp bên gia đình, bạn bè và trao nhau những món quà ý nghĩa. Trong không khí ấm áp của mùa đoàn viên, một hộp bánh Trung thu được chuẩn bị chỉn chu không chỉ thể hiện sự quan tâm mà còn gửi gắm những lời chúc tốt đẹp đến người nhận.</p>" +

    "<p>Nhằm mang đến nhiều lựa chọn quà tặng hấp dẫn, SweetCake giới thiệu chương trình ưu đãi giảm giá 20% dành cho các hộp quà Trung thu. Đây là cơ hội để khách hàng lựa chọn những món quà đẹp mắt với mức giá tiết kiệm hơn.</p>" +

    "<h3>1. Hộp quà đẹp mắt và sang trọng</h3>" +

    "<p>Các hộp quà Trung thu tại SweetCake được chú trọng từ thiết kế bên ngoài đến cách sắp xếp sản phẩm bên trong. Màu sắc trang nhã, họa tiết tinh tế cùng cách đóng gói cẩn thận giúp hộp quà trở nên nổi bật và sang trọng.</p>" +

    "<img src='image/CTTT/14_CTTT.jpg' class='anh-trong-bai' />" +

    "<p>Không chỉ phù hợp để thưởng thức cùng gia đình, hộp quà Trung thu còn là lựa chọn thích hợp dành tặng bạn bè, người thân, đồng nghiệp và đối tác trong dịp lễ đoàn viên.</p>" +

    "<h3>2. Ưu đãi giảm giá 20%</h3>" +

    "<p>Khi lựa chọn hộp quà Trung thu thuộc chương trình khuyến mãi, khách hàng có cơ hội nhận ưu đãi giảm giá 20% theo nội dung chương trình của cửa hàng.</p>" +

    "<p>Chương trình giúp khách hàng tiết kiệm chi phí khi mua bánh làm quà, đồng thời có thêm cơ hội lựa chọn những hộp bánh chất lượng và hình thức đẹp mắt.</p>" +

    "<h3>3. Món quà ý nghĩa dành cho người thân</h3>" +

    "<p>Mỗi hộp bánh Trung thu đều mang ý nghĩa của sự đoàn viên, sum họp và sẻ chia. Một món quà nhỏ được trao đi đúng dịp sẽ giúp người nhận cảm nhận được sự quan tâm và tình cảm chân thành.</p>" +

    "<p>Bạn có thể lựa chọn hộp quà dành tặng ông bà, cha mẹ, bạn bè hoặc những người đã đồng hành trong công việc và cuộc sống.</p>" +

    "<h3>4. Lựa chọn hộp quà phù hợp</h3>" +

    "<p>Khi chọn mua hộp quà Trung thu, bạn nên cân nhắc số lượng bánh, hương vị và thiết kế hộp để phù hợp với người nhận. Một hộp quà được lựa chọn cẩn thận sẽ giúp món quà trở nên thiết thực và ý nghĩa hơn.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Trung thu không chỉ là dịp thưởng thức những chiếc bánh thơm ngon mà còn là thời điểm để gửi trao yêu thương. Với chương trình ưu đãi giảm 20% hộp quà Trung thu, SweetCake hy vọng sẽ giúp bạn dễ dàng lựa chọn những món quà đẹp mắt, ý nghĩa để dành tặng những người thân yêu trong mùa đoàn viên.</p>"
            });
            // ================= BÀI VIẾT 11 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 11,
                LoaiTinTuc = "ƯU ĐÃI ĐẶC BIỆT",
                TieuDe = "MUA 3 TÍNH TIỀN 2",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "3 phút đọc",
                AnhTinTuc = "image/TrangChu/baiviet5_TC.jpg",
                MoTa = "Thêm niềm vui với chương trình ưu đãi dành cho khách hàng.",
                NoiDung =
    "<h2>Mua 3 tính tiền 2 – Ưu đãi đặc biệt từ SweetCake</h2>" +

    "<p>Nhằm mang đến thêm nhiều trải nghiệm mua sắm thú vị và tiết kiệm cho khách hàng, SweetCake giới thiệu chương trình ưu đãi mua 3 tính tiền 2. Đây là cơ hội tuyệt vời để bạn thưởng thức nhiều loại bánh thơm ngon hoặc lựa chọn những món quà ngọt ngào dành tặng gia đình và bạn bè.</p>" +

    "<p>Với chương trình này, khách hàng có thể lựa chọn 3 sản phẩm thuộc danh sách áp dụng và được hưởng ưu đãi theo thể lệ của cửa hàng.</p>" +

    "<h3>1. Mua nhiều hơn, nhận ưu đãi hấp dẫn</h3>" +

    "<p>Chương trình mua 3 tính tiền 2 giúp khách hàng tiết kiệm chi phí khi lựa chọn nhiều sản phẩm cùng lúc. Thay vì chỉ mua một loại bánh quen thuộc, bạn có thể kết hợp nhiều hương vị khác nhau để trải nghiệm sự đa dạng trong bộ sưu tập bánh của SweetCake.</p>" +

    "<img src='image/CTTT/15_CTTT.jpg' class='anh-trong-bai' />" +

    "<p>Đây cũng là dịp thích hợp để bạn rủ bạn bè hoặc người thân cùng đặt bánh, vừa có thể thưởng thức nhiều hương vị vừa tận dụng được chương trình ưu đãi.</p>" +

    "<h3>2. Đa dạng lựa chọn bánh ngọt</h3>" +

    "<p>SweetCake mang đến nhiều dòng bánh với hương vị và kiểu dáng khác nhau. Bạn có thể lựa chọn bánh kem mềm mịn, bánh mousse thanh nhẹ, cupcake nhỏ xinh hoặc những loại bánh ngọt hấp dẫn khác tùy theo sở thích.</p>" +

    "<p>Mỗi loại bánh đều có nét đặc trưng riêng, từ vị ngọt béo của chocolate đến vị chua ngọt tươi mát của trái cây. Sự đa dạng này giúp khách hàng dễ dàng lựa chọn những sản phẩm phù hợp với khẩu vị của mình.</p>" +

    "<h3>3. Phù hợp khi mua bánh làm quà</h3>" +

    "<p>Không chỉ phục vụ nhu cầu thưởng thức cá nhân, chương trình còn phù hợp với những khách hàng muốn mua bánh làm quà. Bạn có thể lựa chọn các loại bánh khác nhau để dành tặng gia đình, bạn bè, đồng nghiệp trong những dịp sinh nhật, gặp mặt hoặc kỷ niệm đặc biệt.</p>" +

    "<p>Những chiếc bánh được lựa chọn cẩn thận và đóng gói đẹp mắt sẽ giúp bạn gửi gắm sự quan tâm đến những người thân yêu.</p>" +

    "<h3>4. Những lưu ý khi tham gia chương trình</h3>" +

    "<p>Khi mua hàng, khách hàng nên kiểm tra danh sách sản phẩm được áp dụng ưu đãi và các điều kiện đi kèm. Bạn cũng có thể liên hệ với SweetCake để được tư vấn về sản phẩm, cách đặt hàng và thông tin chương trình.</p>" +

    "<h2>Lời kết</h2>" +

    "<p>Chương trình mua 3 tính tiền 2 là cơ hội để khách hàng thưởng thức nhiều loại bánh thơm ngon với mức chi phí tiết kiệm hơn. SweetCake hy vọng ưu đãi này sẽ mang đến những trải nghiệm mua sắm thú vị và giúp bạn có thêm nhiều khoảnh khắc ngọt ngào bên gia đình, bạn bè và những người thân yêu.</p>"
            });

            // ================= BÀI VIẾT 12 =================
            danhSach.Add(new BaiVietTinTuc
            {
                MaTinTuc = 12,
                LoaiTinTuc = "BỘ SƯU TẬP",
                TieuDe = "12 HƯƠNG VỊ CAO CẤP TUYỂN CHỌN",
                NgayDang = "Đang cập nhật",
                ThoiGianDoc = "4 phút đọc",
                AnhTinTuc = "image/TrangChu/banhtrungthu3_TC.jpg",
                MoTa = "Khám phá những hương vị bánh Trung Thu đặc biệt dành cho mùa trăng.",
                NoiDung =
    "<h2>12 hương vị cao cấp tuyển chọn</h2>" +
    "<p>Đón mùa Trung thu, SweetCake giới thiệu bộ sưu tập gồm 12 hương vị bánh được tuyển chọn dành cho những khách hàng yêu thích bánh Trung thu. Mỗi chiếc bánh đều được chăm chút từ hương vị đến hình thức, mang đến trải nghiệm thưởng thức thơm ngon và hấp dẫn.</p>" +

    "<h3>Đa dạng hương vị</h3>" +
    "<img src='image/CTTT/13_CTTT.jpg' class='anh-trong-bai' />" +
    "<p>Bộ sưu tập mang đến nhiều lựa chọn khác nhau, từ những hương vị truyền thống quen thuộc đến các sự kết hợp mới lạ. Nhờ đó, khách hàng có thể dễ dàng tìm được loại bánh phù hợp với sở thích của bản thân và gia đình.</p>" +
    "<p>Từng chiếc bánh được chuẩn bị với sự chú trọng đến chất lượng nguyên liệu, độ mềm của vỏ bánh và phần nhân bên trong. Sự kết hợp hài hòa giữa các thành phần giúp tạo nên hương vị thơm ngon, vừa giữ được nét truyền thống vừa mang đến cảm giác mới mẻ.</p>" +

    "<h3>Món quà ý nghĩa mùa trăng</h3>" +
    "<p>Bánh Trung thu không chỉ là món ăn truyền thống mà còn tượng trưng cho sự đoàn viên, sum họp và những lời chúc tốt đẹp. Đây là món quà thường được lựa chọn để gửi gắm tình cảm đến gia đình, bạn bè, đồng nghiệp và đối tác trong dịp Tết Trung thu.</p>" +
    "<p>Với thiết kế hộp quà chỉn chu cùng nhiều hương vị hấp dẫn, bộ sưu tập SweetCake là lựa chọn đáng cân nhắc dành tặng những người thân yêu. Một hộp bánh được chuẩn bị cẩn thận sẽ thay cho lời chúc sức khỏe, hạnh phúc và bình an trong mùa trăng tròn.</p>" +

    "<h3>Trải nghiệm Trung thu cùng SweetCake</h3>" +
    "<p>SweetCake mong muốn mang đến cho khách hàng những chiếc bánh thơm ngon, góp phần làm cho khoảnh khắc sum họp trở nên trọn vẹn hơn. Dù thưởng thức cùng gia đình hay dùng làm quà tặng, mỗi chiếc bánh đều mang theo hương vị ngọt ngào của mùa đoàn viên.</p>" +
    "<p>Hãy cùng SweetCake khám phá bộ sưu tập 12 hương vị cao cấp và lựa chọn những chiếc bánh phù hợp để đón một mùa Trung thu thật ấm áp và ý nghĩa.</p>"
            });
            return danhSach;
        }
    }

    // Lớp lưu thông tin bài viết, cùng namespace với ChiTietTinTuc
    public class BaiVietTinTuc
    {
        public int MaTinTuc { get; set; }

        public string LoaiTinTuc { get; set; }

        public string TieuDe { get; set; }

        public string NgayDang { get; set; }

        public string ThoiGianDoc { get; set; }

        public string AnhTinTuc { get; set; }

        public string MoTa { get; set; }

        public string NoiDung { get; set; }
    }
}
