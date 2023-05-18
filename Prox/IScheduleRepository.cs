using Prox.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Prox
{
    public interface IScheduleRepository
    {

        public IEnumerable<Scheduele> GetSchedueles();
        public void insertservice(Scheduele insert);

        public Scheduele Getinschedule(int ID);


        public void DeleteJob(Scheduele deletejob);

        public void UpdateSchedulet(Scheduele updateschedule);


    }
}
