$(document).ready(
    
    function () {


        $('#btCreateN').click(function () {


            $('#Namepb').val('');
            $('#idpb').val("ID");
            $('#Maphong').hide();

            $('#btnUpdate').hide();
            $('#btnAdd').show();
        });
        
        //_getAll();
    });



function _add() {
    var obj = {
        
        Name: $('#Namepb').val(),

    }
    $.ajax({
        url: '/api/Phongban',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        statusCode: {
            200: function () {

                location.reload();
                $('#myModal').modal('hide');



             
            },

        }



    });
}
function _edit() {
    
    var obj = {
        Id: $('#idpb').val(),
        Name: $('#Namepb').val(),

    }

    $.ajax({
        url: '/api/Phongban',
        data: JSON.stringify(obj),
        type: "PUT",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        statusCode: {
            200: function () {


                location.reload();


                $('#myModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        }
    });
}

function _getById(id) {
    $.ajax({
        url: '/api/Phongban/' + id,
        // data: JSON.stringify(dto),
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#Maphong').show();
            $('#idpb').val(result.Id);
            $('#Namepb').val(result.Name);


            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function _delete(id) {
    var cf = confirm('Bạn muốn xoá phòng ban này?');
    if (cf) {
        $.ajax({
            url: '/api/Phongban/' + id,
            type: "DELETE",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            statusCode: {
                200: function () {
                    location.reload();
                }
            }



        });
    }



}