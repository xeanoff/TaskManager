// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var hidden = [];
var searchBar = document.getElementById("search-bar"); 

window.addEventListener("load", function (event) {
    var url = window.location.pathname.split("/");
    var action = url[2];
    if (action != null) {

        if (action == "SortByName") {
            sortSelector.value = 'name';
        }
        else if (action == "SortByDeadline") {
            sortSelector.value = 'deadline';
        }
        else if (action == "SortByPriority") {
            sortSelector.value = 'priority';
        }

        else if (action == "SortByNameOutdated") {
            sortSelector.value = 'name';
        }
        else if (action == "SortByDeadlineOutdated") {
            sortSelector.value = 'deadline';
        }
        else if (action == "SortByPriorityOutdated") {
            sortSelector.value = 'priority';
        }

        else if (action == "SortByNameDaily") {
            sortSelector.value = 'name';
        }
        else if (action == "SortByDeadlineDaily") {
            sortSelector.value = 'deadline';
        }
        else if (action == "SortByPriorityDaily") {
            sortSelector.value = 'priority';
        }
    }
});

function hide(elements) {
    elements = elements.length ? elements : [elements];

    for (var index = 0; index < elements.length; index++) {

        elements[index].style.display = 'none';

    }
}

searchBar.addEventListener('input', function (evt) {

    if (this.value.length >= 3) {

        let elements = document.getElementsByClassName("grid");
        for (var index = 0; index < elements.length; index++) {

            var content = elements[index].innerText;
            content = content.split(' ').join('');

            if (!content.toLowerCase().includes(this.value.toLowerCase())) {

                hide(elements[index]);
                hidden.push(elements[index]);

            }
        }
    }
    else {
        for (var index = 0; index < hidden.length; index++) {

            hidden[index].style.display = 'grid';

        }
    }
});