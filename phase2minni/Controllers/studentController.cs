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
    public class studentController : Controller
    {
        // GET: student
        Helper helper = null;
        public studentController()
        {
            helper = new Helper();
        }

        public ActionResult Index()
        {
            var stulist = helper.List();
            List<studmodel> modelsList = new List<studmodel>();
            foreach (var item in stulist)
            {
                modelsList.Add(new studmodel
                {
                    student_id = item.student_id,
                    student_name = item.student_name,
                    
                });
            }

            return View(modelsList);
        }
        public ActionResult Details(int id)
        {
            var data = helper.search(id);
            studmodel emp = new studmodel();
            emp.student_id = id;
            emp.student_name = data.student_name;

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
            bal.student_id = Convert.ToInt32(Request["student_id"]);
            bal.student_name = Request["student_name"].ToString();
            


            bool ans = helper.AddE(bal);
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
            var emp = helper.search(id);
            studmodel model = new studmodel();
            model.student_id = id;
            model.student_name = emp.student_name;



            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.search(id);
                emp.student_id = Convert.ToInt32(Request["student_id"]);
                emp.student_name = Request["student_name"].ToString();
                

                bool ans = helper.Edit(emp);


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
            var emp = helper.search(id);
            studmodel model = new studmodel();
            model.student_id = id;
            model.student_name = emp.student_name;
            



            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.search(id);
                if (dataFound != null)
                {
                    bool ans = helper.remove(id);
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