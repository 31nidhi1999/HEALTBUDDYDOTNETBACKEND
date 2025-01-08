using System.Collections.Generic;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;

namespace HealthBuddyDotnetBE.Services.Declaration
{
    public interface IAppointmentService
    {
        AppointmentResDto BookAppointment(AppointmentReqDto appointment);
        List<AppointmentResDto> GetAllAppointments();
        List<AppointmentResDto> GetAppointmentsByDoctorId(long doctorId);
        List<AppointmentResDto> GetAppointmentsByHospitalId(long hospId);
        AppointmentResDto GetAppointment(long id);
        string CancelAppointment(long appointId);
        string CompleteAppointment(long appointId);
        List<AppointmentResDto> GetAppointmentsByPatientId(long patientId);
    }
}
