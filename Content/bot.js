// Trong phần script của trang HTML hoặc trong một tệp JS riêng biệt
document.addEventListener('DOMContentLoaded', function () {
    var botContainer = document.getElementById('bot-container');
    var botToggle = document.getElementById('bot-toggle');
    var botContent = document.getElementById('bot-content');

    botToggle.addEventListener('click', function () {
        botContainer.classList.toggle('bot-open');
        botContainer.classList.toggle('bot-closed');
        botContent.style.display = (botContent.style.display === 'none') ? 'block' : 'none';
    });
});
