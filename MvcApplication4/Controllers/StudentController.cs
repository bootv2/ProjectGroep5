using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        List<Student> studenten = new List<Student>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowStudent(String Achternaam)
        {
            fillStudenten();
            Student student = null;
            foreach (Student stud in studenten)
            {
                if (stud.achternaam == Achternaam) {
                    student = stud;
                    break;
                }
            }

            return View(student);
        }

        public ActionResult ShowAllStudents()
        {
            fillStudenten();
            return View(studenten);
        }
		
		public ActionResult EditStudent(int id)
		{
			fillStudenten();
            Student student = null;
            foreach (Student stud in studenten)
            {
                if (stud.id == id) {
                    student = stud;
                    break;
                }
            }

            return View(student);
		}

        public String SaveStudent(int id, String voornaam, String achternaam, String woonplaats)
        {
            fillStudenten();
            bool saved = false;
            foreach (Student stud in studenten)
            {
                if (stud.id == id)
                {
                    //update to db
                    saved = true;
                    break;
                }
            }

            return saved.ToString();
        }

        private void fillStudenten()
        {
            Student student = new Models.Student();
            student.id = 1;
            student.voornaam = "a";
            student.achternaam = "ienabd";
            student.woonplaats = "DH";
            studenten.Add(student);

            student = new Models.Student();
            student.id = 2;
            student.voornaam = "b";
            student.achternaam = "nog ienand";
            student.woonplaats = "DH";
            studenten.Add(student);

            student = new Models.Student();
            student.id = 3;
            student.voornaam = "c";
            student.achternaam = "ienand anders";
            student.woonplaats = "DH";
            studenten.Add(student);

        }
    }
}
