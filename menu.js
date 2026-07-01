// const links = document.querySelectorAll('.link');

// links.forEach((link) => {
//     link.addEventListener('click', (e) => {
//         e.preventDefault(); stops ASP.NET LinkButton from posting back
//         links.forEach((li) => {
//             li.classList.remove('active');
//         })
//         link.classList.add('active');
//         console.log(e);
//     });
// });

const colors = ['red', 'blue', 'green', 'black', 'orange','purple'];

const form_container = document.getElementById('form_container');
let hoverTimer;
let hasRun = false;
let count = parseInt(localStorage.getItem("count") || "0", 10);

window.onload = () => {
    localStorage.setItem("count", count);
    console.log('HI');
    document.documentElement.style.setProperty('--initial-bg-color', colors[localStorage.getItem('count') == 0 ? colors.length-1 : localStorage.getItem('count')-1]);
    document.documentElement.style.setProperty('--bg-color', colors[localStorage.getItem('count') == 0  ? colors.length-1: localStorage.getItem('count')-1]);
    // document.documentElement.style.setProperty('--bg-color', colors[localStorage.getItem('count')]);
    // console.log(colors[localStorage.getItem("count")==4?0:1);


};

form_container.addEventListener('mouseenter', () => {
    if (hasRun) return;

    // Set immediate hover color
    document.documentElement.style.setProperty('--initial-bg-color', colors[count]);

    // Start 500ms hold timer
    hoverTimer = setTimeout(() => {
        document.documentElement.style.setProperty('--bg-color', colors[count]);
        document.documentElement.style.setProperty('--visibility', 'hidden');
        count = (count + 1) % colors.length;
        localStorage.setItem("count", count);
        hasRun = true; // lock after successful run
    }, 500);
});

form_container.addEventListener('mouseleave', () => {
    clearTimeout(hoverTimer); // cancel if mouse leaves early
});


// pop msg logic

