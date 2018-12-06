function openModal(Id) {
    var name;
    var address;
    console.log("in");

    $.ajax({
        url: "/Store/Details?id=" + Id, success: function (result) {
            name = result.Name;
            address = result.Address;
            $("#store-edit-name-value").val(name);
            $("#store-edit-id").val(result.Id);
            $("#store-edit-address-value").val(address);
            console.log(name);

        },
        error: function (result) {
            console.log(result);
        }
    });

    $("#store-edit-id").attr('readonly', true);
    $("#store-edit-box").modal();


}

function storeSave() {
    checkInput("store-edit-name-value", "store-edit-address-value");
    console.log($("#store-edit-name-value").val() != null);
    if ($("#store-edit-name-value").val() != "" && $("#store-edit-address-value").val() != "") {
        var id = $("#store-edit-id").val();

        var passdata = {
            Id: id,
            Name: $("#store-edit-name-value").val(),
            Address: $("#store-edit-address-value").val(),
        };

        $.ajax({
            type: "POST",
            url: "/Store/Edit",
            data: passdata,
            dataType: "json",
            success: function (data) {
                if (data === "success save") {
                    location.reload();

                }
            },
            failure: function (errMsg) {
                alert(errMsg)
            }



        });
    }

}

function openCreate() {
    $("#store-create-box").modal();
}

function storeCreate()
{
 
    checkInput("store-create-name-value", "store-create-address-value");
    if ($("#store-create-name-value").val() != "" && $("#store-create-address-value").val() != "") {

        var passdata = {

            Name: $("#store-create-name-value").val(),
            Address: $("#store-create-address-value").val()
        };

        $.ajax({
            type: "POST",
            url: "Store/Create",
            data: passdata,
            dataType: "json",
            success: function (data) {


                if (data === "success create") {
                    location.reload();
                } else {
                    return ("unsave");
                };

            },
            failure: function (errMsg) {
                alert(errMsg);
            }


        });
    
    }
    

}

function checkInput(id1, id2) {
    $("#" + id2).css("background-color", "");
    $("#" + id1).css("background-color", "");
    if (!($("#"+id1).val() != "") && $("#"+id2).val() != "") {
        console.log("in");

        $("#"+id1).css("background-color", "red");
        return;


    }
    if (($("#"+id2).val() != "") == false && $("#"+id1).val() != "") {
        console.log("in2");

        $("#"+id2).css("background-color", "red");
        return;


    } else {
        console.log("in2");
        $("#"+id2).css("background-color", "red");
        $("#"+id1).css("background-color", "red");
        return;
    }

}



function openDelete(Id) {

    removeAppend();
    $.ajax({
        url: "/Store/Details?id=" + Id, success: function (result) {
            name = result.Name;
            address = result.Address;
            $("#store-delete-info").append("<div class=" + "remove" + ">Are you sure to delete <h3>Name: " + name + "</h3> <h3> Address:" + address + "</h3></div>");
            $("#store-delete-Id").val(result.Id);
            console.log(name+"get");

        },
        error: function (result) {
            console.log(result);
        }
    });
    $("#store-delete-Id").attr('readonly', true);
    $("#store-delete-box").modal();

}

function storeDelete() {
    id = $("#store-delete-Id").val();
    console.log(id);

    $.ajax({
        type: "post",
        url: "Store/delete?id=" + id,
        success: function (data) {

            if (data === "deleted sucess") {
                location.reload();
            } else {
                return ("unsucessful");
            };

        },
        failure: function (errmsg) {
            alert(errmsg);
        }


    });

}
function removeAppend() {
    $(".remove").remove();
}




