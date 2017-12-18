using HRMDAL;
using HRMEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBLL
{
    public class AnnouncementServices
    {
        public static AnnouncementEntity GetAnnouncement()
        {
            return AnnouncementProvider.GetAnnouncement();
        }

        public static void UpdateAnnouncement(AnnouncementEntity ob)
        {
            AnnouncementProvider.UpdateAnnouncement(ob);
        }
    }
}
