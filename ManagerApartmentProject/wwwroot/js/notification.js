$(() => {
    $("div.action-group a:last-child").on("click", (event) => {
        event.preventDefault();
        let card = $(event.target).parent().parent();
        let title = card.find(".card-title").text();
        let subtitle = card.find(".card-subtitle").text();

        let modal = $("#modal");
        
        modal.find(".modal-body").html(`<h5>${title}</h5><p>${subtitle}</p>`);
    });


    $(".of-all .page-item .page-link").on("click", (event) => {
        let page = $(event.target).data("page");
        console.log(page)
        $.ajax({
            type: "GET",
            url: "api/Notification/getPageAll/"+page,
            dataType: "json",
            success: function (response) {
                console.log(response);
            }
        });
    });

    $(".of-my .page-item .page-link").on("click", (event) => {
        let page = $(event.target).data("page");
        console.log(page)
        $.ajax({
            type: "GET",
            url: "api/Notification/getPageMy/"+page,
            dataType: "json",
            success: function (response) {
                console.log(response);
            }
        });
    });

    renderNotification = (auth) => {
        `<li class="card">
            <a href="~/Notification/Detail/{}" class="card-body">
                <h4 class="card-title">@notify.title</h4>
                <h6 class="card-subtitle text-muted font-italic">[@notify.creator] - @notify.dateRelease.ToString("dd/MM/yyyy")</h6>
            </a>

            @if ((bool) @ViewData["auth"]){
                <div class="action-group text-right">
                    <a asp-controller="Notification" asp-action="Update" asp-route-id="@notify.ID">Update</a>
                    <a data-toggle="modal" data-target="#modal">Delete</a>
                </div>
            }
        </li>`
    }

});