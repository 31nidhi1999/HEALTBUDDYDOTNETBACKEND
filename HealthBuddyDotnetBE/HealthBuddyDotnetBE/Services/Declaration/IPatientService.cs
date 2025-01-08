using System.Collections.Generic;
using HealthBuddyDotnetBE.RequestDto;//.Health.ReqDto;
using HealthBuddyDotnetBE.ResponseDto;

namespace HealthBuddyDotnetBE.Services.Declaration
{
    public interface IPatientService
    {
        List<PatientResDto> GetAllPatients();
        PatientResDto GetPatientById(long patientId);

        //ApiResponse UpdatePatient(PatientResDto patientResDto);
        ApiResponse AddPatient(PatientReqDto patientDto);
        ApiResponse InactivatePatient(long patientId);
        ApiResponse ActivatePatient(long patientId);
    }
}
