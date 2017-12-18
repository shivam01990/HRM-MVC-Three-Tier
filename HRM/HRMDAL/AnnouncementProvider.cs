using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMEntity;
using HRMDAL.Repository;
namespace HRMDAL
{
    public class AnnouncementProvider
    {
        public static IGenericRepository<Announcement> repository = new GenericRepository<HRMEntities, Announcement>();
        public static AnnouncementEntity GetAnnouncement()
        {
            AnnouncementEntity rType = new AnnouncementEntity();
            try
            {
                rType = repository.FindBy(x => x.AnnouncementId == 1).Select(x => new AnnouncementEntity
                  {
                      AnnouncementId = x.AnnouncementId,
                      AnnouncementText = x.AnnouncementText
                  }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return rType;
        }


        public static void UpdateAnnouncement(AnnouncementEntity ob)
        {
            try
            {
                Announcement temp = repository.FindBy(x => x.AnnouncementId == 1).FirstOrDefault();
                temp.AnnouncementId = 1;
                temp.AnnouncementText = ob.AnnouncementText;
                repository.Edit(temp);
                repository.Save();
            }
            catch
            {
                throw;
            }
        }
    }
}
