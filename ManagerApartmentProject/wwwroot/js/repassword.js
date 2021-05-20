
$(() => {
    let beforeSubmit = () => {
        let confirm = $("#new-password-confirm");

        let valid = confirm.val();

        let validate = $("span#validate-password");
        if (!valid) {
            validate
            .text("Xác nhận mật khẩu không được để trống").show();
            return false;
        }
        
        let inputP = $("#password");
        let inputN = $("#newPassword");

        let password = inputP.val();
        let newPassword = inputN.val();
        
        if (newPassword === valid) {
            validate.hide();

            inputP.val(calcMD5(password));
            inputN.val(calcMD5(newPassword));
            return true;
        }
        else {
            validate.text("Xác nhận mật khẩu mới không chính xác");
            validate.show();
        }
        return false;
    };
    
    $("form").submit(() => {

        return beforeSubmit();;
    });

});