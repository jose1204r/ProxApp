using Dapper;
using Prox.Models;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
namespace Prox
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IDbConnection _conn;



        public ScheduleRepository(IDbConnection conn)
        {


            _conn = conn;
        }


        // get each view of serivce scheduled
        public Scheduele Getinschedule(int ID)
        {
            return _conn.QuerySingle<Scheduele>("SELECT * FROM services WHERE ID = @ID",
                 new { ID = ID });
        }


        // Get services shceduled table

        public IEnumerable<Scheduele> GetSchedueles()
        {
            return _conn.Query<Scheduele>("SELECT * FROM services");
        }
        // creste services
        public void insertservice(Scheduele insert)
        {
            _conn.Execute("INSERT INTO services (NAME,DESCRIPTION,PROBLEMS,DATETIME2,PHONE,ADDRESS,STATE,ZIPCODE,EMAIL) VALUES (@Name,@Description,@Problems,@Datetime2,@Phone,@Address,@State,@Zipcode,@Email);",
new { Name = insert.Name, Description = insert.Description, Problems= insert.Problems,Datetime2 = insert.Datetime2,Phone = insert.Phone,Address = insert.Address,State = insert.State,Zipcode = insert.Zipcode,Email = insert.Email });
        }



        public void DeleteJob(Scheduele deletejob)
        {
            _conn.Execute("DELETE FROM  services WHERE ID = @ID;",
                                     new { id = deletejob.ID});


        }

        public void UpdateSchedulet(Scheduele updateschedule)
        {
            _conn.Execute("UPDATE services SET Name = @Name,Description = @Description,Problems = @Problems,Datetime2 = @Datetime2,Phone = @Phone,Address= @Address,City =@City,State = @State,Zipcode = @Zipcode,Email = @Email WHERE Name = @Name",
                 new { Name = updateschedule.Name,Description =updateschedule.Description,Problems =updateschedule.Problems,Datetime2 =updateschedule.Datetime2,Phone =updateschedule.Phone,Address =updateschedule.Address,City = updateschedule.City,State =updateschedule.State,Zipcode =updateschedule.Zipcode,Email =updateschedule.Email,ID =updateschedule.ID });
        }
    }
}
