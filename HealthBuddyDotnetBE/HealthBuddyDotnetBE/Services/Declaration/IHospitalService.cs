using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthBuddyDotnetBE.RequestDto;//.Health.ReqDto;
using HealthBuddyDotnetBE.ResponseDto;

namespace HealthBuddyDotnetBE.Services.Declaration
{
    
    public interface IHospitalService
    {
        
        List<HospitalResDto> GetAllHospitals();

        ApiResponse AddHospital(HospitalReqDto hospitalReqDto);
        ApiResponse AddDoctor(long hospId, long doctorId);


        string ActivateHospital(long hospId);

        string InActivateHospital(long hospId);

        ApiResponse RemoveDoctor(long hospId, long doctorId);

        List<HospitalResDto> GetActiveHospitals();

        ApiResponse UpdateHospital(long hospId, [Required] HospitalReqDto hospitalReqDto);
    }
}
