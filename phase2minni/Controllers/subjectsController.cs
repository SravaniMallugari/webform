using bal;
using helperlibrary;
using phase2minni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phase2minni.Controllers
{
    public class subjectsController : Controller
    {
        // GET: subjects
        Helper helper = null;
        public subjectsController()
        {
            helper = new Helper();
        }

        public ActionResult Index()
        {
            var stulist = helper.subList();
            List<submodel> modelsList = new List<submodel>();
            foreach (var item in stulist)
            {
                modelsList.Add(new submodel
                {
                    subjects_id = item.subjects_id,
                    subjects_name = item.subjects_name

                });
            }

            return View(modelsList);
        }
        public ActionResult Details(int id)
        {
            var data = helper.searchsub(id);
            submodel emp = new submodel();
            emp.subjects_id = id;
            emp.subjects_name = data.subjects_name;


            return View(emp);

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            BAL bal = new BAL();
            bal.subjects_id = Convert.ToInt32(Request["subjects_id"]);
            bal.subjects_name = Request["subjects_name"].ToString();



            bool ans = helper.Addsub(bal);
            if (ans)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var emp = helper.searchsub(id);
            submodel model = new submodel();
            model.subjects_id = id;
            model.subjects_name = emp.subjects_name;




            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.searchsub(id);
                emp.subjects_id = Convert.ToInt32(Request["subjects_id"]);
                emp.subjects_name = Request["subjects_name"].ToString();
                //       emp.student_class = Convert.ToInt32(Request["student_class"]);

                bool ans = helper.editsub(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var emp = helper.searchsub(id);
            submodel model = new submodel();
            model.subjects_id = id;
            model.subjects_name = emp.subjects_name;
            //    model.student_class = emp.student_class;



            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.searchsub(id);
                if (dataFound != null)
                {
                    bool ans = helper.removesub(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}