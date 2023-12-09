using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class MediaChatController : Controller
    {
            // Action để hiển thị trang chat
          
            // Action để hiển thị trang chat
            public ActionResult Index()
            {
                return View();
            }

            // Action để xử lý yêu cầu từ người dùng và trả về phản hồi
            [HttpPost]
            public JsonResult ProcessUserMessage(string userMessage)
            {
                try
                {
                    // Gửi userMessage đến hàm xử lý tư vấn và nhận phản hồi
                    string botResponse = GetConsultationResponse(userMessage);

                    // Trả về phản hồi cho trình duyệt
                    return Json(new { success = true, response = botResponse });
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    return Json(new { success = false, errorMessage = ex.Message });
                }
            }

            // Hàm xử lý tư vấn
            private string GetConsultationResponse(string userMessage)
            {
                // Xử lý tư vấn ở đây, ví dụ:
                if (userMessage.ToLower().Contains("hello"))
                {
                    return "Hello! How can I assist you today?";
                }
                else if (userMessage.ToLower().Contains("ngoại khoa"))
                {
                    return "Bạn cần khám ngoại khoa. Có gì tôi có thể giúp bạn?";
                }
                else if (userMessage.ToLower().Contains("nội khoa"))
                {
                    return "Bạn cần khám nội khoa. Có gì tôi có thể giúp bạn?";
                }
                else
                {
                    return "Xin lỗi, tôi không hiểu. Bạn có thể chọn ngoại khoa hoặc nội khoa.";
                }
            }
        }
    }
