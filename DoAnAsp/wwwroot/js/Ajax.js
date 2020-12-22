btnGET = (url, title) => {
    $.ajax({
        type: 'POST',
        url: "/Admin/Index",
        success: function (res) {
            if(res.isValid)
                alert("Đăng nhập thành công");
            if (res.Roles == "")
                window.location.href = ""
            else

        },
    })
}