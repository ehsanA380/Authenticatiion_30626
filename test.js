const form_container = document.getElementById('form_container');
console.log(form_container);
const colors = ['red', 'blue', 'green', 'black', 'orange'];
let hoverTimer;
// flag to ensure it runs only once
let hasRun = false;


let count = 0;

form_container.addEventListener('mouseenter', () => {
    if (hasRun) return;

    // Initialize count from localStorage if it exists
    if (localStorage.getItem("count") !== null) {
        count = parseInt(localStorage.getItem("count"), 10);
    } else {
        localStorage.setItem("count", count);
    }

    count = localStorage.getItem("count");
    console.log(count);
    // if (count >= 3) {
    //     count = 0;
    // }
    // else {
    //     count++;
    // }
    setTimeout(() => {
        if (hasRun) return;
        document.documentElement.style.setProperty('--initial-bg-color', colors[count]);
    }, 0)
    hoverTimer = setTimeout(() => {
        document.documentElement.style.setProperty('--bg-color', colors[count]);
        count = (count + 1) % colors.length;
        hasRun = true;
        localStorage.setItem("count", count);

    }, 400)


});

form_container.addEventListener('mouseleave', () => {
    clearTimeout(hoverTimer);
})