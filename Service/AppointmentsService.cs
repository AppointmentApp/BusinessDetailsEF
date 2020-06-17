using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDetailsEF.Service
{
    public class AppointmentsService:IAppointmentInterface
    {
        private appointo146updateContext auc = new appointo146updateContext();
        public AppointmentsService() { }
        public List<AppointmentsEntity> getall()
        {
            var appointments = auc.Appointments.Select(p => new AppointmentsEntity()
            {
                AappointmentId = p.appointmentId,
                ABusiness_Id = p.Business_Id,
                AName = p.Name,
                Aaddress = p.address,
                Adate1 = p.date1,
                AtimeSlot = p.timeSlot,
                AContact = p.Contact,
                Astatus = p.status
            }).ToList();
            return (appointments);
        }
        public List<AppointmentsEntity> getbyid(int id)
        {
            var appointments = auc.Appointments.Where(p => p.appointmentId == id).Select(p => new AppointmentsEntity()
            {

                AName = p.Name,
                Aaddress = p.address,
                Adate1 = p.date1,
                AtimeSlot = p.timeSlot,
                AContact = p.Contact,
                Astatus = p.status
            }).ToList();
            return (appointments);
        }

        public Appointments addappointments(AppointmentsEntity appointmentsEntity)
        {
            var appoints = new Appointments()
            {
                Name = appointmentsEntity.AName,
                address = appointmentsEntity.Aaddress,
                date1 = appointmentsEntity.Adate1,
                timeSlot = appointmentsEntity.AtimeSlot,
                Contact = appointmentsEntity.AContact,
                status = appointmentsEntity.Astatus
            };
            auc.Appointments.Add(appoints);
            auc.SaveChanges();
            return (appoints);
        }
        public Appointments updatestatus(AppointmentsEntity appentity, int id)
        {
            var ad = auc.Appointments.FirstOrDefault(item => item.appointmentId == id);
            if (ad != null)
            {

                ad.status = appentity.Astatus;
            }
            auc.Appointments.Update(ad);
            auc.SaveChanges();
            return (ad);
        }
        public Appointments deleteappointment(int id)
        {
            var appointment = auc.Appointments.Find(id);
            auc.Appointments.Remove(appointment);
            auc.SaveChanges();
            return (appointment);
           
        }
    }
}
