using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class NlpService
    {
        // Phương thức xử lý yêu cầu từ người dùng và trả về phản hồi
        public string ProcessUserMessage(string userMessage)
        {
            // Thực hiện xử lý NLP ở đây và trả về kết quả
            // Ví dụ đơn giản: Chỉ làm việc với userMessage và trả về nó
            return $"Bạn đã nói: {userMessage}";
        }
    }
}