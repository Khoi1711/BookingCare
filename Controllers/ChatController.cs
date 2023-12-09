using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{


    public class ChatController : Controller
    {
        // Đối tượng bot hoặc dịch vụ NLP
        private readonly NlpService nlpService;

        public ChatController()
        {
            // Khởi tạo đối tượng bot hoặc dịch vụ NLP ở đây
            nlpService = new NlpService();
        }

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
                // Gửi userMessage đến bot hoặc dịch vụ NLP và nhận phản hồi
                string botResponse = nlpService.ProcessUserMessage(userMessage);

                // Trả về phản hồi cho trình duyệt
                return Json(new { success = true, response = botResponse });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
