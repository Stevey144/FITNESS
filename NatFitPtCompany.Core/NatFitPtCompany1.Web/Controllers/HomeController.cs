using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pos8Company.Web.Extensions;
using Pos8Company.Web.Models;
using Pos8Company.Web.RepositoryLayer;
using Pos8Company.Web.Responses;
using System.Diagnostics;


namespace Pos8Company.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/NatFitPt")]
    public class HomeController : Controller
    {
        private IPositive8WebSiteRepository Positive8WebSiteRepository;
        private readonly IMapper _mapper;

        public HomeController(IPositive8WebSiteRepository positive8websiterepository, IMapper mapper)
        {
            Positive8WebSiteRepository = positive8websiterepository;
            _mapper = mapper;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Pos8Company.Web.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("contactus")]
        public IActionResult ContactUs([FromBody] BusinessContact value)
        {

            var response = new SingleModelResponse<BusinessContact>() as ISingleModelResponse<BusinessContact>;

            try
            {
                var entity = Positive8WebSiteRepository.AddBusinessContact(value);

                this.SendBusinessContactEmail(value);

                response.Model = value;
                response.Message = "Thanks, Please your business contact has been successfully saved, we will get in touch with you shortly.";

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }


            TempData["message"] = "Thanks, Please your business contact has been successfully saved, we will get in touch with you shortly.";

            return Redirect("/index.html#!/contacts");

        }//End of httPost

        [HttpGet]
        [Route("getofferscontact/{offerscontactid}")]

        public async Task<IActionResult> GetOffersContact(int businesscontactid)
        {


            var response = new ListModelResponse<OffersContact>() as IListModelResponse<OffersContact>;

            try
            {
                response.Model = await Positive8WebSiteRepository
                        .GetOffersContact(businesscontactid)
                        .Select(item => _mapper.Map<OffersContact>(item))
                        .ToListAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();

        }//End of httpGet

        [HttpPost]
        [Route("offers")]
        public IActionResult Offers([FromBody] OffersContact value)
        {


            var response = new SingleModelResponse<OffersContact>() as ISingleModelResponse<OffersContact>;

            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Positive8WebSiteRepository.AddOffersContact(value);

                    this.SendOffersContactEmail(value);

                    response.Model = value;
                    response.Message = "Thanks, Please your business contact has been successfully saved, we will get in touch with you shortly regarding the offers.";
                }

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }


            TempData["message"] = "Thanks, Please your business contact has been successfully saved, we will get in touch with you shortly regarding the offers.";
            
            return Redirect("/index.html#!/taster");
           // return View();

        }//End of httPost

        public OffersContact SendOffersContactEmail(OffersContact value)
        {

            var response = new SingleModelResponse<OffersContact>() as ISingleModelResponse<OffersContact>;

            OffersContact offersContact = new OffersContact();



            try
            {

                MailMessage mMailMessage = new MailMessage();

                // ' Set the sender address of the mail message
                mMailMessage.From = new MailAddress("noreply@natfitpt.co.uk");
                //' Set the recepient address of the mail message

                mMailMessage.To.Add(new MailAddress("robert.burton@natfitpt.co.uk"));

                // ' Set the subject of the mail message
                mMailMessage.Subject = "Free Taster Session Enquiry Submission from " + value.FirstName + " " + value.LastName;

                // ' Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                //' Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;


                mMailMessage.Body = "First Name : " + value.FirstName + "<br/>" + "Last Name : " + value.LastName + "<br/>" + "Organisation Email : " + value.OrganisationEmail + "<br/>" + "Telephone Number : " + value.TelephoneNumber + "<br/>" + "Mobile Number : " + value.MobileNumber + "<br/>"; ;

                var mSmtpClient = new SmtpClient("smtp.hosts.co.uk");
                NetworkCredential Credentials = new NetworkCredential("natfitpt.co.uk", "Tiibdt9?");
              //  mSmtpClient.EnableSsl = true;
             //   mSmtpClient.Port = 25;
                mSmtpClient.Credentials = Credentials;

                mSmtpClient.Send(mMailMessage);

            }
            catch (Exception ex)
            {
                response.Model = offersContact;
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            response.Model = offersContact;

            return offersContact;
        }


        public BusinessContact SendBusinessContactEmail(BusinessContact value)
        {

            var response = new SingleModelResponse<BusinessContact>() as ISingleModelResponse<BusinessContact>;

            BusinessContact businessContact = new BusinessContact();


            try
            {

                MailMessage mMailMessage = new MailMessage();

                // ' Set the sender address of the mail message
                mMailMessage.From = new MailAddress("noreply@natfitpt.co.uk");
                //' Set the recepient address of the mail message

                mMailMessage.To.Add(new MailAddress("robert.burton@natfitpt.co.uk"));

                // ' Set the subject of the mail message
                mMailMessage.Subject = "Business Enquiry Submission from " + value.FirstName + " " + value.LastName;

                // ' Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                //' Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;


                mMailMessage.Body = "First Name : " + value.FirstName + "<br/>" + "Last Name : " + value.LastName + "<br/>" + "Organisation Email : " + value.OrganisationEmail + "<br/>" + "Telephone Number : " + value.TelephoneNumber + "<br/>" + "Mobile Number : " + value.MobileNumber + "<br/>" + "Message : " + value.Message + "<br/>"; ;

                var mSmtpClient = new SmtpClient("smtp.hosts.co.uk");
                NetworkCredential Credentials = new NetworkCredential("natfitpt.co.uk", "Tiibdt9?");
              //  mSmtpClient.EnableSsl = true;
             //   mSmtpClient.Port = 25;
                mSmtpClient.Credentials = Credentials;

                mSmtpClient.Send(mMailMessage);

            }
            catch (Exception ex)
            {
                response.Model = businessContact;
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            response.Model = businessContact;

            return businessContact;
        }

        public IActionResult Offers()
        {
            return View();

        }


       // [Route("")]
        public IActionResult Index()
        {
            return Redirect("/index.html#!");
        }
    }
    }