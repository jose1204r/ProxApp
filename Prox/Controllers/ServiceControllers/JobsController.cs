using Microsoft.AspNetCore.Mvc;
using Prox.Models;

namespace Prox.Controllers
{
    public class JobsController : Controller
    {


        private readonly IScheduleRepository repo;





        public JobsController(IScheduleRepository repo)
        {


            this.repo = repo;
        }



        public IActionResult Index()
        {
            var customer = repo.GetSchedueles();
            return View(customer);

        }



        public IActionResult insertServices(Scheduele services1)
        {
            repo.insertservice(services1);

            return RedirectToAction("Index");
        }

        public IActionResult Schedule()
        {
          

            return View();
        }

        public IActionResult ViewJob(int id)
        {
            var gs = repo.Getinschedule(id);

            return View(gs);
        }




        public IActionResult DeleteJob(Scheduele service) 
        { 
        

            repo.DeleteJob(service);
            return RedirectToAction("Index");
        
        
        
        }



        public IActionResult UpdateService(int id)
        {

            Scheduele service2 = repo.Getinschedule(id);

            if (service2 == null)
            {

                return View("ServiceNotFound");


            }

            return View(service2);
        }




        public IActionResult UpdateServiceToDatabase(Scheduele servicedata)
        {
            repo.UpdateSchedulet(servicedata);

            return RedirectToAction("Index", new { servicedata.ID });
        }










    }
}
