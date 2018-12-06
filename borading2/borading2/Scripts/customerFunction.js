function openModal(Id) {
    var name;
    var address;

    $.ajax({
        url: "/Customer/Details?id=" + Id, success: function (result) {
            name = result.Name;
            address = result.Address;
            $("#customer-edit-name-value").val(name);
            $("#customer-edit-id").val(result.Id);
            $("#customer-edit-address-value").val(address);
            console.log(name);

        },
        error: function (result) {
            console.log(result);
        }
    });

    $("#customer-edit-id").attr('readonly', true);
    $("#customer-edit-box").modal();

    
}

function customerSave() {
    var id = $("#customer-edit-id").val();
    var passdata = {
        Id: id,
        Name: $("#customer-edit-name-value").val(),
        Address: $("#customer-edit-address-value").val(),
    };

    $.ajax({
        type: "POST",
        url: "/Customer/Edit",
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

function openCreate() {
    $("#customer-create-box").modal();
   }

function customerCreate() {
    //var k;
    //count = 0;
    //var id;
    //while (k !== "pass"&& count<200) {
    //    id = Math.floor(Math.random() * 1000000) + 1;
       
    //    checkId(id, function (data) {
    //        check = data;
    //        console.log(check);
    //    });

    //    setTimeout(function () {

    //        k = check;
           


    //    }, 200);
    //    count++;
    //}


    
    var passdata = {

        Name: $("#customer-create-name-value").val(),
        Address: $("#customer-create-address-value").val()
    };

    $.ajax({
        type: "POST",
        url: "/Customer/Create",
        data: passdata,
        dataType: "json",
        success: function(data){

            if (data === "success create") {
                location.reload();
            }else {
                return ("unsave");
            };
            
        },
        failure: function (errMsg) {
            alert(errMsg);
        }


    });

}


function checkId(id, callback) {

    $.ajax({
        url: "CheckId?id=" + id,
        success: function (result) {
            if (result === "exist") {



                callback(result);


            } else if (result === "pass") {

                callback(result);

            }




        },
        error: function (result) {
            console.log(result);
        }

    })
}

function openDelete(Id) {
    console.log(Id);
    removeAppend();
    $.ajax({
        url: "/Customer/Details?id=" + Id, success: function (result) {
            name = result.Name;
            address = result.Address;
            $("#customer-delete-info").append("<div class="+"remove"+">Are you sure to delete <h3>Name: " + result.Name + "</h3> <h3> Address:" + result.Address+"</h3></div>");
            $("#customer-delete-Id").val(result.Id);
            console.log(name);

        },
        error: function (result) {
            console.log(result);
        }
    });
    $("#customer-delete-Id").attr('readonly', true);
    $("#customer-delete-box").modal();

}

function customerDelete() {
    id = $("#customer-delete-Id").val();
    console.log(id);

    $.ajax({
        type: "post",
        url: "/Customer/delete?id=" + id ,
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
 



