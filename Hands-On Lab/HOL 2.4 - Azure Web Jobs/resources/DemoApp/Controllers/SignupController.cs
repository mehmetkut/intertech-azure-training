using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebJobDemo.Web.Controllers
{
    public class SignupController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Index(string email)
        {
            await JobHelper.SendNotification(email);
            return RedirectToAction("index", "home");
        }
    }
}
