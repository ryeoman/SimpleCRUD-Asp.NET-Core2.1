using Medico.Challange.DL.Entities;
using Medico.Challange.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medico.Challange.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(string id);
        BaseResultViewModel SavePatientDetail(PatientViewModel param);
        BaseResultViewModel RemovePatient(string id);
        PatientViewModel CreateViewModel(string PatientId);
    }
}
