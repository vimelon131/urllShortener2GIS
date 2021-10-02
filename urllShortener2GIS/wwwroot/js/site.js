// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const input = document.getElementById('input-url');
const form = document.getElementById('enter-form');
const copyBtn = document.querySelector('.copy-btn');
const redirectBtn = document.querySelector('.redirect-link');


redirectBtn.addEventListener('click', () => {
    if (redirectBtn.href == '') {
        const emptyLink = document.querySelector('.empty-link');
        emptyLink.classList.add('empty-link-opened');
    }
})

input.addEventListener('click', () => {
    const emptyLink = document.querySelector('.empty-link');
    emptyLink.classList.remove('empty-link-opened');
})

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

copyBtn.addEventListener('click', () => {
    const copyText = document.querySelector('.input-url');
    copyText.select();
    document.execCommand('copy');
})

const matchURL = (url) => {
    var expression = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/;
    var regex = new RegExp(expression);
    return url.match(regex) ? true : false;
}
