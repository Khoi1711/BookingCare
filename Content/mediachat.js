function sendMessage() {
    var messageInput = document.getElementById('message-input');
    var chatMessages = document.getElementById('chat-messages');

    var messageText = messageInput.value.trim();
    if (messageText !== '') {
        // Hiển thị tin nhắn trong chat box
        var messageElement = document.createElement('div');
        messageElement.innerText = 'You: ' + messageText;
        chatMessages.appendChild(messageElement);

        // Xử lý tư vấn và hiển thị mục cần khám
        var consultationResponse = getConsultationResponse(messageText);
        var consultationElement = document.createElement('div');
        consultationElement.innerText = 'Bot: ' + consultationResponse;
        chatMessages.appendChild(consultationElement);

        // Xóa nội dung của input
        messageInput.value = '';
    }
}

function getConsultationResponse(userMessage) {
    // Xử lý tư vấn ở đây, ví dụ:
    if (userMessage.toLowerCase().includes('hello')) {
        return 'Hello! How can I assist you today?';
    } else if (userMessage.toLowerCase().includes('ngoại khoa')) {
        return 'Bạn cần khám ngoại khoa. Có gì tôi có thể giúp bạn?';
    } else if (userMessage.toLowerCase().includes('nội khoa')) {
        return 'Bạn cần khám nội khoa. Có gì tôi có thể giúp bạn?';
    } else {
        return 'Xin lỗi, tôi không hiểu. Bạn có thể chọn ngoại khoa hoặc nội khoa.';
    }
}
