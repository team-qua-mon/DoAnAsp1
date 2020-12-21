btnGET = (url, title) => {
    $.ajax({
        type: 'POST',
        url: "/Admin/Index",
        success: function (data, text) {
            alert("Đăng nhập thành công");
        },
    })
}