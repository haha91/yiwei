function openmodal(Id) {
    var price;
    var name;

    $.ajax({
        url: "/product/edit?id=" + Id, success: function (result) {
            price = result.Price;
            name = result.Name;
            $("#name-value").val(name);
            $("#price-value").val(price);
            $("#product-id").val(Id);
        }, error: function (result) {

            console.log(result);
        }
    });
    $("#test").modal();
    console.log("ok");


}
function productSave() {
    var id = $("#product-id").val();
    var pdata = {
        Id: id,
        Name: $("#name-value").val(),
        Price: $("#price-value").val()
    };

    $.ajax({
        type: "POST",
        url: "/product/edit",
        // The key needs to match your method's input parameter (case-sensitive).
        data: pdata,
        dataType: "json",
        success: function (data) {
            if (data == "success save") {
                location.reload();
            }
        },
        failure: function (errMsg) {
            alert(errMsg);
        }


    });
}


function openCreateModal() {
    $("#productCreate").modal();
    console.log("creatin");
}

function newProductSave() {

    if ($("#create-name-value").val() != "" && $("#create-price-value").val() != "") {


        var pdata = {

            Name: $("#create-name-value").val(),
            Price: $("#create-price-value").val()
        };




    } else {

        $("#create-name-value").css("background-color", "red");
        return;
    }

    console.log(pdata)
    $.ajax({
        type: "POST",
        url: "/product/create",
        // The key needs to match your method's input parameter (case-sensitive).
        data: pdata,
        dataType: "json",
        success: function (data) {
            console.log(data)
            if (data == "success save") {
                
                location.reload();
            } else {
                console.log("unsave");
            }
        },
        failure: function (errMsg) {
            alert(errMsg);
        }


    });
}


function openDeleteModal(Id) {
    var price;
    var name;

    $.ajax({
        url: "/product/edit?id=" + Id, success: function (result) {
            price = result.Price;
            name = result.Name;
            $("#product-delete-name-value").val(name);
            $("#product-delete-price-value").val(price);
            $("#product-delete-id").val(Id);
        }, error: function (result) {

            console.log(result);
        }
    });
    $("#productDelete").modal();
    console.log("ok");


}

function deleteProduct() {
    var productId = $("#product-delete-id").val();
   

    $.ajax({
        type: "POST",
        url: "/product/delete?id=" + productId,
        // The key needs to match your method's input parameter (case-sensitive).
        data: {
            id: productId
        },
        dataType: "json",
        success: function (data) {
            
            if (data == "success Deleted") {
                console.log(data);
                location.reload();
            } else if (data == "can not find the Products") {
                return ("can not find this products")

            } else if (data == "you can not delete this product becuase the products still at the productSold") {
                return ("you can not delete this product becuase the products still at the productSold")
            }
        },
        failure: function (errMsg) {
            alert(errMsg);
        }


    });

}