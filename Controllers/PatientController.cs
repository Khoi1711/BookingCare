using System.Configuration;
using System.Web.Mvc;
using System;

public class PatientController : Controller
{
    private readonly MailHelper _mailHelper;

    public PatientController()
    {
        string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
        string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
        string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

        _mailHelper = new MailHelper(smtpServer, smtpPort, smtpUsername, smtpPassword);
    }

    public ActionResult SendNotification(string patientEmail)
    {
        string subject = "Thông báo về cuộc hẹn";
        string body = "Đây là thông báo về cuộc hẹn của bạn.";

        _mailHelper.SendEmail(patientEmail, subject, body);

        return View();
    }
}