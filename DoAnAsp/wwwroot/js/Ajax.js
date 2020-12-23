
//btnGET = (url, title) => {
//    $.ajax({
//        type: 'POST',
//        url: "/Admin/Index",
//        success: function (res) {
//            if(res.isValid)
//                alert("Đăng nhập thành công");
//            if (res.Roles == "")
//                window.location.href = ""
//            else

//        }
//    })
//}
showModal = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#View-All').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }

        })
        return false;
    } catch (ex) {
        console.log(ex)
    }
}
function readURL(input, idImg) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(idImg).attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}