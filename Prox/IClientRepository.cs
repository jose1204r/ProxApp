
using System.Linq;
using System.Collections.Generic;
using Prox.Models;

namespace Prox
{
    public interface IClientRepository
    {

        public IEnumerable<Client>clientinfo();

        public void insertclient(Client insert);

        public Client GetClient(int ID);


        public void DeleteClient(Client deleteclient);

        public void UpdateClient(Client updateclient);



    }


      
    



   




}
