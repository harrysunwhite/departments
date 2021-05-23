
var $id = "";
var $modal = $('#myModal');
var $myModalContent = $("#myModalContent");
var $modalins = $('#myModalins');
var $myModalContentins = $("#myModalContentins");
var $myModalTitle = $("#myModalTitle");
var $myModalTitleins = $("#myModalTitleins");

$(document).ready(
    
    function () {
      
         $("#btSave").click(function () {
             var data = {};
             data.Id = 1;
             data.Name = $('#Namepbins').val()
             $.ajax({
                 type: "POST",
                 url: "/Department/ThemPb",
                 dataType: "json",
                 data: data,
                 success: function (result) {
                    $('#preloader-wrapper').toggleClass('hide');
                     if (result.status >= 1) {
                         console.log(result.text);
                         toastr.success(result.text);
                         reloadpage(1);
                    }
                    else {
                         toastr.danger(result.text);
                    }
                 },
                 error: function (errormessage) {
                     alert(errormessage.responseText);
                 },
                 failure: function (message) {
                    $('#preloader-wrapper').toggleClass('hide');
                }
             });
         });
        $("#btupdate").click(function () {
            var data = {};
            data.Id = $('#idpb').val();
            data.Name = $('#namepb').val()
            $.ajax({
                type: "POST",
                url: "/Department/UpdatePb",
                dataType: "json",
                data: data,
                success: function (result) {
                    $('#preloader-wrapper').toggleClass('hide');
                    if (result.status >= 1) {
                        toastr.success(result.text);
                        reloadpage();
                    }
                    else {
                        alert("Cập nhật thất bại")
                    }
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                },
                failure: function (message) {
                    $('#preloader-wrapper').toggleClass('hide');
                }
            });
        });
        $("#btclose").click(function () {
            
            reloadpage();
        });
        $("#btcloseins").click(function () {

            reloadpage();
        });
        
       
      
    });



function reloadpage() {


    obj = {};
    obj.id = 1,
        obj.Name = "";
    obj.Page = 1;
    $.ajax({
        url: '/PageList/',

        type: "Get",
        timeout: 20000,

        async: false,
        
        data: obj,

        success: function (result) {

            $('#nameListContainer').html(result);
        },
        
        failure: function (message) {
            $('#preloader-wrapper').toggleClass('hide');
        }
    });
}




function Edit(id_) {
    $myModalContent.html("");
    $myModalTitle.html("Cập nhật");
    $.ajax({
        url: '/_EditDeparment/' ,
         
        type: "Get",
        timeout: 20000,
        
        async: true,
        data: {
            id: id_
        },
       
        success: function (result) {
            $myModalContent.html(result);
            $('#btSave').hide();
            $('#btupdate').show();
            $modal.modal('show');
        
          
            $('#preloader-wrapper').toggleClass('hide');
        },
        failure: function (message) {
            $('#preloader-wrapper').toggleClass('hide');
        }
    });
}


function showmodal() {

    $myModalTitleins.html("Thêm");
    $modalins.modal('show');
    $('#Namepbins').val('');
    $('#btSave').show();
    $('#btupdate').hide();
    $('#idpb').val("ID");

}

function _delete(id) {
    var cf = confirm('Bạn muốn xoá phòng ban này?');
    if (cf) {
        $.ajax({
            type: "POST",
            url: "/Department/DeletePB",
            dataType: "json",
            data: { "id": id },
            success: function (result) {
                $('#preloader-wrapper').toggleClass('hide');
                if (result.status >= 1) {
                    toastr.success(result.text);
                    
                    reloadpage();
                }
                else {
                    toastr.danger(result.text);
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            },
            failure: function (message) {
                $('#preloader-wrapper').toggleClass('hide');
            }
        });
    }
    
}

function Timkiem() {
   

    obj = {};
    obj.id = 1,
        obj.Name = $('#txtSearch').val();
    obj.Page = 1;
    $.ajax({
        url: '/PageList/',
        
        type: "Get",
        timeout: 20000,

        async: false,
       
        data: obj,
          

        success: function (result) {
            if (result.status == -2) {
                toastr.success(result.text);

            }
            else {

                $('#nameListContainer').html(result);
            }
            
            
        },
       
        failure: function (message) {
            $('#preloader-wrapper').toggleClass('hide');
        }
    });
}

function Clear() {


    obj = {};
    obj.id = 1,
        obj.Name = "";
    obj.Page = 1;
    $.ajax({
        url: '/PageList/',

        type: "Get",
        timeout: 20000,

        async: false,
      
        data: obj,

        success: function (result) {

            $('#nameListContainer').html(result);
        },
       
        failure: function (message) {
            $('#preloader-wrapper').toggleClass('hide');
        }
    });
}







