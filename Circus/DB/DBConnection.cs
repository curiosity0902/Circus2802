using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus.DB
{
    internal class DBConnection
    {
        public static CircussEntities1 circussEntities = new CircussEntities1();

        public static Worker loginedWorker;
        public static Artist loginedArtist;
        public static Admin loginedAdmin;
        public static AnimalTrainer loginedAnimalTrainer;

        public static SheduleArtist selectedForEditShedule;
    }
}
