let menuIcon = document.querySelector("#menu-icon");

let downArrow = document.querySelector("#down-arrow");

let leftSidebar = document.querySelector(".left--sidebar");

let closeArrow = document.querySelector("#close-arrow");


let rightNavigation = document.querySelector(".right-navigation");



menuIcon.addEventListener("click", () => {
    if(leftSidebar.classList.contains('open')){
        leftSidebar.classList.remove('open');
        leftSidebar.classList.add('close');
    }


    else if(leftSidebar.classList.contains('close')){
        leftSidebar.classList.remove('close');
        leftSidebar.classList.add('open');
    }
})

closeArrow.addEventListener("click", () => {
    rightNavigation.classList.toggle("display-none");
    
})

function Setimage1(
    document.getElementById('img1').src="./images/dashboard-default.svg";
);