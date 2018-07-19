using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medico.Challange.Web.Models;
using Medico.Challange.Services;
using Medico.Challange.Services.Models;

namespace Medico.Challange.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPatientService _patientService;
        public HomeController(IPatientService patientServicec)
        {
            _patientService = patientServicec;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPatientDetail(string PatientId)
        {
            var model = _patientService.CreateViewModel(PatientId);
            return PartialView("_PatientForm", model);
        }

        [HttpPost]
        public IActionResult SavePatientDetail(PatientViewModel param)
        {
            var result = _patientService.SavePatientDetail(param);
            return Json(result);
        }

        [HttpPost]
        public IActionResult RemovePatientDetail(string PatientId)
        {
            var result = _patientService.RemovePatient(PatientId);
            return Json(result);
        }

        [HttpPost]
        public JsonResult PatientList(DataTablesParam param)
        {
            var search = param.search.value ?? "";
            var data = _patientService.GetPatients();
            var totalRecord = data.Count();

            data = _patientService.GetPatients().Where(p => 
                            p.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                            p.LastName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                            p.PlaceOfBirth.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                            p.Gender.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                        );
            
            switch (param.order[0].column)
            {
                case 0:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.FirstName);
                    else
                        data = data.OrderByDescending(p => p.FirstName);
                    break;
                case 1:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.FirstName);
                    else
                        data = data.OrderByDescending(p => p.FirstName);
                    break;
                case 2:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.LastName);
                    else
                        data = data.OrderByDescending(p => p.LastName);
                    break;
                case 3:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.Gender);
                    else
                        data = data.OrderByDescending(p => p.Gender);
                    break;
                case 4:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.PlaceOfBirth);
                    else
                        data = data.OrderByDescending(p => p.PlaceOfBirth);
                    break;
                case 5:
                    if (param.order[0].dir.Equals("asc"))
                        data = data.OrderBy(p => p.DateOfBirth);
                    else
                        data = data.OrderByDescending(p => p.DateOfBirth);
                    break;
            }

            data = data.Skip(param.start).Take(param.length);

            var patientList = from a in data
                           select new
                           {
                               patientId = a.Id,
                               firstName = a.FirstName,
                               lastName = a.LastName,
                               gender = a.Gender,
                               birthPlace = a.PlaceOfBirth,
                               dateOfBirth = a.DateOfBirth == null ? "-" : ((DateTime)a.DateOfBirth).ToString("dd/MM/yyyy")
                           };

            return Json(new
            {
                draw = param.draw,
                recordsTotal = patientList.ToList().Count,
                recordsFiltered = totalRecord,
                data = patientList
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
