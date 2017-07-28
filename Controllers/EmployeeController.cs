using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Data_Access_Laye;
using WebApplication3.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public string Getstring()
        {
            return "hello world!";
        }
        public ActionResult listview()
        {
            Employee em = new Employee();
            
            SalesERPDAL dal = new SalesERPDAL();
            List<Employee> strlist = new List<Employee>();
            strlist=dal.embloyees.ToList();
            ViewData["strlist"] = strlist;
            return View("listview");
        }
        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult SaveEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {


                SalesERPDAL dal = new SalesERPDAL();
                dal.embloyees.Add(e);
                dal.SaveChanges();
                return RedirectToAction("listview");
            }
            else
            {
                //return RedirectToAction("listview");
                //return Content("输入数据通过验证");
                return View("addnew");
            }
        }
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult  editnew(int id)
        {
            SalesERPDAL dal = new SalesERPDAL();
            string strid = id.ToString();
            Employee em = new Employee();
            em= (from c in dal.embloyees where c.id == id select c).FirstOrDefault();
            ViewData["em"] = em;
            return View();
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult del(int id)
        {
            try
            {
                SalesERPDAL dal = new SalesERPDAL();
                //需要一个实体对象参数
                //db.Customers.Remove(new Customer() {CustomerNo = id });
                //1,创建要删除的对象
                Employee modelDel = new Employee() { id = id };
                //2,将对象添加到EF管理容器中
                dal.embloyees.Attach(modelDel);
                //3,修改对象的包装类对象标识为删除状态
                dal.embloyees.Remove(modelDel);
                //4,更新到数据库
                dal.SaveChanges();
                //5,更新成功,则命令流浪器重定向 到 /Home/Index 方法
                return RedirectToAction("listview", "employee");
            }
            catch (Exception)
            {
                //指定对应跳转的视图Test下的Test.cshtml文件
                return RedirectToAction("Test", "Test");
                //return Content("删除失败" + ex.Message);
            }
           
        }
        [HttpPost]
        public ActionResult modify(Employee em)
        {
            SalesERPDAL dal = new SalesERPDAL();
            DbEntityEntry<Employee> eee = dal.Entry<Employee>(em);
            if (ModelState.IsValid)
            {

                eee.State = EntityState.Unchanged;
                eee.Property(a => a.firstname).IsModified = true;
                eee.Property(a => a.lastname).IsModified = true;
                eee.Property(a => a.salary).IsModified = true;
                dal.SaveChanges();

                Response.Write("<script>alert('修改成功')</script>");


                //dal.embloyees<Employee> eee=dal.Entry<Employee>(model)
                return RedirectToAction("listview", "employee");
            }
            else
            {
                //ViewData["em"] = eee;
                return View("editnew");
            }
        }
    }
}