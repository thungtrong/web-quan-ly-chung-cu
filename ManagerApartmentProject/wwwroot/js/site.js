// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(() => {
    var managers = ["chung cư", "Người Thuê", "Dân Cư", "Nhân Viên", "Thông Báo", "Hoá Đơn Thuê", "Chi Phí", "Góp Ý"];
    var _html;
    for (var i = 0; i < managers.length; i++) {
        let manager = managers[i];
        _html =
            `<li class="sidebar-item">
            <a href="#" data-toggle="collapse" data-target="#collapse-${i}" aria-expanded="false" aria-controls="#collapse-1">
                <span>
                ${manager}
                </span>
            </a>
            <ul class="collapse" id="collapse-${i}">
                <li>
                <a href=""><span class="glyphicon glyphicon-menu-right"></span>Danh sách ${manager}</a>
                </li>
                <li>
                <a href=""><span class="glyphicon glyphicon-menu-right"></span>Thêm ${manager}</a>
                </li>
                <li>
                <a href=""><span class="glyphicon glyphicon-menu-right"></span>Cập Nhật ${manager}</a>
                </li>
            </ul>
        </li>`;

        $(".sidebar-nav").append(_html);
    }
});