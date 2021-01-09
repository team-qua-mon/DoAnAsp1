$(function () {
    $('#AlertBox').removeClass('hide');
    $('#AlertBox').delay(1000).slideUp(1000);
});

$(function () {
    var q = new Date();
    var m = q.getMonth();
    var d = q.getDay();
    var y = q.getFullYear();
    var dateToday = new Date(d, m, y);
    var ngaynhapbd = document.getElementById("ValicationBD").value;
    if (ngaynhapbd < dateToday) {
        alert("a");
    }
})

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
jQueryAjaxDelete = form => {
    if (confirm("Bạn có muốn xóa sản phẩm?")) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#View-All').html(res.html);
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
    else {
        return false;
    }
    
}
