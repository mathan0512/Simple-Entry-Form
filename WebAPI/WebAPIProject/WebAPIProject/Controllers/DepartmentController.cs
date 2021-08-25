using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _Iconfigration;

        public DepartmentController(IConfiguration configuration)
        {

            _Iconfigration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            try
            {
                string query = @"select Departmentid,Departname from Department";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            try
            {
                string query = @"
                            insert into Department values('" + dep.DepartName + @"')
                                ";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Suucessfully added !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            try
            {
                string query = @"                            
                                update Department SET 
                                Departname = '" + dep.DepartName + @"' 
                                where Departmentid = " + dep.DepartmentId + @"";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Suucessfully Updated !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{deptid}")]
        public JsonResult Delete(int deptid)
        {
            try
            {
                string query = @"                            
                                Delete from  Department                                  
                                where Departmentid = " + deptid + @"";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Suucessfully Deleted !");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
