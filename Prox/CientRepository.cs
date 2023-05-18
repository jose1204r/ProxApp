using Dapper;
using Prox.Models;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace Prox
{
    public class CientRepository : IClientRepository
    {
        private readonly IDbConnection _conn;
        
        
        public CientRepository(IDbConnection conn)
        {


            _conn = conn;
        }
        
        
        
        //client list
        
        public IEnumerable<Client> clientinfo()
        {
            return _conn.Query<Client>("SELECT * FROM client");
        }

       // get client

        public Client GetClient(int ID)
        {
            return _conn.QuerySingle<Client>("SELECT * FROM client WHERE ID = @ID",
                new { ID = ID});

        }
        // add client
        public void insertclient(Client insert)
        {
            _conn.Execute("INSERT INTO client (Company,Phone,Address,City,Zipcode,State,Email) VALUES (@Company,@Phone,@Address,@City,@Zipcode,@State,@Email);",
new { Company = insert.Company,Phone = insert.Phone,Address = insert.Address,City = insert.City,Zipcode = insert.Zipcode,State= insert.State,Email = insert.Email});


        }


        // Delete 
        public void DeleteClient(Client deleteclient)
        {
            _conn.Execute("DELETE FROM Client WHERE ID = @ID;",
                                      new { id = deleteclient.ID});

        }

        public void UpdateClient(Client updateclient)
        {
            _conn.Execute("UPDATE client SET Company = @Company,Phone = @Phone,Address = @Address,City = @City,Zipcode = @Zipcode,State = @State,Email = @Email WHERE Company = @company",
                 new { Company = updateclient.Company, Phone=updateclient.Phone, Address = updateclient.Address,city = updateclient.City,Zipcode = updateclient.Zipcode,State = updateclient.State,Email = updateclient.Email,ID = updateclient.ID});

        }
    }
}
