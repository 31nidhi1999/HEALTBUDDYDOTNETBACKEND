using System.Collections.Generic;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;

namespace HealthBuddyDotnetBE.Services.Declaration
{
    public interface IDoctorService
    {
        ApiResponse AddDoctor(DoctorReqDto doctorReqDto);
        List<DoctorResDto> GetDoctorsByHospital(long hospId);
        DoctorResDto GetDoctorById(long doctorId);
        List<DoctorResDto> GetAllDoctors();
        ApiResponse UpdateDoctor(long doctorId, DoctorReqDto doctorReqDto);
        ApiResponse InactivateDoctor(long doctorId);
        List<DoctorResDto> GetAllActiveDoctors();
        ApiResponse ActivateDoctor(long doctorId);
    }
}
