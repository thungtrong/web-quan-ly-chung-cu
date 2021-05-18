$(() =>{
    $("button.submit-btn").click((event) => {
        event.preventDefault();
        let input = $("input#password");
        let password = input.val();
        input.val(calcMD5(password));
        $("form").submit();
    });
});