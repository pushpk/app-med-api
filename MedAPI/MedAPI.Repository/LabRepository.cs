using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class LabRepository : ILabRepository
    {
        public long SaveLab(Lab lab)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efLab = context.labs.Where(m => m.id == lab.id).FirstOrDefault();
                if (efLab == null)
                {
                    efLab = new DataAccess.lab();
                    context.labs.Add(efLab);
                }
                efLab.id = lab.id;
                efLab.ruc = lab.ruc;
                efLab.user_id = lab.userId;
                efLab.parentCompany = lab.parentCompany;
                efLab.labName = lab.labName;

                context.SaveChanges();

                return efLab.id;
            }
        }
    }
}
