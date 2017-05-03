function Status(ID, url) {
    $.ajax({
        url: url + ID,
        type: "Post",
        success: function (data) {
            if (data) {
                $("#durum_" + ID).empty();
                $("#durum_" + ID).append("<span class='btn btn-success'>Aktif</span>")
            }
            else {

                $("#durum_" + ID).empty();
                $("#durum_" + ID).append("<span class='btn btn-danger'>Pasif</span>")
            }
        }


    })
}

function Delete(ID, url) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel plx!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
    function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                url: url + ID,
                type: "post",
                success: function ()
                {
                    $("#sil_" + ID).fadeOut();
                    swal("Deleted!", "Your imaginary file has been deleted.", "success");
                }

            })

        } else {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
        }
    });
}