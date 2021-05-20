function beforeSubmit(){
    // event.preventDefault();
    let confirm = $("#password-confirm").val();
    let input = $("#password");
    let password = $("#password").val();
    let validation = $("span#validate-password");

    console.log(confirm);
    console.log(password);

    if (password && confirm === password)
    {
        validation.hide();
        input.val(calcMD5(password));
        return true;
    }
    else
    {
        validation.text("Xác nhận mật khẩu không chính xác");
        validation.show();
    }
    return false;
}


function changeOptionList(list)
{
    let target = $("#accountOf");
    $("#accountOf option:gt(0)").remove();

    for (let i = 0; i < list.length; i++)
    {
        target.append(
            $("<option></option>")
            .attr("value", list[i].ID)
            .text(list[i].name));
    }
}

function changePersonList(authority, target)
{
    let url = `GetPersonDontHaveAccountApi/${authority}`;
    let loading = $(".loading-effect");

    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        before: () => {
            loading.toggleClass("show-flex");
        },
        success: function (response) {
            loading.toggleClass("show-flex");
            changeOptionList(response, target);
        },
        error: () => {
            loading.toggleClass("show-flex");
            // Show alert
        }
    })
}

function typeAccountChange()
{
    $("#authority").change((event) => {
        let options = event.target.options;
        let value = options[options.selectedIndex].value;
        
        changePersonList(value, event.target);
    });
}


$(() => {
    $("form").submit(() => {

        return beforeSubmit();;
    });

    typeAccountChange();
});