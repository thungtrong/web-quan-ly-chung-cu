$(() => {

    let loading = $(".loading-effect");
    
    $("div.action-group a:last-child").on("click", (event) => {
        event.preventDefault();
        let card = $(event.target).parent().parent();
        let title = card.find(".card-title").text();
        let subtitle = card.find(".card-subtitle").text();

        let modal = $("#modal");
        
        modal.find(".modal-body").html(`<h5>${title}</h5><p>${subtitle}</p>`);
    });  

    const setListenersPagination = (tab, type, apiName) => {
        $(`${tab} .page-item${type} .page-link`).click((event) => {
            myOnclick(event, tab, type, apiName);
        });
    };

    const myOnclick = (event, tab, type, apiName) => {
        event.preventDefault();

        if (event.target.tagName === "A"){
            let target = $(event.target);
            let page;

            if (type === ".control"){
                page = $(`${tab} li.page-item.active .page-link`).data("page") + target.data("page");
            } else {
                page = target.data("page");
            }

            loadNotifications(
                `api/${apiName}/${page}`,
                tab,
                tab === "#my" ? true : false
            );
        }
    };

    const loadNotifications = (url, tab, auth) => {        
        $.ajax({
            type: "GET",
            url: url,
            dataType: "json",
            before: () => {
                loading.toggleClass("show-flex");
            },
            success: function (response) {
                loading.toggleClass("show-flex");
                if (response.status) {

                    renderNotification(
                        response.notifications,
                        $(`${tab} ul.list-notification`).html(""),
                        auth
                    );

                    renderPagination(response.pagination, tab);
                }
            },
            error: () => {
                loading.toggleClass("show-flex");
                // Show alert
            }
        });
    };

    const renderNotification = (notifications, dom, auth) => {
        let html;
        let child;
        for (let notify of notifications) {
            if (auth){
                child =
                `<div class="action-group text-right">
                    <a href="Update/${notify.ID}">Update</a>
                    <a data-toggle="modal" data-target="#modal">Delete</a>
                </div>`;
            } else {
                child = "";
            }

            html = 
            `<li class="card">
                <a href="Detail/${notify.ID}" class="card-body">
                    <h4 class="card-title">${notify.title}</h4>
                    <h6 class="card-subtitle text-muted font-italic">[${notify.creator}] - ${formatDate(notify.dateRelease)}</h6>
                </a>
                ${child}
            </li>`
            
            dom_tmp = $("")
            dom.append(html);
        }
        
    };

    const formatDate = (date) => {
        return `${date.substring(8, 10)}/${date.substring(5, 7)}/${date.substring(0, 4)}`
    }; 

    const renderPagination = (pagination, tab) => {
        // Xoa active hien tai
        $(`${tab} li.page-item.active`).toggleClass("active");

        let start = pagination.start;
        let end = pagination.end;

        // Clean thong bao cua trang hien tai
        $(`${tab} ul.pagination .page-item.number`).remove();

        // Bat dau bang nut Previous
        let pre = $(`${tab} .page-item.control.previous`);
        let next = $(`${tab} .page-item.control.next`);

        disabledControls(start, end, pre, next);

        let apiName = tab === "#all" ? "GetPageAll" : "GetPageMy";
        let active = "active";
        for (let i = start; i <= end; i++) {
            pre.after(
                `<li class="page-item number ${active}">
                    <a class="page-link" href="#" data-page="${i}">${i}</a>
                </li>`
            )
            // Chuyen den element moi tao, set su kien click
            pre = pre.next();
            pre.click((event) => {
                myOnclick(event, tab, ".number", apiName);
            });
            active = "";
        }
    };

    const disabledControls = (start, end, pre, next) => {
        pre.removeClass("disabled-link");
        next.removeClass("disabled-link");
        if (start === 0){
            pre.addClass("disabled-link");
        }
        if (end === next.data("page-max")){
            next.addClass("disabled-link");
        }
    };
    
    // Set su kien click cho cac button
    setListenersPagination("#all", ".number", "getPageAll");
    setListenersPagination("#all", ".control", "getPageAll");
    setListenersPagination("#my", ".number", "getPageMy");
    setListenersPagination("#my", ".control", "getPageMy");
    
});