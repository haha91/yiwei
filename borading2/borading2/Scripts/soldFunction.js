function openModal(Id) {
    $("#productSold-id").val(Id);
    console.log(Id);

    $.ajax({
        url: "/ProductSold/edit?id=" + Id, success: function (result) {
    
            $("#customer-id").val(result.CustomerId);
            $("#product-id").val(result.ProductId);
            $("#store-id").val(result.StoreId);
            $("#soldDate").val(moment(result.soldDate).format("YYYY-MM-DD"));
            result.CustomerList.forEach(function (element) {
            
                if (result.CustomerId == element.Id) {
                    $("#customer-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#customer-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }
               
            });
            result.StoreList.forEach(function (element) {

                if (result.StoreId == element.Id) {
                    $("#store-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#store-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }
            });
            result.ProductList.forEach(function (element) {

                if (result.ProductId == element.Id) {
                    $("#product-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#product-list").append("<option value=" + element.Id + ">" + element.Name + "</option>")
                };
            });
            
        }, error: function (result) {

            console.log(result.ProductList);
        }
    });
    $("#productSold-id").attr('readonly', true);
    $("#customer-id").attr('readonly', true);
    $("#product-id").attr('readonly', true);
    $("#store-id").attr('readonly', true);
    $("#sold-edit-box").modal();



}

function save() {
    customerId = $("#customer-list option:selected").val();
    productId = $("#product-list option:selected").val()
    storeId = ($("#store-list option:selected").val());
    date = $("#soldDate").val();

    console.log(productId);
  
    var id = $("#productSold-id").val();
    var passdata = {
        Id:id,
        ProductId: productId,
        CustomerId: customerId ,
        StoreId: storeId,
        soldDate:date
    };

    $.ajax({
        type: "POST",
        url: "/ProductSold/Save",
        data: passdata,
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data === "success save") {
                location.reload();
            }
        },
        failure: function (errMsg) {
            alert(errMsg)
        }
    });
}

function createOpen() {

    $.ajax({
        url: "/ProductSold/CreateInfo", success: function (result) {
                  
            result.CustomerList.forEach(function (element) {

                if (result.CustomerId == element.Id) {
                    $("#create-customer-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#create-customer-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }

            });
            result.StoreList.forEach(function (element) {

                if (result.StoreId == element.Id) {
                    $("#create-store-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#create-store-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }
            });
            result.ProductList.forEach(function (element) {

                if (result.ProductId == element.Id) {
                    $("#create-product-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#create-product-list").append("<option value=" + element.Id + ">" + element.Name + "</option>")
                };
            });

        }, error: function (result) {

            console.log(result.ProductList);
        }
    });  
    $("#soldCreate-box").modal();
}

function createSave() {
    customerId = $("#create-customer-list option:selected").val();
    productId = $("#create-product-list option:selected").val()
    storeId = ($("#create-store-list option:selected").val());
    date = $("#create-soldDate").val();
    console.log(storeId);
    console.log(productId);
    console.log(customerId);
    console.log(date);
    

      var passdata = {
        ProductId: productId,
        CustomerId: customerId,
        StoreId: storeId,
        soldDate: date
    };

    $.ajax({
        type: "POST",
        url: "/ProductSold/Create",
        data: passdata,
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data === "success create") {
                console.log("in");
                location.reload();
            }
        },
        failure: function (errMsg) {
            alert(errMsg)
        }
    });
}


function deleteOpen(Id) {
    $("#delete-productSold-id").val(Id);
    console.log(Id);
    $.ajax({
        url: "/ProductSold/edit?id=" + Id, success: function (result) {
            console.log(result);
          
            $("#delete-soldDate").val(moment(result.soldDate).format("YYYY-MM-DD"));
            result.CustomerList.forEach(function (element) {

                if (result.CustomerId == element.Id) {
                    $("#delete-customer-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#delete-customer-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }

            });
            result.StoreList.forEach(function (element) {

                if (result.StoreId == element.Id) {
                    $("#delete-store-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#delete-store-list").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                }
            });
            result.ProductList.forEach(function (element) {

                if (result.ProductId == element.Id) {
                    $("#delete-product-list").append("<option value=" + element.Id + " selected=" + "selected" + ">" + element.Name + "</option>");
                } else {
                    $("#delete-product-list").append("<option value=" + element.Id + ">" + element.Name + "</option>")
                };
            });

        }, error: function (result) {

            console.log(result.ProductList);
        }
    });
    $("#delete-productSold-id").attr('readonly', true);

    $("#sold-delete-box").modal();

}


function soldDelete() {
    id = $("#delete-productSold-id").val();
    console.log(id);

    $.ajax({
        type: "post",
        url: "/ProductSold/Delete?id=" + id,
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