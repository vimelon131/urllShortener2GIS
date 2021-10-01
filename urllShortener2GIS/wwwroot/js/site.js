// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const input = document.getElementById('input-url');
const copyBtn = document.querySelector('.copy-btn');
const form = document.getElementById('enter-form');


form.addEventListener('submit', (e) => {
    const warningEmpty = document.getElementById('empty');
    const warningWrongUrl = document.getElementById('wrong');
    if (input.value.trim() === '') {
        warningWrongUrl.classList.remove('wrong-input-opened');
        warningEmpty.classList.add('wrong-input-opened');
        e.preventDefault();
    } else if (!matchURL(input.value.trim())) {
        warningEmpty.classList.remove('wrong-input-opened');
        warningWrongUrl.classList.add('wrong-input-opened');
        e.preventDefault();
    } else {
        warning.classList.remove('wrong-input-opened');
        warningWrongUrl.classList.remove('wrong-input-opened');
    }

});

const matchURL = (url) => {
    var expression = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/;
    var regex = new RegExp(expression);
    return url.match(regex) ? true : false;
}

copyBtn.addEventListener('click', () => {
    const copyText = document.querySelector('.input-url');
    copyText.select();
    document.execCommand('copy');
})