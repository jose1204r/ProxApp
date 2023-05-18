using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Prox.Models;

namespace Prox.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository repo;

        public ClientController(IClientRepository repo)
        
        { 
        
           this.repo = repo;
        
        }
        // create view 
        public IActionResult Create()
        {

            return View();
        }

        // schedule serviceview
       

        // client table view
        public IActionResult Client()
        {

            var customer = repo.clientinfo();
            return View(customer);

           
        }
        // insert to client database
        public IActionResult insertcl(Client clientinsert)
        {
            repo.insertclient(clientinsert);

            return RedirectToAction("client");
        }

        // each clients views
        public IActionResult ViewClient(int id)
        {
            var cl = repo.GetClient(id);

            return View(cl);
        }


        public IActionResult DeleteClient(Client client)
        {
            repo.DeleteClient(client);
            return RedirectToAction("client");
        }
        
        public IActionResult UpdateClient(int id)
        {

            Client client2 = repo.GetClient(id);

            if (client2 == null)
            {

                return View("ClientNotFound");


            }

            return View(client2);
        }


        public IActionResult UpdateClientToDatabase(Client clientdata)
        {
            repo.UpdateClient(clientdata);

            return RedirectToAction("client", new { clientdata.ID });
        }








    }
}
