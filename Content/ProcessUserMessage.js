function sendMessage() {
    var userMessage = $("#user-message").val();
    if (userMessage.trim() !== "") {
        // Gửi yêu cầu lên server và nhận phản hồi
        $.post("/Chat/ProcessUserMessage", { userMessage: userMessage }, function (data) {
            if (data.success) {
                // Hiển thị phản hồi từ server
                $("#chat-messages").append("<p>User: " + userMessage + "</p>");
                $("#chat-messages").append("<p>Bot: " + data.response + "</p>");
            } else {
                // Xử lý lỗi nếu có
                console.error(data.errorMessage);
            }

            // Xóa nội dung trong ô nhập liệu
            $("#user-message").val("");
        });
    }
}
