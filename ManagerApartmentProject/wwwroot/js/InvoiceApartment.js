$(() => {
    var amounts = $("#details .form-group input#amount");
    amounts.keyup(() => {
        let sum = 0;
        for (let i = 0; i < amounts.length; i++){
            sum += amounts[i].value == "" ? 0 : parseInt(amounts[i].value) ;
            $("#invoice #amount").val(sum);
        }
    });

    $("#new-detail").click(() => {
        $(".form-group.detail-invoice:first").clone(true).appendTo("#details").find("input").val("");
        amounts = $("#details .form-group input#amount");
    });

    $("button#submit").click((event) => {
        event.preventDefault();
        
        let action = $("#submit").data("action");

        let invoiceApartmentViewModel;
        let num;

        if (action !== "DeleteConfirm")
        {
            console.log("Da chay");
            let invoiceOf = $("select#invoiceOf").val();
            
            let invoiceG = $("#invoice");
            
            let id = invoiceG.find("input#ID").val();

            // Lay Invoice
            let invoice = {"ID": id, "invoiceOf": invoiceOf};
            for (let tmp of invoiceG.find(".form-group input[id]")){
                if (tmp.id == 'status')
                {
                    invoice[tmp.id] = tmp.checked;
                }
                else
                {
                    invoice[tmp.id] = tmp.value;
                }
            }
            
            // Lay detail
            let inputDetails;
            let details= [];
            let detail = {};

            let detailsG = $("#details");
            for (let tmp of detailsG.find(".form-group"))
            {
                inputDetails = $(tmp).find("input[id]");
                detail = {};
                detail[inputDetails[0].id] = inputDetails[0].value;
                detail[inputDetails[1].id] = inputDetails[1].value;
                detail[inputDetails[2].id] = inputDetails[2].value;
                details.push(detail);
            }

            // Send data
            invoiceApartmentViewModel = {"invoice" : invoice, "details" : details};

            if (action === "CreateConfirm") {
                num = $("select#invoiceOf").val();
            } else {
                num = invoice["ID"];
            }
        }
        
        if (action == "DeleteConfirm") {
            num = $("#invoice input#ID").val();
        }
        

        let url = `/InvoiceApartment/${action}/${num}`;
        console.log(invoiceApartmentViewModel);
        console.log(url);
        $.ajax({
            type: "post",
            url: url,
            // data: JSON.stringify(invoidApartmentViewModel),
            data: invoiceApartmentViewModel,
            dataType: "json",

            success: function (response) {
                console.log(response)
                if (response.status){
                    console.log("Da chay");
                    window.location.assign("/InvoiceApartment");

                }
                // Hiển thị alert
            }
        });

    });

    
});