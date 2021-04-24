$(() => {
    var amounts = $("#details .form-group input#amount");
    amounts.keydown(() => {
        let sum = 0;
        for (let i = 0; i < amounts.length; i++){
            sum += parseInt(amounts[i].value);
            $("#invoice #amount").val(sum);
        }
    });

    $("button.submit").click((event) => {
        event.preventDefault();
        let invoiceG = $("#invoice");
        let detailsG = $("#details");
        
        let id = invoiceG.find("input#ID").val();
        // Lay Invoice
        let invoice = {"ID": id}
        for (let tmp of invoiceG.find(".form-group input")){
            invoice[tmp.id] = tmp.value
        }
        
        // Lay detail
        let inputDetails;
        let details= [];
        let detail = {};
        for (let tmp of detailsG.find(".form-group"))
        {
            inputDetails = $(tmp).find("input");
            detail = {};
            detail[inputDetails[0].id] = inputDetails[0].value;
            detail[inputDetails[1].id] = inputDetails[1].value;
            detail[inputDetails[2].id] = inputDetails[2].value;
            details.push(detail);
        }

        // Send data
        let invoidApartmentViewModel = {"invoice" : invoice, "details" : details};
        console.log(invoidApartmentViewModel)
        console.log(JSON.stringify(invoidApartmentViewModel));
        
        $.ajax({
            type: "post",
            url: "/InvoiceApartment/Update/"+invoice["ID"],
            // data: JSON.stringify(invoidApartmentViewModel),
            data: invoidApartmentViewModel,
            dataType: "json",

            success: function (response) {
                console.log(response.status)
                if (response.status){
                    console.log("Da chay");
                    window.location.assign("/InvoiceApartment");

                }
            }
        });

    });

    
});