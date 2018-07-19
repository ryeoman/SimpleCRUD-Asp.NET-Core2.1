using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Medico.Challange.DL.Entities;
using Medico.Challange.Services.Models;
using Medico.Challange.Services.Repositories;

namespace Medico.Challange.Services
{
    public class PatientService : IPatientService
    {
        private IRepository<Patient> _repository;

        public PatientService(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public PatientViewModel CreateViewModel(string PatientId)
        {
            var data = _repository.GetById(PatientId);
            var result = Mapper.Map<PatientViewModel>(data);
            return result ?? new PatientViewModel();
        }
        
        public Patient GetPatient(string id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _repository.ListAll();
        }

        public BaseResultViewModel RemovePatient(string id)
        {
            var result = new BaseResultViewModel()
            {
                IsSuccess = false,
                Message = ""
            };

            var patient = _repository.GetById(id);
            if(patient != null)
            {
                _repository.Delete(patient);
                result.IsSuccess = true;
                result.Message = $"Successfully remove { patient.FirstName + " " + patient.LastName } data";
            }
            else
            {
                result.Message = "Remove failed";
            }

            return result;
        }

        public BaseResultViewModel SavePatientDetail(PatientViewModel param)
        {
            var result = new BaseResultViewModel() {
                IsSuccess = false,
                Message = ""
            };

            if (string.IsNullOrEmpty(param.Id))
            {
                //Add new
                var data = Mapper.Map<Patient>(param);
                data.CreatedDate = DateTime.Now;
                _repository.Add(data);

                result.IsSuccess = true;
                result.Message = "Successfully add new Patient detail";
            }
            else
            {
                //update
                var patient = _repository.GetById(param.Id);
                if(patient != null)
                {
                    Mapper.Map(param, patient);
                    patient.ModifiedDate = DateTime.Now;
                    _repository.Update(patient);

                    result.IsSuccess = true;
                    result.Message = "Successfully update Patient detail";
                }
                else
                {
                    result.Message = $"Patient with id: {param.Id} cannot be found";
                }
            }

            return result;
        }
        
    }
}
